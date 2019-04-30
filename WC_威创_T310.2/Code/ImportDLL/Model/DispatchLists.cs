using System;
namespace ImportDLL.Model
{
	/// <summary>
	/// DispatchLists:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DispatchLists
	{
		public DispatchLists()
		{}
		#region Model
		private long _autoid;
		private long _dlid=  0;
		private long _icorid=  0;
		private string _cwhcode;
		private string _cinvcode;
		private decimal? _iquantity=  0M;
		private decimal? _inum=  0M;
		private decimal? _iquotedprice=  0M;
		private decimal? _iunitprice=  0M;
		private decimal? _itaxunitprice=  0M;
		private decimal? _imoney=  0M;
		private decimal? _itax=  0M;
		private decimal? _isum= 0M;
		private decimal? _idiscount=  0M;
		private decimal? _inatunitprice=  0M;
		private decimal? _inatmoney=  0M;
		private decimal? _inattax= 0M;
		private decimal? _inatsum=  0M;
		private decimal? _inatdiscount=  0M;
		private decimal? _isettlenum=  0M;
		private decimal? _isettlequantity=  0M;
		private long? _ibatch=  0;
		private string _cbatch;
		private bool _bsettleall= false;
		private string _cmemo;
		private string _cfree1;
		private string _cfree2;
		private long? _rdsid;
		private long? _itb=0;
		private DateTime? _dvdate;
		private decimal? _tbquantity;
		private decimal? _tbnum;
		private long _isosid=0;
		private long _idlsid=0;
		private decimal? _kl=0M;
		private decimal? _kl2=0M;
		private string _cinvname;
		private decimal? _itaxrate=0M;
		private string _cdefine22;
		private string _cdefine23;
		private string _cdefine24;
		private string _cdefine25;
		private decimal? _cdefine26;
		private decimal? _cdefine27;
		private decimal? _foutquantity=0M;
		private decimal? _foutnum=0M;
		private string _citemcode;
		private string _citem_class;
		private decimal? _fsalecost;
		private decimal? _fsaleprice;
		private string _cvenabbname;
		private string _citemname;
		private string _citem_cname;
        private decimal? _iinvexchrate;
		/// <summary>
		/// 
		/// </summary>
		public long AutoID
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long DLID
		{
			set{ _dlid=value;}
			get{return _dlid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iCorID
		{
			set{ _icorid=value;}
			get{return _icorid;}
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
		public decimal? iQuotedPrice
		{
			set{ _iquotedprice=value;}
			get{return _iquotedprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iUnitPrice
		{
			set{ _iunitprice=value;}
			get{return _iunitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTaxUnitPrice
		{
			set{ _itaxunitprice=value;}
			get{return _itaxunitprice;}
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
		public decimal? iTax
		{
			set{ _itax=value;}
			get{return _itax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSum
		{
			set{ _isum=value;}
			get{return _isum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iDisCount
		{
			set{ _idiscount=value;}
			get{return _idiscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNatUnitPrice
		{
			set{ _inatunitprice=value;}
			get{return _inatunitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNatMoney
		{
			set{ _inatmoney=value;}
			get{return _inatmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNatTax
		{
			set{ _inattax=value;}
			get{return _inattax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNatSum
		{
			set{ _inatsum=value;}
			get{return _inatsum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNatDisCount
		{
			set{ _inatdiscount=value;}
			get{return _inatdiscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSettleNum
		{
			set{ _isettlenum=value;}
			get{return _isettlenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSettleQuantity
		{
			set{ _isettlequantity=value;}
			get{return _isettlequantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iBatch
		{
			set{ _ibatch=value;}
			get{return _ibatch;}
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
		public bool bSettleAll
		{
			set{ _bsettleall=value;}
			get{return _bsettleall;}
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
		public long? RdsID
		{
			set{ _rdsid=value;}
			get{return _rdsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iTB
		{
			set{ _itb=value;}
			get{return _itb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dvDate
		{
			set{ _dvdate=value;}
			get{return _dvdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TBQuantity
		{
			set{ _tbquantity=value;}
			get{return _tbquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TBNum
		{
			set{ _tbnum=value;}
			get{return _tbnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iSOsID
		{
			set{ _isosid=value;}
			get{return _isosid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iDLsID
		{
			set{ _idlsid=value;}
			get{return _idlsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KL
		{
			set{ _kl=value;}
			get{return _kl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KL2
		{
			set{ _kl2=value;}
			get{return _kl2;}
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
		public decimal? iTaxRate
		{
			set{ _itaxrate=value;}
			get{return _itaxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine22
		{
			set{ _cdefine22=value;}
			get{return _cdefine22;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine23
		{
			set{ _cdefine23=value;}
			get{return _cdefine23;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine24
		{
			set{ _cdefine24=value;}
			get{return _cdefine24;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine25
		{
			set{ _cdefine25=value;}
			get{return _cdefine25;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cDefine26
		{
			set{ _cdefine26=value;}
			get{return _cdefine26;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cDefine27
		{
			set{ _cdefine27=value;}
			get{return _cdefine27;}
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
		public string cItemCode
		{
			set{ _citemcode=value;}
			get{return _citemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cItem_class
		{
			set{ _citem_class=value;}
			get{return _citem_class;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fSaleCost
		{
			set{ _fsalecost=value;}
			get{return _fsalecost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fSalePrice
		{
			set{ _fsaleprice=value;}
			get{return _fsaleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVenAbbName
		{
			set{ _cvenabbname=value;}
			get{return _cvenabbname;}
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
		public string cItem_CName
		{
			set{ _citem_cname=value;}
			get{return _citem_cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvExchRate
		{
			set{ _iinvexchrate=value;}
			get{return _iinvexchrate;}
		}
		#endregion Model

	}
}

