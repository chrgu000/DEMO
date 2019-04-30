using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction.Model
{
    public class ClsUserInfoMod
    {
        public ClsUserInfoMod()
		{}
		#region Model
        private string _vchruid;
        private string _vchrname;
        private string _vchrpwd;
        private string _vchrremark;
        private string _tstamp;
        private DateTime _dtmcreate;
        private DateTime _dtmclose;
        /// <summary>
        /// 
        /// </summary>
        public string vchrUid
        {
            set { _vchruid = value; }
            get { return _vchruid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vchrName
        {
            set { _vchrname = value; }
            get { return _vchrname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vchrPwd
        {
            set { _vchrpwd = value; }
            get { return _vchrpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vchrRemark
        {
            set { _vchrremark = value; }
            get { return _vchrremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tStamp
        {
            set { _tstamp = value; }
            get { return _tstamp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmClose
        {
            set { _dtmclose = value; }
            get { return _dtmclose; }
        }
		#endregion Model
	}
}

