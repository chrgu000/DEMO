using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ClsU8.Dal
{
    class ClsRoleInfoDal
    {
        ClsBaseClass.ClsDataBase clsSQL = ClsBaseClass.ClsDataBaseFactory.Instance();

        public ClsRoleInfoDal()
        { }

        #region  ��Ա����

        /// <summary>
        /// �ر�һ������
        /// </summary>
        public string DeleteUser(string vchrUid)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete _UserInfo ");
            //strSql.Append(" where vchrUid='" + vchrUid + "'");
            return(strSql.ToString());
        }
        /// <summary>
		/// ɾ��һ������
		/// </summary>
        public string DeleteRole(string vchrUserID)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _RoleInfo set ");
            strSql.Append("bClosed=1");
            strSql.Append(" where vchrRoleID='" + vchrUserID + "'");
			return(strSql.ToString());
		}

        /// <summary>
        /// ����һ������
        /// </summary>
        public string UnDeleteRole(string vchrUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _RoleInfo set ");
            strSql.Append("bClosed=0");
            strSql.Append(" where vchrRoleID='" + vchrUserID + "'");
            return (strSql.ToString());
        }
        #endregion  ��Ա����

        public void Delete(string sRoleID)
        {
            ArrayList aList = new ArrayList();
            string sSQL = DeleteRole(sRoleID);
            aList.Add(sSQL);

            //sSQL = DeleteUser(sRoleID);
            //aList.Add(sSQL);

            clsSQL.ExecSqlTran(aList);
        }

        public void UnDelete(string sRoleID)
        {
            ArrayList aList = new ArrayList();
            string sSQL = UnDeleteRole(sRoleID);
            aList.Add(sSQL);
            clsSQL.ExecSqlTran(aList);
        }
    }
}
