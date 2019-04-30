using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:PU_ArrivalVouchs
    /// </summary>
    public partial class PU_ArrivalVouchs
    {
        public PU_ArrivalVouchs()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.PU_ArrivalVouchs model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Autoid != null)
            {
                strSql1.Append("Autoid,");
                strSql2.Append("" + model.Autoid + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
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
            if (model.iNum != null)
            {
                strSql1.Append("iNum,");
                strSql2.Append("" + model.iNum + ",");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
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
            if (model.iPOsID != null)
            {
                strSql1.Append("iPOsID,");
                strSql2.Append("" + model.iPOsID + ",");
            }
            if (model.cItemName != null)
            {
                strSql1.Append("cItemName,");
                strSql2.Append("'" + model.cItemName + "',");
            }
            if (model.cUnitID != null)
            {
                strSql1.Append("cUnitID,");
                strSql2.Append("'" + model.cUnitID + "',");
            }
            if (model.fValidInQuan != null)
            {
                strSql1.Append("fValidInQuan,");
                strSql2.Append("" + model.fValidInQuan + ",");
            }
            if (model.fKPQuantity != null)
            {
                strSql1.Append("fKPQuantity,");
                strSql2.Append("" + model.fKPQuantity + ",");
            }
            if (model.fRealQuantity != null)
            {
                strSql1.Append("fRealQuantity,");
                strSql2.Append("" + model.fRealQuantity + ",");
            }
            if (model.fValidQuantity != null)
            {
                strSql1.Append("fValidQuantity,");
                strSql2.Append("" + model.fValidQuantity + ",");
            }
            if (model.finValidQuantity != null)
            {
                strSql1.Append("finValidQuantity,");
                strSql2.Append("" + model.finValidQuantity + ",");
            }
            if (model.cCloser != null)
            {
                strSql1.Append("cCloser,");
                strSql2.Append("'" + model.cCloser + "',");
            }
            if (model.iCorId != null)
            {
                strSql1.Append("iCorId,");
                strSql2.Append("" + model.iCorId + ",");
            }
            if (model.fRetQuantity != null)
            {
                strSql1.Append("fRetQuantity,");
                strSql2.Append("" + model.fRetQuantity + ",");
            }
            if (model.fInValidInQuan != null)
            {
                strSql1.Append("fInValidInQuan,");
                strSql2.Append("" + model.fInValidInQuan + ",");
            }
            if (model.bGsp != null)
            {
                strSql1.Append("bGsp,");
                strSql2.Append("" + model.bGsp + ",");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
            }
            if (model.dVDate != null)
            {
                strSql1.Append("dVDate,");
                strSql2.Append("'" + model.dVDate + "',");
            }
            if (model.dPDate != null)
            {
                strSql1.Append("dPDate,");
                strSql2.Append("'" + model.dPDate + "',");
            }
            if (model.fRefuseQuantity != null)
            {
                strSql1.Append("fRefuseQuantity,");
                strSql2.Append("" + model.fRefuseQuantity + ",");
            }
            if (model.cGspState != null)
            {
                strSql1.Append("cGspState,");
                strSql2.Append("'" + model.cGspState + "',");
            }
            if (model.fValidNum != null)
            {
                strSql1.Append("fValidNum,");
                strSql2.Append("" + model.fValidNum + ",");
            }
            if (model.fValidInNum != null)
            {
                strSql1.Append("fValidInNum,");
                strSql2.Append("" + model.fValidInNum + ",");
            }
            if (model.fInValidNum != null)
            {
                strSql1.Append("fInValidNum,");
                strSql2.Append("" + model.fInValidNum + ",");
            }
            if (model.fRealNum != null)
            {
                strSql1.Append("fRealNum,");
                strSql2.Append("" + model.fRealNum + ",");
            }
            if (model.bTaxCost != null)
            {
                strSql1.Append("bTaxCost,");
                strSql2.Append("" + (model.bTaxCost ? 1 : 0) + ",");
            }
            if (model.bInspect != null)
            {
                strSql1.Append("bInspect,");
                strSql2.Append("" + model.bInspect + ",");
            }
            if (model.fRefuseNum != null)
            {
                strSql1.Append("fRefuseNum,");
                strSql2.Append("" + model.fRefuseNum + ",");
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
            if (model.ContractRowGUID != null)
            {
                strSql1.Append("ContractRowGUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.imassdate != null)
            {
                strSql1.Append("imassdate,");
                strSql2.Append("" + model.imassdate + ",");
            }
            if (model.cmassunit != null)
            {
                strSql1.Append("cmassunit,");
                strSql2.Append("" + model.cmassunit + ",");
            }
            if (model.bexigency != null)
            {
                strSql1.Append("bexigency,");
                strSql2.Append("" + model.bexigency + ",");
            }
            if (model.cbcloser != null)
            {
                strSql1.Append("cbcloser,");
                strSql2.Append("'" + model.cbcloser + "',");
            }
            if (model.fSumRefuseQuantity != null)
            {
                strSql1.Append("fSumRefuseQuantity,");
                strSql2.Append("" + model.fSumRefuseQuantity + ",");
            }
            if (model.FSumRefuseNum != null)
            {
                strSql1.Append("FSumRefuseNum,");
                strSql2.Append("" + model.FSumRefuseNum + ",");
            }
            if (model.fRetNum != null)
            {
                strSql1.Append("fRetNum,");
                strSql2.Append("" + model.fRetNum + ",");
            }
            if (model.fDTQuantity != null)
            {
                strSql1.Append("fDTQuantity,");
                strSql2.Append("" + model.fDTQuantity + ",");
            }
            if (model.fInvalidInNum != null)
            {
                strSql1.Append("fInvalidInNum,");
                strSql2.Append("" + model.fInvalidInNum + ",");
            }
            if (model.fDegradeQuantity != null)
            {
                strSql1.Append("fDegradeQuantity,");
                strSql2.Append("" + model.fDegradeQuantity + ",");
            }
            if (model.fDegradeNum != null)
            {
                strSql1.Append("fDegradeNum,");
                strSql2.Append("" + model.fDegradeNum + ",");
            }
            if (model.fDegradeInQuantity != null)
            {
                strSql1.Append("fDegradeInQuantity,");
                strSql2.Append("" + model.fDegradeInQuantity + ",");
            }
            if (model.fDegradeInNum != null)
            {
                strSql1.Append("fDegradeInNum,");
                strSql2.Append("" + model.fDegradeInNum + ",");
            }
            if (model.fInspectQuantity != null)
            {
                strSql1.Append("fInspectQuantity,");
                strSql2.Append("" + model.fInspectQuantity + ",");
            }
            if (model.fInspectNum != null)
            {
                strSql1.Append("fInspectNum,");
                strSql2.Append("" + model.fInspectNum + ",");
            }
            if (model.iInvMPCost != null)
            {
                strSql1.Append("iInvMPCost,");
                strSql2.Append("" + model.iInvMPCost + ",");
            }
            if (model.guids != null)
            {
                strSql1.Append("guids,");
                strSql2.Append("'" + model.guids + "',");
            }
            if (model.iinvexchrate != null)
            {
                strSql1.Append("iinvexchrate,");
                strSql2.Append("" + model.iinvexchrate + ",");
            }
            if (model.objectid_source != null)
            {
                strSql1.Append("objectid_source,");
                strSql2.Append("'" + model.objectid_source + "',");
            }
            if (model.autoid_source != null)
            {
                strSql1.Append("autoid_source,");
                strSql2.Append("" + model.autoid_source + ",");
            }
            if (model.ufts_source != null)
            {
                strSql1.Append("ufts_source,");
                strSql2.Append("'" + model.ufts_source + "',");
            }
            if (model.irowno_source != null)
            {
                strSql1.Append("irowno_source,");
                strSql2.Append("" + model.irowno_source + ",");
            }
            if (model.csocode != null)
            {
                strSql1.Append("csocode,");
                strSql2.Append("'" + model.csocode + "',");
            }
            if (model.isorowno != null)
            {
                strSql1.Append("isorowno,");
                strSql2.Append("" + model.isorowno + ",");
            }
            if (model.iorderid != null)
            {
                strSql1.Append("iorderid,");
                strSql2.Append("" + model.iorderid + ",");
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
            if (model.dlineclosedate != null)
            {
                strSql1.Append("dlineclosedate,");
                strSql2.Append("'" + model.dlineclosedate + "',");
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
            if (model.RejectSource != null)
            {
                strSql1.Append("RejectSource,");
                strSql2.Append("" + (model.RejectSource ? 1 : 0) + ",");
            }
            if (model.iciqbookid != null)
            {
                strSql1.Append("iciqbookid,");
                strSql2.Append("" + model.iciqbookid + ",");
            }
            if (model.cciqbookcode != null)
            {
                strSql1.Append("cciqbookcode,");
                strSql2.Append("'" + model.cciqbookcode + "',");
            }
            if (model.cciqcode != null)
            {
                strSql1.Append("cciqcode,");
                strSql2.Append("'" + model.cciqcode + "',");
            }
            if (model.fciqchangrate != null)
            {
                strSql1.Append("fciqchangrate,");
                strSql2.Append("" + model.fciqchangrate + ",");
            }
            if (model.irejectautoid != null)
            {
                strSql1.Append("irejectautoid,");
                strSql2.Append("" + model.irejectautoid + ",");
            }
            if (model.iExpiratDateCalcu != null)
            {
                strSql1.Append("iExpiratDateCalcu,");
                strSql2.Append("" + model.iExpiratDateCalcu + ",");
            }
            if (model.cExpirationdate != null)
            {
                strSql1.Append("cExpirationdate,");
                strSql2.Append("'" + model.cExpirationdate + "',");
            }
            if (model.dExpirationdate != null)
            {
                strSql1.Append("dExpirationdate,");
                strSql2.Append("'" + model.dExpirationdate + "',");
            }
            if (model.cupsocode != null)
            {
                strSql1.Append("cupsocode,");
                strSql2.Append("'" + model.cupsocode + "',");
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
            if (model.cBatchProperty1 != null)
            {
                strSql1.Append("cBatchProperty1,");
                strSql2.Append("" + model.cBatchProperty1 + ",");
            }
            if (model.cBatchProperty2 != null)
            {
                strSql1.Append("cBatchProperty2,");
                strSql2.Append("" + model.cBatchProperty2 + ",");
            }
            if (model.cBatchProperty3 != null)
            {
                strSql1.Append("cBatchProperty3,");
                strSql2.Append("" + model.cBatchProperty3 + ",");
            }
            if (model.cBatchProperty4 != null)
            {
                strSql1.Append("cBatchProperty4,");
                strSql2.Append("" + model.cBatchProperty4 + ",");
            }
            if (model.cBatchProperty5 != null)
            {
                strSql1.Append("cBatchProperty5,");
                strSql2.Append("" + model.cBatchProperty5 + ",");
            }
            if (model.cBatchProperty6 != null)
            {
                strSql1.Append("cBatchProperty6,");
                strSql2.Append("'" + model.cBatchProperty6 + "',");
            }
            if (model.cBatchProperty7 != null)
            {
                strSql1.Append("cBatchProperty7,");
                strSql2.Append("'" + model.cBatchProperty7 + "',");
            }
            if (model.cBatchProperty8 != null)
            {
                strSql1.Append("cBatchProperty8,");
                strSql2.Append("'" + model.cBatchProperty8 + "',");
            }
            if (model.cBatchProperty9 != null)
            {
                strSql1.Append("cBatchProperty9,");
                strSql2.Append("'" + model.cBatchProperty9 + "',");
            }
            if (model.cBatchProperty10 != null)
            {
                strSql1.Append("cBatchProperty10,");
                strSql2.Append("'" + model.cBatchProperty10 + "',");
            }
            if (model.ivouchrowno != null)
            {
                strSql1.Append("ivouchrowno,");
                strSql2.Append("" + model.ivouchrowno + ",");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
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
            if (model.carrivalcode != null)
            {
                strSql1.Append("carrivalcode,");
                strSql2.Append("'" + model.carrivalcode + "',");
            }
            if (model.ipickedquantity != null)
            {
                strSql1.Append("ipickedquantity,");
                strSql2.Append("" + model.ipickedquantity + ",");
            }
            if (model.ipickednum != null)
            {
                strSql1.Append("ipickednum,");
                strSql2.Append("" + model.ipickednum + ",");
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
            if (model.fsumreworkquantity != null)
            {
                strSql1.Append("fsumreworkquantity,");
                strSql2.Append("" + model.fsumreworkquantity + ",");
            }
            if (model.fsumreworknum != null)
            {
                strSql1.Append("fsumreworknum,");
                strSql2.Append("" + model.fsumreworknum + ",");
            }
            if (model.iProductType != null)
            {
                strSql1.Append("iProductType,");
                strSql2.Append("" + model.iProductType + ",");
            }
            if (model.cMainInvCode != null)
            {
                strSql1.Append("cMainInvCode,");
                strSql2.Append("'" + model.cMainInvCode + "',");
            }
            if (model.iMainMoDetailsID != null)
            {
                strSql1.Append("iMainMoDetailsID,");
                strSql2.Append("" + model.iMainMoDetailsID + ",");
            }
            if (model.PlanLotNumber != null)
            {
                strSql1.Append("PlanLotNumber,");
                strSql2.Append("'" + model.PlanLotNumber + "',");
            }
            if (model.bgift != null)
            {
                strSql1.Append("bgift,");
                strSql2.Append("" + model.bgift + ",");
            }
            strSql.Append("insert into @u8.PU_ArrivalVouchs(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1,1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1,1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

