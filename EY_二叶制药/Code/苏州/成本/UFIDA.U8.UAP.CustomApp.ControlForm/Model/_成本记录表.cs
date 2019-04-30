using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _成本记录表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _成本记录表
    {
        public _成本记录表()
        { }
        #region Model
        private string _单据号;
        private DateTime? _单据日期;
        private string _部门编码;
        private string _存货编码;
        private decimal _数量;
        private decimal? _单价;
        private decimal? _金额;
        private string _单据类型;
        private decimal? _料;
        private decimal? _部门分摊;
        private decimal? _公用分摊;
        private string _计算时间;
        private decimal? _产品总数;
        private long? _id;
        private long _autoid;
        private string _收发类别;
        private string _会计期间;
        private string _制单人;
        private DateTime? _制单日期;
        /// <summary>
        /// 
        /// </summary>
        public string 单据号
        {
            set { _单据号 = value; }
            get { return _单据号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 单据日期
        {
            set { _单据日期 = value; }
            get { return _单据日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 部门编码
        {
            set { _部门编码 = value; }
            get { return _部门编码; }
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
        public decimal 数量
        {
            set { _数量 = value; }
            get { return _数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 单价
        {
            set { _单价 = value; }
            get { return _单价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 金额
        {
            set { _金额 = value; }
            get { return _金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 单据类型
        {
            set { _单据类型 = value; }
            get { return _单据类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 料
        {
            set { _料 = value; }
            get { return _料; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 部门分摊
        {
            set { _部门分摊 = value; }
            get { return _部门分摊; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 公用分摊
        {
            set { _公用分摊 = value; }
            get { return _公用分摊; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 计算时间
        {
            set { _计算时间 = value; }
            get { return _计算时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 产品总数
        {
            set { _产品总数 = value; }
            get { return _产品总数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long autoid
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 收发类别
        {
            set { _收发类别 = value; }
            get { return _收发类别; }
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
        public string 制单人
        {
            set { _制单人 = value; }
            get { return _制单人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 制单日期
        {
            set { _制单日期 = value; }
            get { return _制单日期; }
        }
        #endregion Model

    }
}

