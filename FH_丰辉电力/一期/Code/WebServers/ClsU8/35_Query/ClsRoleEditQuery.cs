using ClsBaseClass;
using System;
using System.Data;
namespace ClsU8.Query
{
    public class ClsRoleEditQuery
    {
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "SELECT vchrUid, vchrRemark, dtmCreate, dtmClose, ' ' AS bChoosed FROM _UserInfo where dtmCreate <= getdate() and dtmClose >= getdate() order by vchrUid";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得角色信息失败！");
            }
            return dt;
        }
        public DataTable GetUserRole(string sRoleID)
        {
            DataTable dt = null;
            try
            {
                string sSQL = "select _UserInfo.vchrUid,vchrRemark,dtmCreate,dtmClose, bChoosed = case isnull(_UserRoleInfo.vchrUserID,'') when '' then '' else '√' end from dbo._UserInfo left join dbo._UserRoleInfo  on _UserRoleInfo.vchrUserid = _UserInfo.vchrUid and vchrRoleID ='" + sRoleID + "' where dtmCreate<=getdate() and dtmClose >= getdate() order by _UserInfo.vchrUid";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得角色信息失败！");
            }
            return dt;
        }
        public bool ChkRoleID(string sRoleID)
        {
            bool b = false;
            try
            {
                string sSQL = "SELECT COUNT(vchrRoleID) AS iCount FROM _RoleInfo WHERE (vchrRoleID = '" + sRoleID + "')";
                int iCount = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                b = (iCount < 1);
            }
            catch
            {
                throw new Exception("判断角色是否存在失败！");
            }
            return b;
        }
    }
}
