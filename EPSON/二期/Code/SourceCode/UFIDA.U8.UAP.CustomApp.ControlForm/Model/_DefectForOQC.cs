using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _DefectForOQC:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _DefectForOQC
    {
        public _DefectForOQC()
        { }
        #region Model
        private int _iid;
        private string _cinvcode;
        private string _defectcode;
        private string _cwhcode;
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
        public string cInvCode
        {
            set { _cinvcode = value; }
            get { return _cinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DefectCode
        {
            set { _defectcode = value; }
            get { return _defectcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cWhCode
        {
            set { _cwhcode = value; }
            get { return _cwhcode; }
        }
        #endregion Model

    }
}

