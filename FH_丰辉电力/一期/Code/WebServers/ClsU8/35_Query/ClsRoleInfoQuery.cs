using ClsBaseClass;
using System;
using System.Data;
namespace ClsU8.Query
{
    public class ClsRoleInfoQuery
    {
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "SELECT vchrRoleID, vchrRoleText, vchrRemark, bClosed, dtmCreate FROM _RoleInfo ORDER BY vchrRoleID ";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得用户信息失败！");
            }
            return dt;
        }
        public bool ChkClosed(string sRoleID)
        {
            bool b = false;
            try
            {
                string sSQL = "SELECT bClosed FROM _RoleInfo WHERE vchrRoleID='" + sRoleID + "' ORDER BY vchrRoleID ";
                b = Convert.ToBoolean(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch
            {
                throw new Exception("获得用户信息失败！");
            }
            return b;
        }
    }
}
