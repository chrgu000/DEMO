using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _DSSaleBaseInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _DSSaleBaseInfo
    {
        public _DSSaleBaseInfo()
        { }
        #region Model
        private string _cstcode;
        private bool _bds;
        /// <summary>
        /// 
        /// </summary>
        public string cSTCode
        {
            set { _cstcode = value; }
            get { return _cstcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bDS
        {
            set { _bds = value; }
            get { return _bds; }
        }
        #endregion Model

    }
}

