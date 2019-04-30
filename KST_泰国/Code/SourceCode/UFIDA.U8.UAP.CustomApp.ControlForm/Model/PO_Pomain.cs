using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// PO_Pomain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PO_Pomain
	{
		public PO_Pomain()
		{}
		#region Model
		private string _cpoid;
		private DateTime _dpodate;
		private string _cvencode;
		private string _cdepcode;
		private string _cpersoncode;
		private string _cptcode;
		private string _carrivalplace;
		private string _csccode;
		private string _cexch_name;
		private decimal? _nflat;
		private decimal? _itaxrate=0M;
		private string _cpaycode;
		private decimal? _icost=0M;
		private decimal? _ibargain= 0M;
		private string _cmemo;
		private long? _cstate=0;
		private string _cperiod;
		private string _cmaker;
		private string _cverifier;
		private string _ccloser;
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
		private long _poid=0;
		private long _ivtid=0;
		private DateTime _ufts;
		private string _cchanger;
		private string _cbustype="普通采购";
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private long? _cdefine15;
		private decimal? _cdefine16;
		private string _clocker;
		private long? _idiscounttaxtype=0;
		private long? _iverifystateex;
		private long? _ireturncount;
		private bool _iswfcontrolled= false;
		private DateTime? _cmaketime= DateTime.Now;
		private DateTime? _cmodifytime;
		private DateTime? _caudittime;
		private DateTime? _cauditdate;
		private DateTime? _cmodifydate;
		private string _creviser;
		private string _cvenpuomprotocol;
		private string _cchangverifier;
		private DateTime? _cchangaudittime;
		private DateTime? _cchangauditdate;
		private long? _ibg_overflag=0;
		private string _cbg_auditor="";
		private string _cbg_audittime="";
		private long? _controlresult;
		private long? _iflowid;
		private long? _iprintcount=0;
		private DateTime? _dclosedate;
		private DateTime? _dclosetime;
		private string _ccleanver;
		private string _ccontactcode;
		private string _cvenperson;
		private string _cvenbank;
		private string _cvenaccount;
		private string _cappcode;
		private string _csysbarcode;
		private string _ccurrentauditor;
		/// <summary>
		/// 
		/// </summary>
		public string cPOID
		{
			set{ _cpoid=value;}
			get{return _cpoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dPODate
		{
			set{ _dpodate=value;}
			get{return _dpodate;}
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
		public string cPTCode
		{
			set{ _cptcode=value;}
			get{return _cptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cArrivalPlace
		{
			set{ _carrivalplace=value;}
			get{return _carrivalplace;}
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
		public string cexch_name
		{
			set{ _cexch_name=value;}
			get{return _cexch_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nflat
		{
			set{ _nflat=value;}
			get{return _nflat;}
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
		public string cPayCode
		{
			set{ _cpaycode=value;}
			get{return _cpaycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iCost
		{
			set{ _icost=value;}
			get{return _icost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iBargain
		{
			set{ _ibargain=value;}
			get{return _ibargain;}
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
		public long? cState
		{
			set{ _cstate=value;}
			get{return _cstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPeriod
		{
			set{ _cperiod=value;}
			get{return _cperiod;}
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
		public string cVerifier
		{
			set{ _cverifier=value;}
			get{return _cverifier;}
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
		public long POID
		{
			set{ _poid=value;}
			get{return _poid;}
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
		public DateTime ufts
		{
			set{ _ufts=value;}
			get{return _ufts;}
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
		public string cBusType
		{
			set{ _cbustype=value;}
			get{return _cbustype;}
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
		public string cLocker
		{
			set{ _clocker=value;}
			get{return _clocker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iDiscountTaxType
		{
			set{ _idiscounttaxtype=value;}
			get{return _idiscounttaxtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iverifystateex
		{
			set{ _iverifystateex=value;}
			get{return _iverifystateex;}
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
		public bool IsWfControlled
		{
			set{ _iswfcontrolled=value;}
			get{return _iswfcontrolled;}
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
		public DateTime? cModifyTime
		{
			set{ _cmodifytime=value;}
			get{return _cmodifytime;}
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
		public DateTime? cAuditDate
		{
			set{ _cauditdate=value;}
			get{return _cauditdate;}
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
		public string cVenPUOMProtocol
		{
			set{ _cvenpuomprotocol=value;}
			get{return _cvenpuomprotocol;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cChangVerifier
		{
			set{ _cchangverifier=value;}
			get{return _cchangverifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cChangAuditTime
		{
			set{ _cchangaudittime=value;}
			get{return _cchangaudittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cChangAuditDate
		{
			set{ _cchangauditdate=value;}
			get{return _cchangauditdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iBG_OverFlag
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
		public long? ControlResult
		{
			set{ _controlresult=value;}
			get{return _controlresult;}
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
		public long? iPrintCount
		{
			set{ _iprintcount=value;}
			get{return _iprintcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dCloseDate
		{
			set{ _dclosedate=value;}
			get{return _dclosedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dCloseTime
		{
			set{ _dclosetime=value;}
			get{return _dclosetime;}
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
		public string cVenAccount
		{
			set{ _cvenaccount=value;}
			get{return _cvenaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cappcode
		{
			set{ _cappcode=value;}
			get{return _cappcode;}
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
		#endregion Model

	}
}

