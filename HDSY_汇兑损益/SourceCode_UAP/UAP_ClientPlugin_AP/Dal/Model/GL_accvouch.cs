using System;
namespace UAP_ClientPlugin_AP.Model
{
    /// <summary>
    /// GL_accvouch:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GL_accvouch
    {
        public GL_accvouch()
        { }
        #region Model
        private int _i_id;
        private int _iperiod;
        private string _csign;
        private int _isignseq;
        private int _ino_id;
        private int _inid;
        private DateTime _dbill_date;
        private int _idoc = 0;
        private string _cbill;
        private string _ccheck;
        private string _cbook;
        private int _ibook = 0;
        private string _ccashier;
        private int _iflag;
        private string _ctext1;
        private string _ctext2;
        private string _cdigest;
        private string _ccode;
        private string _cexch_name;
        private decimal _md =  0M;
		private decimal _mc =  0M;
		private decimal _md_f = 0M;
		private decimal _mc_f =  0M;
		private decimal _nfrat = 0M;
		private decimal _nd_s =  0M;
		private decimal _nc_s =  0M;
		private string _csettle;
        private string _cn_id;
        private DateTime? _dt_date;
        private string _cdept_id;
        private string _cperson_id;
        private string _ccus_id;
        private string _csup_id;
        private string _citem_id;
        private string _citem_class;
        private string _cname;
        private string _ccode_equal;
        private int? _iflagbank;
        private int? _iflagperson;
        private bool _bdelete = false;
        private string _coutaccset;
        private int? _ioutyear;
        private string _coutsysname;
        private string _coutsysver;
        private DateTime? _doutbilldate;
        private int? _ioutperiod =  0;
        private string _coutsign =  "";
        private string _coutno_id;
        private DateTime? _doutdate;
        private string _coutbillsign;
        private string _coutid;
        private bool _bvouchedit = false;
        private bool _bvouchaddordele = false;
        private bool _bvouchmoneyhold = false;
        private bool _bvalueedit = false;
        private bool _bcodeedit = false;
        private string _ccodecontrol;
        private bool _bpcsedit = false;
        private bool _bdeptedit = false;
        private bool _bitemedit = false;
        private bool _bcussupinput = false;
        private string _cdefine1;
        private string _cdefine2;
        private string _cdefine3;
        private DateTime? _cdefine4;
        private int? _cdefine5;
        private DateTime? _cdefine6;
        private decimal? _cdefine7;
        private string _cdefine8;
        private string _cdefine9;
        private string _cdefine10;
        private string _cdefine11;
        private string _cdefine12;
        private string _cdefine13;
        private string _cdefine14;
        private int? _cdefine15;
        private decimal? _cdefine16;
        private DateTime? _dreceive = Convert.ToDateTime(null);
        private string _cwldzflag;
        private DateTime? _dwldztime;
        private bool _bflagout = false;
        private int _ibg_overflag;
        private string _cbg_auditor;
        private DateTime? _dbg_audittime;
        private string _cbg_auditopinion;
        private bool _bwh_bgflag;
        private int? _ssxznum;
        private string _cerrreason;
        private string _bg_auditremark;
        private string _cbudgetbuffer;
        private int _ibg_controlresult;
        private string _ncvouchid;
        private DateTime? _daudit_date;
        private string _rowguid = "newid";
        private string _cbankreconno;
        private int? _iyear;
        private int _iyperiod;
        private DateTime? _wllqdate;
        private int? _wllqperiod;
        private DateTime? _tvouchtime;
        private string _cblueoutno_id;
        private string _ccodeexch_equal;
        /// <summary>
        /// 
        /// </summary>
        public int i_id
        {
            set { _i_id = value; }
            get { return _i_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iperiod
        {
            set { _iperiod = value; }
            get { return _iperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csign
        {
            set { _csign = value; }
            get { return _csign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isignseq
        {
            set { _isignseq = value; }
            get { return _isignseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ino_id
        {
            set { _ino_id = value; }
            get { return _ino_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int inid
        {
            set { _inid = value; }
            get { return _inid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dbill_date
        {
            set { _dbill_date = value; }
            get { return _dbill_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idoc
        {
            set { _idoc = value; }
            get { return _idoc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbill
        {
            set { _cbill = value; }
            get { return _cbill; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccheck
        {
            set { _ccheck = value; }
            get { return _ccheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbook
        {
            set { _cbook = value; }
            get { return _cbook; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ibook
        {
            set { _ibook = value; }
            get { return _ibook; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccashier
        {
            set { _ccashier = value; }
            get { return _ccashier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iflag
        {
            set { _iflag = value; }
            get { return _iflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ctext1
        {
            set { _ctext1 = value; }
            get { return _ctext1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ctext2
        {
            set { _ctext2 = value; }
            get { return _ctext2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdigest
        {
            set { _cdigest = value; }
            get { return _cdigest; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cexch_name
        {
            set { _cexch_name = value; }
            get { return _cexch_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal md
        {
            set { _md = value; }
            get { return _md; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal mc
        {
            set { _mc = value; }
            get { return _mc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal md_f
        {
            set { _md_f = value; }
            get { return _md_f; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal mc_f
        {
            set { _mc_f = value; }
            get { return _mc_f; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal nfrat
        {
            set { _nfrat = value; }
            get { return _nfrat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal nd_s
        {
            set { _nd_s = value; }
            get { return _nd_s; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal nc_s
        {
            set { _nc_s = value; }
            get { return _nc_s; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csettle
        {
            set { _csettle = value; }
            get { return _csettle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cn_id
        {
            set { _cn_id = value; }
            get { return _cn_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dt_date
        {
            set { _dt_date = value; }
            get { return _dt_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdept_id
        {
            set { _cdept_id = value; }
            get { return _cdept_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cperson_id
        {
            set { _cperson_id = value; }
            get { return _cperson_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccus_id
        {
            set { _ccus_id = value; }
            get { return _ccus_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csup_id
        {
            set { _csup_id = value; }
            get { return _csup_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citem_id
        {
            set { _citem_id = value; }
            get { return _citem_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citem_class
        {
            set { _citem_class = value; }
            get { return _citem_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cname
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccode_equal
        {
            set { _ccode_equal = value; }
            get { return _ccode_equal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iflagbank
        {
            set { _iflagbank = value; }
            get { return _iflagbank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iflagPerson
        {
            set { _iflagperson = value; }
            get { return _iflagperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bdelete
        {
            set { _bdelete = value; }
            get { return _bdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coutaccset
        {
            set { _coutaccset = value; }
            get { return _coutaccset; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ioutyear
        {
            set { _ioutyear = value; }
            get { return _ioutyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coutsysname
        {
            set { _coutsysname = value; }
            get { return _coutsysname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coutsysver
        {
            set { _coutsysver = value; }
            get { return _coutsysver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? doutbilldate
        {
            set { _doutbilldate = value; }
            get { return _doutbilldate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ioutperiod
        {
            set { _ioutperiod = value; }
            get { return _ioutperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coutsign
        {
            set { _coutsign = value; }
            get { return _coutsign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coutno_id
        {
            set { _coutno_id = value; }
            get { return _coutno_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? doutdate
        {
            set { _doutdate = value; }
            get { return _doutdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coutbillsign
        {
            set { _coutbillsign = value; }
            get { return _coutbillsign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string coutid
        {
            set { _coutid = value; }
            get { return _coutid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bvouchedit
        {
            set { _bvouchedit = value; }
            get { return _bvouchedit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bvouchAddordele
        {
            set { _bvouchaddordele = value; }
            get { return _bvouchaddordele; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bvouchmoneyhold
        {
            set { _bvouchmoneyhold = value; }
            get { return _bvouchmoneyhold; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bvalueedit
        {
            set { _bvalueedit = value; }
            get { return _bvalueedit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bcodeedit
        {
            set { _bcodeedit = value; }
            get { return _bcodeedit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccodecontrol
        {
            set { _ccodecontrol = value; }
            get { return _ccodecontrol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bPCSedit
        {
            set { _bpcsedit = value; }
            get { return _bpcsedit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bDeptedit
        {
            set { _bdeptedit = value; }
            get { return _bdeptedit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bItemedit
        {
            set { _bitemedit = value; }
            get { return _bitemedit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bCusSupInput
        {
            set { _bcussupinput = value; }
            get { return _bcussupinput; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine1
        {
            set { _cdefine1 = value; }
            get { return _cdefine1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine2
        {
            set { _cdefine2 = value; }
            get { return _cdefine2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine3
        {
            set { _cdefine3 = value; }
            get { return _cdefine3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine4
        {
            set { _cdefine4 = value; }
            get { return _cdefine4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine5
        {
            set { _cdefine5 = value; }
            get { return _cdefine5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine6
        {
            set { _cdefine6 = value; }
            get { return _cdefine6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine7
        {
            set { _cdefine7 = value; }
            get { return _cdefine7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine8
        {
            set { _cdefine8 = value; }
            get { return _cdefine8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine9
        {
            set { _cdefine9 = value; }
            get { return _cdefine9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine10
        {
            set { _cdefine10 = value; }
            get { return _cdefine10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine11
        {
            set { _cdefine11 = value; }
            get { return _cdefine11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine12
        {
            set { _cdefine12 = value; }
            get { return _cdefine12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine13
        {
            set { _cdefine13 = value; }
            get { return _cdefine13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine14
        {
            set { _cdefine14 = value; }
            get { return _cdefine14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cDefine15
        {
            set { _cdefine15 = value; }
            get { return _cdefine15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine16
        {
            set { _cdefine16 = value; }
            get { return _cdefine16; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dReceive
        {
            set { _dreceive = value; }
            get { return _dreceive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cWLDZFlag
        {
            set { _cwldzflag = value; }
            get { return _cwldzflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dWLDZTime
        {
            set { _dwldztime = value; }
            get { return _dwldztime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bFlagOut
        {
            set { _bflagout = value; }
            get { return _bflagout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iBG_OverFlag
        {
            set { _ibg_overflag = value; }
            get { return _ibg_overflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_Auditor
        {
            set { _cbg_auditor = value; }
            get { return _cbg_auditor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dBG_AuditTime
        {
            set { _dbg_audittime = value; }
            get { return _dbg_audittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBG_AuditOpinion
        {
            set { _cbg_auditopinion = value; }
            get { return _cbg_auditopinion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bWH_BgFlag
        {
            set { _bwh_bgflag = value; }
            get { return _bwh_bgflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ssxznum
        {
            set { _ssxznum = value; }
            get { return _ssxznum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CErrReason
        {
            set { _cerrreason = value; }
            get { return _cerrreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BG_AuditRemark
        {
            set { _bg_auditremark = value; }
            get { return _bg_auditremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBudgetBuffer
        {
            set { _cbudgetbuffer = value; }
            get { return _cbudgetbuffer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iBG_ControlResult
        {
            set { _ibg_controlresult = value; }
            get { return _ibg_controlresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NCVouchID
        {
            set { _ncvouchid = value; }
            get { return _ncvouchid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? daudit_date
        {
            set { _daudit_date = value; }
            get { return _daudit_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RowGuid
        {
            set { _rowguid = value; }
            get { return _rowguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cBankReconNo
        {
            set { _cbankreconno = value; }
            get { return _cbankreconno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? iyear
        {
            set { _iyear = value; }
            get { return _iyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iYPeriod
        {
            set { _iyperiod = value; }
            get { return _iyperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? wllqDate
        {
            set { _wllqdate = value; }
            get { return _wllqdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? wllqPeriod
        {
            set { _wllqperiod = value; }
            get { return _wllqperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? tvouchtime
        {
            set { _tvouchtime = value; }
            get { return _tvouchtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cblueoutno_id
        {
            set { _cblueoutno_id = value; }
            get { return _cblueoutno_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccodeexch_equal
        {
            set { _ccodeexch_equal = value; }
            get { return _ccodeexch_equal; }
        }
        #endregion Model

    }
}

