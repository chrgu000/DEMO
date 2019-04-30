using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _AQLSampleSizeMap:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _AQLSampleSizeMap
    {
        public _AQLSampleSizeMap()
        { }
        #region Model
        private long _iid;
        private string _codeletter;
        private decimal? _samplesize;
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
        public string CodeLetter
        {
            set { _codeletter = value; }
            get { return _codeletter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SampleSize
        {
            set { _samplesize = value; }
            get { return _samplesize; }
        }
        #endregion Model

    }
}

