using System;
namespace TH.clsU8.Model
{
    /// <summary>
    /// Ap_CloseBills:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Ap_CloseBills
    {
        public Ap_CloseBills()
        { }
        #region Model
        private long _iid;
        private long _id;
        private long _itype;
        private bool _bprepay = false;
        private string _ccusven;
        private decimal _iamt_f = 0M;
        private decimal _iamt = 0M;
        private decimal _iramt_f = 0M;
        private decimal _iramt = 0M;
        private string _ckm;
        private string _cxmclass;
        private string _cxm;
        private string _cdepcode;
        private string _cpersoncode;
        private string _corderid;
        private string _citemname;
        private string _ccontype;
        private string _cconid;
        private decimal? _iamt_s;
        private decimal? _iramt_s;
        private long? _iordertype;
        private string _cdlcode;
        private string _ccitemcode;
        private long? _registerflag = 0;
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
        private string _cstagecode;
        private string _ccovouchid;
        private string _cexecid;
        private string _cmemo;
        private long? _isrcclosesid = 0;
        private decimal _ifaresettled_f = 0M;
        private string _cebordercode;
        /// <summary>
        /// 
        /// </summary>
        public long iID
        {
            set { _iid = value; }
            get { return _iid; }
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
        public long iType
        {
            set { _itype = value; }
            get { return _itype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bPrePay
        {
            set { _bprepay = value; }
            get { return _bprepay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusVen
        {
            set { _ccusven = value; }
            get { return _ccusven; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iAmt_f
        {
            set { _iamt_f = value; }
            get { return _iamt_f; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iAmt
        {
            set { _iamt = value; }
            get { return _iamt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iRAmt_f
        {
            set { _iramt_f = value; }
            get { return _iramt_f; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iRAmt
        {
            set { _iramt = value; }
            get { return _iramt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cKm
        {
            set { _ckm = value; }
            get { return _ckm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cXmClass
        {
            set { _cxmclass = value; }
            get { return _cxmclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cXm
        {
            set { _cxm = value; }
            get { return _cxm; }
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
        public string cOrderID
        {
            set { _corderid = value; }
            get { return _corderid; }
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
        public string cConType
        {
            set { _ccontype = value; }
            get { return _ccontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cConID
        {
            set { _cconid = value; }
            get { return _cconid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iAmt_s
        {
            set { _iamt_s = value; }
            get { return _iamt_s; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iRAmt_s
        {
            set { _iramt_s = value; }
            get { return _iramt_s; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iOrderType
        {
            set { _iordertype = value; }
            get { return _iordertype; }
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
        public string ccItemCode
        {
            set { _ccitemcode = value; }
            get { return _ccitemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? RegisterFlag
        {
            set { _registerflag = value; }
            get { return _registerflag; }
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
        public string cStageCode
        {
            set { _cstagecode = value; }
            get { return _cstagecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCoVouchID
        {
            set { _ccovouchid = value; }
            get { return _ccovouchid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cExecID
        {
            set { _cexecid = value; }
            get { return _cexecid; }
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
        public long? iSrcClosesID
        {
            set { _isrcclosesid = value; }
            get { return _isrcclosesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ifaresettled_f
        {
            set { _ifaresettled_f = value; }
            get { return _ifaresettled_f; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cEBOrderCode
        {
            set { _cebordercode = value; }
            get { return _cebordercode; }
        }
        #endregion Model

    }
}

