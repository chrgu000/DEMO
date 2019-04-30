using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// VoucherHistory:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VoucherHistory
    {
        public VoucherHistory()
        { }
        #region Model
        private int _autoid;
        private string _cardnumber;
        private int? _irdflagseed;
        private string _ccontent;
        private string _ccontentrule;
        private string _cseed;
        private string _cnumber = "1";
        private bool _bempty = false;
        /// <summary>
        /// 
        /// </summary>
        public int AutoId
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardNumber
        {
            set { _cardnumber = value; }
            get { return _cardnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iRdFlagSeed
        {
            set { _irdflagseed = value; }
            get { return _irdflagseed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cContent
        {
            set { _ccontent = value; }
            get { return _ccontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cContentRule
        {
            set { _ccontentrule = value; }
            get { return _ccontentrule; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSeed
        {
            set { _cseed = value; }
            get { return _cseed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cNumber
        {
            set { _cnumber = value; }
            get { return _cnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bEmpty
        {
            set { _bempty = value; }
            get { return _bempty; }
        }
        #endregion Model

    }
}

