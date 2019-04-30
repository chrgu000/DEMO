using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;
namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:ProductionLinePeopleNO
    /// </summary>
    public partial class ReportTH
    {
        public ReportTH()
        { }

        public DataTable Get销售订单状态查看(string sWhere)
        {

            string sSQL = @"
select a.cSOCode as 销售订单号, CONVERT(varchar(100), a.dDate,111) AS 日期,a.cCusCode as 客户编码,a.cCusName as 客户,a.cDepCode as 部门编码,c.cDepName as 部门
	,a.cMaker as 制单人,a.cCloser as 关闭人,a.cBusType as 业务类型 ,a.cexch_name as 币种
	,b.iRowNo as 行,b.cInvCode as 存货编码,d.cInvName as 存货名称,d.cInvStd as 存货规格,b.iQuantity as 数量,b.iUnitPrice as 原币无税单价,b.iTaxUnitPrice as 原币含税单价
	,b.iMoney as 原币无税金额,b.iTax as 原币税额 ,b.iSum as 原币价税合计 ,b.iNatUnitPrice as 本币无税单价 ,b.iNatMoney as 本币无税金额 ,b.iTaxRate as 税率
	,b.cSCloser as 行关闭
	,e.*
from @u8.so_somain a inner join @u8.SO_SODetails b on a.id = b.id
	inner join @u8.Department c on c.cDepCode = a.cDepCode
	inner join @u8.Inventory d on d.cInvCode = b.cInvCode
	left join 订单评审 e on e.销售订单子表ID = b.AutoID
where 1=1
order by a.cSOCode ,b.iRowNo
";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }


        public DataTable Get生产达成日期范围(string sWhere, DateTime d1, DateTime d2)
        {
            string s = "";
            string s2 = "";
            DateTime dDate = d1;
            while (dDate <= d2)
            {
                s = s + ",case when 计划生产日期 = '" + dDate + "' then cast(c.数量 as decimal(16,2)) end as 计划数量" + dDate.ToString("yyMMdd");
                s = s + ",case when 计划生产日期 = '" + dDate + "' then cast(d.iQuantity as decimal(16,2)) end as 入库数量" + dDate.ToString("yyMMdd");

                s2 = s2 + ",sum( 计划数量" + dDate.ToString("yyMMdd") + ") as 计划数量" + dDate.ToString("yyMMdd");
                s2 = s2 + ",sum( 入库数量" + dDate.ToString("yyMMdd") + ") as 入库数量" + dDate.ToString("yyMMdd");

                dDate = dDate.AddDays(1);
            }

            string sSQL = @"

select a.MOCode as 生产订单号,b.SortSeq  as 行号,b.InvCode as 存货编码,e.cInvName as 存货名称,e.cInvStd as 存货规格, cast (b.Qty as decimal(16,2)) as 订单数量
    ,c.生产订单明细iID,c.最新排产日期,c.计划生产日期,c.数量
    ,cast(d.iQuantity as decimal(16,2)) as 入库数量
    111111
into #a
from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid
	inner join 
	(
	select 生产订单明细iID,max(排产日期) as 最新排产日期,计划生产日期,数量
	from dbo.生产日计划
	where isnull(审核人,'') <> ''
	group by 生产订单明细iID,计划生产日期,数量
	) c on b.modid = c.生产订单明细iID
	left join
	(
	select b.iMPoIds,a.dDate,sum(b.iQuantity) as iQuantity
	from @u8.rdrecord10 a inner join @u8.rdrecords10 b on a.id = b.id
	group by b.iMPoIds,a.dDate
	) d on d.iMPoIds = b.modid and d.dDate = c.计划生产日期
    inner join @u8.Inventory e on e.cInvCode = b.InvCode
where 1=1
order by  生产订单明细iID

select min(计划生产日期) as minDate,max(计划生产日期) as maxDate from #a
";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            if (d1 != null)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 计划生产日期 >= '" + d1 + "' ");
            }
            if (d2 != null)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 计划生产日期 <= '" + d2 + "' ");
            }
            sSQL = sSQL.Replace("111111", s);
            sSQL = sSQL.Replace("222222", s2);
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable Get生产达成(string sWhere, DateTime d1, DateTime d2)
        {
            DateTime dDate1 = d1;
            DateTime dDate2 = d2;


            string s = "";
            string s2 = "";
            while (dDate1 <= dDate2)
            {
                s = s + ",case when 计划生产日期 = '" + dDate1 + "' then cast(c.数量 as decimal(16,2)) end as 计划数量" + dDate1.ToString("yyMMdd");
                s = s + ",case when 计划生产日期 = '" + dDate1 + "' then cast(d.iQuantity as decimal(16,2)) end as 入库数量" + dDate1.ToString("yyMMdd");

                s2 = s2 + ",sum( 计划数量" + dDate1.ToString("yyMMdd") + ") as 计划数量" + dDate1.ToString("yyMMdd");
                s2 = s2 + ",sum( 入库数量" + dDate1.ToString("yyMMdd") + ") as 入库数量" + dDate1.ToString("yyMMdd");

                dDate1 = dDate1.AddDays(1);
            }

           string sSQL = @"

select a.MOCode as 生产订单号,b.SortSeq  as 行号,b.InvCode as 存货编码,e.cInvName as 存货名称,e.cInvStd as 存货规格, cast (b.Qty as decimal(16,2)) as 订单数量
    ,c.生产订单明细iID,c.最新排产日期,c.计划生产日期,c.数量
    ,cast(d.iQuantity as decimal(16,2)) as 入库数量
    111111
into #a
from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid
	inner join 
	(
	select 生产订单明细iID,max(排产日期) as 最新排产日期,计划生产日期,数量
	from dbo.生产日计划
	where isnull(审核人,'') <> ''
	group by 生产订单明细iID,计划生产日期,数量
	) c on b.modid = c.生产订单明细iID
	left join
	(
	select b.iMPoIds,a.dDate,sum(b.iQuantity) as iQuantity
	from @u8.rdrecord10 a inner join @u8.rdrecords10 b on a.id = b.id
	group by b.iMPoIds,a.dDate
	) d on d.iMPoIds = b.modid and d.dDate = c.计划生产日期
    inner join @u8.Inventory e on e.cInvCode = b.InvCode
where 1=1
order by  生产订单明细iID



select 生产订单号,行号,存货编码,存货名称,存货规格,订单数量,生产订单明细iID
	222222
from #a
group by 生产订单号,行号,存货编码,存货名称,存货规格,订单数量,生产订单明细iID
order by  生产订单号,行号
";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            if (d1 != null)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 计划生产日期 >= '" + d1 + "' ");
            }
            if (d2 != null)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 计划生产日期 <= '" + d2 + "' ");
            }
            sSQL = sSQL.Replace("111111", s);
            sSQL = sSQL.Replace("222222", s2);
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 自制件未设置生产工时
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable Get自制件未设生产工时(string sWhere)
        {

            string sSQL = @"

";

            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }
    }
}

