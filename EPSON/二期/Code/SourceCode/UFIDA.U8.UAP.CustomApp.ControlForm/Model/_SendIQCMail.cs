using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _SendIQCMail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _SendIQCMail
    {
        public _SendIQCMail()
        { }
        #region Model
        private int _iid;
        private string _mailaddress;
        private string _mailsubject;
        private string _mailtext;
        private string _mailadjunct;
        private DateTime? _dtmcreate;
        private string _uidcreate;
        private string _iqcno;
        private bool _issend;
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
        public string MailAddress
        {
            set { _mailaddress = value; }
            get { return _mailaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MailSubject
        {
            set { _mailsubject = value; }
            get { return _mailsubject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MailText
        {
            set { _mailtext = value; }
            get { return _mailtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MailAdjunct
        {
            set { _mailadjunct = value; }
            get { return _mailadjunct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UidCreate
        {
            set { _uidcreate = value; }
            get { return _uidcreate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IQCNo
        {
            set { _iqcno = value; }
            get { return _iqcno; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool issend
        {
            set { _issend = value; }
            get { return _issend; }
        }

        #endregion Model

    }
}

