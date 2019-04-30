using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _ProMaterial:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _ProMaterial
    {
        public _ProMaterial()
        { }
        #region Model
        private int _iid;
        private string _会计期间;
        private string _部门;
        private string _产品编码;
        private string _存货编码;
        private decimal _数量;
        private string _制单人;
        private DateTime _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        private decimal? _工时;
        private decimal? _未完工工时;
        private decimal? _冻干完工工时;
        private decimal? _冻干未完工工时;
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
        public decimal? 工时
        {
            set { _工时 = value; }
            get { return _工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 未完工工时
        {
            set { _未完工工时 = value; }
            get { return _未完工工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 冻干完工工时
        {
            set { _冻干完工工时 = value; }
            get { return _冻干完工工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 冻干未完工工时
        {
            set { _冻干未完工工时 = value; }
            get { return _冻干未完工工时; }
        }
        #endregion Model

    }
}