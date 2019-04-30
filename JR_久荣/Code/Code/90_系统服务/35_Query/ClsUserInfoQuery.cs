using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ϵͳ����.Query
{
    class ClsUserInfoQuery
    {
        ϵͳ����.ClsDataBase clsSQLCommond;

        public ClsUserInfoQuery()
        {
            clsSQLCommond = ϵͳ����.ClsDataBaseFactory.Instance();
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
                throw new Exception ("����û���Ϣʧ�ܣ�");
            }
            return dt;
        }

    
    }
}
