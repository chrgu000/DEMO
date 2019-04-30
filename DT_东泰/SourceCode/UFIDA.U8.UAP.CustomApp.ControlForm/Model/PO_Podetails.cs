using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// PO_Podetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PO_Podetails
    {
        public PO_Podetails()
        { }
        #region Model
        private long _id;
        private string _cpoid;
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
        private DateTime? _darrivedate;
        private decimal? _ireceivedqty;
        private decimal _ireceivednum;
        private decimal? _ireceivedmoney;
        private decimal? _iinvqty;
        private decimal _iinvnum;
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
        private long _ppcids;
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
        private long _poid;
        private string _cunitid;
        private decimal? _itaxprice;
        private decimal? _iarrqty;
        private decimal? _iarrnum;
        private decimal? _iarrmoney;
        private decimal? _inatarrmoney;
        private long? _iappids;
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
        private long _isosid;
        private bool _btaxcost = false;
        private string _csource;
        private string _cbcloser;
        private long? _ippartid;
        private decimal? _ipquantity;
        private long? _iptoseq;
        private long? _sotype;
        private string _sodid;
        private Guid _contractrowguid;
        private string _cupsocode;
        private decimal? _iinvmpcost;
        private string _contractcode;
        private string _contractrowno;
        private decimal? _fpovalidquantity;
        private decimal? _fpovalidnum;
        private decimal? _fpoarrquantity;
        private decimal? _fpoarrnum;
        private decimal? _fporetquantity;
        private decimal? _fporetnum;
        private decimal? _fporefusequantity;
        private decimal? _fporefusenum;
        private DateTime _dufts;
        private long? _iorderdid;
        private long? _iordertype;
        private string _csoordercode;
        private long? _iorderseq;
        private DateTime? _cbclosetime;
        private DateTime? _cbclosedate;
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
        private decimal? _fexquantity;
        private decimal? _fexnum;
        private long? _ivouchrowno;
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
        private decimal? _freceivedqty;
        private decimal? _freceivednum;
        private string _cxjspdids;
        private string _cbmemo;
        private string _cbsysbarcode;
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
        public string cPOID
        {
            set { _cpoid = value; }
            get { return _cpoid; }
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
        public decimal iReceivedNum
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
        public decimal iInvNum
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
        public long PPCIds
        {
            set { _ppcids = value; }
            get { return _ppcids; }
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
        public long POID
        {
            set { _poid = value; }
            get { return _poid; }
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
        public long? iAppIds
        {
            set { _iappids = value; }
            get { return _iappids; }
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
        public long iSOsID
        {
            set { _isosid = value; }
            get { return _isosid; }
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
        public long? SoType
        {
            set { _sotype = value; }
            get { return _sotype; }
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
        public Guid ContractRowGUID
        {
            set { _contractrowguid = value; }
            get { return _contractrowguid; }
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
        public decimal? iInvMPCost
        {
            set { _iinvmpcost = value; }
            get { return _iinvmpcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContractCode
        {
            set { _contractcode = value; }
            get { return _contractcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContractRowNo
        {
            set { _contractrowno = value; }
            get { return _contractrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoValidQuantity
        {
            set { _fpovalidquantity = value; }
            get { return _fpovalidquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoValidNum
        {
            set { _fpovalidnum = value; }
            get { return _fpovalidnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoArrQuantity
        {
            set { _fpoarrquantity = value; }
            get { return _fpoarrquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoArrNum
        {
            set { _fpoarrnum = value; }
            get { return _fpoarrnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoRetQuantity
        {
            set { _fporetquantity = value; }
            get { return _fporetquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoRetNum
        {
            set { _fporetnum = value; }
            get { return _fporetnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoRefuseQuantity
        {
            set { _fporefusequantity = value; }
            get { return _fporefusequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fPoRefuseNum
        {
            set { _fporefusenum = value; }
            get { return _fporefusenum; }
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
        public DateTime? cbCloseTime
        {
            set { _cbclosetime = value; }
            get { return _cbclosetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cbCloseDate
        {
            set { _cbclosedate = value; }
            get { return _cbclosedate; }
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
        public decimal? fexquantity
        {
            set { _fexquantity = value; }
            get { return _fexquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fexnum
        {
            set { _fexnum = value; }
            get { return _fexnum; }
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
        public string cxjspdids
        {
            set { _cxjspdids = value; }
            get { return _cxjspdids; }
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
        public string planlotnumber
        {
            set { _planlotnumber = value; }
            get { return _planlotnumber; }
        }
        #endregion Model

    }
}

