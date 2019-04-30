using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class PMGatingEntity
    {
        private int _iid;
        private Guid _guid;
        private string _sversion;
        private string _spartid;
        private decimal? _fopenqty;
        private DateTime? _ddate;
        private string _splannercode;
        private string _ssrc;
        private string _sproductgroup;
        private string _sreorderpolicy;
        private string _sremark;
        private string _spreparedby;
        private DateTime? _dtmpreparedby;
        private string _supdateuid;
        private DateTime? _dtmupdate;
        private int? _istatus;
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
        public string sPartID
        {
            set { _spartid = value; }
            get { return _spartid; }
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
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
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
        public string sSRC
        {
            set { _ssrc = value; }
            get { return _ssrc; }
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
        public string sReorderPolicy
        {
            set { _sreorderpolicy = value; }
            get { return _sreorderpolicy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark
        {
            set { _sremark = value; }
            get { return _sremark; }
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
        public int? iStatus
        {
            set { _istatus = value; }
            get { return _istatus; }
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
