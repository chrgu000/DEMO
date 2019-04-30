using System;
namespace ImportDLL.Model
{
	/// <summary>
	/// RdRecords:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RdRecords
	{
		public RdRecords()
		{}
		#region Model
		private long _autoid=  0;
		private long _id=  0;
		private string _cinvcode;
		private decimal? _inum;
		private decimal? _iquantity;
		private decimal? _iunitcost;
		private decimal? _iprice;
		private decimal? _iaprice;
		private decimal? _ipunitcost;
		private decimal? _ipprice;
		private string _cbatch;
		private string _cobjcode;
		private string _cvouchcode;
		private string _cfree1;
		private string _cfree2;
		private long _iflag=  0;
		private DateTime? _dsdate;
		private decimal? _itax=  0M;
		private decimal? _isquantity=  0M;
		private decimal? _isnum=  0M;
		private decimal? _imoney= 0M;
		private decimal? _isoutquantity= 0M;
		private decimal? _isoutnum=  0M;
		private decimal? _ifnum=  0M;
		private decimal? _ifquantity=  0M;
		private DateTime? _dvdate;
		private long? _itrids=null;
		private string _cposition;
		private string _cdefine22;
		private string _cdefine23;
		private string _cdefine24;
		private string _cdefine25;
		private decimal? _cdefine26;
		private decimal? _cdefine27;
		private string _citem_class;
		private string _citemcode;
		private long? _iposid=null;
		private decimal? _facost=null;
		private long? _idlsid=null;
		private long? _isbsid=null;
		private decimal? _isendquantity=0M;
		private decimal? _isendnum=0M;
		private string _cname;
		private string _citemcname;
		private long? _iensid;
		private string _cblueid;
		private decimal? _idquantity=null;
		private bool _bdistribute= false;
		private decimal? _itaxunitprice;
		private decimal? _itaxprice;
		private decimal? _itaxrate;
		private long? _ipbsid;
		private decimal? _iinvexchrate=null;
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
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public decimal? iNum
		{
			set{ _inum=value;}
			get{return _inum;}
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
		public decimal? iUnitCost
		{
			set{ _iunitcost=value;}
			get{return _iunitcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iPrice
		{
			set{ _iprice=value;}
			get{return _iprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iAPrice
		{
			set{ _iaprice=value;}
			get{return _iaprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iPUnitCost
		{
			set{ _ipunitcost=value;}
			get{return _ipunitcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iPPrice
		{
			set{ _ipprice=value;}
			get{return _ipprice;}
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
		public string cObjCode
		{
			set{ _cobjcode=value;}
			get{return _cobjcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cVouchCode
		{
			set{ _cvouchcode=value;}
			get{return _cvouchcode;}
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
		public long iFlag
		{
			set{ _iflag=value;}
			get{return _iflag;}
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
		public decimal? iTax
		{
			set{ _itax=value;}
			get{return _itax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSQuantity
		{
			set{ _isquantity=value;}
			get{return _isquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSNum
		{
			set{ _isnum=value;}
			get{return _isnum;}
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
		public decimal? iSOutQuantity
		{
			set{ _isoutquantity=value;}
			get{return _isoutquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSOutNum
		{
			set{ _isoutnum=value;}
			get{return _isoutnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iFNum
		{
			set{ _ifnum=value;}
			get{return _ifnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iFQuantity
		{
			set{ _ifquantity=value;}
			get{return _ifquantity;}
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
		public long? iTrIds
		{
			set{ _itrids=value;}
			get{return _itrids;}
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
		public string cItem_class
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
		public long? iPOsID
		{
			set{ _iposid=value;}
			get{return _iposid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fACost
		{
			set{ _facost=value;}
			get{return _facost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iDLsID
		{
			set{ _idlsid=value;}
			get{return _idlsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iSBsID
		{
			set{ _isbsid=value;}
			get{return _isbsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSendQuantity
		{
			set{ _isendquantity=value;}
			get{return _isendquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iSendNum
		{
			set{ _isendnum=value;}
			get{return _isendnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cName
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cItemCName
		{
			set{ _citemcname=value;}
			get{return _citemcname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iEnsID
		{
			set{ _iensid=value;}
			get{return _iensid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBlueID
		{
			set{ _cblueid=value;}
			get{return _cblueid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iDQuantity
		{
			set{ _idquantity=value;}
			get{return _idquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bDistribute
		{
			set{ _bdistribute=value;}
			get{return _bdistribute;}
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
		public decimal? iTaxPrice
		{
			set{ _itaxprice=value;}
			get{return _itaxprice;}
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
		public long? iPBsID
		{
			set{ _ipbsid=value;}
			get{return _ipbsid;}
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

