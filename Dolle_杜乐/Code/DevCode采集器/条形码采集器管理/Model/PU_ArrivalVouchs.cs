using System;
namespace BarCode.Model
{
    /// <summary>
    /// PU_ArrivalVouchs:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PU_ArrivalVouchs
    {
        public PU_ArrivalVouchs()
        { }
        #region Model
        private int _autoid;
        private int _id;
        private string _cwhcode;
        private string _cinvcode;
        private decimal? _inum;
        private decimal _iquantity;
        private decimal? _ioricost;
        private decimal? _ioritaxcost;
        private decimal? _iorimoney;
        private decimal? _ioritaxprice;
        private decimal? _iorisum;
        private decimal? _icost;
        private decimal? _imoney;
        private decimal? _itaxprice;
        private decimal? _isum;
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
        private decimal _itaxrate = 0M;
        private string _cdefine22;
        private string _cdefine23;
        private string _cdefine24;
        private string _cdefine25;
        private decimal? _cdefine26;
        private decimal? _cdefine27;
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
        private string _citem_class;
        private string _citemcode;
        private int _iposid;
        private string _citemname;
        private string _cunitid;
        private decimal _fvalidinquan = 0M;
        private decimal? _fkpquantity = 0M;
        private decimal? _frealquantity = 0M;
        private decimal? _fvalidquantity = 0M;
        private decimal? _finvalidquantity = 0M;
        private string _ccloser;
        private int? _icorid;
        private decimal? _fretquantity = 0M;
        private decimal? _finvalidinquan = 0M;
        private int? _bgsp = 0;
        private string _cbatch;
        private DateTime? _dvdate;
        private DateTime? _dpdate;
        private decimal? _frefusequantity = 0M;
        private string _cgspstate;
        private decimal? _fvalidnum;
        private decimal _fvalidinnum;
        private decimal? _finvalidnum;
        private decimal? _frealnum;
        private bool _btaxcost = false;
        private int? _binspect;
        private decimal? _frefusenum;
        private int? _ippartid;
        private decimal? _ipquantity;
        private int? _iptoseq;
        private string _sodid;
        private int _sotype;
        private Guid _contractrowguid;
        private int? _imassdate;
        private int? _cmassunit;
        private int? _bexigency = 0;
        private string _cbcloser;
        private decimal? _fsumrefusequantity;
        private decimal? _fsumrefusenum;
        private decimal? _fretnum;
        private decimal? _fdtquantity;
        private decimal? _finvalidinnum;
        private decimal? _fdegradequantity;
        private decimal? _fdegradenum;
        private decimal? _fdegradeinquantity;
        private decimal? _fdegradeinnum;
        private decimal? _finspectquantity;
        private decimal? _finspectnum;
        private decimal? _iinvmpcost;
        private string _guids;
        private decimal? _iinvexchrate;
        private string _objectid_source;
        private int? _autoid_source;
        private string _ufts_source;
        private int? _irowno_source;
        private string _csocode;
        private int? _isorowno;
        private int? _iorderid;
        private string _cordercode;
        private int? _iorderrowno;
        private DateTime? _dlineclosedate;
        private string _contractcode;
        private string _contractrowno;
        private bool _rejectsource = false;
        private int? _iciqbookid;
        private string _cciqbookcode;
        private string _cciqcode;
        private decimal? _fciqchangrate;
        private int? _irejectautoid;
        private int? _iexpiratdatecalcu;
        private string _cexpirationdate;
        private DateTime? _dexpirationdate;
        private string _cupsocode;
        private int? _iorderdid;
        private int? _iordertype;
        private string _csoordercode;
        private int? _iorderseq;
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
        private int? _ivouchrowno;
        private int? _irowno;
        private string _cbmemo;
        private string _cbsysbarcode;
        private string _carrivalcode;
        private decimal? _ipickedquantity;
        private decimal? _ipickednum;
        private string _isourcemocode;
        private int? _isourcemodetailsid;
        private decimal? _freworkquantity;
        private decimal? _freworknum;
        private decimal? _fsumreworkquantity;
        private decimal? _fsumreworknum;
        private int? _iproducttype;
        private string _cmaininvcode;
        private int? _imainmodetailsid;
        private string _planlotnumber;
        private int? _bgift = 0;
        /// <summary>
        /// 
        /// </summary>
        public int Autoid
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cWhCode
        {
            set { _cwhcode = value; }
            get { return _cwhcode; }
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
        public decimal? iNum
        {
            set { _inum = value; }
            get { return _inum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iQuantity
        {
            set { _iquantity = value; }
            get { return _iquantity; }
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
        public decimal? iCost
        {
            set { _icost = value; }
            get { return _icost; }
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
        public decimal? iSum
        {
            set { _isum = value; }
            get { return _isum; }
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
        public decimal iTaxRate
        {
            set { _itaxrate = value; }
            get { return _itaxrate; }
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
        public int? cDefine34
        {
            set { _cdefine34 = value; }
            get { return _cdefine34; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine35
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
        public int iPOsID
        {
            set { _iposid = value; }
            get { return _iposid; }
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
        public string cUnitID
        {
            set { _cunitid = value; }
            get { return _cunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal fValidInQuan
        {
            set { _fvalidinquan = value; }
            get { return _fvalidinquan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fKPQuantity
        {
            set { _fkpquantity = value; }
            get { return _fkpquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fRealQuantity
        {
            set { _frealquantity = value; }
            get { return _frealquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fValidQuantity
        {
            set { _fvalidquantity = value; }
            get { return _fvalidquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? finValidQuantity
        {
            set { _finvalidquantity = value; }
            get { return _finvalidquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCloser
        {
            set { _ccloser = value; }
            get { return _ccloser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iCorId
        {
            set { _icorid = value; }
            get { return _icorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fRetQuantity
        {
            set { _fretquantity = value; }
            get { return _fretquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fInValidInQuan
        {
            set { _finvalidinquan = value; }
            get { return _finvalidinquan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bGsp
        {
            set { _bgsp = value; }
            get { return _bgsp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBatch
        {
            set { _cbatch = value; }
            get { return _cbatch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dVDate
        {
            set { _dvdate = value; }
            get { return _dvdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dPDate
        {
            set { _dpdate = value; }
            get { return _dpdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fRefuseQuantity
        {
            set { _frefusequantity = value; }
            get { return _frefusequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cGspState
        {
            set { _cgspstate = value; }
            get { return _cgspstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fValidNum
        {
            set { _fvalidnum = value; }
            get { return _fvalidnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal fValidInNum
        {
            set { _fvalidinnum = value; }
            get { return _fvalidinnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fInValidNum
        {
            set { _finvalidnum = value; }
            get { return _finvalidnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fRealNum
        {
            set { _frealnum = value; }
            get { return _frealnum; }
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
        public int? bInspect
        {
            set { _binspect = value; }
            get { return _binspect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fRefuseNum
        {
            set { _frefusenum = value; }
            get { return _frefusenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iPPartId
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
        public int? iPTOSeq
        {
            set { _iptoseq = value; }
            get { return _iptoseq; }
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
        public int SoType
        {
            set { _sotype = value; }
            get { return _sotype; }
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
        public int? imassdate
        {
            set { _imassdate = value; }
            get { return _imassdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cmassunit
        {
            set { _cmassunit = value; }
            get { return _cmassunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bexigency
        {
            set { _bexigency = value; }
            get { return _bexigency; }
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
        public decimal? fSumRefuseQuantity
        {
            set { _fsumrefusequantity = value; }
            get { return _fsumrefusequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FSumRefuseNum
        {
            set { _fsumrefusenum = value; }
            get { return _fsumrefusenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fRetNum
        {
            set { _fretnum = value; }
            get { return _fretnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fDTQuantity
        {
            set { _fdtquantity = value; }
            get { return _fdtquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fInvalidInNum
        {
            set { _finvalidinnum = value; }
            get { return _finvalidinnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fDegradeQuantity
        {
            set { _fdegradequantity = value; }
            get { return _fdegradequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fDegradeNum
        {
            set { _fdegradenum = value; }
            get { return _fdegradenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fDegradeInQuantity
        {
            set { _fdegradeinquantity = value; }
            get { return _fdegradeinquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fDegradeInNum
        {
            set { _fdegradeinnum = value; }
            get { return _fdegradeinnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fInspectQuantity
        {
            set { _finspectquantity = value; }
            get { return _finspectquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fInspectNum
        {
            set { _finspectnum = value; }
            get { return _finspectnum; }
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
        public string guids
        {
            set { _guids = value; }
            get { return _guids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iinvexchrate
        {
            set { _iinvexchrate = value; }
            get { return _iinvexchrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string objectid_source
        {
            set { _objectid_source = value; }
            get { return _objectid_source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? autoid_source
        {
            set { _autoid_source = value; }
            get { return _autoid_source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ufts_source
        {
            set { _ufts_source = value; }
            get { return _ufts_source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? irowno_source
        {
            set { _irowno_source = value; }
            get { return _irowno_source; }
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
        public int? isorowno
        {
            set { _isorowno = value; }
            get { return _isorowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iorderid
        {
            set { _iorderid = value; }
            get { return _iorderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cordercode
        {
            set { _cordercode = value; }
            get { return _cordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iorderrowno
        {
            set { _iorderrowno = value; }
            get { return _iorderrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dlineclosedate
        {
            set { _dlineclosedate = value; }
            get { return _dlineclosedate; }
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
        public bool RejectSource
        {
            set { _rejectsource = value; }
            get { return _rejectsource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iciqbookid
        {
            set { _iciqbookid = value; }
            get { return _iciqbookid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cciqbookcode
        {
            set { _cciqbookcode = value; }
            get { return _cciqbookcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cciqcode
        {
            set { _cciqcode = value; }
            get { return _cciqcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fciqchangrate
        {
            set { _fciqchangrate = value; }
            get { return _fciqchangrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? irejectautoid
        {
            set { _irejectautoid = value; }
            get { return _irejectautoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iExpiratDateCalcu
        {
            set { _iexpiratdatecalcu = value; }
            get { return _iexpiratdatecalcu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cExpirationdate
        {
            set { _cexpirationdate = value; }
            get { return _cexpirationdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dExpirationdate
        {
            set { _dexpirationdate = value; }
            get { return _dexpirationdate; }
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
        public int? iorderdid
        {
            set { _iorderdid = value; }
            get { return _iorderdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iordertype
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
        public int? iorderseq
        {
            set { _iorderseq = value; }
            get { return _iorderseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cBatchProperty1
        {
            set { _cbatchproperty1 = value; }
            get { return _cbatchproperty1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cBatchProperty2
        {
            set { _cbatchproperty2 = value; }
            get { return _cbatchproperty2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cBatchProperty3
        {
            set { _cbatchproperty3 = value; }
            get { return _cbatchproperty3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cBatchProperty4
        {
            set { _cbatchproperty4 = value; }
            get { return _cbatchproperty4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cBatchProperty5
        {
            set { _cbatchproperty5 = value; }
            get { return _cbatchproperty5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBatchProperty6
        {
            set { _cbatchproperty6 = value; }
            get { return _cbatchproperty6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBatchProperty7
        {
            set { _cbatchproperty7 = value; }
            get { return _cbatchproperty7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBatchProperty8
        {
            set { _cbatchproperty8 = value; }
            get { return _cbatchproperty8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBatchProperty9
        {
            set { _cbatchproperty9 = value; }
            get { return _cbatchproperty9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cBatchProperty10
        {
            set { _cbatchproperty10 = value; }
            get { return _cbatchproperty10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ivouchrowno
        {
            set { _ivouchrowno = value; }
            get { return _ivouchrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? irowno
        {
            set { _irowno = value; }
            get { return _irowno; }
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
        public string carrivalcode
        {
            set { _carrivalcode = value; }
            get { return _carrivalcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ipickedquantity
        {
            set { _ipickedquantity = value; }
            get { return _ipickedquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ipickednum
        {
            set { _ipickednum = value; }
            get { return _ipickednum; }
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
        public int? iSourceMODetailsID
        {
            set { _isourcemodetailsid = value; }
            get { return _isourcemodetailsid; }
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
        public decimal? fsumreworkquantity
        {
            set { _fsumreworkquantity = value; }
            get { return _fsumreworkquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fsumreworknum
        {
            set { _fsumreworknum = value; }
            get { return _fsumreworknum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iProductType
        {
            set { _iproducttype = value; }
            get { return _iproducttype; }
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
        public int? iMainMoDetailsID
        {
            set { _imainmodetailsid = value; }
            get { return _imainmodetailsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlanLotNumber
        {
            set { _planlotnumber = value; }
            get { return _planlotnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bgift
        {
            set { _bgift = value; }
            get { return _bgift; }
        }
        #endregion Model

    }
}

