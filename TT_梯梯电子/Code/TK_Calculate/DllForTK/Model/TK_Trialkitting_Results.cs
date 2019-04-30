using System;
namespace DllForTK.Model
{
    /// <summary>
    /// TK_Trialkitting_Results:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TK_Trialkitting_Results
    {
        public TK_Trialkitting_Results()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private string _stkversion;
        private string _stkversiontype;
        private DateTime? _ddate;
        private string _planner;
        private string _prodgroup;
        private string _cinvcode;
        private decimal? _netqty;
        private string _reorderpolicy;
        private int? _daywo;
        private decimal? _qtycurr;
        private decimal? _qtywo;
        private decimal? _qty;
        private DateTime? _dtmqty;
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
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Planner
        {
            set { _planner = value; }
            get { return _planner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProdGroup
        {
            set { _prodgroup = value; }
            get { return _prodgroup; }
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
        public decimal? NetQty
        {
            set { _netqty = value; }
            get { return _netqty; }
        }
        /// <summary>
        /// MPS/MRP
        /// </summary>
        public string Reorderpolicy
        {
            set { _reorderpolicy = value; }
            get { return _reorderpolicy; }
        }
        /// <summary>
        /// 加工周期
        /// </summary>
        public int? DayWO
        {
            set { _daywo = value; }
            get { return _daywo; }
        }
        /// <summary>
        /// 仓库存量
        /// </summary>
        public decimal? QtyCurr
        {
            set { _qtycurr = value; }
            get { return _qtycurr; }
        }
        /// <summary>
        /// 工单数量
        /// </summary>
        public decimal? QtyWO
        {
            set { _qtywo = value; }
            get { return _qtywo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmQty
        {
            set { _dtmqty = value; }
            get { return _dtmqty; }
        }
        #endregion Model

    }
}

