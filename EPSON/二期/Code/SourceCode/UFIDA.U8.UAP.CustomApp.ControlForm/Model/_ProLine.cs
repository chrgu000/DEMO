using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _ProLine:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _ProLine
    {
        public _ProLine()
        { }
        #region Model
        private int _iid;
        private string _ccode;
        private string _cname;
        private string _remark1;
        private string _remark2;
        private string _remark3;
        private string _remark4;
        private string _remark5;
        private string _creater;
        private DateTime? _createdate;
        private string _updateuid;
        private DateTime? _updatedate;
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
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark1
        {
            set { _remark1 = value; }
            get { return _remark1; }
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
        #endregion Model

    }
}

