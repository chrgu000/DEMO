using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务.Query
{
    class ClsUserInfoQuery
    {
        系统服务.ClsDataBase clsSQLCommond;

        public ClsUserInfoQuery()
        {
            clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        }


        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "SELECT vchrUid, vchrPwd,vchrName, vchrRemark, tstamp, dtmCreate, dtmClose " +
                              "  FROM _UserInfo " +
                              " order by vchrUid ";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            { 
                throw new Exception ("获得用户信息失败！");
            }
            return dt;
        }

    
    }
}
