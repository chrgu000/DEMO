using System;
namespace Model
{
    /// <summary>
    /// rdrecords01:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RdRecords
    {
        public RdRecords()
        { }
        #region Model
        private long _autoid = 0;
        private long _id = 0;
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
		private int _iflag=0;
		private DateTime? _dsdate;
		private decimal? _itax=0;
		private decimal? _isquantity=0;
		private decimal? _isnum=0;
		private decimal? _imoney=0;
		private decimal? _isoutquantity=0;
		private decimal? _isoutnum=0;
		private decimal? _ifnum=0;
		private decimal? _ifquantity=0;
		private DateTime? _dvdate;
		private int? _itrids=null;
		private string _cposition;
		private string _cdefine22;
		private string _cdefine23;
		private string _cdefine24;
		private string _cdefine25;
		private decimal? _cdefine26;
		private decimal? _cdefine27;
		private string _citem_class;
		private string _citemcode;
		private int? _iposid=null;
		private decimal? _facost=0;
		private int _idlsid=0;
		private int _isbsid=0;
		private decimal? _isendquantity=0M;
		private decimal? _isendnum=0M;
		private string _cname;
		private string _citemcname;
		private int? _iensid;
		private string _cfree3;
		private string _cfree4;
		private string _cfree5;
		private string _cfree6;
		private string _cfree7;
		private string _cfree8;
		private string _cfree9;
		private string _cfree10;
		private string _cbarcode;
		private decimal? _inquantity;
		private decimal? _innum;
		private string _cassunit;
		private DateTime? _dmadedate;
		private int? _imassdate;
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
		private int? _impoids;
		private int? _icheckids;
		private string _cbvencode;
		private string _cinvouchcode;
		private bool _bgsp;
		private string _cgspstate;
		private int? _iarrsid;
		private string _ccheckcode;
		private int? _icheckidbaks;
		private string _crejectcode;
		private int? _irejectids;
		private string _ccheckpersoncode;
		private DateTime? _dcheckdate;
		private decimal? _itookquantity;
		private decimal? _iinvalidquantity;
		private int _iommpoids;
		private decimal? _ipbvquantity;
		private decimal? _ipbvyquantity;
		private int? _ibalance;
		private decimal? _ihxquantity;
		private string _ccaitemcode;
		private string _ccbgjdxcode;
		private int? _bfilled;
		private int? _iarrptrintype;
		private int? _ichkautoid;
		private int? _irejid;
		private string _crejtext;
		private decimal? _itaxcost;
		private decimal? _itaxprice;
		private decimal? _itaxrate;
		private decimal? _isum;
		private decimal? _iataxcost;
		private decimal? _iataxprice;
		private decimal? _iataxrate;
		private decimal? _iasum;
		private decimal? _makeprice;
		private decimal? _makemny;
		private decimal? _hadbalancequantity;
		private decimal? _hadbalancemny;
		private decimal? _orgmakeprice;
		private string _cbomsocode;
		private string _csocode;
		private string _ccbgjdxname;
		private decimal? _taxmakeprice;
		private decimal? _imaketaxprice;
		private decimal? _imaketaxrate;
		private decimal? _taxmakemny;
		private int? _sosid;
		private string _yccode;
		private int? _ycsid;
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
		public int iFlag
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
		public int? iTrIds
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
		public int? iPOsID
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
		public int iDLsID
		{
			set{ _idlsid=value;}
			get{return _idlsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iSBsID
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
		public int? iEnsID
		{
			set{ _iensid=value;}
			get{return _iensid;}
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
		public string cBarCode
		{
			set{ _cbarcode=value;}
			get{return _cbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNQuantity
		{
			set{ _inquantity=value;}
			get{return _inquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iNNum
		{
			set{ _innum=value;}
			get{return _innum;}
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
		public DateTime? dMadeDate
		{
			set{ _dmadedate=value;}
			get{return _dmadedate;}
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
		public int? iMPoIds
		{
			set{ _impoids=value;}
			get{return _impoids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iCheckIds
		{
			set{ _icheckids=value;}
			get{return _icheckids;}
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
		public bool bGsp
		{
			set{ _bgsp=value;}
			get{return _bgsp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cGspState
		{
			set{ _cgspstate=value;}
			get{return _cgspstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iArrsId
		{
			set{ _iarrsid=value;}
			get{return _iarrsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCheckCode
		{
			set{ _ccheckcode=value;}
			get{return _ccheckcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iCheckIdBaks
		{
			set{ _icheckidbaks=value;}
			get{return _icheckidbaks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cRejectCode
		{
			set{ _crejectcode=value;}
			get{return _crejectcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iRejectIds
		{
			set{ _irejectids=value;}
			get{return _irejectids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCheckPersonCode
		{
			set{ _ccheckpersoncode=value;}
			get{return _ccheckpersoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dCheckDate
		{
			set{ _dcheckdate=value;}
			get{return _dcheckdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTookQuantity
		{
			set{ _itookquantity=value;}
			get{return _itookquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iInvalidQuantity
		{
			set{ _iinvalidquantity=value;}
			get{return _iinvalidquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iOMMPoIds
		{
			set{ _iommpoids=value;}
			get{return _iommpoids;}
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
		public decimal? iPBVyQuantity
		{
			set{ _ipbvyquantity=value;}
			get{return _ipbvyquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iBalance
		{
			set{ _ibalance=value;}
			get{return _ibalance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iHXQuantity
		{
			set{ _ihxquantity=value;}
			get{return _ihxquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCAItemCode
		{
			set{ _ccaitemcode=value;}
			get{return _ccaitemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cCBGJDXCode
		{
			set{ _ccbgjdxcode=value;}
			get{return _ccbgjdxcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? bfilled
		{
			set{ _bfilled=value;}
			get{return _bfilled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iarrptrintype
		{
			set{ _iarrptrintype=value;}
			get{return _iarrptrintype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ichkautoid
		{
			set{ _ichkautoid=value;}
			get{return _ichkautoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? irejid
		{
			set{ _irejid=value;}
			get{return _irejid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string crejtext
		{
			set{ _crejtext=value;}
			get{return _crejtext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iTaxCost
		{
			set{ _itaxcost=value;}
			get{return _itaxcost;}
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
		public decimal? iSum
		{
			set{ _isum=value;}
			get{return _isum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iATaxCost
		{
			set{ _iataxcost=value;}
			get{return _iataxcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iATaxPrice
		{
			set{ _iataxprice=value;}
			get{return _iataxprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iATaxRate
		{
			set{ _iataxrate=value;}
			get{return _iataxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iASum
		{
			set{ _iasum=value;}
			get{return _iasum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MakePrice
		{
			set{ _makeprice=value;}
			get{return _makeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MakeMny
		{
			set{ _makemny=value;}
			get{return _makemny;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? HadBalanceQuantity
		{
			set{ _hadbalancequantity=value;}
			get{return _hadbalancequantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? HadBalanceMny
		{
			set{ _hadbalancemny=value;}
			get{return _hadbalancemny;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OrgMakePrice
		{
			set{ _orgmakeprice=value;}
			get{return _orgmakeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cBOMSoCode
		{
			set{ _cbomsocode=value;}
			get{return _cbomsocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string csocode
		{
			set{ _csocode=value;}
			get{return _csocode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ccbgjdxname
		{
			set{ _ccbgjdxname=value;}
			get{return _ccbgjdxname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TaxMakePrice
		{
			set{ _taxmakeprice=value;}
			get{return _taxmakeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iMakeTaxPrice
		{
			set{ _imaketaxprice=value;}
			get{return _imaketaxprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? iMakeTaxRate
		{
			set{ _imaketaxrate=value;}
			get{return _imaketaxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TaxMakeMny
		{
			set{ _taxmakemny=value;}
			get{return _taxmakemny;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sosid
		{
			set{ _sosid=value;}
			get{return _sosid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string YCcode
		{
			set{ _yccode=value;}
			get{return _yccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? YCsid
		{
			set{ _ycsid=value;}
			get{return _ycsid;}
		}
        #endregion Model

    }
}

