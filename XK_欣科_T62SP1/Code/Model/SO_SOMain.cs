using System;
namespace TH.Model
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
		private DateTime? _ufts;
		private string _cchanger;
		private string _cbustype="普通销售";
		private string _ccrechpname;
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private long? _cdefine15;
		private decimal? _cdefine16;
		private string _caccountpid;
		private DateTime? _caccountpdate;
		private string _defaultcall;
		private string _coutverifier;
		private string _coutcontrol;
		private string _coutstatus;
		private DateTime? _dcoutveriddate;
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
		public DateTime? ufts
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
		public string cAccountPID
		{
			set{ _caccountpid=value;}
			get{return _caccountpid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cAccountPDate
		{
			set{ _caccountpdate=value;}
			get{return _caccountpdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string defaultcall
		{
			set{ _defaultcall=value;}
			get{return _defaultcall;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coutverifier
		{
			set{ _coutverifier=value;}
			get{return _coutverifier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coutcontrol
		{
			set{ _coutcontrol=value;}
			get{return _coutcontrol;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coutstatus
		{
			set{ _coutstatus=value;}
			get{return _coutstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dcoutveriddate
		{
			set{ _dcoutveriddate=value;}
			get{return _dcoutveriddate;}
		}
		#endregion Model

	}
}

