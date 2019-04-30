using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:VoucherHistory
    /// </summary>
    public partial class VoucherHistory
    {
        public VoucherHistory()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.VoucherHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CardNumber != null)
            {
                strSql1.Append("CardNumber,");
                strSql2.Append("'" + model.CardNumber + "',");
            }
            if (model.iRdFlagSeed != null)
            {
                strSql1.Append("iRdFlagSeed,");
                strSql2.Append("" + model.iRdFlagSeed + ",");
            }
            if (model.cContent != null)
            {
                strSql1.Append("cContent,");
                strSql2.Append("'" + model.cContent + "',");
            }
            if (model.cContentRule != null)
            {
                strSql1.Append("cContentRule,");
                strSql2.Append("'" + model.cContentRule + "',");
            }
            if (model.cSeed != null)
            {
                strSql1.Append("cSeed,");
                strSql2.Append("'" + model.cSeed + "',");
            }
            if (model.cNumber != null)
            {
                strSql1.Append("cNumber,");
                strSql2.Append("'" + model.cNumber + "',");
            }
            if (model.bEmpty != null)
            {
                strSql1.Append("bEmpty,");
                strSql2.Append("" + (model.bEmpty ? 1 : 0) + ",");
            }
            strSql.Append("insert into @u8.VoucherHistory(");
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
        public string Update(TH.Model.VoucherHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update @u8.VoucherHistory set ");
            if (model.CardNumber != null)
            {
                strSql.Append("CardNumber='" + model.CardNumber + "',");
            }
            else
            {
                strSql.Append("CardNumber= null ,");
            }
            if (model.iRdFlagSeed != null)
            {
                strSql.Append("iRdFlagSeed=" + model.iRdFlagSeed + ",");
            }
            else
            {
                strSql.Append("iRdFlagSeed= null ,");
            }
            if (model.cContent != null)
            {
                strSql.Append("cContent='" + model.cContent + "',");
            }
            else
            {
                strSql.Append("cContent= null ,");
            }
            if (model.cContentRule != null)
            {
                strSql.Append("cContentRule='" + model.cContentRule + "',");
            }
            else
            {
                strSql.Append("cContentRule= null ,");
            }
            if (model.cSeed != null)
            {
                strSql.Append("cSeed='" + model.cSeed + "',");
            }
            else
            {
                strSql.Append("cSeed= null ,");
            }
            if (model.cNumber != null)
            {
                strSql.Append("cNumber='" + model.cNumber + "',");
            }
            if (model.bEmpty != null)
            {
                strSql.Append("bEmpty=" + (model.bEmpty ? 1 : 0) + ",");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where AutoId=" + model.AutoId + "");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

