using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _PlatingProcess:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _PlatingProcess
    {
        public _PlatingProcess()
        { }
        #region Model
        private long _iid;
        private string _remark;
        private string _istate;
        private string _createruid;
        private DateTime? _createrdate;
        private string _itemcode;
        private string _processcode;
        private string _material;
        private string _xrayfile;
        private string _finishingspec;
        private string _commonpltspec;
        private string _color;
        private string _grade;
        private string _unitsurfacearea;
        private string _unitweight;
        private string _note1;
        private string _note2;
        private string _note3;
        private DateTime? _updateddate;
        private string _updatedby;
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iState
        {
            set { _istate = value; }
            get { return _istate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreaterUid
        {
            set { _createruid = value; }
            get { return _createruid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreaterDate
        {
            set { _createrdate = value; }
            get { return _createrdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ItemCode
        {
            set { _itemcode = value; }
            get { return _itemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessCode
        {
            set { _processcode = value; }
            get { return _processcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Material
        {
            set { _material = value; }
            get { return _material; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XRayFile
        {
            set { _xrayfile = value; }
            get { return _xrayfile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FinishingSpec
        {
            set { _finishingspec = value; }
            get { return _finishingspec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CommonPltSpec
        {
            set { _commonpltspec = value; }
            get { return _commonpltspec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitSurfaceArea
        {
            set { _unitsurfacearea = value; }
            get { return _unitsurfacearea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitWeight
        {
            set { _unitweight = value; }
            get { return _unitweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note1
        {
            set { _note1 = value; }
            get { return _note1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note2
        {
            set { _note2 = value; }
            get { return _note2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note3
        {
            set { _note3 = value; }
            get { return _note3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdatedDate
        {
            set { _updateddate = value; }
            get { return _updateddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdatedBy
        {
            set { _updatedby = value; }
            get { return _updatedby; }
        }
        #endregion Model

    }
}

