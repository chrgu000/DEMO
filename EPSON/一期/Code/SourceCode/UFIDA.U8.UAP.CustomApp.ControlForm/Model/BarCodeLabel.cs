using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _BarCodeLabel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _BarCodeLabel
    {
        public _BarCodeLabel()
        { }
        #region Model
        private long _iid;
        private string _barcode;
        private string _saleorderno;
        private long? _saleorderrowno;
        private long _isosid;
        private string _cinvcode;
        private string _cinvname;
        private string _cinvstd;
        private string _dept;
        private string _cust;
        private string _orderno;
        private string _custdo;
        private string _custlot;
        private string _lotno;
        private decimal _lotsize;
        private decimal? _orderqty;
        private decimal? _lotqty;
        private DateTime? _recdate;
        private DateTime? _duedate;
        private string _creater;
        private DateTime? _createdate;
        private DateTime? _printtime;
        private long? _printcount;
        private string _oldbarcode;
        private string _closeuid;
        private DateTime? _closedate;
        private decimal? _lotqty2;
        private string _status;
        private string _process;
        private string _rdtype;
        private string _barkg;
        private string _batch;
        private long? _rdsid;
        /// <summary>
        /// 
        /// </summary>
        public long iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SaleOrderNo
        {
            set { _saleorderno = value; }
            get { return _saleorderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SaleOrderRowNo
        {
            set { _saleorderrowno = value; }
            get { return _saleorderrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iSOsID
        {
            set { _isosid = value; }
            get { return _isosid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvCode
        {
            set { _cinvcode = value; }
            get { return _cinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvName
        {
            set { _cinvname = value; }
            get { return _cinvname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvStd
        {
            set { _cinvstd = value; }
            get { return _cinvstd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPT
        {
            set { _dept = value; }
            get { return _dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUST
        {
            set { _cust = value; }
            get { return _cust; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ORDERNO
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUSTDO
        {
            set { _custdo = value; }
            get { return _custdo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUSTLOT
        {
            set { _custlot = value; }
            get { return _custlot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOTNO
        {
            set { _lotno = value; }
            get { return _lotno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal LotSize
        {
            set { _lotsize = value; }
            get { return _lotsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ORDERQTY
        {
            set { _orderqty = value; }
            get { return _orderqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LOTQTY
        {
            set { _lotqty = value; }
            get { return _lotqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RECDate
        {
            set { _recdate = value; }
            get { return _recdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DueDate
        {
            set { _duedate = value; }
            get { return _duedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creater
        {
            set { _creater = value; }
            get { return _creater; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PrintTime
        {
            set { _printtime = value; }
            get { return _printtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? PrintCount
        {
            set { _printcount = value; }
            get { return _printcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oldBarCode
        {
            set { _oldbarcode = value; }
            get { return _oldbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CloseUid
        {
            set { _closeuid = value; }
            get { return _closeuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseDate
        {
            set { _closedate = value; }
            get { return _closedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LOTQTY2
        {
            set { _lotqty2 = value; }
            get { return _lotqty2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Process
        {
            set { _process = value; }
            get { return _process; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RDType
        {
            set { _rdtype = value; }
            get { return _rdtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BarKG
        {
            set { _barkg = value; }
            get { return _barkg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? RDsID
        {
            set { _rdsid = value; }
            get { return _rdsid; }
        }
        #endregion Model

    }
}

