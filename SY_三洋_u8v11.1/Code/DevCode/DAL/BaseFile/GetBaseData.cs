using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameBaseFunction;
using System.Data.SqlClient;
using System.Data;

namespace TH.DAL
{
    public partial class GetBaseData
    {

        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDatetimeSer()
        {
            string sSQL = @"select getdate()";

            return Convert.ToDateTime(DbHelperSQL.Query(sSQL).Rows[0][0]);
        }
        /// <summary>
        /// 获得系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDatetimeSer(string sType)
        {
            string sSQL = @"select getdate()";
            DateTime d = Convert.ToDateTime(DbHelperSQL.Query(sSQL).Rows[0][0]);

            return BaseFunction.BaseFunction.ReturnDate(d.ToString(sType));
        }

        /// <summary>
        /// 获得评审单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetPSCode(string strWhere)
        {
            string sSQL = @"
select distinct 评审单据号 
from dbo.订单评审 
where 1=1
order by 评审单据号
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (strWhere.Trim() == "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DBNull.Value;
                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }

        /// <summary>
        /// 获得销售订单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetSoCode(string strWhere)
        {
            string sSQL = @"
select a.cSoCode
from @u8.so_somain a 
where isnull(a.cVerifier,'') <> '' and isnull(a.cCloser ,'') = '' and 1=1
order by a.cSoCode
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }

            DataTable dt = DbHelperSQL.Query(sSQL);

            if (strWhere.Trim() == "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DBNull.Value;
                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }

        /// <summary>
        /// 获得存货档案
        /// </summary>
        /// <returns></returns>
        public DataTable GetInventory(string strWhere)
        {
            string sSQL = @"
select cInvCode,cInvName,cInvAddCode,cInvStd,cInvDepCode,cDefWareHouse ,cInvCCode ,cVenCode ,cPosition 
from @u8.Inventory 
where  1=1
order by cInvCode
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }

            DataTable dt = DbHelperSQL.Query(sSQL);

            if (strWhere.Trim() == "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DBNull.Value;
                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }

        /// <summary>
        /// 获得存货档案扩展自定义项
        /// </summary>
        /// <returns></returns>
        public DataTable GetInventory_extradefine(string strWhere)
        {
            string sSQL = @"
select *
from @u8.Inventory_extradefine 
where  1=1
order by cInvCode
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (strWhere.Trim() == "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DBNull.Value;
                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }

        /// <summary>
        /// 获得产线档案
        /// </summary>
        /// <returns></returns>
        public DataTable  GetProductionLine(string strWhere)
        {
            string sSQL = @"
select [LineNo],LineName,cDepCode,PeopleNO,Remark
from ProductionLine
where  1=1
order by [LineNo]
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (strWhere.Trim() == "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DBNull.Value;
                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }

        /// <summary>
        /// 获得部门档案
        /// </summary>
        /// <returns></returns>
        public DataTable  GetDepartment(string strWhere)
        {
            string sSQL = @"
select cDepCode,cDepName
from @u8.Department  
where  1=1
order by cDepCode 
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (strWhere.Trim() == "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DBNull.Value;
                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }

        /// <summary>
        /// 部门订单号对照
        /// </summary>
        /// <returns></returns>
        public DataTable  Get部门订单号对照(string strWhere)
        {
            string sSQL = @"
select *
from _LookUpDate
where  iType = '13' and  1=1
order by iID 
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (strWhere.Trim() == "")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DBNull.Value;
                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }
    }
}
