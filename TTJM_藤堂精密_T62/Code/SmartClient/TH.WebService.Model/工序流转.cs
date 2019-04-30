using System;
namespace TH.Model
{
    /// <summary>
    /// 工序流转:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 工序流转
    {
        public 工序流转()
        { }
        #region Model
        private long _iid;
        private long? _workdetailsid;
        private string _barcode;
        private string _barcode2;
        private string _工序;
        private decimal? _数量;
        private string _createuid;
        private DateTime? _createdate;
        private string _updateuid;
        private DateTime? _updatedate;
        private string _audituid;
        private DateTime? _auditdate;
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
        public long? WorkDetailsID
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
        public string BarCode2
        {
            set { _barcode2 = value; }
            get { return _barcode2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 工序
        {
            set { _工序 = value; }
            get { return _工序; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 数量
        {
            set { _数量 = value; }
            get { return _数量; }
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
        public string AuditUid
        {
            set { _audituid = value; }
            get { return _audituid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuditDate
        {
            set { _auditdate = value; }
            get { return _auditdate; }
        }
        #endregion Model

    }
}

