using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _高开返利单:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _高开返利单_SZ
    {
        public _高开返利单_SZ()
        { }
        #region Model
        private int _iid;
        private string _ccode;
        private DateTime? _dtmdate;
        private int? _fpids;
        private string _csbvcode;
        private DateTime? _ddate;
        private string _cpersoncode;
        private string _cpersonname;
        private string _cdepcode;
        private string _cdepname;
        private string _ccuscode;
        private string _ccusname;
        private string _ccusabbname;
        private string _cinvcode;
        private string _cinvaddcode;
        private string _cinvname;
        private string _cinvstd;
        private decimal? _itaxunitprice;
        private decimal? _iquantity;
        private decimal? _isum;
        private string _cdlcode;
        private decimal? _itaxunitpricefh;
        private decimal? _itaxratecj;
        private decimal? _itaxcj;
        private decimal? _imoneyfl;
        private string _createuid;
        private DateTime? _dtmcreate;
        private string _audituid;
        private DateTime? _dtmaudit;
        private string _remark;
        private string _dls;
        private string _dlsname;
        private string _guid;
        private bool? _bred;


        /// <summary>
        /// 
        /// </summary>
        public bool? bRed
        {
            set { _bred = value; }
            get { return _bred; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
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
        public DateTime? dtmDate
        {
            set { _dtmdate = value; }
            get { return _dtmdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FPIDs
        {
            set { _fpids = value; }
            get { return _fpids; }
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
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
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
        public string cPersonName
        {
            set { _cpersonname = value; }
            get { return _cpersonname; }
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
        public string cDepName
        {
            set { _cdepname = value; }
            get { return _cdepname; }
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
        public string cCusName
        {
            set { _ccusname = value; }
            get { return _ccusname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusAbbName
        {
            set { _ccusabbname = value; }
            get { return _ccusabbname; }
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
        public string cInvAddCode
        {
            set { _cinvaddcode = value; }
            get { return _cinvaddcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvName
        {
            set { _cinvname = value; }
            get { return _cinvname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvStd
        {
            set { _cinvstd = value; }
            get { return _cinvstd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxUnitPrice
        {
            set { _itaxunitprice = value; }
            get { return _itaxunitprice; }
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
        public decimal? iSum
        {
            set { _isum = value; }
            get { return _isum; }
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
        public decimal? iTaxUnitPriceFH
        {
            set { _itaxunitpricefh = value; }
            get { return _itaxunitpricefh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxRateCJ
        {
            set { _itaxratecj = value; }
            get { return _itaxratecj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxCJ
        {
            set { _itaxcj = value; }
            get { return _itaxcj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iMoneyFL
        {
            set { _imoneyfl = value; }
            get { return _imoneyfl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createUid
        {
            set { _createuid = value; }
            get { return _createuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string auditUid
        {
            set { _audituid = value; }
            get { return _audituid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmAudit
        {
            set { _dtmaudit = value; }
            get { return _dtmaudit; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DLS
        {
            set { _dls = value; }
            get { return _dls; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DLSName
        {
            set { _dlsname = value; }
            get { return _dlsname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sGUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        #endregion Model

    }
}

