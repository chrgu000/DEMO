using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
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
        /// 是否存在该记录
        /// </summary>
        public string Exists(string sWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cNumber from VoucherHistory");
            strSql.Append(" where 1=1 and " + sWhere);
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.VoucherHistory model)
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
            strSql.Append("insert into VoucherHistory(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model.VoucherHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VoucherHistory set ");
            if (model.iRdFlagSeed != null)
            {
                strSql.Append("iRdFlagSeed=" + model.iRdFlagSeed + ",");
            }
            else
            {
                strSql.Append("iRdFlagSeed= null ,");
            }
            if (model.cContentRule != null)
            {
                strSql.Append("cContentRule='" + model.cContentRule + "',");
            }
            else
            {
                strSql.Append("cContentRule= null ,");
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
            strSql.Append(" where cSeed = '" + model.cSeed + "' and CardNumber = '" + model.CardNumber + "'");
            return (strSql.ToString());

        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

