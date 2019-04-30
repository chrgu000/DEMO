using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _CustomerFeedback:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _CustomerFeedback
    {
        public _CustomerFeedback()
        { }
        #region Model
        private string _customerfeedback;
        /// <summary>
        /// 
        /// </summary>
        public string CustomerFeedback
        {
            set { _customerfeedback = value; }
            get { return _customerfeedback; }
        }
        #endregion Model

    }
}

