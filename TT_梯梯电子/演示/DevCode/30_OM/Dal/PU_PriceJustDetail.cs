using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace OM.DAL
{
    /// <summary>
    /// 数据访问类:PU_PriceJustDetail
    /// </summary>
    public partial class PU_PriceJustDetail
    {
        public PU_PriceJustDetail()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(OM.Model.PU_PriceJustDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.autoid != null)
            {
                strSql1.Append("autoid,");
                strSql2.Append("" + model.autoid + ",");
            }
            if (model.id != null)
            {
                strSql1.Append("id,");
                strSql2.Append("" + model.id + ",");
            }
            if (model.operationtype != null)
            {
                strSql1.Append("operationtype,");
                strSql2.Append("'" + model.operationtype + "',");
            }
            if (model.ipriceid != null)
            {
                strSql1.Append("ipriceid,");
                strSql2.Append("" + model.ipriceid + ",");
            }
            if (model.cvencode != null)
            {
                strSql1.Append("cvencode,");
                strSql2.Append("'" + model.cvencode + "',");
            }
            if (model.cinvcode != null)
            {
                strSql1.Append("cinvcode,");
                strSql2.Append("'" + model.cinvcode + "',");
            }
            if (model.cfree1 != null)
            {
                strSql1.Append("cfree1,");
                strSql2.Append("'" + model.cfree1 + "',");
            }
            if (model.cfree2 != null)
            {
                strSql1.Append("cfree2,");
                strSql2.Append("'" + model.cfree2 + "',");
            }
            if (model.cfree3 != null)
            {
                strSql1.Append("cfree3,");
                strSql2.Append("'" + model.cfree3 + "',");
            }
            if (model.cfree4 != null)
            {
                strSql1.Append("cfree4,");
                strSql2.Append("'" + model.cfree4 + "',");
            }
            if (model.cfree5 != null)
            {
                strSql1.Append("cfree5,");
                strSql2.Append("'" + model.cfree5 + "',");
            }
            if (model.cfree6 != null)
            {
                strSql1.Append("cfree6,");
                strSql2.Append("'" + model.cfree6 + "',");
            }
            if (model.cfree7 != null)
            {
                strSql1.Append("cfree7,");
                strSql2.Append("'" + model.cfree7 + "',");
            }
            if (model.cfree8 != null)
            {
                strSql1.Append("cfree8,");
                strSql2.Append("'" + model.cfree8 + "',");
            }
            if (model.cfree9 != null)
            {
                strSql1.Append("cfree9,");
                strSql2.Append("'" + model.cfree9 + "',");
            }
            if (model.cfree10 != null)
            {
                strSql1.Append("cfree10,");
                strSql2.Append("'" + model.cfree10 + "',");
            }
            if (model.cbodymemo != null)
            {
                strSql1.Append("cbodymemo,");
                strSql2.Append("'" + model.cbodymemo + "',");
            }
            if (model.dstartdate != null)
            {
                strSql1.Append("dstartdate,");
                strSql2.Append("'" + model.dstartdate + "',");
            }
            if (model.denddate != null)
            {
                strSql1.Append("denddate,");
                strSql2.Append("'" + model.denddate + "',");
            }
            if (model.cdefine22 != null)
            {
                strSql1.Append("cdefine22,");
                strSql2.Append("'" + model.cdefine22 + "',");
            }
            if (model.cdefine23 != null)
            {
                strSql1.Append("cdefine23,");
                strSql2.Append("'" + model.cdefine23 + "',");
            }
            if (model.cdefine24 != null)
            {
                strSql1.Append("cdefine24,");
                strSql2.Append("'" + model.cdefine24 + "',");
            }
            if (model.cdefine25 != null)
            {
                strSql1.Append("cdefine25,");
                strSql2.Append("'" + model.cdefine25 + "',");
            }
            if (model.cdefine26 != null)
            {
                strSql1.Append("cdefine26,");
                strSql2.Append("" + model.cdefine26 + ",");
            }
            if (model.cdefine27 != null)
            {
                strSql1.Append("cdefine27,");
                strSql2.Append("" + model.cdefine27 + ",");
            }
            if (model.cdefine28 != null)
            {
                strSql1.Append("cdefine28,");
                strSql2.Append("'" + model.cdefine28 + "',");
            }
            if (model.cdefine29 != null)
            {
                strSql1.Append("cdefine29,");
                strSql2.Append("'" + model.cdefine29 + "',");
            }
            if (model.cdefine30 != null)
            {
                strSql1.Append("cdefine30,");
                strSql2.Append("'" + model.cdefine30 + "',");
            }
            if (model.cdefine31 != null)
            {
                strSql1.Append("cdefine31,");
                strSql2.Append("'" + model.cdefine31 + "',");
            }
            if (model.cdefine32 != null)
            {
                strSql1.Append("cdefine32,");
                strSql2.Append("'" + model.cdefine32 + "',");
            }
            if (model.cdefine33 != null)
            {
                strSql1.Append("cdefine33,");
                strSql2.Append("'" + model.cdefine33 + "',");
            }
            if (model.cdefine34 != null)
            {
                strSql1.Append("cdefine34,");
                strSql2.Append("" + model.cdefine34 + ",");
            }
            if (model.cdefine35 != null)
            {
                strSql1.Append("cdefine35,");
                strSql2.Append("" + model.cdefine35 + ",");
            }
            if (model.cdefine36 != null)
            {
                strSql1.Append("cdefine36,");
                strSql2.Append("'" + model.cdefine36 + "',");
            }
            if (model.cdefine37 != null)
            {
                strSql1.Append("cdefine37,");
                strSql2.Append("'" + model.cdefine37 + "',");
            }
            if (model.bsales != null)
            {
                strSql1.Append("bsales,");
                strSql2.Append("" + model.bsales + ",");
            }
            if (model.fminquantity != null)
            {
                strSql1.Append("fminquantity,");
                strSql2.Append("" + model.fminquantity + ",");
            }
            if (model.iUnitPrice != null)
            {
                strSql1.Append("iUnitPrice,");
                strSql2.Append("" + model.iUnitPrice + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.iTaxUnitPrice != null)
            {
                strSql1.Append("iTaxUnitPrice,");
                strSql2.Append("" + model.iTaxUnitPrice + ",");
            }
            if (model.cexch_name != null)
            {
                strSql1.Append("cexch_name,");
                strSql2.Append("'" + model.cexch_name + "',");
            }
            if (model.cTermCode != null)
            {
                strSql1.Append("cTermCode,");
                strSql2.Append("'" + model.cTermCode + "',");
            }
            if (model.ivouchrowno != null)
            {
                strSql1.Append("ivouchrowno,");
                strSql2.Append("" + model.ivouchrowno + ",");
            }
            if (model.ijusttaxprice != null)
            {
                strSql1.Append("ijusttaxprice,");
                strSql2.Append("" + model.ijusttaxprice + ",");
            }
            if (model.cbsysbarcode != null)
            {
                strSql1.Append("cbsysbarcode,");
                strSql2.Append("'" + model.cbsysbarcode + "',");
            }
            if (model.bEndPriceList != null)
            {
                strSql1.Append("bEndPriceList,");
                strSql2.Append("" + model.bEndPriceList + ",");
            }
            strSql.Append("insert into @u8.PU_PriceJustDetail(");
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

