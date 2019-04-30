using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
{
    /// <summary>
    /// 数据访问类:DispatchLists
    /// </summary>
    public partial class DispatchLists
    {
        public DispatchLists()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.clsU8.Model.DispatchLists model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.DLID != null)
            {
                strSql1.Append("DLID,");
                strSql2.Append("" + model.DLID + ",");
            }
            if (model.iCorID != null)
            {
                strSql1.Append("iCorID,");
                strSql2.Append("" + model.iCorID + ",");
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
            if (model.iSettleNum != null)
            {
                strSql1.Append("iSettleNum,");
                strSql2.Append("" + model.iSettleNum + ",");
            }
            if (model.iSettleQuantity != null)
            {
                strSql1.Append("iSettleQuantity,");
                strSql2.Append("" + model.iSettleQuantity + ",");
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
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
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
            if (model.cVenAbbName != null)
            {
                strSql1.Append("cVenAbbName,");
                strSql2.Append("'" + model.cVenAbbName + "',");
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
            if (model.bIsSTQc != null)
            {
                strSql1.Append("bIsSTQc,");
                strSql2.Append("" + (model.bIsSTQc ? 1 : 0) + ",");
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
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.iRetQuantity != null)
            {
                strSql1.Append("iRetQuantity,");
                strSql2.Append("" + model.iRetQuantity + ",");
            }
            if (model.fEnSettleQuan != null)
            {
                strSql1.Append("fEnSettleQuan,");
                strSql2.Append("" + model.fEnSettleQuan + ",");
            }
            if (model.fEnSettleSum != null)
            {
                strSql1.Append("fEnSettleSum,");
                strSql2.Append("" + model.fEnSettleSum + ",");
            }
            if (model.iSettlePrice != null)
            {
                strSql1.Append("iSettlePrice,");
                strSql2.Append("" + model.iSettlePrice + ",");
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
            if (model.bGsp != null)
            {
                strSql1.Append("bGsp,");
                strSql2.Append("" + (model.bGsp ? 1 : 0) + ",");
            }
            if (model.cGspState != null)
            {
                strSql1.Append("cGspState,");
                strSql2.Append("'" + model.cGspState + "',");
            }
            if (model.cSoCode != null)
            {
                strSql1.Append("cSoCode,");
                strSql2.Append("'" + model.cSoCode + "',");
            }
            if (model.cCorCode != null)
            {
                strSql1.Append("cCorCode,");
                strSql2.Append("'" + model.cCorCode + "',");
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
            if (model.bQAChecking != null)
            {
                strSql1.Append("bQAChecking,");
                strSql2.Append("" + (model.bQAChecking ? 1 : 0) + ",");
            }
            if (model.bQAChecked != null)
            {
                strSql1.Append("bQAChecked,");
                strSql2.Append("" + (model.bQAChecked ? 1 : 0) + ",");
            }
            if (model.iQAQuantity != null)
            {
                strSql1.Append("iQAQuantity,");
                strSql2.Append("" + model.iQAQuantity + ",");
            }
            if (model.iQANum != null)
            {
                strSql1.Append("iQANum,");
                strSql2.Append("" + model.iQANum + ",");
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
            if (model.fsumsignquantity != null)
            {
                strSql1.Append("fsumsignquantity,");
                strSql2.Append("" + model.fsumsignquantity + ",");
            }
            if (model.fsumsignnum != null)
            {
                strSql1.Append("fsumsignnum,");
                strSql2.Append("" + model.fsumsignnum + ",");
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
            if (model.ispecialtype != null)
            {
                strSql1.Append("ispecialtype,");
                strSql2.Append("" + model.ispecialtype + ",");
            }
            if (model.cvmivencode != null)
            {
                strSql1.Append("cvmivencode,");
                strSql2.Append("'" + model.cvmivencode + "',");
            }
            if (model.iexchsum != null)
            {
                strSql1.Append("iexchsum,");
                strSql2.Append("" + model.iexchsum + ",");
            }
            if (model.imoneysum != null)
            {
                strSql1.Append("imoneysum,");
                strSql2.Append("" + model.imoneysum + ",");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
            }
            if (model.frettbquantity != null)
            {
                strSql1.Append("frettbquantity,");
                strSql2.Append("" + model.frettbquantity + ",");
            }
            if (model.fretsum != null)
            {
                strSql1.Append("fretsum,");
                strSql2.Append("" + model.fretsum + ",");
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
            if (model.dblPreExchMomey != null)
            {
                strSql1.Append("dblPreExchMomey,");
                strSql2.Append("" + model.dblPreExchMomey + ",");
            }
            if (model.dblPreMomey != null)
            {
                strSql1.Append("dblPreMomey,");
                strSql2.Append("" + model.dblPreMomey + ",");
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
            if (model.cvencode != null)
            {
                strSql1.Append("cvencode,");
                strSql2.Append("'" + model.cvencode + "',");
            }
            if (model.cReasonCode != null)
            {
                strSql1.Append("cReasonCode,");
                strSql2.Append("'" + model.cReasonCode + "',");
            }
            if (model.cInvSN != null)
            {
                strSql1.Append("cInvSN,");
                strSql2.Append("'" + model.cInvSN + "',");
            }
            if (model.iInvSNCount != null)
            {
                strSql1.Append("iInvSNCount,");
                strSql2.Append("" + model.iInvSNCount + ",");
            }
            if (model.bneedsign != null)
            {
                strSql1.Append("bneedsign,");
                strSql2.Append("" + (model.bneedsign ? 1 : 0) + ",");
            }
            if (model.bsignover != null)
            {
                strSql1.Append("bsignover,");
                strSql2.Append("" + (model.bsignover ? 1 : 0) + ",");
            }
            if (model.bneedloss != null)
            {
                strSql1.Append("bneedloss,");
                strSql2.Append("" + (model.bneedloss ? 1 : 0) + ",");
            }
            if (model.flossrate != null)
            {
                strSql1.Append("flossrate,");
                strSql2.Append("" + model.flossrate + ",");
            }
            if (model.frlossqty != null)
            {
                strSql1.Append("frlossqty,");
                strSql2.Append("" + model.frlossqty + ",");
            }
            if (model.fulossqty != null)
            {
                strSql1.Append("fulossqty,");
                strSql2.Append("" + model.fulossqty + ",");
            }
            if (model.isettletype != null)
            {
                strSql1.Append("isettletype,");
                strSql2.Append("" + model.isettletype + ",");
            }
            if (model.crelacuscode != null)
            {
                strSql1.Append("crelacuscode,");
                strSql2.Append("'" + model.crelacuscode + "',");
            }
            if (model.cLossMaker != null)
            {
                strSql1.Append("cLossMaker,");
                strSql2.Append("'" + model.cLossMaker + "',");
            }
            if (model.dLossDate != null)
            {
                strSql1.Append("dLossDate,");
                strSql2.Append("'" + model.dLossDate + "',");
            }
            if (model.dLossTime != null)
            {
                strSql1.Append("dLossTime,");
                strSql2.Append("'" + model.dLossTime + "',");
            }
            if (model.icoridlsid != null)
            {
                strSql1.Append("icoridlsid,");
                strSql2.Append("" + model.icoridlsid + ",");
            }
            if (model.fretoutqty != null)
            {
                strSql1.Append("fretoutqty,");
                strSql2.Append("" + model.fretoutqty + ",");
            }
            if (model.body_outid != null)
            {
                strSql1.Append("body_outid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.fVeriBillQty != null)
            {
                strSql1.Append("fVeriBillQty,");
                strSql2.Append("" + model.fVeriBillQty + ",");
            }
            if (model.fVeriBillSum != null)
            {
                strSql1.Append("fVeriBillSum,");
                strSql2.Append("" + model.fVeriBillSum + ",");
            }
            if (model.fVeriRetQty != null)
            {
                strSql1.Append("fVeriRetQty,");
                strSql2.Append("" + model.fVeriRetQty + ",");
            }
            if (model.fVeriRetSum != null)
            {
                strSql1.Append("fVeriRetSum,");
                strSql2.Append("" + model.fVeriRetSum + ",");
            }
            if (model.fLastSettleQty != null)
            {
                strSql1.Append("fLastSettleQty,");
                strSql2.Append("" + model.fLastSettleQty + ",");
            }
            if (model.fLastSettleSum != null)
            {
                strSql1.Append("fLastSettleSum,");
                strSql2.Append("" + model.fLastSettleSum + ",");
            }
            if (model.cBookWhcode != null)
            {
                strSql1.Append("cBookWhcode,");
                strSql2.Append("'" + model.cBookWhcode + "',");
            }
            if (model.cInVouchType != null)
            {
                strSql1.Append("cInVouchType,");
                strSql2.Append("'" + model.cInVouchType + "',");
            }
            if (model.cPosition != null)
            {
                strSql1.Append("cPosition,");
                strSql2.Append("'" + model.cPosition + "',");
            }
            if (model.fretqtywkp != null)
            {
                strSql1.Append("fretqtywkp,");
                strSql2.Append("" + model.fretqtywkp + ",");
            }
            if (model.fretqtyykp != null)
            {
                strSql1.Append("fretqtyykp,");
                strSql2.Append("" + model.fretqtyykp + ",");
            }
            if (model.frettbqtyykp != null)
            {
                strSql1.Append("frettbqtyykp,");
                strSql2.Append("" + model.frettbqtyykp + ",");
            }
            if (model.fretsumykp != null)
            {
                strSql1.Append("fretsumykp,");
                strSql2.Append("" + model.fretsumykp + ",");
            }
            if (model.dkeepdate != null)
            {
                strSql1.Append("dkeepdate,");
                strSql2.Append("'" + model.dkeepdate + "',");
            }
            if (model.cSCloser != null)
            {
                strSql1.Append("cSCloser,");
                strSql2.Append("'" + model.cSCloser + "',");
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
            if (model.fxjquantity != null)
            {
                strSql1.Append("fxjquantity,");
                strSql2.Append("" + model.fxjquantity + ",");
            }
            if (model.fxjnum != null)
            {
                strSql1.Append("fxjnum,");
                strSql2.Append("" + model.fxjnum + ",");
            }
            if (model.bIAcreatebill != null)
            {
                strSql1.Append("bIAcreatebill,");
                strSql2.Append("" + (model.bIAcreatebill ? 1 : 0) + ",");
            }
            if (model.cParentCode != null)
            {
                strSql1.Append("cParentCode,");
                strSql2.Append("'" + model.cParentCode + "',");
            }
            if (model.cChildCode != null)
            {
                strSql1.Append("cChildCode,");
                strSql2.Append("'" + model.cChildCode + "',");
            }
            if (model.fchildqty != null)
            {
                strSql1.Append("fchildqty,");
                strSql2.Append("" + model.fchildqty + ",");
            }
            if (model.fchildrate != null)
            {
                strSql1.Append("fchildrate,");
                strSql2.Append("" + model.fchildrate + ",");
            }
            if (model.iCalcType != null)
            {
                strSql1.Append("iCalcType,");
                strSql2.Append("" + model.iCalcType + ",");
            }
            if (model.fappretwkpqty != null)
            {
                strSql1.Append("fappretwkpqty,");
                strSql2.Append("" + model.fappretwkpqty + ",");
            }
            if (model.fappretwkpsum != null)
            {
                strSql1.Append("fappretwkpsum,");
                strSql2.Append("" + model.fappretwkpsum + ",");
            }
            if (model.fappretykpqty != null)
            {
                strSql1.Append("fappretykpqty,");
                strSql2.Append("" + model.fappretykpqty + ",");
            }
            if (model.fappretykpsum != null)
            {
                strSql1.Append("fappretykpsum,");
                strSql2.Append("" + model.fappretykpsum + ",");
            }
            if (model.fappretwkptbqty != null)
            {
                strSql1.Append("fappretwkptbqty,");
                strSql2.Append("" + model.fappretwkptbqty + ",");
            }
            if (model.fappretykptbqty != null)
            {
                strSql1.Append("fappretykptbqty,");
                strSql2.Append("" + model.fappretykptbqty + ",");
            }
            if (model.irtnappid != null)
            {
                strSql1.Append("irtnappid,");
                strSql2.Append("" + model.irtnappid + ",");
            }
            if (model.crtnappcode != null)
            {
                strSql1.Append("crtnappcode,");
                strSql2.Append("'" + model.crtnappcode + "',");
            }
            if (model.fretailrealamount != null)
            {
                strSql1.Append("fretailrealamount,");
                strSql2.Append("" + model.fretailrealamount + ",");
            }
            if (model.fretailsettleamount != null)
            {
                strSql1.Append("fretailsettleamount,");
                strSql2.Append("" + model.fretailsettleamount + ",");
            }
            strSql.Append("insert into DispatchLists(");
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

