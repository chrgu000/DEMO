USE [UFDATA_001_2014]
GO
/****** Object:  StoredProcedure [dbo].[_Get产品材料耗用月汇总]    Script Date: 07/11/2015 19:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--		_Get产品材料耗用月汇总 '2015-04','010812'

ALTER proc [dbo].[_Get产品材料耗用月汇总](@yearMonth varchar(50),@cDepCode varchar(10))
as

set nocount on

--declare @yearMonth varchar(50)
--declare @cDepCode varchar(10)

--set @yearMonth = '2015-04'
--set @cDepCode = '0804'

declare @dDate datetime
set @dDate = @yearMonth + '-01'



	
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_TmpTH1]') AND type in (N'U'))
	DROP TABLE [dbo]._TmpTH1

--#a 初始化材料列表，并加载期初，U8出库列表，材料耗用登记汇总
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a
	
create table #a(材料编码 varchar(100)
	,月初存料数量 decimal(16,6),月初存料金额 decimal(16,2),月初存料单价 decimal(16,4)
	,本月耗用数量 decimal(16,6),本月耗用金额 decimal(16,2),本月耗用单价 decimal(16,4)
	,收发存出库数量 decimal(16,6),收发存出库金额 decimal(16,2),收发存出库单价 decimal(16,4)
	)


--期初材料及本期发生的材料作为本次用料表所有材料信息
--期初材料
insert into #a(材料编码,月初存料数量,月初存料金额,月初存料单价)
select 存货编码,sum(期初数量),cast(sum(期初金额)  as decimal(16,2)),cast(sum(期初金额) / sum(期初数量) as decimal(16,4))
from _QCMaterial a
where 会计期间 = @yearMonth and a.部门 = @cDepCode
group by 存货编码
having sum(期初数量) <> 0

--本期用材料
insert into #a(材料编码,本月耗用数量)
select distinct a.存货编码 as 材料编码,sum(数量)
from dbo._ProMaterial a
where a.会计期间 = @yearMonth and a.部门 = @cDepCode
group by a.存货编码
order by a.存货编码

--出库单列表材料
insert into #a(材料编码,收发存出库数量,收发存出库金额,收发存出库单价)
select  b.cInvCode,sum(b.iQuantity) ,cast(SUM(iPrice) as decimal(16,2)) ,cast(sum(iPrice) / sum(b.iQuantity) as decimal(16,4))
from rdrecord11 a inner join rdrecords11 b on a.ID = b.ID
	inner join Inventory c on b.cInvCode = c.cInvCode
where a.dDate >= @dDate and a.dDate < dateadd(month,1,@dDate)
	and isnull(iQuantity,0) <> 0 and a.cDepCode = @cDepCode
	and a.cWhCode in ('01','02','03','04','05','06','14','19')
	and c.cInvCCode not like '8%'
group by b.cInvCode
having sum(b.iQuantity) <> 0

	
	--select * from #a
	
select 材料编码
	,sum(月初存料数量) as 月初存料数量,sum(月初存料金额) as 月初存料金额,sum(月初存料单价) as 月初存料单价
	,sum(本月耗用数量) as 本月耗用数量,cast(cast(case when (sum(isnull(收发存出库数量,0)) + sum(isnull(月初存料数量,0))) <> 0 then (sum(isnull(收发存出库金额,0)) + sum(isnull(月初存料金额,0))) / (sum(isnull(收发存出库数量,0)) + sum(isnull(月初存料数量,0))) else null end as decimal(16,4)) as decimal(16,4)) as 本月耗用单价
	,cast(sum(本月耗用数量) * case when (sum(isnull(收发存出库数量,0)) + sum(isnull(月初存料数量,0))) <> 0 then (sum(isnull(收发存出库金额,0)) + sum(isnull(月初存料金额,0))) / (sum(isnull(收发存出库数量,0)) + sum(isnull(月初存料数量,0))) else null end as decimal(16,2)) as 本月耗用金额
	,SUM(收发存出库数量) as 收发存出库数量,cast(SUM(收发存出库金额) as decimal(16,2)) as 收发存出库金额,cast(SUM(收发存出库金额) / SUM(收发存出库数量) as decimal(16,4)) as 收发存出库单价
into _TmpTH1
from #a
group by 材料编码
order by 材料编码

if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a

--select * from _TmpTH1

--将本期登记的产品横向展开
--1. 获得本期所有产品
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#b') and type='U')
	drop table #b
	
select ROW_NUMBER() OVER(ORDER BY 产品编码) AS rowNumber,a.*
into #b
from
(
	select  distinct a.产品编码,b.cInvName as 产品名称,b.cInvStd as 产品规格,b.cCurrencyName as 通用名称,c.cComUnitName as 单位
	from dbo._ProMaterial a 
		inner join Inventory b on a.产品编码 = b.cInvCode and b.cInvCCode not like '8%'
		inner join ComputationUnit  c on c.cComunitCode = b.cComUnitCode 
	where a.会计期间 = @yearMonth and a.部门 = @cDepCode
)a
order by a.产品编码


declare @rowNo int   
set @rowNo=1 

declare @max int
select @max = max(rowNumber) from #b

while @rowNo <= @max
begin	
	alter table _TmpTH1 add 产品数量 decimal(16,6) null
	alter table _TmpTH1 add 产品单价 decimal(16,4) null
	alter table _TmpTH1 add 产品金额 decimal(16,2) null

	declare @InvCode varchar(200)
	declare @InvName varchar(200)
	select @InvCode = 产品编码,@InvName = 产品名称 from #b where rowNumber = @rowNo
	
	declare @ColName varchar(200)
	set @ColName = '产品数量_' + @InvCode + '_' + @InvName
	exec sp_rename '_TmpTH1.[产品数量]',@ColName,'column'

	set @ColName = '产品金额_' + @InvCode + '_'+ @InvName
	exec sp_rename '_TmpTH1.[产品金额]',@ColName,'column'
	
	set @ColName = '产品单价_' + @InvCode + '_'+ @InvName
	exec sp_rename '_TmpTH1.[产品单价]',@ColName,'column'

	set @rowNo = @rowNo + 1
end


--2. 逐行将产品耗用的材料信息填入

--	select * from _TmpTH1

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_TmpTH2]') AND type in (N'U'))
	DROP TABLE [dbo]._TmpTH2
	
select ROW_NUMBER() OVER(ORDER BY 材料编码) AS rowNumber,* 
into _TmpTH2
from _TmpTH1
	
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_TmpTH1]') AND type in (N'U'))
	DROP TABLE [dbo]._TmpTH1
	
set @rowNo=1 
select @max = max(rowNumber) from _TmpTH2


while @rowNo <= @max
begin	
	
	if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#c') and type='U')
		drop table #c
		
	declare @cInvCode varchar(100)	
	declare @d本月耗用单价 decimal(16,4)
	select @cInvCode = 材料编码,@d本月耗用单价 = 本月耗用单价 from _TmpTH2 where rowNumber = @rowNo
	
	--select @cInvCode,@d本月耗用单价
	
	--3. 通过材料找到所有相关产品,并更新材料用量
	declare @RowNoCol int 
	set @RowNoCol = 1
	
	select ROW_NUMBER() OVER(ORDER BY 存货编码) AS rowNumber,a.* ,b.cInvName as 产品名称
	into #c
	from _ProMaterial a
		inner join Inventory b on a.产品编码 = b.cInvCode
	where a.会计期间 = @yearMonth and a.部门 = @cDepCode and 存货编码 = @cInvCode
	
	
	declare @RowMaxCol int
	select @RowMaxCol = max(rowNumber) from #c
	
	while @RowNoCol <= @RowMaxCol
	begin		
		declare @d本月耗用数量 decimal(16,6)
		declare @d本月耗用金额 decimal(16,2)
		declare @InvCode2 nvarchar(200) 
		declare @InvName2 nvarchar(200) 

		select @InvCode2 = 产品编码,@InvName2 = 产品名称,@d本月耗用数量 = 数量	from #c where rowNumber = @RowNoCol
		set @d本月耗用金额 = isnull(@d本月耗用数量,0) * isnull(@d本月耗用单价,0)
		
		declare @ColName2 nvarchar(200)
		set @ColName2 = N'产品数量_' + @InvCode2 + '_' + @InvName2
		declare @ColName3 nvarchar(200)
		set @ColName3 = N'产品单价_' + @InvCode2 + '_' + @InvName2
		declare @ColName4 nvarchar(200)
		set @ColName4 = N'产品金额_' + @InvCode2 + '_' + @InvName2
		
		declare @sSQL nvarchar(3000)
		set @sSQL = 'update _TmpTH2 set [' + @ColName2 + '] = ' + convert(nvarchar(20),isnull(@d本月耗用数量,0))  
		set @sSQL = @sSQL + ',[' + @ColName3 + '] = ' + convert(nvarchar(20),isnull(@d本月耗用单价,0))
		set @sSQL = @sSQL + ',[' + @ColName4 + '] = ' + convert(nvarchar(20),isnull(@d本月耗用金额,0))
		set @sSQL = @sSQL + ' where rowNumber = ' + convert(nvarchar(20),@rowNo)
				
		execute sp_executesql @sSQL
						
		set @RowNoCol = @RowNoCol + 1
	end

	set @rowNo = @rowNo + 1
end

	alter table _TmpTH2 add 月末结存数量 decimal(16,6) null
	alter table _TmpTH2 add 月末结存单价 decimal(16,4) null
	alter table _TmpTH2 add 月末结存金额 decimal(16,2) null

update _TmpTH2 
	set  月末结存数量 = ISNULL(月初存料数量,0) + ISNULL(收发存出库数量,0) - isnull(本月耗用数量,0)
		,月末结存金额 = ISNULL(月初存料金额,0) + ISNULL(收发存出库金额,0) - isnull(本月耗用金额,0)
		,月末结存单价 = 本月耗用单价

--update _TmpTH2 
--	set  月末结存单价 = 月末结存金额 / 月末结存数量

select * from _TmpTH2 
--where 材料编码 = '0491012'
order by 材料编码 
	
--	update _TmpTH2 set [产品数量_714002_热塑套（停用）] = 0.000000,[产品单价_714002_热塑套（停用）] = 0.000000,[产品金额_714002_热塑套（停用）] = 0.000000 where rowNumber = 124