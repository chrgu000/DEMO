using System;
namespace TH.clsU8.Model
{
	/// <summary>
	/// Ap_CloseBill:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ap_CloseBill
	{
		public Ap_CloseBill()
		{}
		#region Model
		private string _cvouchtype;
		private string _cvouchid;
		private DateTime _dvouchdate;
		private long _iperiod=0;
		private string _cdwcode;
		private string _cdeptcode;
		private string _cperson;
		private string _citem_class;
		private string _citemcode;
		private string _csscode;
		private string _cnoteno;
		private string _ccovouchtype;
		private string _ccovouchid;
		private string _cdigest;
		private string _cbankaccount;
		private string _cexch_name;
		private decimal? _iexchrate=  1M;
		private decimal? _iamount=0M;
		private decimal? _iamount_f=  0M;
		private decimal? _iramount=  0M;
		private decimal? _iramount_f=  0M;
		private string _coperator;
		private string _ccancelman;
		private string _crpman;
		private bool _bprepay= false;
		private bool _bstartflag= false;
		private string _corderno;
		private string _ccode;
		private string _cprecode;
		private bool _ipayforother= false;
		private string _csrcflag;
		private string _cpzid;
		private string _cflag;
		private bool _bsend= false;
		private bool _breceived= false;
		private string _csitemcode;
		private long _iid;
		private string _ccancelno;
		private string _cbank;
		private string _cnatbank;
		private string _cnatbankaccount;
		private bool _bfrombank= false;
		private bool _btobank= false;
		private bool _bsure= false;
		private long _vt_id=0;
		private string _ccheckman;
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
		private string _cdefine11;
		private string _cdefine12;
		private string _cdefine13;
		private string _cdefine14;
		private long? _cdefine15;
		private decimal? _cdefine16;
		private DateTime? _ufts;
		private string _citemname;
		private string _ccontracttype;
		private string _ccontractid;
		private decimal? _iamount_s;
		private bool _iswfcontrolled= false;
		private long? _isource;
		private string _sdlcode;
		private long? _registerflag=0;
		private long? _iverifystate;
		private long? _ireturncount;
		private DateTime? _dcreatesystime;
		private DateTime? _dverifysystime;
		private DateTime? _dmodifysystime;
		private string _cmodifier;
		private DateTime? _dmoddate;
		private DateTime? _dverifydate;
		private long? _ibg_overflag=0;
		private string _cbg_auditor="";
		private string _cbg_audittime="";
		private long? _controlresult;
		private string _cbg_itemcode="";
		private string _cbg_itemname="";
		private string _cbg_caliberkey1="";
		private string _cbg_caliberkeyname1="";
		private string _cbg_caliberkey2="";
		private string _cbg_caliberkeyname2="";
		private string _cbg_caliberkey3="";
		private string _cbg_caliberkeyname3="";
		private string _cbg_calibercode1="";
		private string _cbg_calibername1="";
		private string _cbg_calibercode2="";
		private string _cbg_calibername2="";
		private string _cbg_calibercode3="";
		private string _cbg_calibername3="";
		private bool _ibg_ctrl= false;
		private string _cbg_auditopinion="";
		private string _capplycode;
		private string _cpznum;
		private DateTime? _doutbilldate;
		private string _cbg_caliberkey4="";
		private string _cbg_caliberkeyname4="";
		private string _cbg_caliberkey5="";
		private string _cbg_caliberkeyname5="";
		private string _cbg_caliberkey6="";
		private string _cbg_caliberkeyname6="";
		private string _cbg_calibercode4="";
		private string _cbg_calibername4="";
		private string _cbg_calibercode5="";
		private string _cbg_calibername5="";
		private string _cbg_calibercode6="";
		private string _cbg_calibername6="";
		private long _iprintcount=0;
		private string _creservedeptcode;
		private bool _bdealmode;
		private long? _ibustype;
		private long _ipaytype=0;
		private string _cagentcuscode;
		private string _csysbarcode;
		private string _ccurrentauditor;
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
		public string cVouchID
		{
			set{ _cvouchid=value;}
			get{return _cvouchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dVouchDate
		{
			set{ _dvouchdate=value;}
			get{return _dvouchdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iPeriod
		{
			set{ _iperiod=value;}
			get{return _iperiod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDwCode
		{
			set{ _cdwcode=value;}
			get{return _cdwcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDeptCode
		{
			set{ _cdeptcode=value;}
			get{return _cdeptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPerson
		{
			set{ _cperson=value;}
			get{return _cperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cItem_Class
		{
			set{ _citem_class=value;}
			get{return _citem_class;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cItemCode
		{
			set{ _citemcode=value;}
			get{return _citemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSSCode
		{
			set{ _csscode=value;}
			get{return _csscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cNoteNo
		{
			set{ _cnoteno=value;}
			get{return _cnoteno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCoVouchType
		{
			set{ _ccovouchtype=value;}
			get{return _ccovouchtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCoVouchID
		{
			set{ _ccovouchid=value;}
			get{return _ccovouchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDigest
		{
			set{ _cdigest=value;}
			get{return _cdigest;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBankAccount
		{
			set{ _cbankaccount=value;}
			get{return _cbankaccount;}
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
		public decimal? iAmount
		{
			set{ _iamount=value;}
			get{return _iamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iAmount_f
		{
			set{ _iamount_f=value;}
			get{return _iamount_f;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iRAmount
		{
			set{ _iramount=value;}
			get{return _iramount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iRAmount_f
		{
			set{ _iramount_f=value;}
			get{return _iramount_f;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cOperator
		{
			set{ _coperator=value;}
			get{return _coperator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCancelMan
		{
			set{ _ccancelman=value;}
			get{return _ccancelman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cRPMan
		{
			set{ _crpman=value;}
			get{return _crpman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bPrePay
		{
			set{ _bprepay=value;}
			get{return _bprepay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bStartFlag
		{
			set{ _bstartflag=value;}
			get{return _bstartflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cOrderNo
		{
			set{ _corderno=value;}
			get{return _corderno;}
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
		public string cPreCode
		{
			set{ _cprecode=value;}
			get{return _cprecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool iPayForOther
		{
			set{ _ipayforother=value;}
			get{return _ipayforother;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cSrcFlag
		{
			set{ _csrcflag=value;}
			get{return _csrcflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPzID
		{
			set{ _cpzid=value;}
			get{return _cpzid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cFlag
		{
			set{ _cflag=value;}
			get{return _cflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bSend
		{
			set{ _bsend=value;}
			get{return _bsend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bReceived
		{
			set{ _breceived=value;}
			get{return _breceived;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csItemCode
		{
			set{ _csitemcode=value;}
			get{return _csitemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iID
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCancelNo
		{
			set{ _ccancelno=value;}
			get{return _ccancelno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBank
		{
			set{ _cbank=value;}
			get{return _cbank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cNatBank
		{
			set{ _cnatbank=value;}
			get{return _cnatbank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cNatBankAccount
		{
			set{ _cnatbankaccount=value;}
			get{return _cnatbankaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bFromBank
		{
			set{ _bfrombank=value;}
			get{return _bfrombank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bToBank
		{
			set{ _btobank=value;}
			get{return _btobank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bSure
		{
			set{ _bsure=value;}
			get{return _bsure;}
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
		public string cCheckMan
		{
			set{ _ccheckman=value;}
			get{return _ccheckman;}
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
		public DateTime? Ufts
		{
			set{ _ufts=value;}
			get{return _ufts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cItemName
		{
			set{ _citemname=value;}
			get{return _citemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cContractType
		{
			set{ _ccontracttype=value;}
			get{return _ccontracttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cContractID
		{
			set{ _ccontractid=value;}
			get{return _ccontractid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iAmount_s
		{
			set{ _iamount_s=value;}
			get{return _iamount_s;}
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
		public long? iSource
		{
			set{ _isource=value;}
			get{return _isource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sDLCode
		{
			set{ _sdlcode=value;}
			get{return _sdlcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? RegisterFlag
		{
			set{ _registerflag=value;}
			get{return _registerflag;}
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
		public long? ibg_overflag
		{
			set{ _ibg_overflag=value;}
			get{return _ibg_overflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_auditor
		{
			set{ _cbg_auditor=value;}
			get{return _cbg_auditor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_audittime
		{
			set{ _cbg_audittime=value;}
			get{return _cbg_audittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? controlresult
		{
			set{ _controlresult=value;}
			get{return _controlresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_itemcode
		{
			set{ _cbg_itemcode=value;}
			get{return _cbg_itemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_itemname
		{
			set{ _cbg_itemname=value;}
			get{return _cbg_itemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkey1
		{
			set{ _cbg_caliberkey1=value;}
			get{return _cbg_caliberkey1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkeyname1
		{
			set{ _cbg_caliberkeyname1=value;}
			get{return _cbg_caliberkeyname1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkey2
		{
			set{ _cbg_caliberkey2=value;}
			get{return _cbg_caliberkey2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkeyname2
		{
			set{ _cbg_caliberkeyname2=value;}
			get{return _cbg_caliberkeyname2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkey3
		{
			set{ _cbg_caliberkey3=value;}
			get{return _cbg_caliberkey3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkeyname3
		{
			set{ _cbg_caliberkeyname3=value;}
			get{return _cbg_caliberkeyname3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibercode1
		{
			set{ _cbg_calibercode1=value;}
			get{return _cbg_calibercode1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibername1
		{
			set{ _cbg_calibername1=value;}
			get{return _cbg_calibername1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibercode2
		{
			set{ _cbg_calibercode2=value;}
			get{return _cbg_calibercode2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibername2
		{
			set{ _cbg_calibername2=value;}
			get{return _cbg_calibername2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibercode3
		{
			set{ _cbg_calibercode3=value;}
			get{return _cbg_calibercode3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibername3
		{
			set{ _cbg_calibername3=value;}
			get{return _cbg_calibername3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ibg_ctrl
		{
			set{ _ibg_ctrl=value;}
			get{return _ibg_ctrl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_auditopinion
		{
			set{ _cbg_auditopinion=value;}
			get{return _cbg_auditopinion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cApplyCode
		{
			set{ _capplycode=value;}
			get{return _capplycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPZNum
		{
			set{ _cpznum=value;}
			get{return _cpznum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? doutbilldate
		{
			set{ _doutbilldate=value;}
			get{return _doutbilldate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkey4
		{
			set{ _cbg_caliberkey4=value;}
			get{return _cbg_caliberkey4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkeyname4
		{
			set{ _cbg_caliberkeyname4=value;}
			get{return _cbg_caliberkeyname4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkey5
		{
			set{ _cbg_caliberkey5=value;}
			get{return _cbg_caliberkey5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkeyname5
		{
			set{ _cbg_caliberkeyname5=value;}
			get{return _cbg_caliberkeyname5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkey6
		{
			set{ _cbg_caliberkey6=value;}
			get{return _cbg_caliberkey6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_caliberkeyname6
		{
			set{ _cbg_caliberkeyname6=value;}
			get{return _cbg_caliberkeyname6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibercode4
		{
			set{ _cbg_calibercode4=value;}
			get{return _cbg_calibercode4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibername4
		{
			set{ _cbg_calibername4=value;}
			get{return _cbg_calibername4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibercode5
		{
			set{ _cbg_calibercode5=value;}
			get{return _cbg_calibercode5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibername5
		{
			set{ _cbg_calibername5=value;}
			get{return _cbg_calibername5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibercode6
		{
			set{ _cbg_calibercode6=value;}
			get{return _cbg_calibercode6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbg_calibername6
		{
			set{ _cbg_calibername6=value;}
			get{return _cbg_calibername6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iPrintCount
		{
			set{ _iprintcount=value;}
			get{return _iprintcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cReserveDeptCode
		{
			set{ _creservedeptcode=value;}
			get{return _creservedeptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bDealMode
		{
			set{ _bdealmode=value;}
			get{return _bdealmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iBusType
		{
			set{ _ibustype=value;}
			get{return _ibustype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iPayType
		{
			set{ _ipaytype=value;}
			get{return _ipaytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cagentcuscode
		{
			set{ _cagentcuscode=value;}
			get{return _cagentcuscode;}
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

