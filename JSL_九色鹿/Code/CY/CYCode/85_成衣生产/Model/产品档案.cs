using System;
namespace 成衣生产.Model
{
    /// <summary>
    /// 产品档案:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 产品档案
    {
        public 产品档案()
        { }
        #region Model
        private int _iid;
        private int _尺码信息iid;
        private string _编码;
        private string _类别;
        private string _款号;
        private string _款名;
        private string _规格;
        private string _生产;
        private string _纱种;
        private decimal? _腰围l;
        private decimal? _腰围t;
        private decimal? _下摆宽l;
        private decimal? _下摆宽t;
        private string _针型;
        private string _领形;
        private decimal? _领深l;
        private decimal? _领深t;
        private decimal? _定制加工费;
        private decimal? _vip加工费;
        private string _主色;
        private string _配色1;
        private string _配色2;
        private string _配色3;
        private string _配色4;
        private string _配色5;
        private decimal? _主色用纱量;
        private decimal? _配色1用纱量;
        private decimal? _配色2用纱量;
        private decimal? _配色3用纱量;
        private decimal? _配色4用纱量;
        private decimal? _配色5用纱量;
        private string _图纸责任人;
        private string _制版文件;
        private DateTime? _制版时间;
        private string _制版人;
        private string _上机文件;
        private DateTime? _上机时间;
        private string _上机人;
        private string _制单人;
        private DateTime? _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        private decimal? _身高l;
        private decimal? _身高t;
        private decimal? _体重l;
        private decimal? _体重t;
        private decimal _胸围l;
        private decimal? _胸围t;
        private decimal? _胸围杯型l;
        private decimal? _胸围杯型t;
        private decimal? _身长l;
        private decimal? _身长t;
        private decimal? _肩宽l;
        private decimal? _肩宽t;
        private decimal? _袖长l;
        private decimal? _袖长t;
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
        public int 尺码信息iID
        {
            set { _尺码信息iid = value; }
            get { return _尺码信息iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 编码
        {
            set { _编码 = value; }
            get { return _编码; }
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
        public string 款名
        {
            set { _款名 = value; }
            get { return _款名; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 规格
        {
            set { _规格 = value; }
            get { return _规格; }
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
        public decimal? 腰围L
        {
            set { _腰围l = value; }
            get { return _腰围l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 腰围T
        {
            set { _腰围t = value; }
            get { return _腰围t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 下摆宽L
        {
            set { _下摆宽l = value; }
            get { return _下摆宽l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 下摆宽T
        {
            set { _下摆宽t = value; }
            get { return _下摆宽t; }
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
        public string 领形
        {
            set { _领形 = value; }
            get { return _领形; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 领深L
        {
            set { _领深l = value; }
            get { return _领深l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 领深T
        {
            set { _领深t = value; }
            get { return _领深t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 定制加工费
        {
            set { _定制加工费 = value; }
            get { return _定制加工费; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? VIP加工费
        {
            set { _vip加工费 = value; }
            get { return _vip加工费; }
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
        /// <summary>
        /// 
        /// </summary>
        public string 图纸责任人
        {
            set { _图纸责任人 = value; }
            get { return _图纸责任人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 制版文件
        {
            set { _制版文件 = value; }
            get { return _制版文件; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 制版时间
        {
            set { _制版时间 = value; }
            get { return _制版时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 制版人
        {
            set { _制版人 = value; }
            get { return _制版人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 上机文件
        {
            set { _上机文件 = value; }
            get { return _上机文件; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 上机时间
        {
            set { _上机时间 = value; }
            get { return _上机时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 上机人
        {
            set { _上机人 = value; }
            get { return _上机人; }
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
        /// <summary>
        /// 
        /// </summary>
        public decimal? 身高L
        {
            set { _身高l = value; }
            get { return _身高l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 身高T
        {
            set { _身高t = value; }
            get { return _身高t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 体重L
        {
            set { _体重l = value; }
            get { return _体重l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 体重T
        {
            set { _体重t = value; }
            get { return _体重t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 胸围L
        {
            set { _胸围l = value; }
            get { return _胸围l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 胸围T
        {
            set { _胸围t = value; }
            get { return _胸围t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 胸围杯型L
        {
            set { _胸围杯型l = value; }
            get { return _胸围杯型l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 胸围杯型T
        {
            set { _胸围杯型t = value; }
            get { return _胸围杯型t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 身长L
        {
            set { _身长l = value; }
            get { return _身长l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 身长T
        {
            set { _身长t = value; }
            get { return _身长t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 肩宽L
        {
            set { _肩宽l = value; }
            get { return _肩宽l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 肩宽T
        {
            set { _肩宽t = value; }
            get { return _肩宽t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 袖长L
        {
            set { _袖长l = value; }
            get { return _袖长l; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 袖长T
        {
            set { _袖长t = value; }
            get { return _袖长t; }
        }
        #endregion Model

    }
}

