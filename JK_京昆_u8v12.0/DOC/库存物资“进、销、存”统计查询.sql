
--create table #a(序号,分类,二级,三级,存货编码,存货名称,规格型号,包装,期末库存数量,合格,不合格,待检,仓库编码,仓库名称,货位编码,货位名称,数量,件数
--	,生产累计入库,生产累计领料,生产累计退库,采购入库,采购退货,累计销售,累计销售退货)
	
	
--select SUBSTRING(cInvCCode,0,3), SUBSTRING(cInvCCode,0,5),* from InventoryClass order by cInvCCode


declare @dDate1 datetime
declare @dDate2 datetime

set @dDate1 = '2015-4-1'
set @dDate2 = '2015-4-30'


if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a
	

--	采购入库
select distinct invPos.AutoID,rds.cInvCode as 存货编码,inv.cInvName as 存货名称,inv.cInvStd as 存货规格
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as 一级分类编码,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as 一级分类名称
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as 二级分类编码,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as 二级分类名称
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as 三级分类编码,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as 三级分类名称
	,inv.cInvDefine4 as 包装,null as 期末库存数量,null as 合格,null as 不合格,null as 待检
	,wh.cWhCode as 仓库编码,wh.cWhName as 仓库名称,Pos.cPosCode as 货位编码,Pos.cPosName as 货位名称
	,curr.iQuantity as 仓库现存量,curr.iNum as 仓库现存件数
	,InvPosSum.iQuantity as 货位现存量,invpossum.inum as 货位显存件数
	,rds.iQuantity as 采购入库数量,rds.iNum as 采购入库件数
	,cast(null as decimal(16,6)) as 采购退货数量,cast(null as decimal(16,6)) as 采购退货件数
	,cast(null as decimal(16,6)) as 生产累计入库数量,cast(null as decimal(16,6)) as 生产累计入库件数
	,cast(null as decimal(16,6)) as 生产累计领料数量,cast(null as decimal(16,6)) as 生产累计领料件数
	,cast(null as decimal(16,6)) as 生产累计退库数量,cast(null as decimal(16,6)) as 生产累计退库件数
	,cast(null as decimal(16,6)) as 累计销售数量,cast(null as decimal(16,6)) as 累计销售件数
	,cast(null as decimal(16,6)) as 累计销售退货数量,cast(null as decimal(16,6)) as 累计销售退货件数
into #a
from RdRecord01 rd inner join RdRecords01 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where isnull(rds.iQuantity,0) > 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2

--采购退货
insert into #a
select distinct invPos.AutoID,rds.cInvCode as 存货编码,inv.cInvName as 存货名称,inv.cInvStd as 存货规格
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as 一级分类编码,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as 一级分类名称
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as 二级分类编码,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as 二级分类名称
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as 三级分类编码,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as 三级分类名称
	,inv.cInvDefine4 as 包装,null as 期末库存数量,null as 合格,null as 不合格,null as 待检
	,wh.cWhCode as 仓库编码,wh.cWhName as 仓库名称,Pos.cPosCode as 货位编码,Pos.cPosName as 货位名称
	,curr.iQuantity as 仓库现存量,curr.iNum as 仓库现存件数
	,InvPosSum.iQuantity as 货位现存量,invpossum.inum as 货位显存件数
	,cast(null as decimal(16,6)) as 采购入库数量,cast(null as decimal(16,6)) as 采购入库件数
	,rds.iQuantity as 采购退货数量,rds.iNum as 采购退货件数
	,cast(null as decimal(16,6)) as 生产累计入库数量,cast(null as decimal(16,6)) as 生产累计入库件数
	,cast(null as decimal(16,6)) as 生产累计领料数量,cast(null as decimal(16,6)) as 生产累计领料件数
	,cast(null as decimal(16,6)) as 生产累计退库数量,cast(null as decimal(16,6)) as 生产累计退库件数
	,cast(null as decimal(16,6)) as 累计销售数量,cast(null as decimal(16,6)) as 累计销售件数
	,cast(null as decimal(16,6)) as 累计销售退货数量,cast(null as decimal(16,6)) as 累计销售退货件数
from RdRecord01 rd inner join RdRecords01 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where isnull(rds.iQuantity,0) < 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2

-- 产品入库
insert into #a
select distinct invPos.AutoID,rds.cInvCode as 存货编码,inv.cInvName as 存货名称,inv.cInvStd as 存货规格
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as 一级分类编码,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as 一级分类名称
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as 二级分类编码,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as 二级分类名称
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as 三级分类编码,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as 三级分类名称
	,inv.cInvDefine4 as 包装,null as 期末库存数量,null as 合格,null as 不合格,null as 待检
	,wh.cWhCode as 仓库编码,wh.cWhName as 仓库名称,Pos.cPosCode as 货位编码,Pos.cPosName as 货位名称
	,curr.iQuantity as 仓库现存量,curr.iNum as 仓库现存件数
	,InvPosSum.iQuantity as 货位现存量,invpossum.inum as 货位显存件数
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as 采购入库件数
	,cast(null as decimal(16,6)) as 采购退货数量,cast(null as decimal(16,6)) as 采购退货件数
	,rds.iQuantity as 生产累计入库数量,rds.iNum as 生产累计入库件数
	,cast(null as decimal(16,6)) as 生产累计领料数量,cast(null as decimal(16,6)) as 生产累计领料件数
	,cast(null as decimal(16,6)) as 生产累计退库数量,cast(null as decimal(16,6)) as 生产累计退库件数
	,cast(null as decimal(16,6)) as 累计销售数量,cast(null as decimal(16,6)) as 累计销售件数
	,cast(null as decimal(16,6)) as 累计销售退货数量,cast(null as decimal(16,6)) as 累计销售退货件数
