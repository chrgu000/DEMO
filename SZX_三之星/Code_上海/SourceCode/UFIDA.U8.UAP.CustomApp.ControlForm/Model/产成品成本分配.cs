using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _产品成本分配:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _产品成本分配
    {
        public _产品成本分配()
        { }
        #region Model
        private int _iid;
        private string _会计期间;
        private string _存货分类;
        private decimal? _差异sum;
        private decimal? _间接原价sum;
        private string _存货编码;
        private decimal? _数量;
        private decimal? _原价;
        private decimal? _标准;
        private decimal? _差异;
        private decimal? _间接原价;
        private decimal? _实际成本;
        private string _createuid;
        private DateTime? _createdate;
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
        public string 会计期间
        {
            set { _会计期间 = value; }
            get { return _会计期间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 存货分类
        {
            set { _存货分类 = value; }
            get { return _存货分类; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 差异Sum
        {
            set { _差异sum = value; }
            get { return _差异sum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 间接原价Sum
        {
            set { _间接原价sum = value; }
            get { return _间接原价sum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 存货编码
        {
            set { _存货编码 = value; }
            get { return _存货编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 数量
        {
            set { _数量 = value; }
            get { return _数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 原价
        {
            set { _原价 = value; }
            get { return _原价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 标准
        {
            set { _标准 = value; }
            get { return _标准; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 差异
        {
            set { _差异 = value; }
            get { return _差异; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 间接原价
        {
            set { _间接原价 = value; }
            get { return _间接原价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 实际成本
        {
            set { _实际成本 = value; }
            get { return _实际成本; }
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
        #endregion Model

    }
}

