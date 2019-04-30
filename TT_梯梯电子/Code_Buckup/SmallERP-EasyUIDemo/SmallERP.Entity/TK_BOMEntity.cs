using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_BOMEntity
    {
        private int? _iid;
        private string _depth;
        private string _toplevel;
        private string _parent;
        private string _child;
        private decimal? _qty;
        private decimal? _cumqty;
        private string _childsm;
        private string _topprodgroup;
        /// <summary>
        /// 
        /// </summary>
        public int? iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string toplevel
        {
            set { _toplevel = value; }
            get { return _toplevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string parent
        {
            set { _parent = value; }
            get { return _parent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string child
        {
            set { _child = value; }
            get { return _child; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cumqty
        {
            set { _cumqty = value; }
            get { return _cumqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string childsm
        {
            set { _childsm = value; }
            get { return _childsm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string topprodgroup
        {
            set { _topprodgroup = value; }
            get { return _topprodgroup; }
        }
    }
}
