using System;
using System.Collections.Generic;
namespace TH.Model
{

    public partial class 生产工序日计划
    {

        #region Model
        private long _iid;
        private long _生产订单明细iid;
        private long _生产订单工艺路线明细id;
        private DateTime _排产日期;
        private DateTime _计划生产开工日期;
        private DateTime? _计划生产完工日期;
        private string _审核人;
        private DateTime? _审核日期;
        private string _制单人;
        private DateTime? _制单日期;
        private DateTime? _createdate = DateTime.Now;
        private decimal? _数量;
        private decimal? _工时比例;
        private decimal? _工时;
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
        public long 生产订单明细iID
        {
            set { _生产订单明细iid = value; }
            get { return _生产订单明细iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long 生产订单工艺路线明细ID
        {
            set { _生产订单工艺路线明细id = value; }
            get { return _生产订单工艺路线明细id; }
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
        public DateTime 计划生产开工日期
        {
            set { _计划生产开工日期 = value; }
            get { return _计划生产开工日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 计划生产完工日期
        {
            set { _计划生产完工日期 = value; }
            get { return _计划生产完工日期; }
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
        public decimal? 工时比例
        {
            set { _工时比例 = value; }
            get { return _工时比例; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 工时
        {
            set { _工时 = value; }
            get { return _工时; }
        }
        #endregion Model

    }
}

