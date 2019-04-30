using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{

    /// <summary>
    /// 数据访问类:生产工序排产
    /// </summary>
    public partial class 生产工序排产
    {
        DateTime d生产计划考虑起始日期 = Convert.ToDateTime("2014-6-10");

        long l起始订单ID = 0;
        string s测试用生产订单号 = "SCDD14080013";

        public DataSet GetPCList(DateTime dDate, int iDaysCount, int iDayTime, out string sReturn)
        {
            bool b历史计划 = false;
            string sSQL = "select max(排产日期) as 排产日期 from 生产工序日计划";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime d = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);

                if (d > dDate)
                    b历史计划 = true;
            }

         
            if (b历史计划)
            {
                return GetList(dDate, iDaysCount, iDayTime, out sReturn);
            }
            else
            {
                return GetPC(dDate, iDaysCount, iDayTime, out sReturn);
            }
        }

        /// <summary>
        /// 查看历史计划
        /// </summary>
        /// <param name="dDate"></param>
        /// <param name="iDaysCount"></param>
        /// <param name="iDayTime"></param>
        /// <param name="sReturn"></param>
        /// <returns></returns>
        public DataSet GetList(DateTime dDate, int iDaysCount, int iDayTime, out string sReturn)
        {
            //string sCols1 = "";
            string sDate = dDate.ToString("yyyy-MM-dd");

            string sCols2 = "";
            string sCols3 = "";
            string sCols4 = "";
            for (int i = 0; i <= iDaysCount; i++)
            {
                    sCols2 = sCols2 + ",sum(数量" + dDate.AddDays(i).ToString("yyMMdd") + ") as  数量" + dDate.AddDays(i).ToString("yyMMdd");
                    sCols3 = sCols3 + ",case when isnull(数量" + dDate.AddDays(i).ToString("yyMMdd") + ",0) = 0 then null else cast(数量" + dDate.AddDays(i).ToString("yyMMdd") + " as decimal(16,2)) end as 数量" + dDate.AddDays(i).ToString("yyMMdd") + "";

                    sCols4 = sCols4 + ",(case when b.计划生产开工日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.数量 end) as  数量" + dDate.AddDays(i).ToString("yyMMdd");
            }

            sReturn = "";

            string sSQL = "select * from 生产工序日计划 where 排产日期 = '" + sDate + "'";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                sReturn = "已保存(历史)";

                if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    sReturn = "已审核(历史)";
                }
            }

            sSQL = @"
select a.moid,c.modid,d.MoRoutingId,d.MoRoutingDId
    ,a.MoCode as 生产订单号,c.SortSeq as 生产订单行号,c.InvCode as 物料编码,h.cInvName as 物料名称,h.cInvStd as 物料规格
    ,c.Qty as 生产订单数量,c.QualifiedInQty  as 入库数量,c.SoCode as 销售订单号,c.SoSeq as 销售订单行号,c.Define26 as 单重
    ,d.OpSeq as 工序行号,d.Operationid as 标准工序ID,d.Description as 工序说明
    ,d.BalQualifiedQty as 可用合格数量,d.LastFlag as 末道工序,d.FirstFlag as 首道工序
    ,d.WcID as 工作中心ID,f.WcCode  as 工作中心代号,f.Description as 工作中心名称
    ,case when d.SubFlag  = 1 then '是' else '否' end as 委外工序
    ,isnull(d.Define27,0) as 单件加工工时,isnull(d.Define34,0) as 工序分类,isnull(d.Define35,0) as 是否瓶颈工序
    ,d.StartDate as 工序开工日期,d.DueDate as 工序完成日期 ,isnull(d.Define14,0) as 检验员 
    ,case when isnull(g.iID,0) = 0 then d.StartDate else g.计划生产开工日期 end as 计划生产开工日期
    ,case when isnull(g.iID,0) = 0 then c.Qty - isnull(c.QualifiedInQty,0) else g.数量 end as 工序排产数量
    ,d.CompleteQty  as 工序完成数量,c.MoLotCode  as 零件号
into #a
from @u8.mom_order a 
    
    inner join @u8.mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
inner join @u8.mom_morder b on c.modid = b.modid
    inner join @u8.sfc_moroutingdetail d on d.modid = c.modid
    inner join @u8.sfc_operation e on e.OperationId = d.OperationId 
    inner join @u8.sfc_workcenter f on f.WcId = d.WcID
    inner join dbo.生产工序日计划 g on g.生产订单工艺路线明细ID = d.MoRoutingDId
    inner join @u8.Inventory h on h.cInvCode = c.InvCode
where c.Status = 3 and g.排产日期 = '444444'
    and a.moid > 777777
    888888
