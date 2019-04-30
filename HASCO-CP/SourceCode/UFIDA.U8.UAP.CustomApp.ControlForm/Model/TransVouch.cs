using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// TransVouch:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TransVouch
	{
		public TransVouch()
		{}
		#region Model
		private string _ctvcode;
		private DateTime _dtvdate;
		private string _cowhcode;
		private string _ciwhcode;
		private string _codepcode;
		private string _cidepcode;
		private string _cpersoncode;
		private string _cirdcode;
		private string _cordcode;
		private string _ctvmemo;
		private string _cdefine1;
		private string _cdefine2;
		private string _cdefine3;
		private DateTime? _cdefine4;
		private long? _cdefine5;
		private DateTime? _cdefine6;
		private decimal? _cdefine7=  0M;
		private string _cdefine8;
		private string _cdefine9;
		private string _cdefine10;
		private string _caccounter;
		private string _cmaker;
		private decimal? _inetlock=  0M;
		private long _id;
		private long _vt_id=1;
		private string _cverifyperson;
		private DateTime? _dverifydate;
		private string _cpspcode;
		private string _cmpocode;
		private decimal? _iquantity;
		private long? _btransflag;
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private long? _cdefine15;
		private decimal? _cdefine16;
		private DateTime? _ufts;
		private long? _iproorderid;
		private string _cordertype;
		private string _ctranrequestcode;
		private string _cversion;
		private long? _bomid;
		private string _cfree1;
		private string _cfree2;
		private string _cfree3;
		private string _cfree4;
		private string _cfree5;
		private string _cfree6;
		private string _cfree7;
		private string _cfree8;
		private string _cfree9;
		private string _cfree10;
		private string _capptvcode;
		private string _csource="1";
		private string _itransflag="正向";
		private string _cmodifyperson="";
		private DateTime? _dmodifydate;
		private DateTime? _dnmaketime;
		private DateTime? _dnmodifytime;
		private DateTime? _dnverifytime;
		private long? _ireturncount=0;
		private long? _iverifystate=0;
		private long? _iswfcontrolled=0;
		private string _cbustype;
		private string _csourcecodels;
		private long? _iprintcount=0;
		private string _csourceguid;
		private string _csysbarcode;
		private string _ccurrentauditor;
		/// <summary>
		/// 
		/// </summary>
		public string cTVCode
		{
			set{ _ctvcode=value;}
			get{return _ctvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dTVDate
		{
			set{ _dtvdate=value;}
			get{return _dtvdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cOWhCode
		{
			set{ _cowhcode=value;}
			get{return _cowhcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cIWhCode
		{
			set{ _ciwhcode=value;}
			get{return _ciwhcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cODepCode
		{
			set{ _codepcode=value;}
			get{return _codepcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cIDepCode
		{
			set{ _cidepcode=value;}
			get{return _cidepcode;}
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
		public string cIRdCode
		{
			set{ _cirdcode=value;}
			get{return _cirdcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cORdCode
		{
			set{ _cordcode=value;}
			get{return _cordcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cTVMemo
		{
			set{ _ctvmemo=value;}
			get{return _ctvmemo;}
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
		public string cAccounter
		{
			set{ _caccounter=value;}
			get{return _caccounter;}
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
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long VT_ID
		{
			set{ _vt_id=value;}
			get{return _vt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVerifyPerson
		{
			set{ _cverifyperson=value;}
			get{return _cverifyperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dVerifyDate
		{
			set{ _dverifydate=value;}
			get{return _dverifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPSPCode
		{
			set{ _cpspcode=value;}
			get{return _cpspcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cMPoCode
		{
			set{ _cmpocode=value;}
			get{return _cmpocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iQuantity
		{
			set{ _iquantity=value;}
			get{return _iquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? bTransFlag
		{
			set{ _btransflag=value;}
			get{return _btransflag;}
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
		public DateTime? ufts
		{
			set{ _ufts=value;}
			get{return _ufts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iproorderid
		{
			set{ _iproorderid=value;}
			get{return _iproorderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cOrderType
		{
			set{ _cordertype=value;}
			get{return _cordertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cTranRequestCode
		{
			set{ _ctranrequestcode=value;}
			get{return _ctranrequestcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVersion
		{
			set{ _cversion=value;}
			get{return _cversion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? BomId
		{
			set{ _bomid=value;}
			get{return _bomid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree1
		{
			set{ _cfree1=value;}
			get{return _cfree1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree2
		{
			set{ _cfree2=value;}
			get{return _cfree2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree3
		{
			set{ _cfree3=value;}
			get{return _cfree3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree4
		{
			set{ _cfree4=value;}
			get{return _cfree4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree5
		{
			set{ _cfree5=value;}
			get{return _cfree5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree6
		{
			set{ _cfree6=value;}
			get{return _cfree6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree7
		{
			set{ _cfree7=value;}
			get{return _cfree7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree8
		{
			set{ _cfree8=value;}
			get{return _cfree8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree9
		{
			set{ _cfree9=value;}
			get{return _cfree9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFree10
		{
			set{ _cfree10=value;}
			get{return _cfree10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cAppTVCode
		{
			set{ _capptvcode=value;}
			get{return _capptvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csource
		{
			set{ _csource=value;}
			get{return _csource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string itransflag
		{
			set{ _itransflag=value;}
			get{return _itransflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cModifyPerson
		{
			set{ _cmodifyperson=value;}
			get{return _cmodifyperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dModifyDate
		{
			set{ _dmodifydate=value;}
			get{return _dmodifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dnmaketime
		{
			set{ _dnmaketime=value;}
			get{return _dnmaketime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dnmodifytime
		{
			set{ _dnmodifytime=value;}
			get{return _dnmodifytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dnverifytime
		{
			set{ _dnverifytime=value;}
			get{return _dnverifytime;}
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
		public long? iverifystate
		{
			set{ _iverifystate=value;}
			get{return _iverifystate;}
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
		public string cbustype
		{
			set{ _cbustype=value;}
			get{return _cbustype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSourceCodeLs
		{
			set{ _csourcecodels=value;}
			get{return _csourcecodels;}
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
		public string csourceguid
		{
			set{ _csourceguid=value;}
			get{return _csourceguid;}
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

