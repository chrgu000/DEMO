using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ϵͳ����.Query
{
    class ClsRoleInfoQuery
    {

        ϵͳ����.ClsDataBase clsSQLCommond;

        public ClsRoleInfoQuery()
        {
            clsSQLCommond = ϵͳ����.ClsDataBaseFactory.Instance();
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
                throw new Exception("����û���Ϣʧ�ܣ�");
            }
            return dt;
        }

        /// <summary>
        /// �жϽ�ɫ�Ƿ�ر�
        /// </summary>
        /// <param name="sRoleID"></param>
        /// <returns>True �ر�</returns>
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
                throw new Exception("����û���Ϣʧ�ܣ�");
            }
            return b;
        }

    }
}
