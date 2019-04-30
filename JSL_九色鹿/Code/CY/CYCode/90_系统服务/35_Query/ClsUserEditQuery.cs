using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务.Query
{
    class ClsUserEditQuery
    {
        系统服务.ClsDataBase clsSQLCommond;

        public ClsUserEditQuery()
        {
            clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        }

        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "select vchrRoleID,vchrRoleText,vchrRemark,' ' as bChoosed from dbo._RoleInfo " +
                                "where isnull(bClosed,0) <>1   " +
                                "order by vchrRoleID";
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
                string sSQL = "select dbo._RoleInfo.vchrRoleID,vchrRoleText,vchrRemark, " +
		                        "bChoosed = case isnull(dbo._UserRoleInfo.vchrRoleID,'') " +
		                        "	when '' then '' " +
		                        "		else '√' " +
		                        "	end " +
                        "from dbo._RoleInfo left join dbo._UserRoleInfo on dbo._UserRoleInfo.vchrRoleID = dbo._RoleInfo.vchrRoleID  " +
                        "	and vchrUserID = '" + sUid + "' " +
                        "where isnull(bClosed,0) <>1   " +
                        "order by dbo._RoleInfo.vchrRoleID";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得角色信息失败！");
            }
            return dt;
        }

        /// <summary>
        /// 判断用户是否不存在
        /// </summary>
        /// <param name="sUid"></param>
        /// <returns>不存在True</returns>
        public bool ChkUID(string sUid)
        {
            bool b = false;
            try
            {
                string sSQL = "SELECT COUNT(vchrUid) AS iCount FROM _UserInfo " +
                                    "WHERE (vchrUid = '" + sUid + "') ";
                int iCount = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCount < 1)
                    b = true;
                else
                    b = false;
            }
            catch
            {
                throw new Exception("判断用户是否存在失败！");
            }

            return b;
        }
    }
}
