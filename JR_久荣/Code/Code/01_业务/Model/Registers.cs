using System;
namespace Model
{
    /// <summary>
    /// Registers:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Registers
    {
        public Registers()
        { }
        #region Model
        private int _id;
        private DateTime? _ddate;
        private string _vencode;
        private string _door;
        private string _invcode;
        private string _ihz;
        private decimal? _isheqty;
        private DateTime? _ishedate;
        private decimal? _iboxqty;
        private decimal? _iqty;
        private string _orderno;
        private string _barcode;
        private string _remark;
        private string _createuid;
        private DateTime? _createdate;
        private string _updateuid;
        private DateTime? _updatedate;
        private decimal? _ioutqty;
        private DateTime? _ioutdate;
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
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VenCode
        {
            set { _vencode = value; }
            get { return _vencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Door
        {
            set { _door = value; }
            get { return _door; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvCode
        {
            set { _invcode = value; }
            get { return _invcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iHZ
        {
            set { _ihz = value; }
            get { return _ihz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSheQty
        {
            set { _isheqty = value; }
            get { return _isheqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? iSheDate
        {
            set { _ishedate = value; }
            get { return _ishedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iBoxQty
        {
            set { _iboxqty = value; }
            get { return _iboxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iQty
        {
            set { _iqty = value; }
            get { return _iqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUid
        {
            set { _updateuid = value; }
            get { return _updateuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iOutQty
        {
            set { _ioutqty = value; }
            get { return _ioutqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? iOutDate
        {
            set { _ioutdate = value; }
            get { return _ioutdate; }
        }
        #endregion Model

    }
}

