using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// DispatchList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DispatchList
	{
		public DispatchList()
		{}
		#region Model
		private long _dlid=0;
		private string _cdlcode;
		private string _cvouchtype;
		private string _cstcode;
		private DateTime _ddate;
		private string _crdcode;
		private string _cdepcode;
		private string _cpersoncode;
		private long _sbvid= 0;
		private string _csbvcode;
		private string _csocode;
		private string _ccuscode;
		private string _cpaycode;
		private string _csccode;
		private string _cshipaddress;
		private string _cexch_name= "人民币";
		private decimal _iexchrate= 1M;
		private decimal? _itaxrate=0M;
		private bool _bfirst= false;
		private bool _breturnflag= false;
		private bool _bsettleall= false;
		private string _cmemo;
		private string _csaleout;
		private string _cdefine1;
		private string _cdefine2;
		private string _cdefine3;
		private DateTime? _cdefine4;
		private long? _cdefine5;
		private DateTime? _cdefine6;
		private decimal? _cdefine7= 0M;
		private string _cdefine8;
		private string _cdefine9;
		private string _cdefine10;
		private string _cverifier;
		private string _cmaker;
		private decimal? _inetlock= 0M;
		private long? _isale=0;
		private string _ccusname;
		private long _ivtid=0;
		private DateTime? _ufts;
		private string _cbustype;
		private string _ccloser;
		private string _caccounter;
		private string _ccrechpname;
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private long? _cdefine15;
		private decimal? _cdefine16;
		private bool _biafirst= false;
		private long? _ioutgolden=0;
		private string _cgatheringplan;
		private DateTime? _dcreditstart;
		private DateTime? _dgatheringdate;
		private long? _icreditdays;
		private bool _bcredit;
		private string _caddcode;
		private long? _iverifystate=0;
		private long? _ireturncount=0;
		private long? _iswfcontrolled=0;
		private string _icreditstate;
		private bool _barfirst= false;
		private string _cmodifier;
		private DateTime? _dmoddate;
		private DateTime? _dverifydate;
		private string _ccusperson;
		private DateTime? _dcreatesystime= DateTime.Now;
		private DateTime? _dverifysystime;
		private DateTime? _dmodifysystime;
		private string _csvouchtype;
		private string _cchanger;
		private long? _iflowid;
		private bool _bsigncreate;
		private bool _bcashsale;
		private string _cgathingcode;
		private string _cchangememo;
		private Guid _outid;
		private bool _bmustbook;
		private string _cbookdepcode;
		private string _cbooktype;
		private bool _bsaused;
		private bool _bneedbill;
		private bool _baccswitchflag;
		private long? _iprintcount;
		private string _ccuspersoncode;
		private string _csourcecode;
		private bool _bsaleoutcreatebill;
		private string _csysbarcode;
		private string _ccurrentauditor;
		private string _csscode;
		private string _cinvoicecompany;
		private decimal? _febweight;
		private string _cebweightunit;
		private string _cebexpresscode;
		private long? _iebexpresscoid;
		private long? _separateid;
		private long? _bnottogoldtax;
		private string _cebtrnumber;
		private string _cebbuyer;
		private string _cebbuyernote;
		private string _ccontactname;
		private string _cebprovince;
		private string _cebcity;
		private string _cebdistrict;
		private string _cmobilephone;
		private string _cinvoicecusname;
		private string _cweighter;
		private DateTime? _dweighttime;
		private string _cpickvouchcode;
		/// <summary>
		/// 
		/// </summary>
		public long DLID
		{
			set{ _dlid=value;}
			get{return _dlid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDLCode
		{
			set{ _cdlcode=value;}
			get{return _cdlcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVouchType
		{
			set{ _cvouchtype=value;}
			get{return _cvouchtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSTCode
		{
			set{ _cstcode=value;}
			get{return _cstcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dDate
		{
			set{ _ddate=value;}
			get{return _ddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cRdCode
		{
			set{ _crdcode=value;}
			get{return _crdcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDepCode
		{
			set{ _cdepcode=value;}
			get{return _cdepcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPersonCode
		{
			set{ _cpersoncode=value;}
			get{return _cpersoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long SBVID
		{
			set{ _sbvid=value;}
			get{return _sbvid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSBVCode
		{
			set{ _csbvcode=value;}
			get{return _csbvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSOCode
		{
			set{ _csocode=value;}
			get{return _csocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCusCode
		{
			set{ _ccuscode=value;}
			get{return _ccuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPayCode
		{
			set{ _cpaycode=value;}
			get{return _cpaycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSCCode
		{
			set{ _csccode=value;}
			get{return _csccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cShipAddress
		{
			set{ _cshipaddress=value;}
			get{return _cshipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cexch_name
		{
			set{ _cexch_name=value;}
			get{return _cexch_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal iExchRate
		{
			set{ _iexchrate=value;}
			get{return _iexchrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTaxRate
		{
			set{ _itaxrate=value;}
			get{return _itaxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bFirst
		{
			set{ _bfirst=value;}
			get{return _bfirst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bReturnFlag
		{
			set{ _breturnflag=value;}
			get{return _breturnflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bSettleAll
		{
			set{ _bsettleall=value;}
			get{return _bsettleall;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cMemo
		{
			set{ _cmemo=value;}
			get{return _cmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSaleOut
		{
			set{ _csaleout=value;}
			get{return _csaleout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine1
		{
			set{ _cdefine1=value;}
			get{return _cdefine1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine2
		{
			set{ _cdefine2=value;}
			get{return _cdefine2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine3
		{
			set{ _cdefine3=value;}
			get{return _cdefine3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cDefine4
		{
			set{ _cdefine4=value;}
			get{return _cdefine4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? cDefine5
		{
			set{ _cdefine5=value;}
			get{return _cdefine5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cDefine6
		{
			set{ _cdefine6=value;}
			get{return _cdefine6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cDefine7
		{
			set{ _cdefine7=value;}
			get{return _cdefine7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine8
		{
			set{ _cdefine8=value;}
			get{return _cdefine8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine9
		{
			set{ _cdefine9=value;}
			get{return _cdefine9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine10
		{
			set{ _cdefine10=value;}
			get{return _cdefine10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVerifier
		{
			set{ _cverifier=value;}
			get{return _cverifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cMaker
		{
			set{ _cmaker=value;}
			get{return _cmaker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNetLock
		{
			set{ _inetlock=value;}
			get{return _inetlock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iSale
		{
			set{ _isale=value;}
			get{return _isale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCusName
		{
			set{ _ccusname=value;}
			get{return _ccusname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iVTid
		{
			set{ _ivtid=value;}
			get{return _ivtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ufts
		{
			set{ _ufts=value;}
			get{return _ufts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBusType
		{
			set{ _cbustype=value;}
			get{return _cbustype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCloser
		{
			set{ _ccloser=value;}
			get{return _ccloser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cAccounter
		{
			set{ _caccounter=value;}
			get{return _caccounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCreChpName
		{
			set{ _ccrechpname=value;}
			get{return _ccrechpname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine11
		{
			set{ _cdefine11=value;}
			get{return _cdefine11;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine12
		{
			set{ _cdefine12=value;}
			get{return _cdefine12;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine13
		{
			set{ _cdefine13=value;}
			get{return _cdefine13;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine14
		{
			set{ _cdefine14=value;}
			get{return _cdefine14;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? cDefine15
		{
			set{ _cdefine15=value;}
			get{return _cdefine15;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cDefine16
		{
			set{ _cdefine16=value;}
			get{return _cdefine16;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bIAFirst
		{
			set{ _biafirst=value;}
			get{return _biafirst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? ioutgolden
		{
			set{ _ioutgolden=value;}
			get{return _ioutgolden;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cgatheringplan
		{
			set{ _cgatheringplan=value;}
			get{return _cgatheringplan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dCreditStart
		{
			set{ _dcreditstart=value;}
			get{return _dcreditstart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dGatheringDate
		{
			set{ _dgatheringdate=value;}
			get{return _dgatheringdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? icreditdays
		{
			set{ _icreditdays=value;}
			get{return _icreditdays;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bCredit
		{
			set{ _bcredit=value;}
			get{return _bcredit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string caddcode
		{
			set{ _caddcode=value;}
			get{return _caddcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iverifystate
		{
			set{ _iverifystate=value;}
			get{return _iverifystate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? ireturncount
		{
			set{ _ireturncount=value;}
			get{return _ireturncount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iswfcontrolled
		{
			set{ _iswfcontrolled=value;}
			get{return _iswfcontrolled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string icreditstate
		{
			set{ _icreditstate=value;}
			get{return _icreditstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bARFirst
		{
			set{ _barfirst=value;}
			get{return _barfirst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cmodifier
		{
			set{ _cmodifier=value;}
			get{return _cmodifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dmoddate
		{
			set{ _dmoddate=value;}
			get{return _dmoddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dverifydate
		{
			set{ _dverifydate=value;}
			get{return _dverifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ccusperson
		{
			set{ _ccusperson=value;}
			get{return _ccusperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dcreatesystime
		{
			set{ _dcreatesystime=value;}
			get{return _dcreatesystime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dverifysystime
		{
			set{ _dverifysystime=value;}
			get{return _dverifysystime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dmodifysystime
		{
			set{ _dmodifysystime=value;}
			get{return _dmodifysystime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csvouchtype
		{
			set{ _csvouchtype=value;}
			get{return _csvouchtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cChanger
		{
			set{ _cchanger=value;}
			get{return _cchanger;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iflowid
		{
			set{ _iflowid=value;}
			get{return _iflowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bsigncreate
		{
			set{ _bsigncreate=value;}
			get{return _bsigncreate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bcashsale
		{
			set{ _bcashsale=value;}
			get{return _bcashsale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cgathingcode
		{
			set{ _cgathingcode=value;}
			get{return _cgathingcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cChangeMemo
		{
			set{ _cchangememo=value;}
			get{return _cchangememo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid outid
		{
			set{ _outid=value;}
			get{return _outid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bmustbook
		{
			set{ _bmustbook=value;}
			get{return _bmustbook;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBookDepcode
		{
			set{ _cbookdepcode=value;}
			get{return _cbookdepcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBookType
		{
			set{ _cbooktype=value;}
			get{return _cbooktype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bSaUsed
		{
			set{ _bsaused=value;}
			get{return _bsaused;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bneedbill
		{
			set{ _bneedbill=value;}
			get{return _bneedbill;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool baccswitchflag
		{
			set{ _baccswitchflag=value;}
			get{return _baccswitchflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iPrintCount
		{
			set{ _iprintcount=value;}
			get{return _iprintcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ccuspersoncode
		{
			set{ _ccuspersoncode=value;}
			get{return _ccuspersoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSourceCode
		{
			set{ _csourcecode=value;}
			get{return _csourcecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bsaleoutcreatebill
		{
			set{ _bsaleoutcreatebill=value;}
			get{return _bsaleoutcreatebill;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSysBarCode
		{
			set{ _csysbarcode=value;}
			get{return _csysbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCurrentAuditor
		{
			set{ _ccurrentauditor=value;}
			get{return _ccurrentauditor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csscode
		{
			set{ _csscode=value;}
			get{return _csscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cinvoicecompany
		{
			set{ _cinvoicecompany=value;}
			get{return _cinvoicecompany;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fEBweight
		{
			set{ _febweight=value;}
			get{return _febweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBweightUnit
		{
			set{ _cebweightunit=value;}
			get{return _cebweightunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBExpressCode
		{
			set{ _cebexpresscode=value;}
			get{return _cebexpresscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iEBExpressCoID
		{
			set{ _iebexpresscoid=value;}
			get{return _iebexpresscoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? SeparateID
		{
			set{ _separateid=value;}
			get{return _separateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? bNotToGoldTax
		{
			set{ _bnottogoldtax=value;}
			get{return _bnottogoldtax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBTrnumber
		{
			set{ _cebtrnumber=value;}
			get{return _cebtrnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBBuyer
		{
			set{ _cebbuyer=value;}
			get{return _cebbuyer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBBuyerNote
		{
			set{ _cebbuyernote=value;}
			get{return _cebbuyernote;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ccontactname
		{
			set{ _ccontactname=value;}
			get{return _ccontactname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBprovince
		{
			set{ _cebprovince=value;}
			get{return _cebprovince;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBcity
		{
			set{ _cebcity=value;}
			get{return _cebcity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cEBdistrict
		{
			set{ _cebdistrict=value;}
			get{return _cebdistrict;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cmobilephone
		{
			set{ _cmobilephone=value;}
			get{return _cmobilephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvoiceCusName
		{
			set{ _cinvoicecusname=value;}
			get{return _cinvoicecusname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cweighter
		{
			set{ _cweighter=value;}
			get{return _cweighter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dweighttime
		{
			set{ _dweighttime=value;}
			get{return _dweighttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPickVouchCode
		{
			set{ _cpickvouchcode=value;}
			get{return _cpickvouchcode;}
		}
		#endregion Model

	}
}

