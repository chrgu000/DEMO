using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_ListEntity
    {
        private int _iid;
        private string _stype;
        private DateTime? _ddate;
        private string _sverdata;
        private string _svertrialkitting;
        private string _prodgroup;
        private string _planner;
        private string _sversion;
        private int? _istate;
        private string _sresult;
        private string _remark;
        private string _createuid;
        private DateTime? _dtmcreate;
        private DateTime? _dtmstart;
        private DateTime? _dtmend;
        private int? _ichecktime;
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
        public string sType
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 同步/计算
        /// </summary>
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sVerData
        {
            set { _sverdata = value; }
            get { return _sverdata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sVerTrialkitting
        {
            set { _svertrialkitting = value; }
            get { return _svertrialkitting; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProdGroup
        {
            set { _prodgroup = value; }
            get { return _prodgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Planner
        {
            set { _planner = value; }
            get { return _planner; }
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
        /// 0 待处理；1 正在处理；2 处理完成成功；3 处理完成失败；4 取消计算
        /// </summary>
        public int? iState
        {
            set { _istate = value; }
            get { return _istate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sResult
        {
            set { _sresult = value; }
            get { return _sresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUid
        {
            set { _createuid = value; }
            get { return _createuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
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
        public int? iCheckTime
        {
            set { _ichecktime = value; }
            get { return _ichecktime; }
        }
    }
}
