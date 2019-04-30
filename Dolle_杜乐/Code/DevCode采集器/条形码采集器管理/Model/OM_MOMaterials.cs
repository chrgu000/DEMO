using System;
namespace BarCode.Model
{
    /// <summary>
    /// OM_MOMaterials:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OM_MOMaterials
    {
        public OM_MOMaterials()
        { }
        #region Model
        private long _momaterialsid;
        private long _modetailsid;
        private long _moid;
        private string _cinvcode;
        private decimal? _iquantity;
        private DateTime? _drequireddate;
        private decimal? _isendqty;
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
        private decimal? _fbaseqtyn;
        private decimal? _fbaseqtyd;
        private decimal? _fcompscrp;
        private long? _bfvqty;
        private long? _iwiptype;
        private string _cwhcode;
        private decimal? _iunitquantity;
        private string _cbatch;
        private long? _opcomponentid;
        private long? _subflag = 0;
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
        private long? _cdefine34;
        private long? _cdefine35;
        private DateTime? _cdefine36;
        private DateTime? _cdefine37;
        private decimal? _fbasenumn;
        private decimal? _iunitnum;
        private decimal? _inum;
        private decimal? _isendnum;
        private string _cunitid;
        private decimal? _icomplementqty;
        private decimal? _icomplementnum;
        private decimal? _ftransqty;
        private DateTime _dufts;
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
        private long? _sotype;
        private string _sodid;
        private string _csocode;
        private long? _irowno;
        private string _cdemandmemo;
        private string _cdetailsdemandcode;
        private string _cdetailsdemandmemo;
        private string _csendtype;
        private decimal? _fsendapplyqty;
        private decimal? _fsendapplynum;
        private decimal? _fapplyqty;
        private decimal? _fapplynum;
        private string _cbmemo;
        private string _csubsysbarcode;
        private decimal? _ipickqty;
        private decimal? _ipicknum;
        private long? _iproducttype;
        /// <summary>
        /// 
        /// </summary>
        public long MOMaterialsID
        {
            set { _momaterialsid = value; }
            get { return _momaterialsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long MoDetailsID
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
        public DateTime? dRequiredDate
        {
            set { _drequireddate = value; }
            get { return _drequireddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSendQTY
        {
            set { _isendqty = value; }
            get { return _isendqty; }
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
        public decimal? fBaseQtyN
        {
            set { _fbaseqtyn = value; }
            get { return _fbaseqtyn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fBaseQtyD
        {
            set { _fbaseqtyd = value; }
            get { return _fbaseqtyd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fCompScrp
        {
            set { _fcompscrp = value; }
            get { return _fcompscrp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? bFVQty
        {
            set { _bfvqty = value; }
            get { return _bfvqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iWIPtype
        {
            set { _iwiptype = value; }
            get { return _iwiptype; }
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
        public decimal? iUnitQuantity
        {
            set { _iunitquantity = value; }
            get { return _iunitquantity; }
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
        public long? OpComponentId
        {
            set { _opcomponentid = value; }
            get { return _opcomponentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SubFlag
        {
            set { _subflag = value; }
            get { return _subflag; }
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
        public decimal? fbasenumn
        {
            set { _fbasenumn = value; }
            get { return _fbasenumn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iUnitNum
        {
            set { _iunitnum = value; }
            get { return _iunitnum; }
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
        public decimal? iSendNum
        {
            set { _isendnum = value; }
            get { return _isendnum; }
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
        public decimal? iComplementQty
        {
            set { _icomplementqty = value; }
            get { return _icomplementqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iComplementNum
        {
            set { _icomplementnum = value; }
            get { return _icomplementnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fTransQty
        {
            set { _ftransqty = value; }
            get { return _ftransqty; }
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
        public long? sotype
        {
            set { _sotype = value; }
            get { return _sotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sodid
        {
            set { _sodid = value; }
            get { return _sodid; }
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
        public string cdemandmemo
        {
            set { _cdemandmemo = value; }
            get { return _cdemandmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdetailsdemandcode
        {
            set { _cdetailsdemandcode = value; }
            get { return _cdetailsdemandcode; }
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
        public string csendtype
        {
            set { _csendtype = value; }
            get { return _csendtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fsendapplyqty
        {
            set { _fsendapplyqty = value; }
            get { return _fsendapplyqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fsendapplynum
        {
            set { _fsendapplynum = value; }
            get { return _fsendapplynum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fapplyqty
        {
            set { _fapplyqty = value; }
            get { return _fapplyqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fapplynum
        {
            set { _fapplynum = value; }
            get { return _fapplynum; }
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
        public string csubsysbarcode
        {
            set { _csubsysbarcode = value; }
            get { return _csubsysbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPickQty
        {
            set { _ipickqty = value; }
            get { return _ipickqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPickNum
        {
            set { _ipicknum = value; }
            get { return _ipicknum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iProductType
        {
            set { _iproducttype = value; }
            get { return _iproducttype; }
        }
        #endregion Model

    }
}

