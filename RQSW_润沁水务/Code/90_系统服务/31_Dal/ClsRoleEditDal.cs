using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace 系统服务.Dal
{
    class ClsRoleEditDal
    {
        系统服务.ClsDataBase clsSQL = 系统服务.ClsDataBaseFactory.Instance();
        public ClsRoleEditDal()
        {}
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        private string AddRole(系统服务.Model.ClsRoleInfoMod model)
        {
            int iClose = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into _RoleInfo(");
            strSql.Append("vchrRoleID,vchrRoleText,vchrRemark,bClosed,dtmCreate");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.vchrRoleID + "',");
            strSql.Append("'" + model.vchrRoleText + "',");
            strSql.Append("'" + model.vchrRemark + "',");
            if (model.bClosed)
                iClose = 1;
            else
                iClose = 0;
            strSql.Append("" + iClose + ",");
            strSql.Append("'" + model.dtmCreate + "'");
            strSql.Append(")");
            return(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        private string AddUserRole(系统服务.Model.ClsUserRoleMod model)
        {
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into _UserRoleInfo(");
			strSql.Append("vchrUserID,vchrRoleID");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+model.vchrUserID+"',");
			strSql.Append("'"+model.vchrRoleID+"'");
			strSql.Append(")");
			return(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        private string UpdateRole(系统服务.Model.ClsRoleInfoMod model)
        {
            int iClose;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _RoleInfo set ");
            strSql.Append("vchrRoleText='" + model.vchrRoleText + "',");
            strSql.Append("vchrRemark='" + model.vchrRemark + "',");
            if (model.bClosed)
                iClose = 1;
            else
                iClose = 0;
            strSql.Append("bClosed=" + iClose + ",");
            strSql.Append("dtmCreate='" + model.dtmCreate + "'");
            strSql.Append(" where vchrRoleID='" + model.vchrRoleID + "'");
            return (strSql.ToString());
        }

        #endregion  成员方法

        public void UpdateSQL(系统服务.Model.ClsRoleInfoMod model, DataTable dt)
        {
            ArrayList arrList = new ArrayList();
            string sSQL = UpdateRole(model);
            arrList.Add(sSQL);

            sSQL = "delete dbo._UserRoleInfo " +
                    "where vchrRoleID = '" + model.vchrRoleID + "' ";
            arrList.Add(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                系统服务.Model.ClsUserRoleMod clsMod = new 系统服务.Model.ClsUserRoleMod();
                if (dt.Rows[i]["bChoosed"].ToString().Trim() == "√")
                {
                    clsMod.vchrUserID = dt.Rows[i]["vchrUID"].ToString().Trim();
                    clsMod.vchrRoleID = model.vchrRoleID;
                    string s = AddUserRole(clsMod);
                    arrList.Add(s);
                }
            }

            clsSQL.ExecSqlTran(arrList);
        }

        public void AddSQL(系统服务.Model.ClsRoleInfoMod model, DataTable dt)
        {
            ArrayList arrList = new ArrayList();
            string sSQL = AddRole(model);
            arrList.Add(sSQL);

            sSQL = "delete dbo._UserRoleInfo " +
                    "where vchrRoleID  = '" + model.vchrRoleID + "' ";
            arrList.Add(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                系统服务.Model.ClsUserRoleMod clsMod = new 系统服务.Model.ClsUserRoleMod();
                if (dt.Rows[i]["bChoosed"].ToString().Trim() == "√")
                {
                    clsMod.vchrUserID = dt.Rows[i]["vchrUID"].ToString().Trim();
                    clsMod.vchrRoleID = model.vchrRoleID;
                    string s = AddUserRole(clsMod);
                    arrList.Add(s);
                }
            }

            clsSQL.ExecSqlTran(arrList);
        }
    }
}
