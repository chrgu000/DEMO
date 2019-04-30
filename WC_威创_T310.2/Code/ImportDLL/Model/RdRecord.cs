using System;
namespace ImportDLL.Model
{
	/// <summary>
	/// RdRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RdRecord
	{
		public RdRecord()
		{}
		#region Model
		private long _id= 0;
		private long _brdflag= 0;
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
		private long _cbillcode;
		private long _cdlcode;
		private string _cprobatch;
		private string _chandler;
		private string _cmemo;
		private bool _btransflag= false;
		private string _caccounter;
		private string _cmaker;
		private decimal? _inetlock= 0M;
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
		private string _dkeepdate;
		private DateTime? _dveridate;
		private decimal? _itaxratehead;
		private string _csccode;
		private string _cshipaddress;
		private string _czqcode;
		private DateTime _dzqdate;
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
		public long bRdFlag
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
		public long cBillCode
		{
			set{ _cbillcode=value;}
			get{return _cbillcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long cDLCode
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
		public decimal? iTaxRateHead
		{
			set{ _itaxratehead=value;}
			get{return _itaxratehead;}
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
		public string cShipAddress
		{
			set{ _cshipaddress=value;}
			get{return _cshipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cZQCode
		{
			set{ _czqcode=value;}
			get{return _czqcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dZQDate
		{
			set{ _dzqdate=value;}
			get{return _dzqdate;}
		}
		#endregion Model

	}
}

