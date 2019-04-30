using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _AQLLevelMap:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _AQLLevelMap
    {
        public _AQLLevelMap()
        { }
        #region Model
        private long _iid;
        private string _codeletter;
        private decimal _aqllevel;
        private decimal? _accept;
        private decimal? _reject;
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
        public string CodeLetter
        {
            set { _codeletter = value; }
            get { return _codeletter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AQLLevel
        {
            set { _aqllevel = value; }
            get { return _aqllevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Accept
        {
            set { _accept = value; }
            get { return _accept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Reject
        {
            set { _reject = value; }
            get { return _reject; }
        }
        #endregion Model

    }
}

