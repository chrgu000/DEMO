using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class CycleEntity
    {
        private int _iid;
        private Guid _guid;
        private string _sversion;
        private int? _ipriority;
        private string _spartid;
        private string _splannercode;
        private string _sreorderpolicy;
        private string _sproductgroup;
        private int? _iprocesscycle;
        private decimal? _funfullkit;
        private decimal? _fcurrentstock;
        private decimal? _fwoqty;
        private DateTime _dtmperiod;
        private decimal? _fqty;
        private string _spreparedby;
        private DateTime? _dtmpreparedby;
        private string _supdateuid;
        private DateTime? _dtmupdate;
        private bool _bdel;
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
        public int? iPriority
        {
            set { _ipriority = value; }
            get { return _ipriority; }
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
        public string sPlannerCode
        {
            set { _splannercode = value; }
            get { return _splannercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sReorderPolicy
        {
            set { _sreorderpolicy = value; }
            get { return _sreorderpolicy; }
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
        public int? iProcessCycle
        {
            set { _iprocesscycle = value; }
            get { return _iprocesscycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fUnFullKit
        {
            set { _funfullkit = value; }
            get { return _funfullkit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fCurrentStock
        {
            set { _fcurrentstock = value; }
            get { return _fcurrentstock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fWOQty
        {
            set { _fwoqty = value; }
            get { return _fwoqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmPeriod
        {
            set { _dtmperiod = value; }
            get { return _dtmperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fQty
        {
            set { _fqty = value; }
            get { return _fqty; }
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
        /// <summary>
        /// 
        /// </summary>
        public string sUpdateUid
        {
            set { _supdateuid = value; }
            get { return _supdateuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmUpdate
        {
            set { _dtmupdate = value; }
            get { return _dtmupdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bDel
        {
            set { _bdel = value; }
            get { return _bdel; }
        }
    }
}
