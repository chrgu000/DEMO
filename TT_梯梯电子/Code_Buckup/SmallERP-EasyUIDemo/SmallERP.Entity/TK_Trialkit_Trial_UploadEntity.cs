using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class TK_Trialkit_Trial_UploadEntity
    {
        private int _iid;
        private Guid _guid;
        private string _stkversion;
        private string _sdataversion;
        private string _partid;
        private DateTime? _ddate;
        private DateTime _dtmperiod;
        private decimal? _qty;
        private int? _iupload_type;
        private string _stkversion_contrast;
        private int? _itk_type;
        private string _remark;
        private string _createuid;
        private DateTime? _dtmcreate;
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
        public Guid Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// Trialkitting版本
        /// </summary>
        public string sTKVersion
        {
            set { _stkversion = value; }
            get { return _stkversion; }
        }
        /// <summary>
        /// 同步过来的基础数据的版本（净需求、工单、采购订单、库存）
        /// </summary>
        public string sDataVersion
        {
            set { _sdataversion = value; }
            get { return _sdataversion; }
        }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string Partid
        {
            set { _partid = value; }
            get { return _partid; }
        }
        /// <summary>
        /// 上传数据：模板中日期；保存的计算表中的日期
        /// </summary>
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 按照dDate的日期转换为周期的日期
        /// </summary>
        public DateTime dtmPeriod
        {
            set { _dtmperiod = value; }
            get { return _dtmperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 数据类型：0 全部计算；1 全部上传；2 部分上传（参考对比版本计算）
        /// </summary>
        public int? iUpload_Type
        {
            set { _iupload_type = value; }
            get { return _iupload_type; }
        }
        /// <summary>
        /// iUpload_Type = 2 时的对比版本
        /// </summary>
        public string sTKVersion_Contrast
        {
            set { _stkversion_contrast = value; }
            get { return _stkversion_contrast; }
        }
        /// <summary>
        /// 计算类型：0 全部计算；1 排除临时不计算物料
        /// </summary>
        public int? iTK_Type
        {
            set { _itk_type = value; }
            get { return _itk_type; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUid
        {
            set { _createuid = value; }
            get { return _createuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmCreate
        {
            set { _dtmcreate = value; }
            get { return _dtmcreate; }
        }
    }
}
