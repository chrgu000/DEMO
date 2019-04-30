using System;
namespace TH.Model
{
	/// <summary>
	/// CurrentStock:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CurrentStock
	{
		public CurrentStock()
		{}
		#region Model
		private int _autoid;
		private string _cwhcode;
		private string _cinvcode;
		private decimal? _iquantity;
        private decimal? _inum;
		private string _cfree1="";
		private string _cfree2="";
		private decimal? _foutquantity;
		private decimal? _foutnum;
		private decimal? _finquantity;
		private decimal? _finnum;
		private string _cfree3="";
		private string _cfree4="";
		private string _cfree5="";
		private string _cfree6="";
		private string _cfree7="";
		private string _cfree8="";
		private string _cfree9="";
		private string _cfree10="";
		private string _cbatch="";
		private DateTime? _dvdate;
		private bool _bstopflag;
		private decimal? _ftransinquantity;
		private DateTime? _dmdate;
		private decimal? _ftransinnum;
		private decimal? _ftransoutquantity;
		private decimal? _ftransoutnum;
		private decimal? _fplanquantity;
		private decimal? _fplannum;
		private decimal? _fdisablequantity;
		private decimal? _fdisablenum;
		private decimal? _favaquantity;
		private decimal? _favanum;
		private DateTime? _ufts;
		private int? _imassdate=0;
		private bool _bgspstop;
		/// <summary>
		/// 
		/// </summary>
		public int AutoID
		{
			set{ _autoid=value;}
			get{return _autoid;}
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
		public string cInvCode
		{
			set{ _cinvcode=value;}
			get{return _cinvcode;}
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
		public decimal? iNum
		{
			set{ _inum=value;}
			get{return _inum;}
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
		public decimal? fOutQuantity
		{
			set{ _foutquantity=value;}
			get{return _foutquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fOutNum
		{
			set{ _foutnum=value;}
			get{return _foutnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fInQuantity
		{
			set{ _finquantity=value;}
			get{return _finquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fInNum
		{
			set{ _finnum=value;}
			get{return _finnum;}
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
		public string cBatch
		{
			set{ _cbatch=value;}
			get{return _cbatch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dVDate
		{
			set{ _dvdate=value;}
			get{return _dvdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bStopFlag
		{
			set{ _bstopflag=value;}
			get{return _bstopflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fTransInQuantity
		{
			set{ _ftransinquantity=value;}
			get{return _ftransinquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dMdate
		{
			set{ _dmdate=value;}
			get{return _dmdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fTransInNum
		{
			set{ _ftransinnum=value;}
			get{return _ftransinnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fTransOutQuantity
		{
			set{ _ftransoutquantity=value;}
			get{return _ftransoutquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fTransOutNum
		{
			set{ _ftransoutnum=value;}
			get{return _ftransoutnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fPlanQuantity
		{
			set{ _fplanquantity=value;}
			get{return _fplanquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fPlanNum
		{
			set{ _fplannum=value;}
			get{return _fplannum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fDisableQuantity
		{
			set{ _fdisablequantity=value;}
			get{return _fdisablequantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fDisableNum
		{
			set{ _fdisablenum=value;}
			get{return _fdisablenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fAvaQuantity
		{
			set{ _favaquantity=value;}
			get{return _favaquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fAvaNum
		{
			set{ _favanum=value;}
			get{return _favanum;}
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
		public int? iMassDate
		{
			set{ _imassdate=value;}
			get{return _imassdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool BGSPSTOP
		{
			set{ _bgspstop=value;}
			get{return _bgspstop;}
		}
		#endregion Model

	}
}

