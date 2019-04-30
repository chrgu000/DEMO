using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:ST_RDRecord
    /// </summary>
    public partial class ST_RDRecord
    {
        public ST_RDRecord()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.ST_RDRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.code != null)
            {
                strSql1.Append("code,");
                strSql2.Append("'" + model.code + "',");
            }
            if (model.dispatchAddress != null)
            {
                strSql1.Append("dispatchAddress,");
                strSql2.Append("'" + model.dispatchAddress + "',");
            }
            if (model.contact != null)
            {
                strSql1.Append("contact,");
                strSql2.Append("'" + model.contact + "',");
            }
            if (model.contactPhone != null)
            {
                strSql1.Append("contactPhone,");
                strSql2.Append("'" + model.contactPhone + "',");
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
            if (model.purchaseArrivalCode != null)
            {
                strSql1.Append("purchaseArrivalCode,");
                strSql2.Append("'" + model.purchaseArrivalCode + "',");
            }
            if (model.productReceiveCode != null)
            {
                strSql1.Append("productReceiveCode,");
                strSql2.Append("'" + model.productReceiveCode + "',");
            }
            if (model.saleDeliveryCode != null)
            {
                strSql1.Append("saleDeliveryCode,");
                strSql2.Append("'" + model.saleDeliveryCode + "',");
            }
            if (model.printTime != null)
            {
                strSql1.Append("printTime,");
                strSql2.Append("" + model.printTime + ",");
            }
            if (model.amount != null)
            {
                strSql1.Append("amount,");
                strSql2.Append("" + model.amount + ",");
            }
            if (model.rdDirectionFlag != null)
            {
                strSql1.Append("rdDirectionFlag,");
                strSql2.Append("" + model.rdDirectionFlag + ",");
            }
            if (model.isCostAccount != null)
            {
                strSql1.Append("isCostAccount,");
                strSql2.Append("" + model.isCostAccount + ",");
            }
            if (model.isMergedFlow != null)
            {
                strSql1.Append("isMergedFlow,");
                strSql2.Append("" + model.isMergedFlow + ",");
            }
            if (model.isAutoGenerate != null)
            {
                strSql1.Append("isAutoGenerate,");
                strSql2.Append("" + model.isAutoGenerate + ",");
            }
            if (model.memo != null)
            {
                strSql1.Append("memo,");
                strSql2.Append("'" + model.memo + "',");
            }
            if (model.isNoModify != null)
            {
                strSql1.Append("isNoModify,");
                strSql2.Append("'" + model.isNoModify + "',");
            }
            if (model.maker != null)
            {
                strSql1.Append("maker,");
                strSql2.Append("'" + model.maker + "',");
            }
            if (model.auditor != null)
            {
                strSql1.Append("auditor,");
                strSql2.Append("'" + model.auditor + "',");
            }
            if (model.reviser != null)
            {
                strSql1.Append("reviser,");
                strSql2.Append("'" + model.reviser + "',");
            }
            if (model.iscarriedforwardout != null)
            {
                strSql1.Append("iscarriedforwardout,");
                strSql2.Append("" + model.iscarriedforwardout + ",");
            }
            if (model.iscarriedforwardin != null)
            {
                strSql1.Append("iscarriedforwardin,");
                strSql2.Append("" + model.iscarriedforwardin + ",");
            }
            if (model.ismodifiedcode != null)
            {
                strSql1.Append("ismodifiedcode,");
                strSql2.Append("" + model.ismodifiedcode + ",");
            }
            if (model.accountingperiod != null)
            {
                strSql1.Append("accountingperiod,");
                strSql2.Append("" + model.accountingperiod + ",");
            }
            if (model.docid != null)
            {
                strSql1.Append("docid,");
                strSql2.Append("'" + model.docid + "',");
            }
            if (model.accountingyear != null)
            {
                strSql1.Append("accountingyear,");
                strSql2.Append("" + model.accountingyear + ",");
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
            if (model.priuserdefnvc5 != null)
            {
                strSql1.Append("priuserdefnvc5,");
                strSql2.Append("'" + model.priuserdefnvc5 + "',");
            }
            if (model.priuserdefdecm5 != null)
            {
                strSql1.Append("priuserdefdecm5,");
                strSql2.Append("" + model.priuserdefdecm5 + ",");
            }
            if (model.priuserdefnvc6 != null)
            {
                strSql1.Append("priuserdefnvc6,");
                strSql2.Append("'" + model.priuserdefnvc6 + "',");
            }
            if (model.priuserdefdecm6 != null)
            {
                strSql1.Append("priuserdefdecm6,");
                strSql2.Append("" + model.priuserdefdecm6 + ",");
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
            if (model.pubuserdefdecm2 != null)
            {
                strSql1.Append("pubuserdefdecm2,");
                strSql2.Append("" + model.pubuserdefdecm2 + ",");
            }
            if (model.pubuserdefnvc3 != null)
            {
                strSql1.Append("pubuserdefnvc3,");
                strSql2.Append("'" + model.pubuserdefnvc3 + "',");
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
            if (model.pubuserdefnvc5 != null)
            {
                strSql1.Append("pubuserdefnvc5,");
                strSql2.Append("'" + model.pubuserdefnvc5 + "',");
            }
            if (model.pubuserdefdecm5 != null)
            {
                strSql1.Append("pubuserdefdecm5,");
                strSql2.Append("" + model.pubuserdefdecm5 + ",");
            }
            if (model.pubuserdefnvc6 != null)
            {
                strSql1.Append("pubuserdefnvc6,");
                strSql2.Append("'" + model.pubuserdefnvc6 + "',");
            }
            if (model.pubuserdefdecm6 != null)
            {
                strSql1.Append("pubuserdefdecm6,");
                strSql2.Append("" + model.pubuserdefdecm6 + ",");
            }
            if (model.VoucherYear != null)
            {
                strSql1.Append("VoucherYear,");
                strSql2.Append("" + model.VoucherYear + ",");
            }
            if (model.VoucherPeriod != null)
            {
                strSql1.Append("VoucherPeriod,");
                strSql2.Append("" + model.VoucherPeriod + ",");
            }
            if (model.SourceVoucherDate != null)
            {
                strSql1.Append("SourceVoucherDate,");
                strSql2.Append("'" + model.SourceVoucherDate + "',");
            }
            if (model.exchangeRate != null)
            {
                strSql1.Append("exchangeRate,");
                strSql2.Append("" + model.exchangeRate + ",");
            }
            if (model.ManufactureOrderCode != null)
            {
                strSql1.Append("ManufactureOrderCode,");
                strSql2.Append("'" + model.ManufactureOrderCode + "',");
            }
            if (model.DelegateDispatchCode != null)
            {
                strSql1.Append("DelegateDispatchCode,");
                strSql2.Append("'" + model.DelegateDispatchCode + "',");
            }
            if (model.BeforeUpgrade != null)
            {
                strSql1.Append("BeforeUpgrade,");
                strSql2.Append("'" + model.BeforeUpgrade + "',");
            }
            if (model.TotalOrigTaxAmount != null)
            {
                strSql1.Append("TotalOrigTaxAmount,");
                strSql2.Append("" + model.TotalOrigTaxAmount + ",");
            }
            if (model.TotalTaxAmount != null)
            {
                strSql1.Append("TotalTaxAmount,");
                strSql2.Append("" + model.TotalTaxAmount + ",");
            }
            if (model.PrintCount != null)
            {
                strSql1.Append("PrintCount,");
                strSql2.Append("" + model.PrintCount + ",");
            }
            if (model.Mobilephone != null)
            {
                strSql1.Append("Mobilephone,");
                strSql2.Append("'" + model.Mobilephone + "',");
            }
            if (model.Address != null)
            {
                strSql1.Append("Address,");
                strSql2.Append("'" + model.Address + "',");
            }
            if (model.ExternalCode != null)
            {
                strSql1.Append("ExternalCode,");
                strSql2.Append("'" + model.ExternalCode + "',");
            }
            if (model.idbusitype != null)
            {
                strSql1.Append("idbusitype,");
                strSql2.Append("" + model.idbusitype + ",");
            }
            if (model.idcurrency != null)
            {
                strSql1.Append("idcurrency,");
                strSql2.Append("" + model.idcurrency + ",");
            }
            if (model.iddepartment != null)
            {
                strSql1.Append("iddepartment,");
                strSql2.Append("" + model.iddepartment + ",");
            }
            if (model.iddistrict != null)
            {
                strSql1.Append("iddistrict,");
                strSql2.Append("" + model.iddistrict + ",");
            }
            if (model.idmember != null)
            {
                strSql1.Append("idmember,");
                strSql2.Append("" + model.idmember + ",");
            }
            if (model.IdStore != null)
            {
                strSql1.Append("IdStore,");
                strSql2.Append("" + model.IdStore + ",");
            }
            if (model.IdMarketingOrgan != null)
            {
                strSql1.Append("IdMarketingOrgan,");
                strSql2.Append("" + model.IdMarketingOrgan + ",");
            }
            if (model.idpartner != null)
            {
                strSql1.Append("idpartner,");
                strSql2.Append("" + model.idpartner + ",");
            }
            if (model.idsettleCustomer != null)
            {
                strSql1.Append("idsettleCustomer,");
                strSql2.Append("" + model.idsettleCustomer + ",");
            }
            if (model.idclerk != null)
            {
                strSql1.Append("idclerk,");
                strSql2.Append("" + model.idclerk + ",");
            }
            if (model.idqualityinspector != null)
            {
                strSql1.Append("idqualityinspector,");
                strSql2.Append("" + model.idqualityinspector + ",");
            }
            if (model.idproject != null)
            {
                strSql1.Append("idproject,");
                strSql2.Append("" + model.idproject + ",");
            }
            if (model.idrdstyle != null)
            {
                strSql1.Append("idrdstyle,");
                strSql2.Append("" + model.idrdstyle + ",");
            }
            if (model.idinwarehouse != null)
            {
                strSql1.Append("idinwarehouse,");
                strSql2.Append("" + model.idinwarehouse + ",");
            }
            if (model.idwarehouse != null)
            {
                strSql1.Append("idwarehouse,");
                strSql2.Append("" + model.idwarehouse + ",");
            }
            if (model.idCollaborateUpVoucherType != null)
            {
                strSql1.Append("idCollaborateUpVoucherType,");
                strSql2.Append("" + model.idCollaborateUpVoucherType + ",");
            }
            if (model.idCollaborateUpVoucher != null)
            {
                strSql1.Append("idCollaborateUpVoucher,");
                strSql2.Append("" + model.idCollaborateUpVoucher + ",");
            }
            if (model.accountState != null)
            {
                strSql1.Append("accountState,");
                strSql2.Append("" + model.accountState + ",");
            }
            if (model.deliveryState != null)
            {
                strSql1.Append("deliveryState,");
                strSql2.Append("" + model.deliveryState + ",");
            }
            if (model.settleStatus != null)
            {
                strSql1.Append("settleStatus,");
                strSql2.Append("" + model.settleStatus + ",");
            }
            if (model.transportType != null)
            {
                strSql1.Append("transportType,");
                strSql2.Append("" + model.transportType + ",");
            }
            if (model.voucherState != null)
            {
                strSql1.Append("voucherState,");
                strSql2.Append("" + model.voucherState + ",");
            }
            if (model.auditorid != null)
            {
                strSql1.Append("auditorid,");
                strSql2.Append("" + model.auditorid + ",");
            }
            if (model.makerid != null)
            {
                strSql1.Append("makerid,");
                strSql2.Append("" + model.makerid + ",");
            }
            if (model.sourceVoucherId != null)
            {
                strSql1.Append("sourceVoucherId,");
                strSql2.Append("" + model.sourceVoucherId + ",");
            }
            if (model.purchaseArrivalId != null)
            {
                strSql1.Append("purchaseArrivalId,");
                strSql2.Append("" + model.purchaseArrivalId + ",");
            }
            if (model.saleDeliveryId != null)
            {
                strSql1.Append("saleDeliveryId,");
                strSql2.Append("" + model.saleDeliveryId + ",");
            }
            if (model.saleOrderId != null)
            {
                strSql1.Append("saleOrderId,");
                strSql2.Append("" + model.saleOrderId + ",");
            }
            if (model.idsourcevouchertype != null)
            {
                strSql1.Append("idsourcevouchertype,");
                strSql2.Append("" + model.idsourcevouchertype + ",");
            }
            if (model.idvouchertype != null)
            {
                strSql1.Append("idvouchertype,");
                strSql2.Append("" + model.idvouchertype + ",");
            }
            if (model.productReceiveId != null)
            {
                strSql1.Append("productReceiveId,");
                strSql2.Append("" + model.productReceiveId + ",");
            }
            if (model.maturityDate != null)
            {
                strSql1.Append("maturityDate,");
                strSql2.Append("'" + model.maturityDate + "',");
            }
            if (model.voucherdate != null)
            {
                strSql1.Append("voucherdate,");
                strSql2.Append("'" + model.voucherdate + "',");
            }
            if (model.madedate != null)
            {
                strSql1.Append("madedate,");
                strSql2.Append("'" + model.madedate + "',");
            }
            if (model.auditeddate != null)
            {
                strSql1.Append("auditeddate,");
                strSql2.Append("'" + model.auditeddate + "',");
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
            if (model.DataSource != null)
            {
                strSql1.Append("DataSource,");
                strSql2.Append("" + model.DataSource + ",");
            }
            strSql.Append("insert into ST_RDRecord(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

