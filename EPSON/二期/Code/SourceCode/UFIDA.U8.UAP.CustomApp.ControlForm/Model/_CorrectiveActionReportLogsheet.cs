using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _CorrectiveActionReportLogsheet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _CorrectiveActionReportLogsheet
    {
        public _CorrectiveActionReportLogsheet()
        { }
        #region Model
        private long _iid;
        private string _stype;
        private string _barcode;
        private string _reportno;
        private DateTime? _dateofcomplaint;
        private string _ccuscode;
        private string _description;
        private string _cdepcode;
        private DateTime? _dateissued;
        private DateTime? _duedate;
        private DateTime? _datereplied;
        private DateTime? _dateclosed;
        private string _remarks;
        private decimal? _complaint;
        private decimal? _claim;
        /// <summary>
        /// 
        /// </summary>
        public long iID
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
        /// 
        /// </summary>
        public string Barcode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReportNo
        {
            set { _reportno = value; }
            get { return _reportno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateofComplaint
        {
            set { _dateofcomplaint = value; }
            get { return _dateofcomplaint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusCode
        {
            set { _ccuscode = value; }
            get { return _ccuscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDepCode
        {
            set { _cdepcode = value; }
            get { return _cdepcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateIssued
        {
            set { _dateissued = value; }
            get { return _dateissued; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DueDate
        {
            set { _duedate = value; }
            get { return _duedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateReplied
        {
            set { _datereplied = value; }
            get { return _datereplied; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateClosed
        {
            set { _dateclosed = value; }
            get { return _dateclosed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Complaint
        {
            set { _complaint = value; }
            get { return _complaint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Claim
        {
            set { _claim = value; }
            get { return _claim; }
        }
        #endregion Model

    }
}

