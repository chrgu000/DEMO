using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 业务.DAL
{
    /// <summary>
    /// 数据访问类:检验值
    /// </summary>
    public partial class 检验值
    {
        public 检验值()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(业务.Model.检验值 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.接收数据 != null)
            {
                strSql1.Append("接收数据,");
                strSql2.Append("N'" + model.接收数据 + "',");
            }
            if (model.发射器编号 != null)
            {
                strSql1.Append("发射器编号,");
                strSql2.Append("" + model.发射器编号 + ",");
            }
            if (model.测量数值 != null)
            {
                strSql1.Append("测量数值,");
                strSql2.Append("" + model.测量数值 + ",");
            }
            if (model.原始值 != null)
            {
                strSql1.Append("原始值,");
                strSql2.Append("" + model.原始值 + ",");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("getdate(),");
            }
            strSql.Append("insert into 检验值(");
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

