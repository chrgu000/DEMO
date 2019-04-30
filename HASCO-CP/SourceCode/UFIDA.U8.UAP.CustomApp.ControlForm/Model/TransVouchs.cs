using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// TransVouchs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TransVouchs
	{
		public TransVouchs()
		{}
		#region Model
		private string _ctvcode;
		private string _cinvcode;
		private long? _rdsid=  0;
		private decimal? _itvnum=  0M;
		private decimal? _itvquantity=  0M;
		private decimal? _itvacost;
		private decimal? _itvaprice;
		private decimal? _itvpcost;
		private decimal? _itvpprice;
		private string _ctvbatch;
		private DateTime? _ddisdate;
		private string _cfree1;
		private string _cfree2;
		private string _cdefine22;
		private string _cdefine23;
		private string _cdefine24;
		private string _cdefine25;
		private decimal? _cdefine26;
		private decimal? _cdefine27;
		private string _citemcode;
		private string _citem_class;
		private decimal? _fsalecost;
		private decimal? _fsaleprice;
		private string _cname;
		private string _citemcname;
		private long _autoid;
		private long _id;
		private long? _imassdate;
		private string _cbarcode;
		private string _cassunit;
		private string _cfree3;
		private string _cfree4;
		private string _cfree5;
		private string _cfree6;
		private string _cfree7;
		private string _cfree8;
		private string _cfree9;
		private string _cfree10;
		private string _cdefine28;
		private string _cdefine29;
		private string _cdefine30;
		private string _cdefine31;
		private string _cdefine32;
		private string _cdefine33;
		private long? _cdefine34;
		private long? _cdefine35;
		private DateTime? _cdefine36;
		private DateTime? _cdefine37;
		private long? _impoids;
		private string _cbvencode;
		private string _cinvouchcode;
		private DateTime? _dmadedate;
		private long? _cmassunit;
		private long? _itrids;
		private long? _apptransids;
		private long? _issotype=0;
		private string _issodid;
		private long? _idsotype=0;
		private string _idsodid;
		private bool _bcosting;
		private string _cvmivencode= "null";
		private string _cinposcode= "null";
		private string _coutposcode= "null";
		private long? _iinvsncount;
		private decimal? _iinvexchrate=null;
		private string _comcode;
		private string _cmocode;
		private string _invcode;
		private long? _imoseq;
		private long? _iomids;
		private long? _imoids;
		private string _corufts="";
		private long? _iexpiratdatecalcu;
		private string _cexpirationdate;
		private DateTime? _dexpirationdate;
		private decimal? _cbatchproperty1;
		private decimal? _cbatchproperty2;
		private decimal? _cbatchproperty3;
		private decimal? _cbatchproperty4;
		private decimal? _cbatchproperty5;
		private string _cbatchproperty6;
		private string _cbatchproperty7;
		private string _cbatchproperty8;
		private string _cbatchproperty9;
		private DateTime? _cbatchproperty10;
		private string _cciqbookcode;
		private string _cbmemo;
		private long? _irowno;
		private Guid _strowguid;
		private string _cinvouchtype;
		private string _cbsourcecodels;
		private string _cmolotcode;
		private long? _cinvoucherlineid;
		private string _cinvouchercode;
		private string _cinvouchertype;
		private string _cbsysbarcode;
		/// <summary>
		/// 
		/// </summary>
		public string cTVCode
		{
			set{ _ctvcode=value;}
			get{return _ctvcode;}
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
		public long? RdsID
		{
			set{ _rdsid=value;}
			get{return _rdsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTVNum
		{
			set{ _itvnum=value;}
			get{return _itvnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTVQuantity
		{
			set{ _itvquantity=value;}
			get{return _itvquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTVACost
		{
			set{ _itvacost=value;}
			get{return _itvacost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTVAPrice
		{
			set{ _itvaprice=value;}
			get{return _itvaprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTVPCost
		{
			set{ _itvpcost=value;}
			get{return _itvpcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTVPPrice
		{
			set{ _itvpprice=value;}
			get{return _itvpprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cTVBatch
		{
			set{ _ctvbatch=value;}
			get{return _ctvbatch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dDisDate
		{
			set{ _ddisdate=value;}
			get{return _ddisdate;}
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
		public long autoID
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
		public long? iMassDate
		{
			set{ _imassdate=value;}
			get{return _imassdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBarCode
		{
			set{ _cbarcode=value;}
			get{return _cbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cAssUnit
		{
			set{ _cassunit=value;}
			get{return _cassunit;}
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
		public string cDefine28
		{
			set{ _cdefine28=value;}
			get{return _cdefine28;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine29
		{
			set{ _cdefine29=value;}
			get{return _cdefine29;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine30
		{
			set{ _cdefine30=value;}
			get{return _cdefine30;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine31
		{
			set{ _cdefine31=value;}
			get{return _cdefine31;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine32
		{
			set{ _cdefine32=value;}
			get{return _cdefine32;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDefine33
		{
			set{ _cdefine33=value;}
			get{return _cdefine33;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? cDefine34
		{
			set{ _cdefine34=value;}
			get{return _cdefine34;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? cDefine35
		{
			set{ _cdefine35=value;}
			get{return _cdefine35;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cDefine36
		{
			set{ _cdefine36=value;}
			get{return _cdefine36;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cDefine37
		{
			set{ _cdefine37=value;}
			get{return _cdefine37;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iMPoIds
		{
			set{ _impoids=value;}
			get{return _impoids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBVencode
		{
			set{ _cbvencode=value;}
			get{return _cbvencode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInVouchCode
		{
			set{ _cinvouchcode=value;}
			get{return _cinvouchcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dMadeDate
		{
			set{ _dmadedate=value;}
			get{return _dmadedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? cMassUnit
		{
			set{ _cmassunit=value;}
			get{return _cmassunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iTRIds
		{
			set{ _itrids=value;}
			get{return _itrids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? AppTransIDS
		{
			set{ _apptransids=value;}
			get{return _apptransids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iSSoType
		{
			set{ _issotype=value;}
			get{return _issotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string iSSodid
		{
			set{ _issodid=value;}
			get{return _issodid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iDSoType
		{
			set{ _idsotype=value;}
			get{return _idsotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string iDSodid
		{
			set{ _idsodid=value;}
			get{return _idsodid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bCosting
		{
			set{ _bcosting=value;}
			get{return _bcosting;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvmivencode
		{
			set{ _cvmivencode=value;}
			get{return _cvmivencode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cinposcode
		{
			set{ _cinposcode=value;}
			get{return _cinposcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string coutposcode
		{
			set{ _coutposcode=value;}
			get{return _coutposcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iinvsncount
		{
			set{ _iinvsncount=value;}
			get{return _iinvsncount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iinvexchrate
		{
			set{ _iinvexchrate=value;}
			get{return _iinvexchrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comcode
		{
			set{ _comcode=value;}
			get{return _comcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cmocode
		{
			set{ _cmocode=value;}
			get{return _cmocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invcode
		{
			set{ _invcode=value;}
			get{return _invcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? imoseq
		{
			set{ _imoseq=value;}
			get{return _imoseq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iomids
		{
			set{ _iomids=value;}
			get{return _iomids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? imoids
		{
			set{ _imoids=value;}
			get{return _imoids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string corufts
		{
			set{ _corufts=value;}
			get{return _corufts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iExpiratDateCalcu
		{
			set{ _iexpiratdatecalcu=value;}
			get{return _iexpiratdatecalcu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cExpirationdate
		{
			set{ _cexpirationdate=value;}
			get{return _cexpirationdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dExpirationdate
		{
			set{ _dexpirationdate=value;}
			get{return _dexpirationdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cBatchProperty1
		{
			set{ _cbatchproperty1=value;}
			get{return _cbatchproperty1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cBatchProperty2
		{
			set{ _cbatchproperty2=value;}
			get{return _cbatchproperty2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cBatchProperty3
		{
			set{ _cbatchproperty3=value;}
			get{return _cbatchproperty3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cBatchProperty4
		{
			set{ _cbatchproperty4=value;}
			get{return _cbatchproperty4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cBatchProperty5
		{
			set{ _cbatchproperty5=value;}
			get{return _cbatchproperty5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBatchProperty6
		{
			set{ _cbatchproperty6=value;}
			get{return _cbatchproperty6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBatchProperty7
		{
			set{ _cbatchproperty7=value;}
			get{return _cbatchproperty7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBatchProperty8
		{
			set{ _cbatchproperty8=value;}
			get{return _cbatchproperty8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBatchProperty9
		{
			set{ _cbatchproperty9=value;}
			get{return _cbatchproperty9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cBatchProperty10
		{
			set{ _cbatchproperty10=value;}
			get{return _cbatchproperty10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cciqbookcode
		{
			set{ _cciqbookcode=value;}
			get{return _cciqbookcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbMemo
		{
			set{ _cbmemo=value;}
			get{return _cbmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? irowno
		{
			set{ _irowno=value;}
			get{return _irowno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid strowguid
		{
			set{ _strowguid=value;}
			get{return _strowguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cinvouchtype
		{
			set{ _cinvouchtype=value;}
			get{return _cinvouchtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbsourcecodels
		{
			set{ _cbsourcecodels=value;}
			get{return _cbsourcecodels;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cMoLotCode
		{
			set{ _cmolotcode=value;}
			get{return _cmolotcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? cInVoucherLineID
		{
			set{ _cinvoucherlineid=value;}
			get{return _cinvoucherlineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInVoucherCode
		{
			set{ _cinvouchercode=value;}
			get{return _cinvouchercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInVoucherType
		{
			set{ _cinvouchertype=value;}
			get{return _cinvouchertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbsysbarcode
		{
			set{ _cbsysbarcode=value;}
			get{return _cbsysbarcode;}
		}
		#endregion Model

	}
}

