using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:PurBillVouchs
    /// </summary>
    public partial class PurBillVouchs
    {
        public PurBillVouchs()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.PurBillVouchs model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.PBVID != null)
            {
                strSql1.Append("PBVID,");
                strSql2.Append("'" + model.PBVID + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.bExBill != null)
            {
                strSql1.Append("bExBill,");
                strSql2.Append("" + (model.bExBill ? 1 : 0) + ",");
            }
            if (model.dInDate != null)
            {
                strSql1.Append("dInDate,");
                strSql2.Append("'" + model.dInDate + "',");
            }
            if (model.iPBVQuantity != null)
            {
                strSql1.Append("iPBVQuantity,");
                strSql2.Append("" + model.iPBVQuantity + ",");
            }
            if (model.iNum != null)
            {
                strSql1.Append("iNum,");
                strSql2.Append("" + model.iNum + ",");
            }
            if (model.iOriCost != null)
            {
                strSql1.Append("iOriCost,");
                strSql2.Append("" + model.iOriCost + ",");
            }
            if (model.iOriMoney != null)
            {
                strSql1.Append("iOriMoney,");
                strSql2.Append("" + model.iOriMoney + ",");
            }
            if (model.iOriTaxPrice != null)
            {
                strSql1.Append("iOriTaxPrice,");
                strSql2.Append("" + model.iOriTaxPrice + ",");
            }
            if (model.iOriSum != null)
            {
                strSql1.Append("iOriSum,");
                strSql2.Append("" + model.iOriSum + ",");
            }
            if (model.iCost != null)
            {
                strSql1.Append("iCost,");
                strSql2.Append("" + model.iCost + ",");
            }
            if (model.iMoney != null)
            {
                strSql1.Append("iMoney,");
                strSql2.Append("" + model.iMoney + ",");
            }
            if (model.iTaxPrice != null)
            {
                strSql1.Append("iTaxPrice,");
                strSql2.Append("" + model.iTaxPrice + ",");
            }
            if (model.iSum != null)
            {
                strSql1.Append("iSum,");
                strSql2.Append("" + model.iSum + ",");
            }
            if (model.iExMoney != null)
            {
                strSql1.Append("iExMoney,");
                strSql2.Append("" + model.iExMoney + ",");
            }
            if (model.iLostQuan != null)
            {
                strSql1.Append("iLostQuan,");
                strSql2.Append("" + model.iLostQuan + ",");
            }
            if (model.iNLostQuan != null)
            {
                strSql1.Append("iNLostQuan,");
                strSql2.Append("" + model.iNLostQuan + ",");
            }
            if (model.iNLostMoney != null)
            {
                strSql1.Append("iNLostMoney,");
                strSql2.Append("" + model.iNLostMoney + ",");
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
            if (model.cDebitHead != null)
            {
                strSql1.Append("cDebitHead,");
                strSql2.Append("'" + model.cDebitHead + "',");
            }
            if (model.cTaxHead != null)
            {
                strSql1.Append("cTaxHead,");
                strSql2.Append("'" + model.cTaxHead + "',");
            }
            if (model.cClue != null)
            {
                strSql1.Append("cClue,");
                strSql2.Append("'" + model.cClue + "',");
            }
            if (model.dSignDate != null)
            {
                strSql1.Append("dSignDate,");
                strSql2.Append("'" + model.dSignDate + "',");
            }
            if (model.cCorInvCode != null)
            {
                strSql1.Append("cCorInvCode,");
                strSql2.Append("'" + model.cCorInvCode + "',");
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
            if (model.iPOsID != null)
            {
                strSql1.Append("iPOsID,");
                strSql2.Append("" + model.iPOsID + ",");
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
            if (model.cNLostType != null)
            {
                strSql1.Append("cNLostType,");
                strSql2.Append("'" + model.cNLostType + "',");
            }
            if (model.mNLostTax != null)
            {
                strSql1.Append("mNLostTax,");
                strSql2.Append("" + model.mNLostTax + ",");
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
            if (model.dSDate != null)
            {
                strSql1.Append("dSDate,");
                strSql2.Append("'" + model.dSDate + "',");
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
            if (model.iSBsID != null)
            {
                strSql1.Append("iSBsID,");
                strSql2.Append("" + model.iSBsID + ",");
            }
            if (model.RdsId != null)
            {
                strSql1.Append("RdsId,");
                strSql2.Append("" + model.RdsId + ",");
            }
            if (model.ContractRowGUID != null)
            {
                strSql1.Append("ContractRowGUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.iOriTaxCost != null)
            {
                strSql1.Append("iOriTaxCost,");
                strSql2.Append("" + model.iOriTaxCost + ",");
            }
            if (model.UpSoType != null)
            {
                strSql1.Append("UpSoType,");
                strSql2.Append("'" + model.UpSoType + "',");
            }
            if (model.cBAccounter != null)
            {
                strSql1.Append("cBAccounter,");
                strSql2.Append("'" + model.cBAccounter + "',");
            }
            if (model.bCosting != null)
            {
                strSql1.Append("bCosting,");
                strSql2.Append("" + (model.bCosting ? 1 : 0) + ",");
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
            if (model.copcode != null)
            {
                strSql1.Append("copcode,");
                strSql2.Append("'" + model.copcode + "',");
            }
            if (model.cdescription != null)
            {
                strSql1.Append("cdescription,");
                strSql2.Append("'" + model.cdescription + "',");
            }
            if (model.bTaxCost != null)
            {
                strSql1.Append("bTaxCost,");
                strSql2.Append("" + (model.bTaxCost ? 1 : 0) + ",");
            }
            if (model.chyordercode != null)
            {
                strSql1.Append("chyordercode,");
                strSql2.Append("'" + model.chyordercode + "',");
            }
            if (model.ihyorderdid != null)
            {
                strSql1.Append("ihyorderdid,");
                strSql2.Append("" + model.ihyorderdid + ",");
            }
            if (model.inattaxprice != null)
            {
                strSql1.Append("inattaxprice,");
                strSql2.Append("" + model.inattaxprice + ",");
            }
            if (model.iinvexchrate != null)
            {
                strSql1.Append("iinvexchrate,");
                strSql2.Append("" + model.iinvexchrate + ",");
            }
            if (model.opseq != null)
            {
                strSql1.Append("opseq,");
                strSql2.Append("'" + model.opseq + "',");
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
            if (model.cConExecID != null)
            {
                strSql1.Append("cConExecID,");
                strSql2.Append("'" + model.cConExecID + "',");
            }
            if (model.cConRowID != null)
            {
                strSql1.Append("cConRowID,");
                strSql2.Append("'" + model.cConRowID + "',");
            }
            if (model.brettax != null)
            {
                strSql1.Append("brettax,");
                strSql2.Append("" + model.brettax + ",");
            }
            if (model.fretquantity != null)
            {
                strSql1.Append("fretquantity,");
                strSql2.Append("" + model.fretquantity + ",");
            }
            if (model.dretdate != null)
            {
                strSql1.Append("dretdate,");
                strSql2.Append("'" + model.dretdate + "',");
            }
            if (model.dlastretdate != null)
            {
                strSql1.Append("dlastretdate,");
                strSql2.Append("'" + model.dlastretdate + "',");
            }
            if (model.fretmoney != null)
            {
                strSql1.Append("fretmoney,");
                strSql2.Append("" + model.fretmoney + ",");
            }
            if (model.iOriZbjMoney != null)
            {
                strSql1.Append("iOriZbjMoney,");
                strSql2.Append("" + model.iOriZbjMoney + ",");
            }
            if (model.iOriNoRateZbjMoney != null)
            {
                strSql1.Append("iOriNoRateZbjMoney,");
                strSql2.Append("" + model.iOriNoRateZbjMoney + ",");
            }
            if (model.iZbjMoney != null)
            {
                strSql1.Append("iZbjMoney,");
                strSql2.Append("" + model.iZbjMoney + ",");
            }
            if (model.iNoRateZbjMoney != null)
            {
                strSql1.Append("iNoRateZbjMoney,");
                strSql2.Append("" + model.iNoRateZbjMoney + ",");
            }
            if (model.ivouchrowno != null)
            {
                strSql1.Append("ivouchrowno,");
                strSql2.Append("" + model.ivouchrowno + ",");
            }
            if (model.cPZNum != null)
            {
                strSql1.Append("cPZNum,");
                strSql2.Append("'" + model.cPZNum + "',");
            }
            if (model.dkeepdate != null)
            {
                strSql1.Append("dkeepdate,");
                strSql2.Append("'" + model.dkeepdate + "',");
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
            strSql.Append("insert into PurBillVouchs(");
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

