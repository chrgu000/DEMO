using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _QCCost:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _QCCost
    {
        public _QCCost()
        { }
        #region Model
        private string _会计期间;
        private string _部门;
        private string _产品编码;
        private decimal? _工时;
        private decimal? _能源;
        private decimal? _工资;
        private decimal? _制造费用;
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
        public string 产品编码
        {
            set { _产品编码 = value; }
            get { return _产品编码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 工时
        {
            set { _工时 = value; }
            get { return _工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 能源
        {
            set { _能源 = value; }
            get { return _能源; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 工资
        {
            set { _工资 = value; }
            get { return _工资; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 制造费用
        {
            set { _制造费用 = value; }
            get { return _制造费用; }
        }
        #endregion Model

    }
}

