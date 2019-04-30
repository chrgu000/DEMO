using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DllForService.DAL
{
    /// <summary>
    /// 数据访问类:_CreateDisInfo_Log
    /// </summary>
    public partial class _CreateDisInfo_Log
    {
        public _CreateDisInfo_Log()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DllForService.Model._CreateDisInfo_Log model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cSOCode != null)
            {
                strSql1.Append("cSOCode,");
                strSql2.Append("'" + model.cSOCode + "',");
            }
            if (model.DisCode != null)
            {
                strSql1.Append("DisCode,");
                strSql2.Append("'" + model.DisCode + "',");
            }
            if (model.RdCode != null)
            {
                strSql1.Append("RdCode,");
                strSql2.Append("'" + model.RdCode + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("'" + model.Status + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into _CreateDisInfo_Log(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

