using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:TransVouchs
    /// </summary>
    public partial class TransVouchs
    {
        public TransVouchs()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouchs model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cTVCode != null)
            {
                strSql1.Append("cTVCode,");
                strSql2.Append("'" + model.cTVCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.RdsID != null)
            {
                strSql1.Append("RdsID,");
                strSql2.Append("" + model.RdsID + ",");
            }
            if (model.iTVNum != null)
            {
                strSql1.Append("iTVNum,");
                strSql2.Append("" + model.iTVNum + ",");
            }
            if (model.iTVQuantity != null)
            {
                strSql1.Append("iTVQuantity,");
                strSql2.Append("" + model.iTVQuantity + ",");
            }
            if (model.iTVACost != null)
            {
                strSql1.Append("iTVACost,");
                strSql2.Append("" + model.iTVACost + ",");
            }
            if (model.iTVAPrice != null)
            {
                strSql1.Append("iTVAPrice,");
                strSql2.Append("" + model.iTVAPrice + ",");
            }
            if (model.iTVPCost != null)
            {
                strSql1.Append("iTVPCost,");
                strSql2.Append("" + model.iTVPCost + ",");
            }
            if (model.iTVPPrice != null)
            {
                strSql1.Append("iTVPPrice,");
                strSql2.Append("" + model.iTVPPrice + ",");
            }
            if (model.cTVBatch != null)
            {
                strSql1.Append("cTVBatch,");
                strSql2.Append("'" + model.cTVBatch + "',");
            }
            if (model.dDisDate != null)
            {
                strSql1.Append("dDisDate,");
                strSql2.Append("'" + model.dDisDate + "',");
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
            if (model.autoID != null)
            {
                strSql1.Append("autoID,");
                strSql2.Append("" + model.autoID + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.iMassDate != null)
            {
                strSql1.Append("iMassDate,");
                strSql2.Append("" + model.iMassDate + ",");
            }
            if (model.cBarCode != null)
            {
                strSql1.Append("cBarCode,");
                strSql2.Append("'" + model.cBarCode + "',");
            }
            if (model.cAssUnit != null)
            {
                strSql1.Append("cAssUnit,");
                strSql2.Append("'" + model.cAssUnit + "',");
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
            if (model.cBVencode != null)
            {
                strSql1.Append("cBVencode,");
                strSql2.Append("'" + model.cBVencode + "',");
            }
            if (model.cInVouchCode != null)
            {
                strSql1.Append("cInVouchCode,");
                strSql2.Append("'" + model.cInVouchCode + "',");
            }
            if (model.dMadeDate != null)
            {
                strSql1.Append("dMadeDate,");
                strSql2.Append("'" + model.dMadeDate + "',");
            }
            if (model.cMassUnit != null)
            {
                strSql1.Append("cMassUnit,");
                strSql2.Append("" + model.cMassUnit + ",");
            }
            if (model.iTRIds != null)
            {
                strSql1.Append("iTRIds,");
                strSql2.Append("" + model.iTRIds + ",");
            }
            if (model.AppTransIDS != null)
            {
                strSql1.Append("AppTransIDS,");
                strSql2.Append("" + model.AppTransIDS + ",");
            }
            if (model.iSSoType != null)
            {
                strSql1.Append("iSSoType,");
                strSql2.Append("" + model.iSSoType + ",");
            }
            if (model.iSSodid != null)
            {
                strSql1.Append("iSSodid,");
                strSql2.Append("'" + model.iSSodid + "',");
            }
            if (model.iDSoType != null)
            {
                strSql1.Append("iDSoType,");
                strSql2.Append("" + model.iDSoType + ",");
            }
            if (model.iDSodid != null)
            {
                strSql1.Append("iDSodid,");
                strSql2.Append("'" + model.iDSodid + "',");
            }
            if (model.bCosting != null)
            {
                strSql1.Append("bCosting,");
                strSql2.Append("" + (model.bCosting ? 1 : 0) + ",");
            }
            if (model.cvmivencode != null)
            {
                strSql1.Append("cvmivencode,");
                strSql2.Append("'" + model.cvmivencode + "',");
            }
            if (model.cinposcode != null)
            {
                strSql1.Append("cinposcode,");
                strSql2.Append("'" + model.cinposcode + "',");
            }
            if (model.coutposcode != null)
            {
                strSql1.Append("coutposcode,");
                strSql2.Append("'" + model.coutposcode + "',");
            }
            if (model.iinvsncount != null)
            {
                strSql1.Append("iinvsncount,");
                strSql2.Append("" + model.iinvsncount + ",");
            }
            if (model.iinvexchrate != null)
            {
                strSql1.Append("iinvexchrate,");
                strSql2.Append("" + model.iinvexchrate + ",");
            }
            if (model.comcode != null)
            {
                strSql1.Append("comcode,");
                strSql2.Append("'" + model.comcode + "',");
            }
            if (model.cmocode != null)
            {
                strSql1.Append("cmocode,");
                strSql2.Append("'" + model.cmocode + "',");
            }
            if (model.invcode != null)
            {
                strSql1.Append("invcode,");
                strSql2.Append("'" + model.invcode + "',");
            }
            if (model.imoseq != null)
            {
                strSql1.Append("imoseq,");
                strSql2.Append("" + model.imoseq + ",");
            }
            if (model.iomids != null)
            {
                strSql1.Append("iomids,");
                strSql2.Append("" + model.iomids + ",");
            }
            if (model.imoids != null)
            {
                strSql1.Append("imoids,");
                strSql2.Append("" + model.imoids + ",");
            }
            if (model.corufts != null)
            {
                strSql1.Append("corufts,");
                strSql2.Append("'" + model.corufts + "',");
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
            if (model.cciqbookcode != null)
            {
                strSql1.Append("cciqbookcode,");
                strSql2.Append("'" + model.cciqbookcode + "',");
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
            if (model.cinvouchtype != null)
            {
                strSql1.Append("cinvouchtype,");
                strSql2.Append("'" + model.cinvouchtype + "',");
            }
            if (model.cbsourcecodels != null)
            {
                strSql1.Append("cbsourcecodels,");
                strSql2.Append("'" + model.cbsourcecodels + "',");
            }
            if (model.cMoLotCode != null)
            {
                strSql1.Append("cMoLotCode,");
                strSql2.Append("'" + model.cMoLotCode + "',");
            }
            if (model.cInVoucherLineID != null)
            {
                strSql1.Append("cInVoucherLineID,");
                strSql2.Append("" + model.cInVoucherLineID + ",");
            }
            if (model.cInVoucherCode != null)
            {
                strSql1.Append("cInVoucherCode,");
                strSql2.Append("'" + model.cInVoucherCode + "',");
            }
            if (model.cInVoucherType != null)
            {
                strSql1.Append("cInVoucherType,");
                strSql2.Append("'" + model.cInVoucherType + "',");
            }
            if (model.cbsysbarcode != null)
            {
                strSql1.Append("cbsysbarcode,");
                strSql2.Append("'" + model.cbsysbarcode + "',");
            }
            strSql.Append("insert into TransVouchs(");
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

