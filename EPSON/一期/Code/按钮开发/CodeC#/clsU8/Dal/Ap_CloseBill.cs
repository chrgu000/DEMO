using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
{
    /// <summary>
    /// 数据访问类:Ap_CloseBill
    /// </summary>
    public partial class Ap_CloseBill
    {
        public Ap_CloseBill()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.clsU8.Model.Ap_CloseBill model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cVouchType != null)
            {
                strSql1.Append("cVouchType,");
                strSql2.Append("'" + model.cVouchType + "',");
            }
            if (model.cVouchID != null)
            {
                strSql1.Append("cVouchID,");
                strSql2.Append("'" + model.cVouchID + "',");
            }
            if (model.dVouchDate != null)
            {
                strSql1.Append("dVouchDate,");
                strSql2.Append("'" + model.dVouchDate + "',");
            }
            if (model.iPeriod != null)
            {
                strSql1.Append("iPeriod,");
                strSql2.Append("" + model.iPeriod + ",");
            }
            if (model.cDwCode != null)
            {
                strSql1.Append("cDwCode,");
                strSql2.Append("'" + model.cDwCode + "',");
            }
            if (model.cDeptCode != null)
            {
                strSql1.Append("cDeptCode,");
                strSql2.Append("'" + model.cDeptCode + "',");
            }
            if (model.cPerson != null)
            {
                strSql1.Append("cPerson,");
                strSql2.Append("'" + model.cPerson + "',");
            }
            if (model.cItem_Class != null)
            {
                strSql1.Append("cItem_Class,");
                strSql2.Append("'" + model.cItem_Class + "',");
            }
            if (model.cItemCode != null)
            {
                strSql1.Append("cItemCode,");
                strSql2.Append("'" + model.cItemCode + "',");
            }
            if (model.cSSCode != null)
            {
                strSql1.Append("cSSCode,");
                strSql2.Append("'" + model.cSSCode + "',");
            }
            if (model.cNoteNo != null)
            {
                strSql1.Append("cNoteNo,");
                strSql2.Append("'" + model.cNoteNo + "',");
            }
            if (model.cCoVouchType != null)
            {
                strSql1.Append("cCoVouchType,");
                strSql2.Append("'" + model.cCoVouchType + "',");
            }
            if (model.cCoVouchID != null)
            {
                strSql1.Append("cCoVouchID,");
                strSql2.Append("'" + model.cCoVouchID + "',");
            }
            if (model.cDigest != null)
            {
                strSql1.Append("cDigest,");
                strSql2.Append("'" + model.cDigest + "',");
            }
            if (model.cBankAccount != null)
            {
                strSql1.Append("cBankAccount,");
                strSql2.Append("'" + model.cBankAccount + "',");
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
            if (model.iAmount != null)
            {
                strSql1.Append("iAmount,");
                strSql2.Append("" + model.iAmount + ",");
            }
            if (model.iAmount_f != null)
            {
                strSql1.Append("iAmount_f,");
                strSql2.Append("" + model.iAmount_f + ",");
            }
            if (model.iRAmount != null)
            {
                strSql1.Append("iRAmount,");
                strSql2.Append("" + model.iRAmount + ",");
            }
            if (model.iRAmount_f != null)
            {
                strSql1.Append("iRAmount_f,");
                strSql2.Append("" + model.iRAmount_f + ",");
            }
            if (model.cOperator != null)
            {
                strSql1.Append("cOperator,");
                strSql2.Append("'" + model.cOperator + "',");
            }
            if (model.cCancelMan != null)
            {
                strSql1.Append("cCancelMan,");
                strSql2.Append("'" + model.cCancelMan + "',");
            }
            if (model.cRPMan != null)
            {
                strSql1.Append("cRPMan,");
                strSql2.Append("'" + model.cRPMan + "',");
            }
            if (model.bPrePay != null)
            {
                strSql1.Append("bPrePay,");
                strSql2.Append("" + (model.bPrePay ? 1 : 0) + ",");
            }
            if (model.bStartFlag != null)
            {
                strSql1.Append("bStartFlag,");
                strSql2.Append("" + (model.bStartFlag ? 1 : 0) + ",");
            }
            if (model.cOrderNo != null)
            {
                strSql1.Append("cOrderNo,");
                strSql2.Append("'" + model.cOrderNo + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cPreCode != null)
            {
                strSql1.Append("cPreCode,");
                strSql2.Append("'" + model.cPreCode + "',");
            }
            if (model.iPayForOther != null)
            {
                strSql1.Append("iPayForOther,");
                strSql2.Append("" + (model.iPayForOther ? 1 : 0) + ",");
            }
            if (model.cSrcFlag != null)
            {
                strSql1.Append("cSrcFlag,");
                strSql2.Append("'" + model.cSrcFlag + "',");
            }
            if (model.cPzID != null)
            {
                strSql1.Append("cPzID,");
                strSql2.Append("'" + model.cPzID + "',");
            }
            if (model.cFlag != null)
            {
                strSql1.Append("cFlag,");
                strSql2.Append("'" + model.cFlag + "',");
            }
            if (model.bSend != null)
            {
                strSql1.Append("bSend,");
                strSql2.Append("" + (model.bSend ? 1 : 0) + ",");
            }
            if (model.bReceived != null)
            {
                strSql1.Append("bReceived,");
                strSql2.Append("" + (model.bReceived ? 1 : 0) + ",");
            }
            if (model.csItemCode != null)
            {
                strSql1.Append("csItemCode,");
                strSql2.Append("'" + model.csItemCode + "',");
            }
            if (model.iID != null)
            {
                strSql1.Append("iID,");
                strSql2.Append("" + model.iID + ",");
            }
            if (model.cCancelNo != null)
            {
                strSql1.Append("cCancelNo,");
                strSql2.Append("'" + model.cCancelNo + "',");
            }
            if (model.cBank != null)
            {
                strSql1.Append("cBank,");
                strSql2.Append("'" + model.cBank + "',");
            }
            if (model.cNatBank != null)
            {
                strSql1.Append("cNatBank,");
                strSql2.Append("'" + model.cNatBank + "',");
            }
            if (model.cNatBankAccount != null)
            {
                strSql1.Append("cNatBankAccount,");
                strSql2.Append("'" + model.cNatBankAccount + "',");
            }
            if (model.bFromBank != null)
            {
                strSql1.Append("bFromBank,");
                strSql2.Append("" + (model.bFromBank ? 1 : 0) + ",");
            }
            if (model.bToBank != null)
            {
                strSql1.Append("bToBank,");
                strSql2.Append("" + (model.bToBank ? 1 : 0) + ",");
            }
            if (model.bSure != null)
            {
                strSql1.Append("bSure,");
                strSql2.Append("" + (model.bSure ? 1 : 0) + ",");
            }
            if (model.VT_ID != null)
            {
                strSql1.Append("VT_ID,");
                strSql2.Append("" + model.VT_ID + ",");
            }
            if (model.cCheckMan != null)
            {
                strSql1.Append("cCheckMan,");
                strSql2.Append("'" + model.cCheckMan + "',");
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
            if (model.Ufts != null)
            {
                strSql1.Append("Ufts,");
                strSql2.Append("" + model.Ufts + ",");
            }
            if (model.cItemName != null)
            {
                strSql1.Append("cItemName,");
                strSql2.Append("'" + model.cItemName + "',");
            }
            if (model.cContractType != null)
            {
                strSql1.Append("cContractType,");
                strSql2.Append("'" + model.cContractType + "',");
            }
            if (model.cContractID != null)
            {
                strSql1.Append("cContractID,");
                strSql2.Append("'" + model.cContractID + "',");
            }
            if (model.iAmount_s != null)
            {
                strSql1.Append("iAmount_s,");
                strSql2.Append("" + model.iAmount_s + ",");
            }
            if (model.IsWfControlled != null)
            {
                strSql1.Append("IsWfControlled,");
                strSql2.Append("" + (model.IsWfControlled ? 1 : 0) + ",");
            }
            if (model.iSource != null)
            {
                strSql1.Append("iSource,");
                strSql2.Append("" + model.iSource + ",");
            }
            if (model.sDLCode != null)
            {
                strSql1.Append("sDLCode,");
                strSql2.Append("'" + model.sDLCode + "',");
            }
            if (model.RegisterFlag != null)
            {
                strSql1.Append("RegisterFlag,");
                strSql2.Append("" + model.RegisterFlag + ",");
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
            if (model.dcreatesystime != null)
            {
                strSql1.Append("dcreatesystime,");
                strSql2.Append("'" + model.dcreatesystime + "',");
            }
            if (model.dverifysystime != null)
            {
                strSql1.Append("dverifysystime,");
                strSql2.Append("'" + model.dverifysystime + "',");
            }
            if (model.dmodifysystime != null)
            {
                strSql1.Append("dmodifysystime,");
                strSql2.Append("'" + model.dmodifysystime + "',");
            }
            if (model.cmodifier != null)
            {
                strSql1.Append("cmodifier,");
                strSql2.Append("'" + model.cmodifier + "',");
            }
            if (model.dmoddate != null)
            {
                strSql1.Append("dmoddate,");
                strSql2.Append("'" + model.dmoddate + "',");
            }
            if (model.dverifydate != null)
            {
                strSql1.Append("dverifydate,");
                strSql2.Append("'" + model.dverifydate + "',");
            }
            if (model.ibg_overflag != null)
            {
                strSql1.Append("ibg_overflag,");
                strSql2.Append("" + model.ibg_overflag + ",");
            }
            if (model.cbg_auditor != null)
            {
                strSql1.Append("cbg_auditor,");
                strSql2.Append("'" + model.cbg_auditor + "',");
            }
            if (model.cbg_audittime != null)
            {
                strSql1.Append("cbg_audittime,");
                strSql2.Append("'" + model.cbg_audittime + "',");
            }
            if (model.controlresult != null)
            {
                strSql1.Append("controlresult,");
                strSql2.Append("" + model.controlresult + ",");
            }
            if (model.cbg_itemcode != null)
            {
                strSql1.Append("cbg_itemcode,");
                strSql2.Append("'" + model.cbg_itemcode + "',");
            }
            if (model.cbg_itemname != null)
            {
                strSql1.Append("cbg_itemname,");
                strSql2.Append("'" + model.cbg_itemname + "',");
            }
            if (model.cbg_caliberkey1 != null)
            {
                strSql1.Append("cbg_caliberkey1,");
                strSql2.Append("'" + model.cbg_caliberkey1 + "',");
            }
            if (model.cbg_caliberkeyname1 != null)
            {
                strSql1.Append("cbg_caliberkeyname1,");
                strSql2.Append("'" + model.cbg_caliberkeyname1 + "',");
            }
            if (model.cbg_caliberkey2 != null)
            {
                strSql1.Append("cbg_caliberkey2,");
                strSql2.Append("'" + model.cbg_caliberkey2 + "',");
            }
            if (model.cbg_caliberkeyname2 != null)
            {
                strSql1.Append("cbg_caliberkeyname2,");
                strSql2.Append("'" + model.cbg_caliberkeyname2 + "',");
            }
            if (model.cbg_caliberkey3 != null)
            {
                strSql1.Append("cbg_caliberkey3,");
                strSql2.Append("'" + model.cbg_caliberkey3 + "',");
            }
            if (model.cbg_caliberkeyname3 != null)
            {
                strSql1.Append("cbg_caliberkeyname3,");
                strSql2.Append("'" + model.cbg_caliberkeyname3 + "',");
            }
            if (model.cbg_calibercode1 != null)
            {
                strSql1.Append("cbg_calibercode1,");
                strSql2.Append("'" + model.cbg_calibercode1 + "',");
            }
            if (model.cbg_calibername1 != null)
            {
                strSql1.Append("cbg_calibername1,");
                strSql2.Append("'" + model.cbg_calibername1 + "',");
            }
            if (model.cbg_calibercode2 != null)
            {
                strSql1.Append("cbg_calibercode2,");
                strSql2.Append("'" + model.cbg_calibercode2 + "',");
            }
            if (model.cbg_calibername2 != null)
            {
                strSql1.Append("cbg_calibername2,");
                strSql2.Append("'" + model.cbg_calibername2 + "',");
            }
            if (model.cbg_calibercode3 != null)
            {
                strSql1.Append("cbg_calibercode3,");
                strSql2.Append("'" + model.cbg_calibercode3 + "',");
            }
            if (model.cbg_calibername3 != null)
            {
                strSql1.Append("cbg_calibername3,");
                strSql2.Append("'" + model.cbg_calibername3 + "',");
            }
            if (model.ibg_ctrl != null)
            {
                strSql1.Append("ibg_ctrl,");
                strSql2.Append("" + (model.ibg_ctrl ? 1 : 0) + ",");
            }
            if (model.cbg_auditopinion != null)
            {
                strSql1.Append("cbg_auditopinion,");
                strSql2.Append("'" + model.cbg_auditopinion + "',");
            }
            if (model.cApplyCode != null)
            {
                strSql1.Append("cApplyCode,");
                strSql2.Append("'" + model.cApplyCode + "',");
            }
            if (model.cPZNum != null)
            {
                strSql1.Append("cPZNum,");
                strSql2.Append("'" + model.cPZNum + "',");
            }
            if (model.doutbilldate != null)
            {
                strSql1.Append("doutbilldate,");
                strSql2.Append("'" + model.doutbilldate + "',");
            }
            if (model.cbg_caliberkey4 != null)
            {
                strSql1.Append("cbg_caliberkey4,");
                strSql2.Append("'" + model.cbg_caliberkey4 + "',");
            }
            if (model.cbg_caliberkeyname4 != null)
            {
                strSql1.Append("cbg_caliberkeyname4,");
                strSql2.Append("'" + model.cbg_caliberkeyname4 + "',");
            }
            if (model.cbg_caliberkey5 != null)
            {
                strSql1.Append("cbg_caliberkey5,");
                strSql2.Append("'" + model.cbg_caliberkey5 + "',");
            }
            if (model.cbg_caliberkeyname5 != null)
            {
                strSql1.Append("cbg_caliberkeyname5,");
                strSql2.Append("'" + model.cbg_caliberkeyname5 + "',");
            }
            if (model.cbg_caliberkey6 != null)
            {
                strSql1.Append("cbg_caliberkey6,");
                strSql2.Append("'" + model.cbg_caliberkey6 + "',");
            }
            if (model.cbg_caliberkeyname6 != null)
            {
                strSql1.Append("cbg_caliberkeyname6,");
                strSql2.Append("'" + model.cbg_caliberkeyname6 + "',");
            }
            if (model.cbg_calibercode4 != null)
            {
                strSql1.Append("cbg_calibercode4,");
                strSql2.Append("'" + model.cbg_calibercode4 + "',");
            }
            if (model.cbg_calibername4 != null)
            {
                strSql1.Append("cbg_calibername4,");
                strSql2.Append("'" + model.cbg_calibername4 + "',");
            }
            if (model.cbg_calibercode5 != null)
            {
                strSql1.Append("cbg_calibercode5,");
                strSql2.Append("'" + model.cbg_calibercode5 + "',");
            }
            if (model.cbg_calibername5 != null)
            {
                strSql1.Append("cbg_calibername5,");
                strSql2.Append("'" + model.cbg_calibername5 + "',");
            }
            if (model.cbg_calibercode6 != null)
            {
                strSql1.Append("cbg_calibercode6,");
                strSql2.Append("'" + model.cbg_calibercode6 + "',");
            }
            if (model.cbg_calibername6 != null)
            {
                strSql1.Append("cbg_calibername6,");
                strSql2.Append("'" + model.cbg_calibername6 + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.cReserveDeptCode != null)
            {
                strSql1.Append("cReserveDeptCode,");
                strSql2.Append("'" + model.cReserveDeptCode + "',");
            }
            if (model.bDealMode != null)
            {
                strSql1.Append("bDealMode,");
                strSql2.Append("" + (model.bDealMode ? 1 : 0) + ",");
            }
            if (model.iBusType != null)
            {
                strSql1.Append("iBusType,");
                strSql2.Append("" + model.iBusType + ",");
            }
            if (model.iPayType != null)
            {
                strSql1.Append("iPayType,");
                strSql2.Append("" + model.iPayType + ",");
            }
            if (model.cagentcuscode != null)
            {
                strSql1.Append("cagentcuscode,");
                strSql2.Append("'" + model.cagentcuscode + "',");
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
            strSql.Append("insert into Ap_CloseBill(");
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

