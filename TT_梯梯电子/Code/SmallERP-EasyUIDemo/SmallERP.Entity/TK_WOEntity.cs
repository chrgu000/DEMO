using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_WOEntity
    {
        private int _iid;
        private Guid _guid;
        private string _sversion;
        private string _swono;
        private DateTime? _ddate;
        private string _spartid;
        private decimal _fqty;
        private decimal? _fopenqty;
        private DateTime _dtmduedate;
        private string _sproductgroup;
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
        public string sWONo
        {
            set { _swono = value; }
            get { return _swono; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sPartID
        {
            set { _spartid = value; }
            get { return _spartid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal fQTY
        {
            set { _fqty = value; }
            get { return _fqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fOpenQTY
        {
            set { _fopenqty = value; }
            get { return _fopenqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmDuedate
        {
            set { _dtmduedate = value; }
            get { return _dtmduedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sProductGroup
        {
            set { _sproductgroup = value; }
            get { return _sproductgroup; }
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
