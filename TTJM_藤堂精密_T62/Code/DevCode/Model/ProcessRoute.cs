using System;
namespace TH.Model
{
    /// <summary>
    /// ProcessRoute:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProcessRoute
    {
        public ProcessRoute()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private string _createuid;
        private DateTime _createdate;
        private string _updatauid;
        private DateTime? _updatadate;
        private string _audituid;
        private DateTime? _auditdate;
        private string _closeuid;
        private DateTime? _closedate;
        private string _cinvcode;
        private string _versions;
        private string _worksort;
        private string _workprocessno;
        private string _cdepcode;
        private string _remark;
        private string _remark2;
        private string _remark3;
        private string _remark4;
        private string _remark5;
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
        public Guid GUID
        {
            set { _guid = value; }
            get { return _guid; }
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
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdataUid
        {
            set { _updatauid = value; }
            get { return _updatauid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdataDate
        {
            set { _updatadate = value; }
            get { return _updatadate; }
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
        /// <summary>
        /// 
        /// </summary>
        public string CloseUid
        {
            set { _closeuid = value; }
            get { return _closeuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseDate
        {
            set { _closedate = value; }
            get { return _closedate; }
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
        public string Versions
        {
            set { _versions = value; }
            get { return _versions; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkSort
        {
            set { _worksort = value; }
            get { return _worksort; }
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
        public string cDepCode
        {
            set { _cdepcode = value; }
            get { return _cdepcode; }
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
        public string Remark2
        {
            set { _remark2 = value; }
            get { return _remark2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark3
        {
            set { _remark3 = value; }
            get { return _remark3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark4
        {
            set { _remark4 = value; }
            get { return _remark4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark5
        {
            set { _remark5 = value; }
            get { return _remark5; }
        }
        #endregion Model

    }
}

