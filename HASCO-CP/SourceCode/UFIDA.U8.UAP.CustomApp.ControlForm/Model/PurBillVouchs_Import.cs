using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// PurBillVouchs_Import:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PurBillVouchs_Import
    {
        public PurBillVouchs_Import()
        { }
        #region Model
        private int _autoid;
        private string _importtime;
        private string _invoiceno;
        private DateTime? _date;
        private string _companyname;
        private string _pono;
        private string _partno;
        private string _descriptionenglish;
        private decimal? _quantity;
        private decimal? _nw;
        private decimal? _gw;
        private decimal? _priceperunit;
        private string _unit;
        private decimal? _totalprice;
        /// <summary>
        /// 
        /// </summary>
        public int AutoID
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
        public string PARTNO
        {
            set { _partno = value; }
            get { return _partno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTIONENGLISH
        {
            set { _descriptionenglish = value; }
            get { return _descriptionenglish; }
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
        public decimal? NW
        {
            set { _nw = value; }
            get { return _nw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GW
        {
            set { _gw = value; }
            get { return _gw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PRICEPERUNIT
        {
            set { _priceperunit = value; }
            get { return _priceperunit; }
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
        public decimal? TOTALPRICE
        {
            set { _totalprice = value; }
            get { return _totalprice; }
        }
        #endregion Model

    }
}

