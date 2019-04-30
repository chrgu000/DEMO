using System;
namespace Base.Model
{
    /// <summary>
    /// Inventory_History:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Inventory_History
    {
        public Inventory_History()
        { }
        #region Model
        private int _iid;
        private string _cinvcode;
        private string _cinvnameold;
        private string _cinvstdold;
        private string _cinvnamenew;
        private string _cinvstdnew;
        private string _createuid;
        private DateTime? _dtmcreate;
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
        public string cInvCode
        {
            set { _cinvcode = value; }
            get { return _cinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvNameOld
        {
            set { _cinvnameold = value; }
            get { return _cinvnameold; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvStdOld
        {
            set { _cinvstdold = value; }
            get { return _cinvstdold; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvNameNew
        {
            set { _cinvnamenew = value; }
            get { return _cinvnamenew; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvStdNew
        {
            set { _cinvstdnew = value; }
            get { return _cinvstdnew; }
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
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
        #endregion Model

    }
}

