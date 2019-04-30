using System;
namespace BarCode.Model
{
    /// <summary>
    /// ST_RDRecord_b:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ST_RDRecord_b
    {
        public ST_RDRecord_b()
        { }
        #region Model
        private string _code;
        private decimal? _arrivalquantity;
        private decimal? _arrivalquantity2;
        private decimal? _quantity;
        private decimal? _quantity2;
        private string _compositionquantity;
        private decimal? _basequantity;
        private decimal? _subquantity;
        private decimal? _price;
        private decimal? _price2;
        private decimal? _baseprice;
        private decimal? _estimatedprice2;
        private decimal? _baseestimatedprice;
        private decimal? _estimatedprice;
        private decimal _amount;
        private decimal? _estimatedamount;
        private decimal? _cumulativesettlementquantity;
        private decimal? _cumulativesettlementquantity2;
        private decimal? _cumulativesettlementbasequantity;
        private decimal? _cumulativesettlementsubquantity;
        private decimal? _cumulativesettlementamount;
        private decimal? _taxrate;
        private decimal? _taxprice;
        private decimal? _tax;
        private decimal? _taxamount;
        private decimal? _changerate;
        private decimal? _receiveadjust;
        private decimal _dispatchadjust;
        private decimal? _feeadjust;
        private decimal? _totalamount;
        private decimal? _feeamount;
        private decimal? _materialamount;
        private string _sourcevouchercode;
        private string _saleordercode;
        private decimal? _cumulativepurchasearrivalquantity;
        private decimal? _cumulativepurchasearrivalquantity2;
        private decimal? _cumulativesaledispatchquantity;
        private decimal? _cumulativesaledispatchquantity2;
        private string _batch;
        private string _memo;
        private decimal? _defectivequantity;
        private decimal? _defectivequantity2;
        private decimal? _manhour;
        private string _receivevouchercode;
        private int? _ismanualcost;
        private decimal? _kitquantity;
        private decimal? _kitquantity2;
        private decimal? _distributedquantity;
        private decimal? _distributedquantity2;
        private int? _iscostaccounted;
        private int? _taxflag;
        private string _inventorylocation;
        private string _isnomodify;
        private decimal? _cumulativeestimateamount;
        private DateTime? _ts;
        private string _updatedby;
        private string _freeitem0;
        private string _freeitem1;
        private string _freeitem2;
        private string _freeitem3;
        private string _freeitem4;
        private string _freeitem5;
        private string _freeitem6;
        private string _freeitem7;
        private string _freeitem8;
        private string _freeitem9;
        private string _priuserdefnvc1;
        private decimal? _priuserdefdecm1;
        private string _priuserdefnvc2;
        private decimal? _priuserdefdecm2;
        private string _priuserdefnvc3;
        private decimal? _priuserdefdecm3;
        private string _priuserdefnvc4;
        private decimal? _priuserdefdecm4;
        private string _pubuserdefnvc1;
        private decimal? _pubuserdefdecm1;
        private string _pubuserdefnvc2;
        private string _customerinventoryprice;
        private decimal? _pubuserdefdecm2;
        private string _vendorinventoryprice;
        private string _pubuserdefnvc3;
        private string _invbarcode;
        private decimal? _pubuserdefdecm3;
        private string _pubuserdefnvc4;
        private decimal? _pubuserdefdecm4;
        private string _sourcevouchercodebymergedflow;
        private string _vendorinventoryname;
        private string _purchaseordercode;
        private string _partnerinventoryname;
        private decimal? _shrinkagequantity;
        private decimal? _shrinkagequantity2;
        private decimal? _shrinkagebasequantity;
        private decimal? _shrinkagesubquantity;
        private decimal? _origshrinkagequantity;
        private decimal? _origshrinkagequantity2;
        private decimal? _cumpurchaseshrinkagequantity;
        private decimal? _cumpurchaseshrinkagequantity2;
        private string _productfreeitem0;
        private string _productfreeitem1;
        private string _productfreeitem2;
        private string _productfreeitem3;
        private string _productfreeitem4;
        private string _productfreeitem5;
        private string _productfreeitem6;
        private string _productfreeitem7;
        private string _productfreeitem8;
        private string _productfreeitem9;
        private decimal? _origprice;
        private decimal? _origamount;
        private decimal? _origtaxprice;
        private decimal? _origtax;
        private decimal? _origtaxamount;
        private decimal? _origsaleprice;
        private decimal? _origtaxsaleprice;
        private decimal? _origsaleamount;
        private decimal? _origtaxsaleamount;
        private decimal? _saleprice;
        private decimal? _taxsaleprice;
        private decimal? _saleamount;
        private decimal? _taxsaleamount;
        private string _manufactureordercode;
        private decimal? _cumreturnquantity;
        private decimal? _cumreturnquantity2;
        private decimal? _origmanuprice;
        private decimal? _origmanuamount;
        private decimal? _origtaxmanuprice;
        private decimal? _origtaxmanuamount;
        private decimal? _manuprice;
        private decimal? _manuamount;
        private decimal? _taxmanuprice;
        private decimal? _taxmanuamount;
        private decimal? _manufeediff;
        private decimal? _origmanuprice2;
        private decimal? _origtaxmanuprice2;
        private decimal? _manuprice2;
        private decimal? _taxmanuprice2;
        private decimal? _basemanuprice;
        private decimal? _origprice2;
        private decimal? _origtaxprice2;
        private decimal? _taxprice2;
        private decimal? _origsaleprice2;
        private decimal? _origtaxsaleprice2;
        private decimal? _saleprice2;
        private decimal? _taxsaleprice2;
        private decimal? _notsettlequantity;
        private decimal? _notsettlequantity2;
        private decimal? _sentbaseamount;
        private decimal? _sentbasequantity;
        private string _docid;
        private int? _ispresent;
        private decimal? _retailprice;
        private decimal? _retailamount;
        private decimal? _differencequantity;
        private decimal? _differencequantity2;
        private string _boxnumber;
        private decimal? _retailnotaxprice;
        private decimal? _retailnotaxamount;
        private string _lastmodifiedfield;
        private decimal? _discountrate;
        private decimal? _discount;
        private decimal? _origdiscount;
        private string _pricestrategytypename;
        private string _pricestrategyschemeids;
        private string _pricestrategyschemenames;
        private string _promotionvouchercodes;
        private string _promotionvoucherids;
        private int? _ispromotionpresent;
        private string _promotionpresentvouchercode;
        private string _promotionsinglevouchercode;
        private string _promotionpresentgroupid;
        private string _promotionsinglegroupid;
        private string _supersourcevouchertypecode;
        private int _id;
        private int? _idbusitypebymergedflow;
        private int _idinventory;
        private int _idproductinventory;
        private int? _idmarketingorgan;
        private int _idproject;
        private int? _pricestrategytypeid;
        private int? _idbaseunit;
        private int? _idsubunit;
        private int? _idunit;
        private int? _idunit2;
        private int _idwarehouse;
        private int? _indirectsourcevoucherdetailid;
        private int? _cashbackway;
        private int _promotionpresenttypeid;
        private int _promotionsingletypeid;
        private int _sourcevoucherid;
        private int? _manufactureorderid;
        private int? _manufactureorderdetailid;
        private int _sourcevoucherdetailid;
        private int? _manufactureordermaterialdetailid;
        private int? _promotionpresentvoucherid;
        private int? _promotionsinglevoucherid;
        private int? _sourcevoucheridbymergedflow;
        private int? _sourcevoucherdetailidbymergedflow;
        private int? _saleorderid;
        private int? _saleorderdetailid;
        private int? _sourceorderdetailid;
        private int _idsourcevouchertype;
        private int _idsourcevouchertypebymergedflow;
        private int? _idindirectsourcevouchertype;
        private int _receivevoucherid;
        private int _idrdrecorddto;
        private int? _receivevoucherdetailid;
        private DateTime? _expirydate;
        private DateTime? _receivedate;
        private DateTime? _createdtime;
        private DateTime _updated;
        private DateTime? _productiondate;
        private int? _datasource = null;
        /// <summary>
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? arrivalQuantity
        {
            set { _arrivalquantity = value; }
            get { return _arrivalquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? arrivalQuantity2
        {
            set { _arrivalquantity2 = value; }
            get { return _arrivalquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity2
        {
            set { _quantity2 = value; }
            get { return _quantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string compositionQuantity
        {
            set { _compositionquantity = value; }
            get { return _compositionquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? baseQuantity
        {
            set { _basequantity = value; }
            get { return _basequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? subQuantity
        {
            set { _subquantity = value; }
            get { return _subquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price2
        {
            set { _price2 = value; }
            get { return _price2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? basePrice
        {
            set { _baseprice = value; }
            get { return _baseprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? estimatedPrice2
        {
            set { _estimatedprice2 = value; }
            get { return _estimatedprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? baseEstimatedPrice
        {
            set { _baseestimatedprice = value; }
            get { return _baseestimatedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? estimatedPrice
        {
            set { _estimatedprice = value; }
            get { return _estimatedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? estimatedAmount
        {
            set { _estimatedamount = value; }
            get { return _estimatedamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeSettlementQuantity
        {
            set { _cumulativesettlementquantity = value; }
            get { return _cumulativesettlementquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeSettlementQuantity2
        {
            set { _cumulativesettlementquantity2 = value; }
            get { return _cumulativesettlementquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeSettlementBaseQuantity
        {
            set { _cumulativesettlementbasequantity = value; }
            get { return _cumulativesettlementbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeSettlementSubQuantity
        {
            set { _cumulativesettlementsubquantity = value; }
            get { return _cumulativesettlementsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeSettlementAmount
        {
            set { _cumulativesettlementamount = value; }
            get { return _cumulativesettlementamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? taxRate
        {
            set { _taxrate = value; }
            get { return _taxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? taxPrice
        {
            set { _taxprice = value; }
            get { return _taxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tax
        {
            set { _tax = value; }
            get { return _tax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? taxAmount
        {
            set { _taxamount = value; }
            get { return _taxamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? changeRate
        {
            set { _changerate = value; }
            get { return _changerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? receiveAdjust
        {
            set { _receiveadjust = value; }
            get { return _receiveadjust; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dispatchAdjust
        {
            set { _dispatchadjust = value; }
            get { return _dispatchadjust; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? feeAdjust
        {
            set { _feeadjust = value; }
            get { return _feeadjust; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? totalAmount
        {
            set { _totalamount = value; }
            get { return _totalamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? feeAmount
        {
            set { _feeamount = value; }
            get { return _feeamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? materialAmount
        {
            set { _materialamount = value; }
            get { return _materialamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sourceVoucherCode
        {
            set { _sourcevouchercode = value; }
            get { return _sourcevouchercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saleOrderCode
        {
            set { _saleordercode = value; }
            get { return _saleordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativePurchaseArrivalQuantity
        {
            set { _cumulativepurchasearrivalquantity = value; }
            get { return _cumulativepurchasearrivalquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativePurchaseArrivalQuantity2
        {
            set { _cumulativepurchasearrivalquantity2 = value; }
            get { return _cumulativepurchasearrivalquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeSaleDispatchQuantity
        {
            set { _cumulativesaledispatchquantity = value; }
            get { return _cumulativesaledispatchquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeSaleDispatchQuantity2
        {
            set { _cumulativesaledispatchquantity2 = value; }
            get { return _cumulativesaledispatchquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? defectiveQuantity
        {
            set { _defectivequantity = value; }
            get { return _defectivequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? defectiveQuantity2
        {
            set { _defectivequantity2 = value; }
            get { return _defectivequantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? manHour
        {
            set { _manhour = value; }
            get { return _manhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string receiveVoucherCode
        {
            set { _receivevouchercode = value; }
            get { return _receivevouchercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isManualCost
        {
            set { _ismanualcost = value; }
            get { return _ismanualcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? kitQuantity
        {
            set { _kitquantity = value; }
            get { return _kitquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? kitQuantity2
        {
            set { _kitquantity2 = value; }
            get { return _kitquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? distributedQuantity
        {
            set { _distributedquantity = value; }
            get { return _distributedquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? distributedQuantity2
        {
            set { _distributedquantity2 = value; }
            get { return _distributedquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isCostAccounted
        {
            set { _iscostaccounted = value; }
            get { return _iscostaccounted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? taxFlag
        {
            set { _taxflag = value; }
            get { return _taxflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inventoryLocation
        {
            set { _inventorylocation = value; }
            get { return _inventorylocation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string isNoModify
        {
            set { _isnomodify = value; }
            get { return _isnomodify; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumulativeEstimateAmount
        {
            set { _cumulativeestimateamount = value; }
            get { return _cumulativeestimateamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ts
        {
            set { _ts = value; }
            get { return _ts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string updatedBy
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem0
        {
            set { _freeitem0 = value; }
            get { return _freeitem0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem1
        {
            set { _freeitem1 = value; }
            get { return _freeitem1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem2
        {
            set { _freeitem2 = value; }
            get { return _freeitem2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem3
        {
            set { _freeitem3 = value; }
            get { return _freeitem3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem4
        {
            set { _freeitem4 = value; }
            get { return _freeitem4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem5
        {
            set { _freeitem5 = value; }
            get { return _freeitem5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem6
        {
            set { _freeitem6 = value; }
            get { return _freeitem6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem7
        {
            set { _freeitem7 = value; }
            get { return _freeitem7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem8
        {
            set { _freeitem8 = value; }
            get { return _freeitem8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string freeItem9
        {
            set { _freeitem9 = value; }
            get { return _freeitem9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string priuserdefnvc1
        {
            set { _priuserdefnvc1 = value; }
            get { return _priuserdefnvc1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? priuserdefdecm1
        {
            set { _priuserdefdecm1 = value; }
            get { return _priuserdefdecm1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string priuserdefnvc2
        {
            set { _priuserdefnvc2 = value; }
            get { return _priuserdefnvc2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? priuserdefdecm2
        {
            set { _priuserdefdecm2 = value; }
            get { return _priuserdefdecm2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string priuserdefnvc3
        {
            set { _priuserdefnvc3 = value; }
            get { return _priuserdefnvc3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? priuserdefdecm3
        {
            set { _priuserdefdecm3 = value; }
            get { return _priuserdefdecm3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string priuserdefnvc4
        {
            set { _priuserdefnvc4 = value; }
            get { return _priuserdefnvc4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? priuserdefdecm4
        {
            set { _priuserdefdecm4 = value; }
            get { return _priuserdefdecm4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubuserdefnvc1
        {
            set { _pubuserdefnvc1 = value; }
            get { return _pubuserdefnvc1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? pubuserdefdecm1
        {
            set { _pubuserdefdecm1 = value; }
            get { return _pubuserdefdecm1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubuserdefnvc2
        {
            set { _pubuserdefnvc2 = value; }
            get { return _pubuserdefnvc2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerInventoryPrice
        {
            set { _customerinventoryprice = value; }
            get { return _customerinventoryprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? pubuserdefdecm2
        {
            set { _pubuserdefdecm2 = value; }
            get { return _pubuserdefdecm2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VendorInventoryPrice
        {
            set { _vendorinventoryprice = value; }
            get { return _vendorinventoryprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubuserdefnvc3
        {
            set { _pubuserdefnvc3 = value; }
            get { return _pubuserdefnvc3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvBarCode
        {
            set { _invbarcode = value; }
            get { return _invbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? pubuserdefdecm3
        {
            set { _pubuserdefdecm3 = value; }
            get { return _pubuserdefdecm3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubuserdefnvc4
        {
            set { _pubuserdefnvc4 = value; }
            get { return _pubuserdefnvc4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? pubuserdefdecm4
        {
            set { _pubuserdefdecm4 = value; }
            get { return _pubuserdefdecm4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceVoucherCodeByMergedFlow
        {
            set { _sourcevouchercodebymergedflow = value; }
            get { return _sourcevouchercodebymergedflow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VendorInventoryName
        {
            set { _vendorinventoryname = value; }
            get { return _vendorinventoryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PurchaseOrderCode
        {
            set { _purchaseordercode = value; }
            get { return _purchaseordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PartnerInventoryName
        {
            set { _partnerinventoryname = value; }
            get { return _partnerinventoryname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ShrinkageQuantity
        {
            set { _shrinkagequantity = value; }
            get { return _shrinkagequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ShrinkageQuantity2
        {
            set { _shrinkagequantity2 = value; }
            get { return _shrinkagequantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ShrinkageBaseQuantity
        {
            set { _shrinkagebasequantity = value; }
            get { return _shrinkagebasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ShrinkageSubQuantity
        {
            set { _shrinkagesubquantity = value; }
            get { return _shrinkagesubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigShrinkageQuantity
        {
            set { _origshrinkagequantity = value; }
            get { return _origshrinkagequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigShrinkageQuantity2
        {
            set { _origshrinkagequantity2 = value; }
            get { return _origshrinkagequantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CumPurchaseShrinkageQuantity
        {
            set { _cumpurchaseshrinkagequantity = value; }
            get { return _cumpurchaseshrinkagequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CumPurchaseShrinkageQuantity2
        {
            set { _cumpurchaseshrinkagequantity2 = value; }
            get { return _cumpurchaseshrinkagequantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem0
        {
            set { _productfreeitem0 = value; }
            get { return _productfreeitem0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem1
        {
            set { _productfreeitem1 = value; }
            get { return _productfreeitem1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem2
        {
            set { _productfreeitem2 = value; }
            get { return _productfreeitem2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem3
        {
            set { _productfreeitem3 = value; }
            get { return _productfreeitem3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem4
        {
            set { _productfreeitem4 = value; }
            get { return _productfreeitem4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem5
        {
            set { _productfreeitem5 = value; }
            get { return _productfreeitem5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem6
        {
            set { _productfreeitem6 = value; }
            get { return _productfreeitem6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem7
        {
            set { _productfreeitem7 = value; }
            get { return _productfreeitem7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem8
        {
            set { _productfreeitem8 = value; }
            get { return _productfreeitem8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productFreeItem9
        {
            set { _productfreeitem9 = value; }
            get { return _productfreeitem9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origPrice
        {
            set { _origprice = value; }
            get { return _origprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origAmount
        {
            set { _origamount = value; }
            get { return _origamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origTaxPrice
        {
            set { _origtaxprice = value; }
            get { return _origtaxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origTax
        {
            set { _origtax = value; }
            get { return _origtax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origTaxAmount
        {
            set { _origtaxamount = value; }
            get { return _origtaxamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origSalePrice
        {
            set { _origsaleprice = value; }
            get { return _origsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origTaxSalePrice
        {
            set { _origtaxsaleprice = value; }
            get { return _origtaxsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origSaleAmount
        {
            set { _origsaleamount = value; }
            get { return _origsaleamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origTaxSaleAmount
        {
            set { _origtaxsaleamount = value; }
            get { return _origtaxsaleamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? salePrice
        {
            set { _saleprice = value; }
            get { return _saleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? taxSalePrice
        {
            set { _taxsaleprice = value; }
            get { return _taxsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? saleAmount
        {
            set { _saleamount = value; }
            get { return _saleamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? taxSaleAmount
        {
            set { _taxsaleamount = value; }
            get { return _taxsaleamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManufactureOrderCode
        {
            set { _manufactureordercode = value; }
            get { return _manufactureordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CumReturnQuantity
        {
            set { _cumreturnquantity = value; }
            get { return _cumreturnquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CumReturnQuantity2
        {
            set { _cumreturnquantity2 = value; }
            get { return _cumreturnquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigManuPrice
        {
            set { _origmanuprice = value; }
            get { return _origmanuprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigManuAmount
        {
            set { _origmanuamount = value; }
            get { return _origmanuamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigTaxManuPrice
        {
            set { _origtaxmanuprice = value; }
            get { return _origtaxmanuprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigTaxManuAmount
        {
            set { _origtaxmanuamount = value; }
            get { return _origtaxmanuamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ManuPrice
        {
            set { _manuprice = value; }
            get { return _manuprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ManuAmount
        {
            set { _manuamount = value; }
            get { return _manuamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TaxManuPrice
        {
            set { _taxmanuprice = value; }
            get { return _taxmanuprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TaxManuAmount
        {
            set { _taxmanuamount = value; }
            get { return _taxmanuamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ManuFeeDiff
        {
            set { _manufeediff = value; }
            get { return _manufeediff; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigManuPrice2
        {
            set { _origmanuprice2 = value; }
            get { return _origmanuprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigTaxManuPrice2
        {
            set { _origtaxmanuprice2 = value; }
            get { return _origtaxmanuprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ManuPrice2
        {
            set { _manuprice2 = value; }
            get { return _manuprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TaxManuPrice2
        {
            set { _taxmanuprice2 = value; }
            get { return _taxmanuprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? baseManuPrice
        {
            set { _basemanuprice = value; }
            get { return _basemanuprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origPrice2
        {
            set { _origprice2 = value; }
            get { return _origprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origTaxPrice2
        {
            set { _origtaxprice2 = value; }
            get { return _origtaxprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TaxPrice2
        {
            set { _taxprice2 = value; }
            get { return _taxprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origSalePrice2
        {
            set { _origsaleprice2 = value; }
            get { return _origsaleprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? origTaxSalePrice2
        {
            set { _origtaxsaleprice2 = value; }
            get { return _origtaxsaleprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? salePrice2
        {
            set { _saleprice2 = value; }
            get { return _saleprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? taxSalePrice2
        {
            set { _taxsaleprice2 = value; }
            get { return _taxsaleprice2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NotSettleQuantity
        {
            set { _notsettlequantity = value; }
            get { return _notsettlequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NotSettleQuantity2
        {
            set { _notsettlequantity2 = value; }
            get { return _notsettlequantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SentBaseAmount
        {
            set { _sentbaseamount = value; }
            get { return _sentbaseamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SentBaseQuantity
        {
            set { _sentbasequantity = value; }
            get { return _sentbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string docid
        {
            set { _docid = value; }
            get { return _docid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsPresent
        {
            set { _ispresent = value; }
            get { return _ispresent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Retailprice
        {
            set { _retailprice = value; }
            get { return _retailprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RetailAmount
        {
            set { _retailamount = value; }
            get { return _retailamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? differencequantity
        {
            set { _differencequantity = value; }
            get { return _differencequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? differencequantity2
        {
            set { _differencequantity2 = value; }
            get { return _differencequantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BoxNumber
        {
            set { _boxnumber = value; }
            get { return _boxnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RetailNoTaxPrice
        {
            set { _retailnotaxprice = value; }
            get { return _retailnotaxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RetailNoTaxAmount
        {
            set { _retailnotaxamount = value; }
            get { return _retailnotaxamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastModifiedField
        {
            set { _lastmodifiedfield = value; }
            get { return _lastmodifiedfield; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DiscountRate
        {
            set { _discountrate = value; }
            get { return _discountrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrigDiscount
        {
            set { _origdiscount = value; }
            get { return _origdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PriceStrategyTypeName
        {
            set { _pricestrategytypename = value; }
            get { return _pricestrategytypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PriceStrategySchemeIds
        {
            set { _pricestrategyschemeids = value; }
            get { return _pricestrategyschemeids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PriceStrategySchemeNames
        {
            set { _pricestrategyschemenames = value; }
            get { return _pricestrategyschemenames; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PromotionVoucherCodes
        {
            set { _promotionvouchercodes = value; }
            get { return _promotionvouchercodes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PromotionVoucherIds
        {
            set { _promotionvoucherids = value; }
            get { return _promotionvoucherids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsPromotionPresent
        {
            set { _ispromotionpresent = value; }
            get { return _ispromotionpresent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PromotionPresentVoucherCode
        {
            set { _promotionpresentvouchercode = value; }
            get { return _promotionpresentvouchercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PromotionSingleVoucherCode
        {
            set { _promotionsinglevouchercode = value; }
            get { return _promotionsinglevouchercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PromotionPresentGroupID
        {
            set { _promotionpresentgroupid = value; }
            get { return _promotionpresentgroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PromotionSingleGroupID
        {
            set { _promotionsinglegroupid = value; }
            get { return _promotionsinglegroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SuperSourceVoucherTypeCode
        {
            set { _supersourcevouchertypecode = value; }
            get { return _supersourcevouchertypecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idbusiTypeByMergedFlow
        {
            set { _idbusitypebymergedflow = value; }
            get { return _idbusitypebymergedflow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idinventory
        {
            set { _idinventory = value; }
            get { return _idinventory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idProductInventory
        {
            set { _idproductinventory = value; }
            get { return _idproductinventory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IdMarketingOrgan
        {
            set { _idmarketingorgan = value; }
            get { return _idmarketingorgan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idproject
        {
            set { _idproject = value; }
            get { return _idproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PriceStrategyTypeId
        {
            set { _pricestrategytypeid = value; }
            get { return _pricestrategytypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idbaseunit
        {
            set { _idbaseunit = value; }
            get { return _idbaseunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idsubunit
        {
            set { _idsubunit = value; }
            get { return _idsubunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idunit
        {
            set { _idunit = value; }
            get { return _idunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idunit2
        {
            set { _idunit2 = value; }
            get { return _idunit2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idwarehouse
        {
            set { _idwarehouse = value; }
            get { return _idwarehouse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? indirectSourceVoucherDetailId
        {
            set { _indirectsourcevoucherdetailid = value; }
            get { return _indirectsourcevoucherdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CashbackWay
        {
            set { _cashbackway = value; }
            get { return _cashbackway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PromotionPresentTypeID
        {
            set { _promotionpresenttypeid = value; }
            get { return _promotionpresenttypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PromotionSingleTypeID
        {
            set { _promotionsingletypeid = value; }
            get { return _promotionsingletypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sourceVoucherId
        {
            set { _sourcevoucherid = value; }
            get { return _sourcevoucherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ManufactureOrderId
        {
            set { _manufactureorderid = value; }
            get { return _manufactureorderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ManufactureOrderDetailId
        {
            set { _manufactureorderdetailid = value; }
            get { return _manufactureorderdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sourceVoucherDetailId
        {
            set { _sourcevoucherdetailid = value; }
            get { return _sourcevoucherdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ManufactureOrderMaterialDetailId
        {
            set { _manufactureordermaterialdetailid = value; }
            get { return _manufactureordermaterialdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PromotionPresentVoucherID
        {
            set { _promotionpresentvoucherid = value; }
            get { return _promotionpresentvoucherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PromotionSingleVoucherID
        {
            set { _promotionsinglevoucherid = value; }
            get { return _promotionsinglevoucherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SourceVoucherIdByMergedFlow
        {
            set { _sourcevoucheridbymergedflow = value; }
            get { return _sourcevoucheridbymergedflow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SourceVoucherDetailIdByMergedFlow
        {
            set { _sourcevoucherdetailidbymergedflow = value; }
            get { return _sourcevoucherdetailidbymergedflow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? saleOrderId
        {
            set { _saleorderid = value; }
            get { return _saleorderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? saleOrderDetailId
        {
            set { _saleorderdetailid = value; }
            get { return _saleorderdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SourceOrderDetailId
        {
            set { _sourceorderdetailid = value; }
            get { return _sourceorderdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idsourcevouchertype
        {
            set { _idsourcevouchertype = value; }
            get { return _idsourcevouchertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idsourceVoucherTypeByMergedFlow
        {
            set { _idsourcevouchertypebymergedflow = value; }
            get { return _idsourcevouchertypebymergedflow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idIndirectSourceVoucherType
        {
            set { _idindirectsourcevouchertype = value; }
            get { return _idindirectsourcevouchertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int receiveVoucherId
        {
            set { _receivevoucherid = value; }
            get { return _receivevoucherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idRDRecordDTO
        {
            set { _idrdrecorddto = value; }
            get { return _idrdrecorddto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? receiveVoucherDetailId
        {
            set { _receivevoucherdetailid = value; }
            get { return _receivevoucherdetailid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? expiryDate
        {
            set { _expirydate = value; }
            get { return _expirydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? receiveDate
        {
            set { _receivedate = value; }
            get { return _receivedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createdtime
        {
            set { _createdtime = value; }
            get { return _createdtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime updated
        {
            set { _updated = value; }
            get { return _updated; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProductionDate
        {
            set { _productiondate = value; }
            get { return _productiondate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DataSource
        {
            set { _datasource = value; }
            get { return _datasource; }
        }
        #endregion Model

    }
}

