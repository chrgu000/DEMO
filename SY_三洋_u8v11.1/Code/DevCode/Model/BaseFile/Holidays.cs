using System;
namespace TH.Model
{
    /// <summary>
    /// Holidays:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Holidays
    {
        public Holidays()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private string _createuid;
        private DateTime _createdate;
        private string _updatauid;
        private DateTime? _updatadate;
        private string _audituid;
        private DateTime? _auditdate;
        private DateTime _dholidays;
        private string _holidaystext;
        private string _remark;
        private string _remark2;
        private string _remark3;
        private string _remark4;
        private string _remark5;
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
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdataUid
        {
            set { _updatauid = value; }
            get { return _updatauid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdataDate
        {
            set { _updatadate = value; }
            get { return _updatadate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditUid
        {
            set { _audituid = value; }
            get { return _audituid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuditDate
        {
            set { _auditdate = value; }
            get { return _auditdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dHolidays
        {
            set { _dholidays = value; }
            get { return _dholidays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HolidaysText
        {
            set { _holidaystext = value; }
            get { return _holidaystext; }
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
        public string Remark2
        {
            set { _remark2 = value; }
            get { return _remark2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark3
        {
            set { _remark3 = value; }
            get { return _remark3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark4
        {
            set { _remark4 = value; }
            get { return _remark4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark5
        {
            set { _remark5 = value; }
            get { return _remark5; }
        }
        #endregion Model

    }
}

