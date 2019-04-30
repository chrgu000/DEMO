using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_回款_sap
    /// </summary>
    public partial class _回款_sap
    {
        public _回款_sap()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _回款_sap");
            strSql.Append(" where iID=" + iID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._回款_sap model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.收款单号 != null)
            {
                strSql1.Append("收款单号,");
                strSql2.Append("'" + model.收款单号 + "',");
            }
            if (model.收款单日期 != null)
            {
                strSql1.Append("收款单日期,");
                strSql2.Append("'" + model.收款单日期 + "',");
            }
            if (model.收款单金额 != null)
            {
                strSql1.Append("收款单金额,");
                strSql2.Append("" + model.收款单金额 + ",");
            }
            if (model.业务员编码 != null)
            {
                strSql1.Append("业务员编码,");
                strSql2.Append("'" + model.业务员编码 + "',");
            }
            if (model.业务员 != null)
            {
                strSql1.Append("业务员,");
                strSql2.Append("'" + model.业务员 + "',");
            }
            if (model.核销金额 != null)
            {
                strSql1.Append("核销金额,");
                strSql2.Append("" + model.核销金额 + ",");
            }
            if (model.核销日期 != null)
            {
                strSql1.Append("核销日期,");
                strSql2.Append("'" + model.核销日期 + "',");
            }
            if (model.发票号码 != null)
            {
                strSql1.Append("发票号码,");
                strSql2.Append("'" + model.发票号码 + "',");
            }
            if (model.发票日期 != null)
            {
                strSql1.Append("发票日期,");
                strSql2.Append("'" + model.发票日期 + "',");
            }
            if (model.销售组织 != null)
            {
                strSql1.Append("销售组织,");
                strSql2.Append("'" + model.销售组织 + "',");
            }
            if (model.客户编码 != null)
            {
                strSql1.Append("客户编码,");
                strSql2.Append("'" + model.客户编码 + "',");
            }
            if (model.客户名称 != null)
            {
                strSql1.Append("客户名称,");
                strSql2.Append("'" + model.客户名称 + "',");
            }
            if (model.发票金额 != null)
            {
                strSql1.Append("发票金额,");
                strSql2.Append("" + model.发票金额 + ",");
            }
            if (model.货币单位 != null)
            {
                strSql1.Append("货币单位,");
                strSql2.Append("'" + model.货币单位 + "',");
            }
            if (model.分配 != null)
            {
                strSql1.Append("分配,");
                strSql2.Append("'" + model.分配 + "',");
            }
            if (model.金税发票号 != null)
            {
                strSql1.Append("金税发票号,");
                strSql2.Append("'" + model.金税发票号 + "',");
            }
            if (model.清帐凭证号 != null)
            {
                strSql1.Append("清帐凭证号,");
                strSql2.Append("'" + model.清帐凭证号 + "',");
            }
            strSql.Append("insert into _回款_sap(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

       
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string 收款单号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _回款_sap ");
            strSql.Append(" where 收款单号='" + 收款单号 + "'");
            return (strSql.ToString());
        }	
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