order by a.moid,c.modid,d.OpSeq



select  a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序排产数量,a.工序完成数量
    222222
    ,cast (null as decimal(16,6)) as 日期未到
    ,0 as 首次排产
    ,cast(null as datetime) as 排产最大日期,cast(null as datetime) as 排产最小日期
    ,cast(null as varchar(50)) as 排产说明,零件号,到货单日期,到货单供应商,到货单号,'edit' as iSave
from
(
select distinct a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序排产数量,a.工序完成数量,cast (null as decimal(16,6)) as 日期已过
    666666
    ,零件号,c.dDate as 到货单日期,c.cVenName as 到货单供应商,c.cCode as 到货单号
from #a a inner join 生产工序日计划 b on a.MoRoutingDId = b.生产订单工艺路线明细ID
left join (select a.dDate,c.cVenName,a.cCode,b.cBatch from PU_ArrivalVouch a 
left join PU_ArrivalVouchs b on a.ID =b.ID 
left join Vendor c on a.cVenCode=c.cVenCode) c on b.零件号=c.cBatch
where b.排产日期 = '444444'
)a 
group by   a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序排产数量,a.工序完成数量,零件号
order by a.生产订单号,a.生产订单行号,a.工序行号
";

            sSQL = sSQL.Replace("111111", dDate.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("666666", sCols4);
            sSQL = sSQL.Replace("333333", sCols3);
            sSQL = sSQL.Replace("444444", sDate);
            sSQL = sSQL.Replace("555555", d生产计划考虑起始日期.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", sCols2);
            sSQL = sSQL.Replace("777777", l起始订单ID.ToString().Trim());
            if (s测试用生产订单号.Trim() != "")
            {
                sSQL = sSQL.Replace("888888", " and a.MoCode = '" + s测试用生产订单号.Trim() + "'");
            }
            else
            {
                sSQL = sSQL.Replace("888888", "");
            }
            
            DataSet ds = DbHelperSQL.Query(sSQL);           

            return ds;
        }

        /// <summary>
        /// 生产工序排产
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetPC(DateTime dDate, int iDaysCount,int iDayTime,out string sReturn)
        {
            string sCols1 = "";
            string sDate = dDate.ToString("yyyy-MM-dd");

            string sCols2 = "";
            string sCols3 = "";
            string sCols4 = "";
            string sCols6 = "";
            sCols1 = sCols1 + ",case when datediff(d,'" + sDate + "',a.工序开工日期) < 0 then 工序排产数量 end as 日期已过";
            for (int i = 0; i <= iDaysCount; i++)
            {
                if (i == 0)
                {
                    sCols1 = sCols1 + ",case when datediff(d,'" + sDate + "',a.工序开工日期) <= " + i.ToString() + " then 工序排产数量 end as 数量" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",case when datediff(d,'" + sDate + "',a.工序开工日期) <= " + i.ToString() + " then 工时比例 end as 工时比例" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",case when datediff(d,'" + sDate + "',a.工序开工日期) <= " + i.ToString() + " then 工时 end as 工时" + dDate.AddDays(i).ToString("yyMMdd");
                    sCols2 = sCols2 + ",sum(数量" + dDate.AddDays(i).ToString("yyMMdd") + ") as 数量" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",sum(工时比例" + dDate.AddDays(i).ToString("yyMMdd") + ") as 工时比例" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",sum(工时" + dDate.AddDays(i).ToString("yyMMdd") + ") as 工时" + dDate.AddDays(i).ToString("yyMMdd");
                    sCols4 = sCols4 + ",(case when b.计划生产开工日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.数量 end) as  数量" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",(case when b.计划生产开工日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.工时比例 end) as  工时比例" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",(case when b.计划生产开工日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.工时 end) as  工时" + dDate.AddDays(i).ToString("yyMMdd");
                }
                else
                {
                    sCols1 = sCols1 + ",case when datediff(d,'" + sDate + "',a.工序开工日期) = " + i.ToString() + " then 工序排产数量 end as 数量" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",case when datediff(d,'" + sDate + "',a.工序开工日期) = " + i.ToString() + " then 工时比例 end as 工时比例" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",case when datediff(d,'" + sDate + "',a.工序开工日期) = " + i.ToString() + " then 工时 end as 工时" + dDate.AddDays(i).ToString("yyMMdd");
                    sCols2 = sCols2 + ",sum(数量" + dDate.AddDays(i).ToString("yyMMdd") + ") as 数量" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",sum(工时比例" + dDate.AddDays(i).ToString("yyMMdd") + ") as 工时比例" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",sum(工时" + dDate.AddDays(i).ToString("yyMMdd") + ") as 工时" + dDate.AddDays(i).ToString("yyMMdd");
                    sCols4 = sCols4 + ",(case when b.计划生产开工日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.数量 end) as  数量" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",(case when b.计划生产开工日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.工时比例 end) as  工时比例" + dDate.AddDays(i).ToString("yyMMdd")
                        + ",(case when b.计划生产开工日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then b.工时 end) as  工时" + dDate.AddDays(i).ToString("yyMMdd");
                }
                if (i == iDaysCount)
                {
                    sCols1 = sCols1 + ",case when datediff(d,'" + sDate + "',a.工序开工日期) > " + i.ToString() + " then 工序排产数量 end as 日期未到";
                }

                if (i >= 0)
                {
                    sCols3 = sCols3 + ",case when isnull(数量" + dDate.AddDays(i).ToString("yyMMdd") + ",0) = 0 then null else cast(数量" + dDate.AddDays(i).ToString("yyMMdd") + " as decimal(16,2)) end as 数量" + dDate.AddDays(i).ToString("yyMMdd") + ""
                        + ",case when isnull(工时比例" + dDate.AddDays(i).ToString("yyMMdd") + ",0) = 0 then null else cast(工时比例" + dDate.AddDays(i).ToString("yyMMdd") + " as decimal(16,2)) end as 工时比例" + dDate.AddDays(i).ToString("yyMMdd") + ""
                        + ",case when isnull(工时" + dDate.AddDays(i).ToString("yyMMdd") + ",0) = 0 then null else cast(工时" + dDate.AddDays(i).ToString("yyMMdd") + " as decimal(16,2)) end as 工时" + dDate.AddDays(i).ToString("yyMMdd") + "";
                }
            }

            sReturn = "";

            string sSQL = "select * from 生产工序日计划 where 排产日期 = '" + sDate + "'";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                sReturn = "已保存";

                if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    sReturn = "已审核";
                }
            }

            sSQL = @"
