
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


select a.cinvcode as �������,sum(a.fQuantity) as ������������
	,null as ����,null as ���,null as δ�깤,null as ��������,null as �����̵�,null as �����̵�
INTO #a
from ufdata_002_2015..PP_POMain a INNER JOIN ufdata_002_2015..PP_ProductPO b ON a.ID = b.ID
	inner join ufdata_002_2015..Inventory c on a.cInvCode = c.cInvCode
where b.dDate >= @dDate1 and b.dDate < @dDate2
group by a.cinvcode

insert into #a
select s1,null,sum(isnull(d14,0) ) as iQty,null,null,null,null,null
from SystemDB_TTJM.dbo.���򱨱� 
where Date1 >= @dDate1 and  Date1 < @dDate2
	and sType = '����'
group by s1

INSERT INTO #a(�������,���)
select b.cInvCode,SUM(b.iQuantity) AS iQty
from ufdata_002_2015..rdrecord a inner join ufdata_002_2015..RdRecords b on a.ID = b.ID
	INNER JOIN ufdata_002_2015..Inventory c ON b.cinvcode = c.cInvCode
where a.dDate  >= @dDate1 and a.dDate < @dDate2 AND cVouchType = '10' AND c.cinvccode LIKE '04%'
GROUP BY b.cInvCode	

insert into #a(�������,�����̵�)
select �������,SUM(�ϼ�)
from  SystemDB_TTJM..�ڲ�Ʒ�̵��
where YEAR(�̵�����) = YEAR(@dDate3) and MONTH(�̵�����) = MONTH(@dDate3) 
group by �������

insert into #a(�������,�����̵�)
select �������,SUM(�ϼ�)
from  SystemDB_TTJM..�ڲ�Ʒ�̵��
where YEAR(�̵�����) = YEAR(@dDate1) and MONTH(�̵�����) = MONTH(@dDate1) 
group by �������

select ROW_NUMBER() OVER(ORDER BY �������) AS rowNumber,�������,b.cInvAddCode AS �ͺ�,b.cInvName as �������,b.cInvStd as ������
    ,sum(������������) as ������������,sum(����) as ����
	 ,SUM(���) AS ���,SUM(��������) AS ��������
	 ,ISNULL(sum(������������),0) - ISNULL(sum(����),0) AS �������ϲ�
	 ,ISNULL(sum(����),0) - ISNULL(SUM(���),0) AS ��������
	 ,sum(�����̵�) as �����̵�
	 ,sum(�����̵�) as �����̵�
	 ,sum(isnull(����,0)) + sum(isnull(�����̵�,0)) - SUM(isnull(���,0)) as ���۽��
	 ,cast(null as decimal(16,6)) as �������ϳɱ�
	 ,cast(null as decimal(16,2)) as ���ϳɱ�
into #b
from #a
	LEFT JOIN ufdata_002_2015..inventory b ON #a.������� = b.cInvCode
group by �������,b.cInvAddCode,b.cInvName,b.cInvStd
order by ������� ,b.cInvAddCode


declare @rowNo int   
set @rowNo=1 

declare @max int
select @max = max(rowNumber) from #b

while @rowNo < @max
begin

	declare @autoid uniqueidentifier

	declare @InvCode varchar(50)
	select @InvCode = ������� from #b where rowNumber = @rowNo
	
	select @InvCode = cInvDefine6 from Inventory where cInvCode = @InvCode

	select @autoid = iAutoId from ProductStructure where cPSPCode=@InvCode and isnull(bMRCBBOM,0) = 1
	
	exec PP_Struct_end @autoid,0,2

	declare @iPrice decimal(16,6) 
	select @iPrice = sum(cast (iQInvNCost as decimal(16,6)))
	from (SELECT * FROM tempdb..PP_WLQDCBtemp) PP_WLQDfinZX 

	update #b set �������ϳɱ� = @iPrice,���ϳɱ� = @iPrice * ��� where rowNumber = @rowNo
	
	set @rowNo = @rowNo + 1
end

select #b.*,inv.cInvDefine6 ,inv2.cInvName
into #c
from #b left join Inventory inv on #b.������� = inv.cInvCode
	left join Inventory inv2 on inv.cInvDefine6 = inv2.cInvCode
where inv2.cInvCCode = '040202'


select cInvDefine6 as �������,cInvName as �������
	,sum(������������) as ������������,sum(����) as ����,sum(���) as ���
	,sum(�����̵�) as �����̵�,sum(�����̵�) as �����̵�
	,sum(���۽��) as ���۽��,sum(isnull(���۽��,0)) - sum(isnull(�����̵�,0)) as �̵����
	,�������ϳɱ�,sum(���ϳɱ�) as ���ϳɱ�
from #c
group by cInvDefine6,cInvName,�������ϳɱ�
order by cInvDefine6

--select * from Inventory where cInvCode = 'R-X62-D1'