using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{

    /// <summary>
    /// 数据访问类:工序流转卡打印
    /// </summary>
    public partial class 工序流转卡打印
    {
        DateTime d生产计划考虑起始日期 = Convert.ToDateTime("2014-6-10");

       
        /// <summary>
        /// 获得生产订单列表
        /// </summary>
        public DataTable Get生产订单列表(string sWhere)
        {
            string sSQL = @"
select cast(0 as bit) as 选择 ,a.MoCode as 生产订单号,c.SortSeq as 生产订单行号, b.startDate as 开工日期,b.DueDate as 完工日期
    ,c.InvCode as 物料编码,inv.cInvStd as 规格型号,c.Qty as 生产订单数量,c.QualifiedInQty  as 入库数量,c.SoCode as 销售订单号,c.SoSeq as 销售订单行号,c.Define26 as 单重,c.Free1 as 材质
    ,c.Free2 as 渗层mm,c.Free3 as 统一号,c.Free4 as 工艺要求,c.MoLotCode as 零件号
	,a.moid,c.modid,到货单日期,到货单供应商,到货单号,流转卡打印次数
from @u8.mom_order a 
    inner join @u8.mom_morder b on a.moid = b.moid
    inner join @u8.mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
left join (select modid,sum(Qty-isnull(IssQty,0)) as 未领数量,sum(isnull(IssQty,0)) as 已领料数量 from @u8.mom_moallocate group by modid) h on b.modid=h.modid 
left join (select cBatch,max(dDate) as 领料日期 from @u8.rdrecord11 a left join @u8.rdrecords11 b on a.id=b.id group by cBatch) r on r.cBatch=c.MoLotCode
left join (select max(a.dDate) as 到货单日期,max(c.cVenCode) as 到货单供应商,max(a.cCode) as 到货单号,b.cBatch from @u8.PU_ArrivalVouch a 
left join @u8.PU_ArrivalVouchs b on a.ID =b.ID 
left join @u8.Vendor c on a.cVenCode=c.cVenCode group by b.cBatch) e on c.MoLotCode=e.cBatch
left join  流转卡打印 i on b.modid=i.modid 
left join @u8.Inventory inv on c.InvCode=inv.cInvCode
where c.Status = 3 
	and 1=1
order by a.moid,c.modid
";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", sWhere);
            }
            DataSet ds = DbHelperSQL.Query(sSQL);

            return ds.Tables[0];
        }


        /// <summary>
        /// 获得生产订单工序列表
        /// </summary>
        public DataTable Get生产订单工序列表(string sWhere)
        {
            string sSQL = @"
select cast(0 as bit) as 选择,a.MoCode as 生产订单号,c.SortSeq as 生产订单行号, convert(varchar, b.startDate, 111) as 开工日期,b.DueDate as 完工日期, convert(varchar, getdate(), 120) as 下发日期
    ,c.InvCode as 物料编码,h.cInvName as 物料名称,c.Qty as 生产订单数量,c.QualifiedInQty  as 入库数量,c.SoCode as 销售订单号,c.SoSeq as 销售订单行号,c.Define26 as 单重,c.Free1 as 材质
    ,c.Free2 as 渗层mm,c.Free3 as 统一号,c.Free4 as 工艺要求,c.MoLotCode as 零件号
    ,d.OpSeq as 工序行号,d.Operationid as 标准工序ID,d.Description as 工序说明
    ,d.BalQualifiedQty as 可用合格数量,d.LastFlag as 末道工序,d.FirstFlag as 首道工序
    ,convert(varchar, d.DueDate, 111) as 工序完工日期
    ,d.WcID as 工作中心代号,f.WcCode  as 工作中心代号,f.Description as 工作中心名称
    ,case when d.SubFlag  = 1 then '是' else '否' end as 委外工序,d.Define26 as 计划工时
    ,d.Define27 as 单件加工工时,isnull(d.Define34,0) as 工序分类,isnull(d.Define35,0) as 是否瓶颈工序
    ,h.cInvDefine4 as 模数,h.cInvDefine5 as 齿数,h.cInvAddCode as 图号,h.cInvDefine3 as 螺旋角,h.cInvDefine6 as 齿宽
    ,a.moid,c.modid,d.MoRoutingDId ,到货单日期,到货单供应商,到货单号
from @u8.mom_order a 
    inner join @u8.mom_morder b on a.moid = b.moid
    inner join @u8.mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
    inner join @u8.sfc_moroutingdetail d on d.modid = c.modid
    inner join @u8.sfc_operation e on e.OperationId = d.OperationId 
    inner join @u8.sfc_workcenter f on f.WcId = d.WcID
    inner join @u8.Inventory h on h.cInvCode = c.InvCode

left join (select max(convert(nvarchar(10),a.dDate,120)) as 到货单日期,max(c.cVenCode) as 到货单供应商,max(a.cCode) as 到货单号,b.cBatch from @u8.PU_ArrivalVouch a 
left join @u8.PU_ArrivalVouchs b on a.ID =b.ID 
left join @u8.Vendor c on a.cVenCode=c.cVenCode group by b.cBatch) i on c.MoLotCode=i.cBatch

where c.Status = 3 
	and c.MoDid = 111111
order by a.moid,c.modid,d.OpSeq
";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("111111", sWhere);
            }
            DataSet ds = DbHelperSQL.Query(sSQL);

            return ds.Tables[0];
        }
    }
}

