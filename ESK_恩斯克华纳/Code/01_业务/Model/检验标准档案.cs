using System;
namespace 业务.Model
{
    /// <summary>
    /// 检验标准档案:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 检验标准档案
    {
        public 检验标准档案()
        { }
        #region Model
        private long _iid;
        private int _发射器id;
        private string _量具品名;
        private string _测定项目;
        private string _规格;
        private string _测定项目日文;
        private string _尺寸公差;
        private decimal? _下限;
        private decimal? _上限;
        private string _备注;
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
        public int 发射器ID
        {
            set { _发射器id = value; }
            get { return _发射器id; }
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
        public string 规格
        {
            set { _规格 = value; }
            get { return _规格; }
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
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        #endregion Model

    }
}

