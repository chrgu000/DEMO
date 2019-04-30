using System;
namespace ClsU8.Model
{
    /// <summary>
    /// MaterialAppVouch:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MaterialAppVouch
    {
        public MaterialAppVouch()
        { }
        #region Model
        private long? _id;
        private DateTime _ddate;
        private string _ccode;
        private string _crdcode;
        private string _cdepcode;
        private string _cpersoncode;
        private string _citem_class;
        private string _citemcode;
        private string _cname;
        private string _citemcname;
        private string _chandler;
        private string _cmemo;
        private string _ccloser;
        private string _cmaker;
        private string _cdefine1;
        private string _cdefine2;
        private string _cdefine3;
        private DateTime? _cdefine4;
        private long? _cdefine5;
        private DateTime? _cdefine6;
        private decimal? _cdefine7;
        private string _cdefine8;
        private string _cdefine9;
        private string _cdefine10;
        private DateTime? _dveridate;
        private long? _vt_id;
        private string _cdefine11;
        private string _cdefine12;
        private string _cdefine13;
        private string _cdefine14;
        private long? _cdefine15;
        private decimal? _cdefine16;
        private DateTime? _ufts;
        private long? _ireturncount = 0;
        private long? _iverifystate = 0;
        private long? _iswfcontrolled = 0;
        private string _cmodifyperson = "";
        private DateTime? _dmodifydate;
        private DateTime? _dnmaketime;
        private DateTime? _dnmodifytime;
        private DateTime? _dnverifytime;
        private long? _iprintcount = 0;
        private string _csource;
        private string _cvencode;
        private decimal? _imquantity;
        private string _csysbarcode;
        private string _ccurrentauditor;
        private string _cchanger;
        /// <summary>
        /// 
        /// </summary>
        public long? ID
        {
            set { _id = value; }
            get { return _id; }
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
        public string cCloser
        {
            set { _ccloser = value; }
            get { return _ccloser; }
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
        public long? cDefine5
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
        public DateTime? dVeriDate
        {
            set { _dveridate = value; }
            get { return _dveridate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? VT_ID
        {
            set { _vt_id = value; }
            get { return _vt_id; }
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
        public long? cDefine15
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
        public DateTime? ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ireturncount
        {
            set { _ireturncount = value; }
            get { return _ireturncount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iverifystate
        {
            set { _iverifystate = value; }
            get { return _iverifystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iswfcontrolled
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
        public long? iPrintCount
        {
            set { _iprintcount = value; }
            get { return _iprintcount; }
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
        public string cvencode
        {
            set { _cvencode = value; }
            get { return _cvencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? imquantity
        {
            set { _imquantity = value; }
            get { return _imquantity; }
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
        /// <summary>
        /// 
        /// </summary>
        public string cChanger
        {
            set { _cchanger = value; }
            get { return _cchanger; }
        }
        #endregion Model

    }
}

