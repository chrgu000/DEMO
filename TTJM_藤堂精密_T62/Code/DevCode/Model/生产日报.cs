using System;
namespace TH.Model
{
    /// <summary>
    /// 生产日报表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 生产日报表
    {
        public 生产日报表()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private DateTime _日期;
        private int _生产订单序号;
        private string _工艺路线版本;
        private string _工艺路线顺序;
        private string _工序;
        private string _班次;
        private string _机床号;
        private string _作业员;
        private string _存货编码;
        private string _模号;
        private int? _转速;
        private int? _良品数;
        private int? _不良数;
        private decimal? _计划停机;
        private decimal? _机故;
        private decimal? _模故;
        private decimal? _换模;
        private decimal? _换料;
        private decimal? _测量;
        private decimal? _吃饭;
        private decimal? _休息;
        private decimal? _清扫;
        private decimal? _换班;
        private decimal? _待料;
        private decimal? _其它;
        private string _备注;
        private string _制单人;
        private DateTime? _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
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
        public Guid GUID
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 日期
        {
            set { _日期 = value; }
            get { return _日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int 生产订单序号
        {
            set { _生产订单序号 = value; }
            get { return _生产订单序号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 工艺路线版本
        {
            set { _工艺路线版本 = value; }
            get { return _工艺路线版本; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 工艺路线顺序
        {
            set { _工艺路线顺序 = value; }
            get { return _工艺路线顺序; }
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
        public string 班次
        {
            set { _班次 = value; }
            get { return _班次; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 机床号
        {
            set { _机床号 = value; }
            get { return _机床号; }
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
        public string 存货编码
        {
            set { _存货编码 = value; }
            get { return _存货编码; }
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
        public int? 转速
        {
            set { _转速 = value; }
            get { return _转速; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 良品数
        {
            set { _良品数 = value; }
            get { return _良品数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 不良数
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
        public decimal? 换模
        {
            set { _换模 = value; }
            get { return _换模; }
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
        public decimal? 其它
        {
            set { _其它 = value; }
            get { return _其它; }
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
        public string 制单人
        {
            set { _制单人 = value; }
            get { return _制单人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 制单日期
        {
            set { _制单日期 = value; }
            get { return _制单日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 审核人
        {
            set { _审核人 = value; }
            get { return _审核人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 审核日期
        {
            set { _审核日期 = value; }
            get { return _审核日期; }
        }
        #endregion Model

    }
}

