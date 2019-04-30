using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:OM_MODetails
    /// </summary>
    public partial class OM_MODetails
    {
        public OM_MODetails()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.OM_MODetails model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MODetailsID != null)
            {
                strSql1.Append("MODetailsID,");
                strSql2.Append("" + model.MODetailsID + ",");
            }
            if (model.MOID != null)
            {
                strSql1.Append("MOID,");
                strSql2.Append("" + model.MOID + ",");
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
            if (model.dStartDate != null)
            {
                strSql1.Append("dStartDate,");
                strSql2.Append("'" + model.dStartDate + "',");
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
            if (model.SOType != null)
            {
                strSql1.Append("SOType,");
                strSql2.Append("" + model.SOType + ",");
            }
            if (model.SODID != null)
            {
                strSql1.Append("SODID,");
                strSql2.Append("'" + model.SODID + "',");
            }
            if (model.BomID != null)
            {
                strSql1.Append("BomID,");
                strSql2.Append("" + model.BomID + ",");
            }
            if (model.mrpdetailsID != null)
            {
                strSql1.Append("mrpdetailsID,");
                strSql2.Append("" + model.mrpdetailsID + ",");
            }
            if (model.fParentScrp != null)
            {
                strSql1.Append("fParentScrp,");
                strSql2.Append("" + model.fParentScrp + ",");
            }
            if (model.iMaterialSendQty != null)
            {
                strSql1.Append("iMaterialSendQty,");
                strSql2.Append("" + model.iMaterialSendQty + ",");
            }
            if (model.Tbaseqtyd != null)
            {
                strSql1.Append("Tbaseqtyd,");
                strSql2.Append("" + model.Tbaseqtyd + ",");
            }
            if (model.iVTids != null)
            {
                strSql1.Append("iVTids,");
                strSql2.Append("" + model.iVTids + ",");
            }
            if (model.cupsocode != null)
            {
                strSql1.Append("cupsocode,");
                strSql2.Append("'" + model.cupsocode + "',");
            }
            if (model.cupsoids != null)
            {
                strSql1.Append("cupsoids,");
                strSql2.Append("" + model.cupsoids + ",");
            }
            if (model.isosid != null)
            {
                strSql1.Append("isosid,");
                strSql2.Append("" + model.isosid + ",");
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
            if (model.iVouchRowNo != null)
            {
                strSql1.Append("iVouchRowNo,");
                strSql2.Append("" + model.iVouchRowNo + ",");
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
            if (model.cbMemo != null)
            {
                strSql1.Append("cbMemo,");
                strSql2.Append("'" + model.cbMemo + "',");
            }
            if (model.iCusBomID != null)
            {
                strSql1.Append("iCusBomID,");
                strSql2.Append("" + model.iCusBomID + ",");
            }
            if (model.cbsysbarcode != null)
            {
                strSql1.Append("cbsysbarcode,");
                strSql2.Append("'" + model.cbsysbarcode + "',");
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
            if (model.BomType != null)
            {
                strSql1.Append("BomType,");
                strSql2.Append("" + model.BomType + ",");
            }
            if (model.iSourceMOCode != null)
            {
                strSql1.Append("iSourceMOCode,");
                strSql2.Append("'" + model.iSourceMOCode + "',");
            }
            if (model.iSourceMODetailsID != null)
            {
                strSql1.Append("iSourceMODetailsID,");
                strSql2.Append("" + model.iSourceMODetailsID + ",");
            }
            if (model.imrpqty != null)
            {
                strSql1.Append("imrpqty,");
                strSql2.Append("" + model.imrpqty + ",");
            }
            if (model.freworkquantity != null)
            {
                strSql1.Append("freworkquantity,");
                strSql2.Append("" + model.freworkquantity + ",");
            }
            if (model.freworknum != null)
            {
                strSql1.Append("freworknum,");
                strSql2.Append("" + model.freworknum + ",");
            }
            if (model.iProductType != null)
            {
                strSql1.Append("iProductType,");
                strSql2.Append("" + model.iProductType + ",");
            }
            if (model.iMainMoDetailsID != null)
            {
                strSql1.Append("iMainMoDetailsID,");
                strSql2.Append("" + model.iMainMoDetailsID + ",");
            }
            if (model.iMainMoMaterialsID != null)
            {
                strSql1.Append("iMainMoMaterialsID,");
                strSql2.Append("" + model.iMainMoMaterialsID + ",");
            }
            if (model.cMainInvCode != null)
            {
                strSql1.Append("cMainInvCode,");
                strSql2.Append("'" + model.cMainInvCode + "',");
            }
            if (model.isoordertype != null)
            {
                strSql1.Append("isoordertype,");
                strSql2.Append("" + model.isoordertype + ",");
            }
            if (model.iorderdid != null)
            {
                strSql1.Append("iorderdid,");
                strSql2.Append("" + model.iorderdid + ",");
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
            if (model.cPlanLotNumber != null)
            {
                strSql1.Append("cPlanLotNumber,");
                strSql2.Append("'" + model.cPlanLotNumber + "',");
            }
            strSql.Append("insert into @u8.OM_MODetails(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1, 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

