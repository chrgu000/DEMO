using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _TH_ChkValue01:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _TH_ChkValue01
    {
        public _TH_ChkValue01()
        { }
        #region Model
        private string _ccode;
        private long _iid;
        private DateTime? _dtmcode;
        private string _wono;
        private long? _worow;
        private long _modid;
        private string _workgroup;
        private string _workprocess;
        private string _wobatch;
        private string _womould;
        private DateTime? _wodate;
        private string _cinvcode;
        private string _cinvname;
        private string _cinvstd;
        private string _cinvperformance;
        private string _cinvdraw;
        private decimal? _weigth;
        private decimal? _weigths;
        private decimal? _weigthrb;
        private decimal? _weigthsrb;
        private decimal? _qtydz;
        private decimal? _qtyg;
        private decimal? _qtywj;
        private decimal? _qtygfs;
        private decimal? _qtytxg;
        private decimal? _qtytxd;
        private decimal? _qtytxpk;
        private decimal? _qtygh;
        private decimal? _qtywgh;
        private decimal? _qtyhf;
        private decimal? _qtyun1;
        private decimal? _qtyun2;
        private decimal? _qtyun3;
        private string _creatuid;
        private DateTime? _dtmcreate;
        private string _audituid;
        private DateTime? _dtmaudit;
        private string _remark;
        private decimal? _qtypcs;
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
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkProcess
        {
            set { _workprocess = value; }
            get { return _workprocess; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WONo
        {
            set { _wono = value; }
            get { return _wono; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? WORow
        {
            set { _worow = value; }
            get { return _worow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long MODid
        {
            set { _modid = value; }
            get { return _modid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkGroup
        {
            set { _workgroup = value; }
            get { return _workgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WOBatch
        {
            set { _wobatch = value; }
            get { return _wobatch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WOMould
        {
            set { _womould = value; }
            get { return _womould; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmCode
        {
            set { _dtmcode = value; }
            get { return _dtmcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? WODate
        {
            set { _wodate = value; }
            get { return _wodate; }
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
        public string cInvName
        {
            set { _cinvname = value; }
            get { return _cinvname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvStd
        {
            set { _cinvstd = value; }
            get { return _cinvstd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvPerformance
        {
            set { _cinvperformance = value; }
            get { return _cinvperformance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cInvDraw
        {
            set { _cinvdraw = value; }
            get { return _cinvdraw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Weigth
        {
            set { _weigth = value; }
            get { return _weigth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Weigths
        {
            set { _weigths = value; }
            get { return _weigths; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WeigthRB
        {
            set { _weigthrb = value; }
            get { return _weigthrb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WeigthsRB
        {
            set { _weigthsrb = value; }
            get { return _weigthsrb; }
        }
        /// <summary>
        /// 单重
        /// </summary>
        public decimal? QtyDZ
        {
            set { _qtydz = value; }
            get { return _qtydz; }
        }
        /// <summary>
        /// 共重
        /// </summary>
        public decimal? QtyG
        {
            set { _qtyg = value; }
            get { return _qtyg; }
        }
        /// <summary>
        /// 万件
        /// </summary>
        public decimal? QtyWJ
        {
            set { _qtywj = value; }
            get { return _qtywj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyGFS
        {
            set { _qtygfs = value; }
            get { return _qtygfs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyTXG
        {
            set { _qtytxg = value; }
            get { return _qtytxg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyTXD
        {
            set { _qtytxd = value; }
            get { return _qtytxd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyTXPK
        {
            set { _qtytxpk = value; }
            get { return _qtytxpk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyGH
        {
            set { _qtygh = value; }
            get { return _qtygh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyWGH
        {
            set { _qtywgh = value; }
            get { return _qtywgh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyHF
        {
            set { _qtyhf = value; }
            get { return _qtyhf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyUn1
        {
            set { _qtyun1 = value; }
            get { return _qtyun1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyUn2
        {
            set { _qtyun2 = value; }
            get { return _qtyun2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QtyUn3
        {
            set { _qtyun3 = value; }
            get { return _qtyun3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreatUid
        {
            set { _creatuid = value; }
            get { return _creatuid; }
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
        public string AuditUid
        {
            set { _audituid = value; }
            get { return _audituid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dtmAudit
        {
            set { _dtmaudit = value; }
            get { return _dtmaudit; }
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
        public decimal? Qtypcs
        {
            set { _qtypcs = value; }
            get { return _qtypcs; }
        }
        #endregion Model

    }
}

