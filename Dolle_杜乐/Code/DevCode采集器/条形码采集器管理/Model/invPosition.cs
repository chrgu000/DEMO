using System;
namespace BarCode.Model
{
    /// <summary>
    /// InvPosition:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class InvPosition
    {
        public InvPosition()
        { }
        #region Model
        private long _autoid;
        private long _rdsid;
        private long _rdid;
        private string _cwhcode;
        private string _cposcode;
        private string _cinvcode;
        private string _cbatch = "";
        private string _cfree1 = "";
        private string _cfree2 = "";
        private DateTime? _dvdate;
        private decimal? _iquantity;
        private decimal? _inum;
        private string _cmemo;
        private string _chandler;
        private DateTime? _ddate;
        private long _brdflag = 1;
        private string _csource;
        private string _cfree3 = "";
        private string _cfree4 = "";
        private string _cfree5 = "";
        private string _cfree6 = "";
        private string _cfree7 = "";
        private string _cfree8 = "";
        private string _cfree9 = "";
        private string _cfree10 = "";
        private string _cassunit;
        private string _cbvencode;
        private long? _itrackid;
        private DateTime? _ufts;
        private DateTime? _dmadedate;
        private long? _imassdate;
        private long? _cmassunit;
        private string _cvmivencode = "null";
        private long? _iexpiratdatecalcu;
        private string _cexpirationdate;
        private DateTime? _dexpirationdate;
        private string _cvouchtype;
        private string _cinvouchtype;
        private string _cverifier;
        private DateTime? _dveridate;
        private DateTime? _dvouchdate;
        /// <summary>
        /// 
        /// </summary>
        public long AutoID
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long RdsID
        {
            set { _rdsid = value; }
            get { return _rdsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long RdID
        {
            set { _rdid = value; }
            get { return _rdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cWhCode
        {
            set { _cwhcode = value; }
            get { return _cwhcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPosCode
        {
            set { _cposcode = value; }
            get { return _cposcode; }
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
        public string cBatch
        {
            set { _cbatch = value; }
            get { return _cbatch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree1
        {
            set { _cfree1 = value; }
            get { return _cfree1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree2
        {
            set { _cfree2 = value; }
            get { return _cfree2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dVDate
        {
            set { _dvdate = value; }
            get { return _dvdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iQuantity
        {
            set { _iquantity = value; }
            get { return _iquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNum
        {
            set { _inum = value; }
            get { return _inum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMemo
        {
            set { _cmemo = value; }
            get { return _cmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cHandler
        {
            set { _chandler = value; }
            get { return _chandler; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long bRdFlag
        {
            set { _brdflag = value; }
            get { return _brdflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSource
        {
            set { _csource = value; }
            get { return _csource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree3
        {
            set { _cfree3 = value; }
            get { return _cfree3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree4
        {
            set { _cfree4 = value; }
            get { return _cfree4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree5
        {
            set { _cfree5 = value; }
            get { return _cfree5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree6
        {
            set { _cfree6 = value; }
            get { return _cfree6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree7
        {
            set { _cfree7 = value; }
            get { return _cfree7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree8
        {
            set { _cfree8 = value; }
            get { return _cfree8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree9
        {
            set { _cfree9 = value; }
            get { return _cfree9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree10
        {
            set { _cfree10 = value; }
            get { return _cfree10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cAssUnit
        {
            set { _cassunit = value; }
            get { return _cassunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBVencode
        {
            set { _cbvencode = value; }
            get { return _cbvencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iTrackId
        {
            set { _itrackid = value; }
            get { return _itrackid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dMadeDate
        {
            set { _dmadedate = value; }
            get { return _dmadedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iMassDate
        {
            set { _imassdate = value; }
            get { return _imassdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cMassUnit
        {
            set { _cmassunit = value; }
            get { return _cmassunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cvmivencode
        {
            set { _cvmivencode = value; }
            get { return _cvmivencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iExpiratDateCalcu
        {
            set { _iexpiratdatecalcu = value; }
            get { return _iexpiratdatecalcu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cExpirationdate
        {
            set { _cexpirationdate = value; }
            get { return _cexpirationdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dExpirationdate
        {
            set { _dexpirationdate = value; }
            get { return _dexpirationdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cvouchtype
        {
            set { _cvouchtype = value; }
            get { return _cvouchtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInVouchType
        {
            set { _cinvouchtype = value; }
            get { return _cinvouchtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVerifier
        {
            set { _cverifier = value; }
            get { return _cverifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dVeriDate
        {
            set { _dveridate = value; }
            get { return _dveridate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dVouchDate
        {
            set { _dvouchdate = value; }
            get { return _dvouchdate; }
        }
        #endregion Model

    }
}


