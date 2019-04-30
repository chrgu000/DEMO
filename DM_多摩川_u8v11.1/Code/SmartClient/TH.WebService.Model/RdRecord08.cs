using System;
namespace TH.WebService.Model
{
    /// <summary>
    /// RdRecord08:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RdRecord08
    {
        public RdRecord08()
        { }
        #region Model
        private long _id;
        private int _brdflag;
        private string _cvouchtype;
        private string _cbustype;
        private string _csource;
        private string _cbuscode;
        private string _cwhcode;
        private DateTime _ddate;
        private string _ccode;
        private string _crdcode;
        private string _cdepcode;
        private string _cpersoncode;
        private string _cptcode;
        private string _cstcode;
        private string _ccuscode;
        private string _cvencode;
        private string _cordercode;
        private string _carvcode;
        private long? _cbillcode;
        private long? _cdlcode;
        private string _cprobatch;
        private string _chandler;
        private string _cmemo;
        private bool _btransflag = false;
        private string _caccounter;
        private string _cmaker;
        private string _cdefine1;
        private string _cdefine2;
        private string _cdefine3;
        private DateTime? _cdefine4;
        private int? _cdefine5;
        private DateTime? _cdefine6;
        private decimal? _cdefine7;
        private string _cdefine8;
        private string _cdefine9;
        private string _cdefine10;
        private string _dkeepdate;
        private DateTime? _dveridate;
        private bool _bpufirst = false;
        private bool _biafirst = false;
        private decimal? _imquantity;
        private DateTime? _darvdate;
        private string _cchkcode;
        private DateTime? _dchkdate;
        private string _cchkperson;
        private int? _vt_id;
        private bool _bisstqc = false;
        private string _cdefine11;
        private string _cdefine12;
        private string _cdefine13;
        private string _cdefine14;
        private int? _cdefine15;
        private decimal? _cdefine16;
        private string _gspcheck;
        private DateTime? _ufts;
        private decimal? _iexchrate;
        private string _cexch_name;
        private bool _bomfirst;
        private bool _bfrompreyear = false;
        private bool _bislsquery;
        private int? _biscomplement = 0;
        private int? _idiscounttaxtype = 0;
        private int? _ireturncount = 0;
        private int? _iverifystate = 0;
        private int? _iswfcontrolled = 0;
        private string _cmodifyperson = "";
        private DateTime? _dmodifydate;
        private DateTime? _dnmaketime;
        private DateTime? _dnmodifytime;
        private DateTime? _dnverifytime;
        private int? _bredvouch = 0;
        private int? _iflowid;
        private string _cpzid;
        private string _csourcels;
        private string _csourcecodels;
        private int? _iprintcount = 0;
        private string _ctransflag;
        private string _csysbarcode;
        private string _ccurrentauditor;
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
        public int bRdFlag
        {
            set { _brdflag = value; }
            get { return _brdflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVouchType
        {
            set { _cvouchtype = value; }
            get { return _cvouchtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBusType
        {
            set { _cbustype = value; }
            get { return _cbustype; }
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
        public string cBusCode
        {
            set { _cbuscode = value; }
            get { return _cbuscode; }
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
        public DateTime dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cRdCode
        {
            set { _crdcode = value; }
            get { return _crdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDepCode
        {
            set { _cdepcode = value; }
            get { return _cdepcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPersonCode
        {
            set { _cpersoncode = value; }
            get { return _cpersoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPTCode
        {
            set { _cptcode = value; }
            get { return _cptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSTCode
        {
            set { _cstcode = value; }
            get { return _cstcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusCode
        {
            set { _ccuscode = value; }
            get { return _ccuscode; }
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
        public string cOrderCode
        {
            set { _cordercode = value; }
            get { return _cordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cARVCode
        {
            set { _carvcode = value; }
            get { return _carvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cBillCode
        {
            set { _cbillcode = value; }
            get { return _cbillcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cDLCode
        {
            set { _cdlcode = value; }
            get { return _cdlcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cProBatch
        {
            set { _cprobatch = value; }
            get { return _cprobatch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cHandler
        {
            set { _chandler = value; }
            get { return _chandler; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMemo
        {
            set { _cmemo = value; }
            get { return _cmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bTransFlag
        {
            set { _btransflag = value; }
            get { return _btransflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cAccounter
        {
            set { _caccounter = value; }
            get { return _caccounter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMaker
        {
            set { _cmaker = value; }
            get { return _cmaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine1
        {
            set { _cdefine1 = value; }
            get { return _cdefine1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine2
        {
            set { _cdefine2 = value; }
            get { return _cdefine2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine3
        {
            set { _cdefine3 = value; }
            get { return _cdefine3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine4
        {
            set { _cdefine4 = value; }
            get { return _cdefine4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine5
        {
            set { _cdefine5 = value; }
            get { return _cdefine5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine6
        {
            set { _cdefine6 = value; }
            get { return _cdefine6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine7
        {
            set { _cdefine7 = value; }
            get { return _cdefine7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine8
        {
            set { _cdefine8 = value; }
            get { return _cdefine8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine9
        {
            set { _cdefine9 = value; }
            get { return _cdefine9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine10
        {
            set { _cdefine10 = value; }
            get { return _cdefine10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dKeepDate
        {
            set { _dkeepdate = value; }
            get { return _dkeepdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dVeriDate
        {
            set { _dveridate = value; }
            get { return _dveridate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bpufirst
        {
            set { _bpufirst = value; }
            get { return _bpufirst; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool biafirst
        {
            set { _biafirst = value; }
            get { return _biafirst; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iMQuantity
        {
            set { _imquantity = value; }
            get { return _imquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dARVDate
        {
            set { _darvdate = value; }
            get { return _darvdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cChkCode
        {
            set { _cchkcode = value; }
            get { return _cchkcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dChkDate
        {
            set { _dchkdate = value; }
            get { return _dchkdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cChkPerson
        {
            set { _cchkperson = value; }
            get { return _cchkperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VT_ID
        {
            set { _vt_id = value; }
            get { return _vt_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bIsSTQc
        {
            set { _bisstqc = value; }
            get { return _bisstqc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine11
        {
            set { _cdefine11 = value; }
            get { return _cdefine11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine12
        {
            set { _cdefine12 = value; }
            get { return _cdefine12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine13
        {
            set { _cdefine13 = value; }
            get { return _cdefine13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine14
        {
            set { _cdefine14 = value; }
            get { return _cdefine14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine15
        {
            set { _cdefine15 = value; }
            get { return _cdefine15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine16
        {
            set { _cdefine16 = value; }
            get { return _cdefine16; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gspcheck
        {
            set { _gspcheck = value; }
            get { return _gspcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
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
        public string cExch_Name
        {
            set { _cexch_name = value; }
            get { return _cexch_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bOMFirst
        {
            set { _bomfirst = value; }
            get { return _bomfirst; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bFromPreYear
        {
            set { _bfrompreyear = value; }
            get { return _bfrompreyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bIsLsQuery
        {
            set { _bislsquery = value; }
            get { return _bislsquery; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bIsComplement
        {
            set { _biscomplement = value; }
            get { return _biscomplement; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iDiscountTaxType
        {
            set { _idiscounttaxtype = value; }
            get { return _idiscounttaxtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ireturncount
        {
            set { _ireturncount = value; }
            get { return _ireturncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iverifystate
        {
            set { _iverifystate = value; }
            get { return _iverifystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iswfcontrolled
        {
            set { _iswfcontrolled = value; }
            get { return _iswfcontrolled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cModifyPerson
        {
            set { _cmodifyperson = value; }
            get { return _cmodifyperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dModifyDate
        {
            set { _dmodifydate = value; }
            get { return _dmodifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dnmaketime
        {
            set { _dnmaketime = value; }
            get { return _dnmaketime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dnmodifytime
        {
            set { _dnmodifytime = value; }
            get { return _dnmodifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dnverifytime
        {
            set { _dnverifytime = value; }
            get { return _dnverifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? bredvouch
        {
            set { _bredvouch = value; }
            get { return _bredvouch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iFlowId
        {
            set { _iflowid = value; }
            get { return _iflowid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cPZID
        {
            set { _cpzid = value; }
            get { return _cpzid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSourceLs
        {
            set { _csourcels = value; }
            get { return _csourcels; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSourceCodeLs
        {
            set { _csourcecodels = value; }
            get { return _csourcecodels; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iPrintCount
        {
            set { _iprintcount = value; }
            get { return _iprintcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ctransflag
        {
            set { _ctransflag = value; }
            get { return _ctransflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csysbarcode
        {
            set { _csysbarcode = value; }
            get { return _csysbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCurrentAuditor
        {
            set { _ccurrentauditor = value; }
            get { return _ccurrentauditor; }
        }
        #endregion Model

    }
}

