using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_Base_CalendarPeriodEntity
    {
        private int _iid;
        private int _iyear;
        private int _imonth;
        private DateTime? _dtmstart;
        private DateTime? _dtmend;
        private DateTime? _iweek1;
        private DateTime? _iweek2;
        private DateTime? _iweek3;
        private DateTime? _iweek4;
        private DateTime? _iweek5;
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
        public int iYear
        {
            set { _iyear = value; }
            get { return _iyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iMonth
        {
            set { _imonth = value; }
            get { return _imonth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmStart
        {
            set { _dtmstart = value; }
            get { return _dtmstart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmEnd
        {
            set { _dtmend = value; }
            get { return _dtmend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? iWeek1
        {
            set { _iweek1 = value; }
            get { return _iweek1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? iWeek2
        {
            set { _iweek2 = value; }
            get { return _iweek2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? iWeek3
        {
            set { _iweek3 = value; }
            get { return _iweek3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? iWeek4
        {
            set { _iweek4 = value; }
            get { return _iweek4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? iWeek5
        {
            set { _iweek5 = value; }
            get { return _iweek5; }
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
