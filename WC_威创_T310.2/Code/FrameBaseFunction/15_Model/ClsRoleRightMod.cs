using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction.Model
{
    class ClsRoleRightMod
    {
        public ClsRoleRightMod()
        { }

        #region Model
        private Guid _guid;
        private string _vchrroleid;
        private string _vchrroleright;
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
        public string vchrRoleID
        {
            set { _vchrroleid = value; }
            get { return _vchrroleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vchrRoleRight
        {
            set { _vchrroleright = value; }
            get { return _vchrroleright; }
        }
        #endregion Model
    }
}
