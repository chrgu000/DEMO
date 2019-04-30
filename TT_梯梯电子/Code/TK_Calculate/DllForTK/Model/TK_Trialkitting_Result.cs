using System;
namespace DllForTK.Model
{
    /// <summary>
    /// TK_Trialkitting_Result:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TK_Trialkitting_Result
    {
        public TK_Trialkitting_Result()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private string _stkversion;
        private string _stkversiontype;
        private string _sdataversion;
        private string _createuid;
        private DateTime? _dtmcreate;
        private string _remark;
        private int? _datafrom;
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
        public Guid Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sTKVersion
        {
            set { _stkversion = value; }
            get { return _stkversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sTKVersionType
        {
            set { _stkversiontype = value; }
            get { return _stkversiontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sDataVersion
        {
            set { _sdataversion = value; }
            get { return _sdataversion; }
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
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
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
        /// 计算数据来源：0 同步的数据；1 上传的数据
        /// </summary>
        public int? DataFrom
        {
            set { _datafrom = value; }
            get { return _datafrom; }
        }
        #endregion Model

    }
}

