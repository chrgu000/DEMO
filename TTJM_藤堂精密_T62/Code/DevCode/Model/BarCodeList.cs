using System;
namespace TH.Model
{
    /// <summary>
    /// BarCodeList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BarCodeList
    {
        public BarCodeList()
        { }
        #region Model
        private long _iid;
        private string _workcode;
        private long _workdetailsid;
        private string _barcode;
        private string _cinvcode;
        private decimal? _workqty;
        private decimal _iqty;
        private decimal _iboxqty;
        private string _workprocessno;
        private string _workprocessname;
        private bool _分包;
        private string _ramark;
        private string _ramark2;
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
        public string WorkCode
        {
            set { _workcode = value; }
            get { return _workcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long WorkDetailsID
        {
            set { _workdetailsid = value; }
            get { return _workdetailsid; }
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
        public string cInvCode
        {
            set { _cinvcode = value; }
            get { return _cinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkQty
        {
            set { _workqty = value; }
            get { return _workqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iQty
        {
            set { _iqty = value; }
            get { return _iqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iBoxQty
        {
            set { _iboxqty = value; }
            get { return _iboxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkProcessNo
        {
            set { _workprocessno = value; }
            get { return _workprocessno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkProcessName
        {
            set { _workprocessname = value; }
            get { return _workprocessname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool 分包
        {
            set { _分包 = value; }
            get { return _分包; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ramark
        {
            set { _ramark = value; }
            get { return _ramark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ramark2
        {
            set { _ramark2 = value; }
            get { return _ramark2; }
        }
        #endregion Model

    }
}


