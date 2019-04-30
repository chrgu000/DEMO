using System;
namespace BarCode.Model
{
    /// <summary>
    /// PU_ArrivalVouch:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PU_ArrivalVouch
    {
        public PU_ArrivalVouch()
        { }
        #region Model
        private int _ivtid;
        private DateTime _ufts;
        private int _id;
        private string _ccode;
        private string _cptcode;
        private DateTime _ddate;
        private string _cvencode;
        private string _cdepcode;
        private string _cpersoncode;
        private string _cpaycode;
        private string _csccode;
        private string _cexch_name;
        private decimal? _iexchrate;
        private decimal? _itaxrate;
        private string _cmemo;
        private string _cbustype;
        private string _cmaker;
        private int _bnegative = 0;
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
        private string _ccloser;
        private int? _idiscounttaxtype = 0;
        private int _ibilltype = 0;
        private string _cvouchtype;
        private string _cgeneralordercode;
        private string _ctmcode;
        private string _cincotermcode;
        private string _ctransordercode;
        private DateTime? _dportdate;
        private string _csportcode;
        private string _caportcode;
        private string _csvencode;
        private string _carrivalplace;
        private DateTime? _dclosedate;
        private int? _idec;
        private bool _bcal;
        private string _guid;
        private DateTime? _cmaketime = DateTime.Now;
        private DateTime? _cmodifytime;
        private DateTime? _cmodifydate;
        private string _creviser;
        private int? _iverifystate;
        private DateTime? _cauditdate;
        private DateTime? _caudittime;
        private string _cverifier;
        private int? _iverifystateex;
        private int? _ireturncount;
        private bool _iswfcontrolled = false;
        private string _cvenpuomprotocol;
        private string _cchanger;
        private int? _iflowid;
        private int? _iprintcount = 0;
        private string _ccleanver;
        private string _cpocode;
        private string _csysbarcode;
        private string _ccurrentauditor;
        /// <summary>
        /// 
        /// </summary>
        public int iVTid
        {
            set { _ivtid = value; }
            get { return _ivtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        public string cPTCode
        {
            set { _cptcode = value; }
            get { return _cptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVenCode
        {
            set { _cvencode = value; }
            get { return _cvencode; }
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
        public string cPersonCode
        {
            set { _cpersoncode = value; }
            get { return _cpersoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPayCode
        {
            set { _cpaycode = value; }
            get { return _cpaycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSCCode
        {
            set { _csccode = value; }
            get { return _csccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cexch_name
        {
            set { _cexch_name = value; }
            get { return _cexch_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iExchRate
        {
            set { _iexchrate = value; }
            get { return _iexchrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxRate
        {
            set { _itaxrate = value; }
            get { return _itaxrate; }
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
        public string cBusType
        {
            set { _cbustype = value; }
            get { return _cbustype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMaker
        {
            set { _cmaker = value; }
            get { return _cmaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bNegative
        {
            set { _bnegative = value; }
            get { return _bnegative; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine1
        {
            set { _cdefine1 = value; }
            get { return _cdefine1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine2
        {
            set { _cdefine2 = value; }
            get { return _cdefine2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine3
        {
            set { _cdefine3 = value; }
            get { return _cdefine3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine4
        {
            set { _cdefine4 = value; }
            get { return _cdefine4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine5
        {
            set { _cdefine5 = value; }
            get { return _cdefine5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine6
        {
            set { _cdefine6 = value; }
            get { return _cdefine6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine7
        {
            set { _cdefine7 = value; }
            get { return _cdefine7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine8
        {
            set { _cdefine8 = value; }
            get { return _cdefine8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine9
        {
            set { _cdefine9 = value; }
            get { return _cdefine9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine10
        {
            set { _cdefine10 = value; }
            get { return _cdefine10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine11
        {
            set { _cdefine11 = value; }
            get { return _cdefine11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine12
        {
            set { _cdefine12 = value; }
            get { return _cdefine12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine13
        {
            set { _cdefine13 = value; }
            get { return _cdefine13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine14
        {
            set { _cdefine14 = value; }
            get { return _cdefine14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine15
        {
            set { _cdefine15 = value; }
            get { return _cdefine15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine16
        {
            set { _cdefine16 = value; }
            get { return _cdefine16; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccloser
        {
            set { _ccloser = value; }
            get { return _ccloser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iDiscountTaxType
        {
            set { _idiscounttaxtype = value; }
            get { return _idiscounttaxtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iBillType
        {
            set { _ibilltype = value; }
            get { return _ibilltype; }
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
        public string cgeneralordercode
        {
            set { _cgeneralordercode = value; }
            get { return _cgeneralordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ctmcode
        {
            set { _ctmcode = value; }
            get { return _ctmcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cincotermcode
        {
            set { _cincotermcode = value; }
            get { return _cincotermcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ctransordercode
        {
            set { _ctransordercode = value; }
            get { return _ctransordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dportdate
        {
            set { _dportdate = value; }
            get { return _dportdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csportcode
        {
            set { _csportcode = value; }
            get { return _csportcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string caportcode
        {
            set { _caportcode = value; }
            get { return _caportcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csvencode
        {
            set { _csvencode = value; }
            get { return _csvencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string carrivalplace
        {
            set { _carrivalplace = value; }
            get { return _carrivalplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dclosedate
        {
            set { _dclosedate = value; }
            get { return _dclosedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idec
        {
            set { _idec = value; }
            get { return _idec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bcal
        {
            set { _bcal = value; }
            get { return _bcal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string guid
        {
            set { _guid = value; }
            get { return _guid; }
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
        public int? iverifystate
        {
            set { _iverifystate = value; }
            get { return _iverifystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cAuditDate
        {
            set { _cauditdate = value; }
            get { return _cauditdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? caudittime
        {
            set { _caudittime = value; }
            get { return _caudittime; }
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
        public int? iverifystateex
        {
            set { _iverifystateex = value; }
            get { return _iverifystateex; }
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
        public bool IsWfControlled
        {
            set { _iswfcontrolled = value; }
            get { return _iswfcontrolled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVenPUOMProtocol
        {
            set { _cvenpuomprotocol = value; }
            get { return _cvenpuomprotocol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cchanger
        {
            set { _cchanger = value; }
            get { return _cchanger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iflowid
        {
            set { _iflowid = value; }
            get { return _iflowid; }
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
        public string cpocode
        {
            set { _cpocode = value; }
            get { return _cpocode; }
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