from rdrecord10 rd inner join rdrecords10 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) > 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2

-- 产品退货
insert into #a
select distinct invPos.AutoID,rds.cInvCode as 存货编码,inv.cInvName as 存货名称,inv.cInvStd as 存货规格
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as 一级分类编码,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as 一级分类名称
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as 二级分类编码,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as 二级分类名称
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as 三级分类编码,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as 三级分类名称
	,inv.cInvDefine4 as 包装,null as 期末库存数量,null as 合格,null as 不合格,null as 待检
	,wh.cWhCode as 仓库编码,wh.cWhName as 仓库名称,Pos.cPosCode as 货位编码,Pos.cPosName as 货位名称
	,curr.iQuantity as 仓库现存量,curr.iNum as 仓库现存件数
	,InvPosSum.iQuantity as 货位现存量,invpossum.inum as 货位显存件数
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as 采购入库件数
	,cast(null as decimal(16,6)) as 采购退货数量,cast(null as decimal(16,6)) as 采购退货件数
	,cast(null as decimal(16,6)) as 生产累计入库数量,cast(null as decimal(16,6)) as 生产累计入库件数
	,rds.iQuantity  as 生产累计领料数量,rds.iNum as 生产累计领料件数
	,cast(null as decimal(16,6)) as 生产累计退库数量,cast(null as decimal(16,6)) as 生产累计退库件数
	,cast(null as decimal(16,6)) as 累计销售数量,cast(null as decimal(16,6)) as 累计销售件数
	,cast(null as decimal(16,6)) as 累计销售退货数量,cast(null as decimal(16,6)) as 累计销售退货件数
from rdrecord10 rd inner join rdrecords10 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) < 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
	
-- 产品领料
insert into #a
select distinct invPos.AutoID,rds.cInvCode as 存货编码,inv.cInvName as 存货名称,inv.cInvStd as 存货规格
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as 一级分类编码,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as 一级分类名称
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as 二级分类编码,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as 二级分类名称
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as 三级分类编码,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as 三级分类名称
	,inv.cInvDefine4 as 包装,null as 期末库存数量,null as 合格,null as 不合格,null as 待检
	,wh.cWhCode as 仓库编码,wh.cWhName as 仓库名称,Pos.cPosCode as 货位编码,Pos.cPosName as 货位名称
	,curr.iQuantity as 仓库现存量,curr.iNum as 仓库现存件数
	,InvPosSum.iQuantity as 货位现存量,invpossum.inum as 货位显存件数
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as 采购入库件数
	,cast(null as decimal(16,6)) as 采购退货数量,cast(null as decimal(16,6)) as 采购退货件数
	,cast(null as decimal(16,6)) as 生产累计入库数量,cast(null as decimal(16,6)) as 生产累计入库件数
	,cast(null as decimal(16,6)) as 生产累计领料数量,cast(null as decimal(16,6)) as 生产累计领料件数
	,rds.iQuantity as 生产累计退库数量,rds.iNum as 生产累计退库件数
	,cast(null as decimal(16,6)) as 累计销售数量,cast(null as decimal(16,6)) as 累计销售件数
	,cast(null as decimal(16,6)) as 累计销售退货数量,cast(null as decimal(16,6)) as 累计销售退货件数
from rdrecord11 rd inner join rdrecords11 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where 1=1 
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
		
-- 销售
insert into #a
select distinct invPos.AutoID,rds.cInvCode as 存货编码,inv.cInvName as 存货名称,inv.cInvStd as 存货规格
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as 一级分类编码,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as 一级分类名称
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as 二级分类编码,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as 二级分类名称
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as 三级分类编码,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as 三级分类名称
	,inv.cInvDefine4 as 包装,null as 期末库存数量,null as 合格,null as 不合格,null as 待检
	,wh.cWhCode as 仓库编码,wh.cWhName as 仓库名称,Pos.cPosCode as 货位编码,Pos.cPosName as 货位名称
	,curr.iQuantity as 仓库现存量,curr.iNum as 仓库现存件数
	,InvPosSum.iQuantity as 货位现存量,invpossum.inum as 货位显存件数
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as 采购入库件数
	,cast(null as decimal(16,6)) as 采购退货数量,cast(null as decimal(16,6)) as 采购退货件数
	,cast(null as decimal(16,6)) as 生产累计入库数量,cast(null as decimal(16,6)) as 生产累计入库件数
	,cast(null as decimal(16,6)) as 生产累计领料数量,cast(null as decimal(16,6)) as 生产累计领料件数
	,cast(null as decimal(16,6)) as 生产累计退库数量,cast(null as decimal(16,6)) as 生产累计退库件数
	,rds.iQuantity as 累计销售数量,rds.iNum as 累计销售件数
	,cast(null as decimal(16,6)) as 累计销售退货数量,cast(null as decimal(16,6)) as 累计销售退货件数
