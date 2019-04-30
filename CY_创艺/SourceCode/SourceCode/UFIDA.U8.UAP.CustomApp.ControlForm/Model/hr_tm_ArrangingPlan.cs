using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// hr_tm_ArrangingPlan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hr_tm_ArrangingPlan
	{
		public hr_tm_ArrangingPlan()
		{}
		#region Model
		private int _irecordid;
		private string _voucherid;
		private string _deptcode;
		private string _year;
		private string _week;
		private bool _haschilddept;
		private string _begindate;
        private string _enddate;
		private string _seldutys;
		private string _periodtype;
		private string _vremark;
		private string _cauditor;
		private bool _bauditflag;
		private string _cauditornum;
		private string _daudittime;
		private string _ccreatornum;
		private string _ccreator;
		private string _dcreattime;
		private string _coperatornum;
		private string _coperator;
		private string _doperattime;
		private bool _blastflag;
		private string _vstatus1;
		private decimal? _nstatus2;
		/// <summary>
		/// 
		/// </summary>
		public int iRecordID
		{
			set{ _irecordid=value;}
			get{return _irecordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VoucherId
		{
			set{ _voucherid=value;}
			get{return _voucherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptCode
		{
			set{ _deptcode=value;}
			get{return _deptcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Week
		{
			set{ _week=value;}
			get{return _week;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool HasChildDept
		{
			set{ _haschilddept=value;}
			get{return _haschilddept;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BeginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SelDutys
		{
			set{ _seldutys=value;}
			get{return _seldutys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PeriodType
		{
			set{ _periodtype=value;}
			get{return _periodtype;}
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
		public string cAuditor
		{
			set{ _cauditor=value;}
			get{return _cauditor;}
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
		public string cAuditorNum
		{
			set{ _cauditornum=value;}
			get{return _cauditornum;}
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
		#endregion Model

	}
}

