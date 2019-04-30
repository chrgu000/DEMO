


-- 北京
select  d.cInvCName as cInvName
	,cast(sum(b.iQuantity) as decimal(16,2)) as iQtyBJ 
	,cast(sum(b.iNatSum) as decimal(16,2))  as iMomeyBJ 
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPriceBJ 
	,cast(null as decimal(16,2)) as iQtyKS
	,cast(null as decimal(16,2)) as iMomeyKS
	,cast(null as decimal(16,2)) as iPriceKS

	,cast(null as decimal(16,2)) as iQtySD
	,cast(null as decimal(16,2)) as iMomeySD
	,cast(null as decimal(16,2)) as iPriceSD

	,cast(null as decimal(16,2)) as iQtySC
	,cast(null as decimal(16,2)) as iMomeySC
	,cast(null as decimal(16,2)) as iPriceSC

	,cast(null as decimal(16,2)) as iQtyHW
	,cast(null as decimal(16,2)) as iMomeyHW
	,cast(null as decimal(16,2)) as iPriceHW

	,cast(null as decimal(16,2)) as iQtySZ
	,cast(null as decimal(16,2)) as iMomeySZ
	,cast(null as decimal(16,2)) as iPriceSZ

	,cast(null as decimal(16,2)) as iQtyCZ
	,cast(null as decimal(16,2)) as iMomeyCZ
	,cast(null as decimal(16,2)) as iPriceCZ

	,cast(null as decimal(16,2)) as iQtyXM
	,cast(null as decimal(16,2)) as iMomeyXM
	,cast(null as decimal(16,2)) as iPriceXM

	,cast(null as decimal(16,2)) as iQtyDL
	,cast(null as decimal(16,2)) as iMomeyDL
	,cast(null as decimal(16,2)) as iPriceDL

into #_TH_REP_SUM
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '北京'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo





-- 昆山销售部
INSERT INTO #_TH_REP_SUM(cInvName,iQtyKS,iMomeyKS,iPriceKS)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '昆山销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo


-- 山东
INSERT INTO #_TH_REP_SUM(cInvName,iQtySD,iMomeySD,iPriceSD)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '山东'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo


-- 四川
INSERT INTO #_TH_REP_SUM(cInvName,iQtySC,iMomeySC,iPriceSC)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '四川'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo


-- 海外
INSERT INTO #_TH_REP_SUM(cInvName,iQtyHW,iMomeyHW,iPriceHW)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '海外'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo


-- 深圳销售部
INSERT INTO #_TH_REP_SUM(cInvName,iQtySZ,iMomeySZ,iPriceSZ)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_201_2014..DispatchList a inner join ufdata_201_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_201_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_201_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_201_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_201_2014..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '深圳销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo




-- 潮州
INSERT INTO #_TH_REP_SUM(cInvName,iQtyCZ,iMomeyCZ,iPriceCZ)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_104_2014..DispatchList a inner join ufdata_104_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_104_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_104_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_104_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_104_2014..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '潮州销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo



-- 厦门销售部
INSERT INTO #_TH_REP_SUM(cInvName,iQtyXM,iMomeyXM,iPriceXM)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_102_2014..DispatchList a inner join ufdata_102_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_102_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_102_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_102_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_102_2014..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '厦门销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo


-- 大连销售部
INSERT INTO #_TH_REP_SUM(cInvName,iQtyDL,iMomeyDL,iPriceDL)
select  d.cInvCName as cinv
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_103_2014..DispatchList a inner join ufdata_103_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_103_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_103_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_103_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_103_2014..Department  f on a.cDepCode = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '大连销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo


SELECT  cInvCName 

	,sum(iQtyBJ) as iQtyBJ			--	数量
	,sum(iMomeyBJ) as iMomeyBJ 		--	金额
	,avg(iPriceBJ) as iPriceBJ 		--	单价

	,sum(iQtyKS) as iQtyKS
	,sum(iMomeyKS) as iMomeyKS
	,avg(iPriceKS) as iPriceKS

	,sum(iQtySD) as iQtySD
	,sum(iMomeySD) as iMomeySD
	,avg(iPriceSD) as iPriceSD

	,sum(iQtySC) as iQtySC
	,sum(iMomeySC) as iMomeySC
	,avg(iPriceSC) as iPriceSC

	,sum(iQtyHW) as iQtyHW
	,sum(iMomeyHW) as iMomeyHW
	,avg(iPriceHW) as iPriceHW

	,sum(iQtySZ) as iQtySZ
	,sum(iMomeySZ) as iMomeySZ
	,avg(iPriceSZ) as iPriceSZ

	,sum(iQtyCZ) as iQtyCZ
	,sum(iMomeyCZ) as iMomeyCZ
	,avg(iPriceCZ) as iPriceCZ

	,sum(iQtyXM) as iQtyXM
	,sum(iMomeyXM) as iMomeyXM
	,avg(iPriceXM) as iPriceXM

	,sum(iQtyDL) as iQtyDL
	,sum(iMomeyDL) as iMomeyDL
	,avg(iPriceDL) as iPriceDL

	,sum(iQtyBJ) + sum(iQtyKS) + sum(iQtySD) + sum(iQtySC) + sum(iQtyHW) + sum(iQtySZ) + sum(iQtyCZ) + sum(iQtyXM) + sum(iQtyDL) as iQtySum
	,sum(iMomeyBJ)+sum(iMomeyKS)+sum(iMomeySD)+sum(iMomeySC)+sum(iMomeyHW)+sum(iMomeySZ)+sum(iMomeyCZ)+sum(iMomeyXM)+sum(iMomeyDL) as iMoneySum
	,case when isnull(sum(iQtyBJ) + sum(iQtyKS) + sum(iQtySD) + sum(iQtySC) + sum(iQtyHW) + sum(iQtySZ) + sum(iQtyCZ) + sum(iQtyXM) + sum(iQtyDL) , 0) <> 0 
		then cast((sum(iMomeyBJ)+sum(iMomeyKS)+sum(iMomeySD)+sum(iMomeySC)+sum(iMomeyHW)+sum(iMomeySZ)+sum(iMomeyCZ)+sum(iMomeyXM)+sum(iMomeyDL)/(isnull(sum(iQtyBJ) + sum(iQtyKS) + sum(iQtySD) + sum(iQtySC) + sum(iQtyHW) + sum(iQtySZ) + sum(iQtyCZ) + sum(iQtyXM) + sum(iQtyDL))) as decimal(16,2))
	else null end as iPriceSum
FROM #_TH_REP_SUM
group by cInvCName 
order by cInvCName 
