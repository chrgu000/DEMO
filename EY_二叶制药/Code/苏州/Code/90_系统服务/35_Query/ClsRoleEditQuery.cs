using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ϵͳ����.Query
{
    class ClsRoleEditQuery
    {
        ϵͳ����.ClsDataBase clsSQLCommond;

        public ClsRoleEditQuery()
        {
            clsSQLCommond = ϵͳ����.ClsDataBaseFactory.Instance();
        }

        public DataTable GetAllDt()
        {
            DataTable dt = null;
            try
            {
                string sSQL = "SELECT vchrUid, vchrRemark, dtmCreate, dtmClose, ' ' AS bChoosed " +
                                "FROM _UserInfo " +
                                "where dtmCreate <= getdate() and dtmClose >= getdate() " +
                                "order by vchrUid";
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("��ý�ɫ��Ϣʧ�ܣ�");
            }
            return dt;
        }


        public DataTable GetUserRole(string sRoleID)
        {
            DataTable dt = null;
            try
            {
                string sSQL = "select _UserInfo.vchrUid,vchrRemark,dtmCreate,dtmClose, " +
	                        "bChoosed = case isnull(_UserRoleInfo.vchrUserID,'') when '' then '' else '��' end " +
                        "from dbo._UserInfo left join dbo._UserRoleInfo  " +
                            "on _UserRoleInfo.vchrUserid = _UserInfo.vchrUid and vchrRoleID ='" + sRoleID + "' " +
                            "where dtmCreate<=getdate() and dtmClose >= getdate() " +
                        "order by _UserInfo.vchrUid"; 
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("��ý�ɫ��Ϣʧ�ܣ�");
            }
            return dt;
        }

        /// <summary>
        /// �жϽ�ɫ�Ƿ񲻴���
        /// </summary>
        /// <param name="sUid"></param>
        /// <returns>������True</returns>
        public bool ChkRoleID(string sRoleID)
        {
            bool b = false;
            try
            {
                string sSQL = "SELECT COUNT(vchrRoleID) AS iCount " +
                                "FROM _RoleInfo " +
                                "WHERE (vchrRoleID = '" + sRoleID + "')";
                int iCount = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCount < 1)
                    b = true;
                else
                    b = false;
            }
            catch
            {
                throw new Exception("�жϽ�ɫ�Ƿ����ʧ�ܣ�");
            }

            return b;
        }
    }
}
