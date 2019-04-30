using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:ST_CurrentStock
    /// </summary>
    public partial class ST_CurrentStock
    {
        public ST_CurrentStock()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ST_CurrentStock");
            strSql.Append(" where id=" + id + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.ST_CurrentStock model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.batch != null)
            {
                strSql1.Append("batch,");
                strSql2.Append("'" + model.batch + "',");
            }
            if (model.baseQuantity != null)
            {
                strSql1.Append("baseQuantity,");
                strSql2.Append("" + model.baseQuantity + ",");
            }
            if (model.subQuantity != null)
            {
                strSql1.Append("subQuantity,");
                strSql2.Append("" + model.subQuantity + ",");
            }
            if (model.canUseBaseQuantity != null)
            {
                strSql1.Append("canUseBaseQuantity,");
                strSql2.Append("" + model.canUseBaseQuantity + ",");
            }
            if (model.canUseSubQuantity != null)
            {
                strSql1.Append("canUseSubQuantity,");
                strSql2.Append("" + model.canUseSubQuantity + ",");
            }
            if (model.onWayBaseQuantity != null)
            {
                strSql1.Append("onWayBaseQuantity,");
                strSql2.Append("" + model.onWayBaseQuantity + ",");
            }
            if (model.onWaySubQuantity != null)
            {
                strSql1.Append("onWaySubQuantity,");
                strSql2.Append("" + model.onWaySubQuantity + ",");
            }
            if (model.forDispatchBaseQuantity != null)
            {
                strSql1.Append("forDispatchBaseQuantity,");
                strSql2.Append("" + model.forDispatchBaseQuantity + ",");
            }
            if (model.forDispatchSubQuantity != null)
            {
                strSql1.Append("forDispatchSubQuantity,");
                strSql2.Append("" + model.forDispatchSubQuantity + ",");
            }
            if (model.purchaseOrderOnWayBaseQuantity != null)
            {
                strSql1.Append("purchaseOrderOnWayBaseQuantity,");
                strSql2.Append("" + model.purchaseOrderOnWayBaseQuantity + ",");
            }
            if (model.purchaseOrderOnWaySubQuantity != null)
            {
                strSql1.Append("purchaseOrderOnWaySubQuantity,");
                strSql2.Append("" + model.purchaseOrderOnWaySubQuantity + ",");
            }
            if (model.purchaseArrivalBaseQuantity != null)
            {
                strSql1.Append("purchaseArrivalBaseQuantity,");
                strSql2.Append("" + model.purchaseArrivalBaseQuantity + ",");
            }
            if (model.purchaseArrivalSubQuantity != null)
            {
                strSql1.Append("purchaseArrivalSubQuantity,");
                strSql2.Append("" + model.purchaseArrivalSubQuantity + ",");
            }
            if (model.purchaseForReceiveBaseQuantity != null)
            {
                strSql1.Append("purchaseForReceiveBaseQuantity,");
                strSql2.Append("" + model.purchaseForReceiveBaseQuantity + ",");
            }
            if (model.purchaseForReceiveSubQuantity != null)
            {
                strSql1.Append("purchaseForReceiveSubQuantity,");
                strSql2.Append("" + model.purchaseForReceiveSubQuantity + ",");
            }
            if (model.onProducingBaseQuantity != null)
            {
                strSql1.Append("onProducingBaseQuantity,");
                strSql2.Append("" + model.onProducingBaseQuantity + ",");
            }
            if (model.onProducingSubQuantity != null)
            {
                strSql1.Append("onProducingSubQuantity,");
                strSql2.Append("" + model.onProducingSubQuantity + ",");
            }
            if (model.productForReceiveBaseQuantity != null)
            {
                strSql1.Append("productForReceiveBaseQuantity,");
                strSql2.Append("" + model.productForReceiveBaseQuantity + ",");
            }
            if (model.productForReceiveSubQuantity != null)
            {
                strSql1.Append("productForReceiveSubQuantity,");
                strSql2.Append("" + model.productForReceiveSubQuantity + ",");
            }
            if (model.transOnWayBaseQuantity != null)
            {
                strSql1.Append("transOnWayBaseQuantity,");
                strSql2.Append("" + model.transOnWayBaseQuantity + ",");
            }
            if (model.transOnWaySubQuantity != null)
            {
                strSql1.Append("transOnWaySubQuantity,");
                strSql2.Append("" + model.transOnWaySubQuantity + ",");
            }
            if (model.transForDispatchBaseQuantity != null)
            {
                strSql1.Append("transForDispatchBaseQuantity,");
                strSql2.Append("" + model.transForDispatchBaseQuantity + ",");
            }
            if (model.transForDispatchSubQuantity != null)
            {
                strSql1.Append("transForDispatchSubQuantity,");
                strSql2.Append("" + model.transForDispatchSubQuantity + ",");
            }
            if (model.otherOnWayBaseQuantity != null)
            {
                strSql1.Append("otherOnWayBaseQuantity,");
                strSql2.Append("" + model.otherOnWayBaseQuantity + ",");
            }
            if (model.otherOnWaySubQuantity != null)
            {
                strSql1.Append("otherOnWaySubQuantity,");
                strSql2.Append("" + model.otherOnWaySubQuantity + ",");
            }
            if (model.otherForDispatchBaseQuantity != null)
            {
                strSql1.Append("otherForDispatchBaseQuantity,");
                strSql2.Append("" + model.otherForDispatchBaseQuantity + ",");
            }
            if (model.otherForDispatchSubQuantity != null)
            {
                strSql1.Append("otherForDispatchSubQuantity,");
                strSql2.Append("" + model.otherForDispatchSubQuantity + ",");
            }
            if (model.forSaleOrderBaseQuantity != null)
            {
                strSql1.Append("forSaleOrderBaseQuantity,");
                strSql2.Append("" + model.forSaleOrderBaseQuantity + ",");
            }
            if (model.forSaleOrderSubQuantity != null)
            {
                strSql1.Append("forSaleOrderSubQuantity,");
                strSql2.Append("" + model.forSaleOrderSubQuantity + ",");
            }
            if (model.saleDeliveryBaseQuantity != null)
            {
                strSql1.Append("saleDeliveryBaseQuantity,");
                strSql2.Append("" + model.saleDeliveryBaseQuantity + ",");
            }
            if (model.saleDeliverySubQuantity != null)
            {
                strSql1.Append("saleDeliverySubQuantity,");
                strSql2.Append("" + model.saleDeliverySubQuantity + ",");
            }
            if (model.forSaleDispatchBaseQuantity != null)
            {
                strSql1.Append("forSaleDispatchBaseQuantity,");
                strSql2.Append("" + model.forSaleDispatchBaseQuantity + ",");
            }
            if (model.forSaleDispatchSubQuantity != null)
            {
                strSql1.Append("forSaleDispatchSubQuantity,");
                strSql2.Append("" + model.forSaleDispatchSubQuantity + ",");
            }
            if (model.materialForSendBaseQuantity != null)
            {
                strSql1.Append("materialForSendBaseQuantity,");
                strSql2.Append("" + model.materialForSendBaseQuantity + ",");
            }
            if (model.materialForSendSubQuantity != null)
            {
                strSql1.Append("materialForSendSubQuantity,");
                strSql2.Append("" + model.materialForSendSubQuantity + ",");
            }
            if (model.receiveVoucherCode != null)
            {
                strSql1.Append("receiveVoucherCode,");
                strSql2.Append("'" + model.receiveVoucherCode + "',");
            }
            if (model.voucherQuantity != null)
            {
                strSql1.Append("voucherQuantity,");
                strSql2.Append("" + model.voucherQuantity + ",");
            }
            if (model.voucherQuantity2 != null)
            {
                strSql1.Append("voucherQuantity2,");
                strSql2.Append("" + model.voucherQuantity2 + ",");
            }
            if (model.preBaseQuantity != null)
            {
                strSql1.Append("preBaseQuantity,");
                strSql2.Append("" + model.preBaseQuantity + ",");
            }
            if (model.preSubQuantity != null)
            {
                strSql1.Append("preSubQuantity,");
                strSql2.Append("" + model.preSubQuantity + ",");
            }
            if (model.lowQuantity != null)
            {
                strSql1.Append("lowQuantity,");
                strSql2.Append("" + model.lowQuantity + ",");
            }
            if (model.topQuantity != null)
            {
                strSql1.Append("topQuantity,");
                strSql2.Append("" + model.topQuantity + ",");
            }
            if (model.changeRate != null)
            {
                strSql1.Append("changeRate,");
                strSql2.Append("" + model.changeRate + ",");
            }
            if (model.isCarriedForwardOut != null)
            {
                strSql1.Append("isCarriedForwardOut,");
                strSql2.Append("" + model.isCarriedForwardOut + ",");
            }
            if (model.isCarriedForwardIn != null)
            {
                strSql1.Append("isCarriedForwardIn,");
                strSql2.Append("" + model.isCarriedForwardIn + ",");
            }
            if (model.ts != null)
            {
                strSql1.Append("ts,");
                strSql2.Append("" + model.ts + ",");
            }
            if (model.updatedBy != null)
            {
                strSql1.Append("updatedBy,");
                strSql2.Append("'" + model.updatedBy + "',");
            }
            if (model.freeItem0 != null)
            {
                strSql1.Append("freeItem0,");
                strSql2.Append("'" + model.freeItem0 + "',");
            }
            if (model.freeItem1 != null)
            {
                strSql1.Append("freeItem1,");
                strSql2.Append("'" + model.freeItem1 + "',");
            }
            if (model.freeItem2 != null)
            {
                strSql1.Append("freeItem2,");
                strSql2.Append("'" + model.freeItem2 + "',");
            }
            if (model.freeItem3 != null)
            {
                strSql1.Append("freeItem3,");
                strSql2.Append("'" + model.freeItem3 + "',");
            }
            if (model.freeItem4 != null)
            {
                strSql1.Append("freeItem4,");
                strSql2.Append("'" + model.freeItem4 + "',");
            }
            if (model.freeItem5 != null)
            {
                strSql1.Append("freeItem5,");
                strSql2.Append("'" + model.freeItem5 + "',");
            }
            if (model.freeItem6 != null)
            {
                strSql1.Append("freeItem6,");
                strSql2.Append("'" + model.freeItem6 + "',");
            }
            if (model.freeItem7 != null)
            {
                strSql1.Append("freeItem7,");
                strSql2.Append("'" + model.freeItem7 + "',");
            }
            if (model.freeItem8 != null)
            {
                strSql1.Append("freeItem8,");
                strSql2.Append("'" + model.freeItem8 + "',");
            }
            if (model.freeItem9 != null)
            {
                strSql1.Append("freeItem9,");
                strSql2.Append("'" + model.freeItem9 + "',");
            }
            if (model.ProduceForDispatchBaseQuantity != null)
            {
                strSql1.Append("ProduceForDispatchBaseQuantity,");
                strSql2.Append("" + model.ProduceForDispatchBaseQuantity + ",");
            }
            if (model.ProduceForDispatchSubQuantity != null)
            {
                strSql1.Append("ProduceForDispatchSubQuantity,");
                strSql2.Append("" + model.ProduceForDispatchSubQuantity + ",");
            }
            if (model.stockRequestBaseQuantity != null)
            {
                strSql1.Append("stockRequestBaseQuantity,");
                strSql2.Append("" + model.stockRequestBaseQuantity + ",");
            }
            if (model.stockRequestSubQuantity != null)
            {
                strSql1.Append("stockRequestSubQuantity,");
                strSql2.Append("" + model.stockRequestSubQuantity + ",");
            }
            if (model.idinventory != null)
            {
                strSql1.Append("idinventory,");
                strSql2.Append("" + model.idinventory + ",");
            }
            if (model.IdMarketingOrgan != null)
            {
                strSql1.Append("IdMarketingOrgan,");
                strSql2.Append("" + model.IdMarketingOrgan + ",");
            }
            if (model.idbaseunit != null)
            {
                strSql1.Append("idbaseunit,");
                strSql2.Append("" + model.idbaseunit + ",");
            }
            if (model.idsubunit != null)
            {
                strSql1.Append("idsubunit,");
                strSql2.Append("" + model.idsubunit + ",");
            }
            if (model.idvoucherunit != null)
            {
                strSql1.Append("idvoucherunit,");
                strSql2.Append("" + model.idvoucherunit + ",");
            }
            if (model.idvoucherunit2 != null)
            {
                strSql1.Append("idvoucherunit2,");
                strSql2.Append("" + model.idvoucherunit2 + ",");
            }
            if (model.idwarehouse != null)
            {
                strSql1.Append("idwarehouse,");
                strSql2.Append("" + model.idwarehouse + ",");
            }
            if (model.idBatchDispatchDTO != null)
            {
                strSql1.Append("idBatchDispatchDTO,");
                strSql2.Append("" + model.idBatchDispatchDTO + ",");
            }
            if (model.receiveVoucherId != null)
            {
                strSql1.Append("receiveVoucherId,");
                strSql2.Append("" + model.receiveVoucherId + ",");
            }
            if (model.receiveVoucherDetailId != null)
            {
                strSql1.Append("receiveVoucherDetailId,");
                strSql2.Append("" + model.receiveVoucherDetailId + ",");
            }
            if (model.expiryDate != null)
            {
                strSql1.Append("expiryDate,");
                strSql2.Append("'" + model.expiryDate + "',");
            }
            if (model.createdtime != null)
            {
                strSql1.Append("createdtime,");
                strSql2.Append("'" + model.createdtime + "',");
            }
            if (model.updated != null)
            {
                strSql1.Append("updated,");
                strSql2.Append("'" + model.updated + "',");
            }
            if (model.productionDate != null)
            {
                strSql1.Append("productionDate,");
                strSql2.Append("'" + model.productionDate + "',");
            }
            strSql.Append("insert into ST_CurrentStock(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1,1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1,1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(BarCode.Model.ST_CurrentStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ST_CurrentStock set ");
            if (model.baseQuantity != null)
            {
                strSql.Append("baseQuantity=" + model.baseQuantity + ",");
            }
            else
            {
                strSql.Append("baseQuantity= null ,");
            }
            if (model.subQuantity != null)
            {
                strSql.Append("subQuantity=" + model.subQuantity + ",");
            }
            else
            {
                strSql.Append("subQuantity= null ,");
            }
            if (model.canUseBaseQuantity != null)
            {
                strSql.Append("canUseBaseQuantity=" + model.canUseBaseQuantity + ",");
            }
            else
            {
                strSql.Append("canUseBaseQuantity= null ,");
            }
            if (model.canUseSubQuantity != null)
            {
                strSql.Append("canUseSubQuantity=" + model.canUseSubQuantity + ",");
            }
            else
            {
                strSql.Append("canUseSubQuantity= null ,");
            }
            if (model.onWayBaseQuantity != null)
            {
                strSql.Append("onWayBaseQuantity=" + model.onWayBaseQuantity + ",");
            }
            else
            {
                strSql.Append("onWayBaseQuantity= null ,");
            }
            if (model.onWaySubQuantity != null)
            {
                strSql.Append("onWaySubQuantity=" + model.onWaySubQuantity + ",");
            }
            else
            {
                strSql.Append("onWaySubQuantity= null ,");
            }
            if (model.forDispatchBaseQuantity != null)
            {
                strSql.Append("forDispatchBaseQuantity=" + model.forDispatchBaseQuantity + ",");
            }
            else
            {
                strSql.Append("forDispatchBaseQuantity= null ,");
            }
            if (model.forDispatchSubQuantity != null)
            {
                strSql.Append("forDispatchSubQuantity=" + model.forDispatchSubQuantity + ",");
            }
            else
            {
                strSql.Append("forDispatchSubQuantity= null ,");
            }
            if (model.purchaseOrderOnWayBaseQuantity != null)
            {
                strSql.Append("purchaseOrderOnWayBaseQuantity=" + model.purchaseOrderOnWayBaseQuantity + ",");
            }
            else
            {
                strSql.Append("purchaseOrderOnWayBaseQuantity= null ,");
            }
            if (model.purchaseOrderOnWaySubQuantity != null)
            {
                strSql.Append("purchaseOrderOnWaySubQuantity=" + model.purchaseOrderOnWaySubQuantity + ",");
            }
            else
            {
                strSql.Append("purchaseOrderOnWaySubQuantity= null ,");
            }
            if (model.purchaseArrivalBaseQuantity != null)
            {
                strSql.Append("purchaseArrivalBaseQuantity=" + model.purchaseArrivalBaseQuantity + ",");
            }
            else
            {
                strSql.Append("purchaseArrivalBaseQuantity= null ,");
            }
            if (model.purchaseArrivalSubQuantity != null)
            {
                strSql.Append("purchaseArrivalSubQuantity=" + model.purchaseArrivalSubQuantity + ",");
            }
            else
            {
                strSql.Append("purchaseArrivalSubQuantity= null ,");
            }
            if (model.purchaseForReceiveBaseQuantity != null)
            {
                strSql.Append("purchaseForReceiveBaseQuantity=" + model.purchaseForReceiveBaseQuantity + ",");
            }
            else
            {
                strSql.Append("purchaseForReceiveBaseQuantity= null ,");
            }
            if (model.purchaseForReceiveSubQuantity != null)
            {
                strSql.Append("purchaseForReceiveSubQuantity=" + model.purchaseForReceiveSubQuantity + ",");
            }
            else
            {
                strSql.Append("purchaseForReceiveSubQuantity= null ,");
            }
            if (model.onProducingBaseQuantity != null)
            {
                strSql.Append("onProducingBaseQuantity=" + model.onProducingBaseQuantity + ",");
            }
            else
            {
                strSql.Append("onProducingBaseQuantity= null ,");
            }
            if (model.onProducingSubQuantity != null)
            {
                strSql.Append("onProducingSubQuantity=" + model.onProducingSubQuantity + ",");
            }
            else
            {
                strSql.Append("onProducingSubQuantity= null ,");
            }
            if (model.productForReceiveBaseQuantity != null)
            {
                strSql.Append("productForReceiveBaseQuantity=" + model.productForReceiveBaseQuantity + ",");
            }
            else
            {
                strSql.Append("productForReceiveBaseQuantity= null ,");
            }
            if (model.productForReceiveSubQuantity != null)
            {
                strSql.Append("productForReceiveSubQuantity=" + model.productForReceiveSubQuantity + ",");
            }
            else
            {
                strSql.Append("productForReceiveSubQuantity= null ,");
            }
            if (model.transOnWayBaseQuantity != null)
            {
                strSql.Append("transOnWayBaseQuantity=" + model.transOnWayBaseQuantity + ",");
            }
            else
            {
                strSql.Append("transOnWayBaseQuantity= null ,");
            }
            if (model.transOnWaySubQuantity != null)
            {
                strSql.Append("transOnWaySubQuantity=" + model.transOnWaySubQuantity + ",");
            }
            else
            {
                strSql.Append("transOnWaySubQuantity= null ,");
            }
            if (model.transForDispatchBaseQuantity != null)
            {
                strSql.Append("transForDispatchBaseQuantity=" + model.transForDispatchBaseQuantity + ",");
            }
            else
            {
                strSql.Append("transForDispatchBaseQuantity= null ,");
            }
            if (model.transForDispatchSubQuantity != null)
            {
                strSql.Append("transForDispatchSubQuantity=" + model.transForDispatchSubQuantity + ",");
            }
            else
            {
                strSql.Append("transForDispatchSubQuantity= null ,");
            }
            if (model.otherOnWayBaseQuantity != null)
            {
                strSql.Append("otherOnWayBaseQuantity=" + model.otherOnWayBaseQuantity + ",");
            }
            else
            {
                strSql.Append("otherOnWayBaseQuantity= null ,");
            }
            if (model.otherOnWaySubQuantity != null)
            {
                strSql.Append("otherOnWaySubQuantity=" + model.otherOnWaySubQuantity + ",");
            }
            else
            {
                strSql.Append("otherOnWaySubQuantity= null ,");
            }
            if (model.otherForDispatchBaseQuantity != null)
            {
                strSql.Append("otherForDispatchBaseQuantity=" + model.otherForDispatchBaseQuantity + ",");
            }
            else
            {
                strSql.Append("otherForDispatchBaseQuantity= null ,");
            }
            if (model.otherForDispatchSubQuantity != null)
            {
                strSql.Append("otherForDispatchSubQuantity=" + model.otherForDispatchSubQuantity + ",");
            }
            else
            {
                strSql.Append("otherForDispatchSubQuantity= null ,");
            }
            if (model.forSaleOrderBaseQuantity != null)
            {
                strSql.Append("forSaleOrderBaseQuantity=" + model.forSaleOrderBaseQuantity + ",");
            }
            else
            {
                strSql.Append("forSaleOrderBaseQuantity= null ,");
            }
            if (model.forSaleOrderSubQuantity != null)
            {
                strSql.Append("forSaleOrderSubQuantity=" + model.forSaleOrderSubQuantity + ",");
            }
            else
            {
                strSql.Append("forSaleOrderSubQuantity= null ,");
            }
            if (model.saleDeliveryBaseQuantity != null)
            {
                strSql.Append("saleDeliveryBaseQuantity=" + model.saleDeliveryBaseQuantity + ",");
            }
            else
            {
                strSql.Append("saleDeliveryBaseQuantity= null ,");
            }
            if (model.saleDeliverySubQuantity != null)
            {
                strSql.Append("saleDeliverySubQuantity=" + model.saleDeliverySubQuantity + ",");
            }
            else
            {
                strSql.Append("saleDeliverySubQuantity= null ,");
            }
            if (model.forSaleDispatchBaseQuantity != null)
            {
                strSql.Append("forSaleDispatchBaseQuantity=" + model.forSaleDispatchBaseQuantity + ",");
            }
            else
            {
                strSql.Append("forSaleDispatchBaseQuantity= null ,");
            }
            if (model.forSaleDispatchSubQuantity != null)
            {
                strSql.Append("forSaleDispatchSubQuantity=" + model.forSaleDispatchSubQuantity + ",");
            }
            else
            {
                strSql.Append("forSaleDispatchSubQuantity= null ,");
            }
            if (model.materialForSendBaseQuantity != null)
            {
                strSql.Append("materialForSendBaseQuantity=" + model.materialForSendBaseQuantity + ",");
            }
            else
            {
                strSql.Append("materialForSendBaseQuantity= null ,");
            }
            if (model.materialForSendSubQuantity != null)
            {
                strSql.Append("materialForSendSubQuantity=" + model.materialForSendSubQuantity + ",");
            }
            else
            {
                strSql.Append("materialForSendSubQuantity= null ,");
            }
            if (model.receiveVoucherCode != null)
            {
                strSql.Append("receiveVoucherCode='" + model.receiveVoucherCode + "',");
            }
            else
            {
                strSql.Append("receiveVoucherCode= null ,");
            }
            if (model.voucherQuantity != null)
            {
                strSql.Append("voucherQuantity=" + model.voucherQuantity + ",");
            }
            else
            {
                strSql.Append("voucherQuantity= null ,");
            }
            if (model.voucherQuantity2 != null)
            {
                strSql.Append("voucherQuantity2=" + model.voucherQuantity2 + ",");
            }
            else
            {
                strSql.Append("voucherQuantity2= null ,");
            }
            if (model.preBaseQuantity != null)
            {
                strSql.Append("preBaseQuantity=" + model.preBaseQuantity + ",");
            }
            else
            {
                strSql.Append("preBaseQuantity= null ,");
            }
            if (model.preSubQuantity != null)
            {
                strSql.Append("preSubQuantity=" + model.preSubQuantity + ",");
            }
            else
            {
                strSql.Append("preSubQuantity= null ,");
            }
            if (model.lowQuantity != null)
            {
                strSql.Append("lowQuantity=" + model.lowQuantity + ",");
            }
            else
            {
                strSql.Append("lowQuantity= null ,");
            }
            if (model.topQuantity != null)
            {
                strSql.Append("topQuantity=" + model.topQuantity + ",");
            }
            else
            {
                strSql.Append("topQuantity= null ,");
            }
            if (model.changeRate != null)
            {
                strSql.Append("changeRate=" + model.changeRate + ",");
            }
            else
            {
                strSql.Append("changeRate= null ,");
            }
            if (model.isCarriedForwardOut != null)
            {
                strSql.Append("isCarriedForwardOut=" + model.isCarriedForwardOut + ",");
            }
            else
            {
                strSql.Append("isCarriedForwardOut= null ,");
            }
            if (model.isCarriedForwardIn != null)
            {
                strSql.Append("isCarriedForwardIn=" + model.isCarriedForwardIn + ",");
            }
            else
            {
                strSql.Append("isCarriedForwardIn= null ,");
            }
            if (model.updatedBy != null)
            {
                strSql.Append("updatedBy='" + model.updatedBy + "',");
            }
            else
            {
                strSql.Append("updatedBy= null ,");
            }
            if (model.freeItem0 != null)
            {
                strSql.Append("freeItem0='" + model.freeItem0 + "',");
            }
            else
            {
                strSql.Append("freeItem0= null ,");
            }
            if (model.freeItem1 != null)
            {
                strSql.Append("freeItem1='" + model.freeItem1 + "',");
            }
            else
            {
                strSql.Append("freeItem1= null ,");
            }
            if (model.freeItem2 != null)
            {
                strSql.Append("freeItem2='" + model.freeItem2 + "',");
            }
            else
            {
                strSql.Append("freeItem2= null ,");
            }
            if (model.freeItem3 != null)
            {
                strSql.Append("freeItem3='" + model.freeItem3 + "',");
            }
            else
            {
                strSql.Append("freeItem3= null ,");
            }
            if (model.freeItem4 != null)
            {
                strSql.Append("freeItem4='" + model.freeItem4 + "',");
            }
            else
            {
                strSql.Append("freeItem4= null ,");
            }
            if (model.freeItem5 != null)
            {
                strSql.Append("freeItem5='" + model.freeItem5 + "',");
            }
            else
            {
                strSql.Append("freeItem5= null ,");
            }
            if (model.freeItem6 != null)
            {
                strSql.Append("freeItem6='" + model.freeItem6 + "',");
            }
            else
            {
                strSql.Append("freeItem6= null ,");
            }
            if (model.freeItem7 != null)
            {
                strSql.Append("freeItem7='" + model.freeItem7 + "',");
            }
            else
            {
                strSql.Append("freeItem7= null ,");
            }
            if (model.freeItem8 != null)
            {
                strSql.Append("freeItem8='" + model.freeItem8 + "',");
            }
            else
            {
                strSql.Append("freeItem8= null ,");
            }
            if (model.freeItem9 != null)
            {
                strSql.Append("freeItem9='" + model.freeItem9 + "',");
            }
            else
            {
                strSql.Append("freeItem9= null ,");
            }
            if (model.ProduceForDispatchBaseQuantity != null)
            {
                strSql.Append("ProduceForDispatchBaseQuantity=" + model.ProduceForDispatchBaseQuantity + ",");
            }
            else
            {
                strSql.Append("ProduceForDispatchBaseQuantity= null ,");
            }
            if (model.ProduceForDispatchSubQuantity != null)
            {
                strSql.Append("ProduceForDispatchSubQuantity=" + model.ProduceForDispatchSubQuantity + ",");
            }
            else
            {
                strSql.Append("ProduceForDispatchSubQuantity= null ,");
            }
            if (model.stockRequestBaseQuantity != null)
            {
                strSql.Append("stockRequestBaseQuantity=" + model.stockRequestBaseQuantity + ",");
            }
            else
            {
                strSql.Append("stockRequestBaseQuantity= null ,");
            }
            if (model.stockRequestSubQuantity != null)
            {
                strSql.Append("stockRequestSubQuantity=" + model.stockRequestSubQuantity + ",");
            }
            else
            {
                strSql.Append("stockRequestSubQuantity= null ,");
            }
            if (model.IdMarketingOrgan != null)
            {
                strSql.Append("IdMarketingOrgan=" + model.IdMarketingOrgan + ",");
            }
            else
            {
                strSql.Append("IdMarketingOrgan= null ,");
            }
            if (model.idbaseunit != null)
            {
                strSql.Append("idbaseunit=" + model.idbaseunit + ",");
            }
            else
            {
                strSql.Append("idbaseunit= null ,");
            }
            if (model.idsubunit != null)
            {
                strSql.Append("idsubunit=" + model.idsubunit + ",");
            }
            else
            {
                strSql.Append("idsubunit= null ,");
            }
            if (model.idvoucherunit != null)
            {
                strSql.Append("idvoucherunit=" + model.idvoucherunit + ",");
            }
            else
            {
                strSql.Append("idvoucherunit= null ,");
            }
            if (model.idvoucherunit2 != null)
            {
                strSql.Append("idvoucherunit2=" + model.idvoucherunit2 + ",");
            }
            else
            {
                strSql.Append("idvoucherunit2= null ,");
            }
            if (model.idBatchDispatchDTO != null)
            {
                strSql.Append("idBatchDispatchDTO=" + model.idBatchDispatchDTO + ",");
            }
            else
            {
                strSql.Append("idBatchDispatchDTO= null ,");
            }
            if (model.receiveVoucherId != null)
            {
                strSql.Append("receiveVoucherId=" + model.receiveVoucherId + ",");
            }
            else
            {
                strSql.Append("receiveVoucherId= null ,");
            }
            if (model.receiveVoucherDetailId != null)
            {
                strSql.Append("receiveVoucherDetailId=" + model.receiveVoucherDetailId + ",");
            }
            else
            {
                strSql.Append("receiveVoucherDetailId= null ,");
            }
            if (model.expiryDate != null)
            {
                strSql.Append("expiryDate='" + model.expiryDate + "',");
            }
            else
            {
                strSql.Append("expiryDate= null ,");
            }
            if (model.createdtime != null)
            {
                strSql.Append("createdtime='" + model.createdtime + "',");
            }
            else
            {
                strSql.Append("createdtime= null ,");
            }
            if (model.productionDate != null)
            {
                strSql.Append("productionDate='" + model.productionDate + "',");
            }
            else
            {
                strSql.Append("productionDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ST_CurrentStock ");
            strSql.Append(" where id=" + id + "");
            return (strSql.ToString());
        }		


        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

