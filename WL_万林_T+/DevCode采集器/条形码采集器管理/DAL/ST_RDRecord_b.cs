using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:ST_RDRecord_b
    /// </summary>
    public partial class ST_RDRecord_b
    {
        public ST_RDRecord_b()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.ST_RDRecord_b model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.code != null)
            {
                strSql1.Append("code,");
                strSql2.Append("'" + model.code + "',");
            }
            if (model.arrivalQuantity != null)
            {
                strSql1.Append("arrivalQuantity,");
                strSql2.Append("" + model.arrivalQuantity + ",");
            }
            if (model.arrivalQuantity2 != null)
            {
                strSql1.Append("arrivalQuantity2,");
                strSql2.Append("" + model.arrivalQuantity2 + ",");
            }
            if (model.quantity != null)
            {
                strSql1.Append("quantity,");
                strSql2.Append("" + model.quantity + ",");
            }
            if (model.quantity2 != null)
            {
                strSql1.Append("quantity2,");
                strSql2.Append("" + model.quantity2 + ",");
            }
            if (model.compositionQuantity != null)
            {
                strSql1.Append("compositionQuantity,");
                strSql2.Append("'" + model.compositionQuantity + "',");
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
            if (model.price != null)
            {
                strSql1.Append("price,");
                strSql2.Append("" + model.price + ",");
            }
            if (model.price2 != null)
            {
                strSql1.Append("price2,");
                strSql2.Append("" + model.price2 + ",");
            }
            if (model.basePrice != null)
            {
                strSql1.Append("basePrice,");
                strSql2.Append("" + model.basePrice + ",");
            }
            if (model.estimatedPrice2 != null)
            {
                strSql1.Append("estimatedPrice2,");
                strSql2.Append("" + model.estimatedPrice2 + ",");
            }
            if (model.baseEstimatedPrice != null)
            {
                strSql1.Append("baseEstimatedPrice,");
                strSql2.Append("" + model.baseEstimatedPrice + ",");
            }
            if (model.estimatedPrice != null)
            {
                strSql1.Append("estimatedPrice,");
                strSql2.Append("" + model.estimatedPrice + ",");
            }
            if (model.amount != null)
            {
                strSql1.Append("amount,");
                strSql2.Append("" + model.amount + ",");
            }
            if (model.estimatedAmount != null)
            {
                strSql1.Append("estimatedAmount,");
                strSql2.Append("" + model.estimatedAmount + ",");
            }
            if (model.cumulativeSettlementQuantity != null)
            {
                strSql1.Append("cumulativeSettlementQuantity,");
                strSql2.Append("" + model.cumulativeSettlementQuantity + ",");
            }
            if (model.cumulativeSettlementQuantity2 != null)
            {
                strSql1.Append("cumulativeSettlementQuantity2,");
                strSql2.Append("" + model.cumulativeSettlementQuantity2 + ",");
            }
            if (model.cumulativeSettlementBaseQuantity != null)
            {
                strSql1.Append("cumulativeSettlementBaseQuantity,");
                strSql2.Append("" + model.cumulativeSettlementBaseQuantity + ",");
            }
            if (model.cumulativeSettlementSubQuantity != null)
            {
                strSql1.Append("cumulativeSettlementSubQuantity,");
                strSql2.Append("" + model.cumulativeSettlementSubQuantity + ",");
            }
            if (model.cumulativeSettlementAmount != null)
            {
                strSql1.Append("cumulativeSettlementAmount,");
                strSql2.Append("" + model.cumulativeSettlementAmount + ",");
            }
            if (model.taxRate != null)
            {
                strSql1.Append("taxRate,");
                strSql2.Append("" + model.taxRate + ",");
            }
            if (model.taxPrice != null)
            {
                strSql1.Append("taxPrice,");
                strSql2.Append("" + model.taxPrice + ",");
            }
            if (model.tax != null)
            {
                strSql1.Append("tax,");
                strSql2.Append("" + model.tax + ",");
            }
            if (model.taxAmount != null)
            {
                strSql1.Append("taxAmount,");
                strSql2.Append("" + model.taxAmount + ",");
            }
            if (model.changeRate != null)
            {
                strSql1.Append("changeRate,");
                strSql2.Append("" + model.changeRate + ",");
            }
            if (model.receiveAdjust != null)
            {
                strSql1.Append("receiveAdjust,");
                strSql2.Append("" + model.receiveAdjust + ",");
            }
            if (model.dispatchAdjust != null)
            {
                strSql1.Append("dispatchAdjust,");
                strSql2.Append("" + model.dispatchAdjust + ",");
            }
            if (model.feeAdjust != null)
            {
                strSql1.Append("feeAdjust,");
                strSql2.Append("" + model.feeAdjust + ",");
            }
            if (model.totalAmount != null)
            {
                strSql1.Append("totalAmount,");
                strSql2.Append("" + model.totalAmount + ",");
            }
            if (model.feeAmount != null)
            {
                strSql1.Append("feeAmount,");
                strSql2.Append("" + model.feeAmount + ",");
            }
            if (model.materialAmount != null)
            {
                strSql1.Append("materialAmount,");
                strSql2.Append("" + model.materialAmount + ",");
            }
            if (model.sourceVoucherCode != null)
            {
                strSql1.Append("sourceVoucherCode,");
                strSql2.Append("'" + model.sourceVoucherCode + "',");
            }
            if (model.saleOrderCode != null)
            {
                strSql1.Append("saleOrderCode,");
                strSql2.Append("'" + model.saleOrderCode + "',");
            }
            if (model.cumulativePurchaseArrivalQuantity != null)
            {
                strSql1.Append("cumulativePurchaseArrivalQuantity,");
                strSql2.Append("" + model.cumulativePurchaseArrivalQuantity + ",");
            }
            if (model.cumulativePurchaseArrivalQuantity2 != null)
            {
                strSql1.Append("cumulativePurchaseArrivalQuantity2,");
                strSql2.Append("" + model.cumulativePurchaseArrivalQuantity2 + ",");
            }
            if (model.cumulativeSaleDispatchQuantity != null)
            {
                strSql1.Append("cumulativeSaleDispatchQuantity,");
                strSql2.Append("" + model.cumulativeSaleDispatchQuantity + ",");
            }
            if (model.cumulativeSaleDispatchQuantity2 != null)
            {
                strSql1.Append("cumulativeSaleDispatchQuantity2,");
                strSql2.Append("" + model.cumulativeSaleDispatchQuantity2 + ",");
            }
            if (model.batch != null)
            {
                strSql1.Append("batch,");
                strSql2.Append("'" + model.batch + "',");
            }
            if (model.memo != null)
            {
                strSql1.Append("memo,");
                strSql2.Append("'" + model.memo + "',");
            }
            if (model.defectiveQuantity != null)
            {
                strSql1.Append("defectiveQuantity,");
                strSql2.Append("" + model.defectiveQuantity + ",");
            }
            if (model.defectiveQuantity2 != null)
            {
                strSql1.Append("defectiveQuantity2,");
                strSql2.Append("" + model.defectiveQuantity2 + ",");
            }
            if (model.manHour != null)
            {
                strSql1.Append("manHour,");
                strSql2.Append("" + model.manHour + ",");
            }
            if (model.receiveVoucherCode != null)
            {
                strSql1.Append("receiveVoucherCode,");
                strSql2.Append("'" + model.receiveVoucherCode + "',");
            }
            if (model.isManualCost != null)
            {
                strSql1.Append("isManualCost,");
                strSql2.Append("" + model.isManualCost + ",");
            }
            if (model.kitQuantity != null)
            {
                strSql1.Append("kitQuantity,");
                strSql2.Append("" + model.kitQuantity + ",");
            }
            if (model.kitQuantity2 != null)
            {
                strSql1.Append("kitQuantity2,");
                strSql2.Append("" + model.kitQuantity2 + ",");
            }
            if (model.distributedQuantity != null)
            {
                strSql1.Append("distributedQuantity,");
                strSql2.Append("" + model.distributedQuantity + ",");
            }
            if (model.distributedQuantity2 != null)
            {
                strSql1.Append("distributedQuantity2,");
                strSql2.Append("" + model.distributedQuantity2 + ",");
            }
            if (model.isCostAccounted != null)
            {
                strSql1.Append("isCostAccounted,");
                strSql2.Append("" + model.isCostAccounted + ",");
            }
            if (model.taxFlag != null)
            {
                strSql1.Append("taxFlag,");
                strSql2.Append("" + model.taxFlag + ",");
            }
            if (model.inventoryLocation != null)
            {
                strSql1.Append("inventoryLocation,");
                strSql2.Append("'" + model.inventoryLocation + "',");
            }
            if (model.isNoModify != null)
            {
                strSql1.Append("isNoModify,");
                strSql2.Append("'" + model.isNoModify + "',");
            }
            if (model.cumulativeEstimateAmount != null)
            {
                strSql1.Append("cumulativeEstimateAmount,");
                strSql2.Append("" + model.cumulativeEstimateAmount + ",");
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
            if (model.priuserdefnvc1 != null)
            {
                strSql1.Append("priuserdefnvc1,");
                strSql2.Append("'" + model.priuserdefnvc1 + "',");
            }
            if (model.priuserdefdecm1 != null)
            {
                strSql1.Append("priuserdefdecm1,");
                strSql2.Append("" + model.priuserdefdecm1 + ",");
            }
            if (model.priuserdefnvc2 != null)
            {
                strSql1.Append("priuserdefnvc2,");
                strSql2.Append("'" + model.priuserdefnvc2 + "',");
            }
            if (model.priuserdefdecm2 != null)
            {
                strSql1.Append("priuserdefdecm2,");
                strSql2.Append("" + model.priuserdefdecm2 + ",");
            }
            if (model.priuserdefnvc3 != null)
            {
                strSql1.Append("priuserdefnvc3,");
                strSql2.Append("'" + model.priuserdefnvc3 + "',");
            }
            if (model.priuserdefdecm3 != null)
            {
                strSql1.Append("priuserdefdecm3,");
                strSql2.Append("" + model.priuserdefdecm3 + ",");
            }
            if (model.priuserdefnvc4 != null)
            {
                strSql1.Append("priuserdefnvc4,");
                strSql2.Append("'" + model.priuserdefnvc4 + "',");
            }
            if (model.priuserdefdecm4 != null)
            {
                strSql1.Append("priuserdefdecm4,");
                strSql2.Append("" + model.priuserdefdecm4 + ",");
            }
            if (model.pubuserdefnvc1 != null)
            {
                strSql1.Append("pubuserdefnvc1,");
                strSql2.Append("'" + model.pubuserdefnvc1 + "',");
            }
            if (model.pubuserdefdecm1 != null)
            {
                strSql1.Append("pubuserdefdecm1,");
                strSql2.Append("" + model.pubuserdefdecm1 + ",");
            }
            if (model.pubuserdefnvc2 != null)
            {
                strSql1.Append("pubuserdefnvc2,");
                strSql2.Append("'" + model.pubuserdefnvc2 + "',");
            }
            if (model.CustomerInventoryPrice != null)
            {
                strSql1.Append("CustomerInventoryPrice,");
                strSql2.Append("'" + model.CustomerInventoryPrice + "',");
            }
            if (model.pubuserdefdecm2 != null)
            {
                strSql1.Append("pubuserdefdecm2,");
                strSql2.Append("" + model.pubuserdefdecm2 + ",");
            }
            if (model.VendorInventoryPrice != null)
            {
                strSql1.Append("VendorInventoryPrice,");
                strSql2.Append("'" + model.VendorInventoryPrice + "',");
            }
            if (model.pubuserdefnvc3 != null)
            {
                strSql1.Append("pubuserdefnvc3,");
                strSql2.Append("'" + model.pubuserdefnvc3 + "',");
            }
            if (model.InvBarCode != null)
            {
                strSql1.Append("InvBarCode,");
                strSql2.Append("'" + model.InvBarCode + "',");
            }
            if (model.pubuserdefdecm3 != null)
            {
                strSql1.Append("pubuserdefdecm3,");
                strSql2.Append("" + model.pubuserdefdecm3 + ",");
            }
            if (model.pubuserdefnvc4 != null)
            {
                strSql1.Append("pubuserdefnvc4,");
                strSql2.Append("'" + model.pubuserdefnvc4 + "',");
            }
            if (model.pubuserdefdecm4 != null)
            {
                strSql1.Append("pubuserdefdecm4,");
                strSql2.Append("" + model.pubuserdefdecm4 + ",");
            }
            if (model.SourceVoucherCodeByMergedFlow != null)
            {
                strSql1.Append("SourceVoucherCodeByMergedFlow,");
                strSql2.Append("'" + model.SourceVoucherCodeByMergedFlow + "',");
            }
            if (model.VendorInventoryName != null)
            {
                strSql1.Append("VendorInventoryName,");
                strSql2.Append("'" + model.VendorInventoryName + "',");
            }
            if (model.PurchaseOrderCode != null)
            {
                strSql1.Append("PurchaseOrderCode,");
                strSql2.Append("'" + model.PurchaseOrderCode + "',");
            }
            if (model.PartnerInventoryName != null)
            {
                strSql1.Append("PartnerInventoryName,");
                strSql2.Append("'" + model.PartnerInventoryName + "',");
            }
            if (model.ShrinkageQuantity != null)
            {
                strSql1.Append("ShrinkageQuantity,");
                strSql2.Append("" + model.ShrinkageQuantity + ",");
            }
            if (model.ShrinkageQuantity2 != null)
            {
                strSql1.Append("ShrinkageQuantity2,");
                strSql2.Append("" + model.ShrinkageQuantity2 + ",");
            }
            if (model.ShrinkageBaseQuantity != null)
            {
                strSql1.Append("ShrinkageBaseQuantity,");
                strSql2.Append("" + model.ShrinkageBaseQuantity + ",");
            }
            if (model.ShrinkageSubQuantity != null)
            {
                strSql1.Append("ShrinkageSubQuantity,");
                strSql2.Append("" + model.ShrinkageSubQuantity + ",");
            }
            if (model.OrigShrinkageQuantity != null)
            {
                strSql1.Append("OrigShrinkageQuantity,");
                strSql2.Append("" + model.OrigShrinkageQuantity + ",");
            }
            if (model.OrigShrinkageQuantity2 != null)
            {
                strSql1.Append("OrigShrinkageQuantity2,");
                strSql2.Append("" + model.OrigShrinkageQuantity2 + ",");
            }
            if (model.CumPurchaseShrinkageQuantity != null)
            {
                strSql1.Append("CumPurchaseShrinkageQuantity,");
                strSql2.Append("" + model.CumPurchaseShrinkageQuantity + ",");
            }
            if (model.CumPurchaseShrinkageQuantity2 != null)
            {
                strSql1.Append("CumPurchaseShrinkageQuantity2,");
                strSql2.Append("" + model.CumPurchaseShrinkageQuantity2 + ",");
            }
            if (model.productFreeItem0 != null)
            {
                strSql1.Append("productFreeItem0,");
                strSql2.Append("'" + model.productFreeItem0 + "',");
            }
            if (model.productFreeItem1 != null)
            {
                strSql1.Append("productFreeItem1,");
                strSql2.Append("'" + model.productFreeItem1 + "',");
            }
            if (model.productFreeItem2 != null)
            {
                strSql1.Append("productFreeItem2,");
                strSql2.Append("'" + model.productFreeItem2 + "',");
            }
            if (model.productFreeItem3 != null)
            {
                strSql1.Append("productFreeItem3,");
                strSql2.Append("'" + model.productFreeItem3 + "',");
            }
            if (model.productFreeItem4 != null)
            {
                strSql1.Append("productFreeItem4,");
                strSql2.Append("'" + model.productFreeItem4 + "',");
            }
            if (model.productFreeItem5 != null)
            {
                strSql1.Append("productFreeItem5,");
                strSql2.Append("'" + model.productFreeItem5 + "',");
            }
            if (model.productFreeItem6 != null)
            {
                strSql1.Append("productFreeItem6,");
                strSql2.Append("'" + model.productFreeItem6 + "',");
            }
            if (model.productFreeItem7 != null)
            {
                strSql1.Append("productFreeItem7,");
                strSql2.Append("'" + model.productFreeItem7 + "',");
            }
            if (model.productFreeItem8 != null)
            {
                strSql1.Append("productFreeItem8,");
                strSql2.Append("'" + model.productFreeItem8 + "',");
            }
            if (model.productFreeItem9 != null)
            {
                strSql1.Append("productFreeItem9,");
                strSql2.Append("'" + model.productFreeItem9 + "',");
            }
            if (model.origPrice != null)
            {
                strSql1.Append("origPrice,");
                strSql2.Append("" + model.origPrice + ",");
            }
            if (model.origAmount != null)
            {
                strSql1.Append("origAmount,");
                strSql2.Append("" + model.origAmount + ",");
            }
            if (model.origTaxPrice != null)
            {
                strSql1.Append("origTaxPrice,");
                strSql2.Append("" + model.origTaxPrice + ",");
            }
            if (model.origTax != null)
            {
                strSql1.Append("origTax,");
                strSql2.Append("" + model.origTax + ",");
            }
            if (model.origTaxAmount != null)
            {
                strSql1.Append("origTaxAmount,");
                strSql2.Append("" + model.origTaxAmount + ",");
            }
            if (model.origSalePrice != null)
            {
                strSql1.Append("origSalePrice,");
                strSql2.Append("" + model.origSalePrice + ",");
            }
            if (model.origTaxSalePrice != null)
            {
                strSql1.Append("origTaxSalePrice,");
                strSql2.Append("" + model.origTaxSalePrice + ",");
            }
            if (model.origSaleAmount != null)
            {
                strSql1.Append("origSaleAmount,");
                strSql2.Append("" + model.origSaleAmount + ",");
            }
            if (model.origTaxSaleAmount != null)
            {
                strSql1.Append("origTaxSaleAmount,");
                strSql2.Append("" + model.origTaxSaleAmount + ",");
            }
            if (model.salePrice != null)
            {
                strSql1.Append("salePrice,");
                strSql2.Append("" + model.salePrice + ",");
            }
            if (model.taxSalePrice != null)
            {
                strSql1.Append("taxSalePrice,");
                strSql2.Append("" + model.taxSalePrice + ",");
            }
            if (model.saleAmount != null)
            {
                strSql1.Append("saleAmount,");
                strSql2.Append("" + model.saleAmount + ",");
            }
            if (model.taxSaleAmount != null)
            {
                strSql1.Append("taxSaleAmount,");
                strSql2.Append("" + model.taxSaleAmount + ",");
            }
            if (model.ManufactureOrderCode != null)
            {
                strSql1.Append("ManufactureOrderCode,");
                strSql2.Append("'" + model.ManufactureOrderCode + "',");
            }
            if (model.CumReturnQuantity != null)
            {
                strSql1.Append("CumReturnQuantity,");
                strSql2.Append("" + model.CumReturnQuantity + ",");
            }
            if (model.CumReturnQuantity2 != null)
            {
                strSql1.Append("CumReturnQuantity2,");
                strSql2.Append("" + model.CumReturnQuantity2 + ",");
            }
            if (model.OrigManuPrice != null)
            {
                strSql1.Append("OrigManuPrice,");
                strSql2.Append("" + model.OrigManuPrice + ",");
            }
            if (model.OrigManuAmount != null)
            {
                strSql1.Append("OrigManuAmount,");
                strSql2.Append("" + model.OrigManuAmount + ",");
            }
            if (model.OrigTaxManuPrice != null)
            {
                strSql1.Append("OrigTaxManuPrice,");
                strSql2.Append("" + model.OrigTaxManuPrice + ",");
            }
            if (model.OrigTaxManuAmount != null)
            {
                strSql1.Append("OrigTaxManuAmount,");
                strSql2.Append("" + model.OrigTaxManuAmount + ",");
            }
            if (model.ManuPrice != null)
            {
                strSql1.Append("ManuPrice,");
                strSql2.Append("" + model.ManuPrice + ",");
            }
            if (model.ManuAmount != null)
            {
                strSql1.Append("ManuAmount,");
                strSql2.Append("" + model.ManuAmount + ",");
            }
            if (model.TaxManuPrice != null)
            {
                strSql1.Append("TaxManuPrice,");
                strSql2.Append("" + model.TaxManuPrice + ",");
            }
            if (model.TaxManuAmount != null)
            {
                strSql1.Append("TaxManuAmount,");
                strSql2.Append("" + model.TaxManuAmount + ",");
            }
            if (model.ManuFeeDiff != null)
            {
                strSql1.Append("ManuFeeDiff,");
                strSql2.Append("" + model.ManuFeeDiff + ",");
            }
            if (model.OrigManuPrice2 != null)
            {
                strSql1.Append("OrigManuPrice2,");
                strSql2.Append("" + model.OrigManuPrice2 + ",");
            }
            if (model.OrigTaxManuPrice2 != null)
            {
                strSql1.Append("OrigTaxManuPrice2,");
                strSql2.Append("" + model.OrigTaxManuPrice2 + ",");
            }
            if (model.ManuPrice2 != null)
            {
                strSql1.Append("ManuPrice2,");
                strSql2.Append("" + model.ManuPrice2 + ",");
            }
            if (model.TaxManuPrice2 != null)
            {
                strSql1.Append("TaxManuPrice2,");
                strSql2.Append("" + model.TaxManuPrice2 + ",");
            }
            if (model.baseManuPrice != null)
            {
                strSql1.Append("baseManuPrice,");
                strSql2.Append("" + model.baseManuPrice + ",");
            }
            if (model.origPrice2 != null)
            {
                strSql1.Append("origPrice2,");
                strSql2.Append("" + model.origPrice2 + ",");
            }
            if (model.origTaxPrice2 != null)
            {
                strSql1.Append("origTaxPrice2,");
                strSql2.Append("" + model.origTaxPrice2 + ",");
            }
            if (model.TaxPrice2 != null)
            {
                strSql1.Append("TaxPrice2,");
                strSql2.Append("" + model.TaxPrice2 + ",");
            }
            if (model.origSalePrice2 != null)
            {
                strSql1.Append("origSalePrice2,");
                strSql2.Append("" + model.origSalePrice2 + ",");
            }
            if (model.origTaxSalePrice2 != null)
            {
                strSql1.Append("origTaxSalePrice2,");
                strSql2.Append("" + model.origTaxSalePrice2 + ",");
            }
            if (model.salePrice2 != null)
            {
                strSql1.Append("salePrice2,");
                strSql2.Append("" + model.salePrice2 + ",");
            }
            if (model.taxSalePrice2 != null)
            {
                strSql1.Append("taxSalePrice2,");
                strSql2.Append("" + model.taxSalePrice2 + ",");
            }
            if (model.NotSettleQuantity != null)
            {
                strSql1.Append("NotSettleQuantity,");
                strSql2.Append("" + model.NotSettleQuantity + ",");
            }
            if (model.NotSettleQuantity2 != null)
            {
                strSql1.Append("NotSettleQuantity2,");
                strSql2.Append("" + model.NotSettleQuantity2 + ",");
            }
            if (model.SentBaseAmount != null)
            {
                strSql1.Append("SentBaseAmount,");
                strSql2.Append("" + model.SentBaseAmount + ",");
            }
            if (model.SentBaseQuantity != null)
            {
                strSql1.Append("SentBaseQuantity,");
                strSql2.Append("" + model.SentBaseQuantity + ",");
            }
            if (model.docid != null)
            {
                strSql1.Append("docid,");
                strSql2.Append("'" + model.docid + "',");
            }
            if (model.IsPresent != null)
            {
                strSql1.Append("IsPresent,");
                strSql2.Append("" + model.IsPresent + ",");
            }
            if (model.Retailprice != null)
            {
                strSql1.Append("Retailprice,");
                strSql2.Append("" + model.Retailprice + ",");
            }
            if (model.RetailAmount != null)
            {
                strSql1.Append("RetailAmount,");
                strSql2.Append("" + model.RetailAmount + ",");
            }
            if (model.differencequantity != null)
            {
                strSql1.Append("differencequantity,");
                strSql2.Append("" + model.differencequantity + ",");
            }
            if (model.differencequantity2 != null)
            {
                strSql1.Append("differencequantity2,");
                strSql2.Append("" + model.differencequantity2 + ",");
            }
            if (model.BoxNumber != null)
            {
                strSql1.Append("BoxNumber,");
                strSql2.Append("'" + model.BoxNumber + "',");
            }
            if (model.RetailNoTaxPrice != null)
            {
                strSql1.Append("RetailNoTaxPrice,");
                strSql2.Append("" + model.RetailNoTaxPrice + ",");
            }
            if (model.RetailNoTaxAmount != null)
            {
                strSql1.Append("RetailNoTaxAmount,");
                strSql2.Append("" + model.RetailNoTaxAmount + ",");
            }
            if (model.LastModifiedField != null)
            {
                strSql1.Append("LastModifiedField,");
                strSql2.Append("'" + model.LastModifiedField + "',");
            }
            if (model.DiscountRate != null)
            {
                strSql1.Append("DiscountRate,");
                strSql2.Append("" + model.DiscountRate + ",");
            }
            if (model.Discount != null)
            {
                strSql1.Append("Discount,");
                strSql2.Append("" + model.Discount + ",");
            }
            if (model.OrigDiscount != null)
            {
                strSql1.Append("OrigDiscount,");
                strSql2.Append("" + model.OrigDiscount + ",");
            }
            if (model.PriceStrategyTypeName != null)
            {
                strSql1.Append("PriceStrategyTypeName,");
                strSql2.Append("'" + model.PriceStrategyTypeName + "',");
            }
            if (model.PriceStrategySchemeIds != null)
            {
                strSql1.Append("PriceStrategySchemeIds,");
                strSql2.Append("'" + model.PriceStrategySchemeIds + "',");
            }
            if (model.PriceStrategySchemeNames != null)
            {
                strSql1.Append("PriceStrategySchemeNames,");
                strSql2.Append("'" + model.PriceStrategySchemeNames + "',");
            }
            if (model.PromotionVoucherCodes != null)
            {
                strSql1.Append("PromotionVoucherCodes,");
                strSql2.Append("'" + model.PromotionVoucherCodes + "',");
            }
            if (model.PromotionVoucherIds != null)
            {
                strSql1.Append("PromotionVoucherIds,");
                strSql2.Append("'" + model.PromotionVoucherIds + "',");
            }
            if (model.IsPromotionPresent != null)
            {
                strSql1.Append("IsPromotionPresent,");
                strSql2.Append("" + model.IsPromotionPresent + ",");
            }
            if (model.PromotionPresentVoucherCode != null)
            {
                strSql1.Append("PromotionPresentVoucherCode,");
                strSql2.Append("'" + model.PromotionPresentVoucherCode + "',");
            }
            if (model.PromotionSingleVoucherCode != null)
            {
                strSql1.Append("PromotionSingleVoucherCode,");
                strSql2.Append("'" + model.PromotionSingleVoucherCode + "',");
            }
            if (model.PromotionPresentGroupID != null)
            {
                strSql1.Append("PromotionPresentGroupID,");
                strSql2.Append("'" + model.PromotionPresentGroupID + "',");
            }
            if (model.PromotionSingleGroupID != null)
            {
                strSql1.Append("PromotionSingleGroupID,");
                strSql2.Append("'" + model.PromotionSingleGroupID + "',");
            }
            if (model.SuperSourceVoucherTypeCode != null)
            {
                strSql1.Append("SuperSourceVoucherTypeCode,");
                strSql2.Append("'" + model.SuperSourceVoucherTypeCode + "',");
            }
            if (model.idbusiTypeByMergedFlow != null)
            {
                strSql1.Append("idbusiTypeByMergedFlow,");
                strSql2.Append("" + model.idbusiTypeByMergedFlow + ",");
            }
            if (model.idinventory != null)
            {
                strSql1.Append("idinventory,");
                strSql2.Append("" + model.idinventory + ",");
            }
            if (model.idProductInventory != null)
            {
                strSql1.Append("idProductInventory,");
                strSql2.Append("" + model.idProductInventory + ",");
            }
            if (model.IdMarketingOrgan != null)
            {
                strSql1.Append("IdMarketingOrgan,");
                strSql2.Append("" + model.IdMarketingOrgan + ",");
            }
            if (model.idproject != null)
            {
                strSql1.Append("idproject,");
                strSql2.Append("" + model.idproject + ",");
            }
            if (model.PriceStrategyTypeId != null)
            {
                strSql1.Append("PriceStrategyTypeId,");
                strSql2.Append("" + model.PriceStrategyTypeId + ",");
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
            if (model.idunit != null)
            {
                strSql1.Append("idunit,");
                strSql2.Append("" + model.idunit + ",");
            }
            if (model.idunit2 != null)
            {
                strSql1.Append("idunit2,");
                strSql2.Append("" + model.idunit2 + ",");
            }
            if (model.idwarehouse != null)
            {
                strSql1.Append("idwarehouse,");
                strSql2.Append("" + model.idwarehouse + ",");
            }
            if (model.indirectSourceVoucherDetailId != null)
            {
                strSql1.Append("indirectSourceVoucherDetailId,");
                strSql2.Append("" + model.indirectSourceVoucherDetailId + ",");
            }
            if (model.CashbackWay != null)
            {
                strSql1.Append("CashbackWay,");
                strSql2.Append("" + model.CashbackWay + ",");
            }
            if (model.PromotionPresentTypeID != null)
            {
                strSql1.Append("PromotionPresentTypeID,");
                strSql2.Append("" + model.PromotionPresentTypeID + ",");
            }
            if (model.PromotionSingleTypeID != null)
            {
                strSql1.Append("PromotionSingleTypeID,");
                strSql2.Append("" + model.PromotionSingleTypeID + ",");
            }
            if (model.sourceVoucherId != null)
            {
                strSql1.Append("sourceVoucherId,");
                strSql2.Append("" + model.sourceVoucherId + ",");
            }
            if (model.ManufactureOrderId != null)
            {
                strSql1.Append("ManufactureOrderId,");
                strSql2.Append("" + model.ManufactureOrderId + ",");
            }
            if (model.ManufactureOrderDetailId != null)
            {
                strSql1.Append("ManufactureOrderDetailId,");
                strSql2.Append("" + model.ManufactureOrderDetailId + ",");
            }
            if (model.sourceVoucherDetailId != null)
            {
                strSql1.Append("sourceVoucherDetailId,");
                strSql2.Append("" + model.sourceVoucherDetailId + ",");
            }
            if (model.ManufactureOrderMaterialDetailId != null)
            {
                strSql1.Append("ManufactureOrderMaterialDetailId,");
                strSql2.Append("" + model.ManufactureOrderMaterialDetailId + ",");
            }
            if (model.PromotionPresentVoucherID != null)
            {
                strSql1.Append("PromotionPresentVoucherID,");
                strSql2.Append("" + model.PromotionPresentVoucherID + ",");
            }
            if (model.PromotionSingleVoucherID != null)
            {
                strSql1.Append("PromotionSingleVoucherID,");
                strSql2.Append("" + model.PromotionSingleVoucherID + ",");
            }
            if (model.SourceVoucherIdByMergedFlow != null)
            {
                strSql1.Append("SourceVoucherIdByMergedFlow,");
                strSql2.Append("" + model.SourceVoucherIdByMergedFlow + ",");
            }
            if (model.SourceVoucherDetailIdByMergedFlow != null)
            {
                strSql1.Append("SourceVoucherDetailIdByMergedFlow,");
                strSql2.Append("" + model.SourceVoucherDetailIdByMergedFlow + ",");
            }
            if (model.saleOrderId != null)
            {
                strSql1.Append("saleOrderId,");
                strSql2.Append("" + model.saleOrderId + ",");
            }
            if (model.saleOrderDetailId != null)
            {
                strSql1.Append("saleOrderDetailId,");
                strSql2.Append("" + model.saleOrderDetailId + ",");
            }
            if (model.SourceOrderDetailId != null)
            {
                strSql1.Append("SourceOrderDetailId,");
                strSql2.Append("" + model.SourceOrderDetailId + ",");
            }
            if (model.idsourcevouchertype != null)
            {
                strSql1.Append("idsourcevouchertype,");
                strSql2.Append("" + model.idsourcevouchertype + ",");
            }
            if (model.idsourceVoucherTypeByMergedFlow != null)
            {
                strSql1.Append("idsourceVoucherTypeByMergedFlow,");
                strSql2.Append("" + model.idsourceVoucherTypeByMergedFlow + ",");
            }
            if (model.idIndirectSourceVoucherType != null)
            {
                strSql1.Append("idIndirectSourceVoucherType,");
                strSql2.Append("" + model.idIndirectSourceVoucherType + ",");
            }
            if (model.receiveVoucherId != null)
            {
                strSql1.Append("receiveVoucherId,");
                strSql2.Append("" + model.receiveVoucherId + ",");
            }
            if (model.idRDRecordDTO != null)
            {
                strSql1.Append("idRDRecordDTO,");
                strSql2.Append("" + model.idRDRecordDTO + ",");
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
            if (model.receiveDate != null)
            {
                strSql1.Append("receiveDate,");
                strSql2.Append("'" + model.receiveDate + "',");
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
            if (model.ProductionDate != null)
            {
                strSql1.Append("ProductionDate,");
                strSql2.Append("'" + model.ProductionDate + "',");
            }
            if (model.DataSource != null)
            {
                strSql1.Append("DataSource,");
                strSql2.Append("" + model.DataSource + ",");
            }
            strSql.Append("insert into ST_RDRecord_b(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BarCode.Model.ST_RDRecord_b DataRowToModel(DataRow row)
        {
            BarCode.Model.ST_RDRecord_b model = new BarCode.Model.ST_RDRecord_b();
            if (row != null)
            {
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["arrivalQuantity"] != null && row["arrivalQuantity"].ToString() != "")
                {
                    model.arrivalQuantity = decimal.Parse(row["arrivalQuantity"].ToString());
                }
                if (row["arrivalQuantity2"] != null && row["arrivalQuantity2"].ToString() != "")
                {
                    model.arrivalQuantity2 = decimal.Parse(row["arrivalQuantity2"].ToString());
                }
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = decimal.Parse(row["quantity"].ToString());
                }
                if (row["quantity2"] != null && row["quantity2"].ToString() != "")
                {
                    model.quantity2 = decimal.Parse(row["quantity2"].ToString());
                }
                if (row["compositionQuantity"] != null)
                {
                    model.compositionQuantity = row["compositionQuantity"].ToString();
                }
                if (row["baseQuantity"] != null && row["baseQuantity"].ToString() != "")
                {
                    model.baseQuantity = decimal.Parse(row["baseQuantity"].ToString());
                }
                if (row["subQuantity"] != null && row["subQuantity"].ToString() != "")
                {
                    model.subQuantity = decimal.Parse(row["subQuantity"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["price2"] != null && row["price2"].ToString() != "")
                {
                    model.price2 = decimal.Parse(row["price2"].ToString());
                }
                if (row["basePrice"] != null && row["basePrice"].ToString() != "")
                {
                    model.basePrice = decimal.Parse(row["basePrice"].ToString());
                }
                if (row["estimatedPrice2"] != null && row["estimatedPrice2"].ToString() != "")
                {
                    model.estimatedPrice2 = decimal.Parse(row["estimatedPrice2"].ToString());
                }
                if (row["baseEstimatedPrice"] != null && row["baseEstimatedPrice"].ToString() != "")
                {
                    model.baseEstimatedPrice = decimal.Parse(row["baseEstimatedPrice"].ToString());
                }
                if (row["estimatedPrice"] != null && row["estimatedPrice"].ToString() != "")
                {
                    model.estimatedPrice = decimal.Parse(row["estimatedPrice"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(row["amount"].ToString());
                }
                if (row["estimatedAmount"] != null && row["estimatedAmount"].ToString() != "")
                {
                    model.estimatedAmount = decimal.Parse(row["estimatedAmount"].ToString());
                }
                if (row["cumulativeSettlementQuantity"] != null && row["cumulativeSettlementQuantity"].ToString() != "")
                {
                    model.cumulativeSettlementQuantity = decimal.Parse(row["cumulativeSettlementQuantity"].ToString());
                }
                if (row["cumulativeSettlementQuantity2"] != null && row["cumulativeSettlementQuantity2"].ToString() != "")
                {
                    model.cumulativeSettlementQuantity2 = decimal.Parse(row["cumulativeSettlementQuantity2"].ToString());
                }
                if (row["cumulativeSettlementBaseQuantity"] != null && row["cumulativeSettlementBaseQuantity"].ToString() != "")
                {
                    model.cumulativeSettlementBaseQuantity = decimal.Parse(row["cumulativeSettlementBaseQuantity"].ToString());
                }
                if (row["cumulativeSettlementSubQuantity"] != null && row["cumulativeSettlementSubQuantity"].ToString() != "")
                {
                    model.cumulativeSettlementSubQuantity = decimal.Parse(row["cumulativeSettlementSubQuantity"].ToString());
                }
                if (row["cumulativeSettlementAmount"] != null && row["cumulativeSettlementAmount"].ToString() != "")
                {
                    model.cumulativeSettlementAmount = decimal.Parse(row["cumulativeSettlementAmount"].ToString());
                }
                if (row["taxRate"] != null && row["taxRate"].ToString() != "")
                {
                    model.taxRate = decimal.Parse(row["taxRate"].ToString());
                }
                if (row["taxPrice"] != null && row["taxPrice"].ToString() != "")
                {
                    model.taxPrice = decimal.Parse(row["taxPrice"].ToString());
                }
                if (row["tax"] != null && row["tax"].ToString() != "")
                {
                    model.tax = decimal.Parse(row["tax"].ToString());
                }
                if (row["taxAmount"] != null && row["taxAmount"].ToString() != "")
                {
                    model.taxAmount = decimal.Parse(row["taxAmount"].ToString());
                }
                if (row["changeRate"] != null && row["changeRate"].ToString() != "")
                {
                    model.changeRate = decimal.Parse(row["changeRate"].ToString());
                }
                if (row["receiveAdjust"] != null && row["receiveAdjust"].ToString() != "")
                {
                    model.receiveAdjust = decimal.Parse(row["receiveAdjust"].ToString());
                }
                if (row["dispatchAdjust"] != null && row["dispatchAdjust"].ToString() != "")
                {
                    model.dispatchAdjust = decimal.Parse(row["dispatchAdjust"].ToString());
                }
                if (row["feeAdjust"] != null && row["feeAdjust"].ToString() != "")
                {
                    model.feeAdjust = decimal.Parse(row["feeAdjust"].ToString());
                }
                if (row["totalAmount"] != null && row["totalAmount"].ToString() != "")
                {
                    model.totalAmount = decimal.Parse(row["totalAmount"].ToString());
                }
                if (row["feeAmount"] != null && row["feeAmount"].ToString() != "")
                {
                    model.feeAmount = decimal.Parse(row["feeAmount"].ToString());
                }
                if (row["materialAmount"] != null && row["materialAmount"].ToString() != "")
                {
                    model.materialAmount = decimal.Parse(row["materialAmount"].ToString());
                }
                if (row["sourceVoucherCode"] != null)
                {
                    model.sourceVoucherCode = row["sourceVoucherCode"].ToString();
                }
                if (row["saleOrderCode"] != null)
                {
                    model.saleOrderCode = row["saleOrderCode"].ToString();
                }
                if (row["cumulativePurchaseArrivalQuantity"] != null && row["cumulativePurchaseArrivalQuantity"].ToString() != "")
                {
                    model.cumulativePurchaseArrivalQuantity = decimal.Parse(row["cumulativePurchaseArrivalQuantity"].ToString());
                }
                if (row["cumulativePurchaseArrivalQuantity2"] != null && row["cumulativePurchaseArrivalQuantity2"].ToString() != "")
                {
                    model.cumulativePurchaseArrivalQuantity2 = decimal.Parse(row["cumulativePurchaseArrivalQuantity2"].ToString());
                }
                if (row["cumulativeSaleDispatchQuantity"] != null && row["cumulativeSaleDispatchQuantity"].ToString() != "")
                {
                    model.cumulativeSaleDispatchQuantity = decimal.Parse(row["cumulativeSaleDispatchQuantity"].ToString());
                }
                if (row["cumulativeSaleDispatchQuantity2"] != null && row["cumulativeSaleDispatchQuantity2"].ToString() != "")
                {
                    model.cumulativeSaleDispatchQuantity2 = decimal.Parse(row["cumulativeSaleDispatchQuantity2"].ToString());
                }
                if (row["batch"] != null)
                {
                    model.batch = row["batch"].ToString();
                }
                if (row["memo"] != null)
                {
                    model.memo = row["memo"].ToString();
                }
                if (row["defectiveQuantity"] != null && row["defectiveQuantity"].ToString() != "")
                {
                    model.defectiveQuantity = decimal.Parse(row["defectiveQuantity"].ToString());
                }
                if (row["defectiveQuantity2"] != null && row["defectiveQuantity2"].ToString() != "")
                {
                    model.defectiveQuantity2 = decimal.Parse(row["defectiveQuantity2"].ToString());
                }
                if (row["manHour"] != null && row["manHour"].ToString() != "")
                {
                    model.manHour = decimal.Parse(row["manHour"].ToString());
                }
                if (row["receiveVoucherCode"] != null)
                {
                    model.receiveVoucherCode = row["receiveVoucherCode"].ToString();
                }
                if (row["isManualCost"] != null && row["isManualCost"].ToString() != "")
                {
                    model.isManualCost = int.Parse(row["isManualCost"].ToString());
                }
                if (row["kitQuantity"] != null && row["kitQuantity"].ToString() != "")
                {
                    model.kitQuantity = decimal.Parse(row["kitQuantity"].ToString());
                }
                if (row["kitQuantity2"] != null && row["kitQuantity2"].ToString() != "")
                {
                    model.kitQuantity2 = decimal.Parse(row["kitQuantity2"].ToString());
                }
                if (row["distributedQuantity"] != null && row["distributedQuantity"].ToString() != "")
                {
                    model.distributedQuantity = decimal.Parse(row["distributedQuantity"].ToString());
                }
                if (row["distributedQuantity2"] != null && row["distributedQuantity2"].ToString() != "")
                {
                    model.distributedQuantity2 = decimal.Parse(row["distributedQuantity2"].ToString());
                }
                if (row["isCostAccounted"] != null && row["isCostAccounted"].ToString() != "")
                {
                    model.isCostAccounted = int.Parse(row["isCostAccounted"].ToString());
                }
                if (row["taxFlag"] != null && row["taxFlag"].ToString() != "")
                {
                    model.taxFlag = int.Parse(row["taxFlag"].ToString());
                }
                if (row["inventoryLocation"] != null)
                {
                    model.inventoryLocation = row["inventoryLocation"].ToString();
                }
                if (row["isNoModify"] != null)
                {
                    model.isNoModify = row["isNoModify"].ToString();
                }
                if (row["cumulativeEstimateAmount"] != null && row["cumulativeEstimateAmount"].ToString() != "")
                {
                    model.cumulativeEstimateAmount = decimal.Parse(row["cumulativeEstimateAmount"].ToString());
                }
                //if (row["ts"] != null && row["ts"].ToString() != "")
                //{
                //    model.ts = DateTime.Parse(row["ts"].ToString());
                //}
                if (row["updatedBy"] != null)
                {
                    model.updatedBy = row["updatedBy"].ToString();
                }
                if (row["freeItem0"] != null)
                {
                    model.freeItem0 = row["freeItem0"].ToString();
                }
                if (row["freeItem1"] != null)
                {
                    model.freeItem1 = row["freeItem1"].ToString();
                }
                if (row["freeItem2"] != null)
                {
                    model.freeItem2 = row["freeItem2"].ToString();
                }
                if (row["freeItem3"] != null)
                {
                    model.freeItem3 = row["freeItem3"].ToString();
                }
                if (row["freeItem4"] != null)
                {
                    model.freeItem4 = row["freeItem4"].ToString();
                }
                if (row["freeItem5"] != null)
                {
                    model.freeItem5 = row["freeItem5"].ToString();
                }
                if (row["freeItem6"] != null)
                {
                    model.freeItem6 = row["freeItem6"].ToString();
                }
                if (row["freeItem7"] != null)
                {
                    model.freeItem7 = row["freeItem7"].ToString();
                }
                if (row["freeItem8"] != null)
                {
                    model.freeItem8 = row["freeItem8"].ToString();
                }
                if (row["freeItem9"] != null)
                {
                    model.freeItem9 = row["freeItem9"].ToString();
                }
                if (row["priuserdefnvc1"] != null)
                {
                    model.priuserdefnvc1 = row["priuserdefnvc1"].ToString();
                }
                if (row["priuserdefdecm1"] != null && row["priuserdefdecm1"].ToString() != "")
                {
                    model.priuserdefdecm1 = decimal.Parse(row["priuserdefdecm1"].ToString());
                }
                if (row["priuserdefnvc2"] != null)
                {
                    model.priuserdefnvc2 = row["priuserdefnvc2"].ToString();
                }
                if (row["priuserdefdecm2"] != null && row["priuserdefdecm2"].ToString() != "")
                {
                    model.priuserdefdecm2 = decimal.Parse(row["priuserdefdecm2"].ToString());
                }
                if (row["priuserdefnvc3"] != null)
                {
                    model.priuserdefnvc3 = row["priuserdefnvc3"].ToString();
                }
                if (row["priuserdefdecm3"] != null && row["priuserdefdecm3"].ToString() != "")
                {
                    model.priuserdefdecm3 = decimal.Parse(row["priuserdefdecm3"].ToString());
                }
                if (row["priuserdefnvc4"] != null)
                {
                    model.priuserdefnvc4 = row["priuserdefnvc4"].ToString();
                }
                if (row["priuserdefdecm4"] != null && row["priuserdefdecm4"].ToString() != "")
                {
                    model.priuserdefdecm4 = decimal.Parse(row["priuserdefdecm4"].ToString());
                }
                if (row["pubuserdefnvc1"] != null)
                {
                    model.pubuserdefnvc1 = row["pubuserdefnvc1"].ToString();
                }
                if (row["pubuserdefdecm1"] != null && row["pubuserdefdecm1"].ToString() != "")
                {
                    model.pubuserdefdecm1 = decimal.Parse(row["pubuserdefdecm1"].ToString());
                }
                if (row["pubuserdefnvc2"] != null)
                {
                    model.pubuserdefnvc2 = row["pubuserdefnvc2"].ToString();
                }
                if (row["CustomerInventoryPrice"] != null)
                {
                    model.CustomerInventoryPrice = row["CustomerInventoryPrice"].ToString();
                }
                if (row["pubuserdefdecm2"] != null && row["pubuserdefdecm2"].ToString() != "")
                {
                    model.pubuserdefdecm2 = decimal.Parse(row["pubuserdefdecm2"].ToString());
                }
                if (row["VendorInventoryPrice"] != null)
                {
                    model.VendorInventoryPrice = row["VendorInventoryPrice"].ToString();
                }
                if (row["pubuserdefnvc3"] != null)
                {
                    model.pubuserdefnvc3 = row["pubuserdefnvc3"].ToString();
                }
                if (row["InvBarCode"] != null)
                {
                    model.InvBarCode = row["InvBarCode"].ToString();
                }
                if (row["pubuserdefdecm3"] != null && row["pubuserdefdecm3"].ToString() != "")
                {
                    model.pubuserdefdecm3 = decimal.Parse(row["pubuserdefdecm3"].ToString());
                }
                if (row["pubuserdefnvc4"] != null)
                {
                    model.pubuserdefnvc4 = row["pubuserdefnvc4"].ToString();
                }
                if (row["pubuserdefdecm4"] != null && row["pubuserdefdecm4"].ToString() != "")
                {
                    model.pubuserdefdecm4 = decimal.Parse(row["pubuserdefdecm4"].ToString());
                }
                if (row["SourceVoucherCodeByMergedFlow"] != null)
                {
                    model.SourceVoucherCodeByMergedFlow = row["SourceVoucherCodeByMergedFlow"].ToString();
                }
                if (row["VendorInventoryName"] != null)
                {
                    model.VendorInventoryName = row["VendorInventoryName"].ToString();
                }
                if (row["PurchaseOrderCode"] != null)
                {
                    model.PurchaseOrderCode = row["PurchaseOrderCode"].ToString();
                }
                if (row["PartnerInventoryName"] != null)
                {
                    model.PartnerInventoryName = row["PartnerInventoryName"].ToString();
                }
                if (row["ShrinkageQuantity"] != null && row["ShrinkageQuantity"].ToString() != "")
                {
                    model.ShrinkageQuantity = decimal.Parse(row["ShrinkageQuantity"].ToString());
                }
                if (row["ShrinkageQuantity2"] != null && row["ShrinkageQuantity2"].ToString() != "")
                {
                    model.ShrinkageQuantity2 = decimal.Parse(row["ShrinkageQuantity2"].ToString());
                }
                if (row["ShrinkageBaseQuantity"] != null && row["ShrinkageBaseQuantity"].ToString() != "")
                {
                    model.ShrinkageBaseQuantity = decimal.Parse(row["ShrinkageBaseQuantity"].ToString());
                }
                if (row["ShrinkageSubQuantity"] != null && row["ShrinkageSubQuantity"].ToString() != "")
                {
                    model.ShrinkageSubQuantity = decimal.Parse(row["ShrinkageSubQuantity"].ToString());
                }
                if (row["OrigShrinkageQuantity"] != null && row["OrigShrinkageQuantity"].ToString() != "")
                {
                    model.OrigShrinkageQuantity = decimal.Parse(row["OrigShrinkageQuantity"].ToString());
                }
                if (row["OrigShrinkageQuantity2"] != null && row["OrigShrinkageQuantity2"].ToString() != "")
                {
                    model.OrigShrinkageQuantity2 = decimal.Parse(row["OrigShrinkageQuantity2"].ToString());
                }
                if (row["CumPurchaseShrinkageQuantity"] != null && row["CumPurchaseShrinkageQuantity"].ToString() != "")
                {
                    model.CumPurchaseShrinkageQuantity = decimal.Parse(row["CumPurchaseShrinkageQuantity"].ToString());
                }
                if (row["CumPurchaseShrinkageQuantity2"] != null && row["CumPurchaseShrinkageQuantity2"].ToString() != "")
                {
                    model.CumPurchaseShrinkageQuantity2 = decimal.Parse(row["CumPurchaseShrinkageQuantity2"].ToString());
                }
                if (row["productFreeItem0"] != null)
                {
                    model.productFreeItem0 = row["productFreeItem0"].ToString();
                }
                if (row["productFreeItem1"] != null)
                {
                    model.productFreeItem1 = row["productFreeItem1"].ToString();
                }
                if (row["productFreeItem2"] != null)
                {
                    model.productFreeItem2 = row["productFreeItem2"].ToString();
                }
                if (row["productFreeItem3"] != null)
                {
                    model.productFreeItem3 = row["productFreeItem3"].ToString();
                }
                if (row["productFreeItem4"] != null)
                {
                    model.productFreeItem4 = row["productFreeItem4"].ToString();
                }
                if (row["productFreeItem5"] != null)
                {
                    model.productFreeItem5 = row["productFreeItem5"].ToString();
                }
                if (row["productFreeItem6"] != null)
                {
                    model.productFreeItem6 = row["productFreeItem6"].ToString();
                }
                if (row["productFreeItem7"] != null)
                {
                    model.productFreeItem7 = row["productFreeItem7"].ToString();
                }
                if (row["productFreeItem8"] != null)
                {
                    model.productFreeItem8 = row["productFreeItem8"].ToString();
                }
                if (row["productFreeItem9"] != null)
                {
                    model.productFreeItem9 = row["productFreeItem9"].ToString();
                }
                if (row["origPrice"] != null && row["origPrice"].ToString() != "")
                {
                    model.origPrice = decimal.Parse(row["origPrice"].ToString());
                }
                if (row["origAmount"] != null && row["origAmount"].ToString() != "")
                {
                    model.origAmount = decimal.Parse(row["origAmount"].ToString());
                }
                if (row["origTaxPrice"] != null && row["origTaxPrice"].ToString() != "")
                {
                    model.origTaxPrice = decimal.Parse(row["origTaxPrice"].ToString());
                }
                if (row["origTax"] != null && row["origTax"].ToString() != "")
                {
                    model.origTax = decimal.Parse(row["origTax"].ToString());
                }
                if (row["origTaxAmount"] != null && row["origTaxAmount"].ToString() != "")
                {
                    model.origTaxAmount = decimal.Parse(row["origTaxAmount"].ToString());
                }
                if (row["origSalePrice"] != null && row["origSalePrice"].ToString() != "")
                {
                    model.origSalePrice = decimal.Parse(row["origSalePrice"].ToString());
                }
                if (row["origTaxSalePrice"] != null && row["origTaxSalePrice"].ToString() != "")
                {
                    model.origTaxSalePrice = decimal.Parse(row["origTaxSalePrice"].ToString());
                }
                if (row["origSaleAmount"] != null && row["origSaleAmount"].ToString() != "")
                {
                    model.origSaleAmount = decimal.Parse(row["origSaleAmount"].ToString());
                }
                if (row["origTaxSaleAmount"] != null && row["origTaxSaleAmount"].ToString() != "")
                {
                    model.origTaxSaleAmount = decimal.Parse(row["origTaxSaleAmount"].ToString());
                }
                if (row["salePrice"] != null && row["salePrice"].ToString() != "")
                {
                    model.salePrice = decimal.Parse(row["salePrice"].ToString());
                }
                if (row["taxSalePrice"] != null && row["taxSalePrice"].ToString() != "")
                {
                    model.taxSalePrice = decimal.Parse(row["taxSalePrice"].ToString());
                }
                if (row["saleAmount"] != null && row["saleAmount"].ToString() != "")
                {
                    model.saleAmount = decimal.Parse(row["saleAmount"].ToString());
                }
                if (row["taxSaleAmount"] != null && row["taxSaleAmount"].ToString() != "")
                {
                    model.taxSaleAmount = decimal.Parse(row["taxSaleAmount"].ToString());
                }
                if (row["ManufactureOrderCode"] != null)
                {
                    model.ManufactureOrderCode = row["ManufactureOrderCode"].ToString();
                }
                if (row["CumReturnQuantity"] != null && row["CumReturnQuantity"].ToString() != "")
                {
                    model.CumReturnQuantity = decimal.Parse(row["CumReturnQuantity"].ToString());
                }
                if (row["CumReturnQuantity2"] != null && row["CumReturnQuantity2"].ToString() != "")
                {
                    model.CumReturnQuantity2 = decimal.Parse(row["CumReturnQuantity2"].ToString());
                }
                if (row["OrigManuPrice"] != null && row["OrigManuPrice"].ToString() != "")
                {
                    model.OrigManuPrice = decimal.Parse(row["OrigManuPrice"].ToString());
                }
                if (row["OrigManuAmount"] != null && row["OrigManuAmount"].ToString() != "")
                {
                    model.OrigManuAmount = decimal.Parse(row["OrigManuAmount"].ToString());
                }
                if (row["OrigTaxManuPrice"] != null && row["OrigTaxManuPrice"].ToString() != "")
                {
                    model.OrigTaxManuPrice = decimal.Parse(row["OrigTaxManuPrice"].ToString());
                }
                if (row["OrigTaxManuAmount"] != null && row["OrigTaxManuAmount"].ToString() != "")
                {
                    model.OrigTaxManuAmount = decimal.Parse(row["OrigTaxManuAmount"].ToString());
                }
                if (row["ManuPrice"] != null && row["ManuPrice"].ToString() != "")
                {
                    model.ManuPrice = decimal.Parse(row["ManuPrice"].ToString());
                }
                if (row["ManuAmount"] != null && row["ManuAmount"].ToString() != "")
                {
                    model.ManuAmount = decimal.Parse(row["ManuAmount"].ToString());
                }
                if (row["TaxManuPrice"] != null && row["TaxManuPrice"].ToString() != "")
                {
                    model.TaxManuPrice = decimal.Parse(row["TaxManuPrice"].ToString());
                }
                if (row["TaxManuAmount"] != null && row["TaxManuAmount"].ToString() != "")
                {
                    model.TaxManuAmount = decimal.Parse(row["TaxManuAmount"].ToString());
                }
                if (row["ManuFeeDiff"] != null && row["ManuFeeDiff"].ToString() != "")
                {
                    model.ManuFeeDiff = decimal.Parse(row["ManuFeeDiff"].ToString());
                }
                if (row["OrigManuPrice2"] != null && row["OrigManuPrice2"].ToString() != "")
                {
                    model.OrigManuPrice2 = decimal.Parse(row["OrigManuPrice2"].ToString());
                }
                if (row["OrigTaxManuPrice2"] != null && row["OrigTaxManuPrice2"].ToString() != "")
                {
                    model.OrigTaxManuPrice2 = decimal.Parse(row["OrigTaxManuPrice2"].ToString());
                }
                if (row["ManuPrice2"] != null && row["ManuPrice2"].ToString() != "")
                {
                    model.ManuPrice2 = decimal.Parse(row["ManuPrice2"].ToString());
                }
                if (row["TaxManuPrice2"] != null && row["TaxManuPrice2"].ToString() != "")
                {
                    model.TaxManuPrice2 = decimal.Parse(row["TaxManuPrice2"].ToString());
                }
                if (row["baseManuPrice"] != null && row["baseManuPrice"].ToString() != "")
                {
                    model.baseManuPrice = decimal.Parse(row["baseManuPrice"].ToString());
                }
                if (row["origPrice2"] != null && row["origPrice2"].ToString() != "")
                {
                    model.origPrice2 = decimal.Parse(row["origPrice2"].ToString());
                }
                if (row["origTaxPrice2"] != null && row["origTaxPrice2"].ToString() != "")
                {
                    model.origTaxPrice2 = decimal.Parse(row["origTaxPrice2"].ToString());
                }
                if (row["TaxPrice2"] != null && row["TaxPrice2"].ToString() != "")
                {
                    model.TaxPrice2 = decimal.Parse(row["TaxPrice2"].ToString());
                }
                if (row["origSalePrice2"] != null && row["origSalePrice2"].ToString() != "")
                {
                    model.origSalePrice2 = decimal.Parse(row["origSalePrice2"].ToString());
                }
                if (row["origTaxSalePrice2"] != null && row["origTaxSalePrice2"].ToString() != "")
                {
                    model.origTaxSalePrice2 = decimal.Parse(row["origTaxSalePrice2"].ToString());
                }
                if (row["salePrice2"] != null && row["salePrice2"].ToString() != "")
                {
                    model.salePrice2 = decimal.Parse(row["salePrice2"].ToString());
                }
                if (row["taxSalePrice2"] != null && row["taxSalePrice2"].ToString() != "")
                {
                    model.taxSalePrice2 = decimal.Parse(row["taxSalePrice2"].ToString());
                }
                if (row["NotSettleQuantity"] != null && row["NotSettleQuantity"].ToString() != "")
                {
                    model.NotSettleQuantity = decimal.Parse(row["NotSettleQuantity"].ToString());
                }
                if (row["NotSettleQuantity2"] != null && row["NotSettleQuantity2"].ToString() != "")
                {
                    model.NotSettleQuantity2 = decimal.Parse(row["NotSettleQuantity2"].ToString());
                }
                if (row["SentBaseAmount"] != null && row["SentBaseAmount"].ToString() != "")
                {
                    model.SentBaseAmount = decimal.Parse(row["SentBaseAmount"].ToString());
                }
                if (row["SentBaseQuantity"] != null && row["SentBaseQuantity"].ToString() != "")
                {
                    model.SentBaseQuantity = decimal.Parse(row["SentBaseQuantity"].ToString());
                }
                if (row["docid"] != null)
                {
                    model.docid = row["docid"].ToString();
                }
                if (row["IsPresent"] != null && row["IsPresent"].ToString() != "")
                {
                    model.IsPresent = int.Parse(row["IsPresent"].ToString());
                }
                if (row["Retailprice"] != null && row["Retailprice"].ToString() != "")
                {
                    model.Retailprice = decimal.Parse(row["Retailprice"].ToString());
                }
                if (row["RetailAmount"] != null && row["RetailAmount"].ToString() != "")
                {
                    model.RetailAmount = decimal.Parse(row["RetailAmount"].ToString());
                }
                if (row["differencequantity"] != null && row["differencequantity"].ToString() != "")
                {
                    model.differencequantity = decimal.Parse(row["differencequantity"].ToString());
                }
                if (row["differencequantity2"] != null && row["differencequantity2"].ToString() != "")
                {
                    model.differencequantity2 = decimal.Parse(row["differencequantity2"].ToString());
                }
                if (row["BoxNumber"] != null)
                {
                    model.BoxNumber = row["BoxNumber"].ToString();
                }
                if (row["RetailNoTaxPrice"] != null && row["RetailNoTaxPrice"].ToString() != "")
                {
                    model.RetailNoTaxPrice = decimal.Parse(row["RetailNoTaxPrice"].ToString());
                }
                if (row["RetailNoTaxAmount"] != null && row["RetailNoTaxAmount"].ToString() != "")
                {
                    model.RetailNoTaxAmount = decimal.Parse(row["RetailNoTaxAmount"].ToString());
                }
                if (row["LastModifiedField"] != null)
                {
                    model.LastModifiedField = row["LastModifiedField"].ToString();
                }
                if (row["DiscountRate"] != null && row["DiscountRate"].ToString() != "")
                {
                    model.DiscountRate = decimal.Parse(row["DiscountRate"].ToString());
                }
                if (row["Discount"] != null && row["Discount"].ToString() != "")
                {
                    model.Discount = decimal.Parse(row["Discount"].ToString());
                }
                if (row["OrigDiscount"] != null && row["OrigDiscount"].ToString() != "")
                {
                    model.OrigDiscount = decimal.Parse(row["OrigDiscount"].ToString());
                }
                if (row["PriceStrategyTypeName"] != null)
                {
                    model.PriceStrategyTypeName = row["PriceStrategyTypeName"].ToString();
                }
                if (row["PriceStrategySchemeIds"] != null)
                {
                    model.PriceStrategySchemeIds = row["PriceStrategySchemeIds"].ToString();
                }
                if (row["PriceStrategySchemeNames"] != null)
                {
                    model.PriceStrategySchemeNames = row["PriceStrategySchemeNames"].ToString();
                }
                if (row["PromotionVoucherCodes"] != null)
                {
                    model.PromotionVoucherCodes = row["PromotionVoucherCodes"].ToString();
                }
                if (row["PromotionVoucherIds"] != null)
                {
                    model.PromotionVoucherIds = row["PromotionVoucherIds"].ToString();
                }
                if (row["IsPromotionPresent"] != null && row["IsPromotionPresent"].ToString() != "")
                {
                    model.IsPromotionPresent = int.Parse(row["IsPromotionPresent"].ToString());
                }
                if (row["PromotionPresentVoucherCode"] != null)
                {
                    model.PromotionPresentVoucherCode = row["PromotionPresentVoucherCode"].ToString();
                }
                if (row["PromotionSingleVoucherCode"] != null)
                {
                    model.PromotionSingleVoucherCode = row["PromotionSingleVoucherCode"].ToString();
                }
                if (row["PromotionPresentGroupID"] != null)
                {
                    model.PromotionPresentGroupID = row["PromotionPresentGroupID"].ToString();
                }
                if (row["PromotionSingleGroupID"] != null)
                {
                    model.PromotionSingleGroupID = row["PromotionSingleGroupID"].ToString();
                }
                if (row["SuperSourceVoucherTypeCode"] != null)
                {
                    model.SuperSourceVoucherTypeCode = row["SuperSourceVoucherTypeCode"].ToString();
                }
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["idbusiTypeByMergedFlow"] != null && row["idbusiTypeByMergedFlow"].ToString() != "")
                {
                    model.idbusiTypeByMergedFlow = int.Parse(row["idbusiTypeByMergedFlow"].ToString());
                }
                if (row["idinventory"] != null && row["idinventory"].ToString() != "")
                {
                    model.idinventory = int.Parse(row["idinventory"].ToString());
                }
                if (row["idProductInventory"] != null && row["idProductInventory"].ToString() != "")
                {
                    model.idProductInventory = int.Parse(row["idProductInventory"].ToString());
                }
                if (row["IdMarketingOrgan"] != null && row["IdMarketingOrgan"].ToString() != "")
                {
                    model.IdMarketingOrgan = int.Parse(row["IdMarketingOrgan"].ToString());
                }
                if (row["idproject"] != null && row["idproject"].ToString() != "")
                {
                    model.idproject = int.Parse(row["idproject"].ToString());
                }
                if (row["PriceStrategyTypeId"] != null && row["PriceStrategyTypeId"].ToString() != "")
                {
                    model.PriceStrategyTypeId = int.Parse(row["PriceStrategyTypeId"].ToString());
                }
                if (row["idbaseunit"] != null && row["idbaseunit"].ToString() != "")
                {
                    model.idbaseunit = int.Parse(row["idbaseunit"].ToString());
                }
                if (row["idsubunit"] != null && row["idsubunit"].ToString() != "")
                {
                    model.idsubunit = int.Parse(row["idsubunit"].ToString());
                }
                if (row["idunit"] != null && row["idunit"].ToString() != "")
                {
                    model.idunit = int.Parse(row["idunit"].ToString());
                }
                if (row["idunit2"] != null && row["idunit2"].ToString() != "")
                {
                    model.idunit2 = int.Parse(row["idunit2"].ToString());
                }
                if (row["idwarehouse"] != null && row["idwarehouse"].ToString() != "")
                {
                    model.idwarehouse = int.Parse(row["idwarehouse"].ToString());
                }
                if (row["indirectSourceVoucherDetailId"] != null && row["indirectSourceVoucherDetailId"].ToString() != "")
                {
                    model.indirectSourceVoucherDetailId = int.Parse(row["indirectSourceVoucherDetailId"].ToString());
                }
                if (row["CashbackWay"] != null && row["CashbackWay"].ToString() != "")
                {
                    model.CashbackWay = int.Parse(row["CashbackWay"].ToString());
                }
                if (row["PromotionPresentTypeID"] != null && row["PromotionPresentTypeID"].ToString() != "")
                {
                    model.PromotionPresentTypeID = int.Parse(row["PromotionPresentTypeID"].ToString());
                }
                if (row["PromotionSingleTypeID"] != null && row["PromotionSingleTypeID"].ToString() != "")
                {
                    model.PromotionSingleTypeID = int.Parse(row["PromotionSingleTypeID"].ToString());
                }
                if (row["sourceVoucherId"] != null && row["sourceVoucherId"].ToString() != "")
                {
                    model.sourceVoucherId = int.Parse(row["sourceVoucherId"].ToString());
                }
                if (row["ManufactureOrderId"] != null && row["ManufactureOrderId"].ToString() != "")
                {
                    model.ManufactureOrderId = int.Parse(row["ManufactureOrderId"].ToString());
                }
                if (row["ManufactureOrderDetailId"] != null && row["ManufactureOrderDetailId"].ToString() != "")
                {
                    model.ManufactureOrderDetailId = int.Parse(row["ManufactureOrderDetailId"].ToString());
                }
                if (row["sourceVoucherDetailId"] != null && row["sourceVoucherDetailId"].ToString() != "")
                {
                    model.sourceVoucherDetailId = int.Parse(row["sourceVoucherDetailId"].ToString());
                }
                if (row["ManufactureOrderMaterialDetailId"] != null && row["ManufactureOrderMaterialDetailId"].ToString() != "")
                {
                    model.ManufactureOrderMaterialDetailId = int.Parse(row["ManufactureOrderMaterialDetailId"].ToString());
                }
                if (row["PromotionPresentVoucherID"] != null && row["PromotionPresentVoucherID"].ToString() != "")
                {
                    model.PromotionPresentVoucherID = int.Parse(row["PromotionPresentVoucherID"].ToString());
                }
                if (row["PromotionSingleVoucherID"] != null && row["PromotionSingleVoucherID"].ToString() != "")
                {
                    model.PromotionSingleVoucherID = int.Parse(row["PromotionSingleVoucherID"].ToString());
                }
                if (row["SourceVoucherIdByMergedFlow"] != null && row["SourceVoucherIdByMergedFlow"].ToString() != "")
                {
                    model.SourceVoucherIdByMergedFlow = int.Parse(row["SourceVoucherIdByMergedFlow"].ToString());
                }
                if (row["SourceVoucherDetailIdByMergedFlow"] != null && row["SourceVoucherDetailIdByMergedFlow"].ToString() != "")
                {
                    model.SourceVoucherDetailIdByMergedFlow = int.Parse(row["SourceVoucherDetailIdByMergedFlow"].ToString());
                }
                if (row["saleOrderId"] != null && row["saleOrderId"].ToString() != "")
                {
                    model.saleOrderId = int.Parse(row["saleOrderId"].ToString());
                }
                if (row["saleOrderDetailId"] != null && row["saleOrderDetailId"].ToString() != "")
                {
                    model.saleOrderDetailId = int.Parse(row["saleOrderDetailId"].ToString());
                }
                if (row["SourceOrderDetailId"] != null && row["SourceOrderDetailId"].ToString() != "")
                {
                    model.SourceOrderDetailId = int.Parse(row["SourceOrderDetailId"].ToString());
                }
                if (row["idsourcevouchertype"] != null && row["idsourcevouchertype"].ToString() != "")
                {
                    model.idsourcevouchertype = int.Parse(row["idsourcevouchertype"].ToString());
                }
                if (row["idsourceVoucherTypeByMergedFlow"] != null && row["idsourceVoucherTypeByMergedFlow"].ToString() != "")
                {
                    model.idsourceVoucherTypeByMergedFlow = int.Parse(row["idsourceVoucherTypeByMergedFlow"].ToString());
                }
                if (row["idIndirectSourceVoucherType"] != null && row["idIndirectSourceVoucherType"].ToString() != "")
                {
                    model.idIndirectSourceVoucherType = int.Parse(row["idIndirectSourceVoucherType"].ToString());
                }
                if (row["receiveVoucherId"] != null && row["receiveVoucherId"].ToString() != "")
                {
                    model.receiveVoucherId = int.Parse(row["receiveVoucherId"].ToString());
                }
                if (row["idRDRecordDTO"] != null && row["idRDRecordDTO"].ToString() != "")
                {
                    model.idRDRecordDTO = int.Parse(row["idRDRecordDTO"].ToString());
                }
                if (row["receiveVoucherDetailId"] != null && row["receiveVoucherDetailId"].ToString() != "")
                {
                    model.receiveVoucherDetailId = int.Parse(row["receiveVoucherDetailId"].ToString());
                }
                if (row["expiryDate"] != null && row["expiryDate"].ToString() != "")
                {
                    model.expiryDate = DateTime.Parse(row["expiryDate"].ToString());
                }
                if (row["receiveDate"] != null && row["receiveDate"].ToString() != "")
                {
                    model.receiveDate = DateTime.Parse(row["receiveDate"].ToString());
                }
                if (row["createdtime"] != null && row["createdtime"].ToString() != "")
                {
                    model.createdtime = DateTime.Parse(row["createdtime"].ToString());
                }
                if (row["updated"] != null && row["updated"].ToString() != "")
                {
                    model.updated = DateTime.Parse(row["updated"].ToString());
                }
                if (row["ProductionDate"] != null && row["ProductionDate"].ToString() != "")
                {
                    model.ProductionDate = DateTime.Parse(row["ProductionDate"].ToString());
                }
                if (row["DataSource"] != null && row["DataSource"].ToString() != "")
                {
                    model.DataSource = int.Parse(row["DataSource"].ToString());
                }
            }
            return model;
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

