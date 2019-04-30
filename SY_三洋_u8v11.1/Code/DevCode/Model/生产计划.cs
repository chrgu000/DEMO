using System;
using System.Collections.Generic;
namespace TH.Model
{

    public partial class 生产计划
    {

        public 生产计划()
        { }
        #region Model
        private int _iid;
        private Guid _guid;
        private Guid _来源guid;
        private string _单据类型;
        private string _评审单据号;
        private string _销售订单号;
        private string _销售订单行号;
        private string _存货编码;
        private decimal? _数量;
        private DateTime? _计划开工日期;
        private DateTime? _计划完工日期;
        private string _产线编码;
        private decimal? _单件生产工时;
        private decimal? _产线并发数;
        private decimal? _生产准备时间;
        private string _生产部门编码;
        private string _制单人;
        private DateTime? _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        private string _关闭人;
        private DateTime? _关闭日期;
        private string _备注1;
        private string _备注2;
        private string _备注3;
        private string _备注4;
        private string _备注5;
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
        public Guid 来源GUID
        {
            set { _来源guid = value; }
            get { return _来源guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 单据类型
        {
            set { _单据类型 = value; }
            get { return _单据类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 评审单据号
        {
            set { _评审单据号 = value; }
            get { return _评审单据号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售订单号
        {
            set { _销售订单号 = value; }
            get { return _销售订单号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 销售订单行号
        {
            set { _销售订单行号 = value; }
            get { return _销售订单行号; }
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
        public decimal? 数量
        {
            set { _数量 = value; }
            get { return _数量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 计划开工日期
        {
            set { _计划开工日期 = value; }
            get { return _计划开工日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 计划完工日期
        {
            set { _计划完工日期 = value; }
            get { return _计划完工日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 产线编码
        {
            set { _产线编码 = value; }
            get { return _产线编码; }
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
        public decimal? 产线并发数
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
        public string 生产部门编码
        {
            set { _生产部门编码 = value; }
            get { return _生产部门编码; }
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
        public string 备注1
        {
            set { _备注1 = value; }
            get { return _备注1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注2
        {
            set { _备注2 = value; }
            get { return _备注2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注3
        {
            set { _备注3 = value; }
            get { return _备注3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注4
        {
            set { _备注4 = value; }
            get { return _备注4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注5
        {
            set { _备注5 = value; }
            get { return _备注5; }
        }
        #endregion Model

    }
}

