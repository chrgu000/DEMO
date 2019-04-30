using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_Trialkit_PartTempEntity
    {
        private int _iid;
        private string _stkversion;
        private string _spartid;
        private string _createruid;
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
        /// TK版本号
        /// </summary>
        public string sTKVersion
        {
            set { _stkversion = value; }
            get { return _stkversion; }
        }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string sPartID
        {
            set { _spartid = value; }
            get { return _spartid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreaterUid
        {
            set { _createruid = value; }
            get { return _createruid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
    }
}
