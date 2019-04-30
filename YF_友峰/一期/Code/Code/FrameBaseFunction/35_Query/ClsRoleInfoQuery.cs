using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction.Query
{
    class ClsRoleInfoQuery
    {

        FrameBaseFunction.ClsDataBase clsSQLCommond;

        public ClsRoleInfoQuery()
        {
            clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        }

        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "SELECT vchrRoleID, vchrRoleText, vchrRemark, bClosed, dtmCreate " +
                                "FROM _RoleInfo " +
                                "ORDER BY vchrRoleID ";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得用户信息失败！");
            }
            return dt;
        }

        /// <summary>
        /// 判断角色是否关闭
        /// </summary>
        /// <param name="sRoleID"></param>
        /// <returns>True 关闭</returns>
        public bool ChkClosed(string sRoleID)
        {
            bool b=false;
            try
            {
                string sSQL = "SELECT bClosed " +
                                "FROM _RoleInfo " +
                                "WHERE vchrRoleID='" + sRoleID + "' " +
                                "ORDER BY vchrRoleID ";
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
