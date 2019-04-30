using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _PurchaseSet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _PurchaseSet
    {
        public _PurchaseSet()
        { }
        #region Model
        private int _iid;
        private string _reasoncode;
        private string _description;
        private string _costcenter;
        private string _costcentredescription;
        private string _glaccountcode;
        private string _glaccountdescription;
        private string _internalorder;
        private string _headtext;
        private string _reasonname;
        private string _creater;
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
        public string ReasonCode
        {
            set { _reasoncode = value; }
            get { return _reasoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CostCenter
        {
            set { _costcenter = value; }
            get { return _costcenter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CostCentreDescription
        {
            set { _costcentredescription = value; }
            get { return _costcentredescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GLAccountCode
        {
            set { _glaccountcode = value; }
            get { return _glaccountcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GLAccountDescription
        {
            set { _glaccountdescription = value; }
            get { return _glaccountdescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InternalOrder
        {
            set { _internalorder = value; }
            get { return _internalorder; }
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
        public string Reasonname
        {
            set { _reasonname = value; }
            get { return _reasonname; }
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
        #endregion Model

    }
}

