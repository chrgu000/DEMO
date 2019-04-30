using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _Action:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _Action
    {
        public _Action()
        { }
        #region Model
        private long _iid;
        private string _actioncode;
        private string _action;
        private string _remark;
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
        public string ActionCode
        {
            set { _actioncode = value; }
            get { return _actioncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Action
        {
            set { _action = value; }
            get { return _action; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

