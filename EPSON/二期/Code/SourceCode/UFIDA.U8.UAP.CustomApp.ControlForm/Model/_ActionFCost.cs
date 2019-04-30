using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _ActionFCost:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _ActionFCost
    {
        public _ActionFCost()
        { }
        #region Model
        private long _iid;
        private string _cinvcode;
        private string _actioncode;
        private decimal? _labour;
        private decimal? _process;
        private decimal? _platingcost;
        private decimal? _part;
        private string _ccuscode;
        private DateTime _dtmstart;
        private DateTime _dtmend;
        private decimal? _manhour;

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
        public string cInvCode
        {
            set { _cinvcode = value; }
            get { return _cinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ActionCode
        {
            set { _actioncode = value; }
            get { return _actioncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Labour
        {
            set { _labour = value; }
            get { return _labour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Process
        {
            set { _process = value; }
            get { return _process; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PlatingCost
        {
            set { _platingcost = value; }
            get { return _platingcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Part
        {
            set { _part = value; }
            get { return _part; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string cCusCode
        {
            set { _ccuscode = value; }
            get { return _ccuscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmStart
        {
            set { _dtmstart = value; }
            get { return _dtmstart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dtmEnd
        {
            set { _dtmend = value; }
            get { return _dtmend; }
        }


        /// <summary>
        /// 
        /// </summary>
        public decimal? MANHOUR
        {
            set { _manhour = value; }
            get { return _manhour; }
        }

        #endregion Model

    }
}

