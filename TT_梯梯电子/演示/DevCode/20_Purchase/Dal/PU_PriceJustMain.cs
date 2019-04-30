using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Purchase.DAL
{
    /// <summary>
    /// 数据访问类:PU_PriceJustMain
    /// </summary>
    public partial class PU_PriceJustMain
    {
        public PU_PriceJustMain()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Purchase.Model.PU_PriceJustMain model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.id != null)
            {
                strSql1.Append("id,");
                strSql2.Append("" + model.id + ",");
            }
            if (model.ddate != null)
            {
                strSql1.Append("ddate,");
                strSql2.Append("'" + model.ddate + "',");
            }
            if (model.ccode != null)
            {
                strSql1.Append("ccode,");
                strSql2.Append("'" + model.ccode + "',");
            }
            if (model.cmaker != null)
            {
                strSql1.Append("cmaker,");
                strSql2.Append("'" + model.cmaker + "',");
            }
            if (model.cpersoncode != null)
            {
                strSql1.Append("cpersoncode,");
                strSql2.Append("'" + model.cpersoncode + "',");
            }
            if (model.cmainmemo != null)
            {
                strSql1.Append("cmainmemo,");
                strSql2.Append("'" + model.cmainmemo + "',");
            }
            if (model.cverifier != null)
            {
                strSql1.Append("cverifier,");
                strSql2.Append("'" + model.cverifier + "',");
            }
            if (model.dverifydate != null)
            {
                strSql1.Append("dverifydate,");
                strSql2.Append("'" + model.dverifydate + "',");
            }
            if (model.cdepcode != null)
            {
                strSql1.Append("cdepcode,");
                strSql2.Append("'" + model.cdepcode + "',");
            }
            if (model.ivtid != null)
            {
                strSql1.Append("ivtid,");
                strSql2.Append("" + model.ivtid + ",");
            }
            if (model.cdefine1 != null)
            {
                strSql1.Append("cdefine1,");
                strSql2.Append("'" + model.cdefine1 + "',");
            }
            if (model.cdefine2 != null)
            {
                strSql1.Append("cdefine2,");
                strSql2.Append("'" + model.cdefine2 + "',");
            }
            if (model.cdefine3 != null)
            {
                strSql1.Append("cdefine3,");
                strSql2.Append("'" + model.cdefine3 + "',");
            }
            if (model.cdefine4 != null)
            {
                strSql1.Append("cdefine4,");
                strSql2.Append("'" + model.cdefine4 + "',");
            }
            if (model.cdefine5 != null)
            {
                strSql1.Append("cdefine5,");
                strSql2.Append("" + model.cdefine5 + ",");
            }
            if (model.cdefine6 != null)
            {
                strSql1.Append("cdefine6,");
                strSql2.Append("'" + model.cdefine6 + "',");
            }
            if (model.cdefine7 != null)
            {
                strSql1.Append("cdefine7,");
                strSql2.Append("" + model.cdefine7 + ",");
            }
            if (model.cdefine8 != null)
            {
                strSql1.Append("cdefine8,");
                strSql2.Append("'" + model.cdefine8 + "',");
            }
            if (model.cdefine9 != null)
            {
                strSql1.Append("cdefine9,");
                strSql2.Append("'" + model.cdefine9 + "',");
            }
            if (model.cdefine10 != null)
            {
                strSql1.Append("cdefine10,");
                strSql2.Append("'" + model.cdefine10 + "',");
            }
            if (model.cdefine11 != null)
            {
                strSql1.Append("cdefine11,");
                strSql2.Append("'" + model.cdefine11 + "',");
            }
            if (model.cdefine12 != null)
            {
                strSql1.Append("cdefine12,");
                strSql2.Append("'" + model.cdefine12 + "',");
            }
            if (model.cdefine13 != null)
            {
                strSql1.Append("cdefine13,");
                strSql2.Append("'" + model.cdefine13 + "',");
            }
            if (model.cdefine14 != null)
            {
                strSql1.Append("cdefine14,");
                strSql2.Append("'" + model.cdefine14 + "',");
            }
            if (model.cdefine15 != null)
            {
                strSql1.Append("cdefine15,");
                strSql2.Append("" + model.cdefine15 + ",");
            }
            if (model.cdefine16 != null)
            {
                strSql1.Append("cdefine16,");
                strSql2.Append("" + model.cdefine16 + ",");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.iverifystate != null)
            {
                strSql1.Append("iverifystate,");
                strSql2.Append("" + model.iverifystate + ",");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.iswfcontrolled != null)
            {
                strSql1.Append("iswfcontrolled,");
                strSql2.Append("" + (model.iswfcontrolled ? 1 : 0) + ",");
            }
            if (model.bTaxCost != null)
            {
                strSql1.Append("bTaxCost,");
                strSql2.Append("" + model.bTaxCost + ",");
            }
            if (model.iSupplyType != null)
            {
                strSql1.Append("iSupplyType,");
                strSql2.Append("" + model.iSupplyType + ",");
            }
            if (model.cMakeTime != null)
            {
                strSql1.Append("cMakeTime,");
                strSql2.Append("'" + model.cMakeTime + "',");
            }
            if (model.cModifyTime != null)
            {
                strSql1.Append("cModifyTime,");
                strSql2.Append("'" + model.cModifyTime + "',");
            }
            if (model.cAuditTime != null)
            {
                strSql1.Append("cAuditTime,");
                strSql2.Append("'" + model.cAuditTime + "',");
            }
            if (model.cModifyDate != null)
            {
                strSql1.Append("cModifyDate,");
                strSql2.Append("'" + model.cModifyDate + "',");
            }
            if (model.cReviser != null)
            {
                strSql1.Append("cReviser,");
                strSql2.Append("'" + model.cReviser + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.ccleanver != null)
            {
                strSql1.Append("ccleanver,");
                strSql2.Append("'" + model.ccleanver + "',");
            }
            if (model.csysbarcode != null)
            {
                strSql1.Append("csysbarcode,");
                strSql2.Append("'" + model.csysbarcode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            strSql.Append("insert into @u8.PU_PriceJustMain(");
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

