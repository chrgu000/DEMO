using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:SaleBillVouchs
    /// </summary>
    public partial class SaleBillVouchs
    {
        public SaleBillVouchs()
        { }
        #region  Method
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(Model.SaleBillVouchs model)
		{
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.SBVID != null)
            {
                strSql1.Append("SBVID,");
                strSql2.Append("" + model.SBVID + ",");
            }
            if (model.AutoID != null)
            {
                strSql1.Append("AutoID,");
                strSql2.Append("" + model.AutoID + ",");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
            }
            if (model.iNum != null)
            {
                strSql1.Append("iNum,");
                strSql2.Append("" + model.iNum + ",");
            }
            if (model.iQuotedPrice != null)
            {
                strSql1.Append("iQuotedPrice,");
                strSql2.Append("" + model.iQuotedPrice + ",");
            }
            if (model.iUnitPrice != null)
            {
                strSql1.Append("iUnitPrice,");
                strSql2.Append("" + model.iUnitPrice + ",");
            }
            if (model.iTaxUnitPrice != null)
            {
                strSql1.Append("iTaxUnitPrice,");
                strSql2.Append("" + model.iTaxUnitPrice + ",");
            }
            if (model.iMoney != null)
            {
                strSql1.Append("iMoney,");
                strSql2.Append("" + model.iMoney + ",");
            }
            if (model.iTax != null)
            {
                strSql1.Append("iTax,");
                strSql2.Append("" + model.iTax + ",");
            }
            if (model.iSum != null)
            {
                strSql1.Append("iSum,");
                strSql2.Append("" + model.iSum + ",");
            }
            if (model.iDisCount != null)
            {
                strSql1.Append("iDisCount,");
                strSql2.Append("" + model.iDisCount + ",");
            }
            if (model.iNatUnitPrice != null)
            {
                strSql1.Append("iNatUnitPrice,");
                strSql2.Append("" + model.iNatUnitPrice + ",");
            }
            if (model.iNatMoney != null)
            {
                strSql1.Append("iNatMoney,");
                strSql2.Append("" + model.iNatMoney + ",");
            }
            if (model.iNatTax != null)
            {
                strSql1.Append("iNatTax,");
                strSql2.Append("" + model.iNatTax + ",");
            }
            if (model.iNatSum != null)
            {
                strSql1.Append("iNatSum,");
                strSql2.Append("" + model.iNatSum + ",");
            }
            if (model.iNatDisCount != null)
            {
                strSql1.Append("iNatDisCount,");
                strSql2.Append("" + model.iNatDisCount + ",");
            }
            if (model.iSBVID != null)
            {
                strSql1.Append("iSBVID,");
                strSql2.Append("" + model.iSBVID + ",");
            }
            if (model.iMoneySum != null)
            {
                strSql1.Append("iMoneySum,");
                strSql2.Append("" + model.iMoneySum + ",");
            }
            if (model.iExchSum != null)
            {
                strSql1.Append("iExchSum,");
                strSql2.Append("" + model.iExchSum + ",");
            }
            if (model.cClue != null)
            {
                strSql1.Append("cClue,");
                strSql2.Append("'" + model.cClue + "',");
            }
            if (model.cIncomeSub != null)
            {
                strSql1.Append("cIncomeSub,");
                strSql2.Append("'" + model.cIncomeSub + "',");
            }
            if (model.cTaxSub != null)
            {
                strSql1.Append("cTaxSub,");
                strSql2.Append("'" + model.cTaxSub + "',");
            }
            if (model.dSignDate != null)
            {
                strSql1.Append("dSignDate,");
                strSql2.Append("'" + model.dSignDate + "',");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.iBatch != null)
            {
                strSql1.Append("iBatch,");
                strSql2.Append("" + model.iBatch + ",");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
            }
            if (model.bSettleAll != null)
            {
                strSql1.Append("bSettleAll,");
                strSql2.Append("" + (model.bSettleAll ? 1 : 0) + ",");
            }
            if (model.cFree1 != null)
            {
                strSql1.Append("cFree1,");
                strSql2.Append("'" + model.cFree1 + "',");
            }
            if (model.cFree2 != null)
            {
                strSql1.Append("cFree2,");
                strSql2.Append("'" + model.cFree2 + "',");
            }
            if (model.RdsID != null)
            {
                strSql1.Append("RdsID,");
                strSql2.Append("" + model.RdsID + ",");
            }
            if (model.iTB != null)
            {
                strSql1.Append("iTB,");
                strSql2.Append("" + model.iTB + ",");
            }
            if (model.dvDate != null)
            {
                strSql1.Append("dvDate,");
                strSql2.Append("'" + model.dvDate + "',");
            }
            if (model.TBQuantity != null)
            {
                strSql1.Append("TBQuantity,");
                strSql2.Append("" + model.TBQuantity + ",");
            }
            if (model.TBNum != null)
            {
                strSql1.Append("TBNum,");
                strSql2.Append("" + model.TBNum + ",");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.iDLsID != null)
            {
                strSql1.Append("iDLsID,");
                strSql2.Append("" + model.iDLsID + ",");
            }
            if (model.KL != null)
            {
                strSql1.Append("KL,");
                strSql2.Append("" + model.KL + ",");
            }
            if (model.KL2 != null)
            {
                strSql1.Append("KL2,");
                strSql2.Append("" + model.KL2 + ",");
            }
            if (model.cInvName != null)
            {
                strSql1.Append("cInvName,");
                strSql2.Append("'" + model.cInvName + "',");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.cDefine22 != null)
            {
                strSql1.Append("cDefine22,");
                strSql2.Append("'" + model.cDefine22 + "',");
            }
            if (model.cDefine23 != null)
            {
                strSql1.Append("cDefine23,");
                strSql2.Append("'" + model.cDefine23 + "',");
            }
            if (model.cDefine24 != null)
            {
                strSql1.Append("cDefine24,");
                strSql2.Append("'" + model.cDefine24 + "',");
            }
            if (model.cDefine25 != null)
            {
                strSql1.Append("cDefine25,");
                strSql2.Append("'" + model.cDefine25 + "',");
            }
            if (model.cDefine26 != null)
            {
                strSql1.Append("cDefine26,");
                strSql2.Append("" + model.cDefine26 + ",");
            }
            if (model.cDefine27 != null)
            {
                strSql1.Append("cDefine27,");
                strSql2.Append("" + model.cDefine27 + ",");
            }
            if (model.fOutQuantity != null)
            {
                strSql1.Append("fOutQuantity,");
                strSql2.Append("" + model.fOutQuantity + ",");
            }
            if (model.fOutNum != null)
            {
                strSql1.Append("fOutNum,");
                strSql2.Append("" + model.fOutNum + ",");
            }
            if (model.cItemCode != null)
            {
                strSql1.Append("cItemCode,");
                strSql2.Append("'" + model.cItemCode + "',");
            }
            if (model.cItem_class != null)
            {
                strSql1.Append("cItem_class,");
                strSql2.Append("'" + model.cItem_class + "',");
            }
            if (model.fSaleCost != null)
            {
                strSql1.Append("fSaleCost,");
                strSql2.Append("" + model.fSaleCost + ",");
            }
            if (model.fSalePrice != null)
            {
                strSql1.Append("fSalePrice,");
                strSql2.Append("" + model.fSalePrice + ",");
            }
            if (model.cItemName != null)
            {
                strSql1.Append("cItemName,");
                strSql2.Append("'" + model.cItemName + "',");
            }
            if (model.cItem_CName != null)
            {
                strSql1.Append("cItem_CName,");
                strSql2.Append("'" + model.cItem_CName + "',");
            }
            if (model.cFree3 != null)
            {
                strSql1.Append("cFree3,");
                strSql2.Append("'" + model.cFree3 + "',");
            }
            if (model.cFree4 != null)
            {
                strSql1.Append("cFree4,");
                strSql2.Append("'" + model.cFree4 + "',");
            }
            if (model.cFree5 != null)
            {
                strSql1.Append("cFree5,");
                strSql2.Append("'" + model.cFree5 + "',");
            }
            if (model.cFree6 != null)
            {
                strSql1.Append("cFree6,");
                strSql2.Append("'" + model.cFree6 + "',");
            }
            if (model.cFree7 != null)
            {
                strSql1.Append("cFree7,");
                strSql2.Append("'" + model.cFree7 + "',");
            }
            if (model.cFree8 != null)
            {
                strSql1.Append("cFree8,");
                strSql2.Append("'" + model.cFree8 + "',");
            }
            if (model.cFree9 != null)
            {
                strSql1.Append("cFree9,");
                strSql2.Append("'" + model.cFree9 + "',");
            }
            if (model.cFree10 != null)
            {
                strSql1.Append("cFree10,");
                strSql2.Append("'" + model.cFree10 + "',");
            }
            if (model.iInvExchRate != null)
            {
                strSql1.Append("iInvExchRate,");
                strSql2.Append("" + model.iInvExchRate + ",");
            }
            if (model.cUnitID != null)
            {
                strSql1.Append("cUnitID,");
                strSql2.Append("'" + model.cUnitID + "',");
            }
            if (model.cDefine28 != null)
            {
                strSql1.Append("cDefine28,");
                strSql2.Append("'" + model.cDefine28 + "',");
            }
            if (model.cDefine29 != null)
            {
                strSql1.Append("cDefine29,");
                strSql2.Append("'" + model.cDefine29 + "',");
            }
            if (model.cDefine30 != null)
            {
                strSql1.Append("cDefine30,");
                strSql2.Append("'" + model.cDefine30 + "',");
            }
            if (model.cDefine31 != null)
            {
                strSql1.Append("cDefine31,");
                strSql2.Append("'" + model.cDefine31 + "',");
            }
            if (model.cDefine32 != null)
            {
                strSql1.Append("cDefine32,");
                strSql2.Append("'" + model.cDefine32 + "',");
            }
            if (model.cDefine33 != null)
            {
                strSql1.Append("cDefine33,");
                strSql2.Append("'" + model.cDefine33 + "',");
            }
            if (model.cDefine34 != null)
            {
                strSql1.Append("cDefine34,");
                strSql2.Append("" + model.cDefine34 + ",");
            }
            if (model.cDefine35 != null)
            {
                strSql1.Append("cDefine35,");
                strSql2.Append("" + model.cDefine35 + ",");
            }
            if (model.cDefine36 != null)
            {
                strSql1.Append("cDefine36,");
                strSql2.Append("'" + model.cDefine36 + "',");
            }
            if (model.cDefine37 != null)
            {
                strSql1.Append("cDefine37,");
                strSql2.Append("'" + model.cDefine37 + "',");
            }
            if (model.dMDate != null)
            {
                strSql1.Append("dMDate,");
                strSql2.Append("'" + model.dMDate + "',");
            }
            if (model.iPBVsID != null)
            {
                strSql1.Append("iPBVsID,");
                strSql2.Append("" + model.iPBVsID + ",");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cSoCode != null)
            {
                strSql1.Append("cSoCode,");
                strSql2.Append("'" + model.cSoCode + "',");
            }
            if (model.bgsp != null)
            {
                strSql1.Append("bgsp,");
                strSql2.Append("" + (model.bgsp ? 1 : 0) + ",");
            }
            if (model.iPPartSeqID != null)
            {
                strSql1.Append("iPPartSeqID,");
                strSql2.Append("" + model.iPPartSeqID + ",");
            }
            if (model.iPPartID != null)
            {
                strSql1.Append("iPPartID,");
                strSql2.Append("" + model.iPPartID + ",");
            }
            if (model.iPPartQty != null)
            {
                strSql1.Append("iPPartQty,");
                strSql2.Append("" + model.iPPartQty + ",");
            }
            if (model.cContractID != null)
            {
                strSql1.Append("cContractID,");
                strSql2.Append("'" + model.cContractID + "',");
            }
            if (model.cContractTagCode != null)
            {
                strSql1.Append("cContractTagCode,");
                strSql2.Append("'" + model.cContractTagCode + "',");
            }
            if (model.cContractRowGuid != null)
            {
                strSql1.Append("cContractRowGuid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.iMassDate != null)
            {
                strSql1.Append("iMassDate,");
                strSql2.Append("" + model.iMassDate + ",");
            }
            if (model.cMassUnit != null)
            {
                strSql1.Append("cMassUnit,");
                strSql2.Append("" + model.cMassUnit + ",");
            }
            if (model.bQANeedCheck != null)
            {
                strSql1.Append("bQANeedCheck,");
                strSql2.Append("" + (model.bQANeedCheck ? 1 : 0) + ",");
            }
            if (model.bQAUrgency != null)
            {
                strSql1.Append("bQAUrgency,");
                strSql2.Append("" + (model.bQAUrgency ? 1 : 0) + ",");
            }
            if (model.cCusInvCode != null)
            {
                strSql1.Append("cCusInvCode,");
                strSql2.Append("'" + model.cCusInvCode + "',");
            }
            if (model.cCusInvName != null)
            {
                strSql1.Append("cCusInvName,");
                strSql2.Append("'" + model.cCusInvName + "',");
            }
            if (model.cbaccounter != null)
            {
                strSql1.Append("cbaccounter,");
                strSql2.Append("'" + model.cbaccounter + "',");
            }
            if (model.bcosting != null)
            {
                strSql1.Append("bcosting,");
                strSql2.Append("" + (model.bcosting ? 1 : 0) + ",");
            }
            if (model.cordercode != null)
            {
                strSql1.Append("cordercode,");
                strSql2.Append("'" + model.cordercode + "',");
            }
            if (model.iorderrowno != null)
            {
                strSql1.Append("iorderrowno,");
                strSql2.Append("" + model.iorderrowno + ",");
            }
            if (model.fcusminprice != null)
            {
                strSql1.Append("fcusminprice,");
                strSql2.Append("" + model.fcusminprice + ",");
            }
            if (model.cvmivencode != null)
            {
                strSql1.Append("cvmivencode,");
                strSql2.Append("'" + model.cvmivencode + "',");
            }
            if (model.cVenAbbName != null)
            {
                strSql1.Append("cVenAbbName,");
                strSql2.Append("'" + model.cVenAbbName + "',");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
            }
            if (model.iExpiratDateCalcu != null)
            {
                strSql1.Append("iExpiratDateCalcu,");
                strSql2.Append("" + model.iExpiratDateCalcu + ",");
            }
            if (model.dExpirationdate != null)
            {
                strSql1.Append("dExpirationdate,");
                strSql2.Append("'" + model.dExpirationdate + "',");
            }
            if (model.cExpirationdate != null)
            {
                strSql1.Append("cExpirationdate,");
                strSql2.Append("'" + model.cExpirationdate + "',");
            }
            if (model.cbatchproperty1 != null)
            {
                strSql1.Append("cbatchproperty1,");
                strSql2.Append("" + model.cbatchproperty1 + ",");
            }
            if (model.cbatchproperty2 != null)
            {
                strSql1.Append("cbatchproperty2,");
                strSql2.Append("" + model.cbatchproperty2 + ",");
            }
            if (model.cbatchproperty3 != null)
            {
                strSql1.Append("cbatchproperty3,");
                strSql2.Append("" + model.cbatchproperty3 + ",");
            }
            if (model.cbatchproperty4 != null)
            {
                strSql1.Append("cbatchproperty4,");
                strSql2.Append("" + model.cbatchproperty4 + ",");
            }
            if (model.cbatchproperty5 != null)
            {
                strSql1.Append("cbatchproperty5,");
                strSql2.Append("" + model.cbatchproperty5 + ",");
            }
            if (model.cbatchproperty6 != null)
            {
                strSql1.Append("cbatchproperty6,");
                strSql2.Append("'" + model.cbatchproperty6 + "',");
            }
            if (model.cbatchproperty7 != null)
            {
                strSql1.Append("cbatchproperty7,");
                strSql2.Append("'" + model.cbatchproperty7 + "',");
            }
            if (model.cbatchproperty8 != null)
            {
                strSql1.Append("cbatchproperty8,");
                strSql2.Append("'" + model.cbatchproperty8 + "',");
            }
            if (model.cbatchproperty9 != null)
            {
                strSql1.Append("cbatchproperty9,");
                strSql2.Append("'" + model.cbatchproperty9 + "',");
            }
            if (model.cbatchproperty10 != null)
            {
                strSql1.Append("cbatchproperty10,");
                strSql2.Append("'" + model.cbatchproperty10 + "',");
            }
            if (model.idemandtype != null)
            {
                strSql1.Append("idemandtype,");
                strSql2.Append("" + model.idemandtype + ",");
            }
            if (model.cdemandcode != null)
            {
                strSql1.Append("cdemandcode,");
                strSql2.Append("'" + model.cdemandcode + "',");
            }
            if (model.cdemandmemo != null)
            {
                strSql1.Append("cdemandmemo,");
                strSql2.Append("'" + model.cdemandmemo + "',");
            }
            if (model.cdemandid != null)
            {
                strSql1.Append("cdemandid,");
                strSql2.Append("'" + model.cdemandid + "',");
            }
            if (model.idemandseq != null)
            {
                strSql1.Append("idemandseq,");
                strSql2.Append("" + model.idemandseq + ",");
            }
            if (model.cbdlcode != null)
            {
                strSql1.Append("cbdlcode,");
                strSql2.Append("'" + model.cbdlcode + "',");
            }
            if (model.iInvSNCount != null)
            {
                strSql1.Append("iInvSNCount,");
                strSql2.Append("" + model.iInvSNCount + ",");
            }
            if (model.cInvSN != null)
            {
                strSql1.Append("cInvSN,");
                strSql2.Append("'" + model.cInvSN + "',");
            }
            if (model.cReasonCode != null)
            {
                strSql1.Append("cReasonCode,");
                strSql2.Append("'" + model.cReasonCode + "',");
            }
            if (model.cvencode != null)
            {
                strSql1.Append("cvencode,");
                strSql2.Append("'" + model.cvencode + "',");
            }
            if (model.bneedsign != null)
            {
                strSql1.Append("bneedsign,");
                strSql2.Append("" + (model.bneedsign ? 1 : 0) + ",");
            }
            if (model.cgathingcode != null)
            {
                strSql1.Append("cgathingcode,");
                strSql2.Append("'" + model.cgathingcode + "',");
            }
            if (model.ftaxpasum != null)
            {
                strSql1.Append("ftaxpasum,");
                strSql2.Append("" + model.ftaxpasum + ",");
            }
            if (model.fpasum != null)
            {
                strSql1.Append("fpasum,");
                strSql2.Append("" + model.fpasum + ",");
            }
            if (model.fnattaxpasum != null)
            {
                strSql1.Append("fnattaxpasum,");
                strSql2.Append("" + model.fnattaxpasum + ",");
            }
            if (model.fnatpasum != null)
            {
                strSql1.Append("fnatpasum,");
                strSql2.Append("" + model.fnatpasum + ",");
            }
            if (model.body_outid != null)
            {
                strSql1.Append("body_outid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.cPZNum != null)
            {
                strSql1.Append("cPZNum,");
                strSql2.Append("'" + model.cPZNum + "',");
            }
            if (model.cInVouchType != null)
            {
                strSql1.Append("cInVouchType,");
                strSql2.Append("'" + model.cInVouchType + "',");
            }
            if (model.cBookWhcode != null)
            {
                strSql1.Append("cBookWhcode,");
                strSql2.Append("'" + model.cBookWhcode + "',");
            }
            if (model.icostquantity != null)
            {
                strSql1.Append("icostquantity,");
                strSql2.Append("" + model.icostquantity + ",");
            }
            if (model.icostsum != null)
            {
                strSql1.Append("icostsum,");
                strSql2.Append("" + model.icostsum + ",");
            }
            if (model.cPosition != null)
            {
                strSql1.Append("cPosition,");
                strSql2.Append("'" + model.cPosition + "',");
            }
            if (model.dkeepdate != null)
            {
                strSql1.Append("dkeepdate,");
                strSql2.Append("'" + model.dkeepdate + "',");
            }
            if (model.isaleoutid != null)
            {
                strSql1.Append("isaleoutid,");
                strSql2.Append("" + model.isaleoutid + ",");
            }
            if (model.bsaleprice != null)
            {
                strSql1.Append("bsaleprice,");
                strSql2.Append("" + (model.bsaleprice ? 1 : 0) + ",");
            }
            if (model.bgift != null)
            {
                strSql1.Append("bgift,");
                strSql2.Append("" + (model.bgift ? 1 : 0) + ",");
            }
            if (model.cbsaleout != null)
            {
                strSql1.Append("cbsaleout,");
                strSql2.Append("'" + model.cbsaleout + "',");
            }
            if (model.bmpforderclosed != null)
            {
                strSql1.Append("bmpforderclosed,");
                strSql2.Append("" + (model.bmpforderclosed ? 1 : 0) + ",");
            }
            if (model.cbSysBarCode != null)
            {
                strSql1.Append("cbSysBarCode,");
                strSql2.Append("'" + model.cbSysBarCode + "',");
            }
            strSql.Append("insert into SaleBillVouchs(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
			return strSql.ToString();
		}
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
    }
}

