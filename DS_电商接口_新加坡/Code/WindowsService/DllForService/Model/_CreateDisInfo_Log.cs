using System;
namespace DllForService.Model
{
    /// <summary>
    /// _CreateDisInfo_Log:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _CreateDisInfo_Log
    {
        public _CreateDisInfo_Log()
        { }
        #region Model
        private int _iid;
        private string _csocode;
        private string _discode;
        private string _rdcode;
        private DateTime? _createdate = DateTime.Now;
        private string _status;
        private string _remark;
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
        public string cSOCode
        {
            set { _csocode = value; }
            get { return _csocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DisCode
        {
            set { _discode = value; }
            get { return _discode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RdCode
        {
            set { _rdcode = value; }
            get { return _rdcode; }
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
        public string Status
        {
            set { _status = value; }
            get { return _status; }
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

