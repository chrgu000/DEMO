using System;
using System.Collections.Generic;
namespace TH.Model
{

    public partial class 生产排产完工登记
    {
        public 生产排产完工登记()
        { }
        #region Model
        private long _生产日计划iid;
        private decimal? _完工数量;
        private string _制单人;
        private DateTime? _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        /// <summary>
        /// 
        /// </summary>
        public long 生产日计划iID
        {
            set { _生产日计划iid = value; }
            get { return _生产日计划iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 完工数量
        {
            set { _完工数量 = value; }
            get { return _完工数量; }
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

