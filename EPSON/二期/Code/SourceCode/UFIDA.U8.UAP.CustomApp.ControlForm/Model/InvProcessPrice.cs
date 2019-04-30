using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _InvProcessPrice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _InvProcessPrice
    {
        public _InvProcessPrice()
        { }
        #region Model
        private int _iid;
        private string _fromworkcenter;
        private string _casetype;
        private decimal _price;
        private string _remark;
        private string _createuid;
        private DateTime? _createdate;
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
        public string FromWorkCenter
        {
            set { _fromworkcenter = value; }
            get { return _fromworkcenter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CaseType
        {
            set { _casetype = value; }
            get { return _casetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
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
        public string CreateUid
        {
            set { _createuid = value; }
            get { return _createuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}

