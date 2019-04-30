using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_能源分配
    /// </summary>
    public partial class _能源分配
    {
        public _能源分配()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._能源分配 model)
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
            if (model.供水分配率 != null)
            {
                strSql1.Append("供水分配率,");
                strSql2.Append("" + model.供水分配率 + ",");
            }
            if (model.供水金额 != null)
            {
                strSql1.Append("供水金额,");
                strSql2.Append("" + model.供水金额 + ",");
            }
            if (model.供电分配率 != null)
            {
                strSql1.Append("供电分配率,");
                strSql2.Append("" + model.供电分配率 + ",");
            }
            if (model.供电金额 != null)
            {
                strSql1.Append("供电金额,");
                strSql2.Append("" + model.供电金额 + ",");
            }
            if (model.供汽分配率 != null)
            {
                strSql1.Append("供汽分配率,");
                strSql2.Append("" + model.供汽分配率 + ",");
            }
            if (model.供汽金额 != null)
            {
                strSql1.Append("供汽金额,");
                strSql2.Append("" + model.供汽金额 + ",");
            }
            if (model.开利机组冷水机组分配率 != null)
            {
                strSql1.Append("开利机组冷水机组分配率,");
                strSql2.Append("" + model.开利机组冷水机组分配率 + ",");
            }
            if (model.开利机组冷水机组金额 != null)
            {
                strSql1.Append("开利机组冷水机组金额,");
                strSql2.Append("" + model.开利机组冷水机组金额 + ",");
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
            strSql.Append("insert into _能源分配(");
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

