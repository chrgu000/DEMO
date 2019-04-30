using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_成本记录表
    /// </summary>
    public partial class _成本记录表
    {
        public _成本记录表()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._成本记录表 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.单据号 != null)
            {
                strSql1.Append("单据号,");
                strSql2.Append("'" + model.单据号 + "',");
            }
            if (model.单据日期 != null)
            {
                strSql1.Append("单据日期,");
                strSql2.Append("'" + model.单据日期 + "',");
            }
            if (model.部门编码 != null)
            {
                strSql1.Append("部门编码,");
                strSql2.Append("'" + model.部门编码 + "',");
            }
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.单价 != null)
            {
                strSql1.Append("单价,");
                strSql2.Append("" + model.单价 + ",");
            }
            if (model.金额 != null)
            {
                strSql1.Append("金额,");
                strSql2.Append("" + model.金额 + ",");
            }
            if (model.单据类型 != null)
            {
                strSql1.Append("单据类型,");
                strSql2.Append("'" + model.单据类型 + "',");
            }
            if (model.料 != null)
            {
                strSql1.Append("料,");
                strSql2.Append("" + model.料 + ",");
            }
            if (model.部门分摊 != null)
            {
                strSql1.Append("部门分摊,");
                strSql2.Append("" + model.部门分摊 + ",");
            }
            if (model.公用分摊 != null)
            {
                strSql1.Append("公用分摊,");
                strSql2.Append("" + model.公用分摊 + ",");
            }
            if (model.计算时间 != null)
            {
                strSql1.Append("计算时间,");
                strSql2.Append("'" + model.计算时间 + "',");
            }
            if (model.产品总数 != null)
            {
                strSql1.Append("产品总数,");
                strSql2.Append("" + model.产品总数 + ",");
            }
            if (model.id != null)
            {
                strSql1.Append("id,");
                strSql2.Append("" + model.id + ",");
            }
            if (model.autoid != null)
            {
                strSql1.Append("autoid,");
                strSql2.Append("" + model.autoid + ",");
            }
            if (model.收发类别 != null)
            {
                strSql1.Append("收发类别,");
                strSql2.Append("'" + model.收发类别 + "',");
            }
            if (model.会计期间 != null)
            {
                strSql1.Append("会计期间,");
                strSql2.Append("'" + model.会计期间 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("getdate(),");
            }
            strSql.Append("insert into _成本记录表(");
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

