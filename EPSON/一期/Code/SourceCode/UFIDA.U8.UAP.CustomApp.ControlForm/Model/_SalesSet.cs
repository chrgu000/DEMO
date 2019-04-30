using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _SalesSet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _SalesSet
    {
        public _SalesSet()
        { }
        #region Model
        private int? _iid;
        private string _creater;
        private DateTime? _createdate;
        private string _salestype;
        private string _headtext;
        private string _glcode;
        private string _internalorder;
        private string _profitcenter;
        private string _itemtext;
        private string _itemtext2;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int? iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creater
        {
            set { _creater = value; }
            get { return _creater; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SalesType
        {
            set { _salestype = value; }
            get { return _salestype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Headtext
        {
            set { _headtext = value; }
            get { return _headtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GLCode
        {
            set { _glcode = value; }
            get { return _glcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Internalorder
        {
            set { _internalorder = value; }
            get { return _internalorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProfitCenter
        {
            set { _profitcenter = value; }
            get { return _profitcenter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ItemText
        {
            set { _itemtext = value; }
            get { return _itemtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ItemText2
        {
            set { _itemtext2 = value; }
            get { return _itemtext2; }
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

