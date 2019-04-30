using System;
namespace BarCode.Model
{
    /// <summary>
    /// ST_RDRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ST_RDRecord
    {
        public ST_RDRecord()
        { }
        #region Model
        private string _code;
        private string _dispatchaddress;
        private string _contact;
        private string _contactphone;
        private string _sourcevouchercode;
        private string _saleordercode;
        private string _purchasearrivalcode;
        private string _productreceivecode;
        private string _saledeliverycode;
        private int? _printtime;
        private decimal? _amount;
        private int? _rddirectionflag;
        private int? _iscostaccount;
        private int? _ismergedflow;
        private int? _isautogenerate;
        private string _memo;
        private string _isnomodify;
        private string _maker;
        private string _auditor;
        private string _reviser;
        private int? _iscarriedforwardout;
        private int? _iscarriedforwardin;
        private int? _ismodifiedcode;
        private int? _accountingperiod;
        private string _docid;
        private int? _accountingyear;
        private DateTime? _ts;
        private string _updatedby;
        private string _priuserdefnvc1;
        private decimal? _priuserdefdecm1;
        private string _priuserdefnvc2;
        private decimal? _priuserdefdecm2;
        private string _priuserdefnvc3;
        private decimal? _priuserdefdecm3;
        private string _priuserdefnvc4;
        private decimal? _priuserdefdecm4;
        private string _priuserdefnvc5;
        private decimal? _priuserdefdecm5;
        private string _priuserdefnvc6;
        private decimal? _priuserdefdecm6;
        private string _pubuserdefnvc1;
        private decimal? _pubuserdefdecm1;
        private string _pubuserdefnvc2;
        private decimal? _pubuserdefdecm2;
        private string _pubuserdefnvc3;
        private decimal? _pubuserdefdecm3;
        private string _pubuserdefnvc4;
        private decimal? _pubuserdefdecm4;
        private string _pubuserdefnvc5;
        private decimal? _pubuserdefdecm5;
        private string _pubuserdefnvc6;
        private decimal? _pubuserdefdecm6;
        private int? _voucheryear;
        private int? _voucherperiod;
        private DateTime? _sourcevoucherdate;
        private decimal? _exchangerate;
        private string _manufactureordercode;
        private string _delegatedispatchcode;
        private string _beforeupgrade;
        private decimal? _totalorigtaxamount;
        private decimal? _totaltaxamount;
        private int? _printcount;
        private string _mobilephone;
        private string _address;
        private string _externalcode;
        private int _id;
        private int? _idbusitype;
        private int? _idcurrency;
        private int _iddepartment;
        private int? _iddistrict;
        private int _idmember;
        private int _idstore;
        private int _idmarketingorgan;
        private int _idpartner;
        private int _idsettlecustomer;
        private int _idclerk;
        private int? _idqualityinspector;
        private int _idproject;
        private int? _idrdstyle;
        private int? _idinwarehouse;
        private int _idwarehouse;
        private int? _idcollaborateupvouchertype;
        private int? _idcollaborateupvoucher;
        private int? _accountstate;
        private int? _deliverystate;
        private int? _settlestatus;
        private int? _transporttype;
        private int _voucherstate;
        private int? _auditorid;
        private int _makerid;
        private int _sourcevoucherid;
        private int? _purchasearrivalid;
        private int? _saledeliveryid;
        private int? _saleorderid;
        private int _idsourcevouchertype;
        private int _idvouchertype;
        private int? _productreceiveid;
        private DateTime? _maturitydate;
        private DateTime _voucherdate;
        private DateTime? _madedate;
        private DateTime? _auditeddate;
        private DateTime _createdtime;
        private DateTime? _updated;
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
        public string dispatchAddress
        {
            set { _dispatchaddress = value; }
            get { return _dispatchaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string contact
        {
            set { _contact = value; }
            get { return _contact; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string contactPhone
        {
            set { _contactphone = value; }
            get { return _contactphone; }
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
        public string purchaseArrivalCode
        {
            set { _purchasearrivalcode = value; }
            get { return _purchasearrivalcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productReceiveCode
        {
            set { _productreceivecode = value; }
            get { return _productreceivecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saleDeliveryCode
        {
            set { _saledeliverycode = value; }
            get { return _saledeliverycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? printTime
        {
            set { _printtime = value; }
            get { return _printtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? rdDirectionFlag
        {
            set { _rddirectionflag = value; }
            get { return _rddirectionflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isCostAccount
        {
            set { _iscostaccount = value; }
            get { return _iscostaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isMergedFlow
        {
            set { _ismergedflow = value; }
            get { return _ismergedflow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isAutoGenerate
        {
            set { _isautogenerate = value; }
            get { return _isautogenerate; }
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
        public string isNoModify
        {
            set { _isnomodify = value; }
            get { return _isnomodify; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string auditor
        {
            set { _auditor = value; }
            get { return _auditor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string reviser
        {
            set { _reviser = value; }
            get { return _reviser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iscarriedforwardout
        {
            set { _iscarriedforwardout = value; }
            get { return _iscarriedforwardout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iscarriedforwardin
        {
            set { _iscarriedforwardin = value; }
            get { return _iscarriedforwardin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ismodifiedcode
        {
            set { _ismodifiedcode = value; }
            get { return _ismodifiedcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? accountingperiod
        {
            set { _accountingperiod = value; }
            get { return _accountingperiod; }
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
        public int? accountingyear
        {
            set { _accountingyear = value; }
            get { return _accountingyear; }
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
        public string priuserdefnvc5
        {
            set { _priuserdefnvc5 = value; }
            get { return _priuserdefnvc5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? priuserdefdecm5
        {
            set { _priuserdefdecm5 = value; }
            get { return _priuserdefdecm5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string priuserdefnvc6
        {
            set { _priuserdefnvc6 = value; }
            get { return _priuserdefnvc6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? priuserdefdecm6
        {
            set { _priuserdefdecm6 = value; }
            get { return _priuserdefdecm6; }
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
        public decimal? pubuserdefdecm2
        {
            set { _pubuserdefdecm2 = value; }
            get { return _pubuserdefdecm2; }
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
        public string pubuserdefnvc5
        {
            set { _pubuserdefnvc5 = value; }
            get { return _pubuserdefnvc5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? pubuserdefdecm5
        {
            set { _pubuserdefdecm5 = value; }
            get { return _pubuserdefdecm5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pubuserdefnvc6
        {
            set { _pubuserdefnvc6 = value; }
            get { return _pubuserdefnvc6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? pubuserdefdecm6
        {
            set { _pubuserdefdecm6 = value; }
            get { return _pubuserdefdecm6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VoucherYear
        {
            set { _voucheryear = value; }
            get { return _voucheryear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VoucherPeriod
        {
            set { _voucherperiod = value; }
            get { return _voucherperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SourceVoucherDate
        {
            set { _sourcevoucherdate = value; }
            get { return _sourcevoucherdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? exchangeRate
        {
            set { _exchangerate = value; }
            get { return _exchangerate; }
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
        public string DelegateDispatchCode
        {
            set { _delegatedispatchcode = value; }
            get { return _delegatedispatchcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BeforeUpgrade
        {
            set { _beforeupgrade = value; }
            get { return _beforeupgrade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalOrigTaxAmount
        {
            set { _totalorigtaxamount = value; }
            get { return _totalorigtaxamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalTaxAmount
        {
            set { _totaltaxamount = value; }
            get { return _totaltaxamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PrintCount
        {
            set { _printcount = value; }
            get { return _printcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobilephone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExternalCode
        {
            set { _externalcode = value; }
            get { return _externalcode; }
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
        public int? idbusitype
        {
            set { _idbusitype = value; }
            get { return _idbusitype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idcurrency
        {
            set { _idcurrency = value; }
            get { return _idcurrency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iddepartment
        {
            set { _iddepartment = value; }
            get { return _iddepartment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iddistrict
        {
            set { _iddistrict = value; }
            get { return _iddistrict; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idmember
        {
            set { _idmember = value; }
            get { return _idmember; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IdStore
        {
            set { _idstore = value; }
            get { return _idstore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IdMarketingOrgan
        {
            set { _idmarketingorgan = value; }
            get { return _idmarketingorgan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idpartner
        {
            set { _idpartner = value; }
            get { return _idpartner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idsettleCustomer
        {
            set { _idsettlecustomer = value; }
            get { return _idsettlecustomer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idclerk
        {
            set { _idclerk = value; }
            get { return _idclerk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idqualityinspector
        {
            set { _idqualityinspector = value; }
            get { return _idqualityinspector; }
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
        public int? idrdstyle
        {
            set { _idrdstyle = value; }
            get { return _idrdstyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idinwarehouse
        {
            set { _idinwarehouse = value; }
            get { return _idinwarehouse; }
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
        public int? idCollaborateUpVoucherType
        {
            set { _idcollaborateupvouchertype = value; }
            get { return _idcollaborateupvouchertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idCollaborateUpVoucher
        {
            set { _idcollaborateupvoucher = value; }
            get { return _idcollaborateupvoucher; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? accountState
        {
            set { _accountstate = value; }
            get { return _accountstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? deliveryState
        {
            set { _deliverystate = value; }
            get { return _deliverystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? settleStatus
        {
            set { _settlestatus = value; }
            get { return _settlestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? transportType
        {
            set { _transporttype = value; }
            get { return _transporttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int voucherState
        {
            set { _voucherstate = value; }
            get { return _voucherstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? auditorid
        {
            set { _auditorid = value; }
            get { return _auditorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int makerid
        {
            set { _makerid = value; }
            get { return _makerid; }
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
        public int? purchaseArrivalId
        {
            set { _purchasearrivalid = value; }
            get { return _purchasearrivalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? saleDeliveryId
        {
            set { _saledeliveryid = value; }
            get { return _saledeliveryid; }
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
        public int idsourcevouchertype
        {
            set { _idsourcevouchertype = value; }
            get { return _idsourcevouchertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idvouchertype
        {
            set { _idvouchertype = value; }
            get { return _idvouchertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? productReceiveId
        {
            set { _productreceiveid = value; }
            get { return _productreceiveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? maturityDate
        {
            set { _maturitydate = value; }
            get { return _maturitydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime voucherdate
        {
            set { _voucherdate = value; }
            get { return _voucherdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? madedate
        {
            set { _madedate = value; }
            get { return _madedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? auditeddate
        {
            set { _auditeddate = value; }
            get { return _auditeddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createdtime
        {
            set { _createdtime = value; }
            get { return _createdtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? updated
        {
            set { _updated = value; }
            get { return _updated; }
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

