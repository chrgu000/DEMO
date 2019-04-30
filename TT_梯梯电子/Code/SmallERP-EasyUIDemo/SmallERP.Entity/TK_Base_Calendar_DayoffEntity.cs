using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_Base_Calendar_DayoffEntity
    {
        private int _iid;
        private int _iyear;
        private DateTime _dayoffstart;
        private DateTime? _dayoffend;
        private string _sremark;
        private string _spreparedby;
        private DateTime? _dtmpreparedby;
        private string _supdateuid;
        private DateTime? _dtmupdate;
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
        public int iYear
        {
            set { _iyear = value; }
            get { return _iyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dayOffStart
        {
            set { _dayoffstart = value; }
            get { return _dayoffstart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dayOffEnd
        {
            set { _dayoffend = value; }
            get { return _dayoffend; }
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
    }
}
