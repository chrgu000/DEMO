using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
     

    /// <summary>
    /// 数据访问类:生产排产发料计划
    /// </summary>
    public partial class 生产排产发料计划
    {
        public DataSet GetPCList(DateTime dDate, int iDaysCount, int iDayTime, out string sReturn)
        {
            string sDate = dDate.ToString("yyyy-MM-dd");
            sReturn = "";
            string sCols2 = "";
            string sCols3 = "";
            for (int i = 1; i <= iDaysCount; i++)
            {
                sCols2 = sCols2 + ",(case when 计划生产日期 = '" + dDate.AddDays(i).ToString("yyyy-MM-dd") + "' then cast( d.数量 * f.BaseQtyN / f.BaseQtyD /(1- f.ParentScrap/100 ) * (1+f.CompScrap/100 ) as decimal(16,2)) end) as  数量" + dDate.AddDays(i).ToString("yyMMdd");
                sCols3 = sCols3 + ",cast(sum(数量" + dDate.AddDays(i).ToString("yyMMdd") + ") as decimal(16,2)) as 数量" + dDate.AddDays(i).ToString("yyMMdd");
            }


            string sSQL = @"
select a.MoCode as 生产订单号,c.SortSeq as 行号
	,c.InvCode as 物料编码,e.cInvName as 物料名称,e.cInvStd as 物料规格
    ,c.Qty as 生产订单数量,c.QualifiedInQty as 入库数量,c.Qty - isnull(c.QualifiedInQty,0) as 未生产数量
	,b.StartDate as 订单开工日期,b.DueDate as 订单完工日期
	,d.数量,d.计划生产日期 
	,f.BaseQtyN / f.BaseQtyD /(1- f.ParentScrap/100 ) * (1+f.CompScrap/100 ) as 使用数量
	,f.InvCode as 子件编码,g.cInvName as 子件名称,g.cInvStd as 子件规格
	,d.数量 * f.BaseQtyN / f.BaseQtyD /(1- f.ParentScrap/100 ) * (1+f.CompScrap/100 ) as 应发料数量
	,f.IssQty  as 已发料数量
    333333
into #a
from @u8.mom_order a 
	inner join @u8.mom_morder b on a.moid = b.moid
	inner join @u8.mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
	inner join dbo.生产日计划 d on d.生产订单明细iID = c.modid
	left join @u8.Inventory e on e.cInvCode = c.InvCode
	left join @u8.mom_moallocate f on f.MoDId = c.modid
	left join @u8.Inventory g on g.cInvCode = f.InvCode
where c.Qty > isnull(c.QualifiedInQty,0) and isnull(d.数量,0) > 0
	and 1=1
order by a.Moid,c.modid,f.InvCode

select 生产订单号,行号,物料编码,物料名称,物料规格,生产订单数量,入库数量,未生产数量,未生产数量,订单开工日期,订单完工日期,sum(数量) as 数量,使用数量
	,子件编码,子件名称,子件规格,应发料数量,已发料数量
	444444
from #a
group by 生产订单号,行号,物料编码,物料名称,物料规格,生产订单数量,入库数量,未生产数量,未生产数量,订单开工日期,订单完工日期,使用数量
	,子件编码,子件名称,子件规格,应发料数量,已发料数量



select 子件编码,子件名称,子件规格
	444444
from #a
group by 子件编码,子件名称,子件规格
order by 子件编码,子件名称,子件规格

";

            sSQL = sSQL.Replace("1=1", "1=1 and d.计划生产日期 <= '" + dDate.AddDays(iDaysCount).ToString("yyyy-MM-dd") + "'");
            sSQL = sSQL.Replace("333333", sCols2);
            sSQL = sSQL.Replace("444444", sCols3);
            DataSet ds = DbHelperSQL.QueryDataSet(sSQL);

            return ds;
        }


        /// <summary>
        /// 获得生产排产发料默认天数
        /// </summary>
        public int GetPCDays()
        {
            int i = 0;
            string sSQL = "select * from dbo._Code where sType = '生产排产发料默认天数'";
            DataTable dt = DbHelperSQL.Query(sSQL);
            i = BaseFunction.BaseFunction.ReturnInt(dt.Rows[0]["cCode"]);

            return i;
        }


     
        private DateTime? GetMaxDate()
        {
            string sSQL = "select max(排产日期) from 生产日计划 where 1=-1";
            DateTime? d = BaseFunction.BaseFunction.ReturnDate(DbHelperSQL.Query(sSQL).Rows[0][0]);
            return d;
        }


        public DataTable GetLine()
        {
            string sSQL = "select [LineNo],LineName from dbo.ProductionLine order by [LineNo]";
            return DbHelperSQL.Query(sSQL);
        }
    }
}

