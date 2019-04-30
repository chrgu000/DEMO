using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _Process:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _Process
    {
        public _Process()
        { }
        #region Model
        private int _iid;
        private string _processno;
        private string _process;
        private string _condition;
        private string _platingspec;
        private string _thickness;
        private decimal? _time;
        private string _amphrs;
        private string _cwhcode;
        private decimal? _price;
        private string _remark;
        private string _createuid;
        private DateTime? _createdate;
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
        public string ProcessNo
        {
            set { _processno = value; }
            get { return _processno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Process
        {
            set { _process = value; }
            get { return _process; }
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
        public string PLATINGSPEC
        {
            set { _platingspec = value; }
            get { return _platingspec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string THICKNESS
        {
            set { _thickness = value; }
            get { return _thickness; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TIME
        {
            set { _time = value; }
            get { return _time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AMPHRS
        {
            set { _amphrs = value; }
            get { return _amphrs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cWhCode
        {
            set { _cwhcode = value; }
            get { return _cwhcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
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
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}

