using System;
namespace TH.Model
{
    /// <summary>
    /// _产品工序流转统计:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _产品工序流转统计
    {
        public _产品工序流转统计()
        { }
        #region Model
        private int _iid;
        private string _存货编码;
        private DateTime _期间;
        private decimal? _期初数量;
        private decimal? _期初金额;
        private decimal? _领用数量;
        private decimal? _领用金额;
        private decimal? _完工数量;
        private decimal? _完工金额;
        private decimal? _在制数量;
        private decimal? _在制金额;
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
        public string 存货编码
        {
            set { _存货编码 = value; }
            get { return _存货编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 期间
        {
            set { _期间 = value; }
            get { return _期间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 期初数量
        {
            set { _期初数量 = value; }
            get { return _期初数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 期初金额
        {
            set { _期初金额 = value; }
            get { return _期初金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 领用数量
        {
            set { _领用数量 = value; }
            get { return _领用数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 领用金额
        {
            set { _领用金额 = value; }
            get { return _领用金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 完工数量
        {
            set { _完工数量 = value; }
            get { return _完工数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 完工金额
        {
            set { _完工金额 = value; }
            get { return _完工金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 在制数量
        {
            set { _在制数量 = value; }
            get { return _在制数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 在制金额
        {
            set { _在制金额 = value; }
            get { return _在制金额; }
        }
        #endregion Model

    }
}

