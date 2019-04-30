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

            return Convert.ToDateTime(DbHelperSQL.Query(sSQL).Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 获得销售订单号
        /// </summary>
        /// <returns></returns>
        public DataSet GetSoCode(string strWhere)
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
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得存货档案
        /// </summary>
        /// <returns></returns>
        public DataSet GetInventory(string strWhere)
        {
            string sSQL = @"
select *
from @u8.Inventory 
where  1=1
order by cInvCode
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得存货档案扩展自定义项
        /// </summary>
        /// <returns></returns>
        public DataSet GetInventory_extradefine(string strWhere)
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
            return DbHelperSQL.Query(sSQL);
        }



        /// <summary>
        /// 获得生产订单号
        /// </summary>
        /// <returns></returns>
        public DataSet GetWorkOrderNO(string strWhere)
        {
            string sSQL = @"
select distinct MoCode
from @u8.mom_order 
order by MoCode
";

            if (strWhere.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 " + strWhere);
            }
            return DbHelperSQL.Query(sSQL);
        }
    }
}
