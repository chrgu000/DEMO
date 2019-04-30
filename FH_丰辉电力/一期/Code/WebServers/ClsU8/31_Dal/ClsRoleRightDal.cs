using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ClsU8.Dal
{
    class ClsRoleRightDal
    {
        ClsBaseClass.ClsDataBase clsSQL = ClsBaseClass.ClsDataBaseFactory.Instance();
        public ClsRoleRightDal()
        { }


        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        private string AddRoleRight(string sPK,DataRow dr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into _RoleRight(");
            strSql.Append("vchrRoleID,vchrRoleRight");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + sPK + "',");
            strSql.Append("'" + dr["vchrRoleRight"].ToString().Trim() + "'");
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  成员方法

        public void AddSQL(string sPK,DataTable dt)
        {
            string sSQL = "";
            ArrayList arrList = new ArrayList();
            sSQL = "delete dbo._RoleRight " +
                    "where vchrRoleID = '" + sPK + "' "; 
            arrList.Add(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sSQL = AddRoleRight(sPK,dt.Rows[i]);
                arrList.Add(sSQL);
            }

            clsSQL.ExecSqlTran(arrList);
        }
    }
}
