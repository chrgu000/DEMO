using System;
namespace Model
{
    /// <summary>
    /// hr_tm_SignCardData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class hr_tm_SignCardData
    {
        public hr_tm_SignCardData()
        { }
        #region Model
        private Guid _urecordid;
        private string _cpsn_num;
        private string _vcardno;
        private DateTime? _ddatetime;
        private bool _bduty;
        private bool _bovertime;
        private bool _bmanual;
        private string _iperiodid;
        private int? _iflag;
        private string _coptpsn_num;
        private DateTime? _dsystime;
        private string _vremark;
        private string _vreason;
        private DateTime? _dolddatetime;
        private int? _irecordid;
        private bool _blastflag;
        private string _vstatus1;
        private decimal? _nstatus2;
        private int? _beffect;
        private bool _bauditflag;
        private string _cauditornum;
        private string _daudittime;
        private string _jobnumber;
        private string _nmachine_num;
        private string _voucherid;
        private int? _cexamineapprovetype;
        private string _cmobilesitecode;
        private string _cmobilesiteaddress;
        private string _cintitude;
        private string _clatitude;
        private string _csource;
        /// <summary>
        /// 
        /// </summary>
        public Guid uRecordId
        {
            set { _urecordid = value; }
            get { return _urecordid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPsn_Num
        {
            set { _cpsn_num = value; }
            get { return _cpsn_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vCardNo
        {
            set { _vcardno = value; }
            get { return _vcardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dDateTime
        {
            set { _ddatetime = value; }
            get { return _ddatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bDuty
        {
            set { _bduty = value; }
            get { return _bduty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bOverTime
        {
            set { _bovertime = value; }
            get { return _bovertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bManual
        {
            set { _bmanual = value; }
            get { return _bmanual; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iPeriodId
        {
            set { _iperiodid = value; }
            get { return _iperiodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iFlag
        {
            set { _iflag = value; }
            get { return _iflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cOptPsn_Num
        {
            set { _coptpsn_num = value; }
            get { return _coptpsn_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dSysTime
        {
            set { _dsystime = value; }
            get { return _dsystime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vRemark
        {
            set { _vremark = value; }
            get { return _vremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vReason
        {
            set { _vreason = value; }
            get { return _vreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dOldDateTime
        {
            set { _dolddatetime = value; }
            get { return _dolddatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iRecordId
        {
            set { _irecordid = value; }
            get { return _irecordid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bLastFlag
        {
            set { _blastflag = value; }
            get { return _blastflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vStatus1
        {
            set { _vstatus1 = value; }
            get { return _vstatus1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? nStatus2
        {
            set { _nstatus2 = value; }
            get { return _nstatus2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bEffect
        {
            set { _beffect = value; }
            get { return _beffect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bAuditFlag
        {
            set { _bauditflag = value; }
            get { return _bauditflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cAuditorNum
        {
            set { _cauditornum = value; }
            get { return _cauditornum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dAuditTime
        {
            set { _daudittime = value; }
            get { return _daudittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JobNumber
        {
            set { _jobnumber = value; }
            get { return _jobnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nMachine_Num
        {
            set { _nmachine_num = value; }
            get { return _nmachine_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VoucherID
        {
            set { _voucherid = value; }
            get { return _voucherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cExamineApproveType
        {
            set { _cexamineapprovetype = value; }
            get { return _cexamineapprovetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMobileSiteCode
        {
            set { _cmobilesitecode = value; }
            get { return _cmobilesitecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMobileSiteAddress
        {
            set { _cmobilesiteaddress = value; }
            get { return _cmobilesiteaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cintitude
        {
            set { _cintitude = value; }
            get { return _cintitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cLatitude
        {
            set { _clatitude = value; }
            get { return _clatitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSource
        {
            set { _csource = value; }
            get { return _csource; }
        }
        #endregion Model

    }
}

