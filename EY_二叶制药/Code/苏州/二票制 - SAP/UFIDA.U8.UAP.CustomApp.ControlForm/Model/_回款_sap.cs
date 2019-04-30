using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _回款_sap:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _回款_sap
    {
        public _回款_sap()
        { }
        #region Model
        private int _iid;
        private string _收款单号;
        private DateTime? _收款单日期;
        private decimal? _收款单金额;
        private string _业务员编码;
        private string _业务员;
        private decimal? _核销金额;
        private DateTime? _核销日期;
        private string _发票号码;
        private DateTime? _发票日期;
        private string _销售组织;
        private string _客户编码;
        private string _客户名称;
        private decimal? _发票金额;
        private string _货币单位;
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
        public string 收款单号
        {
            set { _收款单号 = value; }
            get { return _收款单号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 收款单日期
        {
            set { _收款单日期 = value; }
            get { return _收款单日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 收款单金额
        {
            set { _收款单金额 = value; }
            get { return _收款单金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 业务员编码
        {
            set { _业务员编码 = value; }
            get { return _业务员编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 业务员
        {
            set { _业务员 = value; }
            get { return _业务员; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 核销金额
        {
            set { _核销金额 = value; }
            get { return _核销金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 核销日期
        {
            set { _核销日期 = value; }
            get { return _核销日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 发票号码
        {
            set { _发票号码 = value; }
            get { return _发票号码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 发票日期
        {
            set { _发票日期 = value; }
            get { return _发票日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售组织
        {
            set { _销售组织 = value; }
            get { return _销售组织; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 客户编码
        {
            set { _客户编码 = value; }
            get { return _客户编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 客户名称
        {
            set { _客户名称 = value; }
            get { return _客户名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 发票金额
        {
            set { _发票金额 = value; }
            get { return _发票金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 货币单位
        {
            set { _货币单位 = value; }
            get { return _货币单位; }
        }
        #endregion Model

    }
}

