using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _部门费用登记:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _部门费用登记
    {
        public _部门费用登记()
        { }
        #region Model
        private string _费用类型;
        private string _会计期间;
        private string _部门;
        private decimal? _金额;
        private string _备注;
        private string _制单人;
        private DateTime? _制单日期;
        private string _修改人;
        private DateTime? _修改日期;
        private string _审核人;
        private DateTime? _审核日期;
        private string _记账人;
        private DateTime? _记账日期;
        /// <summary>
        /// 
        /// </summary>
        public string 费用类型
        {
            set { _费用类型 = value; }
            get { return _费用类型; }
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
        public string 部门
        {
            set { _部门 = value; }
            get { return _部门; }
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
        public DateTime? 制单日期
        {
            set { _制单日期 = value; }
            get { return _制单日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 修改人
        {
            set { _修改人 = value; }
            get { return _修改人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 修改日期
        {
            set { _修改日期 = value; }
            get { return _修改日期; }
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

