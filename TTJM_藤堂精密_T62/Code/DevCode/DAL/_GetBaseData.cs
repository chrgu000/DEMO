using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameBaseFunction;
using System.Data.SqlClient;
using System.Data;

namespace TH.DAL
{
    public partial class _GetBaseData
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
select cInvCode,cInvName,cInvAddCode,cInvStd
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
        /// 获得工序档案
        /// </summary>
        /// <returns></returns>
        public DataTable GetWorkProcess(string strWhere)
        {
            string sSQL = @"
select WorkProcessNo,WorkProcessName
from WorkProcess  
where  1=1
order by WorkProcessNo 
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
        /// 获得生产订单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetProductPO(string strWhere)
        {
            string sSQL = @"
select cCode 
from @u8.PP_ProductPO 
where 1=1
order by ID
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
        /// 获得班组信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetWorkGroupPeople(string strWhere)
        {
            string sSQL = @"
select WorkGroupPeopleNo, WorkGroupPeopleName
from dbo.WorkGroupPeople
where 1=1
order by WorkGroupPeopleNo
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
        /// 获得设备信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetEquipment(string strWhere)
        {
            string sSQL = @"
select EquipmentNo,EquipmentName
from dbo.Equipment
where 1=1
order by EquipmentNo
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
