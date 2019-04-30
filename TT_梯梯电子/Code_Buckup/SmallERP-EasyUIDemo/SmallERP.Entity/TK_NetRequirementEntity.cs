using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_NetRequirementEntity
    {
        private int _iid;
        private Guid _guid;
        private string _sversion;
        private string _sourceid;
        private string _sno;
        private string _spartid;
        private decimal _fqty;
        private decimal _fopenqty;
        private DateTime _dtmdue;
        private DateTime _dtmrequirement;
        private string _splannercode;
        private string _ssourcetype;
        private string _sproductgroup;
        private string _sremark;
        private string _spreparedby;
        private DateTime? _dtmpreparedby = DateTime.Now;
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
        public string SourceID
        {
            set { _sourceid = value; }
            get { return _sourceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sNO
        {
            set { _sno = value; }
            get { return _sno; }
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
        public decimal fOpenQTY
        {
            set { _fopenqty = value; }
            get { return _fopenqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmDue
        {
            set { _dtmdue = value; }
            get { return _dtmdue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmRequirement
        {
            set { _dtmrequirement = value; }
            get { return _dtmrequirement; }
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
        public string sSourceType
        {
            set { _ssourcetype = value; }
            get { return _ssourcetype; }
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
    }
}
