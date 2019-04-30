

--select * from PP_POMain

--,c.cInvAddCode as �ͺ�

DROP TABLE #a

DECLARE @dDate1 DATE
DECLARE @dDate2 DATE

SET @dDate1 = '2014-11-1'
SET @dDate2 = '2014-12-31'


select a.cinvcode as �������,sum(a.fQuantity) as ������������
	,null as ����,null as ���,null as δ�깤,null as ��������
INTO #a
from PP_POMain a INNER JOIN PP_ProductPO b ON a.ID = b.ID
	inner join Inventory c on a.cInvCode = c.cInvCode
where b.dDate >= @dDate1 and b.dDate <= @dDate2
group by a.cinvcode

insert into #a
select s1,null,sum(isnull(d14,0) ) as iQty,null,null,null
from SystemDB_TTJM.dbo.���򱨱� 
where CreateDate >= @dDate1 and  CreateDate <= @dDate2
	and sType = '����'
group by s1

INSERT INTO #a(�������,���)
select b.cInvCode,SUM(b.iQuantity) AS iQty
from rdrecord a inner join RdRecords b on a.ID = b.ID
where a.dDate  >= @dDate1 and a.dDate <= @dDate2 AND cVouchType = '10'
GROUP BY b.cInvCode	


INSERT INTO #a(�������,��������)
SELECT D.cInvCode,SUM(B.iQuantity) AS iQty
FROM dbo.RdRecord A INNER JOIN dbo.RdRecords B ON A.ID = B.ID
	LEFT JOIN PP_PODetails C ON C.SubID = B.iMPoIds
	LEFT JOIN PP_POMain d ON c.MainID = d.ID
	LEFT JOIN dbo.Inventory E ON E.cinvcode = B.cInvCode
WHERE A.dDate  >= @dDate1 and a.dDate <= @dDate2
	AND cVouchType = '11'
	AND E.cInvCCode LIKE '01010%'
	AND ISNULL(d.cInvCode,'') <> ''
GROUP BY D.cInvCode 





select �������,b.cInvAddCode AS �ͺ�,sum(������������) as ������������,sum(����) as ����
	 ,SUM(���) AS ���,SUM(��������) AS ��������
	 ,ISNULL(sum(������������),0) - ISNULL(sum(����),0) AS �������ϲ�
	 ,ISNULL(sum(����),0) - ISNULL(SUM(���),0) AS ��������
from #a
	LEFT JOIN inventory b ON #a.������� = b.cInvCode
group by �������,b.cInvAddCode
HAVING ISNULL(sum(����),0) > ISNULL(SUM(���),0)
order by ������� ,b.cInvAddCode