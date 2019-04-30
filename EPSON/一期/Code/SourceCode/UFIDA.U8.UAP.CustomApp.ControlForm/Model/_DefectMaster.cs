using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _DefectMaster_2:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _DefectMaster_2
    {
        public _DefectMaster_2()
        { }
        #region Model
        private long _defectid;
        private string _defectcode;
        private string _defectname;
        /// <summary>
        /// 
        /// </summary>
        public long DefectID
        {
            set { _defectid = value; }
            get { return _defectid; }
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
        public string DefectName
        {
            set { _defectname = value; }
            get { return _defectname; }
        }
        #endregion Model

    }
}

