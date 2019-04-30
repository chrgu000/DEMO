using System;
namespace TH.Model
{
    /// <summary>
    /// 车间工序日报:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 车间工序日报
    {
        public 车间工序日报()
        { }
        #region Model
        private int _生产订单id;
        private string _工序;
        private int _箱号;
        private decimal? _数量;
        private DateTime? _登记日期;
        private string _机台序号;
        private string _作业员;
        private string _型式;
        private string _d1d2;
        private string _模号;
        private decimal? _转速;
        private decimal? _良品数;
        private decimal? _不良数;
        private decimal? _计划停机;
        private decimal? _机故;
        private decimal? _模故;
        private decimal? _换料;
        private decimal? _测量;
        private decimal? _吃饭;
        private decimal? _换模;
        private decimal? _休息;
        private decimal? _清扫;
        private decimal? _换班;
        private decimal? _待料;
        private decimal? _其他;
        private string _备注;
        private string _班次;
        private string _客户;
        /// <summary>
        /// 
        /// </summary>
        public int 生产订单ID
        {
            set { _生产订单id = value; }
            get { return _生产订单id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 工序
        {
            set { _工序 = value; }
            get { return _工序; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int 箱号
        {
            set { _箱号 = value; }
            get { return _箱号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 数量
        {
            set { _数量 = value; }
            get { return _数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 登记日期
        {
            set { _登记日期 = value; }
            get { return _登记日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 机台序号
        {
            set { _机台序号 = value; }
            get { return _机台序号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 作业员
        {
            set { _作业员 = value; }
            get { return _作业员; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 型式
        {
            set { _型式 = value; }
            get { return _型式; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string D1D2
        {
            set { _d1d2 = value; }
            get { return _d1d2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 模号
        {
            set { _模号 = value; }
            get { return _模号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 转速
        {
            set { _转速 = value; }
            get { return _转速; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 良品数
        {
            set { _良品数 = value; }
            get { return _良品数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 不良数
        {
            set { _不良数 = value; }
            get { return _不良数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 计划停机
        {
            set { _计划停机 = value; }
            get { return _计划停机; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 机故
        {
            set { _机故 = value; }
            get { return _机故; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 模故
        {
            set { _模故 = value; }
            get { return _模故; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 换料
        {
            set { _换料 = value; }
            get { return _换料; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 测量
        {
            set { _测量 = value; }
            get { return _测量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 吃饭
        {
            set { _吃饭 = value; }
            get { return _吃饭; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 换模
        {
            set { _换模 = value; }
            get { return _换模; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 休息
        {
            set { _休息 = value; }
            get { return _休息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 清扫
        {
            set { _清扫 = value; }
            get { return _清扫; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 换班
        {
            set { _换班 = value; }
            get { return _换班; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 待料
        {
            set { _待料 = value; }
            get { return _待料; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 其他
        {
            set { _其他 = value; }
            get { return _其他; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 班次
        {
            set { _班次 = value; }
            get { return _班次; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 客户
        {
            set { _客户 = value; }
            get { return _客户; }
        }
        #endregion Model

    }
}

