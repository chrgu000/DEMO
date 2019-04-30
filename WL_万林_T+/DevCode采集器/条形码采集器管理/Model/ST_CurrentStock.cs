using System;
namespace BarCode.Model
{
    /// <summary>
    /// ST_CurrentStock:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ST_CurrentStock
    {
        public ST_CurrentStock()
        { }
        #region Model
        private string _batch;
        private decimal? _basequantity;
        private decimal? _subquantity;
        private decimal? _canusebasequantity;
        private decimal? _canusesubquantity;
        private decimal? _onwaybasequantity;
        private decimal? _onwaysubquantity;
        private decimal? _fordispatchbasequantity;
        private decimal? _fordispatchsubquantity;
        private decimal? _purchaseorderonwaybasequantity;
        private decimal? _purchaseorderonwaysubquantity;
        private decimal? _purchasearrivalbasequantity;
        private decimal? _purchasearrivalsubquantity;
        private decimal? _purchaseforreceivebasequantity;
        private decimal? _purchaseforreceivesubquantity;
        private decimal? _onproducingbasequantity;
        private decimal? _onproducingsubquantity;
        private decimal? _productforreceivebasequantity;
        private decimal? _productforreceivesubquantity;
        private decimal? _transonwaybasequantity;
        private decimal? _transonwaysubquantity;
        private decimal? _transfordispatchbasequantity;
        private decimal? _transfordispatchsubquantity;
        private decimal? _otheronwaybasequantity;
        private decimal? _otheronwaysubquantity;
        private decimal? _otherfordispatchbasequantity;
        private decimal? _otherfordispatchsubquantity;
        private decimal? _forsaleorderbasequantity;
        private decimal? _forsaleordersubquantity;
        private decimal? _saledeliverybasequantity;
        private decimal? _saledeliverysubquantity;
        private decimal? _forsaledispatchbasequantity;
        private decimal? _forsaledispatchsubquantity;
        private decimal? _materialforsendbasequantity;
        private decimal? _materialforsendsubquantity;
        private string _receivevouchercode;
        private decimal? _voucherquantity;
        private decimal? _voucherquantity2;
        private decimal? _prebasequantity;
        private decimal? _presubquantity;
        private decimal? _lowquantity;
        private decimal? _topquantity;
        private decimal? _changerate;
        private int? _iscarriedforwardout;
        private int? _iscarriedforwardin;
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
        private decimal? _producefordispatchbasequantity;
        private decimal? _producefordispatchsubquantity;
        private decimal? _stockrequestbasequantity;
        private decimal? _stockrequestsubquantity;
        private int _id;
        private int _idinventory;
        private int? _idmarketingorgan;
        private int? _idbaseunit;
        private int? _idsubunit;
        private int? _idvoucherunit;
        private int? _idvoucherunit2;
        private int _idwarehouse;
        private int? _idbatchdispatchdto;
        private int? _receivevoucherid;
        private int? _receivevoucherdetailid;
        private DateTime? _expirydate;
        private DateTime? _createdtime;
        private DateTime _updated;
        private DateTime? _productiondate;
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
        public decimal? canUseBaseQuantity
        {
            set { _canusebasequantity = value; }
            get { return _canusebasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? canUseSubQuantity
        {
            set { _canusesubquantity = value; }
            get { return _canusesubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? onWayBaseQuantity
        {
            set { _onwaybasequantity = value; }
            get { return _onwaybasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? onWaySubQuantity
        {
            set { _onwaysubquantity = value; }
            get { return _onwaysubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? forDispatchBaseQuantity
        {
            set { _fordispatchbasequantity = value; }
            get { return _fordispatchbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? forDispatchSubQuantity
        {
            set { _fordispatchsubquantity = value; }
            get { return _fordispatchsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? purchaseOrderOnWayBaseQuantity
        {
            set { _purchaseorderonwaybasequantity = value; }
            get { return _purchaseorderonwaybasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? purchaseOrderOnWaySubQuantity
        {
            set { _purchaseorderonwaysubquantity = value; }
            get { return _purchaseorderonwaysubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? purchaseArrivalBaseQuantity
        {
            set { _purchasearrivalbasequantity = value; }
            get { return _purchasearrivalbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? purchaseArrivalSubQuantity
        {
            set { _purchasearrivalsubquantity = value; }
            get { return _purchasearrivalsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? purchaseForReceiveBaseQuantity
        {
            set { _purchaseforreceivebasequantity = value; }
            get { return _purchaseforreceivebasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? purchaseForReceiveSubQuantity
        {
            set { _purchaseforreceivesubquantity = value; }
            get { return _purchaseforreceivesubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? onProducingBaseQuantity
        {
            set { _onproducingbasequantity = value; }
            get { return _onproducingbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? onProducingSubQuantity
        {
            set { _onproducingsubquantity = value; }
            get { return _onproducingsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? productForReceiveBaseQuantity
        {
            set { _productforreceivebasequantity = value; }
            get { return _productforreceivebasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? productForReceiveSubQuantity
        {
            set { _productforreceivesubquantity = value; }
            get { return _productforreceivesubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? transOnWayBaseQuantity
        {
            set { _transonwaybasequantity = value; }
            get { return _transonwaybasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? transOnWaySubQuantity
        {
            set { _transonwaysubquantity = value; }
            get { return _transonwaysubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? transForDispatchBaseQuantity
        {
            set { _transfordispatchbasequantity = value; }
            get { return _transfordispatchbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? transForDispatchSubQuantity
        {
            set { _transfordispatchsubquantity = value; }
            get { return _transfordispatchsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? otherOnWayBaseQuantity
        {
            set { _otheronwaybasequantity = value; }
            get { return _otheronwaybasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? otherOnWaySubQuantity
        {
            set { _otheronwaysubquantity = value; }
            get { return _otheronwaysubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? otherForDispatchBaseQuantity
        {
            set { _otherfordispatchbasequantity = value; }
            get { return _otherfordispatchbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? otherForDispatchSubQuantity
        {
            set { _otherfordispatchsubquantity = value; }
            get { return _otherfordispatchsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? forSaleOrderBaseQuantity
        {
            set { _forsaleorderbasequantity = value; }
            get { return _forsaleorderbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? forSaleOrderSubQuantity
        {
            set { _forsaleordersubquantity = value; }
            get { return _forsaleordersubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? saleDeliveryBaseQuantity
        {
            set { _saledeliverybasequantity = value; }
            get { return _saledeliverybasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? saleDeliverySubQuantity
        {
            set { _saledeliverysubquantity = value; }
            get { return _saledeliverysubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? forSaleDispatchBaseQuantity
        {
            set { _forsaledispatchbasequantity = value; }
            get { return _forsaledispatchbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? forSaleDispatchSubQuantity
        {
            set { _forsaledispatchsubquantity = value; }
            get { return _forsaledispatchsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? materialForSendBaseQuantity
        {
            set { _materialforsendbasequantity = value; }
            get { return _materialforsendbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? materialForSendSubQuantity
        {
            set { _materialforsendsubquantity = value; }
            get { return _materialforsendsubquantity; }
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
        public decimal? voucherQuantity
        {
            set { _voucherquantity = value; }
            get { return _voucherquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? voucherQuantity2
        {
            set { _voucherquantity2 = value; }
            get { return _voucherquantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? preBaseQuantity
        {
            set { _prebasequantity = value; }
            get { return _prebasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? preSubQuantity
        {
            set { _presubquantity = value; }
            get { return _presubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? lowQuantity
        {
            set { _lowquantity = value; }
            get { return _lowquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? topQuantity
        {
            set { _topquantity = value; }
            get { return _topquantity; }
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
        public int? isCarriedForwardOut
        {
            set { _iscarriedforwardout = value; }
            get { return _iscarriedforwardout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isCarriedForwardIn
        {
            set { _iscarriedforwardin = value; }
            get { return _iscarriedforwardin; }
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
        public decimal? ProduceForDispatchBaseQuantity
        {
            set { _producefordispatchbasequantity = value; }
            get { return _producefordispatchbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ProduceForDispatchSubQuantity
        {
            set { _producefordispatchsubquantity = value; }
            get { return _producefordispatchsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? stockRequestBaseQuantity
        {
            set { _stockrequestbasequantity = value; }
            get { return _stockrequestbasequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? stockRequestSubQuantity
        {
            set { _stockrequestsubquantity = value; }
            get { return _stockrequestsubquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        public int? IdMarketingOrgan
        {
            set { _idmarketingorgan = value; }
            get { return _idmarketingorgan; }
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
        public int? idvoucherunit
        {
            set { _idvoucherunit = value; }
            get { return _idvoucherunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idvoucherunit2
        {
            set { _idvoucherunit2 = value; }
            get { return _idvoucherunit2; }
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
        public int? idBatchDispatchDTO
        {
            set { _idbatchdispatchdto = value; }
            get { return _idbatchdispatchdto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? receiveVoucherId
        {
            set { _receivevoucherid = value; }
            get { return _receivevoucherid; }
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
        public DateTime? productionDate
        {
            set { _productiondate = value; }
            get { return _productiondate; }
        }
        #endregion Model

    }
}

