using System;
namespace 业务.Model
{
    /// <summary>
    /// 发射器档案设置:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 发射器档案设置
    {
        public 发射器档案设置()
        { }
        #region Model
        private long _iid;
        private int _发射器id;
        private string _cmitiid;
        private string _检验工位;
        private string _备注;
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
        public int 发射器ID
        {
            set { _发射器id = value; }
            get { return _发射器id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CMITiID
        {
            set { _cmitiid = value; }
            get { return _cmitiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 检验工位
        {
            set { _检验工位 = value; }
            get { return _检验工位; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        #endregion Model

    }
}

