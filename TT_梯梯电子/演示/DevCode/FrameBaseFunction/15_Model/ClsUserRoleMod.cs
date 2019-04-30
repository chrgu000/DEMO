using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction.Model
{
    class ClsUserRoleMod
    {
        public ClsUserRoleMod()
		{}
        #region Model
        private Guid _guid;
        private string _vchruserid;
        private string _vchrroleid;
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
        public string vchrUserID
        {
            set { _vchruserid = value; }
            get { return _vchruserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vchrRoleID
        {
            set { _vchrroleid = value; }
            get { return _vchrroleid; }
        }
        #endregion Model
    }
}
