using ClsBaseClass;
using System;
using System.Data;
namespace ClsU8.Query
{
    public class ClsUserEditQuery
    {
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "select vchrRoleID,vchrRoleText,vchrRemark,' ' as bChoosed from dbo._RoleInfo where isnull(bClosed,0) <>1   order by vchrRoleID";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得角色信息失败！");
            }
            return dt;
        }
        public DataTable GetUserRole(string sUid)
        {
            DataTable dt = null;
            try
            {
                string sSQL = "select dbo._RoleInfo.vchrRoleID,vchrRoleText,vchrRemark, bChoosed = case isnull(dbo._UserRoleInfo.vchrRoleID,'') \twhen '' then '' \t\telse '√' \tend from dbo._RoleInfo left join dbo._UserRoleInfo on dbo._UserRoleInfo.vchrRoleID = dbo._RoleInfo.vchrRoleID  \tand vchrUserID = '" + sUid + "' where isnull(bClosed,0) <>1   order by dbo._RoleInfo.vchrRoleID";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得角色信息失败！");
            }
            return dt;
        }
        public bool ChkUID(string sUid)
        {
            bool b = false;
            try
            {
                string sSQL = "SELECT COUNT(vchrUid) AS iCount FROM _UserInfo WHERE (vchrUid = '" + sUid + "') ";
                int iCount = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                b = (iCount < 1);
            }
            catch
            {
                throw new Exception("判断用户是否存在失败！");
            }
            return b;
        }
    }
}
