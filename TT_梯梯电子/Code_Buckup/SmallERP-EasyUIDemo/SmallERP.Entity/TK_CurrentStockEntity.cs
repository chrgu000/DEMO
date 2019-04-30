using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_CurrentStockEntity
    {
        private int _iid;
        private Guid _guid;
        private string _sversion;
        private string _warehouse;
        private string _locationid;
        private string _sitemno;
        private decimal? _dqty;
        private string _spreparedby;
        private DateTime? _dtmpreparedby;
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
        public Guid Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sVersion
        {
            set { _sversion = value; }
            get { return _sversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Warehouse
        {
            set { _warehouse = value; }
            get { return _warehouse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LocationID
        {
            set { _locationid = value; }
            get { return _locationid; }
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
        public decimal? dQty
        {
            set { _dqty = value; }
            get { return _dqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sPreparedBy
        {
            set { _spreparedby = value; }
            get { return _spreparedby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmPreparedBy
        {
            set { _dtmpreparedby = value; }
            get { return _dtmpreparedby; }
        }
    }
}
