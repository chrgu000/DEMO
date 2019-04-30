using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DllForService.DAL
{
    /// <summary>
    /// 数据访问类:_CreateDisInfo
    /// </summary>
    public partial class _CreateDisInfo
    {
        public _CreateDisInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string  Exists(string cSOCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _CreateDisInfo");
            strSql.Append(" where cSOCode='" + cSOCode + "' ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string  Add(DllForService.Model._CreateDisInfo model)
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
            strSql.Append("insert into _CreateDisInfo(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(DllForService.Model._CreateDisInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _CreateDisInfo set ");
            if (model.DisCode != null)
            {
                strSql.Append("DisCode='" + model.DisCode + "',");
            }
            if (model.RdCode != null)
            {
                strSql.Append("RdCode='" + model.RdCode + "',");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.Status != null)
            {
                strSql.Append("Status='" + model.Status + "',");
            }
            else
            {
                strSql.Append("Status= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where cSOCode= '" + model.cSOCode + "'");
            return(strSql.ToString());
        }
        #endregion  Method  
        #region  MethodEx

        #endregion  MethodEx
    }
}

