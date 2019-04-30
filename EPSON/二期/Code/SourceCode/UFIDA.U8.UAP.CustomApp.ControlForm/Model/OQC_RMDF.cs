using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _OQC_RMDF:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _OQC_RMDF
    {
        public _OQC_RMDF()
        { }
        #region Model
        private long _iid;
        private string _oqcno;
        private string _oqcstatus;
        private long? _isosid;
        private string _lotno;
        private string _cinvcode;
        private string _cinvname;
        private long? _sstatus;
        private string _action;
        private decimal? _lotqty;
        private decimal? _insqty;
        private decimal? _samplesize;
        private string _ccuscode;
        private string _aqllevel;
        private decimal? _accept;
        private decimal? _reject;
        private string _result;
        private DateTime? _dtmreceived;
        private DateTime? _dtminspected;
        private string _inspectedby;
        private string _createuid;
        private DateTime? _dtmcreate;
        private string _updateuid;
        private DateTime? _dtmupdate;
        private string _audituid;
        private DateTime? _dtmaudit;
        private long? _sendmailcount;
        private string _sendmailuid;
        private DateTime? _dtmsendmail;
        private string _feedback;
        private long? _savecount;
        private string _process;
        private string _closeduid;
        private DateTime? _dtmclose;
        private string _plater;
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
        public string OQCStatus
        {
            set { _oqcstatus = value; }
            get { return _oqcstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iSOsID
        {
            set { _isosid = value; }
            get { return _isosid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LotNo
        {
            set { _lotno = value; }
            get { return _lotno; }
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
        public string cInvName
        {
            set { _cinvname = value; }
            get { return _cinvname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? sStatus
        {
            set { _sstatus = value; }
            get { return _sstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Action
        {
            set { _action = value; }
            get { return _action; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LotQty
        {
            set { _lotqty = value; }
            get { return _lotqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? InsQty
        {
            set { _insqty = value; }
            get { return _insqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SampleSize
        {
            set { _samplesize = value; }
            get { return _samplesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusCode
        {
            set { _ccuscode = value; }
            get { return _ccuscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AQLLevel
        {
            set { _aqllevel = value; }
            get { return _aqllevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Accept
        {
            set { _accept = value; }
            get { return _accept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Reject
        {
            set { _reject = value; }
            get { return _reject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmReceived
        {
            set { _dtmreceived = value; }
            get { return _dtmreceived; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmInspected
        {
            set { _dtminspected = value; }
            get { return _dtminspected; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InspectedBy
        {
            set { _inspectedby = value; }
            get { return _inspectedby; }
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
        public string UpdateUid
        {
            set { _updateuid = value; }
            get { return _updateuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmUpdate
        {
            set { _dtmupdate = value; }
            get { return _dtmupdate; }
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
        public DateTime? dtmAudit
        {
            set { _dtmaudit = value; }
            get { return _dtmaudit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SendMailCount
        {
            set { _sendmailcount = value; }
            get { return _sendmailcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SendMailUid
        {
            set { _sendmailuid = value; }
            get { return _sendmailuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmSendMail
        {
            set { _dtmsendmail = value; }
            get { return _dtmsendmail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Feedback
        {
            set { _feedback = value; }
            get { return _feedback; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SaveCount
        {
            set { _savecount = value; }
            get { return _savecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Process
        {
            set { _process = value; }
            get { return _process; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClosedUid
        {
            set { _closeduid = value; }
            get { return _closeduid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmClose
        {
            set { _dtmclose = value; }
            get { return _dtmclose; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Plater
        {
            set { _plater = value; }
            get { return _plater; }
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

