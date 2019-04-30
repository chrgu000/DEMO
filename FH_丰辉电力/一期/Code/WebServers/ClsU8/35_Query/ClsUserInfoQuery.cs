using ClsBaseClass;
using System;
using System.Data;
namespace ClsU8.Query
{
    public class ClsUserInfoQuery
    {
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "SELECT vchrUid, vchrPwd,vchrName, vchrRemark, tstamp, dtmCreate, dtmClose   FROM _UserInfo  order by vchrUid ";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得用户信息失败！");
            }
            return dt;
        }
    }
}