from rdrecord32 rd inner join rdrecords32 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) > 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
	
	--case when len(cinvccode) = 2
		
-- 销售退回
insert into #a
select distinct invPos.AutoID,rds.cInvCode as 存货编码,inv.cInvName as 存货名称,inv.cInvStd as 存货规格
	,case when len(inv.cInvCCode) = 2 then SUBSTRING(inv.cInvCCode,0,3) else null end as 一级分类编码,case when len(inv.cInvCCode) = 2 then InvC1.cInvCName else null end as 一级分类名称
	,case when len(inv.cInvCCode) = 4 then SUBSTRING(inv.cInvCCode,0,5) else null end as 二级分类编码,case when len(inv.cInvCCode) = 4 then InvC1.cInvCName else null end as 二级分类名称
	,case when len(inv.cInvCCode) >= 6 then inv.cInvCCode else null end as 三级分类编码,case when len(inv.cInvCCode) >= 6 then InvC1.cInvCName else null end as 三级分类名称
	,inv.cInvDefine4 as 包装,null as 期末库存数量,null as 合格,null as 不合格,null as 待检
	,wh.cWhCode as 仓库编码,wh.cWhName as 仓库名称,Pos.cPosCode as 货位编码,Pos.cPosName as 货位名称
	,curr.iQuantity as 仓库现存量,curr.iNum as 仓库现存件数
	,InvPosSum.iQuantity as 货位现存量,invpossum.inum as 货位显存件数
	,cast(null as decimal(16,6)),cast(null as decimal(16,6)) as 采购入库件数
	,cast(null as decimal(16,6)) as 采购退货数量,cast(null as decimal(16,6)) as 采购退货件数
	,cast(null as decimal(16,6)) as 生产累计入库数量,cast(null as decimal(16,6)) as 生产累计入库件数
	,cast(null as decimal(16,6)) as 生产累计领料数量,cast(null as decimal(16,6)) as 生产累计领料件数
	,cast(null as decimal(16,6)) as 生产累计退库数量,cast(null as decimal(16,6)) as 生产累计退库件数
	,cast(null as decimal(16,6)) as 累计销售数量, cast(null as decimal(16,6)) as 累计销售件数
	,cast(null as decimal(16,6)) as 累计销售退货数量,cast(null as decimal(16,6)) as 累计销售退货件数
from rdrecord32 rd inner join rdrecords32 rds on rd.ID = rds.ID 
	left join InvPosition invPos on invPos.RdsID = rds.AutoID
	inner join inventory inv on rds.cInvCode = inv.cInvCode
	left join Warehouse wh on rd.cWhCode = wh.cWhCode
	left join Position Pos on invPos.cPosCode = Pos.cPosCode
	left join InventoryClass InvC1 on InvC1.cInvCCode = SUBSTRING(inv.cInvCCode,0,3)
	left join InventoryClass InvC2 on InvC2.cInvCCode = SUBSTRING(inv.cInvCCode,0,5)
	left join InventoryClass InvC3 on InvC3.cInvCCode = inv.cInvCCode
	left join currentstock Curr on Curr.cInvCode = rds.cInvCode and Curr.cWhCode = rd.cWhCode 
		and Curr.cFree1 = rds.cFree1	and Curr.cFree2 = rds.cFree2	and Curr.cFree3 = rds.cFree3	and Curr.cFree4 = rds.cFree4	and Curr.cFree5 = rds.cFree5
		and Curr.cFree6 = rds.cFree6	and Curr.cFree7 = rds.cFree7	and Curr.cFree8 = rds.cFree8	and Curr.cFree9 = rds.cFree9	and Curr.cFree10 = rds.cFree10
	left join InvPositionSum InvPosSum on InvPosSum.cInvCode = rds.cInvCode and InvPosSum.cWhCode = rd.cWhCode and InvPosSum.cPosCode = invpos.cPosCode
		and InvPosSum.cFree1 = rds.cFree1	and InvPosSum.cFree2 = rds.cFree2	and InvPosSum.cFree3 = rds.cFree3	and InvPosSum.cFree4 = rds.cFree4	and InvPosSum.cFree5 = rds.cFree5
		and InvPosSum.cFree6 = rds.cFree6	and InvPosSum.cFree7 = rds.cFree7	and InvPosSum.cFree8 = rds.cFree8	and InvPosSum.cFree9 = rds.cFree9	and InvPosSum.cFree10 = rds.cFree10
where  isnull(rds.iQuantity,0) < 0
	and rd.dDate >= @dDate1 and rd.dDate <= @dDate2
	
	
select * from #a

--select case when len(cinvccode) = 2 then cinvccode else null end
--	, *
--from InventoryClass

	

	
