using System;
namespace TH.Model
{
    /// <summary>
    /// _产品工序:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _产品工序
    {
        public _产品工序()
        { }
        #region Model
        private int? _iid;
        private string _cinvcode;
        private string _irow;
        private string _workprocessno;
        private string _remark;
        private string _createuid;
        private DateTime? _createdate;
        /// <summary>
        /// 
        /// </summary>
        public int? iID
        {
            set { _iid = value; }
            get { return _iid; }
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
        public string iRow
        {
            set { _irow = value; }
            get { return _irow; }
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
        #endregion Model

    }
}

