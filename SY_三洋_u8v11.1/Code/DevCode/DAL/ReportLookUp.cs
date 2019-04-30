using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;
namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:ReportLookUp
    /// </summary>
    public partial class ReportLookUp
    {
        public ReportLookUp()
        { }

        public DataTable Get评审单号(string sWhere)
        {

            string sSQL = @"
select distinct a.评审单据号 as 评审单号
from 订单评审 a 
where 1=1
order by a.评审单据号
";
            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }


        public DataTable Get销售订单号(string sWhere)
        {

            string sSQL = @"
select distinct a.cSOCode as 销售订单号
from @u8.so_somain a 
where 1=1
order by a.cSOCode
";
            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }

        public DataTable Get生产订单号(string sWhere)
        {

            string sSQL = @"
select distinct a.MoCode as 生产订单号
from @u8.mom_order a 
where 1=1
order by a.MoCode
";
            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }


        public DataTable Get班次设定(string sWhere)
        {

            string sSQL = @"
select iText as 小时数,Remark as 班次  ,iID
from dbo._LookUpDate 
where iType = 12 and 1=1
order by iID
";
            if (sWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and " + sWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }
    }
}

