using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _SystemSet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _SystemSet
    {
        public _SystemSet()
        { }
        #region Model
        private string _cstcode;
        private string _cwhcode;
        private string _crdcode;
        private string _sapcode;
        private string _sapworkcenter;
        private string _internalorder;
        private string _remark;
        private string _createruid;
        private DateTime? _createrdate;
        /// <summary>
        /// 
        /// </summary>
        public string cSTCode
        {
            set { _cstcode = value; }
            get { return _cstcode; }
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
        public string cRdCode
        {
            set { _crdcode = value; }
            get { return _crdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SAPCode
        {
            set { _sapcode = value; }
            get { return _sapcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SAPWorkCenter
        {
            set { _sapworkcenter = value; }
            get { return _sapworkcenter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InternalOrder
        {
            set { _internalorder = value; }
            get { return _internalorder; }
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
        public string CreaterUid
        {
            set { _createruid = value; }
            get { return _createruid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreaterDate
        {
            set { _createrdate = value; }
            get { return _createrdate; }
        }
        #endregion Model

    }
}

