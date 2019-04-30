﻿using System;
namespace TH.clsU8.Model
{
    /// <summary>
    /// rdrecords10:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class rdrecords10
    {
        public rdrecords10()
        { }
        #region Model
        private long _autoid;
        private long _id;
        private string _cinvcode;
        private decimal? _inum;
        private decimal? _iquantity;
        private decimal? _iunitcost;
        private decimal? _iprice;
        private decimal? _iaprice;
        private decimal? _ipunitcost;
        private decimal? _ipprice;
        private string _cbatch;
        private long _cvouchcode;
        private string _cinvouchcode;
        private string _cinvouchtype;
        private decimal? _isoutquantity;
        private decimal? _isoutnum;
        private string _cfree1;
        private string _cfree2;
        private int _iflag = 0;
        private decimal? _ifnum;
        private decimal? _ifquantity;
        private DateTime? _dvdate;
        private string _cposition;
        private string _cdefine22;
        private string _cdefine23;
        private string _cdefine24;
        private string _cdefine25;
        private decimal? _cdefine26;
        private decimal? _cdefine27;
        private string _citem_class;
        private string _citemcode;
        private string _cname;
        private string _citemcname;
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
        private long _impoids;
        private long? _icheckids;
        private string _cbvencode;
        private bool _bgsp;
        private string _cgspstate;
        private string _ccheckcode;
        private long? _icheckidbaks;
        private string _crejectcode;
        private long? _irejectids;
        private string _ccheckpersoncode;
        private DateTime? _dcheckdate;
        private int? _cmassunit;
        private string _cmolotcode;
        private bool _bchecked;
        private bool _brelated;
        private string _cmworkcentercode;
        private bool _blpusefree = false;
        private int? _irsrowno = 0;
        private long? _ioritrackid = 0;
        private string _coritracktype;
        private string _cbaccounter = "";
        private DateTime? _dbkeepdate;
        private bool _bcosting;
        private bool _bvmiused = false;
        private decimal? _ivmisettlequantity = 0M;
        private decimal? _ivmisettlenum = 0M;
        private string _cvmivencode;
        private int? _iinvsncount;
        private string _cwhpersoncode;
        private string _cwhpersonname;
        private string _cserviceoid;
        private string _cbserviceoid;
        private decimal? _iinvexchrate;
        private string _corufts = "";
        private string _cmocode;
        private int? _imoseq;
        private string _iopseq;
        private string _copdesc;
        private Guid _strcontractguid;
        private int? _iexpiratdatecalcu;
        private string _cexpirationdate;
        private DateTime? _dexpirationdate;
        private string _cciqbookcode;
        private decimal? _ibondedsumqty;
        private int? _productinids;
        private int? _iorderdid;
        private int? _iordertype = 0;
        private string _iordercode;
        private int? _iorderseq;
        private string _isodid;
        private int? _isotype;
        private string _csocode;
        private int? _isoseq;
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
        private string _cbmemo;
        private int? _irowno;
        private Guid _strowguid;
        private string _cservicecode;
        private DateTime? _rowufts;
        private decimal? _ipreuseqty;
        private decimal? _ipreuseinum;
        private decimal? _outcopiedquantity;
        private string _cbsysbarcode;
        private string _cplanlotcode;
        private bool _bmergecheck;
        private int? _imergecheckautoid;
        private int? _iposflag = 0;
        private long _iorderdetailid;
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
        public long ID
        {
            set { _id = value; }
            get { return _id; }
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
        public decimal? iQuantity
        {
            set { _iquantity = value; }
            get { return _iquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iUnitCost
        {
            set { _iunitcost = value; }
            get { return _iunitcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPrice
        {
            set { _iprice = value; }
            get { return _iprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iAPrice
        {
            set { _iaprice = value; }
            get { return _iaprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPUnitCost
        {
            set { _ipunitcost = value; }
            get { return _ipunitcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPPrice
        {
            set { _ipprice = value; }
            get { return _ipprice; }
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
        public long cVouchCode
        {
            set { _cvouchcode = value; }
            get { return _cvouchcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInVouchCode
        {
            set { _cinvouchcode = value; }
            get { return _cinvouchcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cinvouchtype
        {
            set { _cinvouchtype = value; }
            get { return _cinvouchtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSOutQuantity
        {
            set { _isoutquantity = value; }
            get { return _isoutquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSOutNum
        {
            set { _isoutnum = value; }
            get { return _isoutnum; }
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
        public int iFlag
        {
            set { _iflag = value; }
            get { return _iflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iFNum
        {
            set { _ifnum = value; }
            get { return _ifnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iFQuantity
        {
            set { _ifquantity = value; }
            get { return _ifquantity; }
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
        public string cPosition
        {
            set { _cposition = value; }
            get { return _cposition; }
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
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItemCName
        {
            set { _citemcname = value; }
            get { return _citemcname; }
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
        public string cBarCode
        {
            set { _cbarcode = value; }
            get { return _cbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNQuantity
        {
            set { _inquantity = value; }
            get { return _inquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNNum
        {
            set { _innum = value; }
            get { return _innum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cAssUnit
        {
            set { _cassunit = value; }
            get { return _cassunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dMadeDate
        {
            set { _dmadedate = value; }
            get { return _dmadedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iMassDate
        {
            set { _imassdate = value; }
            get { return _imassdate; }
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
        public long iMPoIds
        {
            set { _impoids = value; }
            get { return _impoids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iCheckIds
        {
            set { _icheckids = value; }
            get { return _icheckids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBVencode
        {
            set { _cbvencode = value; }
            get { return _cbvencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bGsp
        {
            set { _bgsp = value; }
            get { return _bgsp; }
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
        public string cCheckCode
        {
            set { _ccheckcode = value; }
            get { return _ccheckcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iCheckIdBaks
        {
            set { _icheckidbaks = value; }
            get { return _icheckidbaks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cRejectCode
        {
            set { _crejectcode = value; }
            get { return _crejectcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iRejectIds
        {
            set { _irejectids = value; }
            get { return _irejectids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCheckPersonCode
        {
            set { _ccheckpersoncode = value; }
            get { return _ccheckpersoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dCheckDate
        {
            set { _dcheckdate = value; }
            get { return _dcheckdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cMassUnit
        {
            set { _cmassunit = value; }
            get { return _cmassunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMoLotCode
        {
            set { _cmolotcode = value; }
            get { return _cmolotcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bChecked
        {
            set { _bchecked = value; }
            get { return _bchecked; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bRelated
        {
            set { _brelated = value; }
            get { return _brelated; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cmworkcentercode
        {
            set { _cmworkcentercode = value; }
            get { return _cmworkcentercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bLPUseFree
        {
            set { _blpusefree = value; }
            get { return _blpusefree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iRSRowNO
        {
            set { _irsrowno = value; }
            get { return _irsrowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iOriTrackID
        {
            set { _ioritrackid = value; }
            get { return _ioritrackid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coritracktype
        {
            set { _coritracktype = value; }
            get { return _coritracktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbaccounter
        {
            set { _cbaccounter = value; }
            get { return _cbaccounter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dbKeepDate
        {
            set { _dbkeepdate = value; }
            get { return _dbkeepdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bCosting
        {
            set { _bcosting = value; }
            get { return _bcosting; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bVMIUsed
        {
            set { _bvmiused = value; }
            get { return _bvmiused; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iVMISettleQuantity
        {
            set { _ivmisettlequantity = value; }
            get { return _ivmisettlequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iVMISettleNum
        {
            set { _ivmisettlenum = value; }
            get { return _ivmisettlenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cvmivencode
        {
            set { _cvmivencode = value; }
            get { return _cvmivencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iInvSNCount
        {
            set { _iinvsncount = value; }
            get { return _iinvsncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cwhpersoncode
        {
            set { _cwhpersoncode = value; }
            get { return _cwhpersoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cwhpersonname
        {
            set { _cwhpersonname = value; }
            get { return _cwhpersonname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cserviceoid
        {
            set { _cserviceoid = value; }
            get { return _cserviceoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbserviceoid
        {
            set { _cbserviceoid = value; }
            get { return _cbserviceoid; }
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
        public string corufts
        {
            set { _corufts = value; }
            get { return _corufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cmocode
        {
            set { _cmocode = value; }
            get { return _cmocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? imoseq
        {
            set { _imoseq = value; }
            get { return _imoseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iopseq
        {
            set { _iopseq = value; }
            get { return _iopseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string copdesc
        {
            set { _copdesc = value; }
            get { return _copdesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid strContractGUID
        {
            set { _strcontractguid = value; }
            get { return _strcontractguid; }
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
        public string cciqbookcode
        {
            set { _cciqbookcode = value; }
            get { return _cciqbookcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iBondedSumQty
        {
            set { _ibondedsumqty = value; }
            get { return _ibondedsumqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? productinids
        {
            set { _productinids = value; }
            get { return _productinids; }
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
        public string iordercode
        {
            set { _iordercode = value; }
            get { return _iordercode; }
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
        public string isodid
        {
            set { _isodid = value; }
            get { return _isodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isotype
        {
            set { _isotype = value; }
            get { return _isotype; }
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
        public int? isoseq
        {
            set { _isoseq = value; }
            get { return _isoseq; }
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
        public string cbMemo
        {
            set { _cbmemo = value; }
            get { return _cbmemo; }
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
        public Guid strowguid
        {
            set { _strowguid = value; }
            get { return _strowguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cservicecode
        {
            set { _cservicecode = value; }
            get { return _cservicecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? rowufts
        {
            set { _rowufts = value; }
            get { return _rowufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ipreuseqty
        {
            set { _ipreuseqty = value; }
            get { return _ipreuseqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ipreuseinum
        {
            set { _ipreuseinum = value; }
            get { return _ipreuseinum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OutCopiedQuantity
        {
            set { _outcopiedquantity = value; }
            get { return _outcopiedquantity; }
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
        public string cplanlotcode
        {
            set { _cplanlotcode = value; }
            get { return _cplanlotcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bmergecheck
        {
            set { _bmergecheck = value; }
            get { return _bmergecheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? imergecheckautoid
        {
            set { _imergecheckautoid = value; }
            get { return _imergecheckautoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iposflag
        {
            set { _iposflag = value; }
            get { return _iposflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iorderdetailid
        {
            set { _iorderdetailid = value; }
            get { return _iorderdetailid; }
        }
        #endregion Model

    }
}

