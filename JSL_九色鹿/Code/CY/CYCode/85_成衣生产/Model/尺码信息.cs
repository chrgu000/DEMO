using System;
namespace 成衣生产.Model
{
    /// <summary>
    /// 尺码信息:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 尺码信息
    {
        public 尺码信息()
        { }
        #region Model
        private int _iid;
        private string _款号;
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
        private string _制版文件;
        private string _制版人;
        private DateTime? _制版时间;
        private string _上机文件;
        private string _上机人;
        private DateTime? _上机时间;
        private string _creater;
        private DateTime? _createdate;
        private string _updater;
        private DateTime? _updatedate;
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
        public string 款号
        {
            set { _款号 = value; }
            get { return _款号; }
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
        public string 制版人
        {
            set { _制版人 = value; }
            get { return _制版人; }
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
        public string 上机文件
        {
            set { _上机文件 = value; }
            get { return _上机文件; }
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
        public DateTime? 上机时间
        {
            set { _上机时间 = value; }
            get { return _上机时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creater
        {
            set { _creater = value; }
            get { return _creater; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Updater
        {
            set { _updater = value; }
            get { return _updater; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

    }
}

