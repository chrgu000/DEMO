using System;
namespace ImportDLL.Model
{
	/// <summary>
	/// Inventory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Inventory
	{
		public Inventory()
		{}
		#region Model
		private string _cinvcode;
		private string _cinvaddcode;
		private string _cinvname;
		private string _cinvstd;
		private string _cinvccode;
		private string _cvencode;
		private string _cinvm_unit;
		private string _cinva_unit;
		private string _creplaceitem;
		private string _cposition;
		private bool _bsale= false;
		private bool _bpurchase= false;
		private bool _bself= false;
		private bool _bcomsume= false;
		private bool _bproducing= false;
		private bool _bservice= false;
		private bool _baccessary= false;
		private decimal? _iinvexchrate;
		private int? _itaxrate=  0;
		private decimal? _iinvweight;
		private decimal? _ivolume= 0M;
		private decimal? _iinvrcost;
		private decimal? _iinvsprice;
		private decimal? _iinvscost;
		private decimal? _iinvlscost;
		private decimal? _iinvncost;
		private decimal? _iinvadvance;
		private decimal? _iinvbatch;
		private decimal? _isafenum;
		private decimal? _itopsum;
		private decimal? _ilowsum;
		private decimal? _ioverstock;
		private string _cinvabc;
		private bool _binvquality= false;
		private bool _binvbatch= false;
		private bool _binventrust= false;
		private bool _binvoverstock= false;
		private DateTime? _dsdate;
		private DateTime? _dedate;
		private bool _bfree1= false;
		private bool _bfree2= false;
		private string _cinvdefine1;
		private string _cinvdefine2;
		private string _cinvdefine3;
		private int _i_id;
		private bool _binvtype= false;
		private decimal? _iinvmpcost;
		private string _cquality;
		private decimal? _iinvsalecost;
		private decimal? _iinvscost1;
		private decimal? _iinvscost2;
		private decimal? _iinvscost3;
		private decimal? _iinvscost4;
		private decimal? _iinvscost5;
		private decimal? _iinvwsprice;
		private string _cinvhelp;
		/// <summary>
		/// 
		/// </summary>
		public string cInvCode
		{
			set{ _cinvcode=value;}
			get{return _cinvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvAddCode
		{
			set{ _cinvaddcode=value;}
			get{return _cinvaddcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvName
		{
			set{ _cinvname=value;}
			get{return _cinvname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvStd
		{
			set{ _cinvstd=value;}
			get{return _cinvstd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvCCode
		{
			set{ _cinvccode=value;}
			get{return _cinvccode;}
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
		public string cInvM_Unit
		{
			set{ _cinvm_unit=value;}
			get{return _cinvm_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvA_Unit
		{
			set{ _cinva_unit=value;}
			get{return _cinva_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cReplaceItem
		{
			set{ _creplaceitem=value;}
			get{return _creplaceitem;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cPosition
		{
			set{ _cposition=value;}
			get{return _cposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bSale
		{
			set{ _bsale=value;}
			get{return _bsale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bPurchase
		{
			set{ _bpurchase=value;}
			get{return _bpurchase;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bSelf
		{
			set{ _bself=value;}
			get{return _bself;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bComsume
		{
			set{ _bcomsume=value;}
			get{return _bcomsume;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bProducing
		{
			set{ _bproducing=value;}
			get{return _bproducing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bService
		{
			set{ _bservice=value;}
			get{return _bservice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bAccessary
		{
			set{ _baccessary=value;}
			get{return _baccessary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvExchRate
		{
			set{ _iinvexchrate=value;}
			get{return _iinvexchrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iTaxRate
		{
			set{ _itaxrate=value;}
			get{return _itaxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvWeight
		{
			set{ _iinvweight=value;}
			get{return _iinvweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iVolume
		{
			set{ _ivolume=value;}
			get{return _ivolume;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvRCost
		{
			set{ _iinvrcost=value;}
			get{return _iinvrcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSPrice
		{
			set{ _iinvsprice=value;}
			get{return _iinvsprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSCost
		{
			set{ _iinvscost=value;}
			get{return _iinvscost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvLSCost
		{
			set{ _iinvlscost=value;}
			get{return _iinvlscost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvNCost
		{
			set{ _iinvncost=value;}
			get{return _iinvncost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvAdvance
		{
			set{ _iinvadvance=value;}
			get{return _iinvadvance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvBatch
		{
			set{ _iinvbatch=value;}
			get{return _iinvbatch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSafeNum
		{
			set{ _isafenum=value;}
			get{return _isafenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTopSum
		{
			set{ _itopsum=value;}
			get{return _itopsum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iLowSum
		{
			set{ _ilowsum=value;}
			get{return _ilowsum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOverStock
		{
			set{ _ioverstock=value;}
			get{return _ioverstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvABC
		{
			set{ _cinvabc=value;}
			get{return _cinvabc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bInvQuality
		{
			set{ _binvquality=value;}
			get{return _binvquality;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bInvBatch
		{
			set{ _binvbatch=value;}
			get{return _binvbatch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bInvEntrust
		{
			set{ _binventrust=value;}
			get{return _binventrust;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bInvOverStock
		{
			set{ _binvoverstock=value;}
			get{return _binvoverstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dSDate
		{
			set{ _dsdate=value;}
			get{return _dsdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dEDate
		{
			set{ _dedate=value;}
			get{return _dedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bFree1
		{
			set{ _bfree1=value;}
			get{return _bfree1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bFree2
		{
			set{ _bfree2=value;}
			get{return _bfree2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvDefine1
		{
			set{ _cinvdefine1=value;}
			get{return _cinvdefine1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvDefine2
		{
			set{ _cinvdefine2=value;}
			get{return _cinvdefine2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvDefine3
		{
			set{ _cinvdefine3=value;}
			get{return _cinvdefine3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int I_id
		{
			set{ _i_id=value;}
			get{return _i_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bInvType
		{
			set{ _binvtype=value;}
			get{return _binvtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvMPCost
		{
			set{ _iinvmpcost=value;}
			get{return _iinvmpcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cQuality
		{
			set{ _cquality=value;}
			get{return _cquality;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSaleCost
		{
			set{ _iinvsalecost=value;}
			get{return _iinvsalecost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSCost1
		{
			set{ _iinvscost1=value;}
			get{return _iinvscost1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSCost2
		{
			set{ _iinvscost2=value;}
			get{return _iinvscost2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSCost3
		{
			set{ _iinvscost3=value;}
			get{return _iinvscost3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSCost4
		{
			set{ _iinvscost4=value;}
			get{return _iinvscost4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvSCost5
		{
			set{ _iinvscost5=value;}
			get{return _iinvscost5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvWSPrice
		{
			set{ _iinvwsprice=value;}
			get{return _iinvwsprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvHelp
		{
			set{ _cinvhelp=value;}
			get{return _cinvhelp;}
		}
		#endregion Model

	}
}

