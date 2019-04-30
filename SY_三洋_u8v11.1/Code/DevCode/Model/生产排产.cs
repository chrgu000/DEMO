using System;
using System.Collections.Generic;
namespace TH.Model
{

    public partial class 生产日计划
    {
        public 生产日计划()
        { }
        #region Model
        private int _iid;
        private string _来源类型;
        private Guid _来源guid;
        private DateTime _排产日期;
        private DateTime _计划生产日期;
        private string _产线;
        private string _审核人;
        private DateTime? _审核日期;
        private string _制单人;
        private DateTime? _制单日期;
        private DateTime? _createdate = DateTime.Now;
        private decimal? _数量;
        private decimal? _工时;
        private int? _产线并发数;
        private decimal? _生产准备时间;
        private decimal? _单件生产工时;
        private string _生产部门编码;
        private int? _状态;
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
        public string 来源类型
        {
            set { _来源类型 = value; }
            get { return _来源类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid 来源GUID
        {
            set { _来源guid = value; }
            get { return _来源guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 排产日期
        {
            set { _排产日期 = value; }
            get { return _排产日期; }
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
        public string 产线
        {
            set { _产线 = value; }
            get { return _产线; }
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
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
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
        public decimal? 工时
        {
            set { _工时 = value; }
            get { return _工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 产线并发数
        {
            set { _产线并发数 = value; }
            get { return _产线并发数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 生产准备时间
        {
            set { _生产准备时间 = value; }
            get { return _生产准备时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 单件生产工时
        {
            set { _单件生产工时 = value; }
            get { return _单件生产工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 生产部门编码
        {
            set { _生产部门编码 = value; }
            get { return _生产部门编码; }
        }
        /// <summary>
        /// 0 新计划未排产;1 已保存; 2 已下达生产订单
        /// </summary>
        public int? 状态
        {
            set { _状态 = value; }
            get { return _状态; }
        }
        #endregion Model

    }

    public partial class 生产日计划历史
    {
        public 生产日计划历史()
        { }
        #region Model
        private int _iid;
        private string _来源类型;
        private Guid _来源guid;
        private DateTime _排产日期;
        private DateTime _计划生产日期;
        private string _产线;
        private string _审核人;
        private DateTime? _审核日期;
        private string _制单人;
        private DateTime? _制单日期;
        private DateTime? _createdate;
        private decimal? _数量;
        private decimal? _工时;
        private int? _产线并发数;
        private decimal? _生产准备时间;
        private decimal? _单件生产工时;
        private string _生产部门编码;
        private int? _状态;
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
        public string 来源类型
        {
            set { _来源类型 = value; }
            get { return _来源类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid 来源GUID
        {
            set { _来源guid = value; }
            get { return _来源guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime 排产日期
        {
            set { _排产日期 = value; }
            get { return _排产日期; }
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
        public string 产线
        {
            set { _产线 = value; }
            get { return _产线; }
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
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
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
        public decimal? 工时
        {
            set { _工时 = value; }
            get { return _工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 产线并发数
        {
            set { _产线并发数 = value; }
            get { return _产线并发数; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 生产准备时间
        {
            set { _生产准备时间 = value; }
            get { return _生产准备时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 单件生产工时
        {
            set { _单件生产工时 = value; }
            get { return _单件生产工时; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 生产部门编码
        {
            set { _生产部门编码 = value; }
            get { return _生产部门编码; }
        }
        /// <summary>
        /// 0 新计划未排产;1 已保存; 2 已下达生产订单
        /// </summary>
        public int? 状态
        {
            set { _状态 = value; }
            get { return _状态; }
        }
        #endregion Model

    }
}

