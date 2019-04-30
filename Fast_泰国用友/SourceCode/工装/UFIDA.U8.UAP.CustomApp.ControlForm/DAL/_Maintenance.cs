using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_Maintenance
    /// </summary>
    public partial class _Maintenance
    {
        public _Maintenance()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Maintenance model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("N'" + model.GUID.ToString() + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("N'" + model.cCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("N'" + model.dDate + "',");
            }
            if (model.Person != null)
            {
                strSql1.Append("Person,");
                strSql2.Append("N'" + model.Person + "',");
            }
            if (model.DepCode != null)
            {
                strSql1.Append("DepCode,");
                strSql2.Append("N'" + model.DepCode + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("N'" + model.Remark + "',");
            }
            if (model.CreateUserName != null)
            {
                strSql1.Append("CreateUserName,");
                strSql2.Append("N'" + model.CreateUserName + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("N'" + model.CreateDate + "',");
            }
            if (model.AuditUserName != null)
            {
                strSql1.Append("AuditUserName,");
                strSql2.Append("N'" + model.AuditUserName + "',");
            }
            if (model.AuditDate != null)
            {
                strSql1.Append("AuditDate,");
                strSql2.Append("N'" + model.AuditDate + "',");
            }
            strSql.Append("insert into _Maintenance(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Maintenance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _Maintenance set ");
            if (model.GUID != null)
            {
                strSql.Append("GUID=N'" + model.GUID + "',");
            }
            else
            {
                strSql.Append("GUID= null ,");
            }
            if (model.dDate != null)
            {
                strSql.Append("dDate=N'" + model.dDate + "',");
            }
            else
            {
                strSql.Append("dDate= null ,");
            }
            if (model.Person != null)
            {
                strSql.Append("Person=N'" + model.Person + "',");
            }
            else
            {
                strSql.Append("Person= null ,");
            }
            if (model.DepCode != null)
            {
                strSql.Append("DepCode=N'" + model.DepCode + "',");
            }
            else
            {
                strSql.Append("DepCode= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark=N'" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.CreateUserName != null)
            {
                strSql.Append("CreateUserName=N'" + model.CreateUserName + "',");
            }
            else
            {
                strSql.Append("CreateUserName= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate=N'" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.AuditUserName != null)
            {
                strSql.Append("AuditUserName=N'" + model.AuditUserName + "',");
            }
            else
            {
                strSql.Append("AuditUserName= null ,");
            }
            if (model.AuditDate != null)
            {
                strSql.Append("AuditDate=N'" + model.AuditDate + "',");
            }
            else
            {
                strSql.Append("AuditDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where cCode=" + model.cCode + "");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

