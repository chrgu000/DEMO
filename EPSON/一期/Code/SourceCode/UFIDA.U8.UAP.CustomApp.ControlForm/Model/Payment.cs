using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _Payment:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _Payment
    {
        public _Payment()
        { }
        #region Model
        private string _u8paymenttermcode;
        private string _paymenttermcode;
        private string _remark;
        private string _createruid;
        private DateTime? _createrdate;
        /// <summary>
        /// 
        /// </summary>
        public string U8PaymentTermCode
        {
            set { _u8paymenttermcode = value; }
            get { return _u8paymenttermcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PaymentTermCode
        {
            set { _paymenttermcode = value; }
            get { return _paymenttermcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreaterUid
        {
            set { _createruid = value; }
            get { return _createruid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreaterDate
        {
            set { _createrdate = value; }
            get { return _createrdate; }
        }
        #endregion Model

    }
}

