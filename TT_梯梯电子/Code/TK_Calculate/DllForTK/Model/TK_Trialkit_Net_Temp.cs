using System;
namespace DllForTK.Model
{
    /// <summary>
    /// TK_Trialkit_Net_Temp:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TK_Trialkit_Net_Temp
    {
        public TK_Trialkit_Net_Temp()
        { }
        #region Model
        private int _iid;
        private string _stkversion;
        private int _stkversiontype;
        private string _partid;
        private decimal _netqty;
        private DateTime _ddate;
        private string _protype;
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
        public string sTKVersion
        {
            set { _stkversion = value; }
            get { return _stkversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sTKVersionType
        {
            set { _stkversiontype = value; }
            get { return _stkversiontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PartID
        {
            set { _partid = value; }
            get { return _partid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal NetQty
        {
            set { _netqty = value; }
            get { return _netqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProType
        {
            set { _protype = value; }
            get { return _protype; }
        }
        #endregion Model

    }
}

