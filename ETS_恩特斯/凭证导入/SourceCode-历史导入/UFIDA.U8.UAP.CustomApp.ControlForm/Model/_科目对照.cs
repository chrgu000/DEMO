using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _科目对照:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _科目对照
    {
        public _科目对照()
        { }
        #region Model
        private int _iid;
        private string _年度;
        private string _会计科目;
        private string _对照科目;
        private string _remark;
        private string _remarkj;
        private string _remarkd;
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
        public string 年度
        {
            set { _年度 = value; }
            get { return _年度; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 会计科目
        {
            set { _会计科目 = value; }
            get { return _会计科目; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 对照科目
        {
            set { _对照科目 = value; }
            get { return _对照科目; }
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
        public string RemarkJ
        {
            set { _remarkj = value; }
            get { return _remarkj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkD
        {
            set { _remarkd = value; }
            get { return _remarkd; }
        }
        #endregion Model

    }
}

