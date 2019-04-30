using System;
namespace Purchase.Model
{
	/// <summary>
	/// PurBillVouch:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PurBillVouch
	{
		public PurBillVouch()
		{}
		#region Model
		private long _pbvid= 0;
		private string _cpbvbilltype;
		private string _cpbvcode;
		private string _cptcode;
		private DateTime _dpbvdate;
		private string _cvencode;
		private string _cunitcode;
		private string _cdepcode;
		private string _cpersoncode;
		private string _cpaycode;
		private string _cexch_name;
		private decimal? _cexchrate;
		private decimal? _ipbvtaxrate=  0M;
		private string _cpbvmemo;
		private string _cordercode;
		private string _cincode;
		private string _cbustype;
		private DateTime? _dsdate;
		private string _cpbvmaker;
		private string _cpbvverifier;
		private bool _bnegative= false;
		private bool _boriginal= false;
		private bool _bfirst= false;
		private string _citem_class;
		private string _citemcode;
		private string _cheadcode;
		private decimal? _inetlock=0M;
		private string _cdefine1;
		private string _cdefine2;
		private string _cdefine3;
		private DateTime? _cdefine4;
		private int? _cdefine5;
		private DateTime? _cdefine6;
		private decimal? _cdefine7=0M;
		private string _cdefine8;
		private string _cdefine9;
		private string _cdefine10;
		private string _bpayment;
		private DateTime? _dvoudate;
		private int _ivtid=0;
		private DateTime? _ufts;
		private string _caccounter;
		private string _csource;
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private int? _cdefine15;
		private decimal? _cdefine16;
		private bool _biafirst= false;
		private int? _idiscounttaxtype=0;
		private string _cvenpuomprotocol;
		private DateTime? _dcreditstart;
		private int? _icreditperiod;
		private DateTime? _dgatheringdate;
		private DateTime? _cmodifydate;
		private string _creviser;
		private int? _bcredit;
		private int? _ibg_overflag=0;
		private string _cbg_auditor="";
		private string _cbg_audittime="";
		private int? _controlresult;
		private int? _iflowid;
		private DateTime? _dverifydate;
		private DateTime? _dverifysystime;
		private string _cvenaccount;
		private int? _iprintcount=0;
		private string _ccleanver;
		private string _ccontactcode;
		private string _cvenperson;
		private string _cvenbank;
		private string _cverifier;
		private DateTime? _cauditdate;
		private DateTime? _caudittime;
		private int? _iverifystateex;
		private int? _ireturncount;
		private bool _iswfcontrolled= false;
		private string _csysbarcode;
		private string _ccurrentauditor;
		private DateTime? _cmaketime= DateTime.Now;
		private DateTime? _cmodifytime;
		private int? _bmerger=0;
		/// <summary>
		/// 
		/// </summary>
		public long PBVID
		{
			set{ _pbvid=value;}
			get{return _pbvid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPBVBillType
		{
			set{ _cpbvbilltype=value;}
			get{return _cpbvbilltype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPBVCode
		{
			set{ _cpbvcode=value;}
			get{return _cpbvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPTCode
		{
			set{ _cptcode=value;}
			get{return _cptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dPBVDate
		{
			set{ _dpbvdate=value;}
			get{return _dpbvdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVenCode
		{
			set{ _cvencode=value;}
			get{return _cvencode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cUnitCode
		{
			set{ _cunitcode=value;}
			get{return _cunitcode;}
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
		public string cPayCode
		{
			set{ _cpaycode=value;}
			get{return _cpaycode;}
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
		public decimal? cExchRate
		{
			set{ _cexchrate=value;}
			get{return _cexchrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iPBVTaxRate
		{
			set{ _ipbvtaxrate=value;}
			get{return _ipbvtaxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPBVMemo
		{
			set{ _cpbvmemo=value;}
			get{return _cpbvmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cOrderCode
		{
			set{ _cordercode=value;}
			get{return _cordercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInCode
		{
			set{ _cincode=value;}
			get{return _cincode;}
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
		public DateTime? dSDate
		{
			set{ _dsdate=value;}
			get{return _dsdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPBVMaker
		{
			set{ _cpbvmaker=value;}
			get{return _cpbvmaker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPBVVerifier
		{
			set{ _cpbvverifier=value;}
			get{return _cpbvverifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bNegative
		{
			set{ _bnegative=value;}
			get{return _bnegative;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bOriginal
		{
			set{ _boriginal=value;}
			get{return _boriginal;}
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
		public string citem_class
		{
			set{ _citem_class=value;}
			get{return _citem_class;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string citemcode
		{
			set{ _citemcode=value;}
			get{return _citemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cHeadCode
		{
			set{ _cheadcode=value;}
			get{return _cheadcode;}
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
		public int? cDefine5
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
		public string bPayment
		{
			set{ _bpayment=value;}
			get{return _bpayment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dVouDate
		{
			set{ _dvoudate=value;}
			get{return _dvoudate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iVTid
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
		public string cAccounter
		{
			set{ _caccounter=value;}
			get{return _caccounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSource
		{
			set{ _csource=value;}
			get{return _csource;}
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
		public int? cDefine15
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
		public int? iDiscountTaxType
		{
			set{ _idiscounttaxtype=value;}
			get{return _idiscounttaxtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVenPUOMProtocol
		{
			set{ _cvenpuomprotocol=value;}
			get{return _cvenpuomprotocol;}
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
		public int? iCreditPeriod
		{
			set{ _icreditperiod=value;}
			get{return _icreditperiod;}
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
		public DateTime? cModifyDate
		{
			set{ _cmodifydate=value;}
			get{return _cmodifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cReviser
		{
			set{ _creviser=value;}
			get{return _creviser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bCredit
		{
			set{ _bcredit=value;}
			get{return _bcredit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iBG_OverFlag
		{
			set{ _ibg_overflag=value;}
			get{return _ibg_overflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_Auditor
		{
			set{ _cbg_auditor=value;}
			get{return _cbg_auditor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_AuditTime
		{
			set{ _cbg_audittime=value;}
			get{return _cbg_audittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ControlResult
		{
			set{ _controlresult=value;}
			get{return _controlresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iflowid
		{
			set{ _iflowid=value;}
			get{return _iflowid;}
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
		public DateTime? dverifysystime
		{
			set{ _dverifysystime=value;}
			get{return _dverifysystime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVenAccount
		{
			set{ _cvenaccount=value;}
			get{return _cvenaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iPrintCount
		{
			set{ _iprintcount=value;}
			get{return _iprintcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ccleanver
		{
			set{ _ccleanver=value;}
			get{return _ccleanver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cContactCode
		{
			set{ _ccontactcode=value;}
			get{return _ccontactcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVenPerson
		{
			set{ _cvenperson=value;}
			get{return _cvenperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVenBank
		{
			set{ _cvenbank=value;}
			get{return _cvenbank;}
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
		public DateTime? cAuditDate
		{
			set{ _cauditdate=value;}
			get{return _cauditdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cAuditTime
		{
			set{ _caudittime=value;}
			get{return _caudittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iverifystateex
		{
			set{ _iverifystateex=value;}
			get{return _iverifystateex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ireturncount
		{
			set{ _ireturncount=value;}
			get{return _ireturncount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsWfControlled
		{
			set{ _iswfcontrolled=value;}
			get{return _iswfcontrolled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csysbarcode
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
		public DateTime? cmaketime
		{
			set{ _cmaketime=value;}
			get{return _cmaketime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cmodifytime
		{
			set{ _cmodifytime=value;}
			get{return _cmodifytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bMerger
		{
			set{ _bmerger=value;}
			get{return _bmerger;}
		}
		#endregion Model

	}
}

