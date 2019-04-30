using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _Defects:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _Defects
    {
        public _Defects()
        { }
        #region Model
        private long _iid;
        private string _ccuscode;
        private string _defectcode;
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
        public string cCusCode
        {
            set { _ccuscode = value; }
            get { return _ccuscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DefectCode
        {
            set { _defectcode = value; }
            get { return _defectcode; }
        }
        #endregion Model

    }
}

