using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _Requisitions:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _GiveBacks
    {
        public _GiveBacks()
        { }
        #region Model
        private Guid _guidhead;
        private long _iid;
        private string _ccode;
        private string _serialno;
        private string _remark;
        private long? _requisitionsiid;
        private long? _times;
        /// <summary>
        /// 
        /// </summary>
        public Guid GUIDHead
        {
            set { _guidhead = value; }
            get { return _guidhead; }
        }
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
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SerialNo
        {
            set { _serialno = value; }
            get { return _serialno; }
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
        public long? RequisitionsiID
        {
            set { _requisitionsiid = value; }
            get { return _requisitionsiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Times
        {
            set { _times = value; }
            get { return _times; }
        }
        #endregion Model

    }
}

