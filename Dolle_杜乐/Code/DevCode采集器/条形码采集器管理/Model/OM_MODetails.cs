using System;
namespace BarCode.Model
{
    /// <summary>
    /// OM_MODetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OM_MODetails
    {
        public OM_MODetails()
        { }
        #region Model
        private long _modetailsid;
        private long _moid;
        private string _cinvcode;
        private decimal? _iquantity;
        private decimal? _inum;
        private decimal? _iquotedprice;
        private decimal? _iunitprice;
        private decimal? _imoney;
        private decimal? _itax;
        private decimal? _isum;
        private decimal? _idiscount;
        private decimal? _inatunitprice;
        private decimal? _inatmoney;
        private decimal? _inattax;
        private decimal? _inatsum;
        private decimal? _inatdiscount;
        private DateTime? _dstartdate;
        private DateTime? _darrivedate;
        private decimal? _ireceivedqty;
        private decimal? _ireceivednum;
        private decimal? _ireceivedmoney;
        private decimal? _iinvqty;
        private decimal? _iinvnum;
        private decimal? _iinvmoney;
        private string _cfree1;
        private string _cfree2;
        private decimal? _inatinvmoney;
        private decimal? _ioritotal;
        private decimal? _itotal;
        private decimal? _ipertaxrate;
        private string _cdefine22;
        private string _cdefine23;
        private string _cdefine24;
        private string _cdefine25;
        private decimal? _cdefine26 = 0M;
        private decimal? _cdefine27 = 0M;
        private long? _iflag;
        private string _citemcode;
        private string _citem_class;
        private string _citemname;
        private string _cfree3;
        private string _cfree4;
        private string _cfree5;
        private string _cfree6;
        private string _cfree7;
        private string _cfree8;
        private string _cfree9;
        private string _cfree10;
        private long? _bgsp = 0;
        private string _cunitid;
        private decimal? _itaxprice;
        private decimal? _iarrqty;
        private decimal? _iarrnum;
        private decimal? _iarrmoney;
        private decimal? _inatarrmoney;
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
        private bool _btaxcost = false;
        private string _csource;
        private string _cbcloser;
        private long? _sotype;
        private string _sodid;
        private long? _bomid;
        private long _mrpdetailsid;
        private decimal? _fparentscrp;
        private decimal? _imaterialsendqty;
        private decimal? _tbaseqtyd;
        private DateTime _dufts;
        private long? _ivtids;
        private string _cupsocode;
        private long? _cupsoids;
        private long? _isosid;
        private string _cdemandcode;
        private string _cdetailsdemandmemo;
        private DateTime? _dbclosedate;
        private DateTime? _dbclosetime;
        private long? _ivouchrowno;
        private decimal? _freceivedqty;
        private decimal? _freceivednum;
        private string _cbmemo;
        private long? _icusbomid;
        private string _cbsysbarcode;
        private string _csocode;
        private long? _irowno;
        private long? _bomtype;
        private string _isourcemocode;
        private long? _isourcemodetailsid;
        private decimal? _imrpqty;
        private decimal? _freworkquantity;
        private decimal? _freworknum;
        private long? _iproducttype;
        private long? _imainmodetailsid;
        private long? _imainmomaterialsid;
        private string _cmaininvcode;
        private long? _isoordertype;
        private long? _iorderdid;
        private string _csoordercode;
        private long? _iorderseq;
        private string _cplanlotnumber;
        /// <summary>
        /// 
        /// </summary>
        public long MODetailsID
        {
            set { _modetailsid = value; }
            get { return _modetailsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long MOID
        {
            set { _moid = value; }
            get { return _moid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvCode
        {
            set { _cinvcode = value; }
            get { return _cinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iQuantity
        {
            set { _iquantity = value; }
            get { return _iquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNum
        {
            set { _inum = value; }
            get { return _inum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iQuotedPrice
        {
            set { _iquotedprice = value; }
            get { return _iquotedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iUnitPrice
        {
            set { _iunitprice = value; }
            get { return _iunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iMoney
        {
            set { _imoney = value; }
            get { return _imoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTax
        {
            set { _itax = value; }
            get { return _itax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSum
        {
            set { _isum = value; }
            get { return _isum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iDisCount
        {
            set { _idiscount = value; }
            get { return _idiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatUnitPrice
        {
            set { _inatunitprice = value; }
            get { return _inatunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatMoney
        {
            set { _inatmoney = value; }
            get { return _inatmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatTax
        {
            set { _inattax = value; }
            get { return _inattax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatSum
        {
            set { _inatsum = value; }
            get { return _inatsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatDisCount
        {
            set { _inatdiscount = value; }
            get { return _inatdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dStartDate
        {
            set { _dstartdate = value; }
            get { return _dstartdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dArriveDate
        {
            set { _darrivedate = value; }
            get { return _darrivedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iReceivedQTY
        {
            set { _ireceivedqty = value; }
            get { return _ireceivedqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iReceivedNum
        {
            set { _ireceivednum = value; }
            get { return _ireceivednum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iReceivedMoney
        {
            set { _ireceivedmoney = value; }
            get { return _ireceivedmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iInvQTY
        {
            set { _iinvqty = value; }
            get { return _iinvqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iInvNum
        {
            set { _iinvnum = value; }
            get { return _iinvnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iInvMoney
        {
            set { _iinvmoney = value; }
            get { return _iinvmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree1
        {
            set { _cfree1 = value; }
            get { return _cfree1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree2
        {
            set { _cfree2 = value; }
            get { return _cfree2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatInvMoney
        {
            set { _inatinvmoney = value; }
            get { return _inatinvmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iOriTotal
        {
            set { _ioritotal = value; }
            get { return _ioritotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTotal
        {
            set { _itotal = value; }
            get { return _itotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPerTaxRate
        {
            set { _ipertaxrate = value; }
            get { return _ipertaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine22
        {
            set { _cdefine22 = value; }
            get { return _cdefine22; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine23
        {
            set { _cdefine23 = value; }
            get { return _cdefine23; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine24
        {
            set { _cdefine24 = value; }
            get { return _cdefine24; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine25
        {
            set { _cdefine25 = value; }
            get { return _cdefine25; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine26
        {
            set { _cdefine26 = value; }
            get { return _cdefine26; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine27
        {
            set { _cdefine27 = value; }
            get { return _cdefine27; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iflag
        {
            set { _iflag = value; }
            get { return _iflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItemCode
        {
            set { _citemcode = value; }
            get { return _citemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItem_class
        {
            set { _citem_class = value; }
            get { return _citem_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItemName
        {
            set { _citemname = value; }
            get { return _citemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree3
        {
            set { _cfree3 = value; }
            get { return _cfree3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree4
        {
            set { _cfree4 = value; }
            get { return _cfree4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree5
        {
            set { _cfree5 = value; }
            get { return _cfree5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree6
        {
            set { _cfree6 = value; }
            get { return _cfree6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree7
        {
            set { _cfree7 = value; }
            get { return _cfree7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree8
        {
            set { _cfree8 = value; }
            get { return _cfree8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree9
        {
            set { _cfree9 = value; }
            get { return _cfree9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree10
        {
            set { _cfree10 = value; }
            get { return _cfree10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? bGsp
        {
            set { _bgsp = value; }
            get { return _bgsp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cUnitID
        {
            set { _cunitid = value; }
            get { return _cunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxPrice
        {
            set { _itaxprice = value; }
            get { return _itaxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iArrQTY
        {
            set { _iarrqty = value; }
            get { return _iarrqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iArrNum
        {
            set { _iarrnum = value; }
            get { return _iarrnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iArrMoney
        {
            set { _iarrmoney = value; }
            get { return _iarrmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatArrMoney
        {
            set { _inatarrmoney = value; }
            get { return _inatarrmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine28
        {
            set { _cdefine28 = value; }
            get { return _cdefine28; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine29
        {
            set { _cdefine29 = value; }
            get { return _cdefine29; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine30
        {
            set { _cdefine30 = value; }
            get { return _cdefine30; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine31
        {
            set { _cdefine31 = value; }
            get { return _cdefine31; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine32
        {
            set { _cdefine32 = value; }
            get { return _cdefine32; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine33
        {
            set { _cdefine33 = value; }
            get { return _cdefine33; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cDefine34
        {
            set { _cdefine34 = value; }
            get { return _cdefine34; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cDefine35
        {
            set { _cdefine35 = value; }
            get { return _cdefine35; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine36
        {
            set { _cdefine36 = value; }
            get { return _cdefine36; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine37
        {
            set { _cdefine37 = value; }
            get { return _cdefine37; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bTaxCost
        {
            set { _btaxcost = value; }
            get { return _btaxcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSource
        {
            set { _csource = value; }
            get { return _csource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbCloser
        {
            set { _cbcloser = value; }
            get { return _cbcloser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SOType
        {
            set { _sotype = value; }
            get { return _sotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SODID
        {
            set { _sodid = value; }
            get { return _sodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? BomID
        {
            set { _bomid = value; }
            get { return _bomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long mrpdetailsID
        {
            set { _mrpdetailsid = value; }
            get { return _mrpdetailsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fParentScrp
        {
            set { _fparentscrp = value; }
            get { return _fparentscrp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iMaterialSendQty
        {
            set { _imaterialsendqty = value; }
            get { return _imaterialsendqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Tbaseqtyd
        {
            set { _tbaseqtyd = value; }
            get { return _tbaseqtyd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dUfts
        {
            set { _dufts = value; }
            get { return _dufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iVTids
        {
            set { _ivtids = value; }
            get { return _ivtids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cupsocode
        {
            set { _cupsocode = value; }
            get { return _cupsocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cupsoids
        {
            set { _cupsoids = value; }
            get { return _cupsoids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? isosid
        {
            set { _isosid = value; }
            get { return _isosid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdemandcode
        {
            set { _cdemandcode = value; }
            get { return _cdemandcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdetailsdemandmemo
        {
            set { _cdetailsdemandmemo = value; }
            get { return _cdetailsdemandmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dbCloseDate
        {
            set { _dbclosedate = value; }
            get { return _dbclosedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dbCloseTime
        {
            set { _dbclosetime = value; }
            get { return _dbclosetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iVouchRowNo
        {
            set { _ivouchrowno = value; }
            get { return _ivouchrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freceivedqty
        {
            set { _freceivedqty = value; }
            get { return _freceivedqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freceivednum
        {
            set { _freceivednum = value; }
            get { return _freceivednum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbMemo
        {
            set { _cbmemo = value; }
            get { return _cbmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iCusBomID
        {
            set { _icusbomid = value; }
            get { return _icusbomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbsysbarcode
        {
            set { _cbsysbarcode = value; }
            get { return _cbsysbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csocode
        {
            set { _csocode = value; }
            get { return _csocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? irowno
        {
            set { _irowno = value; }
            get { return _irowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? BomType
        {
            set { _bomtype = value; }
            get { return _bomtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iSourceMOCode
        {
            set { _isourcemocode = value; }
            get { return _isourcemocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iSourceMODetailsID
        {
            set { _isourcemodetailsid = value; }
            get { return _isourcemodetailsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? imrpqty
        {
            set { _imrpqty = value; }
            get { return _imrpqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freworkquantity
        {
            set { _freworkquantity = value; }
            get { return _freworkquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freworknum
        {
            set { _freworknum = value; }
            get { return _freworknum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iProductType
        {
            set { _iproducttype = value; }
            get { return _iproducttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iMainMoDetailsID
        {
            set { _imainmodetailsid = value; }
            get { return _imainmodetailsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iMainMoMaterialsID
        {
            set { _imainmomaterialsid = value; }
            get { return _imainmomaterialsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMainInvCode
        {
            set { _cmaininvcode = value; }
            get { return _cmaininvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? isoordertype
        {
            set { _isoordertype = value; }
            get { return _isoordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iorderdid
        {
            set { _iorderdid = value; }
            get { return _iorderdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csoordercode
        {
            set { _csoordercode = value; }
            get { return _csoordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iorderseq
        {
            set { _iorderseq = value; }
            get { return _iorderseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPlanLotNumber
        {
            set { _cplanlotnumber = value; }
            get { return _cplanlotnumber; }
        }
        #endregion Model

    }
}

