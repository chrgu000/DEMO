using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ClsU8.Dal
{
    class ClsUserInfoDal
    {
        ClsBaseClass.ClsDataBase clsSQL = ClsBaseClass.ClsDataBaseFactory.Instance();

        public ClsUserInfoDal()
        { }

        #region  成员方法

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string DeleteUser(string vchrUid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete _UserInfo ");
            strSql.Append(" where vchrUid='" + vchrUid + "'");
            strSql.Append("delete ProjectRole ");
            strSql.Append(" where vchrUid='" + vchrUid + "'");
            return(strSql.ToString());
        }
        /// <summary>
		/// 删除一条数据
		/// </summary>
        public string DeleteUserRole(string vchrUserID)
		{
				StringBuilder strSql=new StringBuilder();
				strSql.Append("delete _UserRoleInfo ");
                strSql.Append(" where vchrUserID='" + vchrUserID+"'");
				return(strSql.ToString());
		}
        #endregion  成员方法

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
