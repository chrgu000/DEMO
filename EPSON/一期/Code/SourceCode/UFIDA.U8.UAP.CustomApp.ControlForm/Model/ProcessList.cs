using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _ProcessList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProcessList
    {
        public ProcessList()
        { }
        #region Model
        private long _iid;
        private string _status;
        private string _processcode;
        private string _seq;
        private string _platingprocess;
        private string _condition;
        private string _thichness;
        private string _time;
        private decimal? _density;
        private decimal? _amp;
        private DateTime? _updatedate;
        private string _updatedby;
        private string _remark;
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
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessCode
        {
            set { _processcode = value; }
            get { return _processcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Seq
        {
            set { _seq = value; }
            get { return _seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlatingProcess
        {
            set { _platingprocess = value; }
            get { return _platingprocess; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Condition
        {
            set { _condition = value; }
            get { return _condition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Thichness
        {
            set { _thichness = value; }
            get { return _thichness; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Time
        {
            set { _time = value; }
            get { return _time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Density
        {
            set { _density = value; }
            get { return _density; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AMP
        {
            set { _amp = value; }
            get { return _amp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Updatedby
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

