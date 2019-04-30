using System;
namespace 成衣生产.Model
{
    /// <summary>
    /// 生产计划:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 生产计划
    {
        public 生产计划()
        { }
        #region Model
        private int _iid;
        private int _订单iID;
        private DateTime _单据日期;
        private DateTime _计划生产日期;
        private DateTime _生产日期;
        private DateTime _入库日期;
        private DateTime _完成日期;
        private string _联系电话;
        private string _客户;
        private string _备注;
        private string _制单人;
        private DateTime _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        private string _关闭人;
        private DateTime? _关闭日期;
        private string _变更人;
        private DateTime? _变更日期;
        private int? _打印次数;
        private DateTime? _最后打印日期;
        private string _类别;
        private string _款号;
        private DateTime? _交货期;
        private decimal? _数量;
        private string _生产;
        private string _纱种;
        private string _领形;
        private string _针型;
        private decimal? _身高 = 0;
        private decimal? _体重 = 0;
        private decimal? _胸围 = 0;
        private decimal? _胸围杯型 = 0;
        private decimal? _身长 = 0;
        private decimal? _肩宽 = 0;
        private decimal? _袖长 = 0;
        private decimal? _腰围 = 0;
        private decimal? _下摆宽 = 0;
        private decimal? _领深 = 0;
        private string _主色;
        private string _配色1;
        private string _配色2;
        private string _配色3;
        private string _配色4;
        private string _配色5;
        private decimal? _主色用纱量;
        private decimal? _配色1用纱量 = 0;
        private decimal? _配色2用纱量 = 0;
        private decimal? _配色3用纱量 = 0;
        private decimal? _配色4用纱量 = 0;
        private decimal? _配色5用纱量 = 0;
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
        public int 订单iID
        {
            set { _订单iID = value; }
            get { return _订单iID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 单据日期
        {
            set { _单据日期 = value; }
            get { return _单据日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 计划生产日期
        {
            set { _计划生产日期 = value; }
            get { return _计划生产日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 生产日期
        {
            set { _生产日期 = value; }
            get { return _生产日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 入库日期
        {
            set { _入库日期 = value; }
            get { return _入库日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 完成日期
        {
            set { _完成日期 = value; }
            get { return _完成日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 联系电话
        {
            set { _联系电话 = value; }
            get { return _联系电话; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 客户
        {
            set { _客户 = value; }
            get { return _客户; }
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
        public DateTime 制单日期
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
        /// <summary>
        /// 
        /// </summary>
        public string 关闭人
        {
            set { _关闭人 = value; }
            get { return _关闭人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 关闭日期
        {
            set { _关闭日期 = value; }
            get { return _关闭日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 变更人
        {
            set { _变更人 = value; }
            get { return _变更人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 变更日期
        {
            set { _变更日期 = value; }
            get { return _变更日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 打印次数
        {
            set { _打印次数 = value; }
            get { return _打印次数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 最后打印日期
        {
            set { _最后打印日期 = value; }
            get { return _最后打印日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 类别
        {
            set { _类别 = value; }
            get { return _类别; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 款号
        {
            set { _款号 = value; }
            get { return _款号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 交货期
        {
            set { _交货期 = value; }
            get { return _交货期; }
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
        public string 生产
        {
            set { _生产 = value; }
            get { return _生产; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 纱种
        {
            set { _纱种 = value; }
            get { return _纱种; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 领形
        {
            set { _领形 = value; }
            get { return _领形; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 针型
        {
            set { _针型 = value; }
            get { return _针型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 身高
        {
            set { _身高 = value; }
            get { return _身高; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 体重
        {
            set { _体重 = value; }
            get { return _体重; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 胸围
        {
            set { _胸围 = value; }
            get { return _胸围; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 胸围杯型
        {
            set { _胸围杯型 = value; }
            get { return _胸围杯型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 身长
        {
            set { _身长 = value; }
            get { return _身长; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 肩宽
        {
            set { _肩宽 = value; }
            get { return _肩宽; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 袖长
        {
            set { _袖长 = value; }
            get { return _袖长; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 腰围
        {
            set { _腰围 = value; }
            get { return _腰围; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 下摆宽
        {
            set { _下摆宽 = value; }
            get { return _下摆宽; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 领深
        {
            set { _领深 = value; }
            get { return _领深; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 主色
        {
            set { _主色 = value; }
            get { return _主色; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 配色1
        {
            set { _配色1 = value; }
            get { return _配色1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 配色2
        {
            set { _配色2 = value; }
            get { return _配色2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 配色3
        {
            set { _配色3 = value; }
            get { return _配色3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 配色4
        {
            set { _配色4 = value; }
            get { return _配色4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 配色5
        {
            set { _配色5 = value; }
            get { return _配色5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 主色用纱量
        {
            set { _主色用纱量 = value; }
            get { return _主色用纱量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 配色1用纱量
        {
            set { _配色1用纱量 = value; }
            get { return _配色1用纱量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 配色2用纱量
        {
            set { _配色2用纱量 = value; }
            get { return _配色2用纱量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 配色3用纱量
        {
            set { _配色3用纱量 = value; }
            get { return _配色3用纱量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 配色4用纱量
        {
            set { _配色4用纱量 = value; }
            get { return _配色4用纱量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 配色5用纱量
        {
            set { _配色5用纱量 = value; }
            get { return _配色5用纱量; }
        }
        #endregion Model

    }
}

