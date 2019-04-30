using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _SalesShipment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _SalesShipment
    {
        public _SalesShipment()
        { }
        #region Model
        private long _iid;
        private string _lotno;
        private string _csocode;
        private long? _saleorderrow;
        private long _isosid;
        private string _itemno;
        private string _description;
        private string _ccuscode;
        private decimal? _orderqty;
        private decimal? _lotqty;
        private string _dept;
        private string _process;
        private string _processnext;
        private decimal? _otherqty;
        private string _status;
        private string _cstcode;
        private decimal? _currqty;
        private string _createuid;
        private DateTime? _createdate;
        private string _cartonno;
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
        public string LotNO
        {
            set { _lotno = value; }
            get { return _lotno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CartonNo
        {
            set { _cartonno = value; }
            get { return _cartonno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSOCode
        {
            set { _csocode = value; }
            get { return _csocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SaleOrderRow
        {
            set { _saleorderrow = value; }
            get { return _saleorderrow; }
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
        public string ItemNO
        {
            set { _itemno = value; }
            get { return _itemno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusCode
        {
            set { _ccuscode = value; }
            get { return _ccuscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrderQTY
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
        public string DEPT
        {
            set { _dept = value; }
            get { return _dept; }
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
        public string ProcessNext
        {
            set { _processnext = value; }
            get { return _processnext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OtherQTY
        {
            set { _otherqty = value; }
            get { return _otherqty; }
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
        public string cSTCode
        {
            set { _cstcode = value; }
            get { return _cstcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CurrQTY
        {
            set { _currqty = value; }
            get { return _currqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUid
        {
            set { _createuid = value; }
            get { return _createuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}

