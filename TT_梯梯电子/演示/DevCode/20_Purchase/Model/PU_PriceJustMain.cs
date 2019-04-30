using System;
namespace Purchase.Model
{
    /// <summary>
    /// PU_PriceJustMain:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PU_PriceJustMain
    {
        public PU_PriceJustMain()
        { }
        #region Model
        private long _id;
        private DateTime? _ddate;
        private string _ccode;
        private string _cmaker;
        private string _cpersoncode;
        private string _cmainmemo;
        private string _cverifier;
        private DateTime? _dverifydate;
        private string _cdepcode;
        private long? _ivtid;
        private string _cdefine1;
        private string _cdefine2;
        private string _cdefine3;
        private DateTime? _cdefine4;
        private int? _cdefine5;
        private DateTime? _cdefine6;
        private decimal? _cdefine7;
        private string _cdefine8;
        private string _cdefine9;
        private string _cdefine10;
        private string _cdefine11;
        private string _cdefine12;
        private string _cdefine13;
        private string _cdefine14;
        private int? _cdefine15;
        private decimal? _cdefine16;
        private DateTime? _ufts;
        private int? _iverifystate = 0;
        private int? _ireturncount = 0;
        private bool _iswfcontrolled = false;
        private int? _btaxcost = 0;
        private int? _isupplytype = 1;
        private DateTime? _cmaketime = DateTime.Now;
        private DateTime? _cmodifytime;
        private DateTime? _caudittime;
        private DateTime? _cmodifydate;
        private string _creviser;
        private int? _iprintcount = 0;
        private string _ccleanver;
        private string _csysbarcode;
        private string _ccurrentauditor;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ddate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cmaker
        {
            set { _cmaker = value; }
            get { return _cmaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpersoncode
        {
            set { _cpersoncode = value; }
            get { return _cpersoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cmainmemo
        {
            set { _cmainmemo = value; }
            get { return _cmainmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cverifier
        {
            set { _cverifier = value; }
            get { return _cverifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dverifydate
        {
            set { _dverifydate = value; }
            get { return _dverifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdepcode
        {
            set { _cdepcode = value; }
            get { return _cdepcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ivtid
        {
            set { _ivtid = value; }
            get { return _ivtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine1
        {
            set { _cdefine1 = value; }
            get { return _cdefine1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine2
        {
            set { _cdefine2 = value; }
            get { return _cdefine2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine3
        {
            set { _cdefine3 = value; }
            get { return _cdefine3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cdefine4
        {
            set { _cdefine4 = value; }
            get { return _cdefine4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cdefine5
        {
            set { _cdefine5 = value; }
            get { return _cdefine5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cdefine6
        {
            set { _cdefine6 = value; }
            get { return _cdefine6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cdefine7
        {
            set { _cdefine7 = value; }
            get { return _cdefine7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine8
        {
            set { _cdefine8 = value; }
            get { return _cdefine8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine9
        {
            set { _cdefine9 = value; }
            get { return _cdefine9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine10
        {
            set { _cdefine10 = value; }
            get { return _cdefine10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine11
        {
            set { _cdefine11 = value; }
            get { return _cdefine11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine12
        {
            set { _cdefine12 = value; }
            get { return _cdefine12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine13
        {
            set { _cdefine13 = value; }
            get { return _cdefine13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdefine14
        {
            set { _cdefine14 = value; }
            get { return _cdefine14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cdefine15
        {
            set { _cdefine15 = value; }
            get { return _cdefine15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cdefine16
        {
            set { _cdefine16 = value; }
            get { return _cdefine16; }
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
        public int? iverifystate
        {
            set { _iverifystate = value; }
            get { return _iverifystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ireturncount
        {
            set { _ireturncount = value; }
            get { return _ireturncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool iswfcontrolled
        {
            set { _iswfcontrolled = value; }
            get { return _iswfcontrolled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bTaxCost
        {
            set { _btaxcost = value; }
            get { return _btaxcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iSupplyType
        {
            set { _isupplytype = value; }
            get { return _isupplytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cMakeTime
        {
            set { _cmaketime = value; }
            get { return _cmaketime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cModifyTime
        {
            set { _cmodifytime = value; }
            get { return _cmodifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cAuditTime
        {
            set { _caudittime = value; }
            get { return _caudittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cModifyDate
        {
            set { _cmodifydate = value; }
            get { return _cmodifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cReviser
        {
            set { _creviser = value; }
            get { return _creviser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iPrintCount
        {
            set { _iprintcount = value; }
            get { return _iprintcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccleanver
        {
            set { _ccleanver = value; }
            get { return _ccleanver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csysbarcode
        {
            set { _csysbarcode = value; }
            get { return _csysbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCurrentAuditor
        {
            set { _ccurrentauditor = value; }
            get { return _ccurrentauditor; }
        }
        #endregion Model

    }
}

