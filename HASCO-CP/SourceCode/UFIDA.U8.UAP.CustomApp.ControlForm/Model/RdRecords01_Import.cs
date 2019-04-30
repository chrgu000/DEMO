using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// RdRecords01_Import:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RdRecords01_Import
    {
        public RdRecords01_Import()
        { }
        #region Model
        private long _autoid;
        private string _importtime;
        private string _invoiceno;
        private DateTime? _date;
        private string _companyname;
        private string _pono;
        private string _containerno;
        private string _descriptionofproductsen;
        private string _caseno;
        private string _boxno;
        private decimal? _boxqty;
        private decimal? _quantity;
        private string _unit;
        private decimal? _nwkgs;
        private decimal? _gwkgs;
        private decimal? _boxcbm;
        private string _conno;
        private long? _posid;
        private long? _rds01id;
        private decimal? _unitprice;
        private DateTime? _bldate;
        private string _blno;
        private string _partno;
        private string _currency;

        /// <summary>
        /// 
        /// </summary>
        public long AutoID
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImportTime
        {
            set { _importtime = value; }
            get { return _importtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceNo
        {
            set { _invoiceno = value; }
            get { return _invoiceno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PARTNO
        {
            set { _partno = value; }
            get { return _partno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Companyname
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PONO
        {
            set { _pono = value; }
            get { return _pono; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CONTAINERNO
        {
            set { _containerno = value; }
            get { return _containerno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTIONOFPRODUCTSEN
        {
            set { _descriptionofproductsen = value; }
            get { return _descriptionofproductsen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CASENO
        {
            set { _caseno = value; }
            get { return _caseno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BOXNO
        {
            set { _boxno = value; }
            get { return _boxno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BOXQTY
        {
            set { _boxqty = value; }
            get { return _boxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UNIT
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NWKGS
        {
            set { _nwkgs = value; }
            get { return _nwkgs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GWKGS
        {
            set { _gwkgs = value; }
            get { return _gwkgs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BOXCBM
        {
            set { _boxcbm = value; }
            get { return _boxcbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CONNO
        {
            set { _conno = value; }
            get { return _conno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? POsID
        {
            set { _posid = value; }
            get { return _posid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Rds01ID
        {
            set { _rds01id = value; }
            get { return _rds01id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? UnitPrice
        {
            set { _unitprice = value; }
            get { return _unitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BLDate
        {
            set { _bldate = value; }
            get { return _bldate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BLNo
        {
            set { _blno = value; }
            get { return _blno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        #endregion Model

    }
}

