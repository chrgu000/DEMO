using System;
namespace ImportDLL.Model
{
    /// <summary>
    /// DispatchList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DispatchList
    {
        public DispatchList()
        { }
        #region Model
        private long _dlid = 0;
        private string _cdlcode;
        private string _cvouchtype;
        private string _cstcode;
        private DateTime _ddate;
        private string _crdcode;
        private string _cdepcode;
        private string _cpersoncode;
        private long _sbvid = 0;
        private string _csbvcode;
        private string _csocode;
        private string _ccuscode;
        private string _cpaycode;
        private string _csccode;
        private string _cshipaddress;
        private string _cexch_name;
        private decimal _iexchrate = 1M;
        private decimal? _itaxrate = 0M;
        private bool _bfirst = false;
        private bool _breturnflag = false;
        private bool _bsettleall = false;
        private string _cmemo;
        private string _csaleout;
        private bool _bdisflag = false;
        private string _cdefine1;
        private string _cdefine2;
        private string _cdefine3;
        private DateTime? _cdefine4;
        private long? _cdefine5;
        private DateTime? _cdefine6;
        private decimal? _cdefine7 = 0M;
        private string _cdefine8;
        private string _cdefine9;
        private string _cdefine10;
        private string _cverifier;
        private string _cmaker;
        private decimal? _inetlock = 0M;
        private long? _isale = 0;
        private string _ccusname;
        private string _czqcode;
        private DateTime _dzqdate ;
        /// <summary>
        /// 
        /// </summary>
        public long DLID
        {
            set { _dlid = value; }
            get { return _dlid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDLCode
        {
            set { _cdlcode = value; }
            get { return _cdlcode; }
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
        public string cSTCode
        {
            set { _cstcode = value; }
            get { return _cstcode; }
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
        public long SBVID
        {
            set { _sbvid = value; }
            get { return _sbvid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSBVCode
        {
            set { _csbvcode = value; }
            get { return _csbvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSOCode
        {
            set { _csocode = value; }
            get { return _csocode; }
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
        public string cPayCode
        {
            set { _cpaycode = value; }
            get { return _cpaycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSCCode
        {
            set { _csccode = value; }
            get { return _csccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cShipAddress
        {
            set { _cshipaddress = value; }
            get { return _cshipaddress; }
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
        public decimal iExchRate
        {
            set { _iexchrate = value; }
            get { return _iexchrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxRate
        {
            set { _itaxrate = value; }
            get { return _itaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bFirst
        {
            set { _bfirst = value; }
            get { return _bfirst; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bReturnFlag
        {
            set { _breturnflag = value; }
            get { return _breturnflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bSettleAll
        {
            set { _bsettleall = value; }
            get { return _bsettleall; }
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
        public string cSaleOut
        {
            set { _csaleout = value; }
            get { return _csaleout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bDisFlag
        {
            set { _bdisflag = value; }
            get { return _bdisflag; }
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
        public string cVerifier
        {
            set { _cverifier = value; }
            get { return _cverifier; }
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
        public decimal? iNetLock
        {
            set { _inetlock = value; }
            get { return _inetlock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iSale
        {
            set { _isale = value; }
            get { return _isale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusName
        {
            set { _ccusname = value; }
            get { return _ccusname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cZQCode
        {
            set { _czqcode = value; }
            get { return _czqcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dZQDate
        {
            set { _dzqdate = value; }
            get { return _dzqdate; }
        }
        #endregion Model

    }
}

