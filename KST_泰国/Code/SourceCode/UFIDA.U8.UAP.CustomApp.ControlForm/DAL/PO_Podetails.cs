using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:PO_Podetails
    /// </summary>
    public partial class PO_Podetails
    {
        public PO_Podetails()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.PO_Podetails model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.cPOID != null)
            {
                strSql1.Append("cPOID,");
                strSql2.Append("'" + model.cPOID + "',");
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
            if (model.dArriveDate != null)
            {
                strSql1.Append("dArriveDate,");
                strSql2.Append("'" + model.dArriveDate + "',");
            }
            if (model.iReceivedQTY != null)
            {
                strSql1.Append("iReceivedQTY,");
                strSql2.Append("" + model.iReceivedQTY + ",");
            }
            if (model.iReceivedNum != null)
            {
                strSql1.Append("iReceivedNum,");
                strSql2.Append("" + model.iReceivedNum + ",");
            }
            if (model.iReceivedMoney != null)
            {
                strSql1.Append("iReceivedMoney,");
                strSql2.Append("" + model.iReceivedMoney + ",");
            }
            if (model.iInvQTY != null)
            {
                strSql1.Append("iInvQTY,");
                strSql2.Append("" + model.iInvQTY + ",");
            }
            if (model.iInvNum != null)
            {
                strSql1.Append("iInvNum,");
                strSql2.Append("" + model.iInvNum + ",");
            }
            if (model.iInvMoney != null)
            {
                strSql1.Append("iInvMoney,");
                strSql2.Append("" + model.iInvMoney + ",");
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
            if (model.iNatInvMoney != null)
            {
                strSql1.Append("iNatInvMoney,");
                strSql2.Append("" + model.iNatInvMoney + ",");
            }
            if (model.iOriTotal != null)
            {
                strSql1.Append("iOriTotal,");
                strSql2.Append("" + model.iOriTotal + ",");
            }
            if (model.iTotal != null)
            {
                strSql1.Append("iTotal,");
                strSql2.Append("" + model.iTotal + ",");
            }
            if (model.iPerTaxRate != null)
            {
                strSql1.Append("iPerTaxRate,");
                strSql2.Append("" + model.iPerTaxRate + ",");
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
            if (model.iflag != null)
            {
                strSql1.Append("iflag,");
                strSql2.Append("" + model.iflag + ",");
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
            if (model.PPCIds != null)
            {
                strSql1.Append("PPCIds,");
                strSql2.Append("" + model.PPCIds + ",");
            }
            if (model.cItemName != null)
            {
                strSql1.Append("cItemName,");
                strSql2.Append("'" + model.cItemName + "',");
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
            if (model.bGsp != null)
            {
                strSql1.Append("bGsp,");
                strSql2.Append("" + model.bGsp + ",");
            }
            if (model.POID != null)
            {
                strSql1.Append("POID,");
                strSql2.Append("" + model.POID + ",");
            }
            if (model.cUnitID != null)
            {
                strSql1.Append("cUnitID,");
                strSql2.Append("'" + model.cUnitID + "',");
            }
            if (model.iTaxPrice != null)
            {
                strSql1.Append("iTaxPrice,");
                strSql2.Append("" + model.iTaxPrice + ",");
            }
            if (model.iArrQTY != null)
            {
                strSql1.Append("iArrQTY,");
                strSql2.Append("" + model.iArrQTY + ",");
            }
            if (model.iArrNum != null)
            {
                strSql1.Append("iArrNum,");
                strSql2.Append("" + model.iArrNum + ",");
            }
            if (model.iArrMoney != null)
            {
                strSql1.Append("iArrMoney,");
                strSql2.Append("" + model.iArrMoney + ",");
            }
            if (model.iNatArrMoney != null)
            {
                strSql1.Append("iNatArrMoney,");
                strSql2.Append("" + model.iNatArrMoney + ",");
            }
            if (model.iAppIds != null)
            {
                strSql1.Append("iAppIds,");
                strSql2.Append("" + model.iAppIds + ",");
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
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.bTaxCost != null)
            {
                strSql1.Append("bTaxCost,");
                strSql2.Append("" + (model.bTaxCost ? 1 : 0) + ",");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.cbCloser != null)
            {
                strSql1.Append("cbCloser,");
                strSql2.Append("'" + model.cbCloser + "',");
            }
            if (model.iPPartId != null)
            {
                strSql1.Append("iPPartId,");
                strSql2.Append("" + model.iPPartId + ",");
            }
            if (model.iPQuantity != null)
            {
                strSql1.Append("iPQuantity,");
                strSql2.Append("" + model.iPQuantity + ",");
            }
            if (model.iPTOSeq != null)
            {
                strSql1.Append("iPTOSeq,");
                strSql2.Append("" + model.iPTOSeq + ",");
            }
            if (model.SoType != null)
            {
                strSql1.Append("SoType,");
                strSql2.Append("" + model.SoType + ",");
            }
            if (model.SoDId != null)
            {
                strSql1.Append("SoDId,");
                strSql2.Append("'" + model.SoDId + "',");
            }
            //if (model.ContractRowGUID != null)
            //{
            //    strSql1.Append("ContractRowGUID,");
            //    strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            //}
            if (model.cupsocode != null)
            {
                strSql1.Append("cupsocode,");
                strSql2.Append("'" + model.cupsocode + "',");
            }
            if (model.iInvMPCost != null)
            {
                strSql1.Append("iInvMPCost,");
                strSql2.Append("" + model.iInvMPCost + ",");
            }
            if (model.ContractCode != null)
            {
                strSql1.Append("ContractCode,");
                strSql2.Append("'" + model.ContractCode + "',");
            }
            if (model.ContractRowNo != null)
            {
                strSql1.Append("ContractRowNo,");
                strSql2.Append("'" + model.ContractRowNo + "',");
            }
            if (model.fPoValidQuantity != null)
            {
                strSql1.Append("fPoValidQuantity,");
                strSql2.Append("" + model.fPoValidQuantity + ",");
            }
            if (model.fPoValidNum != null)
            {
                strSql1.Append("fPoValidNum,");
                strSql2.Append("" + model.fPoValidNum + ",");
            }
            if (model.fPoArrQuantity != null)
            {
                strSql1.Append("fPoArrQuantity,");
                strSql2.Append("" + model.fPoArrQuantity + ",");
            }
            if (model.fPoArrNum != null)
            {
                strSql1.Append("fPoArrNum,");
                strSql2.Append("" + model.fPoArrNum + ",");
            }
            if (model.fPoRetQuantity != null)
            {
                strSql1.Append("fPoRetQuantity,");
                strSql2.Append("" + model.fPoRetQuantity + ",");
            }
            if (model.fPoRetNum != null)
            {
                strSql1.Append("fPoRetNum,");
                strSql2.Append("" + model.fPoRetNum + ",");
            }
            if (model.fPoRefuseQuantity != null)
            {
                strSql1.Append("fPoRefuseQuantity,");
                strSql2.Append("" + model.fPoRefuseQuantity + ",");
            }
            if (model.fPoRefuseNum != null)
            {
                strSql1.Append("fPoRefuseNum,");
                strSql2.Append("" + model.fPoRefuseNum + ",");
            }
            //if (model.dUfts != null)
            //{
            //    strSql1.Append("dUfts,");
            //    strSql2.Append("" + model.dUfts + ",");
            //}
            if (model.iorderdid != null)
            {
                strSql1.Append("iorderdid,");
                strSql2.Append("" + model.iorderdid + ",");
            }
            if (model.iordertype != null)
            {
                strSql1.Append("iordertype,");
                strSql2.Append("" + model.iordertype + ",");
            }
            if (model.csoordercode != null)
            {
                strSql1.Append("csoordercode,");
                strSql2.Append("'" + model.csoordercode + "',");
            }
            if (model.iorderseq != null)
            {
                strSql1.Append("iorderseq,");
                strSql2.Append("" + model.iorderseq + ",");
            }
            if (model.cbCloseTime != null)
            {
                strSql1.Append("cbCloseTime,");
                strSql2.Append("'" + model.cbCloseTime + "',");
            }
            if (model.cbCloseDate != null)
            {
                strSql1.Append("cbCloseDate,");
                strSql2.Append("'" + model.cbCloseDate + "',");
            }
            if (model.cBG_ItemCode != null)
            {
                strSql1.Append("cBG_ItemCode,");
                strSql2.Append("'" + model.cBG_ItemCode + "',");
            }
            if (model.cBG_ItemName != null)
            {
                strSql1.Append("cBG_ItemName,");
                strSql2.Append("'" + model.cBG_ItemName + "',");
            }
            if (model.cBG_CaliberKey1 != null)
            {
                strSql1.Append("cBG_CaliberKey1,");
                strSql2.Append("'" + model.cBG_CaliberKey1 + "',");
            }
            if (model.cBG_CaliberKeyName1 != null)
            {
                strSql1.Append("cBG_CaliberKeyName1,");
                strSql2.Append("'" + model.cBG_CaliberKeyName1 + "',");
            }
            if (model.cBG_CaliberKey2 != null)
            {
                strSql1.Append("cBG_CaliberKey2,");
                strSql2.Append("'" + model.cBG_CaliberKey2 + "',");
            }
            if (model.cBG_CaliberKeyName2 != null)
            {
                strSql1.Append("cBG_CaliberKeyName2,");
                strSql2.Append("'" + model.cBG_CaliberKeyName2 + "',");
            }
            if (model.cBG_CaliberKey3 != null)
            {
                strSql1.Append("cBG_CaliberKey3,");
                strSql2.Append("'" + model.cBG_CaliberKey3 + "',");
            }
            if (model.cBG_CaliberKeyName3 != null)
            {
                strSql1.Append("cBG_CaliberKeyName3,");
                strSql2.Append("'" + model.cBG_CaliberKeyName3 + "',");
            }
            if (model.cBG_CaliberCode1 != null)
            {
                strSql1.Append("cBG_CaliberCode1,");
                strSql2.Append("'" + model.cBG_CaliberCode1 + "',");
            }
            if (model.cBG_CaliberName1 != null)
            {
                strSql1.Append("cBG_CaliberName1,");
                strSql2.Append("'" + model.cBG_CaliberName1 + "',");
            }
            if (model.cBG_CaliberCode2 != null)
            {
                strSql1.Append("cBG_CaliberCode2,");
                strSql2.Append("'" + model.cBG_CaliberCode2 + "',");
            }
            if (model.cBG_CaliberName2 != null)
            {
                strSql1.Append("cBG_CaliberName2,");
                strSql2.Append("'" + model.cBG_CaliberName2 + "',");
            }
            if (model.cBG_CaliberCode3 != null)
            {
                strSql1.Append("cBG_CaliberCode3,");
                strSql2.Append("'" + model.cBG_CaliberCode3 + "',");
            }
            if (model.cBG_CaliberName3 != null)
            {
                strSql1.Append("cBG_CaliberName3,");
                strSql2.Append("'" + model.cBG_CaliberName3 + "',");
            }
            if (model.iBG_Ctrl != null)
            {
                strSql1.Append("iBG_Ctrl,");
                strSql2.Append("" + model.iBG_Ctrl + ",");
            }
            if (model.cBG_Auditopinion != null)
            {
                strSql1.Append("cBG_Auditopinion,");
                strSql2.Append("'" + model.cBG_Auditopinion + "',");
            }
            if (model.fexquantity != null)
            {
                strSql1.Append("fexquantity,");
                strSql2.Append("" + model.fexquantity + ",");
            }
            if (model.fexnum != null)
            {
                strSql1.Append("fexnum,");
                strSql2.Append("" + model.fexnum + ",");
            }
            if (model.ivouchrowno != null)
            {
                strSql1.Append("ivouchrowno,");
                strSql2.Append("" + model.ivouchrowno + ",");
            }
            if (model.cBG_CaliberKey4 != null)
            {
                strSql1.Append("cBG_CaliberKey4,");
                strSql2.Append("'" + model.cBG_CaliberKey4 + "',");
            }
            if (model.cBG_CaliberKeyName4 != null)
            {
                strSql1.Append("cBG_CaliberKeyName4,");
                strSql2.Append("'" + model.cBG_CaliberKeyName4 + "',");
            }
            if (model.cBG_CaliberKey5 != null)
            {
                strSql1.Append("cBG_CaliberKey5,");
                strSql2.Append("'" + model.cBG_CaliberKey5 + "',");
            }
            if (model.cBG_CaliberKeyName5 != null)
            {
                strSql1.Append("cBG_CaliberKeyName5,");
                strSql2.Append("'" + model.cBG_CaliberKeyName5 + "',");
            }
            if (model.cBG_CaliberKey6 != null)
            {
                strSql1.Append("cBG_CaliberKey6,");
                strSql2.Append("'" + model.cBG_CaliberKey6 + "',");
            }
            if (model.cBG_CaliberKeyName6 != null)
            {
                strSql1.Append("cBG_CaliberKeyName6,");
                strSql2.Append("'" + model.cBG_CaliberKeyName6 + "',");
            }
            if (model.cBG_CaliberCode4 != null)
            {
                strSql1.Append("cBG_CaliberCode4,");
                strSql2.Append("'" + model.cBG_CaliberCode4 + "',");
            }
            if (model.cBG_CaliberName4 != null)
            {
                strSql1.Append("cBG_CaliberName4,");
                strSql2.Append("'" + model.cBG_CaliberName4 + "',");
            }
            if (model.cBG_CaliberCode5 != null)
            {
                strSql1.Append("cBG_CaliberCode5,");
                strSql2.Append("'" + model.cBG_CaliberCode5 + "',");
            }
            if (model.cBG_CaliberName5 != null)
            {
                strSql1.Append("cBG_CaliberName5,");
                strSql2.Append("'" + model.cBG_CaliberName5 + "',");
            }
            if (model.cBG_CaliberCode6 != null)
            {
                strSql1.Append("cBG_CaliberCode6,");
                strSql2.Append("'" + model.cBG_CaliberCode6 + "',");
            }
            if (model.cBG_CaliberName6 != null)
            {
                strSql1.Append("cBG_CaliberName6,");
                strSql2.Append("'" + model.cBG_CaliberName6 + "',");
            }
            if (model.csocode != null)
            {
                strSql1.Append("csocode,");
                strSql2.Append("'" + model.csocode + "',");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
            }
            if (model.freceivedqty != null)
            {
                strSql1.Append("freceivedqty,");
                strSql2.Append("" + model.freceivedqty + ",");
            }
            if (model.freceivednum != null)
            {
                strSql1.Append("freceivednum,");
                strSql2.Append("" + model.freceivednum + ",");
            }
            if (model.cxjspdids != null)
            {
                strSql1.Append("cxjspdids,");
                strSql2.Append("'" + model.cxjspdids + "',");
            }
            if (model.cbMemo != null)
            {
                strSql1.Append("cbMemo,");
                strSql2.Append("'" + model.cbMemo + "',");
            }
            if (model.cbsysbarcode != null)
            {
                strSql1.Append("cbsysbarcode,");
                strSql2.Append("'" + model.cbsysbarcode + "',");
            }
            if (model.planlotnumber != null)
            {
                strSql1.Append("planlotnumber,");
                strSql2.Append("'" + model.planlotnumber + "',");
            }
            strSql.Append("insert into PO_Podetails(");
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

