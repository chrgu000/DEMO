using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
{
    /// <summary>
    /// 数据访问类:DispatchList
    /// </summary>
    public partial class DispatchList
    {
        public DispatchList()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.clsU8.Model.DispatchList model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.DLID != null)
            {
                strSql1.Append("DLID,");
                strSql2.Append("" + model.DLID + ",");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("'" + model.cDLCode + "',");
            }
            if (model.cVouchType != null)
            {
                strSql1.Append("cVouchType,");
                strSql2.Append("'" + model.cVouchType + "',");
            }
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cRdCode != null)
            {
                strSql1.Append("cRdCode,");
                strSql2.Append("'" + model.cRdCode + "',");
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
            if (model.SBVID != null)
            {
                strSql1.Append("SBVID,");
                strSql2.Append("" + model.SBVID + ",");
            }
            if (model.cSBVCode != null)
            {
                strSql1.Append("cSBVCode,");
                strSql2.Append("'" + model.cSBVCode + "',");
            }
            if (model.cSOCode != null)
            {
                strSql1.Append("cSOCode,");
                strSql2.Append("'" + model.cSOCode + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
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
            if (model.cShipAddress != null)
            {
                strSql1.Append("cShipAddress,");
                strSql2.Append("'" + model.cShipAddress + "',");
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
            if (model.bFirst != null)
            {
                strSql1.Append("bFirst,");
                strSql2.Append("" + (model.bFirst ? 1 : 0) + ",");
            }
            if (model.bReturnFlag != null)
            {
                strSql1.Append("bReturnFlag,");
                strSql2.Append("" + (model.bReturnFlag ? 1 : 0) + ",");
            }
            if (model.bSettleAll != null)
            {
                strSql1.Append("bSettleAll,");
                strSql2.Append("" + (model.bSettleAll ? 1 : 0) + ",");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.cSaleOut != null)
            {
                strSql1.Append("cSaleOut,");
                strSql2.Append("'" + model.cSaleOut + "',");
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
            if (model.cVerifier != null)
            {
                strSql1.Append("cVerifier,");
                strSql2.Append("'" + model.cVerifier + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.iNetLock != null)
            {
                strSql1.Append("iNetLock,");
                strSql2.Append("" + model.iNetLock + ",");
            }
            if (model.iSale != null)
            {
                strSql1.Append("iSale,");
                strSql2.Append("" + model.iSale + ",");
            }
            if (model.cCusName != null)
            {
                strSql1.Append("cCusName,");
                strSql2.Append("'" + model.cCusName + "',");
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
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.cCloser != null)
            {
                strSql1.Append("cCloser,");
                strSql2.Append("'" + model.cCloser + "',");
            }
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cCreChpName != null)
            {
                strSql1.Append("cCreChpName,");
                strSql2.Append("'" + model.cCreChpName + "',");
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
            if (model.ioutgolden != null)
            {
                strSql1.Append("ioutgolden,");
                strSql2.Append("" + model.ioutgolden + ",");
            }
            if (model.cgatheringplan != null)
            {
                strSql1.Append("cgatheringplan,");
                strSql2.Append("'" + model.cgatheringplan + "',");
            }
            if (model.dCreditStart != null)
            {
                strSql1.Append("dCreditStart,");
                strSql2.Append("'" + model.dCreditStart + "',");
            }
            if (model.dGatheringDate != null)
            {
                strSql1.Append("dGatheringDate,");
                strSql2.Append("'" + model.dGatheringDate + "',");
            }
            if (model.icreditdays != null)
            {
                strSql1.Append("icreditdays,");
                strSql2.Append("" + model.icreditdays + ",");
            }
            if (model.bCredit != null)
            {
                strSql1.Append("bCredit,");
                strSql2.Append("" + (model.bCredit ? 1 : 0) + ",");
            }
            if (model.caddcode != null)
            {
                strSql1.Append("caddcode,");
                strSql2.Append("'" + model.caddcode + "',");
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
                strSql2.Append("" + model.iswfcontrolled + ",");
            }
            if (model.icreditstate != null)
            {
                strSql1.Append("icreditstate,");
                strSql2.Append("'" + model.icreditstate + "',");
            }
            if (model.bARFirst != null)
            {
                strSql1.Append("bARFirst,");
                strSql2.Append("" + (model.bARFirst ? 1 : 0) + ",");
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
            if (model.ccusperson != null)
            {
                strSql1.Append("ccusperson,");
                strSql2.Append("'" + model.ccusperson + "',");
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
            if (model.csvouchtype != null)
            {
                strSql1.Append("csvouchtype,");
                strSql2.Append("'" + model.csvouchtype + "',");
            }
            if (model.iflowid != null)
            {
                strSql1.Append("iflowid,");
                strSql2.Append("" + model.iflowid + ",");
            }
            if (model.bsigncreate != null)
            {
                strSql1.Append("bsigncreate,");
                strSql2.Append("" + (model.bsigncreate ? 1 : 0) + ",");
            }
            if (model.bcashsale != null)
            {
                strSql1.Append("bcashsale,");
                strSql2.Append("" + (model.bcashsale ? 1 : 0) + ",");
            }
            if (model.cgathingcode != null)
            {
                strSql1.Append("cgathingcode,");
                strSql2.Append("'" + model.cgathingcode + "',");
            }
            if (model.cChanger != null)
            {
                strSql1.Append("cChanger,");
                strSql2.Append("'" + model.cChanger + "',");
            }
            if (model.cChangeMemo != null)
            {
                strSql1.Append("cChangeMemo,");
                strSql2.Append("'" + model.cChangeMemo + "',");
            }
            if (model.outid != null)
            {
                strSql1.Append("outid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.bmustbook != null)
            {
                strSql1.Append("bmustbook,");
                strSql2.Append("" + (model.bmustbook ? 1 : 0) + ",");
            }
            if (model.cBookDepcode != null)
            {
                strSql1.Append("cBookDepcode,");
                strSql2.Append("'" + model.cBookDepcode + "',");
            }
            if (model.cBookType != null)
            {
                strSql1.Append("cBookType,");
                strSql2.Append("'" + model.cBookType + "',");
            }
            if (model.bSaUsed != null)
            {
                strSql1.Append("bSaUsed,");
                strSql2.Append("" + (model.bSaUsed ? 1 : 0) + ",");
            }
            if (model.bneedbill != null)
            {
                strSql1.Append("bneedbill,");
                strSql2.Append("" + (model.bneedbill ? 1 : 0) + ",");
            }
            if (model.baccswitchflag != null)
            {
                strSql1.Append("baccswitchflag,");
                strSql2.Append("" + (model.baccswitchflag ? 1 : 0) + ",");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.ccuspersoncode != null)
            {
                strSql1.Append("ccuspersoncode,");
                strSql2.Append("'" + model.ccuspersoncode + "',");
            }
            if (model.cSourceCode != null)
            {
                strSql1.Append("cSourceCode,");
                strSql2.Append("'" + model.cSourceCode + "',");
            }
            if (model.bsaleoutcreatebill != null)
            {
                strSql1.Append("bsaleoutcreatebill,");
                strSql2.Append("" + (model.bsaleoutcreatebill ? 1 : 0) + ",");
            }
            if (model.cSysBarCode != null)
            {
                strSql1.Append("cSysBarCode,");
                strSql2.Append("'" + model.cSysBarCode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            if (model.csscode != null)
            {
                strSql1.Append("csscode,");
                strSql2.Append("'" + model.csscode + "',");
            }
            if (model.cinvoicecompany != null)
            {
                strSql1.Append("cinvoicecompany,");
                strSql2.Append("'" + model.cinvoicecompany + "',");
            }
            if (model.fEBweight != null)
            {
                strSql1.Append("fEBweight,");
                strSql2.Append("" + model.fEBweight + ",");
            }
            if (model.cEBweightUnit != null)
            {
                strSql1.Append("cEBweightUnit,");
                strSql2.Append("'" + model.cEBweightUnit + "',");
            }
            if (model.cEBExpressCode != null)
            {
                strSql1.Append("cEBExpressCode,");
                strSql2.Append("'" + model.cEBExpressCode + "',");
            }
            if (model.iEBExpressCoID != null)
            {
                strSql1.Append("iEBExpressCoID,");
                strSql2.Append("" + model.iEBExpressCoID + ",");
            }
            if (model.SeparateID != null)
            {
                strSql1.Append("SeparateID,");
                strSql2.Append("" + model.SeparateID + ",");
            }
            if (model.bNotToGoldTax != null)
            {
                strSql1.Append("bNotToGoldTax,");
                strSql2.Append("" + model.bNotToGoldTax + ",");
            }
            if (model.cEBTrnumber != null)
            {
                strSql1.Append("cEBTrnumber,");
                strSql2.Append("'" + model.cEBTrnumber + "',");
            }
            if (model.cEBBuyer != null)
            {
                strSql1.Append("cEBBuyer,");
                strSql2.Append("'" + model.cEBBuyer + "',");
            }
            if (model.cEBBuyerNote != null)
            {
                strSql1.Append("cEBBuyerNote,");
                strSql2.Append("'" + model.cEBBuyerNote + "',");
            }
            if (model.ccontactname != null)
            {
                strSql1.Append("ccontactname,");
                strSql2.Append("'" + model.ccontactname + "',");
            }
            if (model.cEBprovince != null)
            {
                strSql1.Append("cEBprovince,");
                strSql2.Append("'" + model.cEBprovince + "',");
            }
            if (model.cEBcity != null)
            {
                strSql1.Append("cEBcity,");
                strSql2.Append("'" + model.cEBcity + "',");
            }
            if (model.cEBdistrict != null)
            {
                strSql1.Append("cEBdistrict,");
                strSql2.Append("'" + model.cEBdistrict + "',");
            }
            if (model.cmobilephone != null)
            {
                strSql1.Append("cmobilephone,");
                strSql2.Append("'" + model.cmobilephone + "',");
            }
            if (model.cInvoiceCusName != null)
            {
                strSql1.Append("cInvoiceCusName,");
                strSql2.Append("'" + model.cInvoiceCusName + "',");
            }
            if (model.cweighter != null)
            {
                strSql1.Append("cweighter,");
                strSql2.Append("'" + model.cweighter + "',");
            }
            if (model.dweighttime != null)
            {
                strSql1.Append("dweighttime,");
                strSql2.Append("'" + model.dweighttime + "',");
            }
            if (model.cPickVouchCode != null)
            {
                strSql1.Append("cPickVouchCode,");
                strSql2.Append("'" + model.cPickVouchCode + "',");
            }
            strSql.Append("insert into DispatchList(");
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

