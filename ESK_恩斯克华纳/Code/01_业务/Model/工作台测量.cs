using System;
namespace 业务.Model
{
    /// <summary>
    /// 工作台测量:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 工作台测量
    {
        public 工作台测量()
        { }
        #region Model
        private int _iid;
        private int _发射器ID;
        private string _工作台;
        private string _班组;
        private string _量具品名;
        private string _测定项目;
        private string _测定项目日文;
        private string _规格;
        private string _尺寸公差;
        private decimal? _下限;
        private decimal? _上限;
        private decimal? _测量值;
        private decimal? _原始值;
        private string _备注;
        private string _检验员;
        private DateTime? _检验时间;
        private string _操作员;
        private DateTime? _操作日期;
        private DateTime? _dtmcreate = DateTime.Now;
        private long? _sourceid;
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
        public int 发射器ID
        {
            set { _发射器ID = value; }
            get { return _发射器ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 工作台
        {
            set { _工作台 = value; }
            get { return _工作台; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 班组
        {
            set { _班组 = value; }
            get { return _班组; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 量具品名
        {
            set { _量具品名 = value; }
            get { return _量具品名; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 测定项目
        {
            set { _测定项目 = value; }
            get { return _测定项目; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 测定项目日文
        {
            set { _测定项目日文 = value; }
            get { return _测定项目日文; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 规格
        {
            set { _规格 = value; }
            get { return _规格; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 尺寸公差
        {
            set { _尺寸公差 = value; }
            get { return _尺寸公差; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 下限
        {
            set { _下限 = value; }
            get { return _下限; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 上限
        {
            set { _上限 = value; }
            get { return _上限; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 测量值
        {
            set { _测量值 = value; }
            get { return _测量值; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 原始值
        {
            set { _原始值 = value; }
            get { return _原始值; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 检验员
        {
            set { _检验员 = value; }
            get { return _检验员; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 检验时间
        {
            set { _检验时间 = value; }
            get { return _检验时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 操作员
        {
            set { _操作员 = value; }
            get { return _操作员; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 操作日期
        {
            set { _操作日期 = value; }
            get { return _操作日期; }
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
        public long? SourceID
        {
            set { _sourceid = value; }
            get { return _sourceid; }
        }
        #endregion Model

    }
}

