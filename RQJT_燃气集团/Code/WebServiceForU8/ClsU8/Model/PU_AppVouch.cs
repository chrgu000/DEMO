using System;
namespace ClsU8.Model
{
    /// <summary>
    /// PU_AppVouch:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PU_AppVouch
    {
        public PU_AppVouch()
        { }
        #region Model
        private DateTime _ufts;
        private long _ivtid = 0;
        private long _id;
        private string _ccode;
        private DateTime _ddate;
        private string _cdepcode;
        private string _cpersoncode;
        private string _cptcode;
        private string _cbustype;
        private string _cmaker;
        private string _cverifier;
        private string _ccloser;
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
        private string _cdefine11;
        private string _cdefine12;
        private string _cdefine13;
        private string _cdefine14;
        private long? _cdefine15;
        private decimal? _cdefine16;
        private string _cmemo;
        private string _clocker;
        private long? _iverifystateex;
        private long? _ireturncount;
        private bool _iswfcontrolled = false;
        private DateTime? _cmaketime = DateTime.Now;
        private DateTime? _cmodifytime;
        private DateTime? _caudittime;
        private DateTime? _cauditdate;
        private DateTime? _cmodifydate;
        private string _creviser;
        private string _cchanger;
        private long? _ibg_overflag = 0;
        private string _cbg_auditor = "";
        private string _cbg_audittime = "";
        private long? _controlresult;
        private long? _iflowid;
        private long? _iprintcount = 0;
        private string _ccleanver;
        private DateTime? _dclosedate;
        private DateTime? _dclosetime;
        private string _csysbarcode;
        private string _ccurrentauditor;
        private string _cchangverifier;
        private DateTime? _cchangaudittime;
        private DateTime? _cchangauditdate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iVTid
        {
            set { _ivtid = value; }
            get { return _ivtid; }
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
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
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
        public string cBusType
        {
            set { _cbustype = value; }
            get { return _cbustype; }
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
        public string cVerifier
        {
            set { _cverifier = value; }
            get { return _cverifier; }
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
        public string cMemo
        {
            set { _cmemo = value; }
            get { return _cmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cLocker
        {
            set { _clocker = value; }
            get { return _clocker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iverifystateex
        {
            set { _iverifystateex = value; }
            get { return _iverifystateex; }
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
        public bool IsWfControlled
        {
            set { _iswfcontrolled = value; }
            get { return _iswfcontrolled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cMakeTime
        {
            set { _cmaketime = value; }
            get { return _cmaketime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cModifyTime
        {
            set { _cmodifytime = value; }
            get { return _cmodifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cAuditTime
        {
            set { _caudittime = value; }
            get { return _caudittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cAuditDate
        {
            set { _cauditdate = value; }
            get { return _cauditdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cModifyDate
        {
            set { _cmodifydate = value; }
            get { return _cmodifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cReviser
        {
            set { _creviser = value; }
            get { return _creviser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cchanger
        {
            set { _cchanger = value; }
            get { return _cchanger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iBG_OverFlag
        {
            set { _ibg_overflag = value; }
            get { return _ibg_overflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_Auditor
        {
            set { _cbg_auditor = value; }
            get { return _cbg_auditor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_AuditTime
        {
            set { _cbg_audittime = value; }
            get { return _cbg_audittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ControlResult
        {
            set { _controlresult = value; }
            get { return _controlresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iflowid
        {
            set { _iflowid = value; }
            get { return _iflowid; }
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
        public string ccleanver
        {
            set { _ccleanver = value; }
            get { return _ccleanver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dCloseDate
        {
            set { _dclosedate = value; }
            get { return _dclosedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dCloseTime
        {
            set { _dclosetime = value; }
            get { return _dclosetime; }
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
        public string cChangVerifier
        {
            set { _cchangverifier = value; }
            get { return _cchangverifier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cChangAuditTime
        {
            set { _cchangaudittime = value; }
            get { return _cchangaudittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cChangAuditDate
        {
            set { _cchangauditdate = value; }
            get { return _cchangauditdate; }
        }
        #endregion Model

    }
}

