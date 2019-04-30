using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _车间材料领用汇总月报:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _车间材料领用汇总月报
    {
        public _车间材料领用汇总月报()
        { }
        #region Model
        private string _会计期间;
        private string _部门编码;
        private string _产品编码;
        private string _材料编码;
        private decimal? _月初存料数量;
        private decimal? _月初存料单价;
        private decimal? _月初存料金额;
        private decimal? _收发存汇总出库数量;
        private decimal? _收发存汇总出库单价;
        private decimal? _收发存汇总出库金额;
        private decimal? _月末结存数量;
        private decimal? _月末结存单价;
        private decimal? _月末结存金额;
        private decimal? _本月耗用数量;
        private decimal? _本月耗用单价;
        private decimal? _本月耗用金额;
        private decimal? _产品数量;
        private decimal? _产品单价;
        private decimal? _产品金额;
        private string _createuid;
        private DateTime? _createdate;
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
        public string 产品编码
        {
            set { _产品编码 = value; }
            get { return _产品编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 材料编码
        {
            set { _材料编码 = value; }
            get { return _材料编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 月初存料数量
        {
            set { _月初存料数量 = value; }
            get { return _月初存料数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 月初存料单价
        {
            set { _月初存料单价 = value; }
            get { return _月初存料单价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 月初存料金额
        {
            set { _月初存料金额 = value; }
            get { return _月初存料金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 收发存汇总出库数量
        {
            set { _收发存汇总出库数量 = value; }
            get { return _收发存汇总出库数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 收发存汇总出库单价
        {
            set { _收发存汇总出库单价 = value; }
            get { return _收发存汇总出库单价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 收发存汇总出库金额
        {
            set { _收发存汇总出库金额 = value; }
            get { return _收发存汇总出库金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 月末结存数量
        {
            set { _月末结存数量 = value; }
            get { return _月末结存数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 月末结存单价
        {
            set { _月末结存单价 = value; }
            get { return _月末结存单价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 月末结存金额
        {
            set { _月末结存金额 = value; }
            get { return _月末结存金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 本月耗用数量
        {
            set { _本月耗用数量 = value; }
            get { return _本月耗用数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 本月耗用单价
        {
            set { _本月耗用单价 = value; }
            get { return _本月耗用单价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 本月耗用金额
        {
            set { _本月耗用金额 = value; }
            get { return _本月耗用金额; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 产品数量
        {
            set { _产品数量 = value; }
            get { return _产品数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 产品单价
        {
            set { _产品单价 = value; }
            get { return _产品单价; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 产品金额
        {
            set { _产品金额 = value; }
            get { return _产品金额; }
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

