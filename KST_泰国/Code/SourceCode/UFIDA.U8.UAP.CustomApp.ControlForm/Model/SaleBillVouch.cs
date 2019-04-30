using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// SaleBillVouch:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public partial class SaleBillVouch
    {
        public SaleBillVouch()
        { }
        #region Model
        private long _sbvid;
        private string _csbvcode;
        private string _cvouchtype;
        private string _cstcode;
        private DateTime _ddate;
        private string _csaleout;
        private string _crdcode;
        private string _cdepcode;
        private string _cpersoncode;
        private string _csocode;
        private string _ccuscode;
        private string _cpaycode;
        private string _cexch_name;
        private string _cmemo;
        private decimal? _iexchrate = 1M;
        private decimal? _itaxrate = 0M;
        private bool _breturnflag = false;
        private string _cbcode;
        private string _cbillver;
        private string _cmaker;
        private string _cinvalider;
        private string _cverifier;
        private string _cbustype;
        private bool _bfirst = false;
        private string _citem_class;
        private string _citemcode;
        private string _cheadcode;
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
        private string _bpayment;
        private long? _idisp = 0;
        private string _ccusname;
        private string _cdlcode;
        private string _caccounter = "null";
        private string _cchecker = "null";
        private long _ivtid = 0;
        private bool _biafirst = false;
        private DateTime? _ufts;
        private string _ccrechpname;
        private string _cinfotypecode = "null";
        private string _csource;
        private string _cdefine11;
        private string _cdefine12;
        private string _cdefine13;
        private string _cdefine14;
        private long? _cdefine15;
        private decimal? _cdefine16;
        private string _csccode;
        private string _cshipaddress;
        private string _ccusbank;
        private string _ccusaccount;
        private long? _ioutgolden = 0;
        private string _cgatheringplan;
        private DateTime? _dcreditstart;
        private DateTime? _dgatheringdate;
        private long? _icreditdays;
        private bool _bcredit;
        private string _caddcode;
        private long? _iverifystate = 0;
        private long? _ireturncount = 0;
        private long? _iswfcontrolled = 0;
        private string _icreditstate;
        private string _cmodifier;
        private DateTime? _dmoddate;
        private DateTime? _dverifydate;
        private string _ccusperson;
        private DateTime? _dcreatesystime = DateTime.Now;
        private DateTime? _dverifysystime;
        private DateTime? _dmodifysystime;
        private long? _iflowid;
        private bool _bcashsale;
        private Guid _retail_id;
        private string _cbookdepcode;
        private string _cbooktype;
        private string _ccuspersoncode;
        private long? _iprintcount;
        private DateTime? _darverifydate;
        private DateTime? _darverifysystime;
        private string _csysbarcode;
        private string _ccurrentauditor;
        private string _csscode;
        /// <summary>
        /// 
        /// </summary>
        public long SBVID
        {
            set { _sbvid = value; }
            get { return _sbvid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSBVCode
        {
            set { _csbvcode = value; }
            get { return _csbvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVouchType
        {
            set { _cvouchtype = value; }
            get { return _cvouchtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSTCode
        {
            set { _cstcode = value; }
            get { return _cstcode; }
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
        public string cSaleOut
        {
            set { _csaleout = value; }
            get { return _csaleout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cRdCode
        {
            set { _crdcode = value; }
            get { return _crdcode; }
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
        public string cSOCode
        {
            set { _csocode = value; }
            get { return _csocode; }
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
        public string cPayCode
        {
            set { _cpaycode = value; }
            get { return _cpaycode; }
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
        public string cMemo
        {
            set { _cmemo = value; }
            get { return _cmemo; }
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
        public bool bReturnFlag
        {
            set { _breturnflag = value; }
            get { return _breturnflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBCode
        {
            set { _cbcode = value; }
            get { return _cbcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBillVer
        {
            set { _cbillver = value; }
            get { return _cbillver; }
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
        public string cInvalider
        {
            set { _cinvalider = value; }
            get { return _cinvalider; }
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
        public string cBusType
        {
            set { _cbustype = value; }
            get { return _cbustype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bFirst
        {
            set { _bfirst = value; }
            get { return _bfirst; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citem_class
        {
            set { _citem_class = value; }
            get { return _citem_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citemcode
        {
            set { _citemcode = value; }
            get { return _citemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cHeadCode
        {
            set { _cheadcode = value; }
            get { return _cheadcode; }
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
        public string bPayMent
        {
            set { _bpayment = value; }
            get { return _bpayment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iDisp
        {
            set { _idisp = value; }
            get { return _idisp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusName
        {
            set { _ccusname = value; }
            get { return _ccusname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDLCode
        {
            set { _cdlcode = value; }
            get { return _cdlcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cAccounter
        {
            set { _caccounter = value; }
            get { return _caccounter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cChecker
        {
            set { _cchecker = value; }
            get { return _cchecker; }
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
        public bool bIAFirst
        {
            set { _biafirst = value; }
            get { return _biafirst; }
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
        public string cCreChpName
        {
            set { _ccrechpname = value; }
            get { return _ccrechpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInfoTypeCode
        {
            set { _cinfotypecode = value; }
            get { return _cinfotypecode; }
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
        public string cSCCode
        {
            set { _csccode = value; }
            get { return _csccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cShipAddress
        {
            set { _cshipaddress = value; }
            get { return _cshipaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccusbank
        {
            set { _ccusbank = value; }
            get { return _ccusbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccusaccount
        {
            set { _ccusaccount = value; }
            get { return _ccusaccount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ioutgolden
        {
            set { _ioutgolden = value; }
            get { return _ioutgolden; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cgatheringplan
        {
            set { _cgatheringplan = value; }
            get { return _cgatheringplan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dCreditStart
        {
            set { _dcreditstart = value; }
            get { return _dcreditstart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dGatheringDate
        {
            set { _dgatheringdate = value; }
            get { return _dgatheringdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? icreditdays
        {
            set { _icreditdays = value; }
            get { return _icreditdays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bCredit
        {
            set { _bcredit = value; }
            get { return _bcredit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string caddcode
        {
            set { _caddcode = value; }
            get { return _caddcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iverifystate
        {
            set { _iverifystate = value; }
            get { return _iverifystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ireturncount
        {
            set { _ireturncount = value; }
            get { return _ireturncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iswfcontrolled
        {
            set { _iswfcontrolled = value; }
            get { return _iswfcontrolled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icreditstate
        {
            set { _icreditstate = value; }
            get { return _icreditstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cmodifier
        {
            set { _cmodifier = value; }
            get { return _cmodifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dmoddate
        {
            set { _dmoddate = value; }
            get { return _dmoddate; }
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
        public string ccusperson
        {
            set { _ccusperson = value; }
            get { return _ccusperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dcreatesystime
        {
            set { _dcreatesystime = value; }
            get { return _dcreatesystime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dverifysystime
        {
            set { _dverifysystime = value; }
            get { return _dverifysystime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dmodifysystime
        {
            set { _dmodifysystime = value; }
            get { return _dmodifysystime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iflowid
        {
            set { _iflowid = value; }
            get { return _iflowid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bcashsale
        {
            set { _bcashsale = value; }
            get { return _bcashsale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid retail_id
        {
            set { _retail_id = value; }
            get { return _retail_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBookDepcode
        {
            set { _cbookdepcode = value; }
            get { return _cbookdepcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBookType
        {
            set { _cbooktype = value; }
            get { return _cbooktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccuspersoncode
        {
            set { _ccuspersoncode = value; }
            get { return _ccuspersoncode; }
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
        public DateTime? dArverifydate
        {
            set { _darverifydate = value; }
            get { return _darverifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dArverifysystime
        {
            set { _darverifysystime = value; }
            get { return _darverifysystime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSysBarCode
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
        public string csscode
        {
            set { _csscode = value; }
            get { return _csscode; }
        }
        #endregion Model

    }
}

