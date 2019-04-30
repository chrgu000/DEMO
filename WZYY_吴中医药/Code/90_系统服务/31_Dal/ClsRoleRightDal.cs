using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace ϵͳ����.Dal
{
    class ClsRoleRightDal
    {
        ϵͳ����.ClsDataBase clsSQL = ϵͳ����.ClsDataBaseFactory.Instance();
        public ClsRoleRightDal()
        { }


        #region  ��Ա����

        /// <summary>
        /// ����һ������
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
        #endregion  ��Ա����

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
