using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _高开返利核销单_SZ:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _高开返利核销单_SZ
    {
        public _高开返利核销单_SZ()
        { }
        #region Model
        private long _iid;
        private string _dls;
        private string _qy;
        private string _ccode;
        private DateTime? _dtmdate;
        private decimal? _dmoney_kh;
        private decimal? _dmoney_fl;
        private decimal? _dmoney_kp;
        private long? _fld_iid;
        private string _fld_ccode;
        private decimal? _fld_money;
        private string _createuid;
        private DateTime? _dtmcreate;
        private string _remark;
        private Guid _guid;
        private DateTime? _dtmsyscreatetime = DateTime.Now;
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
        public string DLS
        {
            set { _dls = value; }
            get { return _dls; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QY
        {
            set { _qy = value; }
            get { return _qy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmDate
        {
            set { _dtmdate = value; }
            get { return _dtmdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dMoney_kh
        {
            set { _dmoney_kh = value; }
            get { return _dmoney_kh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dMoney_fl
        {
            set { _dmoney_fl = value; }
            get { return _dmoney_fl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dMoney_kp
        {
            set { _dmoney_kp = value; }
            get { return _dmoney_kp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? FLD_iID
        {
            set { _fld_iid = value; }
            get { return _fld_iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FLD_cCode
        {
            set { _fld_ccode = value; }
            get { return _fld_ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FLD_Money
        {
            set { _fld_money = value; }
            get { return _fld_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createUid
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
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public DateTime? dtmSysCreatetime
        {
            set { _dtmsyscreatetime = value; }
            get { return _dtmsyscreatetime; }
        }
        #endregion Model

    }
}

