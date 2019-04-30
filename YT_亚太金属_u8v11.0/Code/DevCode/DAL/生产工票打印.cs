using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{

    /// <summary>
    /// 数据访问类:生产工票打印
    /// </summary>
    public partial class 生产工票打印
    {
        DateTime d生产计划考虑起始日期 = Convert.ToDateTime("2014-6-10");

        public DataSet GetPCList(DateTime dPlanWork, DateTime dPlanWork2, DateTime dPlanWork3, DateTime dPlanWork4, int iDaysCount, out string sReturn)
        {

            return GetList(dPlanWork, dPlanWork2, dPlanWork3, dPlanWork4, iDaysCount, out sReturn);

        }

        public DateTime Get最新审核生产计划日期()
        {
            DateTime dDate;
            string sSQL = "select max(排产日期) as 排产日期 from 生产工序日计划 where isnull(审核人,'') <> '' ";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                dDate = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);
            }
            else
            {
                throw new Exception("获得最新生产工序排产日期失败");
            }

            return dDate;
        }

        public DateTime Get最近一天生产计划(DateTime dDate)
        {
            DateTime dDatePlan;
            string sSQL = "select min(计划生产开工日期) as 排产日期 from 生产工序日计划 where 排产日期 = '" + dDate + "' ";
            DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                dDatePlan = BaseFunction.BaseFunction.ReturnDate(dt.Rows[0][0]);
            }
            else
            {
                throw new Exception("获得最新生产工序排产日期失败");
            }

            return dDatePlan;
        }

        /// <summary>
        /// 查看历史计划
        /// </summary>
        /// <param name="dDate"></param>
        /// <param name="iDaysCount"></param>
        /// <param name="iDayTime"></param>
        /// <param name="sReturn"></param>
        /// <returns></returns>
        public DataSet GetList(DateTime dPlanWork, DateTime dPlanWork2, DateTime dPlanWork3, DateTime dPlanWork4, int iDaysCount, out string sReturn)
        {
            //string sCols1 = "";
            string sCols2 = "";
            string sCols3 = "";
            string sCols4 = "";
            //for (int i = 0; i <= iDaysCount; i++)
            //{
            //    if (i > 0)
            //    {
            //        sCols2 = sCols2 + ",sum(数量" + dDate.AddDays(i).ToString("yyMMdd") + ") as  数量" + dDate.AddDays(i).ToString("yyMMdd");
            //        sCols3 = sCols3 + ",case when isnull(数量" + dDate.AddDays(i).ToString("yyMMdd") + ",0) = 0 then null else cast(数量" + dDate.AddDays(i).ToString("yyMMdd") + " as decimal(16,2)) end as 数量" + dDate.AddDays(i).ToString("yyMMdd") + "";

            //        sCols4 = sCols4 + ", b.数量 as  数量" + dDate.AddDays(i).ToString("yyMMdd");
            //    }
            //}

            sReturn = "";

            //string sSQL = "select * from 生产工序日计划 where 排产日期 = '" + sDate + "'";
            //DataTable dt = DbHelperSQL.Query(sSQL).Tables[0];
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    sReturn = "已保存(历史)";

            //    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
            //    {
            //        sReturn = "已审核(历史)";
            //    }
            //}

            string sSQL = @"
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
    ,d.CompleteQty  as 工序完成数量,c.MoLotCode  as 零件号  ,isnull(工票打印次数,0) as 工票打印次数,null as 定额工时,机床,人员 ,调度安排时间 ,计划生产开工日期 ,实际完工日期
, 生产工票打印.审核人 as 工票审核人  ,'edit' as iSave  
from @u8.mom_order a 
    inner join @u8.mom_morder b on a.moid = b.moid
    inner join @u8.mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
    inner join @u8.sfc_moroutingdetail d on d.modid = c.modid
    inner join @u8.sfc_operation e on e.OperationId = d.OperationId 
    inner join @u8.sfc_workcenter f on f.WcId = d.WcID
    left join dbo.生产工序日计划 g on g.生产订单工艺路线明细ID = d.MoRoutingDId
    inner join @u8.Inventory h on h.cInvCode = c.InvCode
left join 生产工票打印 on d.MoRoutingDId=生产工票打印.MoRoutingDId 
left join (select MoRoutingDId,MIN(DueTime) as 实际完工日期 from @u8.sfc_moroutingdetail group by MoRoutingDId) sfc on d.MoRoutingDId=sfc.MoRoutingDId
where c.Status = 3 and c.MoLotCode is not null and g.审核人 is not null and 1=1 
    and a.moid > 1000002741  and  d.CompleteQty=0
order by a.moid,c.modid,d.OpSeq


/*
select  a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序排产数量,a.工序完成数量 
    ,cast(null as datetime) as 排产最大日期,cast(null as datetime) as 排产最小日期,计划生产开工日期
    ,cast(null as varchar(50)) as 排产说明,零件号,机床,人员 ,调度安排时间 ,工票打印次数 ,定额工时,'edit' as iSave  
from
(
select distinct a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序排产数量,a.工序完成数量,cast (null as decimal(16,6)) as 日期已过
    ,零件号,机床,人员 ,调度安排时间,工票打印次数,定额工时,计划生产开工日期 
from #a a 
)a 
group by   a.moid,a.modid,a.MoRoutingId,a.MoRoutingDid,a.生产订单号,a.生产订单行号,a.物料编码,a.物料名称,a.物料规格,a.生产订单数量,a.入库数量
	,a.销售订单号,a.销售订单行号,a.单重,a.工序行号,a.标准工序ID,a.工序说明,a.可用合格数量,a.末道工序,a.首道工序,a.工作中心ID,a.工作中心代号
	,a.工作中心名称,a.委外工序,a.单件加工工时,a.工序分类,a.是否瓶颈工序,a.工序开工日期,a.工序完成日期
	,a.工序排产数量,a.工序完成数量,a.零件号,机床,人员,调度安排时间,工票打印次数,定额工时,计划生产开工日期
order by a.生产订单号,a.生产订单行号,a.工序行号*/
";

            if (dPlanWork != DateTime.MinValue)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and d.StartDate>='" + dPlanWork.ToString("yyyy-MM-dd") + "'");
            }
            if (dPlanWork2 != DateTime.MinValue)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and d.StartDate<='" + dPlanWork2.ToString("yyyy-MM-dd") + "'");
            }
            if (dPlanWork3 != DateTime.MinValue)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and g.计划生产开工日期>='" + dPlanWork3.ToString("yyyy-MM-dd") + "'");
            }
            if (dPlanWork4 != DateTime.MinValue)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and g.计划生产开工日期<='" + dPlanWork4.ToString("yyyy-MM-dd") + "'");
            }
            //sSQL = sSQL.Replace("666666", sCols4);
            //sSQL = sSQL.Replace("333333", sCols3);
            //sSQL = sSQL.Replace("444444", dPlanWork.ToString("yyyy-MM-dd"));
            //sSQL = sSQL.Replace("999999", dPlanWork2.ToString("yyyy-MM-dd"));
            //sSQL = sSQL.Replace("555555", d生产计划考虑起始日期.ToString("yyyy-MM-dd"));
            //sSQL = sSQL.Replace("222222", sCols2);
            //sSQL = sSQL.Replace("777777", dPlanWork.ToString("yyyy-MM-dd"));
            //sSQL = sSQL.Replace("888888", dPlanWork.AddDays(iDaysCount).ToString("yyyy-MM-dd"));

            DataSet ds = DbHelperSQL.Query(sSQL);

            return ds;
        }

      

        /// <summary>
        /// 获得工票打印天数
        /// </summary>
        public int Get工票打印天数()
        {
            int i = 0;
            string sSQL = "select * from dbo._Code where sType = '工票打印天数'";
            DataSet ds = DbHelperSQL.Query(sSQL);
            i = BaseFunction.BaseFunction.ReturnInt(ds.Tables[0].Rows[0]["cCode"]);

            return i;
        }

        public DataTable GetLine()
        {
            string sSQL = "select WcCode as [LineNo],[Description] as LineName from @u8.sfc_workcenter order by [WcCode]";
            return DbHelperSQL.Query(sSQL).Tables[0];
        }
    }
}

