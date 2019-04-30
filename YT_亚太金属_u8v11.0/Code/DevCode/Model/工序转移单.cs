using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace TH.Model
{
	public partial class sfc_optransform
	{
		public sfc_optransform()
		{}
		#region Model
        private long _transformid;
		private string _doccode;
		private DateTime? _docdate;
		private int? _moid;
		private int? _modid;
		private int _moroutingid;
		private int _moroutingdid;
		private int? _transformtype=1;
		private int? _opstatus;
		private decimal? _transoutqty;

		private int _inmoroutingdid;
		private decimal _qualifiedqty;

		private decimal _scrapqty;

		private decimal _refusedqty;

		private decimal _declareqty;

		private decimal _machiningqty;

		private decimal _declaredqty;
		private string _remark;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _modifydate;
		private string _modifyuser;
		private int? _updcount=0;
		private DateTime? _ufts;
		private string _define1;
		private string _define2;
		private string _define3;
		private DateTime? _define4;
		private int? _define5;
		private DateTime? _define6;
		private decimal? _define7;
		private string _define8;
		private string _define9;
		private string _define10;
		private string _define11;
		private string _define12;
		private string _define13;
		private string _define14;
		private int? _define15;
		private decimal? _define16;
		private bool _qcflag= false;
		private bool _outqcflag= false;
        private int? _vtid = 30389;
		private string _inauxunitcode;
        //private decimal? _inchangerate=null;
		private string _reasoncode;
		private string _qualifiedreasoncode;
		private string _refusedreasoncode;
		private string _scrapreasoncode;
		private int? _qctype=1;
		private int? _checkid;
		private int? _workhrid;
		private int? _status=1;
		private bool _bfedflag= false;
		private DateTime? _createtime;
		private DateTime? _modifytime;
		private DateTime? _doctime;
		private int? _pfreportid;
		private int? _pfreportdid;
		private int? _pfdid;
		private int? _iprintcount=0;
		/// <summary>
		/// 
		/// </summary>
        public long TransformId
		{
			set{ _transformid=value;}
			get{return _transformid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DocCode
		{
			set{ _doccode=value;}
			get{return _doccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DocDate
		{
			set{ _docdate=value;}
			get{return _docdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MoId
		{
			set{ _moid=value;}
			get{return _moid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MoDId
		{
			set{ _modid=value;}
			get{return _modid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MoRoutingId
		{
			set{ _moroutingid=value;}
			get{return _moroutingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MoRoutingDId
		{
			set{ _moroutingdid=value;}
			get{return _moroutingdid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TransformType
		{
			set{ _transformtype=value;}
			get{return _transformtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OpStatus
		{
			set{ _opstatus=value;}
			get{return _opstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TransOutQty
		{
			set{ _transoutqty=value;}
			get{return _transoutqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int InMoRoutingDId
		{
			set{ _inmoroutingdid=value;}
			get{return _inmoroutingdid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal QualifiedQty
		{
			set{ _qualifiedqty=value;}
			get{return _qualifiedqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ScrapQty
		{
			set{ _scrapqty=value;}
			get{return _scrapqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal RefusedQty
		{
			set{ _refusedqty=value;}
			get{return _refusedqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal DeclareQty
		{
			set{ _declareqty=value;}
			get{return _declareqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal MachiningQty
		{
			set{ _machiningqty=value;}
			get{return _machiningqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal DeclaredQty
		{
			set{ _declaredqty=value;}
			get{return _declaredqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ModifyUser
		{
			set{ _modifyuser=value;}
			get{return _modifyuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdCount
		{
			set{ _updcount=value;}
			get{return _updcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Ufts
		{
			set{ _ufts=value;}
			get{return _ufts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define1
		{
			set{ _define1=value;}
			get{return _define1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define2
		{
			set{ _define2=value;}
			get{return _define2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define3
		{
			set{ _define3=value;}
			get{return _define3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Define4
		{
			set{ _define4=value;}
			get{return _define4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Define5
		{
			set{ _define5=value;}
			get{return _define5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Define6
		{
			set{ _define6=value;}
			get{return _define6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Define7
		{
			set{ _define7=value;}
			get{return _define7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define8
		{
			set{ _define8=value;}
			get{return _define8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define9
		{
			set{ _define9=value;}
			get{return _define9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define10
		{
			set{ _define10=value;}
			get{return _define10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define11
		{
			set{ _define11=value;}
			get{return _define11;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define12
		{
			set{ _define12=value;}
			get{return _define12;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define13
		{
			set{ _define13=value;}
			get{return _define13;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Define14
		{
			set{ _define14=value;}
			get{return _define14;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Define15
		{
			set{ _define15=value;}
			get{return _define15;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Define16
		{
			set{ _define16=value;}
			get{return _define16;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool QcFlag
		{
			set{ _qcflag=value;}
			get{return _qcflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool OutQcFlag
		{
			set{ _outqcflag=value;}
			get{return _outqcflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VTid
		{
			set{ _vtid=value;}
			get{return _vtid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InAuxUnitCode
		{
			set{ _inauxunitcode=value;}
			get{return _inauxunitcode;}
		}
        ///// <summary>
        ///// 
        ///// </summary>
        //public decimal? InChangeRate
        //{
        //    set{ _inchangerate=value;}
        //    get{return _inchangerate;}
        //}
		/// <summary>
		/// 
		/// </summary>
		public string ReasonCode
		{
			set{ _reasoncode=value;}
			get{return _reasoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QualifiedReasonCode
		{
			set{ _qualifiedreasoncode=value;}
			get{return _qualifiedreasoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RefusedReasonCode
		{
			set{ _refusedreasoncode=value;}
			get{return _refusedreasoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ScrapReasonCode
		{
			set{ _scrapreasoncode=value;}
			get{return _scrapreasoncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QcType
		{
			set{ _qctype=value;}
			get{return _qctype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CheckId
		{
			set{ _checkid=value;}
			get{return _checkid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WorkHrId
		{
			set{ _workhrid=value;}
			get{return _workhrid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool BFedFlag
		{
			set{ _bfedflag=value;}
			get{return _bfedflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DocTime
		{
			set{ _doctime=value;}
			get{return _doctime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PFReportId
		{
			set{ _pfreportid=value;}
			get{return _pfreportid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PFReportDId
		{
			set{ _pfreportdid=value;}
			get{return _pfreportdid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PFDId
		{
			set{ _pfdid=value;}
			get{return _pfdid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iPrintCount
		{
			set{ _iprintcount=value;}
			get{return _iprintcount;}
		}
		#endregion Model

	}
}