select a.moid,c.modid,d.MoRoutingId,d.MoRoutingDId
    ,a.MoCode as 生产订单号,c.SortSeq as 生产订单行号,c.InvCode as 物料编码,h.cInvName as 物料名称,h.cInvStd as 物料规格
    ,c.Qty as 生产订单数量,c.QualifiedInQty  as 入库数量,c.SoCode as 销售订单号,c.SoSeq as 销售订单行号,c.Define26 as 单重
    ,d.OpSeq as 工序行号,d.Operationid as 标准工序ID,d.Description as 工序说明
    ,d.BalQualifiedQty as 可用合格数量,d.LastFlag as 末道工序,d.FirstFlag as 首道工序
    ,d.WcID as 工作中心ID,f.WcCode  as 工作中心代号,f.Description as 工作中心名称
    ,case when d.SubFlag  = 1 then '是' else '否' end as 委外工序
    ,isnull(d.Define27,0) as 单件加工工时,isnull(d.Define34,0) as 工序分类,isnull(d.Define35,0) as 是否瓶颈工序
    ,d.StartDate as 工序开工日期,d.DueDate as 工序完成日期
    ,case when isnull(g.iID,0) = 0 then d.StartDate else g.计划生产开工日期 end as 计划生产开工日期
    ,case when isnull(g.iID,0) = 0 then c.Qty - isnull(c.QualifiedInQty,0) else g.数量 end as 工序排产数量
    ,case when isnull(g.iID,0) = 0 then (c.Qty - isnull(c.QualifiedInQty,0))*100/c.Qty else g.工时比例 end as 工时比例
    ,case when isnull(g.iID,0) = 0 then (c.Qty - isnull(c.QualifiedInQty,0))*isnull(d.Define27,0) else g.工时 end as 工时
    ,d.CompleteQty  as 工序完成数量,c.MoLotCode  as 零件号
into #a
from @u8.mom_order a 
    
    inner join @u8.mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
inner join @u8.mom_morder b on c.modid = b.modid
    inner join @u8.sfc_moroutingdetail d on d.modid = c.modid
    inner join @u8.sfc_operation e on e.OperationId = d.OperationId 
    inner join @u8.sfc_workcenter f on f.WcId = d.WcID
    left join dbo.生产工序日计划 g on g.生产订单工艺路线明细ID = d.MoRoutingDId and g.排产日期 = '444444'
    inner join @u8.Inventory h on h.cInvCode = c.InvCode
where c.Status = 3 
    and a.moid > 777777
	and case when isnull(g.iID,0) = 0 then c.Qty - isnull(c.QualifiedInQty,0) else g.数量 end> isnull(d.CompleteQty,0)
    888888
order by a.moid,c.modid,d.OpSeq

