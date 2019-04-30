using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:PU_ArrivalVouch
    /// </summary>
    public partial class PU_ArrivalVouch
    {
        public PU_ArrivalVouch()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.PU_ArrivalVouch model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iVTid != null)
            {
                strSql1.Append("iVTid,");
                strSql2.Append("" + model.iVTid + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cPTCode != null)
            {
                strSql1.Append("cPTCode,");
                strSql2.Append("'" + model.cPTCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.cPersonCode != null)
            {
                strSql1.Append("cPersonCode,");
                strSql2.Append("'" + model.cPersonCode + "',");
            }
            if (model.cPayCode != null)
            {
                strSql1.Append("cPayCode,");
                strSql2.Append("'" + model.cPayCode + "',");
            }
            if (model.cSCCode != null)
            {
                strSql1.Append("cSCCode,");
                strSql2.Append("'" + model.cSCCode + "',");
            }
            if (model.cexch_name != null)
            {
                strSql1.Append("cexch_name,");
                strSql2.Append("'" + model.cexch_name + "',");
            }
            if (model.iExchRate != null)
            {
                strSql1.Append("iExchRate,");
                strSql2.Append("" + model.iExchRate + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.bNegative != null)
            {
                strSql1.Append("bNegative,");
                strSql2.Append("" + model.bNegative + ",");
            }
            if (model.cDefine1 != null)
            {
                strSql1.Append("cDefine1,");
                strSql2.Append("'" + model.cDefine1 + "',");
            }
            if (model.cDefine2 != null)
            {
                strSql1.Append("cDefine2,");
                strSql2.Append("'" + model.cDefine2 + "',");
            }
            if (model.cDefine3 != null)
            {
                strSql1.Append("cDefine3,");
                strSql2.Append("'" + model.cDefine3 + "',");
            }
            if (model.cDefine4 != null)
            {
                strSql1.Append("cDefine4,");
                strSql2.Append("'" + model.cDefine4 + "',");
            }
            if (model.cDefine5 != null)
            {
                strSql1.Append("cDefine5,");
                strSql2.Append("" + model.cDefine5 + ",");
            }
            if (model.cDefine6 != null)
            {
                strSql1.Append("cDefine6,");
                strSql2.Append("'" + model.cDefine6 + "',");
            }
            if (model.cDefine7 != null)
            {
                strSql1.Append("cDefine7,");
                strSql2.Append("" + model.cDefine7 + ",");
            }
            if (model.cDefine8 != null)
            {
                strSql1.Append("cDefine8,");
                strSql2.Append("'" + model.cDefine8 + "',");
            }
            if (model.cDefine9 != null)
            {
                strSql1.Append("cDefine9,");
                strSql2.Append("'" + model.cDefine9 + "',");
            }
            if (model.cDefine10 != null)
            {
                strSql1.Append("cDefine10,");
                strSql2.Append("'" + model.cDefine10 + "',");
            }
            if (model.cDefine11 != null)
            {
                strSql1.Append("cDefine11,");
                strSql2.Append("'" + model.cDefine11 + "',");
            }
            if (model.cDefine12 != null)
            {
                strSql1.Append("cDefine12,");
                strSql2.Append("'" + model.cDefine12 + "',");
            }
            if (model.cDefine13 != null)
            {
                strSql1.Append("cDefine13,");
                strSql2.Append("'" + model.cDefine13 + "',");
            }
            if (model.cDefine14 != null)
            {
                strSql1.Append("cDefine14,");
                strSql2.Append("'" + model.cDefine14 + "',");
            }
            if (model.cDefine15 != null)
            {
                strSql1.Append("cDefine15,");
                strSql2.Append("" + model.cDefine15 + ",");
            }
            if (model.cDefine16 != null)
            {
                strSql1.Append("cDefine16,");
                strSql2.Append("" + model.cDefine16 + ",");
            }
            if (model.ccloser != null)
            {
                strSql1.Append("ccloser,");
                strSql2.Append("'" + model.ccloser + "',");
            }
            if (model.iDiscountTaxType != null)
            {
                strSql1.Append("iDiscountTaxType,");
                strSql2.Append("" + model.iDiscountTaxType + ",");
            }
            if (model.iBillType != null)
            {
                strSql1.Append("iBillType,");
                strSql2.Append("" + model.iBillType + ",");
            }
            if (model.cvouchtype != null)
            {
                strSql1.Append("cvouchtype,");
                strSql2.Append("'" + model.cvouchtype + "',");
            }
            if (model.cgeneralordercode != null)
            {
                strSql1.Append("cgeneralordercode,");
                strSql2.Append("'" + model.cgeneralordercode + "',");
            }
            if (model.ctmcode != null)
            {
                strSql1.Append("ctmcode,");
                strSql2.Append("'" + model.ctmcode + "',");
            }
            if (model.cincotermcode != null)
            {
                strSql1.Append("cincotermcode,");
                strSql2.Append("'" + model.cincotermcode + "',");
            }
            if (model.ctransordercode != null)
            {
                strSql1.Append("ctransordercode,");
                strSql2.Append("'" + model.ctransordercode + "',");
            }
            if (model.dportdate != null)
            {
                strSql1.Append("dportdate,");
                strSql2.Append("'" + model.dportdate + "',");
            }
            if (model.csportcode != null)
            {
                strSql1.Append("csportcode,");
                strSql2.Append("'" + model.csportcode + "',");
            }
            if (model.caportcode != null)
            {
                strSql1.Append("caportcode,");
                strSql2.Append("'" + model.caportcode + "',");
            }
            if (model.csvencode != null)
            {
                strSql1.Append("csvencode,");
                strSql2.Append("'" + model.csvencode + "',");
            }
            if (model.carrivalplace != null)
            {
                strSql1.Append("carrivalplace,");
                strSql2.Append("'" + model.carrivalplace + "',");
            }
            if (model.dclosedate != null)
            {
                strSql1.Append("dclosedate,");
                strSql2.Append("'" + model.dclosedate + "',");
            }
            if (model.idec != null)
            {
                strSql1.Append("idec,");
                strSql2.Append("" + model.idec + ",");
            }
            if (model.bcal != null)
            {
                strSql1.Append("bcal,");
                strSql2.Append("" + (model.bcal ? 1 : 0) + ",");
            }
            if (model.guid != null)
            {
                strSql1.Append("guid,");
                strSql2.Append("'" + model.guid + "',");
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
            if (model.iverifystate != null)
            {
                strSql1.Append("iverifystate,");
                strSql2.Append("" + model.iverifystate + ",");
            }
            if (model.cAuditDate != null)
            {
                strSql1.Append("cAuditDate,");
                strSql2.Append("'" + model.cAuditDate + "',");
            }
            if (model.caudittime != null)
            {
                strSql1.Append("caudittime,");
                strSql2.Append("'" + model.caudittime + "',");
            }
            if (model.cverifier != null)
            {
                strSql1.Append("cverifier,");
                strSql2.Append("'" + model.cverifier + "',");
            }
            if (model.iverifystateex != null)
            {
                strSql1.Append("iverifystateex,");
                strSql2.Append("" + model.iverifystateex + ",");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.IsWfControlled != null)
            {
                strSql1.Append("IsWfControlled,");
                strSql2.Append("" + (model.IsWfControlled ? 1 : 0) + ",");
            }
            if (model.cVenPUOMProtocol != null)
            {
                strSql1.Append("cVenPUOMProtocol,");
                strSql2.Append("'" + model.cVenPUOMProtocol + "',");
            }
            if (model.cchanger != null)
            {
                strSql1.Append("cchanger,");
                strSql2.Append("'" + model.cchanger + "',");
            }
            if (model.iflowid != null)
            {
                strSql1.Append("iflowid,");
                strSql2.Append("" + model.iflowid + ",");
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
            if (model.cpocode != null)
            {
                strSql1.Append("cpocode,");
                strSql2.Append("'" + model.cpocode + "',");
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
            strSql.Append("insert into @u8.PU_ArrivalVouch(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1,1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1,1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

