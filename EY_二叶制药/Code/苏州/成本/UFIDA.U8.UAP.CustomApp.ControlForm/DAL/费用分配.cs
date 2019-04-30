using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_费用分配
    /// </summary>
    public partial class _费用分配
    {
        public _费用分配()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._费用分配 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.会计期间 != null)
            {
                strSql1.Append("会计期间,");
                strSql2.Append("'" + model.会计期间 + "',");
            }
            if (model.部门编码 != null)
            {
                strSql1.Append("部门编码,");
                strSql2.Append("'" + model.部门编码 + "',");
            }
            if (model.应摊能源费用 != null)
            {
                strSql1.Append("应摊能源费用,");
                strSql2.Append("" + model.应摊能源费用 + ",");
            }
            if (model.应摊工资费用 != null)
            {
                strSql1.Append("应摊工资费用,");
                strSql2.Append("" + model.应摊工资费用 + ",");
            }
            if (model.应摊制造费用 != null)
            {
                strSql1.Append("应摊制造费用,");
                strSql2.Append("" + model.应摊制造费用 + ",");
            }
            if (model.合计分摊 != null)
            {
                strSql1.Append("合计分摊,");
                strSql2.Append("" + model.合计分摊 + ",");
            }
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.生产工时 != null)
            {
                strSql1.Append("生产工时,");
                strSql2.Append("" + model.生产工时 + ",");
            }
            if (model.冻干工时 != null)
            {
                strSql1.Append("冻干工时,");
                strSql2.Append("" + model.冻干工时 + ",");
            }
            if (model.应摊能源费用行 != null)
            {
                strSql1.Append("应摊能源费用行,");
                strSql2.Append("" + model.应摊能源费用行 + ",");
            }
            if (model.应摊工资费用行 != null)
            {
                strSql1.Append("应摊工资费用行,");
                strSql2.Append("" + model.应摊工资费用行 + ",");
            }
            if (model.应摊制造费用行 != null)
            {
                strSql1.Append("应摊制造费用行,");
                strSql2.Append("" + model.应摊制造费用行 + ",");
            }
            if (model.合计分摊行 != null)
            {
                strSql1.Append("合计分摊行,");
                strSql2.Append("" + model.合计分摊行 + ",");
            }
            if (model.行类型 != null)
            {
                strSql1.Append("行类型,");
                strSql2.Append("" + model.行类型 + ",");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            if (model.记账人 != null)
            {
                strSql1.Append("记账人,");
                strSql2.Append("'" + model.记账人 + "',");
            }
            if (model.记账日期 != null)
            {
                strSql1.Append("记账日期,");
                strSql2.Append("'" + model.记账日期 + "',");
            }
            strSql.Append("insert into _费用分配(");
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

