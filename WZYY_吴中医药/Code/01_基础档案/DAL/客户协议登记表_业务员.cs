using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 基础设置.DAL
{
    /// <summary>
    /// 数据访问类:客户协议登记表_业务员
    /// </summary>
    public partial class 客户协议登记表_业务员
    {
        public 客户协议登记表_业务员()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(基础设置.Model.客户协议登记表_业务员 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + model.GUID + "',");
            }
            if (model.cPersonCode != null)
            {
                strSql1.Append("cPersonCode,");
                strSql2.Append("'" + model.cPersonCode + "',");
            }
            if (model.StartDate != null && model.StartDate > Convert.ToDateTime("1900-01-01"))
            {
                strSql1.Append("StartDate,");
                strSql2.Append("'" + model.StartDate + "',");
            }
            if (model.ENDDate != null && model.ENDDate > Convert.ToDateTime("1900-01-01"))
            {
                strSql1.Append("ENDDate,");
                strSql2.Append("'" + model.ENDDate + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into 客户协议登记表_业务员(");
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

