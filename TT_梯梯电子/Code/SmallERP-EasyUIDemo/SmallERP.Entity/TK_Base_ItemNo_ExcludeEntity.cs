using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_Base_ItemNo_ExcludeEntity
    {
        private int _iid;
        private string _sitemno;
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
        public string sItemNo
        {
            set { _sitemno = value; }
            get { return _sitemno; }
        }
    }
}
