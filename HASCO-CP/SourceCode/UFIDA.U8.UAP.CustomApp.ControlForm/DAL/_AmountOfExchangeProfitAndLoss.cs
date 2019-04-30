using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_AmountOfExchangeProfitAndLoss
    /// </summary>
    public partial class _AmountOfExchangeProfitAndLoss
    {
        public _AmountOfExchangeProfitAndLoss()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AmountOfExchangeProfitAndLoss model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iYear != null)
            {
                strSql1.Append("iYear,");
                strSql2.Append("" + model.iYear + ",");
            }
            if (model.iPeriod != null)
            {
                strSql1.Append("iPeriod,");
                strSql2.Append("" + model.iPeriod + ",");
            }
            if (model.AutoID != null)
            {
                strSql1.Append("AutoID,");
                strSql2.Append("" + model.AutoID + ",");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
            }
            if (model.cExch_Name != null)
            {
                strSql1.Append("cExch_Name,");
                strSql2.Append("'" + model.cExch_Name + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cInvName != null)
            {
                strSql1.Append("cInvName,");
                strSql2.Append("'" + model.cInvName + "',");
            }
            if (model.cInvStd != null)
            {
                strSql1.Append("cInvStd,");
                strSql2.Append("'" + model.cInvStd + "',");
            }
            if (model.iOriSum != null)
            {
                strSql1.Append("iOriSum,");
                strSql2.Append("" + model.iOriSum + ",");
            }
            if (model.nflat != null)
            {
                strSql1.Append("nflat,");
                strSql2.Append("" + model.nflat + ",");
            }
            if (model.nflat2 != null)
            {
                strSql1.Append("nflat2,");
                strSql2.Append("" + model.nflat2 + ",");
            }
            if (model.AmountOfExchangeProfitAndLoss != null)
            {
                strSql1.Append("AmountOfExchangeProfitAndLoss,");
                strSql2.Append("" + model.AmountOfExchangeProfitAndLoss + ",");
            }
            if (model.ino_id != null)
            {
                strSql1.Append("ino_id,");
                strSql2.Append("'" + model.ino_id + "',");
            }
            if (model.cSign != null)
            {
                strSql1.Append("csign,");
                strSql2.Append("'" + model.cSign + "',");
            }
            if (model.i_ID != null)
            {
                strSql1.Append("i_ID,");
                strSql2.Append("" + model.i_ID + ",");
            }
            if (model.redi_ID != null)
            {
                strSql1.Append("redi_ID,");
                strSql2.Append("" + model.redi_ID + ",");
            }
            strSql.Append("insert into _AmountOfExchangeProfitAndLoss(");
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

