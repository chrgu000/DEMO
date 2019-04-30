USE [UFDATA_001_2014]
GO
/****** Object:  StoredProcedure [dbo].[_Get��Ʒ���Ϻ����»���]    Script Date: 07/11/2015 19:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--		_Get��Ʒ���Ϻ����»��� '2015-04','010812'

ALTER proc [dbo].[_Get��Ʒ���Ϻ����»���](@yearMonth varchar(50),@cDepCode varchar(10))
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

--#a ��ʼ�������б��������ڳ���U8�����б����Ϻ��õǼǻ���
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a
	
create table #a(���ϱ��� varchar(100)
	,�³��������� decimal(16,6),�³����Ͻ�� decimal(16,2),�³����ϵ��� decimal(16,4)
	,���º������� decimal(16,6),���º��ý�� decimal(16,2),���º��õ��� decimal(16,4)
	,�շ���������� decimal(16,6),�շ�������� decimal(16,2),�շ�����ⵥ�� decimal(16,4)
	)


--�ڳ����ϼ����ڷ����Ĳ�����Ϊ�������ϱ����в�����Ϣ
--�ڳ�����
insert into #a(���ϱ���,�³���������,�³����Ͻ��,�³����ϵ���)
select �������,sum(�ڳ�����),cast(sum(�ڳ����)  as decimal(16,2)),cast(sum(�ڳ����) / sum(�ڳ�����) as decimal(16,4))
from _QCMaterial a
where ����ڼ� = @yearMonth and a.���� = @cDepCode
group by �������
having sum(�ڳ�����) <> 0

--�����ò���
insert into #a(���ϱ���,���º�������)
select distinct a.������� as ���ϱ���,sum(����)
from dbo._ProMaterial a
where a.����ڼ� = @yearMonth and a.���� = @cDepCode
group by a.�������
order by a.�������

--���ⵥ�б����
insert into #a(���ϱ���,�շ����������,�շ��������,�շ�����ⵥ��)
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
	
select ���ϱ���
	,sum(�³���������) as �³���������,sum(�³����Ͻ��) as �³����Ͻ��,sum(�³����ϵ���) as �³����ϵ���
	,sum(���º�������) as ���º�������,cast(cast(case when (sum(isnull(�շ����������,0)) + sum(isnull(�³���������,0))) <> 0 then (sum(isnull(�շ��������,0)) + sum(isnull(�³����Ͻ��,0))) / (sum(isnull(�շ����������,0)) + sum(isnull(�³���������,0))) else null end as decimal(16,4)) as decimal(16,4)) as ���º��õ���
	,cast(sum(���º�������) * case when (sum(isnull(�շ����������,0)) + sum(isnull(�³���������,0))) <> 0 then (sum(isnull(�շ��������,0)) + sum(isnull(�³����Ͻ��,0))) / (sum(isnull(�շ����������,0)) + sum(isnull(�³���������,0))) else null end as decimal(16,2)) as ���º��ý��
	,SUM(�շ����������) as �շ����������,cast(SUM(�շ��������) as decimal(16,2)) as �շ��������,cast(SUM(�շ��������) / SUM(�շ����������) as decimal(16,4)) as �շ�����ⵥ��
into _TmpTH1
from #a
group by ���ϱ���
order by ���ϱ���

if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a

--select * from _TmpTH1

--�����ڵǼǵĲ�Ʒ����չ��
--1. ��ñ������в�Ʒ
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#b') and type='U')
	drop table #b
	
select ROW_NUMBER() OVER(ORDER BY ��Ʒ����) AS rowNumber,a.*
into #b
from
(
	select  distinct a.��Ʒ����,b.cInvName as ��Ʒ����,b.cInvStd as ��Ʒ���,b.cCurrencyName as ͨ������,c.cComUnitName as ��λ
	from dbo._ProMaterial a 
		inner join Inventory b on a.��Ʒ���� = b.cInvCode and b.cInvCCode not like '8%'
		inner join ComputationUnit  c on c.cComunitCode = b.cComUnitCode 
	where a.����ڼ� = @yearMonth and a.���� = @cDepCode
)a
order by a.��Ʒ����


declare @rowNo int   
set @rowNo=1 

declare @max int
select @max = max(rowNumber) from #b

while @rowNo <= @max
begin	
	alter table _TmpTH1 add ��Ʒ���� decimal(16,6) null
	alter table _TmpTH1 add ��Ʒ���� decimal(16,4) null
	alter table _TmpTH1 add ��Ʒ��� decimal(16,2) null

	declare @InvCode varchar(200)
	declare @InvName varchar(200)
	select @InvCode = ��Ʒ����,@InvName = ��Ʒ���� from #b where rowNumber = @rowNo
	
	declare @ColName varchar(200)
	set @ColName = '��Ʒ����_' + @InvCode + '_' + @InvName
	exec sp_rename '_TmpTH1.[��Ʒ����]',@ColName,'column'

	set @ColName = '��Ʒ���_' + @InvCode + '_'+ @InvName
	exec sp_rename '_TmpTH1.[��Ʒ���]',@ColName,'column'
	
	set @ColName = '��Ʒ����_' + @InvCode + '_'+ @InvName
	exec sp_rename '_TmpTH1.[��Ʒ����]',@ColName,'column'

	set @rowNo = @rowNo + 1
end


--2. ���н���Ʒ���õĲ�����Ϣ����

--	select * from _TmpTH1

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_TmpTH2]') AND type in (N'U'))
	DROP TABLE [dbo]._TmpTH2
	
select ROW_NUMBER() OVER(ORDER BY ���ϱ���) AS rowNumber,* 
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
	declare @d���º��õ��� decimal(16,4)
	select @cInvCode = ���ϱ���,@d���º��õ��� = ���º��õ��� from _TmpTH2 where rowNumber = @rowNo
	
	--select @cInvCode,@d���º��õ���
	
	--3. ͨ�������ҵ�������ز�Ʒ,�����²�������
	declare @RowNoCol int 
	set @RowNoCol = 1
	
	select ROW_NUMBER() OVER(ORDER BY �������) AS rowNumber,a.* ,b.cInvName as ��Ʒ����
	into #c
	from _ProMaterial a
		inner join Inventory b on a.��Ʒ���� = b.cInvCode
	where a.����ڼ� = @yearMonth and a.���� = @cDepCode and ������� = @cInvCode
	
	
	declare @RowMaxCol int
	select @RowMaxCol = max(rowNumber) from #c
	
	while @RowNoCol <= @RowMaxCol
	begin		
		declare @d���º������� decimal(16,6)
		declare @d���º��ý�� decimal(16,2)
		declare @InvCode2 nvarchar(200) 
		declare @InvName2 nvarchar(200) 

		select @InvCode2 = ��Ʒ����,@InvName2 = ��Ʒ����,@d���º������� = ����	from #c where rowNumber = @RowNoCol
		set @d���º��ý�� = isnull(@d���º�������,0) * isnull(@d���º��õ���,0)
		
		declare @ColName2 nvarchar(200)
		set @ColName2 = N'��Ʒ����_' + @InvCode2 + '_' + @InvName2
		declare @ColName3 nvarchar(200)
		set @ColName3 = N'��Ʒ����_' + @InvCode2 + '_' + @InvName2
		declare @ColName4 nvarchar(200)
		set @ColName4 = N'��Ʒ���_' + @InvCode2 + '_' + @InvName2
		
		declare @sSQL nvarchar(3000)
		set @sSQL = 'update _TmpTH2 set [' + @ColName2 + '] = ' + convert(nvarchar(20),isnull(@d���º�������,0))  
		set @sSQL = @sSQL + ',[' + @ColName3 + '] = ' + convert(nvarchar(20),isnull(@d���º��õ���,0))
		set @sSQL = @sSQL + ',[' + @ColName4 + '] = ' + convert(nvarchar(20),isnull(@d���º��ý��,0))
		set @sSQL = @sSQL + ' where rowNumber = ' + convert(nvarchar(20),@rowNo)
				
		execute sp_executesql @sSQL
						
		set @RowNoCol = @RowNoCol + 1
	end

	set @rowNo = @rowNo + 1
end

	alter table _TmpTH2 add ��ĩ������� decimal(16,6) null
	alter table _TmpTH2 add ��ĩ��浥�� decimal(16,4) null
	alter table _TmpTH2 add ��ĩ����� decimal(16,2) null

update _TmpTH2 
	set  ��ĩ������� = ISNULL(�³���������,0) + ISNULL(�շ����������,0) - isnull(���º�������,0)
		,��ĩ����� = ISNULL(�³����Ͻ��,0) + ISNULL(�շ��������,0) - isnull(���º��ý��,0)
		,��ĩ��浥�� = ���º��õ���

--update _TmpTH2 
--	set  ��ĩ��浥�� = ��ĩ����� / ��ĩ�������

select * from _TmpTH2 
--where ���ϱ��� = '0491012'
order by ���ϱ��� 
	
--	update _TmpTH2 set [��Ʒ����_714002_�����ף�ͣ�ã�] = 0.000000,[��Ʒ����_714002_�����ף�ͣ�ã�] = 0.000000,[��Ʒ���_714002_�����ף�ͣ�ã�] = 0.000000 where rowNumber = 124