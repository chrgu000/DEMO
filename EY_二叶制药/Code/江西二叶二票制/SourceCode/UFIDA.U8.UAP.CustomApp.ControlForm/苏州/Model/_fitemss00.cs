using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// fitemss00:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class fitemss00
    {
        public fitemss00()
        { }
        #region Model
        private long _i_id;
        private string _citemcode;
        private string _citemname;
        private bool _bclose;
        private string _citemccode;
        private int? _iotherused;
        private decimal? _金额;
        /// <summary>
        /// 
        /// </summary>
        public long I_id
        {
            set { _i_id = value; }
            get { return _i_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citemcode
        {
            set { _citemcode = value; }
            get { return _citemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citemname
        {
            set { _citemname = value; }
            get { return _citemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bclose
        {
            set { _bclose = value; }
            get { return _bclose; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citemccode
        {
            set { _citemccode = value; }
            get { return _citemccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iotherused
        {
            set { _iotherused = value; }
            get { return _iotherused; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 金额
        {
            set { _金额 = value; }
            get { return _金额; }
        }
        #endregion Model

    }
}

