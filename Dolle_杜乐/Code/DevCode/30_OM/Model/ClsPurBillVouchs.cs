using System;
namespace OM.Model
{
	/// <summary>
	/// PurBillVouchs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PurBillVouchs
	{
		public PurBillVouchs()
		{}
		#region Model
		private long _id= 0;
		private long _pbvid=0;
		private string _cinvcode;
		private bool _bexbill= false;
		private DateTime? _dindate;
		private decimal? _ipbvquantity= 0M;
		private decimal? _inum=0M;
		private decimal? _ioricost= 0M;
		private decimal? _iorimoney= 0M;
		private decimal? _ioritaxprice= 0M;
		private decimal? _iorisum= 0M;
		private decimal? _icost=0M;
		private decimal? _imoney=0M;
		private decimal? _itaxprice= 0M;
		private decimal? _isum= 0M;
		private decimal? _iexmoney= 0M;
		private decimal? _ilostquan=0M;
		private decimal? _inlostquan= 0M;
		private decimal? _inlostmoney=0M;
		private decimal? _ioritotal= 0M;
		private decimal? _itotal= 0M;
		private string _cdebithead;
		private string _ctaxhead;
		private string _cclue;
		private DateTime? _dsigndate;
		private string _ccorinvcode;
		private string _cfree1;
		private string _cfree2;
		private decimal? _itaxrate;
		private string _cdefine22;
		private string _cdefine23;
		private string _cdefine24;
		private string _cdefine25;
		private decimal? _cdefine26=0M;
		private decimal? _cdefine27=0M;
		private int _iposid=0;
		private string _citemcode;
		private string _citem_class;
		private string _cnlosttype;
		private decimal? _mnlosttax=0M;
		private string _citemname;
		private string _cfree3;
		private string _cfree4;
		private string _cfree5;
		private string _cfree6;
		private string _cfree7;
		private string _cfree8;
		private string _cfree9;
		private string _cfree10;
		private DateTime? _dsdate;
		private string _cunitid;
		private string _cdefine28;
		private string _cdefine29;
		private string _cdefine30;
		private string _cdefine31;
		private string _cdefine32;
		private string _cdefine33;
		private int? _cdefine34;
		private int? _cdefine35;
		private DateTime? _cdefine36;
		private DateTime? _cdefine37;
		private int? _isbsid;
		private long _rdsid;
		private Guid _contractrowguid;
		private decimal? _ioritaxcost;
		private string _upsotype;
		private string _cbaccounter;
		private bool _bcosting;
		private decimal? _iinvmpcost;
		private string _contractcode;
		private string _contractrowno;
		private string _copcode;
		private string _cdescription;
		private bool _btaxcost= false;
		private string _chyordercode;
		private int? _ihyorderdid;
		private decimal? _inattaxprice;
		private decimal? _iinvexchrate;
		private string _opseq;
		private string _cbg_itemcode="";
		private string _cbg_itemname="";
		private string _cbg_caliberkey1="";
		private string _cbg_caliberkeyname1="";
		private string _cbg_caliberkey2="";
		private string _cbg_caliberkeyname2="";
		private string _cbg_caliberkey3="";
		private string _cbg_caliberkeyname3="";
		private string _cbg_calibercode1="";
		private string _cbg_calibername1="";
		private string _cbg_calibercode2="";
		private string _cbg_calibername2="";
		private string _cbg_calibercode3="";
		private string _cbg_calibername3="";
		private int? _ibg_ctrl=0;
		private string _cbg_auditopinion="";
		private string _cconexecid;
		private string _cconrowid;
		private int? _brettax;
		private decimal? _fretquantity;
		private DateTime? _dretdate;
		private DateTime? _dlastretdate;
		private decimal? _fretmoney;
		private decimal? _iorizbjmoney;
		private decimal? _iorinoratezbjmoney;
		private decimal? _izbjmoney;
		private decimal? _inoratezbjmoney;
		private int? _ivouchrowno;
		private string _cpznum;
		private DateTime? _dkeepdate;
		private string _cbg_caliberkey4="";
		private string _cbg_caliberkeyname4="";
		private string _cbg_caliberkey5="";
		private string _cbg_caliberkeyname5="";
		private string _cbg_caliberkey6="";
		private string _cbg_caliberkeyname6="";
		private string _cbg_calibercode4="";
		private string _cbg_calibername4="";
		private string _cbg_calibercode5="";
		private string _cbg_calibername5="";
		private string _cbg_calibercode6="";
		private string _cbg_calibername6="";
		private string _cbmemo;
		private string _cbsysbarcode;
		private int? _bgift=0;
		private string _rowguid;
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
		public long PBVID
		{
			set{ _pbvid=value;}
			get{return _pbvid;}
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
		public bool bExBill
		{
			set{ _bexbill=value;}
			get{return _bexbill;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dInDate
		{
			set{ _dindate=value;}
			get{return _dindate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iPBVQuantity
		{
			set{ _ipbvquantity=value;}
			get{return _ipbvquantity;}
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
		public decimal? iOriCost
		{
			set{ _ioricost=value;}
			get{return _ioricost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOriMoney
		{
			set{ _iorimoney=value;}
			get{return _iorimoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOriTaxPrice
		{
			set{ _ioritaxprice=value;}
			get{return _ioritaxprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOriSum
		{
			set{ _iorisum=value;}
			get{return _iorisum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iCost
		{
			set{ _icost=value;}
			get{return _icost;}
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
		public decimal? iTaxPrice
		{
			set{ _itaxprice=value;}
			get{return _itaxprice;}
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
		public decimal? iExMoney
		{
			set{ _iexmoney=value;}
			get{return _iexmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iLostQuan
		{
			set{ _ilostquan=value;}
			get{return _ilostquan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNLostQuan
		{
			set{ _inlostquan=value;}
			get{return _inlostquan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNLostMoney
		{
			set{ _inlostmoney=value;}
			get{return _inlostmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOriTotal
		{
			set{ _ioritotal=value;}
			get{return _ioritotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTotal
		{
			set{ _itotal=value;}
			get{return _itotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cDebitHead
		{
			set{ _cdebithead=value;}
			get{return _cdebithead;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cTaxHead
		{
			set{ _ctaxhead=value;}
			get{return _ctaxhead;}
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
		public DateTime? dSignDate
		{
			set{ _dsigndate=value;}
			get{return _dsigndate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCorInvCode
		{
			set{ _ccorinvcode=value;}
			get{return _ccorinvcode;}
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
		public int iPOsID
		{
			set{ _iposid=value;}
			get{return _iposid;}
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
		public string cNLostType
		{
			set{ _cnlosttype=value;}
			get{return _cnlosttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? mNLostTax
		{
			set{ _mnlosttax=value;}
			get{return _mnlosttax;}
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
		public DateTime? dSDate
		{
			set{ _dsdate=value;}
			get{return _dsdate;}
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
		public int? cDefine34
		{
			set{ _cdefine34=value;}
			get{return _cdefine34;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cDefine35
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
		public int? iSBsID
		{
			set{ _isbsid=value;}
			get{return _isbsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long RdsId
		{
			set{ _rdsid=value;}
			get{return _rdsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid ContractRowGUID
		{
			set{ _contractrowguid=value;}
			get{return _contractrowguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOriTaxCost
		{
			set{ _ioritaxcost=value;}
			get{return _ioritaxcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpSoType
		{
			set{ _upsotype=value;}
			get{return _upsotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBAccounter
		{
			set{ _cbaccounter=value;}
			get{return _cbaccounter;}
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
		public decimal? iInvMPCost
		{
			set{ _iinvmpcost=value;}
			get{return _iinvmpcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContractCode
		{
			set{ _contractcode=value;}
			get{return _contractcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContractRowNo
		{
			set{ _contractrowno=value;}
			get{return _contractrowno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string copcode
		{
			set{ _copcode=value;}
			get{return _copcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cdescription
		{
			set{ _cdescription=value;}
			get{return _cdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bTaxCost
		{
			set{ _btaxcost=value;}
			get{return _btaxcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string chyordercode
		{
			set{ _chyordercode=value;}
			get{return _chyordercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ihyorderdid
		{
			set{ _ihyorderdid=value;}
			get{return _ihyorderdid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? inattaxprice
		{
			set{ _inattaxprice=value;}
			get{return _inattaxprice;}
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
		public string opseq
		{
			set{ _opseq=value;}
			get{return _opseq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_ItemCode
		{
			set{ _cbg_itemcode=value;}
			get{return _cbg_itemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_ItemName
		{
			set{ _cbg_itemname=value;}
			get{return _cbg_itemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKey1
		{
			set{ _cbg_caliberkey1=value;}
			get{return _cbg_caliberkey1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKeyName1
		{
			set{ _cbg_caliberkeyname1=value;}
			get{return _cbg_caliberkeyname1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKey2
		{
			set{ _cbg_caliberkey2=value;}
			get{return _cbg_caliberkey2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKeyName2
		{
			set{ _cbg_caliberkeyname2=value;}
			get{return _cbg_caliberkeyname2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKey3
		{
			set{ _cbg_caliberkey3=value;}
			get{return _cbg_caliberkey3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKeyName3
		{
			set{ _cbg_caliberkeyname3=value;}
			get{return _cbg_caliberkeyname3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberCode1
		{
			set{ _cbg_calibercode1=value;}
			get{return _cbg_calibercode1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberName1
		{
			set{ _cbg_calibername1=value;}
			get{return _cbg_calibername1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberCode2
		{
			set{ _cbg_calibercode2=value;}
			get{return _cbg_calibercode2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberName2
		{
			set{ _cbg_calibername2=value;}
			get{return _cbg_calibername2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberCode3
		{
			set{ _cbg_calibercode3=value;}
			get{return _cbg_calibercode3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberName3
		{
			set{ _cbg_calibername3=value;}
			get{return _cbg_calibername3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iBG_Ctrl
		{
			set{ _ibg_ctrl=value;}
			get{return _ibg_ctrl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_Auditopinion
		{
			set{ _cbg_auditopinion=value;}
			get{return _cbg_auditopinion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cConExecID
		{
			set{ _cconexecid=value;}
			get{return _cconexecid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cConRowID
		{
			set{ _cconrowid=value;}
			get{return _cconrowid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? brettax
		{
			set{ _brettax=value;}
			get{return _brettax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fretquantity
		{
			set{ _fretquantity=value;}
			get{return _fretquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dretdate
		{
			set{ _dretdate=value;}
			get{return _dretdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dlastretdate
		{
			set{ _dlastretdate=value;}
			get{return _dlastretdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fretmoney
		{
			set{ _fretmoney=value;}
			get{return _fretmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOriZbjMoney
		{
			set{ _iorizbjmoney=value;}
			get{return _iorizbjmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iOriNoRateZbjMoney
		{
			set{ _iorinoratezbjmoney=value;}
			get{return _iorinoratezbjmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iZbjMoney
		{
			set{ _izbjmoney=value;}
			get{return _izbjmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNoRateZbjMoney
		{
			set{ _inoratezbjmoney=value;}
			get{return _inoratezbjmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ivouchrowno
		{
			set{ _ivouchrowno=value;}
			get{return _ivouchrowno;}
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
		public DateTime? dkeepdate
		{
			set{ _dkeepdate=value;}
			get{return _dkeepdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKey4
		{
			set{ _cbg_caliberkey4=value;}
			get{return _cbg_caliberkey4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKeyName4
		{
			set{ _cbg_caliberkeyname4=value;}
			get{return _cbg_caliberkeyname4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKey5
		{
			set{ _cbg_caliberkey5=value;}
			get{return _cbg_caliberkey5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKeyName5
		{
			set{ _cbg_caliberkeyname5=value;}
			get{return _cbg_caliberkeyname5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKey6
		{
			set{ _cbg_caliberkey6=value;}
			get{return _cbg_caliberkey6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberKeyName6
		{
			set{ _cbg_caliberkeyname6=value;}
			get{return _cbg_caliberkeyname6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberCode4
		{
			set{ _cbg_calibercode4=value;}
			get{return _cbg_calibercode4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberName4
		{
			set{ _cbg_calibername4=value;}
			get{return _cbg_calibername4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberCode5
		{
			set{ _cbg_calibercode5=value;}
			get{return _cbg_calibercode5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberName5
		{
			set{ _cbg_calibername5=value;}
			get{return _cbg_calibername5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberCode6
		{
			set{ _cbg_calibercode6=value;}
			get{return _cbg_calibercode6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBG_CaliberName6
		{
			set{ _cbg_calibername6=value;}
			get{return _cbg_calibername6;}
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
		public string cbsysbarcode
		{
			set{ _cbsysbarcode=value;}
			get{return _cbsysbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bgift
		{
			set{ _bgift=value;}
			get{return _bgift;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rowguid
		{
			set{ _rowguid=value;}
			get{return _rowguid;}
		}
		#endregion Model

	}
}

