using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_辅助费用分配
    /// </summary>
    public partial class _辅助费用分配
    {
        public _辅助费用分配()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._辅助费用分配 model)
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
            if (model.机修工时 != null)
            {
                strSql1.Append("机修工时,");
                strSql2.Append("" + model.机修工时 + ",");
            }
            if (model.机修金额 != null)
            {
                strSql1.Append("机修金额,");
                strSql2.Append("" + model.机修金额 + ",");
            }
            if (model.仪表工时 != null)
            {
                strSql1.Append("仪表工时,");
                strSql2.Append("" + model.仪表工时 + ",");
            }
            if (model.仪表金额 != null)
            {
                strSql1.Append("仪表金额,");
                strSql2.Append("" + model.仪表金额 + ",");
            }
            if (model.环保工时 != null)
            {
                strSql1.Append("环保工时,");
                strSql2.Append("" + model.环保工时 + ",");
            }
            if (model.环保金额 != null)
            {
                strSql1.Append("环保金额,");
                strSql2.Append("" + model.环保金额 + ",");
            }
            if (model.合计 != null)
            {
                strSql1.Append("合计,");
                strSql2.Append("" + model.合计 + ",");
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
            strSql.Append("insert into _辅助费用分配(");
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

