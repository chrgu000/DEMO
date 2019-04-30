using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_共耗费用登记
    /// </summary>
    public partial class _共耗费用登记
    {
        public _共耗费用登记()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._共耗费用登记 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.费用类型 != null)
            {
                strSql1.Append("费用类型,");
                strSql2.Append("'" + model.费用类型 + "',");
            }
            if (model.会计期间 != null)
            {
                strSql1.Append("会计期间,");
                strSql2.Append("'" + model.会计期间 + "',");
            }
            if (model.金额 != null)
            {
                strSql1.Append("金额,");
                strSql2.Append("" + model.金额 + ",");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
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
            if (model.修改人 != null)
            {
                strSql1.Append("修改人,");
                strSql2.Append("'" + model.修改人 + "',");
            }
            if (model.修改日期 != null)
            {
                strSql1.Append("修改日期,");
                strSql2.Append("'" + model.修改日期 + "',");
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
            strSql.Append("insert into _共耗费用登记(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._共耗费用登记 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _共耗费用登记 set ");
            if (model.金额 != null)
            {
                strSql.Append("金额=" + model.金额 + ",");
            }
            else
            {
                strSql.Append("金额= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            else
            {
                strSql.Append("制单人= null ,");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            else
            {
                strSql.Append("制单日期= null ,");
            }
            if (model.修改人 != null)
            {
                strSql.Append("修改人='" + model.修改人 + "',");
            }
            else
            {
                strSql.Append("修改人= null ,");
            }
            if (model.修改日期 != null)
            {
                strSql.Append("修改日期='" + model.修改日期 + "',");
            }
            else
            {
                strSql.Append("修改日期= null ,");
            }
            if (model.审核人 != null)
            {
                strSql.Append("审核人='" + model.审核人 + "',");
            }
            else
            {
                strSql.Append("审核人= null ,");
            }
            if (model.审核日期 != null)
            {
                strSql.Append("审核日期='" + model.审核日期 + "',");
            }
            else
            {
                strSql.Append("审核日期= null ,");
            }
            if (model.记账人 != null)
            {
                strSql.Append("记账人='" + model.记账人 + "',");
            }
            else
            {
                strSql.Append("记账人= null ,");
            }
            if (model.记账日期 != null)
            {
                strSql.Append("记账日期='" + model.记账日期 + "',");
            }
            else
            {
                strSql.Append("记账日期= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where 费用类型='" + model.费用类型 + "' and 会计期间='" + model.会计期间 + "' ");
            return (strSql.ToString());

        }


        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

