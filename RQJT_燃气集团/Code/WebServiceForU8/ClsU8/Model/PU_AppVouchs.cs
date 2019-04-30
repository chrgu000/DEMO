using System;
namespace ClsU8.Model
{
    /// <summary>
    /// PU_AppVouchs:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PU_AppVouchs
    {
        public PU_AppVouchs()
        { }
        #region Model
        private long _id;
        private long _autoid;
        private string _cvencode;
        private string _cinvcode;
        private decimal _fquantity;
        private decimal? _funitprice;
        private decimal? _ipertaxrate;
        private decimal? _ftaxprice;
        private decimal? _fmoney;
        private DateTime? _drequirdate;
        private DateTime? _darrivedate;
        private decimal? _ireceivedqty = 0M;
        private string _cfree1;
        private string _cfree2;
        private string _cfree3;
        private string _cfree4;
        private string _cfree5;
        private string _cfree6;
        private string _cfree7;
        private string _cfree8;
        private string _cfree9;
        private string _cfree10;
        private string _cdefine22;
        private string _cdefine23;
        private string _cdefine24;
        private string _cdefine25;
        private decimal? _cdefine26 = 0M;
        private decimal? _cdefine27 = 0M;
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
        private string _citem_class;
        private string _citemcode;
        private string _citemname;
        private bool _btaxcost = false;
        private long? _ippartid;
        private decimal? _ipquantity;
        private long? _iptoseq;
        private string _csource;
        private string _sodid;
        private long? _sotype;
        private long _imrpsid;
        private long? _iropsid;
        private string _cbcloser;
        private decimal? _fnum;
        private string _cunitid;
        private decimal? _ireceivednum;
        private string _cpersoncodeexec;
        private string _cdepcodeexec;
        private decimal? _iinvmpcost;
        private DateTime _dufts;
        private string _cexch_name = "人民币";
        private decimal? _iexchrate;
        private decimal? _ioricost;
        private decimal? _ioritaxcost;
        private decimal? _iorimoney;
        private decimal? _ioritaxprice;
        private decimal? _iorisum;
        private decimal? _imoney;
        private decimal? _itaxprice;
        private string _cdemandcode;
        private string _cdetailsdemandmemo;
        private string _cbg_itemcode = "";
        private string _cbg_itemname = "";
        private string _cbg_caliberkey1 = "";
        private string _cbg_caliberkeyname1 = "";
        private string _cbg_caliberkey2 = "";
        private string _cbg_caliberkeyname2 = "";
        private string _cbg_caliberkey3 = "";
        private string _cbg_caliberkeyname3 = "";
        private string _cbg_calibercode1 = "";
        private string _cbg_calibername1 = "";
        private string _cbg_calibercode2 = "";
        private string _cbg_calibername2 = "";
        private string _cbg_calibercode3 = "";
        private string _cbg_calibername3 = "";
        private long? _ibg_ctrl = 0;
        private string _cbg_auditopinion = "";
        private string _mocode;
        private long? _ivouchrowno;
        private decimal? _fconquantity;
        private decimal? _fconmoney;
        private decimal? _fconnum;
        private decimal? _fconorimoney;
        private string _cbg_caliberkey4 = "";
        private string _cbg_caliberkeyname4 = "";
        private string _cbg_caliberkey5 = "";
        private string _cbg_caliberkeyname5 = "";
        private string _cbg_caliberkey6 = "";
        private string _cbg_caliberkeyname6 = "";
        private string _cbg_calibercode4 = "";
        private string _cbg_calibername4 = "";
        private string _cbg_calibercode5 = "";
        private string _cbg_calibername5 = "";
        private string _cbg_calibercode6 = "";
        private string _cbg_calibername6 = "";
        private string _csocode;
        private long? _irowno;
        private decimal? _isumxjqty;
        private decimal? _isumxjcgqty;
        private DateTime? _dbclosedate;
        private DateTime? _dbclosetime;
        private string _cbmemo;
        private string _cbsysbarcode;
        private long? _isosid;
        private long? _iorderdid;
        private long? _iordertype;
        private string _csoordercode;
        private long? _iorderseq;
        private string _planlotnumber;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long AutoID
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVenCode
        {
            set { _cvencode = value; }
            get { return _cvencode; }
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
        public decimal fQuantity
        {
            set { _fquantity = value; }
            get { return _fquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fUnitPrice
        {
            set { _funitprice = value; }
            get { return _funitprice; }
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
        public decimal? fTaxPrice
        {
            set { _ftaxprice = value; }
            get { return _ftaxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fMoney
        {
            set { _fmoney = value; }
            get { return _fmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dRequirDate
        {
            set { _drequirdate = value; }
            get { return _drequirdate; }
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
        public string cItem_class
        {
            set { _citem_class = value; }
            get { return _citem_class; }
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
        public string CItemName
        {
            set { _citemname = value; }
            get { return _citemname; }
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
        public long? iPPartId
        {
            set { _ippartid = value; }
            get { return _ippartid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPQuantity
        {
            set { _ipquantity = value; }
            get { return _ipquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iPTOSeq
        {
            set { _iptoseq = value; }
            get { return _iptoseq; }
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
        public string SoDId
        {
            set { _sodid = value; }
            get { return _sodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SoType
        {
            set { _sotype = value; }
            get { return _sotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iMrpsid
        {
            set { _imrpsid = value; }
            get { return _imrpsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iRopsid
        {
            set { _iropsid = value; }
            get { return _iropsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbcloser
        {
            set { _cbcloser = value; }
            get { return _cbcloser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fNum
        {
            set { _fnum = value; }
            get { return _fnum; }
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
        public decimal? iReceivedNum
        {
            set { _ireceivednum = value; }
            get { return _ireceivednum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPersonCodeExec
        {
            set { _cpersoncodeexec = value; }
            get { return _cpersoncodeexec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDepCodeExec
        {
            set { _cdepcodeexec = value; }
            get { return _cdepcodeexec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iInvMPCost
        {
            set { _iinvmpcost = value; }
            get { return _iinvmpcost; }
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
        public string cexch_name
        {
            set { _cexch_name = value; }
            get { return _cexch_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iExchRate
        {
            set { _iexchrate = value; }
            get { return _iexchrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iOriCost
        {
            set { _ioricost = value; }
            get { return _ioricost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iOriTaxCost
        {
            set { _ioritaxcost = value; }
            get { return _ioritaxcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iOriMoney
        {
            set { _iorimoney = value; }
            get { return _iorimoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iOriTaxPrice
        {
            set { _ioritaxprice = value; }
            get { return _ioritaxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iOriSum
        {
            set { _iorisum = value; }
            get { return _iorisum; }
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
        public decimal? iTaxPrice
        {
            set { _itaxprice = value; }
            get { return _itaxprice; }
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
        public string cBG_ItemCode
        {
            set { _cbg_itemcode = value; }
            get { return _cbg_itemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_ItemName
        {
            set { _cbg_itemname = value; }
            get { return _cbg_itemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKey1
        {
            set { _cbg_caliberkey1 = value; }
            get { return _cbg_caliberkey1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKeyName1
        {
            set { _cbg_caliberkeyname1 = value; }
            get { return _cbg_caliberkeyname1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKey2
        {
            set { _cbg_caliberkey2 = value; }
            get { return _cbg_caliberkey2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKeyName2
        {
            set { _cbg_caliberkeyname2 = value; }
            get { return _cbg_caliberkeyname2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKey3
        {
            set { _cbg_caliberkey3 = value; }
            get { return _cbg_caliberkey3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKeyName3
        {
            set { _cbg_caliberkeyname3 = value; }
            get { return _cbg_caliberkeyname3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberCode1
        {
            set { _cbg_calibercode1 = value; }
            get { return _cbg_calibercode1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberName1
        {
            set { _cbg_calibername1 = value; }
            get { return _cbg_calibername1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberCode2
        {
            set { _cbg_calibercode2 = value; }
            get { return _cbg_calibercode2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberName2
        {
            set { _cbg_calibername2 = value; }
            get { return _cbg_calibername2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberCode3
        {
            set { _cbg_calibercode3 = value; }
            get { return _cbg_calibercode3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberName3
        {
            set { _cbg_calibername3 = value; }
            get { return _cbg_calibername3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iBG_Ctrl
        {
            set { _ibg_ctrl = value; }
            get { return _ibg_ctrl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_Auditopinion
        {
            set { _cbg_auditopinion = value; }
            get { return _cbg_auditopinion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mocode
        {
            set { _mocode = value; }
            get { return _mocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ivouchrowno
        {
            set { _ivouchrowno = value; }
            get { return _ivouchrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fconquantity
        {
            set { _fconquantity = value; }
            get { return _fconquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fconmoney
        {
            set { _fconmoney = value; }
            get { return _fconmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fconnum
        {
            set { _fconnum = value; }
            get { return _fconnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fconorimoney
        {
            set { _fconorimoney = value; }
            get { return _fconorimoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKey4
        {
            set { _cbg_caliberkey4 = value; }
            get { return _cbg_caliberkey4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKeyName4
        {
            set { _cbg_caliberkeyname4 = value; }
            get { return _cbg_caliberkeyname4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKey5
        {
            set { _cbg_caliberkey5 = value; }
            get { return _cbg_caliberkey5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKeyName5
        {
            set { _cbg_caliberkeyname5 = value; }
            get { return _cbg_caliberkeyname5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKey6
        {
            set { _cbg_caliberkey6 = value; }
            get { return _cbg_caliberkey6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberKeyName6
        {
            set { _cbg_caliberkeyname6 = value; }
            get { return _cbg_caliberkeyname6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberCode4
        {
            set { _cbg_calibercode4 = value; }
            get { return _cbg_calibercode4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberName4
        {
            set { _cbg_calibername4 = value; }
            get { return _cbg_calibername4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberCode5
        {
            set { _cbg_calibercode5 = value; }
            get { return _cbg_calibercode5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberName5
        {
            set { _cbg_calibername5 = value; }
            get { return _cbg_calibername5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberCode6
        {
            set { _cbg_calibercode6 = value; }
            get { return _cbg_calibercode6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_CaliberName6
        {
            set { _cbg_calibername6 = value; }
            get { return _cbg_calibername6; }
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
        public decimal? iSumXJqty
        {
            set { _isumxjqty = value; }
            get { return _isumxjqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSumXJCGqty
        {
            set { _isumxjcgqty = value; }
            get { return _isumxjcgqty; }
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
        public string cbMemo
        {
            set { _cbmemo = value; }
            get { return _cbmemo; }
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
        public long? isosid
        {
            set { _isosid = value; }
            get { return _isosid; }
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
        public long? iordertype
        {
            set { _iordertype = value; }
            get { return _iordertype; }
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
        public string planlotnumber
        {
            set { _planlotnumber = value; }
            get { return _planlotnumber; }
        }
        #endregion Model

    }
}

