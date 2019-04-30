using System;
namespace TH.Model
{
    /// <summary>
    /// 生产订单中转箱记录:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 生产订单中转箱记录
    {
        public 生产订单中转箱记录()
        { }
        #region Model
        private long _单据id;
        private long _单据明细id;
        private string _箱号;
        private decimal? _数量;
        private string _updatauid;
        private DateTime? _updatadate;
        private string _createuid;
        private DateTime? _createdate;
        private string _closeuid;
        private DateTime? _closedate;
        /// <summary>
        /// 
        /// </summary>
        public long 单据ID
        {
            set { _单据id = value; }
            get { return _单据id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long 单据明细ID
        {
            set { _单据明细id = value; }
            get { return _单据明细id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 箱号
        {
            set { _箱号 = value; }
            get { return _箱号; }
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
        public string UpdataUid
        {
            set { _updatauid = value; }
            get { return _updatauid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdataDate
        {
            set { _updatadate = value; }
            get { return _updatadate; }
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
        #endregion Model

    }
}

