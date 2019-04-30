using System;
namespace DllForTK.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_BOM_OrderEntity
    {
        private int _iid;
        private string _child;
        private int _orderid;
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
        public string child
        {
            set { _child = value; }
            get { return _child; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int orderid
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
    }
}

