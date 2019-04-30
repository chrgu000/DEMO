
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a
	
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#b') and type='U')
	drop table #b
	
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#c') and type='U')
	drop table #c

DECLARE @dDate1 DATE
DECLARE @dDate2 DATE
DECLARE @dDate3 DATE

SET @dDate1 = '2015-3-1'
SET @dDate2 = DATEADD(month,1,@dDate1)

set @dDate3 = DATEADD(month,-1,@dDate1)


select a.cinvcode as 存货编码,sum(a.fQuantity) as 生产订单数量
	,null as 落料,null as 入库,null as 未完工,null as 材料领用,null as 上期盘点,null as 本期盘点
INTO #a
from ufdata_002_2015..PP_POMain a INNER JOIN ufdata_002_2015..PP_ProductPO b ON a.ID = b.ID
	inner join ufdata_002_2015..Inventory c on a.cInvCode = c.cInvCode
where b.dDate >= @dDate1 and b.dDate < @dDate2
group by a.cinvcode

insert into #a
select s1,null,sum(isnull(d14,0) ) as iQty,null,null,null,null,null
from SystemDB_TTJM.dbo.工序报表 
where Date1 >= @dDate1 and  Date1 < @dDate2
	and sType = '落料'
group by s1

INSERT INTO #a(存货编码,入库)
select b.cInvCode,SUM(b.iQuantity) AS iQty
from ufdata_002_2015..rdrecord a inner join ufdata_002_2015..RdRecords b on a.ID = b.ID
	INNER JOIN ufdata_002_2015..Inventory c ON b.cinvcode = c.cInvCode
where a.dDate  >= @dDate1 and a.dDate < @dDate2 AND cVouchType = '10' AND c.cinvccode LIKE '04%'
GROUP BY b.cInvCode	

insert into #a(存货编码,上期盘点)
select 存货编码,SUM(合计)
from  SystemDB_TTJM..在产品盘点表
where YEAR(盘点年月) = YEAR(@dDate3) and MONTH(盘点年月) = MONTH(@dDate3) 
group by 存货编码

insert into #a(存货编码,本期盘点)
select 存货编码,SUM(合计)
from  SystemDB_TTJM..在产品盘点表
where YEAR(盘点年月) = YEAR(@dDate1) and MONTH(盘点年月) = MONTH(@dDate1) 
group by 存货编码

select ROW_NUMBER() OVER(ORDER BY 存货编码) AS rowNumber,存货编码,b.cInvAddCode AS 型号,b.cInvName as 存货名称,b.cInvStd as 存货规格
    ,sum(生产订单数量) as 生产订单数量,sum(落料) as 落料
	 ,SUM(入库) AS 入库,SUM(材料领用) AS 材料领用
	 ,ISNULL(sum(生产订单数量),0) - ISNULL(sum(落料),0) AS 订单落料差
	 ,ISNULL(sum(落料),0) - ISNULL(SUM(入库),0) AS 落料入库差
	 ,sum(上期盘点) as 上期盘点
	 ,sum(本期盘点) as 本期盘点
	 ,sum(isnull(落料,0)) + sum(isnull(上期盘点,0)) - SUM(isnull(入库,0)) as 理论结存
	 ,cast(null as decimal(16,6)) as 单件材料成本
	 ,cast(null as decimal(16,2)) as 材料成本
into #b
from #a
	LEFT JOIN ufdata_002_2015..inventory b ON #a.存货编码 = b.cInvCode
group by 存货编码,b.cInvAddCode,b.cInvName,b.cInvStd
order by 存货编码 ,b.cInvAddCode


declare @rowNo int   
set @rowNo=1 

declare @max int
select @max = max(rowNumber) from #b

while @rowNo < @max
begin

	declare @autoid uniqueidentifier

	declare @InvCode varchar(50)
	select @InvCode = 存货编码 from #b where rowNumber = @rowNo
	
	select @InvCode = cInvDefine6 from Inventory where cInvCode = @InvCode

	select @autoid = iAutoId from ProductStructure where cPSPCode=@InvCode and isnull(bMRCBBOM,0) = 1
	
	exec PP_Struct_end @autoid,0,2

	declare @iPrice decimal(16,6) 
	select @iPrice = sum(cast (iQInvNCost as decimal(16,6)))
	from (SELECT * FROM tempdb..PP_WLQDCBtemp) PP_WLQDfinZX 

	update #b set 单件材料成本 = @iPrice,材料成本 = @iPrice * 入库 where rowNumber = @rowNo
	
	set @rowNo = @rowNo + 1
end

select #b.*,inv.cInvDefine6 ,inv2.cInvName
into #c
from #b left join Inventory inv on #b.存货编码 = inv.cInvCode
	left join Inventory inv2 on inv.cInvDefine6 = inv2.cInvCode
where inv2.cInvCCode = '040202'


select cInvDefine6 as 存货编码,cInvName as 存货名称
	,sum(生产订单数量) as 生产订单数量,sum(落料) as 落料,sum(入库) as 入库
	,sum(上期盘点) as 上期盘点,sum(本期盘点) as 本期盘点
	,sum(理论结存) as 理论结存,sum(isnull(理论结存,0)) - sum(isnull(本期盘点,0)) as 盘点误差
	,单件材料成本,sum(材料成本) as 材料成本
from #c
group by cInvDefine6,cInvName,单件材料成本
order by cInvDefine6

--select * from Inventory where cInvCode = 'R-X62-D1'