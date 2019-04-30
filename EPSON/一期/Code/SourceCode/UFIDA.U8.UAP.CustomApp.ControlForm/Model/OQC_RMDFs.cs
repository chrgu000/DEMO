using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _OQC_RMDFs:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _OQC_RMDFs
    {
        public _OQC_RMDFs()
        { }
        #region Model
        private long _iid;
        private string _oqcno;
        private long _irow;
        private string _defect;
        private decimal? _qty;
        private string _attachment;
        private string _remark;
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
        public string OQCNo
        {
            set { _oqcno = value; }
            get { return _oqcno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iRow
        {
            set { _irow = value; }
            get { return _irow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Defect
        {
            set { _defect = value; }
            get { return _defect; }
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
        public string Attachment
        {
            set { _attachment = value; }
            get { return _attachment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

