using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// SA_QuoDetails_extradefine:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SA_QuoDetails_extradefine
    {
        public SA_QuoDetails_extradefine()
        { }
        #region Model
        private long _autoid;
        private string _cbdefine4;
        private decimal? _cbdefine5;
        /// <summary>
        /// 
        /// </summary>
        public long AutoID
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbdefine4
        {
            set { _cbdefine4 = value; }
            get { return _cbdefine4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cbdefine5
        {
            set { _cbdefine5 = value; }
            get { return _cbdefine5; }
        }
        #endregion Model

    }
}

