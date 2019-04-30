using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _费用分配:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _费用分配
    {
        public _费用分配()
        { }
        #region Model
        private string _会计期间;
        private string _部门编码;
        private decimal? _应摊能源费用;
        private decimal? _应摊工资费用;
        private decimal? _应摊制造费用;
        private decimal? _合计分摊;
        private string _存货编码;
        private decimal? _生产工时;
        private decimal? _冻干工时;
        private decimal? _应摊能源费用行;
        private decimal? _应摊工资费用行;
        private decimal? _应摊制造费用行;
        private decimal? _合计分摊行;
        private int? _行类型;
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
        public decimal? 应摊能源费用
        {
            set { _应摊能源费用 = value; }
            get { return _应摊能源费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 应摊工资费用
        {
            set { _应摊工资费用 = value; }
            get { return _应摊工资费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 应摊制造费用
        {
            set { _应摊制造费用 = value; }
            get { return _应摊制造费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 合计分摊
        {
            set { _合计分摊 = value; }
            get { return _合计分摊; }
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
        public decimal? 生产工时
        {
            set { _生产工时 = value; }
            get { return _生产工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 冻干工时
        {
            set { _冻干工时 = value; }
            get { return _冻干工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 应摊能源费用行
        {
            set { _应摊能源费用行 = value; }
            get { return _应摊能源费用行; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 应摊工资费用行
        {
            set { _应摊工资费用行 = value; }
            get { return _应摊工资费用行; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 应摊制造费用行
        {
            set { _应摊制造费用行 = value; }
            get { return _应摊制造费用行; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 合计分摊行
        {
            set { _合计分摊行 = value; }
            get { return _合计分摊行; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 行类型
        {
            set { _行类型 = value; }
            get { return _行类型; }
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

