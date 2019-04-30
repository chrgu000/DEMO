using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:RdRecords01_Import
    /// </summary>
    public partial class RdRecords01_Import
    {
        public RdRecords01_Import()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.RdRecords01_Import model)
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
            if (model.CONTAINERNO != null)
            {
                strSql1.Append("CONTAINERNO,");
                strSql2.Append("'" + model.CONTAINERNO + "',");
            }
            if (model.DESCRIPTIONOFPRODUCTSEN != null)
            {
                strSql1.Append("DESCRIPTIONOFPRODUCTSEN,");
                strSql2.Append("'" + model.DESCRIPTIONOFPRODUCTSEN + "',");
            }
            if (model.CASENO != null)
            {
                strSql1.Append("CASENO,");
                strSql2.Append("'" + model.CASENO + "',");
            }
            if (model.BOXNO != null)
            {
                strSql1.Append("BOXNO,");
                strSql2.Append("'" + model.BOXNO + "',");
            }
            if (model.BOXQTY != null)
            {
                strSql1.Append("BOXQTY,");
                strSql2.Append("" + model.BOXQTY + ",");
            }
            if (model.QUANTITY != null)
            {
                strSql1.Append("QUANTITY,");
                strSql2.Append("" + model.QUANTITY + ",");
            }
            if (model.UNIT != null)
            {
                strSql1.Append("UNIT,");
                strSql2.Append("'" + model.UNIT + "',");
            }
            if (model.PARTNO != null)
            {
                strSql1.Append("PARTNO,");
                strSql2.Append("'" + model.PARTNO + "',");
            }
            if (model.NWKGS != null)
            {
                strSql1.Append("NWKGS,");
                strSql2.Append("" + model.NWKGS + ",");
            }
            if (model.GWKGS != null)
            {
                strSql1.Append("GWKGS,");
                strSql2.Append("" + model.GWKGS + ",");
            }
            if (model.BOXCBM != null)
            {
                strSql1.Append("BOXCBM,");
                strSql2.Append("" + model.BOXCBM + ",");
            }
            if (model.CONNO != null)
            {
                strSql1.Append("CONNO,");
                strSql2.Append("'" + model.CONNO + "',");
            }
 
            if (model.POsID != null)
            {
                strSql1.Append("POsID,");
                strSql2.Append("" + model.POsID + ",");
            }
            if (model.Rds01ID != null)
            {
                strSql1.Append("Rds01ID,");
                strSql2.Append("" + model.Rds01ID + ",");
            }
            if (model.UnitPrice != null)
            {
                strSql1.Append("UnitPrice,");
                strSql2.Append("" + model.UnitPrice + ",");
            }
            if (model.BLDate != null)
            {
                strSql1.Append("BLDate,");
                strSql2.Append("'" + model.BLDate + "',");
            }
            if (model.BLNo != null)
            {
                strSql1.Append("BLNo,");
                strSql2.Append("'" + model.BLNo + "',");
            }
            if (model.Currency != null)
            {
                strSql1.Append("Currency,");
                strSql2.Append("'" + model.Currency + "',");
            }
            strSql.Append("insert into RdRecords01_Import(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return  (strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int AutoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RdRecords01_Import ");
            strSql.Append(" where AutoID=" + AutoID + "");
            return (strSql.ToString());
        }		/// <summary>
      
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

