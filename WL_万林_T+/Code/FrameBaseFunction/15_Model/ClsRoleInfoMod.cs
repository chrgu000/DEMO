using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction.Model
{
    public class ClsRoleInfoMod
    {
        public ClsRoleInfoMod()
        { }
        #region Model
        private string _vchrroleid;
        private string _vchrroletext;
        private string _vchrremark;
        private bool _bclosed;
        private DateTime _dtmcreate;
        /// <summary>
        /// 
        /// </summary>
        public string vchrRoleID
        {
            set { _vchrroleid = value; }
            get { return _vchrroleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vchrRoleText
        {
            set { _vchrroletext = value; }
            get { return _vchrroletext; }
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
        public bool bClosed
        {
            set { _bclosed = value; }
            get { return _bclosed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
        #endregion Model
    }
}

