using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_Base_ItemNo_CycleEntity
    {
        private int _iid;
        private string _sitemno;
        private int? _icycle;
        private string _remark;
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
        /// <summary>
        /// 
        /// </summary>
        public int? iCycle
        {
            set { _icycle = value; }
            get { return _icycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
    }
}
