using System;
namespace TH.Model
{
    /// <summary>
    /// ProductionLinePeopleNO:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductionLinePeopleNO
    {
        public ProductionLinePeopleNO()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private string _createuid;
        private DateTime? _createdate;
        private string _updateuid;
        private DateTime? _updatedate;
        private string _lineno = "newid";
        private DateTime _ddate;
        private int? _peopleno;
        private string _remark;
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
        public Guid GUID
        {
            set { _guid = value; }
            get { return _guid; }
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
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUid
        {
            set { _updateuid = value; }
            get { return _updateuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineNO
        {
            set { _lineno = value; }
            get { return _lineno; }
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
        public int? PeopleNO
        {
            set { _peopleno = value; }
            get { return _peopleno; }
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