select *
	111111
    ,1 as 首次排产
into #b
from #a a 
where a.MoRoutingDId not in(select 生产订单工艺路线明细ID from dbo.生产工序日计划  where (isnull(审核人,'') <> ''or 排产日期 = '444444'))


declare @dMax datetime
select @dMax = max(排产日期) from 生产工序日计划 where (isnull(审核人,'') <> '' or 排产日期 = '444444')

insert into #b

select  a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期,null,null
	,a.工序完成数量,a.工时比例,a.工时,零件号,sum(a.日期已过) as 日期已过
    666666
    ,cast (null as decimal(16,6)) as 日期未到
    ,0 as 首次排产
from    
(
select distinct a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序完成数量,a.工时比例,a.工时,(case when b.计划生产开工日期 <= '444444' then b.数量 end ) as 日期已过
    222222
    ,零件号
from #a a inner join 生产工序日计划 b on a.MoRoutingDid = b.生产订单工艺路线明细ID and 排产日期 = @dMax
)a 
group by  a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序完成数量,a.工时比例,a.工时,零件号
		
select a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期,a.计划生产开工日期
	,a.工序排产数量,a.工序完成数量,a.日期已过,cast(null as decimal(16,2)) as 当前页面排产数量
    333333
    ,首次排产,cast(null as datetime) as 排产最大日期,cast(null as datetime) as 排产最小日期
    ,cast(null as varchar(50)) as 排产说明,cast(null as decimal(16,2)) as  未排产数量,cast(null as decimal(16,2)) as  已排产数量,零件号
