using System;
namespace ClsU8.Model
{
    /// <summary>
    /// MaterialAppVouchs:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MaterialAppVouchs
    {
        public MaterialAppVouchs()
        { }
        #region Model
        private long _autoid;
        private long _id;
        private string _cinvcode;
        private decimal? _inum;
        private decimal? _iquantity;
        private string _cbatch;
        private string _cfree1;
        private string _cfree2;
        private DateTime? _dduedate;
        private string _cbcloser;
        private decimal? _foutquantity;
        private decimal? _foutnum;
        private DateTime? _dvdate;
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
        private string _cassunit;
        private DateTime? _dmadedate;
        private long? _imassdate;
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
        private long? _cmassunit;
        private string _cwhcode;
        private decimal? _iinvexchrate ;
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
        private string _cbmemo;
        private long? _irowno;
        private long? _impoids;
        private string _cmolotcode;
        private string _cmworkcentercode;
        private string _cmocode;
        private long? _imoseq;
        private string _iopseq;
        private string _copdesc;
        private long? _iomodid;
        private long? _iomomid;
        private string _comcode;
        private string _invcode;
        private string _cciqbookcode;
        private string _cservicecode;
        private long? _iordertype = 0;
        private long? _iorderdid;
        private string _iordercode;
        private long? _iorderseq;
        private long? _isotype;
        private string _isodid;
        private string _csocode;
        private long? _isoseq;
        private string _corufts = "";
        private string _crejectcode = "";
        private string _ipesodid;
        private long? _ipesotype;
        private string _cpesocode;
        private long? _ipesoseq;
        private string _cbsysbarcode;
        private decimal? _ipickedquantity;
        private decimal? _ipickednum;
        private string _csourcemocode;
        private long? _isourcemodetailsid;
        private string _cplanlotcode;
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
        public string cBatch
        {
            set { _cbatch = value; }
            get { return _cbatch; }
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
        public DateTime? dDueDate
        {
            set { _dduedate = value; }
            get { return _dduedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBCloser
        {
            set { _cbcloser = value; }
            get { return _cbcloser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fOutQuantity
        {
            set { _foutquantity = value; }
            get { return _foutquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fOutNum
        {
            set { _foutnum = value; }
            get { return _foutnum; }
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
        public long? iMassDate
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
        public long? cMassUnit
        {
            set { _cmassunit = value; }
            get { return _cmassunit; }
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
        public decimal? iinvexchrate
        {
            set { _iinvexchrate = value; }
            get { return _iinvexchrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iExpiratDateCalcu
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
        public long? irowno
        {
            set { _irowno = value; }
            get { return _irowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iMPoIds
        {
            set { _impoids = value; }
            get { return _impoids; }
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
        public string cmworkcentercode
        {
            set { _cmworkcentercode = value; }
            get { return _cmworkcentercode; }
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
        public long? imoseq
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
        public long? iOMoDID
        {
            set { _iomodid = value; }
            get { return _iomodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iOMoMID
        {
            set { _iomomid = value; }
            get { return _iomomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string comcode
        {
            set { _comcode = value; }
            get { return _comcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string invcode
        {
            set { _invcode = value; }
            get { return _invcode; }
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
        public string cservicecode
        {
            set { _cservicecode = value; }
            get { return _cservicecode; }
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
        public long? iorderdid
        {
            set { _iorderdid = value; }
            get { return _iorderdid; }
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
        public long? iorderseq
        {
            set { _iorderseq = value; }
            get { return _iorderseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? isotype
        {
            set { _isotype = value; }
            get { return _isotype; }
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
        public string csocode
        {
            set { _csocode = value; }
            get { return _csocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? isoseq
        {
            set { _isoseq = value; }
            get { return _isoseq; }
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
        public string crejectcode
        {
            set { _crejectcode = value; }
            get { return _crejectcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ipesodid
        {
            set { _ipesodid = value; }
            get { return _ipesodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ipesotype
        {
            set { _ipesotype = value; }
            get { return _ipesotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpesocode
        {
            set { _cpesocode = value; }
            get { return _cpesocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ipesoseq
        {
            set { _ipesoseq = value; }
            get { return _ipesoseq; }
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
        public string cSourceMOCode
        {
            set { _csourcemocode = value; }
            get { return _csourcemocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iSourceMODetailsid
        {
            set { _isourcemodetailsid = value; }
            get { return _isourcemodetailsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cplanlotcode
        {
            set { _cplanlotcode = value; }
            get { return _cplanlotcode; }
        }
        #endregion Model

    }
}

