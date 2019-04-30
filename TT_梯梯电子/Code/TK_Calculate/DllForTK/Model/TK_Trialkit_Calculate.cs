using System;
namespace DllForTK.Model
{
    /// <summary>
    /// TK_Trialkit_Calculate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TK_Trialkit_Calculate
    {
        public TK_Trialkit_Calculate()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private string _stkversion;
        private string _stkversiontype;
        private string _sdataversion;
        private long? _iid_netrequirement_sum;
        private string _toplevel;
        private decimal? _qty_toplevel;
        private DateTime? _ddate_toplevel;
        private string _sproductgroup;
        private string _child;
        private int? _childcycle;
        private int? _childscycle;
        private decimal? _qty_bom;
        private decimal? _cumqty_bom;
        private string _childsm;
        private int _depth;
        private decimal _qtychild;
        private DateTime? _dtmstart;
        private DateTime? _dtmend;
        private string _createuid;
        private DateTime? _dtmcreate;
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
        public Guid GUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sTKVersion
        {
            set { _stkversion = value; }
            get { return _stkversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sTKVersionType
        {
            set { _stkversiontype = value; }
            get { return _stkversiontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sDataVersion
        {
            set { _sdataversion = value; }
            get { return _sdataversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iID_NetRequirement_Sum
        {
            set { _iid_netrequirement_sum = value; }
            get { return _iid_netrequirement_sum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string toplevel
        {
            set { _toplevel = value; }
            get { return _toplevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty_toplevel
        {
            set { _qty_toplevel = value; }
            get { return _qty_toplevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dDate_toplevel
        {
            set { _ddate_toplevel = value; }
            get { return _ddate_toplevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sProductGroup
        {
            set { _sproductgroup = value; }
            get { return _sproductgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string child
        {
            set { _child = value; }
            get { return _child; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? childCycle
        {
            set { _childcycle = value; }
            get { return _childcycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? childsCycle
        {
            set { _childscycle = value; }
            get { return _childscycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty_bom
        {
            set { _qty_bom = value; }
            get { return _qty_bom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cumqty_bom
        {
            set { _cumqty_bom = value; }
            get { return _cumqty_bom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string childsm
        {
            set { _childsm = value; }
            get { return _childsm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal qtyChild
        {
            set { _qtychild = value; }
            get { return _qtychild; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmStart
        {
            set { _dtmstart = value; }
            get { return _dtmstart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmEnd
        {
            set { _dtmend = value; }
            get { return _dtmend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUid
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
        #endregion Model

    }
}

