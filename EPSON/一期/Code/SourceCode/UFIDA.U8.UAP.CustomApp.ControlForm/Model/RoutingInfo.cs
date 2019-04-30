using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _RoutingInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _RoutingInfo
    {
        public _RoutingInfo()
        { }
        #region Model
        private int _iid;
        private string _routingid;
        private string _routingform;
        private string _routingto;
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
        public string RoutingID
        {
            set { _routingid = value; }
            get { return _routingid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoutingForm
        {
            set { _routingform = value; }
            get { return _routingform; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoutingTo
        {
            set { _routingto = value; }
            get { return _routingto; }
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

