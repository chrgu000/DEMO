using System;
namespace Model
{
    /// <summary>
    /// RdRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RdRecord
    {
        public RdRecord()
        { }
        #region Model
        private long _id = 0;
		private int _brdflag=0;
		private string _cvouchtype;
		private string _cbustype;
		private string _csource;
		private string _cbuscode;
		private string _cwhcode;
		private DateTime _ddate;
		private string _ccode;
		private string _crdcode;
		private string _cdepcode;
		private string _cpersoncode;
		private string _cptcode;
		private string _cstcode;
		private string _ccuscode;
		private string _cvencode;
		private string _cordercode;
		private string _carvcode;
		private int _cbillcode;
		private int _cdlcode;
		private string _cprobatch;
		private string _chandler;
		private string _cmemo;
		private bool _btransflag= false;
		private string _caccounter;
		private string _cmaker;
		private decimal? _inetlock=0;
		private string _cdefine1;
		private string _cdefine2;
		private string _cdefine3;
		private DateTime? _cdefine4;
		private int? _cdefine5;
		private DateTime? _cdefine6;
		private decimal? _cdefine7=0;
		private string _cdefine8;
		private string _cdefine9;
		private string _cdefine10;
		private string _dkeepdate;
		private DateTime? _dveridate;
		private bool _bpufirst= false;
		private bool _biafirst= false;
		private decimal? _imquantity;
		private DateTime? _darvdate;
		private string _cchkcode;
		private DateTime? _dchkdate;
		private string _cchkperson;
		private int? _vt_id;
		private bool _bisstqc= false;
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private int? _cdefine15;
		private decimal? _cdefine16;
		private string _cpspcode;
		private string _cmpocode;
		private string _gspcheck;
		private int? _ipurorderid;
		private int? _ipurarriveid;
		private int? _iproorderid;
		private string _iarriveid;
		private string _isalebillid;
		private DateTime? _ufts;
		private string _cbomsocode;
		private string _comrdtype;
		private string _cbuscode2;
		private decimal? _itaxrate;
		private string _caccountpid;
		private DateTime? _caccountpdate;
		private string _cpaycode;
		private bool _bgxljz;
		private bool _bisomqc;
		private string _cvenbank;
		private string _cvenaddress;
		private string _cvenphone;
		private string _cvenfax;
		private string _cvenpostcode;
		private string _cvenperson;
		private string _cvenaccount;
		private string _cvenregcode;
		private string _calter;
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
		public int bRdFlag
		{
			set{ _brdflag=value;}
			get{return _brdflag;}
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
		public string cBusType
		{
			set{ _cbustype=value;}
			get{return _cbustype;}
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
		public string cBusCode
		{
			set{ _cbuscode=value;}
			get{return _cbuscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cWhCode
		{
			set{ _cwhcode=value;}
			get{return _cwhcode;}
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
		public string cCode
		{
			set{ _ccode=value;}
			get{return _ccode;}
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
		public string cPTCode
		{
			set{ _cptcode=value;}
			get{return _cptcode;}
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
		public string cCusCode
		{
			set{ _ccuscode=value;}
			get{return _ccuscode;}
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
		public string cOrderCode
		{
			set{ _cordercode=value;}
			get{return _cordercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cARVCode
		{
			set{ _carvcode=value;}
			get{return _carvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cBillCode
		{
			set{ _cbillcode=value;}
			get{return _cbillcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cDLCode
		{
			set{ _cdlcode=value;}
			get{return _cdlcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cProBatch
		{
			set{ _cprobatch=value;}
			get{return _cprobatch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cHandler
		{
			set{ _chandler=value;}
			get{return _chandler;}
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
		public bool bTransFlag
		{
			set{ _btransflag=value;}
			get{return _btransflag;}
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
		public string dKeepDate
		{
			set{ _dkeepdate=value;}
			get{return _dkeepdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dVeriDate
		{
			set{ _dveridate=value;}
			get{return _dveridate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bpufirst
		{
			set{ _bpufirst=value;}
			get{return _bpufirst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool biafirst
		{
			set{ _biafirst=value;}
			get{return _biafirst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iMQuantity
		{
			set{ _imquantity=value;}
			get{return _imquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dARVDate
		{
			set{ _darvdate=value;}
			get{return _darvdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cChkCode
		{
			set{ _cchkcode=value;}
			get{return _cchkcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dChkDate
		{
			set{ _dchkdate=value;}
			get{return _dchkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cChkPerson
		{
			set{ _cchkperson=value;}
			get{return _cchkperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VT_ID
		{
			set{ _vt_id=value;}
			get{return _vt_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bIsSTQc
		{
			set{ _bisstqc=value;}
			get{return _bisstqc;}
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
		public string cPsPcode
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
		public string gspcheck
		{
			set{ _gspcheck=value;}
			get{return _gspcheck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ipurorderid
		{
			set{ _ipurorderid=value;}
			get{return _ipurorderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ipurarriveid
		{
			set{ _ipurarriveid=value;}
			get{return _ipurarriveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iproorderid
		{
			set{ _iproorderid=value;}
			get{return _iproorderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string iarriveid
		{
			set{ _iarriveid=value;}
			get{return _iarriveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isalebillid
		{
			set{ _isalebillid=value;}
			get{return _isalebillid;}
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
		public string cBomSoCode
		{
			set{ _cbomsocode=value;}
			get{return _cbomsocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cOMrdType
		{
			set{ _comrdtype=value;}
			get{return _comrdtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBusCode2
		{
			set{ _cbuscode2=value;}
			get{return _cbuscode2;}
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
		public string cPayCode
		{
			set{ _cpaycode=value;}
			get{return _cpaycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bgxljz
		{
			set{ _bgxljz=value;}
			get{return _bgxljz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bisomqc
		{
			set{ _bisomqc=value;}
			get{return _bisomqc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenbank
		{
			set{ _cvenbank=value;}
			get{return _cvenbank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenaddress
		{
			set{ _cvenaddress=value;}
			get{return _cvenaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenphone
		{
			set{ _cvenphone=value;}
			get{return _cvenphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenfax
		{
			set{ _cvenfax=value;}
			get{return _cvenfax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenpostcode
		{
			set{ _cvenpostcode=value;}
			get{return _cvenpostcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenperson
		{
			set{ _cvenperson=value;}
			get{return _cvenperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenaccount
		{
			set{ _cvenaccount=value;}
			get{return _cvenaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvenregcode
		{
			set{ _cvenregcode=value;}
			get{return _cvenregcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cAlter
		{
			set{ _calter=value;}
			get{return _calter;}
		}
        #endregion Model

    }
}

