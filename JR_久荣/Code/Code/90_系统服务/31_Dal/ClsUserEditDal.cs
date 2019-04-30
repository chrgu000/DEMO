using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace 系统服务.Dal
{
    class ClsUserEditDal
    {
        系统服务.ClsDataBase clsSQL = 系统服务.ClsDataBaseFactory.Instance();
        ClsDES clsDES = ClsDES.Instance();
        public ClsUserEditDal()
        {}
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        private string AddUser(系统服务.Model.ClsUserInfoMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into _UserInfo(");
            strSql.Append("vchrUid,vchrName,vchrPwd,vchrRemark,dtmCreate,dtmClose");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.vchrUid + "',");
            strSql.Append("'" + model.vchrName + "',");
            strSql.Append("'" + clsDES.Encrypt(model.vchrPwd) + "',");
            strSql.Append("'" + model.vchrRemark + "',");
            strSql.Append("'" + model.dtmCreate + "',");
            strSql.Append("'" + model.dtmClose + "'");
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
        private string UpdateUser(系统服务.Model.ClsUserInfoMod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _UserInfo set ");
            strSql.Append("vchrPwd='" +  clsDES.Encrypt(model.vchrPwd) + "',");
            strSql.Append("vchrName='" + model.vchrName + "',");
            strSql.Append("vchrRemark='" + model.vchrRemark + "',");
            strSql.Append("dtmCreate='" + model.dtmCreate + "',");
            strSql.Append("dtmClose='" + model.dtmClose + "'");
            strSql.Append(" where vchrUid='" + model.vchrUid + "'");
            return (strSql.ToString());
        }

        #endregion  成员方法


        public void UpdateSQL(系统服务.Model.ClsUserInfoMod model, DataTable dt)
        {
            ArrayList arrList = new ArrayList();
            string sSQL = UpdateUser(model);
            arrList.Add(sSQL);

            sSQL = "delete dbo._UserRoleInfo " +
                    "where vchrUserID = '" + model.vchrUid + "' ";
            arrList.Add(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                系统服务.Model.ClsUserRoleMod clsMod = new 系统服务.Model.ClsUserRoleMod();
                if (dt.Rows[i]["bChoosed"].ToString().Trim() == "√")
                {
                    clsMod.vchrUserID = model.vchrUid;
                    clsMod.vchrRoleID = dt.Rows[i]["vchrRoleID"].ToString().Trim();
                    string s = AddUserRole(clsMod);
                    arrList.Add(s);
                }
            }

            clsSQL.ExecSqlTran(arrList);
        }

        public void AddSQL(系统服务.Model.ClsUserInfoMod model, DataTable dt)
        {
            ArrayList arrList = new ArrayList();
            string sSQL = AddUser(model);
            arrList.Add(sSQL);

            sSQL = "delete dbo._UserRoleInfo " +
                    "where vchrUserID = '" + model.vchrUid + "' ";
            arrList.Add(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                系统服务.Model.ClsUserRoleMod clsMod = new 系统服务.Model.ClsUserRoleMod();
                if (dt.Rows[i]["bChoosed"].ToString().Trim() == "√")
                {
                    clsMod.vchrUserID = model.vchrUid;
                    clsMod.vchrRoleID = dt.Rows[i]["vchrRoleID"].ToString().Trim();
                    string s = AddUserRole(clsMod);
                    arrList.Add(s);
                }
            }

            clsSQL.ExecSqlTran(arrList);
        }
    }
}
