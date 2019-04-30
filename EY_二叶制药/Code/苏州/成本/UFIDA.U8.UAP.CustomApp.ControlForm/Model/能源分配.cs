using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _能源分配:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _能源分配
    {
        public _能源分配()
        { }
        #region Model
        private string _会计期间;
        private string _部门编码;
        private decimal? _供水分配率;
        private decimal? _供水金额;
        private decimal? _供电分配率;
        private decimal? _供电金额;
        private decimal? _供汽分配率;
        private decimal? _供汽金额;
        private decimal? _开利机组冷水机组分配率;
        private decimal? _开利机组冷水机组金额;
        private decimal? _合计;
        private string _制单人;
        private DateTime? _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        private string _记账人;
        private DateTime? _记账日期;
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
        public string 部门编码
        {
            set { _部门编码 = value; }
            get { return _部门编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 供水分配率
        {
            set { _供水分配率 = value; }
            get { return _供水分配率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 供水金额
        {
            set { _供水金额 = value; }
            get { return _供水金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 供电分配率
        {
            set { _供电分配率 = value; }
            get { return _供电分配率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 供电金额
        {
            set { _供电金额 = value; }
            get { return _供电金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 供汽分配率
        {
            set { _供汽分配率 = value; }
            get { return _供汽分配率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 供汽金额
        {
            set { _供汽金额 = value; }
            get { return _供汽金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 开利机组冷水机组分配率
        {
            set { _开利机组冷水机组分配率 = value; }
            get { return _开利机组冷水机组分配率; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 开利机组冷水机组金额
        {
            set { _开利机组冷水机组金额 = value; }
            get { return _开利机组冷水机组金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 合计
        {
            set { _合计 = value; }
            get { return _合计; }
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
        public string 记账人
        {
            set { _记账人 = value; }
            get { return _记账人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 记账日期
        {
            set { _记账日期 = value; }
            get { return _记账日期; }
        }
        #endregion Model

    }
}

