using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:PurBillVouchs_Import
    /// </summary>
    public partial class PurBillVouchs_Import
    {
        public PurBillVouchs_Import()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouchs_Import model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ImportTime != null)
            {
                strSql1.Append("ImportTime,");
                strSql2.Append("'" + model.ImportTime + "',");
            }
            if (model.InvoiceNo != null)
            {
                strSql1.Append("InvoiceNo,");
                strSql2.Append("'" + model.InvoiceNo + "',");
            }
            if (model.Date != null)
            {
                strSql1.Append("Date,");
                strSql2.Append("'" + model.Date + "',");
            }
            if (model.Companyname != null)
            {
                strSql1.Append("Companyname,");
                strSql2.Append("'" + model.Companyname + "',");
            }
            if (model.PONO != null)
            {
                strSql1.Append("PONO,");
                strSql2.Append("'" + model.PONO + "',");
            }
            if (model.PARTNO != null)
            {
                strSql1.Append("PARTNO,");
                strSql2.Append("'" + model.PARTNO + "',");
            }
            if (model.DESCRIPTIONENGLISH != null)
            {
                strSql1.Append("DESCRIPTIONENGLISH,");
                strSql2.Append("'" + model.DESCRIPTIONENGLISH + "',");
            }
            if (model.QUANTITY != null)
            {
                strSql1.Append("QUANTITY,");
                strSql2.Append("" + model.QUANTITY + ",");
            }
            if (model.NW != null)
            {
                strSql1.Append("NW,");
                strSql2.Append("" + model.NW + ",");
            }
            if (model.GW != null)
            {
                strSql1.Append("GW,");
                strSql2.Append("" + model.GW + ",");
            }
            if (model.PRICEPERUNIT != null)
            {
                strSql1.Append("PRICEPERUNIT,");
                strSql2.Append("" + model.PRICEPERUNIT + ",");
            }
            if (model.UNIT != null)
            {
                strSql1.Append("UNIT,");
                strSql2.Append("'" + model.UNIT + "',");
            }
            if (model.TOTALPRICE != null)
            {
                strSql1.Append("TOTALPRICE,");
                strSql2.Append("" + model.TOTALPRICE + ",");
            }
            strSql.Append("insert into PurBillVouchs_Import(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

