using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:rdrecords10
    /// </summary>
    public partial class rdrecords10
    {
        public rdrecords10()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords10 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.AutoID != null)
            {
                strSql1.Append("AutoID,");
                strSql2.Append("" + model.AutoID + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
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
            if (model.iUnitCost != null)
            {
                strSql1.Append("iUnitCost,");
                strSql2.Append("" + model.iUnitCost + ",");
            }
            if (model.iPrice != null)
            {
                strSql1.Append("iPrice,");
                strSql2.Append("" + model.iPrice + ",");
            }
            if (model.iAPrice != null)
            {
                strSql1.Append("iAPrice,");
                strSql2.Append("" + model.iAPrice + ",");
            }
            if (model.iPUnitCost != null)
            {
                strSql1.Append("iPUnitCost,");
                strSql2.Append("" + model.iPUnitCost + ",");
            }
            if (model.iPPrice != null)
            {
                strSql1.Append("iPPrice,");
                strSql2.Append("" + model.iPPrice + ",");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
            }
            if (model.cVouchCode != null)
            {
                strSql1.Append("cVouchCode,");
                strSql2.Append("" + model.cVouchCode + ",");
            }
            if (model.cInVouchCode != null)
            {
                strSql1.Append("cInVouchCode,");
                strSql2.Append("'" + model.cInVouchCode + "',");
            }
            if (model.cinvouchtype != null)
            {
                strSql1.Append("cinvouchtype,");
                strSql2.Append("'" + model.cinvouchtype + "',");
            }
            if (model.iSOutQuantity != null)
            {
                strSql1.Append("iSOutQuantity,");
                strSql2.Append("" + model.iSOutQuantity + ",");
            }
            if (model.iSOutNum != null)
            {
                strSql1.Append("iSOutNum,");
                strSql2.Append("" + model.iSOutNum + ",");
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
            if (model.iFlag != null)
            {
                strSql1.Append("iFlag,");
                strSql2.Append("" + model.iFlag + ",");
            }
            if (model.iFNum != null)
            {
                strSql1.Append("iFNum,");
                strSql2.Append("" + model.iFNum + ",");
            }
            if (model.iFQuantity != null)
            {
                strSql1.Append("iFQuantity,");
                strSql2.Append("" + model.iFQuantity + ",");
            }
            if (model.dVDate != null)
            {
                strSql1.Append("dVDate,");
                strSql2.Append("'" + model.dVDate + "',");
            }
            if (model.cPosition != null)
            {
                strSql1.Append("cPosition,");
                strSql2.Append("'" + model.cPosition + "',");
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
            if (model.cName != null)
            {
                strSql1.Append("cName,");
                strSql2.Append("'" + model.cName + "',");
            }
            if (model.cItemCName != null)
            {
                strSql1.Append("cItemCName,");
                strSql2.Append("'" + model.cItemCName + "',");
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
            if (model.cBarCode != null)
            {
                strSql1.Append("cBarCode,");
                strSql2.Append("'" + model.cBarCode + "',");
            }
            if (model.iNQuantity != null)
            {
                strSql1.Append("iNQuantity,");
                strSql2.Append("" + model.iNQuantity + ",");
            }
            if (model.iNNum != null)
            {
                strSql1.Append("iNNum,");
                strSql2.Append("" + model.iNNum + ",");
            }
            if (model.cAssUnit != null)
            {
                strSql1.Append("cAssUnit,");
                strSql2.Append("'" + model.cAssUnit + "',");
            }
            if (model.dMadeDate != null)
            {
                strSql1.Append("dMadeDate,");
                strSql2.Append("'" + model.dMadeDate + "',");
            }
            if (model.iMassDate != null)
            {
                strSql1.Append("iMassDate,");
                strSql2.Append("" + model.iMassDate + ",");
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
            if (model.iMPoIds != null)
            {
                strSql1.Append("iMPoIds,");
                strSql2.Append("" + model.iMPoIds + ",");
            }
            if (model.iCheckIds != null)
            {
                strSql1.Append("iCheckIds,");
                strSql2.Append("" + model.iCheckIds + ",");
            }
            if (model.cBVencode != null)
            {
                strSql1.Append("cBVencode,");
                strSql2.Append("'" + model.cBVencode + "',");
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
            if (model.cCheckCode != null)
            {
                strSql1.Append("cCheckCode,");
                strSql2.Append("'" + model.cCheckCode + "',");
            }
            if (model.iCheckIdBaks != null)
            {
                strSql1.Append("iCheckIdBaks,");
                strSql2.Append("" + model.iCheckIdBaks + ",");
            }
            if (model.cRejectCode != null)
            {
                strSql1.Append("cRejectCode,");
                strSql2.Append("'" + model.cRejectCode + "',");
            }
            if (model.iRejectIds != null)
            {
                strSql1.Append("iRejectIds,");
                strSql2.Append("" + model.iRejectIds + ",");
            }
            if (model.cCheckPersonCode != null)
            {
                strSql1.Append("cCheckPersonCode,");
                strSql2.Append("'" + model.cCheckPersonCode + "',");
            }
            if (model.dCheckDate != null)
            {
                strSql1.Append("dCheckDate,");
                strSql2.Append("'" + model.dCheckDate + "',");
            }
            if (model.cMassUnit != null)
            {
                strSql1.Append("cMassUnit,");
                strSql2.Append("" + model.cMassUnit + ",");
            }
            if (model.cMoLotCode != null)
            {
                strSql1.Append("cMoLotCode,");
                strSql2.Append("'" + model.cMoLotCode + "',");
            }
            if (model.bChecked != null)
            {
                strSql1.Append("bChecked,");
                strSql2.Append("" + (model.bChecked ? 1 : 0) + ",");
            }
            if (model.bRelated != null)
            {
                strSql1.Append("bRelated,");
                strSql2.Append("" + (model.bRelated ? 1 : 0) + ",");
            }
            if (model.cmworkcentercode != null)
            {
                strSql1.Append("cmworkcentercode,");
                strSql2.Append("'" + model.cmworkcentercode + "',");
            }
            if (model.bLPUseFree != null)
            {
                strSql1.Append("bLPUseFree,");
                strSql2.Append("" + (model.bLPUseFree ? 1 : 0) + ",");
            }
            if (model.iRSRowNO != null)
            {
                strSql1.Append("iRSRowNO,");
                strSql2.Append("" + model.iRSRowNO + ",");
            }
            if (model.iOriTrackID != null)
            {
                strSql1.Append("iOriTrackID,");
                strSql2.Append("" + model.iOriTrackID + ",");
            }
            if (model.coritracktype != null)
            {
                strSql1.Append("coritracktype,");
                strSql2.Append("'" + model.coritracktype + "',");
            }
            if (model.cbaccounter != null)
            {
                strSql1.Append("cbaccounter,");
                strSql2.Append("'" + model.cbaccounter + "',");
            }
            if (model.dbKeepDate != null)
            {
                strSql1.Append("dbKeepDate,");
                strSql2.Append("'" + model.dbKeepDate + "',");
            }
            if (model.bCosting != null)
            {
                strSql1.Append("bCosting,");
                strSql2.Append("" + (model.bCosting ? 1 : 0) + ",");
            }
            if (model.bVMIUsed != null)
            {
                strSql1.Append("bVMIUsed,");
                strSql2.Append("" + (model.bVMIUsed ? 1 : 0) + ",");
            }
            if (model.iVMISettleQuantity != null)
            {
                strSql1.Append("iVMISettleQuantity,");
                strSql2.Append("" + model.iVMISettleQuantity + ",");
            }
            if (model.iVMISettleNum != null)
            {
                strSql1.Append("iVMISettleNum,");
                strSql2.Append("" + model.iVMISettleNum + ",");
            }
            if (model.cvmivencode != null)
            {
                strSql1.Append("cvmivencode,");
                strSql2.Append("'" + model.cvmivencode + "',");
            }
            if (model.iInvSNCount != null)
            {
                strSql1.Append("iInvSNCount,");
                strSql2.Append("" + model.iInvSNCount + ",");
            }
            if (model.cwhpersoncode != null)
            {
                strSql1.Append("cwhpersoncode,");
                strSql2.Append("'" + model.cwhpersoncode + "',");
            }
            if (model.cwhpersonname != null)
            {
                strSql1.Append("cwhpersonname,");
                strSql2.Append("'" + model.cwhpersonname + "',");
            }
            if (model.cserviceoid != null)
            {
                strSql1.Append("cserviceoid,");
                strSql2.Append("'" + model.cserviceoid + "',");
            }
            if (model.cbserviceoid != null)
            {
                strSql1.Append("cbserviceoid,");
                strSql2.Append("'" + model.cbserviceoid + "',");
            }
            if (model.iinvexchrate != null)
            {
                strSql1.Append("iinvexchrate,");
                strSql2.Append("" + model.iinvexchrate + ",");
            }
            if (model.corufts != null)
            {
                strSql1.Append("corufts,");
                strSql2.Append("'" + model.corufts + "',");
            }
            if (model.cmocode != null)
            {
                strSql1.Append("cmocode,");
                strSql2.Append("'" + model.cmocode + "',");
            }
            if (model.imoseq != null)
            {
                strSql1.Append("imoseq,");
                strSql2.Append("" + model.imoseq + ",");
            }
            if (model.iopseq != null)
            {
                strSql1.Append("iopseq,");
                strSql2.Append("'" + model.iopseq + "',");
            }
            if (model.copdesc != null)
            {
                strSql1.Append("copdesc,");
                strSql2.Append("'" + model.copdesc + "',");
            }
            if (model.strContractGUID != null)
            {
                strSql1.Append("strContractGUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
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
            if (model.cciqbookcode != null)
            {
                strSql1.Append("cciqbookcode,");
                strSql2.Append("'" + model.cciqbookcode + "',");
            }
            if (model.iBondedSumQty != null)
            {
                strSql1.Append("iBondedSumQty,");
                strSql2.Append("" + model.iBondedSumQty + ",");
            }
            if (model.productinids != null)
            {
                strSql1.Append("productinids,");
                strSql2.Append("" + model.productinids + ",");
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
            if (model.iordercode != null)
            {
                strSql1.Append("iordercode,");
                strSql2.Append("'" + model.iordercode + "',");
            }
            if (model.iorderseq != null)
            {
                strSql1.Append("iorderseq,");
                strSql2.Append("" + model.iorderseq + ",");
            }
            if (model.isodid != null)
            {
                strSql1.Append("isodid,");
                strSql2.Append("'" + model.isodid + "',");
            }
            if (model.isotype != null)
            {
                strSql1.Append("isotype,");
                strSql2.Append("" + model.isotype + ",");
            }
            if (model.csocode != null)
            {
                strSql1.Append("csocode,");
                strSql2.Append("'" + model.csocode + "',");
            }
            if (model.isoseq != null)
            {
                strSql1.Append("isoseq,");
                strSql2.Append("" + model.isoseq + ",");
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
            if (model.cbMemo != null)
            {
                strSql1.Append("cbMemo,");
                strSql2.Append("'" + model.cbMemo + "',");
            }
            if (model.irowno != null)
            {
                strSql1.Append("irowno,");
                strSql2.Append("" + model.irowno + ",");
            }
            if (model.strowguid != null)
            {
                strSql1.Append("strowguid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.cservicecode != null)
            {
                strSql1.Append("cservicecode,");
                strSql2.Append("'" + model.cservicecode + "',");
            }
            if (model.rowufts != null)
            {
                strSql1.Append("rowufts,");
                strSql2.Append("" + model.rowufts + ",");
            }
            if (model.ipreuseqty != null)
            {
                strSql1.Append("ipreuseqty,");
                strSql2.Append("" + model.ipreuseqty + ",");
            }
            if (model.ipreuseinum != null)
            {
                strSql1.Append("ipreuseinum,");
                strSql2.Append("" + model.ipreuseinum + ",");
            }
            if (model.OutCopiedQuantity != null)
            {
                strSql1.Append("OutCopiedQuantity,");
                strSql2.Append("" + model.OutCopiedQuantity + ",");
            }
            if (model.cbsysbarcode != null)
            {
                strSql1.Append("cbsysbarcode,");
                strSql2.Append("'" + model.cbsysbarcode + "',");
            }
            if (model.cplanlotcode != null)
            {
                strSql1.Append("cplanlotcode,");
                strSql2.Append("'" + model.cplanlotcode + "',");
            }
            if (model.bmergecheck != null)
            {
                strSql1.Append("bmergecheck,");
                strSql2.Append("" + (model.bmergecheck ? 1 : 0) + ",");
            }
            if (model.imergecheckautoid != null)
            {
                strSql1.Append("imergecheckautoid,");
                strSql2.Append("" + model.imergecheckautoid + ",");
            }
            if (model.iposflag != null)
            {
                strSql1.Append("iposflag,");
                strSql2.Append("" + model.iposflag + ",");
            }
            if (model.iorderdetailid != null)
            {
                strSql1.Append("iorderdetailid,");
                strSql2.Append("" + model.iorderdetailid + ",");
            }
            if (model.SA_PreOrderDetailsID != null)
            {
                strSql1.Append("SA_PreOrderDetailsID,");
                strSql2.Append("" + model.SA_PreOrderDetailsID + ",");
            }
            strSql.Append("insert into rdrecords10(");
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

