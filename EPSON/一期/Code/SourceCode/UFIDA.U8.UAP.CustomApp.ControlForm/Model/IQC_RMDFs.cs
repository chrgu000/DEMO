using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _IQC_RMDFs:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _IQC_RMDFs
    {
        public _IQC_RMDFs()
        { }
        #region Model
        private long _iid;
        private string _iqcno;
        private long _irow;
        private string _defect;
        private decimal? _qty;
        private string _attachment;
        private string _attachmentname;
        private string _remark;
        private string _fileext;
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
        public string IQCNo
        {
            set { _iqcno = value; }
            get { return _iqcno; }
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
        public string AttachmentName
        {
            set { _attachmentname = value; }
            get { return _attachmentname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        public string fileext
        {
            set { _fileext = value; }
            get { return _fileext; }
        }
        #endregion Model

    }
}

