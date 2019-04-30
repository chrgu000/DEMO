using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace ClsU8.DAL
{
    /// <summary>
    /// 数据访问类:PU_AppVouchs
    /// </summary>
    public partial class PU_AppVouchs
    {
        public PU_AppVouchs()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(ClsU8.Model.PU_AppVouchs model)
        {

            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.AutoID != null)
            {
                strSql1.Append("AutoID,");
                strSql2.Append("" + model.AutoID + ",");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.fQuantity != null)
            {
                strSql1.Append("fQuantity,");
                strSql2.Append("" + model.fQuantity + ",");
            }
            if (model.fUnitPrice != null)
            {
                strSql1.Append("fUnitPrice,");
                strSql2.Append("" + model.fUnitPrice + ",");
            }
            if (model.iPerTaxRate != null)
            {
                strSql1.Append("iPerTaxRate,");
                strSql2.Append("" + model.iPerTaxRate + ",");
            }
            if (model.fTaxPrice != null)
            {
                strSql1.Append("fTaxPrice,");
                strSql2.Append("" + model.fTaxPrice + ",");
            }
            if (model.fMoney != null)
            {
                strSql1.Append("fMoney,");
                strSql2.Append("" + model.fMoney + ",");
            }
            if (model.dRequirDate != null)
            {
                strSql1.Append("dRequirDate,");
                strSql2.Append("'" + model.dRequirDate + "',");
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
            if (model.cItem_class != null)
            {
                strSql1.Append("cItem_class,");
                strSql2.Append("'" + model.cItem_class + "',");
            }
            if (model.cItemCode != null)
            {
                strSql1.Append("cItemCode,");
                strSql2.Append("'" + model.cItemCode + "',");
            }
            if (model.CItemName != null)
            {
                strSql1.Append("CItemName,");
                strSql2.Append("'" + model.CItemName + "',");
            }
            if (model.bTaxCost != null)
            {
                strSql1.Append("bTaxCost,");
                strSql2.Append("" + (model.bTaxCost ? 1 : 0) + ",");
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
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.SoDId != null)
            {
                strSql1.Append("SoDId,");
                strSql2.Append("'" + model.SoDId + "',");
            }
            if (model.SoType != null)
            {
                strSql1.Append("SoType,");
                strSql2.Append("" + model.SoType + ",");
            }
            if (model.iMrpsid != null)
            {
                strSql1.Append("iMrpsid,");
                strSql2.Append("" + model.iMrpsid + ",");
            }
            if (model.iRopsid != null)
            {
                strSql1.Append("iRopsid,");
                strSql2.Append("" + model.iRopsid + ",");
            }
            if (model.cbcloser != null)
            {
                strSql1.Append("cbcloser,");
                strSql2.Append("'" + model.cbcloser + "',");
            }
            if (model.fNum != null)
            {
                strSql1.Append("fNum,");
                strSql2.Append("" + model.fNum + ",");
            }
            if (model.cUnitID != null)
            {
                strSql1.Append("cUnitID,");
                strSql2.Append("'" + model.cUnitID + "',");
            }
            if (model.iReceivedNum != null)
            {
                strSql1.Append("iReceivedNum,");
                strSql2.Append("" + model.iReceivedNum + ",");
            }
            if (model.cPersonCodeExec != null)
            {
                strSql1.Append("cPersonCodeExec,");
                strSql2.Append("'" + model.cPersonCodeExec + "',");
            }
            if (model.cDepCodeExec != null)
            {
                strSql1.Append("cDepCodeExec,");
                strSql2.Append("'" + model.cDepCodeExec + "',");
            }
            if (model.iInvMPCost != null)
            {
                strSql1.Append("iInvMPCost,");
                strSql2.Append("" + model.iInvMPCost + ",");
            }
            //if (model.dUfts != null)
            //{
            //    strSql1.Append("dUfts,");
            //    strSql2.Append("" + model.dUfts + ",");
            //}
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
            if (model.iOriCost != null)
            {
                strSql1.Append("iOriCost,");
                strSql2.Append("" + model.iOriCost + ",");
            }
            if (model.iOriTaxCost != null)
            {
                strSql1.Append("iOriTaxCost,");
                strSql2.Append("" + model.iOriTaxCost + ",");
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
            if (model.cdemandcode != null)
            {
                strSql1.Append("cdemandcode,");
                strSql2.Append("'" + model.cdemandcode + "',");
            }
            if (model.cdetailsdemandmemo != null)
            {
                strSql1.Append("cdetailsdemandmemo,");
                strSql2.Append("'" + model.cdetailsdemandmemo + "',");
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
            if (model.mocode != null)
            {
                strSql1.Append("mocode,");
                strSql2.Append("'" + model.mocode + "',");
            }
            if (model.ivouchrowno != null)
            {
                strSql1.Append("ivouchrowno,");
                strSql2.Append("" + model.ivouchrowno + ",");
            }
            if (model.fconquantity != null)
            {
                strSql1.Append("fconquantity,");
                strSql2.Append("" + model.fconquantity + ",");
            }
            if (model.fconmoney != null)
            {
                strSql1.Append("fconmoney,");
                strSql2.Append("" + model.fconmoney + ",");
            }
            if (model.fconnum != null)
            {
                strSql1.Append("fconnum,");
                strSql2.Append("" + model.fconnum + ",");
            }
            if (model.fconorimoney != null)
            {
                strSql1.Append("fconorimoney,");
                strSql2.Append("" + model.fconorimoney + ",");
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
            if (model.iSumXJqty != null)
            {
                strSql1.Append("iSumXJqty,");
                strSql2.Append("" + model.iSumXJqty + ",");
            }
            if (model.iSumXJCGqty != null)
            {
                strSql1.Append("iSumXJCGqty,");
                strSql2.Append("" + model.iSumXJCGqty + ",");
            }
            if (model.dbCloseDate != null)
            {
                strSql1.Append("dbCloseDate,");
                strSql2.Append("'" + model.dbCloseDate + "',");
            }
            if (model.dbCloseTime != null)
            {
                strSql1.Append("dbCloseTime,");
                strSql2.Append("'" + model.dbCloseTime + "',");
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
            if (model.isosid != null)
            {
                strSql1.Append("isosid,");
                strSql2.Append("" + model.isosid + ",");
            }
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
            if (model.planlotnumber != null)
            {
                strSql1.Append("planlotnumber,");
                strSql2.Append("'" + model.planlotnumber + "',");
            }
            strSql.Append("insert into PU_AppVouchs(");
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

