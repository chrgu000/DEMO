using System;
namespace TH.Model
{
    /// <summary>
    /// 生产订单工艺路线:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 生产订单工艺路线
    {
        public 生产订单工艺路线()
        { }
        #region Model
        private string _生产订单号;
        private string _单据id;
        private int _单据明细id;
        private string _存货编码;
        private string _工艺路线版本;
        private string _备注;
        private string _updatauid;
        private DateTime? _updatadate;
        private string _createuid;
        private DateTime? _createdate;
        /// <summary>
        /// 
        /// </summary>
        public string 生产订单号
        {
            set { _生产订单号 = value; }
            get { return _生产订单号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 单据ID
        {
            set { _单据id = value; }
            get { return _单据id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int 单据明细ID
        {
            set { _单据明细id = value; }
            get { return _单据明细id; }
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
        public string 工艺路线版本
        {
            set { _工艺路线版本 = value; }
            get { return _工艺路线版本; }
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
        #endregion Model

    }
}

