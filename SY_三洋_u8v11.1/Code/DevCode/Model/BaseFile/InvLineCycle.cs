using System;
namespace TH.Model
{
    /// <summary>
    /// InvLineCycle:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class InvLineCycle
    {
        public InvLineCycle()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private string _createuid;
        private DateTime? _createdate;
        private string _updateuid;
        private DateTime? _updatedate;
        private string _closeuid;
        private DateTime? _closedate;
        private string _cinvcode;
        private string _lineno;
        private int? _purchasecycle;
        private int? _proxyforeigncycle;
        private decimal? _selfcycle;
        private int? _selfcycleb;
        private decimal? _selfsetupcycle;
        private bool _priority;
        private int? _qualitycycle;
        private int? _selfcapacity;
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
        public string CreateUid
        {
            set { _createuid = value; }
            get { return _createuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUid
        {
            set { _updateuid = value; }
            get { return _updateuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CloseUid
        {
            set { _closeuid = value; }
            get { return _closeuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseDate
        {
            set { _closedate = value; }
            get { return _closedate; }
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
        /// 产线编号
        /// </summary>
        public string LineNo
        {
            set { _lineno = value; }
            get { return _lineno; }
        }
        /// <summary>
        /// 采购周期
        /// </summary>
        public int? PurchaseCycle
        {
            set { _purchasecycle = value; }
            get { return _purchasecycle; }
        }
        /// <summary>
        /// 委外周期
        /// </summary>
        public int? ProxyForeignCycle
        {
            set { _proxyforeigncycle = value; }
            get { return _proxyforeigncycle; }
        }
        /// <summary>
        /// 单件生产工时
        /// </summary>
        public decimal? SelfCycle
        {
            set { _selfcycle = value; }
            get { return _selfcycle; }
        }
        /// <summary>
        /// 单件生产工时基数
        /// </summary>
        public int? SelfCycleB
        {
            set { _selfcycleb = value; }
            get { return _selfcycleb; }
        }
        /// <summary>
        /// 生产准备时间
        /// </summary>
        public decimal? SelfSetupCycle
        {
            set { _selfsetupcycle = value; }
            get { return _selfsetupcycle; }
        }
        /// <summary>
        /// 是否默认产线
        /// </summary>
        public bool Priority
        {
            set { _priority = value; }
            get { return _priority; }
        }
        /// <summary>
        /// 质检周期
        /// </summary>
        public int? QualityCycle
        {
            set { _qualitycycle = value; }
            get { return _qualitycycle; }
        }
        /// <summary>
        /// 产线并发生产数
        /// </summary>
        public int? SelfCapacity
        {
            set { _selfcapacity = value; }
            get { return _selfcapacity; }
        }
        #endregion Model

    }
}

