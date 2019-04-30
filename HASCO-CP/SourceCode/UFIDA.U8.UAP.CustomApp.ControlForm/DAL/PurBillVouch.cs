using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:PurBillVouch
    /// </summary>
    public partial class PurBillVouch
    {
        public PurBillVouch()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouch model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.PBVID != null)
            {
                strSql1.Append("PBVID,");
                strSql2.Append("'" + model.PBVID + "',");
            }
            if (model.cPBVBillType != null)
            {
                strSql1.Append("cPBVBillType,");
                strSql2.Append("'" + model.cPBVBillType + "',");
            }
            if (model.cPBVCode != null)
            {
                strSql1.Append("cPBVCode,");
                strSql2.Append("'" + model.cPBVCode + "',");
            }
            if (model.cPTCode != null)
            {
                strSql1.Append("cPTCode,");
                strSql2.Append("'" + model.cPTCode + "',");
            }
            if (model.dPBVDate != null)
            {
                strSql1.Append("dPBVDate,");
                strSql2.Append("'" + model.dPBVDate + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cUnitCode != null)
            {
                strSql1.Append("cUnitCode,");
                strSql2.Append("'" + model.cUnitCode + "',");
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
            if (model.cexch_name != null)
            {
                strSql1.Append("cexch_name,");
                strSql2.Append("'" + model.cexch_name + "',");
            }
            if (model.cExchRate != null)
            {
                strSql1.Append("cExchRate,");
                strSql2.Append("" + model.cExchRate + ",");
            }
            if (model.iPBVTaxRate != null)
            {
                strSql1.Append("iPBVTaxRate,");
                strSql2.Append("" + model.iPBVTaxRate + ",");
            }
            if (model.cPBVMemo != null)
            {
                strSql1.Append("cPBVMemo,");
                strSql2.Append("'" + model.cPBVMemo + "',");
            }
            if (model.cOrderCode != null)
            {
                strSql1.Append("cOrderCode,");
                strSql2.Append("'" + model.cOrderCode + "',");
            }
            if (model.cInCode != null)
            {
                strSql1.Append("cInCode,");
                strSql2.Append("'" + model.cInCode + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.dSDate != null)
            {
                strSql1.Append("dSDate,");
                strSql2.Append("'" + model.dSDate + "',");
            }
            if (model.cPBVMaker != null)
            {
                strSql1.Append("cPBVMaker,");
                strSql2.Append("'" + model.cPBVMaker + "',");
            }
            if (model.cPBVVerifier != null)
            {
                strSql1.Append("cPBVVerifier,");
                strSql2.Append("'" + model.cPBVVerifier + "',");
            }
            if (model.bNegative != null)
            {
                strSql1.Append("bNegative,");
                strSql2.Append("" + (model.bNegative ? 1 : 0) + ",");
            }
            if (model.bOriginal != null)
            {
                strSql1.Append("bOriginal,");
                strSql2.Append("" + (model.bOriginal ? 1 : 0) + ",");
            }
            if (model.bFirst != null)
            {
                strSql1.Append("bFirst,");
                strSql2.Append("" + (model.bFirst ? 1 : 0) + ",");
            }
            if (model.citem_class != null)
            {
                strSql1.Append("citem_class,");
                strSql2.Append("'" + model.citem_class + "',");
            }
            if (model.citemcode != null)
            {
                strSql1.Append("citemcode,");
                strSql2.Append("'" + model.citemcode + "',");
            }
            if (model.cHeadCode != null)
            {
                strSql1.Append("cHeadCode,");
                strSql2.Append("'" + model.cHeadCode + "',");
            }
            if (model.iNetLock != null)
            {
                strSql1.Append("iNetLock,");
                strSql2.Append("" + model.iNetLock + ",");
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
            if (model.bPayment != null)
            {
                strSql1.Append("bPayment,");
                strSql2.Append("'" + model.bPayment + "',");
            }
            if (model.dVouDate != null)
            {
                strSql1.Append("dVouDate,");
                strSql2.Append("'" + model.dVouDate + "',");
            }
            if (model.iVTid != null)
            {
                strSql1.Append("iVTid,");
                strSql2.Append("" + model.iVTid + ",");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
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
            if (model.bIAFirst != null)
            {
                strSql1.Append("bIAFirst,");
                strSql2.Append("" + (model.bIAFirst ? 1 : 0) + ",");
            }
            if (model.iDiscountTaxType != null)
            {
                strSql1.Append("iDiscountTaxType,");
                strSql2.Append("" + model.iDiscountTaxType + ",");
            }
            if (model.cVenPUOMProtocol != null)
            {
                strSql1.Append("cVenPUOMProtocol,");
                strSql2.Append("'" + model.cVenPUOMProtocol + "',");
            }
            if (model.dCreditStart != null)
            {
                strSql1.Append("dCreditStart,");
                strSql2.Append("'" + model.dCreditStart + "',");
            }
            if (model.iCreditPeriod != null)
            {
                strSql1.Append("iCreditPeriod,");
                strSql2.Append("" + model.iCreditPeriod + ",");
            }
            if (model.dGatheringDate != null)
            {
                strSql1.Append("dGatheringDate,");
                strSql2.Append("'" + model.dGatheringDate + "',");
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
            if (model.bCredit != null)
            {
                strSql1.Append("bCredit,");
                strSql2.Append("" + model.bCredit + ",");
            }
            if (model.iBG_OverFlag != null)
            {
                strSql1.Append("iBG_OverFlag,");
                strSql2.Append("" + model.iBG_OverFlag + ",");
            }
            if (model.cBG_Auditor != null)
            {
                strSql1.Append("cBG_Auditor,");
                strSql2.Append("'" + model.cBG_Auditor + "',");
            }
            if (model.cBG_AuditTime != null)
            {
                strSql1.Append("cBG_AuditTime,");
                strSql2.Append("'" + model.cBG_AuditTime + "',");
            }
            if (model.ControlResult != null)
            {
                strSql1.Append("ControlResult,");
                strSql2.Append("" + model.ControlResult + ",");
            }
            if (model.iflowid != null)
            {
                strSql1.Append("iflowid,");
                strSql2.Append("" + model.iflowid + ",");
            }
            if (model.dverifydate != null)
            {
                strSql1.Append("dverifydate,");
                strSql2.Append("'" + model.dverifydate + "',");
            }
            if (model.dverifysystime != null)
            {
                strSql1.Append("dverifysystime,");
                strSql2.Append("'" + model.dverifysystime + "',");
            }
            if (model.cVenAccount != null)
            {
                strSql1.Append("cVenAccount,");
                strSql2.Append("'" + model.cVenAccount + "',");
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
            if (model.cContactCode != null)
            {
                strSql1.Append("cContactCode,");
                strSql2.Append("'" + model.cContactCode + "',");
            }
            if (model.cVenPerson != null)
            {
                strSql1.Append("cVenPerson,");
                strSql2.Append("'" + model.cVenPerson + "',");
            }
            if (model.cVenBank != null)
            {
                strSql1.Append("cVenBank,");
                strSql2.Append("'" + model.cVenBank + "',");
            }
            if (model.cVerifier != null)
            {
                strSql1.Append("cVerifier,");
                strSql2.Append("'" + model.cVerifier + "',");
            }
            if (model.cAuditDate != null)
            {
                strSql1.Append("cAuditDate,");
                strSql2.Append("'" + model.cAuditDate + "',");
            }
            if (model.cAuditTime != null)
            {
                strSql1.Append("cAuditTime,");
                strSql2.Append("'" + model.cAuditTime + "',");
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
            if (model.cmaketime != null)
            {
                strSql1.Append("cmaketime,");
                strSql2.Append("'" + model.cmaketime + "',");
            }
            if (model.cmodifytime != null)
            {
                strSql1.Append("cmodifytime,");
                strSql2.Append("'" + model.cmodifytime + "',");
            }
            strSql.Append("insert into PurBillVouch(");
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

