using System;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// SO_SOMain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SO_SOMain
	{
		public SO_SOMain()
		{}
		#region Model
		private string _cstcode;
		private DateTime _ddate;
		private string _csocode;
		private string _ccuscode;
		private string _cdepcode;
		private string _cpersoncode;
		private string _csccode;
		private string _ccusoaddress;
		private string _cpaycode;
		private string _cexch_name;
		private decimal? _iexchrate;
		private decimal? _itaxrate;
		private decimal? _imoney;
		private string _cmemo;
		private long _istatus;
		private string _cmaker;
		private string _cverifier;
		private string _ccloser;
		private bool _bdisflag= false;
		private string _cdefine1;
		private string _cdefine2;
		private string _cdefine3;
		private DateTime? _cdefine4;
		private long? _cdefine5;
		private DateTime? _cdefine6;
        private decimal? _cdefine7;
		private string _cdefine8;
		private string _cdefine9;
		private string _cdefine10;
		private bool _breturnflag= false;
		private string _ccusname;
		private bool _border= false;
		private long _id=0;
		private long _ivtid=0;
		private DateTime _ufts;
		private string _cchanger;
		private string _cbustype="普通销售";
		private string _ccrechpname;
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private long? _cdefine15;
		private decimal? _cdefine16;
		private string _coppcode;
		private string _clocker;
		private DateTime? _dpremodatebt;
		private DateTime? _dpredatebt;
		private string _cgatheringplan;
		private string _caddcode;
		private long? _iverifystate=0;
		private long? _ireturncount=0;
		private long? _iswfcontrolled=0;
		private string _icreditstate;
		private string _cmodifier;
		private DateTime? _dmoddate;
		private DateTime? _dverifydate;
		private string _ccusperson;
		private DateTime? _dcreatesystime= DateTime.Now;
		private DateTime? _dverifysystime;
		private DateTime? _dmodifysystime;
		private long? _iflowid;
		private bool _bcashsale;
		private string _cgathingcode;
		private string _cchangeverifier;
		private DateTime? _dchangeverifydate;
		private DateTime? _dchangeverifytime;
		private Guid _outid;
		private string _ccuspersoncode;
		private DateTime? _dclosedate;
		private DateTime? _dclosesystime;
        private decimal? _iprintcount;
		private decimal? _fbookratio;
		private bool _bmustbook;
		private decimal? _fbooksum;
		private decimal? _fbooknatsum;
		private decimal? _fgbooksum;
		private decimal? _fgbooknatsum;
		private string _csvouchtype;
		private string _ccrmpersoncode;
		private string _ccrmpersonname;
		private string _cmainpersoncode;
		private string _csysbarcode;
		private long? _ioppid;
		private string _optnty_name;
		private string _ccurrentauditor;
		private long? _contract_status;
		private string _csscode;
		private string _cinvoicecompany;
		private string _cattachment;
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
		public string cSCCode
		{
			set{ _csccode=value;}
			get{return _csccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCusOAddress
		{
			set{ _ccusoaddress=value;}
			get{return _ccusoaddress;}
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
		public decimal? iExchRate
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
		public decimal? iMoney
		{
			set{ _imoney=value;}
			get{return _imoney;}
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
		public long iStatus
		{
			set{ _istatus=value;}
			get{return _istatus;}
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
		public bool bDisFlag
		{
			set{ _bdisflag=value;}
			get{return _bdisflag;}
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
		public bool bReturnFlag
		{
			set{ _breturnflag=value;}
			get{return _breturnflag;}
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
		public bool bOrder
		{
			set{ _border=value;}
			get{return _border;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public string coppcode
		{
			set{ _coppcode=value;}
			get{return _coppcode;}
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
		public DateTime? dPreMoDateBT
		{
			set{ _dpremodatebt=value;}
			get{return _dpremodatebt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dPreDateBT
		{
			set{ _dpredatebt=value;}
			get{return _dpredatebt;}
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
		public long? iflowid
		{
			set{ _iflowid=value;}
			get{return _iflowid;}
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
		public string cChangeVerifier
		{
			set{ _cchangeverifier=value;}
			get{return _cchangeverifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dChangeVerifyDate
		{
			set{ _dchangeverifydate=value;}
			get{return _dchangeverifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dChangeVerifyTime
		{
			set{ _dchangeverifytime=value;}
			get{return _dchangeverifytime;}
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
		public string ccuspersoncode
		{
			set{ _ccuspersoncode=value;}
			get{return _ccuspersoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dclosedate
		{
			set{ _dclosedate=value;}
			get{return _dclosedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dclosesystime
		{
			set{ _dclosesystime=value;}
			get{return _dclosesystime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iPrintCount
		{
			set{ _iprintcount=value;}
            get { return _iprintcount; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fbookratio
		{
			set{ _fbookratio=value;}
			get{return _fbookratio;}
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
		public decimal? fbooksum
		{
			set{ _fbooksum=value;}
			get{return _fbooksum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fbooknatsum
		{
			set{ _fbooknatsum=value;}
			get{return _fbooknatsum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fgbooksum
		{
			set{ _fgbooksum=value;}
			get{return _fgbooksum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fgbooknatsum
		{
			set{ _fgbooknatsum=value;}
			get{return _fgbooknatsum;}
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
		public string cCrmPersonCode
		{
			set{ _ccrmpersoncode=value;}
			get{return _ccrmpersoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCrmPersonName
		{
			set{ _ccrmpersonname=value;}
			get{return _ccrmpersonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cMainPersonCode
		{
			set{ _cmainpersoncode=value;}
			get{return _cmainpersoncode;}
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
		public long? ioppid
		{
			set{ _ioppid=value;}
			get{return _ioppid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string optnty_name
		{
			set{ _optnty_name=value;}
			get{return _optnty_name;}
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
		public long? contract_status
		{
			set{ _contract_status=value;}
			get{return _contract_status;}
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
		public string cAttachment
		{
			set{ _cattachment=value;}
			get{return _cattachment;}
		}
		#endregion Model

	}
}

