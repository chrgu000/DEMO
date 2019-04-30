using System;
namespace 成衣生产.Model
{
    /// <summary>
    /// 成品出入库:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 成品出入库
    {
        public 成品出入库()
        { }
        #region Model
        private int _iid;
        private int _生产计划iid;
        private DateTime _单据日期;
        private string _出入库类别;
        private string _客户;
        private string _生产;
        private string _类别;
        private string _款号;
        private string _纱种;
        private decimal? _数量;
        private string _质量评定;
        private string _备注;
        private string _制单人;
        private DateTime _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        private string _关闭人;
        private DateTime? _关闭日期;
        private string _变更人;
        private DateTime? _变更日期;
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
        public int 生产计划iID
        {
            set { _生产计划iid = value; }
            get { return _生产计划iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 单据日期
        {
            set { _单据日期 = value; }
            get { return _单据日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 出入库类别
        {
            set { _出入库类别 = value; }
            get { return _出入库类别; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 客户
        {
            set { _客户 = value; }
            get { return _客户; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 生产
        {
            set { _生产 = value; }
            get { return _生产; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 类别
        {
            set { _类别 = value; }
            get { return _类别; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 款号
        {
            set { _款号 = value; }
            get { return _款号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 纱种
        {
            set { _纱种 = value; }
            get { return _纱种; }
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
        public string 质量评定
        {
            set { _质量评定 = value; }
            get { return _质量评定; }
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
        public string 制单人
        {
            set { _制单人 = value; }
            get { return _制单人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 制单日期
        {
            set { _制单日期 = value; }
            get { return _制单日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 审核人
        {
            set { _审核人 = value; }
            get { return _审核人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 审核日期
        {
            set { _审核日期 = value; }
            get { return _审核日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 关闭人
        {
            set { _关闭人 = value; }
            get { return _关闭人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 关闭日期
        {
            set { _关闭日期 = value; }
            get { return _关闭日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 变更人
        {
            set { _变更人 = value; }
            get { return _变更人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 变更日期
        {
            set { _变更日期 = value; }
            get { return _变更日期; }
        }
        #endregion Model

    }
}

