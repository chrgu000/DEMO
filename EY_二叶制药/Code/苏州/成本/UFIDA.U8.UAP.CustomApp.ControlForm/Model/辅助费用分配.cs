using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _辅助费用分配:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _辅助费用分配
    {
        public _辅助费用分配()
        { }
        #region Model
        private string _会计期间;
        private string _部门编码;
        private decimal? _机修工时;
        private decimal? _机修金额;
        private decimal? _仪表工时;
        private decimal? _仪表金额;
        private decimal? _环保工时;
        private decimal? _环保金额;
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
        public decimal? 机修工时
        {
            set { _机修工时 = value; }
            get { return _机修工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 机修金额
        {
            set { _机修金额 = value; }
            get { return _机修金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 仪表工时
        {
            set { _仪表工时 = value; }
            get { return _仪表工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 仪表金额
        {
            set { _仪表金额 = value; }
            get { return _仪表金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 环保工时
        {
            set { _环保工时 = value; }
            get { return _环保工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 环保金额
        {
            set { _环保金额 = value; }
            get { return _环保金额; }
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

