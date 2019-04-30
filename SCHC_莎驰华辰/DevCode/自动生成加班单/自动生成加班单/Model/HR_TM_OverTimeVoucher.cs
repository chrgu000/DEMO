using System;
namespace Model
{
	/// <summary>
	/// HR_TM_OverTimeVoucher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HR_TM_OverTimeVoucher
	{
		public HR_TM_OverTimeVoucher()
		{}
		#region Model
		private string _voucherid;
		private string _vouchercode;
		private string _cdept_num;
		private string _vapprover;
		private string _vjbcode;
		private int? _icomputetype;
		private string _vreason;
		private string _vremark;
		private string _djbdate="";
		private decimal? _nmanhours;
		private string _ctimeuseless1;
		private string _ctimeuseless2;
		private string _ddutytime="";
		private string _dofftime="";
		private int? _boverdate;
		private int? _boverdate2;
		private string _dbegintime="";
		private string _dendtime="";
		private int? _ibegincardahead;
		private int? _iendcardforward;
		private int? _rfreecardmode;
		private int? _nmaxdelay;
		private int? _nmaxleave;
		private bool _blastflag;
		private int? _irecordid;
		private int? _bauditflag;
		private string _cauditor;
		private string _cauditornum;
		private string _ccreator;
		private string _ccreatornum;
		private string _coperator;
		private string _coperatornum;
		private string _doperattime="";
		private string _daudittime="";
        private string _dcreattime = "";
		private string _rdealtype;
		private int? _cexamineapprovetype;
		/// <summary>
		/// 
		/// </summary>
		public string VoucherID
		{
			set{ _voucherid=value;}
			get{return _voucherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoucherCode
		{
			set{ _vouchercode=value;}
			get{return _vouchercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDept_num
		{
			set{ _cdept_num=value;}
			get{return _cdept_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vApprover
		{
			set{ _vapprover=value;}
			get{return _vapprover;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vJbCode
		{
			set{ _vjbcode=value;}
			get{return _vjbcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iComputeType
		{
			set{ _icomputetype=value;}
			get{return _icomputetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vReason
		{
			set{ _vreason=value;}
			get{return _vreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vRemark
		{
			set{ _vremark=value;}
			get{return _vremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dJbDate
		{
			set{ _djbdate=value;}
			get{return _djbdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nManHours
		{
			set{ _nmanhours=value;}
			get{return _nmanhours;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cTimeUseless1
		{
			set{ _ctimeuseless1=value;}
			get{return _ctimeuseless1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cTimeUseless2
		{
			set{ _ctimeuseless2=value;}
			get{return _ctimeuseless2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dDutyTime
		{
			set{ _ddutytime=value;}
			get{return _ddutytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dOffTime
		{
			set{ _dofftime=value;}
			get{return _dofftime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bOverDate
		{
			set{ _boverdate=value;}
			get{return _boverdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bOverDate2
		{
			set{ _boverdate2=value;}
			get{return _boverdate2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dBegintime
		{
			set{ _dbegintime=value;}
			get{return _dbegintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dEndTime
		{
			set{ _dendtime=value;}
			get{return _dendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iBeginCardAhead
		{
			set{ _ibegincardahead=value;}
			get{return _ibegincardahead;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iEndCardForward
		{
			set{ _iendcardforward=value;}
			get{return _iendcardforward;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? rFreeCardMode
		{
			set{ _rfreecardmode=value;}
			get{return _rfreecardmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? nMaxDelay
		{
			set{ _nmaxdelay=value;}
			get{return _nmaxdelay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? nMaxLeave
		{
			set{ _nmaxleave=value;}
			get{return _nmaxleave;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bLastFlag
		{
			set{ _blastflag=value;}
			get{return _blastflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iRecordId
		{
			set{ _irecordid=value;}
			get{return _irecordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bAuditFlag
		{
			set{ _bauditflag=value;}
			get{return _bauditflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cAuditor
		{
			set{ _cauditor=value;}
			get{return _cauditor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cAuditorNum
		{
			set{ _cauditornum=value;}
			get{return _cauditornum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCreator
		{
			set{ _ccreator=value;}
			get{return _ccreator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCreatorNum
		{
			set{ _ccreatornum=value;}
			get{return _ccreatornum;}
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
		public string cOperatorNum
		{
			set{ _coperatornum=value;}
			get{return _coperatornum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dOperatTime
		{
			set{ _doperattime=value;}
			get{return _doperattime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dAuditTime
		{
			set{ _daudittime=value;}
			get{return _daudittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dCreatTime
		{
			set{ _dcreattime=value;}
			get{return _dcreattime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rDealType
		{
			set{ _rdealtype=value;}
			get{return _rdealtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cExamineApproveType
		{
			set{ _cexamineapprovetype=value;}
			get{return _cexamineapprovetype;}
		}
		#endregion Model

	}
}

