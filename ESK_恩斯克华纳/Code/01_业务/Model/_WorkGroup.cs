using System;
namespace 业务.Model
{
    /// <summary>
    /// WorkGroup:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _WorkGroup
    {
        public _WorkGroup()
        { }
        #region Model
        private long _iid;
        private string _workgroup;
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
        public string WorkGroup
        {
            set { _workgroup = value; }
            get { return _workgroup; }
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

