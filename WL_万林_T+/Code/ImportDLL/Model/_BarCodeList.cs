using System;
namespace ImportDLL.Model
{
    /// <summary>
    /// _BarCodeList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _BarCodeList
    {
        public _BarCodeList()
        { }
        #region Model
        private int _iid;
        private string _barcode;
        private decimal? _qty;
        private int? _detailsid;
        private string _createuid;
        private DateTime? _createdate;
        private string _reprintuid;
        private DateTime? _reprintdate;
        private int? _printcount;
        private string _deluid;
        private string _deldate;
        private string _barcode2;
        /// <summary>
        /// 
        /// </summary>
        public int iID
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
        public string BarCode2
        {
            set { _barcode2 = value; }
            get { return _barcode2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DetailsID
        {
            set { _detailsid = value; }
            get { return _detailsid; }
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
        public string RePrintUid
        {
            set { _reprintuid = value; }
            get { return _reprintuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RePrintDate
        {
            set { _reprintdate = value; }
            get { return _reprintdate; }
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
        public string DelUid
        {
            set { _deluid = value; }
            get { return _deluid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DelDate
        {
            set { _deldate = value; }
            get { return _deldate; }
        }
        #endregion Model

    }
}

