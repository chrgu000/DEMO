using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction.Query
{
    class ClsUserInfoQuery
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond;

        public ClsUserInfoQuery()
        {
            clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
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
