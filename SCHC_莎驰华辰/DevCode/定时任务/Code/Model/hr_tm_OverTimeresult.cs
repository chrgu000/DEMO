using System;
namespace Model
{
	/// <summary>
	/// hr_tm_OverTimeresult:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hr_tm_OverTimeresult
	{
		public hr_tm_OverTimeresult()
		{}
		#region Model
		private Guid _urecordid;
		private Guid _uovertimecode;
		private string _cpsn_num;
		private decimal? _novertimehours=0M;
		private decimal? _nsubovtime;
		private string _vcardtime;
		private decimal? _nmanhours;
		private string _djbdate="";
		private string _vjbcode;
		private string _vreason;
		private string _vapprover;
		private string _vremark;
		private string _dbegintime="";
		private string _dendtime="";
		private int? _nmaxdelay;
		private int? _nmaxleave;
		private decimal? _nabsent0;
		private decimal? _nabsent1;
		private decimal? _nresttime;
		private string _ddutytime="";
		private string _dofftime="";
		private int? _boverdate=0;
		private int? _boverdate2=0;
		private int? _bperiod=0;
		private int? _bcompute=0;
		private int? _icomputetype;
		private string _dovstartcard="";
		private string _dovendcard="";
		private int? _irecordid;
		private bool _blastflag;
		private string _vstatus1;
		private decimal? _nstatus2;
		private int? _iactualoverminute;
		private string _cauditornum;
		private string _cauditor;
		private string _daudittime;
		private bool _bauditflag= false;
		private string _ccreatornum;
		private string _ccreator;
		private string _dcreattime;
		private string _coperatornum;
		private string _coperator;
		private string _doperattime;
		private string _rfreecardmode;
		private string _jobnumber;
		private int? _ilabsentminute;
		private int? _ieabsentminute;
		private int? _iabsentminute;
		private string _rsigncardreason1;
		private string _rsigncardreason2;
		private decimal? _nabsentoverhours;
		private string _drealdutytime;
		private string _drealofftime;
		private string _voucherid;
		private string _ctimeuseless1;
		private string _ctimeuseless2;
		private decimal? _ndeductedtime=0M;
		private decimal? _ncanceledtime=0M;
		private decimal? _nbalancedtime=0M;
		private DateTime? _dvaliditydate;
		private int? _cexamineapprovetype;
		private string _cinitperiod;
		private decimal? _navailableoverhours=0M;
		private int? _irowno;
		private DateTime? _hrts;
		private byte[] _concurrencyhrts;
		private string _rdealtype;
		/// <summary>
		/// 
		/// </summary>
		public Guid uRecordId
		{
			set{ _urecordid=value;}
			get{return _urecordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid uOverTimeCode
		{
			set{ _uovertimecode=value;}
			get{return _uovertimecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPsn_Num
		{
			set{ _cpsn_num=value;}
			get{return _cpsn_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nOvertimeHours
		{
			set{ _novertimehours=value;}
			get{return _novertimehours;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nSubOVTime
		{
			set{ _nsubovtime=value;}
			get{return _nsubovtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vCardTime
		{
			set{ _vcardtime=value;}
			get{return _vcardtime;}
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
		public string dJbDate
		{
			set{ _djbdate=value;}
			get{return _djbdate;}
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
		public string vReason
		{
			set{ _vreason=value;}
			get{return _vreason;}
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
		public string vRemark
		{
			set{ _vremark=value;}
			get{return _vremark;}
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
		public decimal? nAbsent0
		{
			set{ _nabsent0=value;}
			get{return _nabsent0;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nAbsent1
		{
			set{ _nabsent1=value;}
			get{return _nabsent1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nRestTime
		{
			set{ _nresttime=value;}
			get{return _nresttime;}
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
		public int? bPeriod
		{
			set{ _bperiod=value;}
			get{return _bperiod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bCompute
		{
			set{ _bcompute=value;}
			get{return _bcompute;}
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
		public string dOVStartCard
		{
			set{ _dovstartcard=value;}
			get{return _dovstartcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dOVEndCard
		{
			set{ _dovendcard=value;}
			get{return _dovendcard;}
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
		public bool bLastFlag
		{
			set{ _blastflag=value;}
			get{return _blastflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vStatus1
		{
			set{ _vstatus1=value;}
			get{return _vstatus1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nStatus2
		{
			set{ _nstatus2=value;}
			get{return _nstatus2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iActualOverMinute
		{
			set{ _iactualoverminute=value;}
			get{return _iactualoverminute;}
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
		public string cAuditor
		{
			set{ _cauditor=value;}
			get{return _cauditor;}
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
		public bool bAuditFlag
		{
			set{ _bauditflag=value;}
			get{return _bauditflag;}
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
		public string cCreator
		{
			set{ _ccreator=value;}
			get{return _ccreator;}
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
		public string cOperatorNum
		{
			set{ _coperatornum=value;}
			get{return _coperatornum;}
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
		public string dOperatTime
		{
			set{ _doperattime=value;}
			get{return _doperattime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rFreeCardMode
		{
			set{ _rfreecardmode=value;}
			get{return _rfreecardmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobNumber
		{
			set{ _jobnumber=value;}
			get{return _jobnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iLAbsentMinute
		{
			set{ _ilabsentminute=value;}
			get{return _ilabsentminute;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iEAbsentMinute
		{
			set{ _ieabsentminute=value;}
			get{return _ieabsentminute;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iAbsentMinute
		{
			set{ _iabsentminute=value;}
			get{return _iabsentminute;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rSignCardReason1
		{
			set{ _rsigncardreason1=value;}
			get{return _rsigncardreason1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rSignCardReason2
		{
			set{ _rsigncardreason2=value;}
			get{return _rsigncardreason2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nAbsentOverHours
		{
			set{ _nabsentoverhours=value;}
			get{return _nabsentoverhours;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dRealDutyTime
		{
			set{ _drealdutytime=value;}
			get{return _drealdutytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dRealOffTime
		{
			set{ _drealofftime=value;}
			get{return _drealofftime;}
		}
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
		public decimal? nDeductedTime
		{
			set{ _ndeductedtime=value;}
			get{return _ndeductedtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nCanceledTime
		{
			set{ _ncanceledtime=value;}
			get{return _ncanceledtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nBalancedTime
		{
			set{ _nbalancedtime=value;}
			get{return _nbalancedtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dValidityDate
		{
			set{ _dvaliditydate=value;}
			get{return _dvaliditydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cExamineApproveType
		{
			set{ _cexamineapprovetype=value;}
			get{return _cexamineapprovetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInitPeriod
		{
			set{ _cinitperiod=value;}
			get{return _cinitperiod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? nAvailableOverHours
		{
			set{ _navailableoverhours=value;}
			get{return _navailableoverhours;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iRowNo
		{
			set{ _irowno=value;}
			get{return _irowno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? hrts
		{
			set{ _hrts=value;}
			get{return _hrts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] concurrencyHrts
		{
			set{ _concurrencyhrts=value;}
			get{return _concurrencyhrts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rDealType
		{
			set{ _rdealtype=value;}
			get{return _rdealtype;}
		}
		#endregion Model

	}
}

