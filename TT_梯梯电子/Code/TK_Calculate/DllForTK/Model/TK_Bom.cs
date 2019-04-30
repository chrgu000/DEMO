using System;
namespace DllForTK.Model
{
    /// <summary>
    /// TK_BOM:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TK_BOM
    {
        public TK_BOM()
        { }
        #region Model
        private int _iid;
        private string _depth;
        private string _toplevel;
        private string _parent;
        private string _child;
        private decimal? _qty;
        private decimal? _cumqty;
        private string _childsm;
        private string _topprodgroup;
        private int? _commonparts;
        private bool _exclude = false;
        private int? _childcycle;
        private int? _childscycle;
        private int? _depths;
        private string _sdataversion;
        private bool _bdel = false;
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
        public string depth
        {
            set { _depth = value; }
            get { return _depth; }
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
        public string parent
        {
            set { _parent = value; }
            get { return _parent; }
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
        public decimal? qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumqty
        {
            set { _cumqty = value; }
            get { return _cumqty; }
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
        public string topprodgroup
        {
            set { _topprodgroup = value; }
            get { return _topprodgroup; }
        }
        /// <summary>
        /// Toplevel 共用件公用次数，通过存储过程计算获得
        /// </summary>
        public int? CommonParts
        {
            set { _commonparts = value; }
            get { return _commonparts; }
        }
        /// <summary>
        /// 不参与运算的物料
        /// </summary>
        public bool Exclude
        {
            set { _exclude = value; }
            get { return _exclude; }
        }
        /// <summary>
        /// child 加工周期/采购周期
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
        /// BOM低阶码
        /// </summary>
        public int? depths
        {
            set { _depths = value; }
            get { return _depths; }
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
        public bool bDel
        {
            set { _bdel = value; }
            get { return _bdel; }
        }
        #endregion Model

    }
}

