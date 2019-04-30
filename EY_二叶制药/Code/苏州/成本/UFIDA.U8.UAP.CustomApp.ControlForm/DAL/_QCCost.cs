using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_QCCost
    /// </summary>
    public partial class _QCCost
    {
        public _QCCost()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._QCCost model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.会计期间 != null)
            {
                strSql1.Append("会计期间,");
                strSql2.Append("'" + model.会计期间 + "',");
            }
            if (model.部门 != null)
            {
                strSql1.Append("部门,");
                strSql2.Append("'" + model.部门 + "',");
            }
            if (model.产品编码 != null)
            {
                strSql1.Append("产品编码,");
                strSql2.Append("'" + model.产品编码 + "',");
            }
            if (model.工时 != null)
            {
                strSql1.Append("工时,");
                strSql2.Append("" + model.工时 + ",");
            }
            if (model.能源 != null)
            {
                strSql1.Append("能源,");
                strSql2.Append("" + model.能源 + ",");
            }
            if (model.工资 != null)
            {
                strSql1.Append("工资,");
                strSql2.Append("" + model.工资 + ",");
            }
            if (model.制造费用 != null)
            {
                strSql1.Append("制造费用,");
                strSql2.Append("" + model.制造费用 + ",");
            }
            strSql.Append("insert into _QCCost(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

