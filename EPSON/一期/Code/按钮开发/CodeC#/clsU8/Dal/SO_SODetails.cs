using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
{
    /// <summary>
    /// 数据访问类:SO_SODetails
    /// </summary>
    public partial class SO_SODetails
    {
        public SO_SODetails()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.clsU8.Model.SO_SODetails model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cSOCode != null)
            {
                strSql1.Append("cSOCode,");
                strSql2.Append("'" + model.cSOCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.dPreDate != null)
            {
                strSql1.Append("dPreDate,");
                strSql2.Append("'" + model.dPreDate + "',");
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
            if (model.iFHNum != null)
            {
                strSql1.Append("iFHNum,");
                strSql2.Append("" + model.iFHNum + ",");
            }
            if (model.iFHQuantity != null)
            {
                strSql1.Append("iFHQuantity,");
                strSql2.Append("" + model.iFHQuantity + ",");
            }
            if (model.iFHMoney != null)
            {
                strSql1.Append("iFHMoney,");
                strSql2.Append("" + model.iFHMoney + ",");
            }
            if (model.iKPQuantity != null)
            {
                strSql1.Append("iKPQuantity,");
                strSql2.Append("" + model.iKPQuantity + ",");
            }
            if (model.iKPNum != null)
            {
                strSql1.Append("iKPNum,");
                strSql2.Append("" + model.iKPNum + ",");
            }
            if (model.iKPMoney != null)
            {
                strSql1.Append("iKPMoney,");
                strSql2.Append("" + model.iKPMoney + ",");
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
            if (model.bFH != null)
            {
                strSql1.Append("bFH,");
                strSql2.Append("" + model.bFH + ",");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
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
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
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
            if (model.FPurQuan != null)
            {
                strSql1.Append("FPurQuan,");
                strSql2.Append("" + model.FPurQuan + ",");
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
            if (model.cQuoCode != null)
            {
                strSql1.Append("cQuoCode,");
                strSql2.Append("'" + model.cQuoCode + "',");
            }
            if (model.iQuoID != null)
            {
                strSql1.Append("iQuoID,");
                strSql2.Append("" + model.iQuoID + ",");
            }
            if (model.cSCloser != null)
            {
                strSql1.Append("cSCloser,");
                strSql2.Append("'" + model.cSCloser + "',");
            }
            if (model.dPreMoDate != null)
            {
                strSql1.Append("dPreMoDate,");
                strSql2.Append("'" + model.dPreMoDate + "',");
            }
            if (model.iRowNo != null)
            {
                strSql1.Append("iRowNo,");
                strSql2.Append("" + model.iRowNo + ",");
            }
            if (model.iCusBomID != null)
            {
                strSql1.Append("iCusBomID,");
                strSql2.Append("" + model.iCusBomID + ",");
            }
            if (model.iMoQuantity != null)
            {
                strSql1.Append("iMoQuantity,");
                strSql2.Append("" + model.iMoQuantity + ",");
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
            if (model.iPreKeepQuantity != null)
            {
                strSql1.Append("iPreKeepQuantity,");
                strSql2.Append("" + model.iPreKeepQuantity + ",");
            }
            if (model.iPreKeepNum != null)
            {
                strSql1.Append("iPreKeepNum,");
                strSql2.Append("" + model.iPreKeepNum + ",");
            }
            if (model.iPreKeepTotQuantity != null)
            {
                strSql1.Append("iPreKeepTotQuantity,");
                strSql2.Append("" + model.iPreKeepTotQuantity + ",");
            }
            if (model.iPreKeepTotNum != null)
            {
                strSql1.Append("iPreKeepTotNum,");
                strSql2.Append("" + model.iPreKeepTotNum + ",");
            }
            if (model.dreleasedate != null)
            {
                strSql1.Append("dreleasedate,");
                strSql2.Append("'" + model.dreleasedate + "',");
            }
            if (model.fcusminprice != null)
            {
                strSql1.Append("fcusminprice,");
                strSql2.Append("" + model.fcusminprice + ",");
            }
            if (model.fimquantity != null)
            {
                strSql1.Append("fimquantity,");
                strSql2.Append("" + model.fimquantity + ",");
            }
            if (model.fomquantity != null)
            {
                strSql1.Append("fomquantity,");
                strSql2.Append("" + model.fomquantity + ",");
            }
            if (model.ballpurchase != null)
            {
                strSql1.Append("ballpurchase,");
                strSql2.Append("" + (model.ballpurchase ? 1 : 0) + ",");
            }
            if (model.finquantity != null)
            {
                strSql1.Append("finquantity,");
                strSql2.Append("" + model.finquantity + ",");
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
            if (model.foutquantity != null)
            {
                strSql1.Append("foutquantity,");
                strSql2.Append("" + model.foutquantity + ",");
            }
            if (model.foutnum != null)
            {
                strSql1.Append("foutnum,");
                strSql2.Append("" + model.foutnum + ",");
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
            if (model.dufts != null)
            {
                strSql1.Append("dufts,");
                strSql2.Append("" + model.dufts + ",");
            }
            if (model.iaoids != null)
            {
                strSql1.Append("iaoids,");
                strSql2.Append("" + model.iaoids + ",");
            }
            if (model.cpreordercode != null)
            {
                strSql1.Append("cpreordercode,");
                strSql2.Append("'" + model.cpreordercode + "',");
            }
            if (model.fretquantity != null)
            {
                strSql1.Append("fretquantity,");
                strSql2.Append("" + model.fretquantity + ",");
            }
            if (model.fretnum != null)
            {
                strSql1.Append("fretnum,");
                strSql2.Append("" + model.fretnum + ",");
            }
            if (model.dbclosedate != null)
            {
                strSql1.Append("dbclosedate,");
                strSql2.Append("'" + model.dbclosedate + "',");
            }
            if (model.dbclosesystime != null)
            {
                strSql1.Append("dbclosesystime,");
                strSql2.Append("'" + model.dbclosesystime + "',");
            }
            if (model.bOrderBOM != null)
            {
                strSql1.Append("bOrderBOM,");
                strSql2.Append("" + (model.bOrderBOM ? 1 : 0) + ",");
            }
            if (model.bOrderBOMOver != null)
            {
                strSql1.Append("bOrderBOMOver,");
                strSql2.Append("" + model.bOrderBOMOver + ",");
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
            if (model.fPurSum != null)
            {
                strSql1.Append("fPurSum,");
                strSql2.Append("" + model.fPurSum + ",");
            }
            if (model.fPurBillQty != null)
            {
                strSql1.Append("fPurBillQty,");
                strSql2.Append("" + model.fPurBillQty + ",");
            }
            if (model.fPurBillSum != null)
            {
                strSql1.Append("fPurBillSum,");
                strSql2.Append("" + model.fPurBillSum + ",");
            }
            if (model.iimid != null)
            {
                strSql1.Append("iimid,");
                strSql2.Append("" + model.iimid + ",");
            }
            if (model.ccorvouchtype != null)
            {
                strSql1.Append("ccorvouchtype,");
                strSql2.Append("'" + model.ccorvouchtype + "',");
            }
            if (model.icorrowno != null)
            {
                strSql1.Append("icorrowno,");
                strSql2.Append("" + model.icorrowno + ",");
            }
            if (model.busecusbom != null)
            {
                strSql1.Append("busecusbom,");
                strSql2.Append("" + (model.busecusbom ? 1 : 0) + ",");
            }
            if (model.body_outid != null)
            {
                strSql1.Append("body_outid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.fVeriDispQty != null)
            {
                strSql1.Append("fVeriDispQty,");
                strSql2.Append("" + model.fVeriDispQty + ",");
            }
            if (model.fVeriDispSum != null)
            {
                strSql1.Append("fVeriDispSum,");
                strSql2.Append("" + model.fVeriDispSum + ",");
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
            if (model.forecastdid != null)
            {
                strSql1.Append("forecastdid,");
                strSql2.Append("" + model.forecastdid + ",");
            }
            if (model.cdetailsdemandcode != null)
            {
                strSql1.Append("cdetailsdemandcode,");
                strSql2.Append("'" + model.cdetailsdemandcode + "',");
            }
            if (model.cdetailsdemandmemo != null)
            {
                strSql1.Append("cdetailsdemandmemo,");
                strSql2.Append("'" + model.cdetailsdemandmemo + "',");
            }
            if (model.fTransedQty != null)
            {
                strSql1.Append("fTransedQty,");
                strSql2.Append("" + model.fTransedQty + ",");
            }
            if (model.cbSysBarCode != null)
            {
                strSql1.Append("cbSysBarCode,");
                strSql2.Append("'" + model.cbSysBarCode + "',");
            }
            if (model.fappqty != null)
            {
                strSql1.Append("fappqty,");
                strSql2.Append("" + model.fappqty + ",");
            }
            strSql.Append("insert into SO_SODetails(");
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

