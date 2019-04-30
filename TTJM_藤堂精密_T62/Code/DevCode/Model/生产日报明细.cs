using System;
namespace TH.Model
{
    /// <summary>
    /// 生产日报表明细:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 生产日报表明细
    {
        public 生产日报表明细()
        { }
        #region Model
        private int _iid;
        private Guid _表头guid;
        private string _箱号;
        private decimal? _装箱数;
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
        public Guid 表头GUID
        {
            set { _表头guid = value; }
            get { return _表头guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 箱号
        {
            set { _箱号 = value; }
            get { return _箱号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 装箱数
        {
            set { _装箱数 = value; }
            get { return _装箱数; }
        }
        #endregion Model

    }
}

