using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ϵͳ����.Dal
{
    class ClsUserInfoDal
    {
        ϵͳ����.ClsDataBase clsSQL = ϵͳ����.ClsDataBaseFactory.Instance();

        public ClsUserInfoDal()
        { }

        #region  ��Ա����

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public string DeleteUser(string vchrUid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete _UserInfo ");
            strSql.Append(" where vchrUid='" + vchrUid + "'");
            return(strSql.ToString());
        }
        /// <summary>
		/// ɾ��һ������
		/// </summary>
        public string DeleteUserRole(string vchrUserID)
		{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("delete _UserRoleInfo ");
                strSql.Append(" where vchrUserID='" + vchrUserID+"'");
				return(strSql.ToString());
		}
        #endregion  ��Ա����

        public void Delete(string sUserID)
        {
            ArrayList aList = new ArrayList();
            string sSQL = DeleteUserRole(sUserID);
            aList.Add(sSQL);

            sSQL = DeleteUser(sUserID);
            aList.Add(sSQL);

            clsSQL.ExecSqlTran(aList);
        }
    }
}
