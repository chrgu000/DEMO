using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// SaleBillVouchs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SaleBillVouchs
	{
		public SaleBillVouchs()
		{}
		#region Model
		private long _sbvid= 0;
		private long _autoid=  0;
		private string _cwhcode;
		private string _cinvcode;
		private decimal? _iquantity=  0M;
		private decimal? _inum=  0M;
		private decimal? _iquotedprice= 0M;
		private decimal? _iunitprice=  0M;
		private decimal? _itaxunitprice= 0M;
		private decimal? _imoney= 0M;
		private decimal? _itax=  0M;
		private decimal? _isum= 0M;
		private decimal? _idiscount= 0M;
		private decimal? _inatunitprice=  0M;
		private decimal? _inatmoney=  0M;
		private decimal? _inattax= 0M;
		private decimal? _inatsum=  0M;
		private decimal? _inatdiscount= 0M;
		private long _isbvid= 0;
		private decimal? _imoneysum=  0M;
		private decimal? _iexchsum= 0M;
		private string _cclue;
		private string _cincomesub;
		private string _ctaxsub;
		private DateTime? _dsigndate;
		private string _cmemo;
		private long? _ibatch= 0;
		private string _cbatch;
		private bool _bsettleall= false;
		private string _cfree1;
		private string _cfree2;
		private long? _rdsid;
		private long _itb=0;
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
		private string _citemname;
		private string _citem_cname;
		private string _cfree3;
		private string _cfree4;
		private string _cfree5;
		private string _cfree6;
		private string _cfree7;
		private string _cfree8;
		private string _cfree9;
		private string _cfree10;
		private decimal? _iinvexchrate;
		private string _cunitid;
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
		private DateTime? _dmdate;
		private long _ipbvsid;
		private string _ccode;
		private string _csocode;
		private bool _bgsp;
		private long? _ippartseqid;
		private long? _ippartid;
		private decimal? _ippartqty;
		private string _ccontractid;
		private string _ccontracttagcode;
		private Guid _ccontractrowguid;
		private long? _imassdate;
		private long? _cmassunit;
		private bool _bqaneedcheck= false;
		private bool _bqaurgency= false;
		private string _ccusinvcode;
		private string _ccusinvname;
		private string _cbaccounter;
		private bool _bcosting= true;
		private string _cordercode;
		private long? _iorderrowno;
		private decimal? _fcusminprice;
		private string _cvmivencode;
		private string _cvenabbname;
		private long? _irowno;
		private long? _iexpiratdatecalcu;
		private DateTime? _dexpirationdate;
		private string _cexpirationdate;
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
		private long? _idemandtype;
		private string _cdemandcode;
		private string _cdemandmemo;
		private string _cdemandid;
		private long? _idemandseq;
		private string _cbdlcode;
		private long? _iinvsncount;
		private string _cinvsn;
		private string _creasoncode;
		private string _cvencode;
		private bool _bneedsign;
		private string _cgathingcode;
		private decimal? _ftaxpasum;
		private decimal? _fpasum;
		private decimal? _fnattaxpasum;
		private decimal? _fnatpasum;
		private Guid _body_outid;
		private string _cpznum;
		private string _cinvouchtype;
		private string _cbookwhcode;
		private decimal? _icostquantity;
		private decimal? _icostsum;
		private string _cposition;
		private DateTime? _dkeepdate;
		private long _isaleoutid;
		private bool _bsaleprice;
		private bool _bgift;
		private string _cbsaleout;
		private bool _bmpforderclosed;
		private string _cbsysbarcode;
		/// <summary>
		/// 
		/// </summary>
		public long SBVID
		{
			set{ _sbvid=value;}
			get{return _sbvid;}
		}
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
		public long iSBVID
		{
			set{ _isbvid=value;}
			get{return _isbvid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iMoneySum
		{
			set{ _imoneysum=value;}
			get{return _imoneysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iExchSum
		{
			set{ _iexchsum=value;}
			get{return _iexchsum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cClue
		{
			set{ _cclue=value;}
			get{return _cclue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cIncomeSub
		{
			set{ _cincomesub=value;}
			get{return _cincomesub;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cTaxSub
		{
			set{ _ctaxsub=value;}
			get{return _ctaxsub;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dSignDate
		{
			set{ _dsigndate=value;}
			get{return _dsigndate;}
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
		public long iTB
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
		public decimal? iInvExchRate
		{
			set{ _iinvexchrate=value;}
			get{return _iinvexchrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cUnitID
		{
			set{ _cunitid=value;}
			get{return _cunitid;}
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
		public DateTime? dMDate
		{
			set{ _dmdate=value;}
			get{return _dmdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long iPBVsID
		{
			set{ _ipbvsid=value;}
			get{return _ipbvsid;}
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
		public string cSoCode
		{
			set{ _csocode=value;}
			get{return _csocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bgsp
		{
			set{ _bgsp=value;}
			get{return _bgsp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iPPartSeqID
		{
			set{ _ippartseqid=value;}
			get{return _ippartseqid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iPPartID
		{
			set{ _ippartid=value;}
			get{return _ippartid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iPPartQty
		{
			set{ _ippartqty=value;}
			get{return _ippartqty;}
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
		public string cContractTagCode
		{
			set{ _ccontracttagcode=value;}
			get{return _ccontracttagcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid cContractRowGuid
		{
			set{ _ccontractrowguid=value;}
			get{return _ccontractrowguid;}
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
		public long? cMassUnit
		{
			set{ _cmassunit=value;}
			get{return _cmassunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bQANeedCheck
		{
			set{ _bqaneedcheck=value;}
			get{return _bqaneedcheck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bQAUrgency
		{
			set{ _bqaurgency=value;}
			get{return _bqaurgency;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCusInvCode
		{
			set{ _ccusinvcode=value;}
			get{return _ccusinvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCusInvName
		{
			set{ _ccusinvname=value;}
			get{return _ccusinvname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbaccounter
		{
			set{ _cbaccounter=value;}
			get{return _cbaccounter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bcosting
		{
			set{ _bcosting=value;}
			get{return _bcosting;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cordercode
		{
			set{ _cordercode=value;}
			get{return _cordercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iorderrowno
		{
			set{ _iorderrowno=value;}
			get{return _iorderrowno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fcusminprice
		{
			set{ _fcusminprice=value;}
			get{return _fcusminprice;}
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
		public string cVenAbbName
		{
			set{ _cvenabbname=value;}
			get{return _cvenabbname;}
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
		public long? iExpiratDateCalcu
		{
			set{ _iexpiratdatecalcu=value;}
			get{return _iexpiratdatecalcu;}
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
		public string cExpirationdate
		{
			set{ _cexpirationdate=value;}
			get{return _cexpirationdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cbatchproperty1
		{
			set{ _cbatchproperty1=value;}
			get{return _cbatchproperty1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cbatchproperty2
		{
			set{ _cbatchproperty2=value;}
			get{return _cbatchproperty2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cbatchproperty3
		{
			set{ _cbatchproperty3=value;}
			get{return _cbatchproperty3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cbatchproperty4
		{
			set{ _cbatchproperty4=value;}
			get{return _cbatchproperty4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? cbatchproperty5
		{
			set{ _cbatchproperty5=value;}
			get{return _cbatchproperty5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbatchproperty6
		{
			set{ _cbatchproperty6=value;}
			get{return _cbatchproperty6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbatchproperty7
		{
			set{ _cbatchproperty7=value;}
			get{return _cbatchproperty7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbatchproperty8
		{
			set{ _cbatchproperty8=value;}
			get{return _cbatchproperty8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbatchproperty9
		{
			set{ _cbatchproperty9=value;}
			get{return _cbatchproperty9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? cbatchproperty10
		{
			set{ _cbatchproperty10=value;}
			get{return _cbatchproperty10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? idemandtype
		{
			set{ _idemandtype=value;}
			get{return _idemandtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cdemandcode
		{
			set{ _cdemandcode=value;}
			get{return _cdemandcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cdemandmemo
		{
			set{ _cdemandmemo=value;}
			get{return _cdemandmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cdemandid
		{
			set{ _cdemandid=value;}
			get{return _cdemandid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? idemandseq
		{
			set{ _idemandseq=value;}
			get{return _idemandseq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbdlcode
		{
			set{ _cbdlcode=value;}
			get{return _cbdlcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? iInvSNCount
		{
			set{ _iinvsncount=value;}
			get{return _iinvsncount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvSN
		{
			set{ _cinvsn=value;}
			get{return _cinvsn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cReasonCode
		{
			set{ _creasoncode=value;}
			get{return _creasoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cvencode
		{
			set{ _cvencode=value;}
			get{return _cvencode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bneedsign
		{
			set{ _bneedsign=value;}
			get{return _bneedsign;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cgathingcode
		{
			set{ _cgathingcode=value;}
			get{return _cgathingcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ftaxpasum
		{
			set{ _ftaxpasum=value;}
			get{return _ftaxpasum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fpasum
		{
			set{ _fpasum=value;}
			get{return _fpasum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fnattaxpasum
		{
			set{ _fnattaxpasum=value;}
			get{return _fnattaxpasum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fnatpasum
		{
			set{ _fnatpasum=value;}
			get{return _fnatpasum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid body_outid
		{
			set{ _body_outid=value;}
			get{return _body_outid;}
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
		public string cInVouchType
		{
			set{ _cinvouchtype=value;}
			get{return _cinvouchtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBookWhcode
		{
			set{ _cbookwhcode=value;}
			get{return _cbookwhcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? icostquantity
		{
			set{ _icostquantity=value;}
			get{return _icostquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? icostsum
		{
			set{ _icostsum=value;}
			get{return _icostsum;}
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
		public DateTime? dkeepdate
		{
			set{ _dkeepdate=value;}
			get{return _dkeepdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long isaleoutid
		{
			set{ _isaleoutid=value;}
			get{return _isaleoutid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bsaleprice
		{
			set{ _bsaleprice=value;}
			get{return _bsaleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bgift
		{
			set{ _bgift=value;}
			get{return _bgift;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbsaleout
		{
			set{ _cbsaleout=value;}
			get{return _cbsaleout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bmpforderclosed
		{
			set{ _bmpforderclosed=value;}
			get{return _bmpforderclosed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cbSysBarCode
		{
			set{ _cbsysbarcode=value;}
			get{return _cbsysbarcode;}
		}
		#endregion Model

	}
}

