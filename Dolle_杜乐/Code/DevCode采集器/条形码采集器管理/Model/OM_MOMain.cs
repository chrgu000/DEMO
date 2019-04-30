using System;
namespace BarCode.Model
{
    /// <summary>
    /// OM_MOMain:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OM_MOMain
    {
        public OM_MOMain()
        { }
        #region Model
        private long _moid;
        private string _ccode;
        private DateTime _ddate;
        private string _cvencode;
        private string _cdepcode;
        private string _cpersoncode;
        private string _cptcode;
        private string _carrivalplace;
        private string _csccode;
        private string _cexch_name;
        private decimal? _nflat;
        private decimal? _itaxrate = 0M;
        private string _cpaycode;
        private decimal? _icost = 0M;
        private decimal? _ibargain = 0M;
        private string _cmemo;
        private string _cmaker;
        private string _cverifier;
        private string _ccloser;
        private string _cdefine1;
        private string _cdefine2;
        private string _cdefine3;
        private DateTime? _cdefine4;
        private long? _cdefine5;
        private DateTime? _cdefine6;
        private decimal? _cdefine7 = 0M;
        private string _cdefine8;
        private string _cdefine9;
        private string _cdefine10;
        private long _ivtid;
        private DateTime _ufts;
        private string _cchanger;
        private string _cbustype;
        private string _cdefine11;
        private string _cdefine12;
        private string _cdefine13;
        private string _cdefine14;
        private long? _cdefine15;
        private decimal? _cdefine16;
        private string _clocker;
        private long _cstate = 0;
        private long _ireturncount = 0;
        private long _iverifystatenew = 0;
        private long _iswfcontrolled = 0;
        private string _cmodifier;
        private DateTime? _dcreatetime = DateTime.Now;
        private DateTime? _dmodifydate;
        private DateTime? _dmodifytime;
        private DateTime? _dverifydate;
        private DateTime? _dverifytime;
        private DateTime? _daltertime;
        private string _cchangeverifier;
        private DateTime? _dchangeverifydate;
        private DateTime? _dchangeverifytime;
        private string _cvenpuomprotocol;
        private long? _iprintcount = 0;
        private DateTime? _dclosedate;
        private DateTime? _dclosetime;
        private string _ccleanver;
        private string _ccontactcode;
        private string _cvenperson;
        private string _cvenbank;
        private string _cvenaccount;
        private string _csrccode;
        private string _csysbarcode;
        private string _ccurrentauditor;
        private long? _iordertype;
        private long? _brework;
        /// <summary>
        /// 
        /// </summary>
        public long MOID
        {
            set { _moid = value; }
            get { return _moid; }
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
        public string cPTCode
        {
            set { _cptcode = value; }
            get { return _cptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cArrivalPlace
        {
            set { _carrivalplace = value; }
            get { return _carrivalplace; }
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
        public decimal? nflat
        {
            set { _nflat = value; }
            get { return _nflat; }
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
        public string cPayCode
        {
            set { _cpaycode = value; }
            get { return _cpaycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iCost
        {
            set { _icost = value; }
            get { return _icost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iBargain
        {
            set { _ibargain = value; }
            get { return _ibargain; }
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
        public string cMaker
        {
            set { _cmaker = value; }
            get { return _cmaker; }
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
        public string cCloser
        {
            set { _ccloser = value; }
            get { return _ccloser; }
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
        public long? cDefine5
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
        public long iVTid
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
        public string cChanger
        {
            set { _cchanger = value; }
            get { return _cchanger; }
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
        public long? cDefine15
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
        public string cLocker
        {
            set { _clocker = value; }
            get { return _clocker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long cState
        {
            set { _cstate = value; }
            get { return _cstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iReturnCount
        {
            set { _ireturncount = value; }
            get { return _ireturncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iVerifyStateNew
        {
            set { _iverifystatenew = value; }
            get { return _iverifystatenew; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long IsWfControlled
        {
            set { _iswfcontrolled = value; }
            get { return _iswfcontrolled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cModifier
        {
            set { _cmodifier = value; }
            get { return _cmodifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dCreateTime
        {
            set { _dcreatetime = value; }
            get { return _dcreatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dModifyDate
        {
            set { _dmodifydate = value; }
            get { return _dmodifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dModifyTime
        {
            set { _dmodifytime = value; }
            get { return _dmodifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dVerifyDate
        {
            set { _dverifydate = value; }
            get { return _dverifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dVerifyTime
        {
            set { _dverifytime = value; }
            get { return _dverifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dAlterTime
        {
            set { _daltertime = value; }
            get { return _daltertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cChangeVerifier
        {
            set { _cchangeverifier = value; }
            get { return _cchangeverifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dChangeVerifyDate
        {
            set { _dchangeverifydate = value; }
            get { return _dchangeverifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dChangeVerifyTime
        {
            set { _dchangeverifytime = value; }
            get { return _dchangeverifytime; }
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
        public long? iPrintCount
        {
            set { _iprintcount = value; }
            get { return _iprintcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dCloseDate
        {
            set { _dclosedate = value; }
            get { return _dclosedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dCloseTime
        {
            set { _dclosetime = value; }
            get { return _dclosetime; }
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
        public string cContactCode
        {
            set { _ccontactcode = value; }
            get { return _ccontactcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVenPerson
        {
            set { _cvenperson = value; }
            get { return _cvenperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVenBank
        {
            set { _cvenbank = value; }
            get { return _cvenbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVenAccount
        {
            set { _cvenaccount = value; }
            get { return _cvenaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csrccode
        {
            set { _csrccode = value; }
            get { return _csrccode; }
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
        /// <summary>
        /// 
        /// </summary>
        public long? iOrderType
        {
            set { _iordertype = value; }
            get { return _iordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? bRework
        {
            set { _brework = value; }
            get { return _brework; }
        }
        #endregion Model

    }
}

