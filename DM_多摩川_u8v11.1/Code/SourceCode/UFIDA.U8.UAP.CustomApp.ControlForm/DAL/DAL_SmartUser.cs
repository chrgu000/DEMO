using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH.BaseClass;
using System.Data;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class DAL_SmartUser
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _User");
            strSql.Append(" where UserID='" + UserID + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model_SmartUser model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.UserID != null)
            {
                strSql1.Append("UserID,");
                strSql2.Append("'" + model.UserID + "',");
            }
            if (model.Pwd != null)
            {
                strSql1.Append("Pwd,");
                strSql2.Append("'" + model.Pwd + "',");
            }
            if (model.EndDate != null)
            {
                strSql1.Append("EndDate,");
                strSql2.Append("'" + model.EndDate + "',");
            }
            strSql.Append("insert into _User(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model_SmartUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _User set ");
            if (model.Pwd != null)
            {
                strSql.Append("Pwd='" + model.Pwd + "',");
            }
            if (model.EndDate != null)
            {
                strSql.Append("EndDate='" + model.EndDate + "',");
            }
            else
            {
                strSql.Append("EndDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where UserID='" + model.UserID + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UFIDA.U8.UAP.CustomApp.ControlForm.Model_SmartUser DataRowToModel(DataRow row)
        {
            UFIDA.U8.UAP.CustomApp.ControlForm.Model_SmartUser model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model_SmartUser();
            if (row != null)
            {
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
            }
            return model;
        }
    }
}
