using System;
namespace 业务.Model
{
    /// <summary>
    /// 检验值:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 检验值
    {
        public 检验值()
        { }
        #region Model
        private int _iid;
        private string _接收数据;
        private int? _发射器编号;
        private decimal? _测量数值;
        private decimal? _原始值;
        private DateTime? _dtmcreate = DateTime.Now;
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
        public string 接收数据
        {
            set { _接收数据 = value; }
            get { return _接收数据; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 发射器编号
        {
            set { _发射器编号 = value; }
            get { return _发射器编号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 测量数值
        {
            set { _测量数值 = value; }
            get { return _测量数值; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 原始值
        {
            set { _原始值 = value; }
            get { return _原始值; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
        #endregion Model

    }
}

