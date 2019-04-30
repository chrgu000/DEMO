using System;
namespace TH.clsU8.Model
{
    /// <summary>
    /// SO_SODetails_extradefine:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SO_SODetails_extradefine
    {
        public SO_SODetails_extradefine()
        { }
        #region Model
        private long _isosid;
        private DateTime? _cbdefine1;
        private DateTime? _cbdefine2;
        /// <summary>
        /// 
        /// </summary>
        public long iSOsID
        {
            set { _isosid = value; }
            get { return _isosid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cbdefine1
        {
            set { _cbdefine1 = value; }
            get { return _cbdefine1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cbdefine2
        {
            set { _cbdefine2 = value; }
            get { return _cbdefine2; }
        }
        #endregion Model

    }
}

