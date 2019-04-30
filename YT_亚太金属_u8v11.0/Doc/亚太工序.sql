select a.moid,c.modid,d.MoRoutingId,d.MoRoutingDId ,b.startDate as 开工日期,b.DueDate as 完工日期
    ,a.MoCode as 生产订单号,c.SortSeq as 生产订单行号,c.InvCode as 物料编码
    ,c.Qty as 生产订单数量,c.QualifiedInQty  as 入库数量,c.SoCode as 销售订单号,c.SoSeq as 销售订单行号,c.Define26 as 单重
    ,d.OpSeq as 工序行号,d.Operationid as 标准工序ID,d.Description as 工序说明
    ,case when isnull(g.iID,0) = 0 then d.StartDate else g.开工日期 end as 工序开工日期
    ,case when isnull(g.iID,0) = 0 then c.Qty - isnull(c.QualifiedInQty,0) else g.数量 end as 工序排产数量,d.CompleteQty  as 工序完成数量
    ,d.DueDate as 工序完工日期
    ,d.WcID as 工作中心代号,f.WcCode  as 工作中心代号,f.Description as 工作中心名称
    ,case when d.SubFlag  = 1 then '是' else '否' end as 委外工序
    ,e.OperationId  as 标准工序ID,e.OpCode as 标准工序代号,e.Description as 标准工序说明
    ,isnull(d.Define27,0) as 单件加工工时,isnull(d.Define34,0) as 工序分类,isnull(d.Define35,0) as 是否瓶颈工序
from UFDATA_100_2014..mom_order a 
    inner join UFDATA_100_2014..mom_morder b on a.moid = b.moid
    inner join UFDATA_100_2014..mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
    inner join UFDATA_100_2014..sfc_moroutingdetail d on d.modid = c.modid
    inner join UFDATA_100_2014..sfc_operation e on e.OperationId = d.OperationId 
    inner join UFDATA_100_2014..sfc_workcenter f on f.WcId = d.WcID
    left join dbo.生产工序日计划 g on g.生产工序ID = d.MoRoutingDId
where c.Status = 3 
	and a.MoCode = 'SCDD14060001' and c.SortSeq = 1
order by a.moid,c.modid,d.OpSeq


