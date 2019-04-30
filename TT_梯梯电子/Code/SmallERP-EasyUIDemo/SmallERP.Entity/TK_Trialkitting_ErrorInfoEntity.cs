using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_Trialkitting_ErrorInfoEntity
    {
        private int _iid;
        private string _stkversion;
        private string _serr;
        /// <summary>
        /// 
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 计算版本
        /// </summary>
        public string sTKVersion
        {
            set { _stkversion = value; }
            get { return _stkversion; }
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string sErr
        {
            set { _serr = value; }
            get { return _serr; }
        }
    }
}
