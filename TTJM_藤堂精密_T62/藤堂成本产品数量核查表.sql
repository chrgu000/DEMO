

--select * from PP_POMain

--,c.cInvAddCode as 型号

DROP TABLE #a

DECLARE @dDate1 DATE
DECLARE @dDate2 DATE

SET @dDate1 = '2014-11-1'
SET @dDate2 = '2014-12-31'


select a.cinvcode as 存货编码,sum(a.fQuantity) as 生产订单数量
	,null as 落料,null as 入库,null as 未完工,null as 材料领用
INTO #a
from PP_POMain a INNER JOIN PP_ProductPO b ON a.ID = b.ID
	inner join Inventory c on a.cInvCode = c.cInvCode
where b.dDate >= @dDate1 and b.dDate <= @dDate2
group by a.cinvcode

insert into #a
select s1,null,sum(isnull(d14,0) ) as iQty,null,null,null
from SystemDB_TTJM.dbo.工序报表 
where CreateDate >= @dDate1 and  CreateDate <= @dDate2
	and sType = '落料'
group by s1

INSERT INTO #a(存货编码,入库)
select b.cInvCode,SUM(b.iQuantity) AS iQty
from rdrecord a inner join RdRecords b on a.ID = b.ID
where a.dDate  >= @dDate1 and a.dDate <= @dDate2 AND cVouchType = '10'
GROUP BY b.cInvCode	


INSERT INTO #a(存货编码,材料领用)
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





select 存货编码,b.cInvAddCode AS 型号,sum(生产订单数量) as 生产订单数量,sum(落料) as 落料
	 ,SUM(入库) AS 入库,SUM(材料领用) AS 材料领用
	 ,ISNULL(sum(生产订单数量),0) - ISNULL(sum(落料),0) AS 订单落料差
	 ,ISNULL(sum(落料),0) - ISNULL(SUM(入库),0) AS 落料入库差
from #a
	LEFT JOIN inventory b ON #a.存货编码 = b.cInvCode
group by 存货编码,b.cInvAddCode
HAVING ISNULL(sum(落料),0) > ISNULL(SUM(入库),0)
order by 存货编码 ,b.cInvAddCode