from #b a
order by a.生产订单号,a.生产订单行号,a.工序行号
";

            sSQL = sSQL.Replace("111111", sCols1);
            sSQL = sSQL.Replace("222222", sCols4);
            sSQL = sSQL.Replace("333333", sCols3);
            sSQL = sSQL.Replace("444444", sDate);
            sSQL = sSQL.Replace("555555", d生产计划考虑起始日期.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("666666", sCols2);
            sSQL = sSQL.Replace("777777", l起始订单ID.ToString().Trim());
            if (s测试用生产订单号.Trim() != "")
            {
                sSQL = sSQL.Replace("888888", " and a.MoCode > '" + s测试用生产订单号.Trim() + "'");
            }
            else
            {
                sSQL = sSQL.Replace("888888", "");
            }
            DataSet ds = DbHelperSQL.Query(sSQL);
            DataTable dtPC = ds.Tables[0];

            for (int i = 0; i < dtPC.Rows.Count; i++)
            {

                decimal d生产订单数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["生产订单数量"], 2);
                decimal d可用合格数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["可用合格数量"], 2);
                decimal d工序排产数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["工序排产数量"], 2);
                decimal d工序完成数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["工序完成数量"], 2);
                decimal d单件加工工时 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["单件加工工时"], 10);

                decimal d总工时 = d生产订单数量 * d单件加工工时;

                decimal d日期已过数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["日期已过"], 2);

                bool b首次排产 = BaseFunction.BaseFunction.ReturnBool(dtPC.Rows[i]["首次排产"]);

                decimal d已排产数量 = 0;
                decimal d未排产数量 = 0;
                if (b首次排产)
                {
                    decimal d排产工时 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["工时"+dDate.AddDays(0).ToString("yyMMdd")], 10);
                    for (int j = 0; j <= iDaysCount; j++)
                    {
                        decimal d当前工时 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i]["工时"+dDate.AddDays(j).ToString("yyMMdd")], 10);
                        if (d排产工时 >= 8)
                        {
                            d当前工时 = 8;
                            d排产工时 = d排产工时 - 8;
                        }
                        else if (d排产工时 < 8 && d排产工时 > 0)
                        {
                            d当前工时 = d排产工时;
                            d排产工时 = 0;
                        }
                        if (d当前工时 > 0)
                        {
                            dtPC.Rows[i]["工时" + dDate.AddDays(j).ToString("yyMMdd")] = d当前工时;
                        }
                        else
                        {
                            dtPC.Rows[i]["工时" + dDate.AddDays(j).ToString("yyMMdd")] = DBNull.Value;
                        }
                        //if (d工序排产数量 <= 0)
                        //    break;

                        //string sColName = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                        //dtPC.Rows[i][sColName] = d工序排产数量;

                        //if (d工序排产数量 >= d日产量)
                        //{
                        //    dtPC.Rows[i][sColName] = d日产量;
                        //    d工序排产数量 = d工序排产数量 - d日产量;
                        //    d已排产数量 = d已排产数量 + d日产量;
                        //}
                        //else
                        //{
                        //    dtPC.Rows[i][sColName] = d工序排产数量;
                        //    d已排产数量 = d已排产数量 + d工序排产数量;
                        //    d工序排产数量 = 0;
                        //}
                    }
                    dtPC.Rows[i]["已排产数量"] = d已排产数量;
                    //d未排产数量 = d工序排产数量;
                    dtPC.Rows[i]["未排产数量"] = d未排产数量;
                }
                else
                {
                    #region 非首次排产，含未完工数量的累加至第一天
                    for (int j = 1; j <= iDaysCount; j++)
                    {
                        if (d工序排产数量 <= 0)
                            break;

                        //休息日不排产（日工时为0）
                        if (iDayTime == 0)
                        {
                            continue;
                        }

                        string sColName = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                        decimal d当日数量 = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i][sColName]);

                        if (d日期已过数量 > 0)
                        {
                            d当日数量 = d当日数量 + d日期已过数量;
                            dtPC.Rows[i][sColName] = d当日数量;
                            break;
                        }
                    }

                    #endregion

                    #region 非首次排产，含之前排产日期未到，现在到的数据，按照上次最大日期 + 1继续排产


                    DateTime d最大生产日期 = dDate;
                    for (int j = dtPC.Columns.Count - 1; j >= 0; j--)
                    {
                        string sColName = dtPC.Columns[j].ColumnName.Trim();
                        if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                        {
                            decimal d = BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i][j]);
                            if (d > 0)
                            {
                                string s = "20" + sColName.Substring(2, 2) + "-" + sColName.Substring(4, 2) + "-" + sColName.Substring(6, 2);
                                d最大生产日期 = BaseFunction.BaseFunction.ReturnDate(s);
                                break;
                            }
                        }
                    }


                    decimal d已排产 = 0;
                    for (int j = 1; j <= iDaysCount; j++)
                    {
                        string sColName = "数量" + dDate.AddDays(j).ToString("yyMMdd");

                        if (dDate.AddDays(j) <= d最大生产日期)
                        {
                            d已排产 = d已排产 + BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i][sColName]);
                            continue;
                        }

                        d工序排产数量 = d工序排产数量 - d已排产;

                        if (d工序排产数量 <= 0)
                            break;


                        //DataRow[] dr = dt日历.Select("iYear = " + dDate.AddDays(j).Year + " and iMonth = " + dDate.AddDays(j).Month + " ");
                        //iDayTime = BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dDate.AddDays(j).Day.ToString()]);

                        ////休息日不排产（日工时为0）
                        //if (iDayTime == 0)
                        //{
                        //    continue;
                        //}

                        //d日产量 = BaseFunction.BaseFunction.ReturnDecimal(d工作中心并发 * iDayTime / d单件生产工时, 2);

                        //if (d工序排产数量 >= d日产量)
                        //{
                        //    dtPC.Rows[i][sColName] = d日产量;
                        //    d工序排产数量 = d工序排产数量 - d日产量;
                        //    d已排产数量 = d已排产数量 + d日产量;
                        //}
                        //else
                        //{
                        //    dtPC.Rows[i][sColName] = d工序排产数量;
                        //    d已排产数量 = d已排产数量 + d工序排产数量;
                        //    d工序排产数量 = 0;
                        //}
                    }
                    #endregion

                }

                decimal d当前页面排产数量 = 0;
                for (int j = 1; j <= iDaysCount; j++)
                {
                    string sColName = "数量" + dDate.AddDays(j).ToString("yyMMdd");
                    d当前页面排产数量 = d当前页面排产数量 + BaseFunction.BaseFunction.ReturnDecimal(dtPC.Rows[i][sColName]);
                }
                if (d当前页面排产数量 > 0)
                {
                    dtPC.Rows[i]["当前页面排产数量"] = d当前页面排产数量;
                }
            }

            dtPC = dt规则化数据(dtPC, dDate);

            return ds;
        }

        public DataTable dt规则化数据(DataTable dt,DateTime dDate)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime d最大生产日期 = dDate;
                for (int j = dt.Columns.Count - 1; j >= 0; j--)
                {
                    string sColName = dt.Columns[j].ColumnName.Trim();
                    if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                    {
                        decimal d = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i][j]);
                        if (d > 0)
                        {
                            string s = "20" + sColName.Substring(2, 2) + "-" + sColName.Substring(4, 2) + "-" + sColName.Substring(6, 2);
                            d最大生产日期 = BaseFunction.BaseFunction.ReturnDate(s);

                            dt.Rows[i]["排产最大日期"] = d最大生产日期;
                            break;
                        }
                    }
                }

                DateTime d最小生产日期 = dDate;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string sColName = dt.Columns[j].ColumnName.Trim();
                    if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                    {
                        decimal d = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i][j]);
                        if (d > 0)
                        {
                            string s = "20" + sColName.Substring(2, 2) + "-" + sColName.Substring(4, 2) + "-" + sColName.Substring(6, 2);
                            d最小生产日期 = BaseFunction.BaseFunction.ReturnDate(s);

                            dt.Rows[i]["排产最小日期"] = d最小生产日期;
                            break;
                        }
                    }
                }

                decimal d当前页面排产数量 = 0;
                decimal d入库数量 = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["入库数量"]);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string sColName = dt.Columns[j].ColumnName.Trim();
                    if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                    {
                        decimal d = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i][j]);
                        if (d > 0)
                        {
                            d当前页面排产数量 = d当前页面排产数量 + d;
                        }
                    }
                }
                dt.Rows[i]["当前页面排产数量"] = d当前页面排产数量;
                decimal 已排产数量 = d入库数量 + d当前页面排产数量;
                dt.Rows[i]["已排产数量"] = 已排产数量;
                decimal d生产订单数量 =  BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["生产订单数量"]);
                decimal d未排产数量 = d生产订单数量 - 已排产数量;
                dt.Rows[i]["未排产数量"] = d未排产数量;

                string s排产说明 = "";
                if (d未排产数量 > 0)
                {
                    s排产说明 = "含未排产数据";
                }

                DateTime d完工日期 = BaseFunction.BaseFunction.ReturnDate(dt.Rows[i]["工序完成日期"]);
                if (d最大生产日期 > d完工日期)
                {
                    s排产说明 = "完工延迟";
                }
                dt.Rows[i]["排产说明"] = s排产说明;
            }

            return dt;
        }

        /// <summary>
        /// 获得生产工序排产默认天数
        /// </summary>
        public int GetPCDays()
        {
            int i = 0;
            string sSQL = "select * from dbo._Code where sType = '生产工序排产默认天数'";
            DataSet ds = DbHelperSQL.Query(sSQL);
            i = BaseFunction.BaseFunction.ReturnInt(ds.Tables[0].Rows[0]["cCode"]);

            return i;
        }
        

        /// <summary>
        /// 获得生产默认日工时
        /// </summary>
        public int GetDayTime()
        {
            int i = 0;
            string sSQL = "select * from dbo._Code where sType = '生产默认日工时'";
            DataSet ds = DbHelperSQL.Query(sSQL);
            i = BaseFunction.BaseFunction.ReturnInt(ds.Tables[0].Rows[0]["cCode"]);

            return i;
        }

        /// <summary>
        /// 获得工作日历
        /// </summary>
        /// <param name="iYear"></param>
        /// <returns></returns>
        public DataTable GetWorkCalendar(int iYear)
        {
            string sSQL = "select * from WorkCalendar where iYear = 111111 or iYear = 222222 order by iYear,iMonth";
            sSQL = sSQL.Replace("111111", iYear.ToString());
            sSQL = sSQL.Replace("222222", (iYear + 1).ToString());
            return DbHelperSQL.Query(sSQL).Tables[0];
        }

        public int Del(DateTime dDate)
        {
            string sSQL = "select * from 生产工序日计划 where 排产日期 = '" + dDate.ToString("yyyy-MM-dd") + "'";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    throw new Exception("当前排产已审核");
                }
            }
            else
                throw new Exception("当前没有可以删除的排产数据");

            sSQL = "select max(排产日期) as 排产日期 from 生产工序日计划 where isnull(审核人,'') <> ''";
            dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime d = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);

                if (d > dDate)
                    throw new Exception("不可以删除历史单据");
            }

            List<string> l = new List<string>();
            DateTime dNow = DbHelperSQL.ExecuteGetServerTime();
            sSQL = "delete 生产工序日计划 where 排产日期 = '" + dDate + "'";
            l.Add(sSQL);
            sSQL = "delete 生产工序日计划历史 where 排产日期 = '" + dDate + "'";
            l.Add(sSQL);

            return DbHelperSQL.ExecuteSqlTran(l);
        }

        public int Audit(DateTime dDate)
        {
            string sSQL = "select * from 生产工序日计划 where 排产日期 = '" + dDate.ToString("yyyy-MM-dd") + "'";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    throw new Exception("当前排产已审核");
                }
            }
            else
                throw new Exception("当前没有可以审核的排产数据");

            sSQL = "select max(排产日期) as 排产日期 from 生产工序日计划";
            dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime d = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);

                if (d > dDate)
                    throw new Exception("不可以审核历史单据");
            }

            List<string> l = new List<string>();
            DateTime dNow = DbHelperSQL.ExecuteGetServerTime();
            sSQL = "Update 生产工序日计划 set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',审核日期 = '" + dNow + "' where 排产日期 = '" + dDate + "'";
            l.Add(sSQL);
            sSQL = "Update 生产工序日计划历史 set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',审核日期 = '" + dNow + "' where 排产日期 = '" + dDate + "'";
            l.Add(sSQL);
            return DbHelperSQL.ExecuteSqlTran(l);
        }


        public int UnAudit(DateTime dDate)
        {
            
            string sSQL = "select * from 生产工序日计划 where 排产日期 = '" + dDate.ToString("yyyy-MM-dd") + "'";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["审核人"].ToString().Trim() == "")
                {
                    throw new Exception("当前排产未审核");
                }
            }
            else
                throw new Exception("当前没有可以弃审的排产数据");

            sSQL = "select max(排产日期) as 排产日期 from 生产工序日计划";
            dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime d = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);

                if (d > dDate)
                    throw new Exception("不可以弃审历史单据");
            }


            List<string> l = new List<string>();
            DateTime dNow = DbHelperSQL.ExecuteGetServerTime();
            sSQL = "Update 生产工序日计划 set 审核人 = null,审核日期 = null where 排产日期 = '" + dDate + "'";
            l.Add(sSQL);
            sSQL = "Update 生产工序日计划历史 set 审核人 = null,审核日期 = null where 排产日期 = '" + dDate + "'";
            l.Add(sSQL);
            return DbHelperSQL.ExecuteSqlTran(l);
        }

        public int Save(DateTime dDate, DataTable dtDetails)
        {
            string sSQL = "select max(排产日期) as 排产日期 from 生产工序日计划";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime d = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);

                if (d > dDate)
                    throw new Exception("已存在新的排产，不可保存");
            }

            DateTime dNow = DbHelperSQL.ExecuteGetServerTime();
            DateTime? dMax = GetMaxDate();
            if (dMax < BaseFunction.BaseFunction.ReturnDate("2000-1-1"))
            {

            }
            else
            {
                if (dDate < dMax)
                {
                    throw new Exception("历史单据不能修改");
                }
            }

            sSQL = "select * from 生产工序日计划 where 排产日期 = '" + dDate.ToString("yyyy-MM-dd") + "'";
            dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    throw new Exception("当前排产已审核");
                }
            }

            string sReturn = "";

            sSQL = "select * from 生产工序日计划 where 排产日期 = '" + dDate + "' and isnull(审核人,'') <> ''";
            DataSet dsTemp = DbHelperSQL.Query(sSQL);

            bool b当天已审核计划 = false;
            if (dsTemp != null && dsTemp.Tables.Count > 0 && dsTemp.Tables[0].Rows.Count > 0)
                b当天已审核计划 = true;

            if (b当天已审核计划)
            {
                throw new Exception("当天计划已经审核，不能修改");
            }
            
            List<string> l = new List<string>();

            sSQL = "delete 生产工序日计划 where 排产日期 <= '" + dDate + "'";
            l.Add(sSQL);
            sSQL = "delete 生产工序日计划历史 where 排产日期 = '" + dDate + "'";
            l.Add(sSQL);
            for (int i = 0; i < dtDetails.Rows.Count; i++)
            {
                for (int j = 0; j < dtDetails.Columns.Count; j++)
                {
                    string sColName = dtDetails.Columns[j].ColumnName.Trim();
                    if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                    {
                        string sTemp = sColName.Substring(2);
                        string sTemp2 = sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2);
                        DateTime d计划生产日期 = BaseFunction.BaseFunction.ReturnDate(sTemp2);

                        decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i][j]);
                        if (dQty <= 0)
                            continue;

                        decimal 工时比例 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i][sColName.Replace("数量","工时比例")]);
                        if (工时比例 <= 0)
                            continue;
                        decimal 工时 = BaseFunction.BaseFunction.ReturnDecimal(dtDetails.Rows[i][sColName.Replace("数量", "工时")]);
                        if (工时 <= 0)
                            continue;

                        TH.Model.生产工序日计划 model = new TH.Model.生产工序日计划();
                        model.生产订单工艺路线明细ID = BaseFunction.BaseFunction.ReturnLong(dtDetails.Rows[i]["MoRoutingDid"]);
                        model.生产订单明细iID = BaseFunction.BaseFunction.ReturnLong(dtDetails.Rows[i]["modid"]);
                        model.排产日期 = dDate;
                        model.计划生产开工日期 = d计划生产日期;
                        model.制单人 = FrameBaseFunction.ClsBaseDataInfo.sUid;
                        model.制单日期 = dNow;
                        model.CreateDate = dNow;
                        model.数量 = dQty;
                        model.工时比例 = 工时比例;
                        model.工时 = 工时;

                        sSQL = Add(model);
                        l.Add(sSQL);

                        sSQL = Add历史(model);
                        l.Add(sSQL);

                    }
                }

            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            return DbHelperSQL.ExecuteSqlTran(l);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.生产工序日计划 DataRowToModel(DataRow row)
        {
            TH.Model.生产工序日计划 model = new TH.Model.生产工序日计划();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["生产订单明细iID"] != null && row["生产订单明细iID"].ToString() != "")
                {
                    model.生产订单明细iID = int.Parse(row["生产订单明细iID"].ToString());
                }
                if (row["生产订单工艺路线明细ID"] != null && row["生产订单工艺路线明细ID"].ToString() != "")
                {
                    model.生产订单工艺路线明细ID = int.Parse(row["生产订单工艺路线明细ID"].ToString());
                }
                if (row["排产日期"] != null && row["排产日期"].ToString() != "")
                {
                    model.排产日期 = DateTime.Parse(row["排产日期"].ToString());
                }
                if (row["计划生产开工日期"] != null && row["计划生产开工日期"].ToString() != "")
                {
                    model.计划生产开工日期 = DateTime.Parse(row["计划生产开工日期"].ToString());
                }
              
                if (row["审核人"] != null)
                {
                    model.审核人 = row["审核人"].ToString();
                }
                if (row["审核日期"] != null && row["审核日期"].ToString() != "")
                {
                    model.审核日期 = DateTime.Parse(row["审核日期"].ToString());
                }
                if (row["制单人"] != null)
                {
                    model.制单人 = row["制单人"].ToString();
                }
                if (row["制单日期"] != null && row["制单日期"].ToString() != "")
                {
                    model.制单日期 = DateTime.Parse(row["制单日期"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["数量"] != null && row["数量"].ToString() != "")
                {
                    model.数量 = decimal.Parse(row["数量"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.生产工序日计划 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.生产订单明细iID != null)
            {
                strSql1.Append("生产订单明细iID,");
                strSql2.Append("" + model.生产订单明细iID + ",");
            }
            if (model.生产订单工艺路线明细ID != null)
            {
                strSql1.Append("生产订单工艺路线明细ID,");
                strSql2.Append("" + model.生产订单工艺路线明细ID + ",");
            }
            if (model.排产日期 != null)
            {
                strSql1.Append("排产日期,");
                strSql2.Append("'" + model.排产日期 + "',");
            }
            if (model.计划生产开工日期 != null)
            {
                strSql1.Append("计划生产开工日期,");
                strSql2.Append("'" + model.计划生产开工日期 + "',");
            }
          
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.工时比例 != null)
            {
                strSql1.Append("工时比例,");
                strSql2.Append("" + model.工时比例 + ",");
            }
            if (model.工时 != null)
            {
                strSql1.Append("工时,");
                strSql2.Append("" + model.工时 + ",");
            }
            strSql.Append("insert into 生产工序日计划(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add历史(TH.Model.生产工序日计划 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.生产订单明细iID != null)
            {
                strSql1.Append("生产订单明细iID,");
                strSql2.Append("" + model.生产订单明细iID + ",");
            }
            if (model.生产订单工艺路线明细ID != null)
            {
                strSql1.Append("生产订单工艺路线明细ID,");
                strSql2.Append("" + model.生产订单工艺路线明细ID + ",");
            }
            if (model.排产日期 != null)
            {
                strSql1.Append("排产日期,");
                strSql2.Append("'" + model.排产日期 + "',");
            }
            if (model.计划生产开工日期 != null)
            {
                strSql1.Append("计划生产开工日期,");
                strSql2.Append("'" + model.计划生产开工日期 + "',");
            }

            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.工时比例 != null)
            {
                strSql1.Append("工时比例,");
                strSql2.Append("" + model.工时比例 + ",");
            }
            if (model.工时 != null)
            {
                strSql1.Append("工时,");
                strSql2.Append("" + model.工时 + ",");
            }
            strSql.Append("insert into 生产工序日计划历史(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }
        private DateTime? GetMaxDate()
        {
            string sSQL = "select max(排产日期) from 生产工序日计划 where 1=-1";
            DateTime? d = BaseFunction.BaseFunction.ReturnDate(DbHelperSQL.Query(sSQL).Tables[0].Rows[0][0]);
            return d;
        }


        public DataTable GetLine()
        {
            string sSQL = "select WcCode as [LineNo],[Description] as LineName from @u8.sfc_workcenter order by [WcCode]";
            return DbHelperSQL.Query(sSQL).Tables[0];
        }
    }
}

