using System;
namespace TH.Model
{
    /// <summary>
    /// _BaseDataList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _BaseDataList
    {
        public _BaseDataList()
        { }
        #region Model
        private long _iid;
        private byte[] _guid;
        private string _stype;
        private string _scode;
        private string _stext;
        private string _stexten;
        private string _stext2;
        private string _stext3;
        private string _stext4;
        private string _stext5;
        private string _sremark;
        private string _sremark2;
        private string _sremark3;
        private string _sremark4;
        private string _sremark5;
        private string _createuid;
        private DateTime _createdate;
        private string _updateuid;
        private DateTime? _updatedate;
        private string _closeuid;
        private DateTime? _closedate;
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
        public byte[] Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sType
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sCode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sText
        {
            set { _stext = value; }
            get { return _stext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sTextEn
        {
            set { _stexten = value; }
            get { return _stexten; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sText2
        {
            set { _stext2 = value; }
            get { return _stext2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sText3
        {
            set { _stext3 = value; }
            get { return _stext3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sText4
        {
            set { _stext4 = value; }
            get { return _stext4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sText5
        {
            set { _stext5 = value; }
            get { return _stext5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark
        {
            set { _sremark = value; }
            get { return _sremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark2
        {
            set { _sremark2 = value; }
            get { return _sremark2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark3
        {
            set { _sremark3 = value; }
            get { return _sremark3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark4
        {
            set { _sremark4 = value; }
            get { return _sremark4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark5
        {
            set { _sremark5 = value; }
            get { return _sremark5; }
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
        public string CloseUid
        {
            set { _closeuid = value; }
            get { return _closeuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseDate
        {
            set { _closedate = value; }
            get { return _closedate; }
        }
        #endregion Model

    }
}

