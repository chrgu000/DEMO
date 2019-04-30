using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _AQLInspectionLevel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _AQLInspectionLevel
    {
        public _AQLInspectionLevel()
        { }
        #region Model
        private long _iid;
        private decimal? _minqty;
        private decimal? _maxqty;
        private string _level1;
        private string _level2;
        private string _level3;
        /// <summary>
        /// 
        /// </summary>
        public long iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? minQty
        {
            set { _minqty = value; }
            get { return _minqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? maxQty
        {
            set { _maxqty = value; }
            get { return _maxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Level1
        {
            set { _level1 = value; }
            get { return _level1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Level2
        {
            set { _level2 = value; }
            get { return _level2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Level3
        {
            set { _level3 = value; }
            get { return _level3; }
        }
        #endregion Model

    }
}

