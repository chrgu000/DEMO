using System;
using System.Collections.Generic;
namespace TH.Model
{

    #region mom_order
    public partial class mom_order
    {
        public mom_order()
        { }
        #region Model
        private long _moid;
        private string _mocode;
        private DateTime? _createdate;
        private string _createuser;
        private DateTime? _modifydate;
        private string _modifyuser;
        private long? _updcount = 0;
        private DateTime? _ufts;
        private string _define1;
        private string _define2;
        private string _define3;
        private DateTime? _define4;
        private long? _define5;
        private DateTime? _define6;
        private decimal? _define7;
        private string _define8;
        private string _define9;
        private string _define10;
        private string _define11;
        private string _define12;
        private string _define13;
        private string _define14;
        private long? _define15;
        private decimal? _define16;
        private long? _vtid;
        private DateTime? _createtime;
        private DateTime? _modifytime;
        private long? _iprintcount = 0;
        private long? _relsvtid;
        private string _csysbarcode;
        /// <summary>
        /// 
        /// </summary>
        public long MoId
        {
            set { _moid = value; }
            get { return _moid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MoCode
        {
            set { _mocode = value; }
            get { return _mocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifyDate
        {
            set { _modifydate = value; }
            get { return _modifydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModifyUser
        {
            set { _modifyuser = value; }
            get { return _modifyuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? UpdCount
        {
            set { _updcount = value; }
            get { return _updcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define1
        {
            set { _define1 = value; }
            get { return _define1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define2
        {
            set { _define2 = value; }
            get { return _define2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define3
        {
            set { _define3 = value; }
            get { return _define3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Define4
        {
            set { _define4 = value; }
            get { return _define4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Define5
        {
            set { _define5 = value; }
            get { return _define5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Define6
        {
            set { _define6 = value; }
            get { return _define6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Define7
        {
            set { _define7 = value; }
            get { return _define7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define8
        {
            set { _define8 = value; }
            get { return _define8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define9
        {
            set { _define9 = value; }
            get { return _define9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define10
        {
            set { _define10 = value; }
            get { return _define10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define11
        {
            set { _define11 = value; }
            get { return _define11; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define12
        {
            set { _define12 = value; }
            get { return _define12; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define13
        {
            set { _define13 = value; }
            get { return _define13; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define14
        {
            set { _define14 = value; }
            get { return _define14; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Define15
        {
            set { _define15 = value; }
            get { return _define15; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Define16
        {
            set { _define16 = value; }
            get { return _define16; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? VTid
        {
            set { _vtid = value; }
            get { return _vtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifyTime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iPrintCount
        {
            set { _iprintcount = value; }
            get { return _iprintcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? RelsVTid
        {
            set { _relsvtid = value; }
            get { return _relsvtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSysBarCode
        {
            set { _csysbarcode = value; }
            get { return _csysbarcode; }
        }
        #endregion Model

    }
    #endregion

    #region mom_orderdetail

    public partial class mom_orderdetail
    {
        public mom_orderdetail()
        { }
        #region Model
        private long _modid;
        private long _moid;
        private long _sortseq = 0;
        private long? _moclass = 1;
        private long? _motypeid;
        private decimal? _qty = 0M;
        private decimal? _mrpqty = 0M;
        private string _auxunitcode;
        private decimal? _auxqty = 0M;
        private decimal? _changerate = 0M;
        private string _molotcode;
        private string _whcode;
        private string _mdeptcode;
        private long? _sotype = 0;
        private string _sodid;
        private string _socode;
        private long? _soseq = 0;
        private decimal? _declaredqty = 0M;
        private decimal? _qualifiedinqty = 0M;
        private long _status = 1;
        private long? _orgstatus = 1;
        private long? _bomid;
        private long _routingid;
        private long? _custbomid;
        private long _demandid;
        private string _plancode;
        private long _partid;
        private string _invcode;
        private string _free1;
        private string _free2;
        private string _free3;
        private string _free4;
        private string _free5;
        private string _free6;
        private string _free7;
        private string _free8;
        private string _free9;
        private string _free10;
        private bool _sfcflag = false;
        private bool _crpflag = false;
        private bool _qcflag = false;
        private DateTime? _relsdate;
        private string _relsuser;
        private DateTime? _closedate;
        private DateTime? _orgclsdate;
        private DateTime _ufts;
        private string _define22;
        private string _define23;
        private string _define24;
        private string _define25;
        private decimal? _define26;
        private decimal? _define27;
        private string _define28;
        private string _define29;
        private string _define30;
        private string _define31;
        private string _define32;
        private string _define33;
        private long? _define34;
        private long? _define35;
        private DateTime? _define36;
        private DateTime? _define37;
        private long? _leadtime = 0;
        private long? _opscheduletype = 1;
        private bool _ordflag = false;
        private long? _wiptype = 5;
        private string _supplywhcode;
        private string _reasoncode;
        private long? _iswfcontrolled = 0;
        private long? _iverifystate = 0;
        private long? _ireturncount = 0;
        private string _remark;
        private string _sourcemocode;
        private long? _sourcemoseq;
        private long? _sourcemoid = 0;
        private long? _sourcemodid = 0;
        private string _sourceqccode;
        private long? _sourceqcid = 0;
        private long? _sourceqcdid = 0;
        private string _costitemcode;
        private string _costitemname;
        private DateTime? _relstime;
        private string _closeuser;
        private DateTime? _closetime;
        private DateTime? _orgclstime;
        private long? _auditstatus = 1;
        private long? _pallocateid = 0;
        private string _demandcode;
        private long? _collectiveflag = 0;
        private long _ordertype = 0;
        private long _orderdid = 0;
        private string _ordercode;
        private long? _orderseq = 0;
        private string _manualcode;
        private bool _reformflag = false;
        private long? _sourceqcvouchtype = 0;
        private decimal? _orgqty = 0M;
        private bool _fmflag = false;
        private string _minsn;
        private string _maxsn;
        private string _sourcesvccode;
        private string _sourcesvcid;
        private string _sourcesvcdid;
        private long? _bomtype = 0;
        private long? _routingtype = 0;
        private long? _busflowid;
        private bool _runcardflag = false;
        private bool _requisitionflag = false;
        private long? _allovtid;
        private long? _relsallovtid;
        private long? _iprintcount = 0;
        private string _cbsysbarcode;
        private string _ccurrentauditor;
        private string _custcode;
        private string _lplancode;
        /// <summary>
        /// 
        /// </summary>
        public long MoDId
        {
            set { _modid = value; }
            get { return _modid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long MoId
        {
            set { _moid = value; }
            get { return _moid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long SortSeq
        {
            set { _sortseq = value; }
            get { return _sortseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? MoClass
        {
            set { _moclass = value; }
            get { return _moclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? MoTypeId
        {
            set { _motypeid = value; }
            get { return _motypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MrpQty
        {
            set { _mrpqty = value; }
            get { return _mrpqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuxUnitCode
        {
            set { _auxunitcode = value; }
            get { return _auxunitcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AuxQty
        {
            set { _auxqty = value; }
            get { return _auxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ChangeRate
        {
            set { _changerate = value; }
            get { return _changerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MoLotCode
        {
            set { _molotcode = value; }
            get { return _molotcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WhCode
        {
            set { _whcode = value; }
            get { return _whcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MDeptCode
        {
            set { _mdeptcode = value; }
            get { return _mdeptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SoType
        {
            set { _sotype = value; }
            get { return _sotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SoDId
        {
            set { _sodid = value; }
            get { return _sodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SoCode
        {
            set { _socode = value; }
            get { return _socode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SoSeq
        {
            set { _soseq = value; }
            get { return _soseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DeclaredQty
        {
            set { _declaredqty = value; }
            get { return _declaredqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? QualifiedInQty
        {
            set { _qualifiedinqty = value; }
            get { return _qualifiedinqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? OrgStatus
        {
            set { _orgstatus = value; }
            get { return _orgstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? BomId
        {
            set { _bomid = value; }
            get { return _bomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long RoutingId
        {
            set { _routingid = value; }
            get { return _routingid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? CustBomId
        {
            set { _custbomid = value; }
            get { return _custbomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long DemandId
        {
            set { _demandid = value; }
            get { return _demandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlanCode
        {
            set { _plancode = value; }
            get { return _plancode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long PartId
        {
            set { _partid = value; }
            get { return _partid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvCode
        {
            set { _invcode = value; }
            get { return _invcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free1
        {
            set { _free1 = value; }
            get { return _free1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free2
        {
            set { _free2 = value; }
            get { return _free2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free3
        {
            set { _free3 = value; }
            get { return _free3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free4
        {
            set { _free4 = value; }
            get { return _free4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free5
        {
            set { _free5 = value; }
            get { return _free5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free6
        {
            set { _free6 = value; }
            get { return _free6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free7
        {
            set { _free7 = value; }
            get { return _free7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free8
        {
            set { _free8 = value; }
            get { return _free8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free9
        {
            set { _free9 = value; }
            get { return _free9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free10
        {
            set { _free10 = value; }
            get { return _free10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SfcFlag
        {
            set { _sfcflag = value; }
            get { return _sfcflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CrpFlag
        {
            set { _crpflag = value; }
            get { return _crpflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool QcFlag
        {
            set { _qcflag = value; }
            get { return _qcflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RelsDate
        {
            set { _relsdate = value; }
            get { return _relsdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RelsUser
        {
            set { _relsuser = value; }
            get { return _relsuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseDate
        {
            set { _closedate = value; }
            get { return _closedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrgClsDate
        {
            set { _orgclsdate = value; }
            get { return _orgclsdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define22
        {
            set { _define22 = value; }
            get { return _define22; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define23
        {
            set { _define23 = value; }
            get { return _define23; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define24
        {
            set { _define24 = value; }
            get { return _define24; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define25
        {
            set { _define25 = value; }
            get { return _define25; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Define26
        {
            set { _define26 = value; }
            get { return _define26; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Define27
        {
            set { _define27 = value; }
            get { return _define27; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define28
        {
            set { _define28 = value; }
            get { return _define28; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define29
        {
            set { _define29 = value; }
            get { return _define29; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define30
        {
            set { _define30 = value; }
            get { return _define30; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define31
        {
            set { _define31 = value; }
            get { return _define31; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define32
        {
            set { _define32 = value; }
            get { return _define32; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define33
        {
            set { _define33 = value; }
            get { return _define33; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Define34
        {
            set { _define34 = value; }
            get { return _define34; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Define35
        {
            set { _define35 = value; }
            get { return _define35; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Define36
        {
            set { _define36 = value; }
            get { return _define36; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Define37
        {
            set { _define37 = value; }
            get { return _define37; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? LeadTime
        {
            set { _leadtime = value; }
            get { return _leadtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? OpScheduleType
        {
            set { _opscheduletype = value; }
            get { return _opscheduletype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool OrdFlag
        {
            set { _ordflag = value; }
            get { return _ordflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? WIPType
        {
            set { _wiptype = value; }
            get { return _wiptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SupplyWhCode
        {
            set { _supplywhcode = value; }
            get { return _supplywhcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReasonCode
        {
            set { _reasoncode = value; }
            get { return _reasoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? IsWFControlled
        {
            set { _iswfcontrolled = value; }
            get { return _iswfcontrolled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iVerifyState
        {
            set { _iverifystate = value; }
            get { return _iverifystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iReturnCount
        {
            set { _ireturncount = value; }
            get { return _ireturncount; }
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
        public string SourceMoCode
        {
            set { _sourcemocode = value; }
            get { return _sourcemocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SourceMoSeq
        {
            set { _sourcemoseq = value; }
            get { return _sourcemoseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SourceMoId
        {
            set { _sourcemoid = value; }
            get { return _sourcemoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SourceMoDId
        {
            set { _sourcemodid = value; }
            get { return _sourcemodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceQCCode
        {
            set { _sourceqccode = value; }
            get { return _sourceqccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SourceQCId
        {
            set { _sourceqcid = value; }
            get { return _sourceqcid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SourceQCDId
        {
            set { _sourceqcdid = value; }
            get { return _sourceqcdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CostItemCode
        {
            set { _costitemcode = value; }
            get { return _costitemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CostItemName
        {
            set { _costitemname = value; }
            get { return _costitemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RelsTime
        {
            set { _relstime = value; }
            get { return _relstime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CloseUser
        {
            set { _closeuser = value; }
            get { return _closeuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CloseTime
        {
            set { _closetime = value; }
            get { return _closetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrgClsTime
        {
            set { _orgclstime = value; }
            get { return _orgclstime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? AuditStatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? PAllocateId
        {
            set { _pallocateid = value; }
            get { return _pallocateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DemandCode
        {
            set { _demandcode = value; }
            get { return _demandcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? CollectiveFlag
        {
            set { _collectiveflag = value; }
            get { return _collectiveflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long OrderDId
        {
            set { _orderdid = value; }
            get { return _orderdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? OrderSeq
        {
            set { _orderseq = value; }
            get { return _orderseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManualCode
        {
            set { _manualcode = value; }
            get { return _manualcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ReformFlag
        {
            set { _reformflag = value; }
            get { return _reformflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SourceQCVouchType
        {
            set { _sourceqcvouchtype = value; }
            get { return _sourceqcvouchtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrgQty
        {
            set { _orgqty = value; }
            get { return _orgqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FmFlag
        {
            set { _fmflag = value; }
            get { return _fmflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinSN
        {
            set { _minsn = value; }
            get { return _minsn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaxSN
        {
            set { _maxsn = value; }
            get { return _maxsn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceSvcCode
        {
            set { _sourcesvccode = value; }
            get { return _sourcesvccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceSvcId
        {
            set { _sourcesvcid = value; }
            get { return _sourcesvcid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SourceSvcDId
        {
            set { _sourcesvcdid = value; }
            get { return _sourcesvcdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? BomType
        {
            set { _bomtype = value; }
            get { return _bomtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? RoutingType
        {
            set { _routingtype = value; }
            get { return _routingtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? BusFlowId
        {
            set { _busflowid = value; }
            get { return _busflowid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool RunCardFlag
        {
            set { _runcardflag = value; }
            get { return _runcardflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool RequisitionFlag
        {
            set { _requisitionflag = value; }
            get { return _requisitionflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? AlloVTid
        {
            set { _allovtid = value; }
            get { return _allovtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? RelsAlloVTid
        {
            set { _relsallovtid = value; }
            get { return _relsallovtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iPrintCount
        {
            set { _iprintcount = value; }
            get { return _iprintcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cbSysBarCode
        {
            set { _cbsysbarcode = value; }
            get { return _cbsysbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCurrentAuditor
        {
            set { _ccurrentauditor = value; }
            get { return _ccurrentauditor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustCode
        {
            set { _custcode = value; }
            get { return _custcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LPlanCode
        {
            set { _lplancode = value; }
            get { return _lplancode; }
        }
        #endregion Model

    }
    #endregion

    #region mom_morder
    public partial class mom_morder
    {
        public mom_morder()
        { }
        #region Model
        private long _modid;
        private DateTime? _startdate;
        private DateTime? _duedate;
        private DateTime? _ufts;
        private long? _moid = 0;
        /// <summary>
        /// 
        /// </summary>
        public long MoDId
        {
            set { _modid = value; }
            get { return _modid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DueDate
        {
            set { _duedate = value; }
            get { return _duedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? MoId
        {
            set { _moid = value; }
            get { return _moid; }
        }
        #endregion Model

    }
    #endregion

    #region mom_moallocate
    public partial class mom_moallocate
    {
        public mom_moallocate()
        { }
        #region Model
        private long _allocateid;
        private long _modid;
        private long _sortseq = 0;
        private string _opseq;
        private long? _componentid;
        private long? _fvflag = 1;
        private decimal? _baseqtyn = 0M;

        private decimal? _baseqtyd = 0M;


        private decimal? _parentscrap = 0M;


        private decimal? _compscrap = 0M;


        private decimal? _qty = 0M;


        private decimal? _issqty = 0M;


        private decimal? _declaredqty = 0M;


        private DateTime? _startdemdate;
        private DateTime? _enddemdate;
        private string _whcode;
        private string _lotno;
        private long? _wiptype = 3;
        private bool _byproductflag = false;
        private bool _qcflag = false;
        private long? _offset = 0;
        private string _invcode;
        private string _free1;
        private string _free2;
        private string _free3;
        private string _free4;
        private string _free5;
        private string _free6;
        private string _free7;
        private string _free8;
        private string _free9;
        private string _free10;
        private long? _opcomponentid = 0;
        private string _define22;
        private string _define23;
        private string _define24;
        private string _define25;
        private decimal? _define26;
        private decimal? _define27;
        private string _define28;
        private string _define29;
        private string _define30;
        private string _define31;
        private string _define32;
        private string _define33;
        private long? _define34;
        private long? _define35;
        private DateTime? _define36;
        private DateTime? _define37;
        private DateTime _ufts;
        private string _auxunitcode;
        private decimal? _changerate = 0M;


        private decimal? _auxbaseqtyn = 0M;


        private decimal? _auxqty = 0M;


        private decimal? _replenishqty = 0M;

        private string _remark;
        private decimal? _transqty = 0M;


        private long? _producttype = 1;
        private long? _sotype = 0;
        private string _sodid;
        private string _socode;
        private long? _soseq = 0;
        private string _demandcode;
        private bool _qmflag = false;
        private decimal? _orgqty = 0M;


        private decimal? _orgauxqty = 0M;

        private string _costitemcode;
        private string _costitemname;
        private bool _requisitionflag = false;
        private decimal? _requisitionqty = 0M;


        private decimal? _requisitionissqty = 0M;

        private bool _costwiprel = false;
        private Guid _moallocatesubid;
        private string _csubsysbarcode;
        private decimal? _pickingqty = 0M;


        private decimal? _pickingauxqty = 0M;


        /// <summary>
        /// 
        /// </summary>
        public long AllocateId
        {
            set { _allocateid = value; }
            get { return _allocateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long MoDId
        {
            set { _modid = value; }
            get { return _modid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long SortSeq
        {
            set { _sortseq = value; }
            get { return _sortseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpSeq
        {
            set { _opseq = value; }
            get { return _opseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ComponentId
        {
            set { _componentid = value; }
            get { return _componentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? FVFlag
        {
            set { _fvflag = value; }
            get { return _fvflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BaseQtyN
        {
            set { _baseqtyn = value; }
            get { return _baseqtyn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BaseQtyD
        {
            set { _baseqtyd = value; }
            get { return _baseqtyd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ParentScrap
        {
            set { _parentscrap = value; }
            get { return _parentscrap; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CompScrap
        {
            set { _compscrap = value; }
            get { return _compscrap; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Qty
        {
            set { _qty = value; }
            get { return _qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? IssQty
        {
            set { _issqty = value; }
            get { return _issqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DeclaredQty
        {
            set { _declaredqty = value; }
            get { return _declaredqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartDemDate
        {
            set { _startdemdate = value; }
            get { return _startdemdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDemDate
        {
            set { _enddemdate = value; }
            get { return _enddemdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WhCode
        {
            set { _whcode = value; }
            get { return _whcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LotNo
        {
            set { _lotno = value; }
            get { return _lotno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? WIPType
        {
            set { _wiptype = value; }
            get { return _wiptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ByproductFlag
        {
            set { _byproductflag = value; }
            get { return _byproductflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool QcFlag
        {
            set { _qcflag = value; }
            get { return _qcflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Offset
        {
            set { _offset = value; }
            get { return _offset; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InvCode
        {
            set { _invcode = value; }
            get { return _invcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free1
        {
            set { _free1 = value; }
            get { return _free1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free2
        {
            set { _free2 = value; }
            get { return _free2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free3
        {
            set { _free3 = value; }
            get { return _free3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free4
        {
            set { _free4 = value; }
            get { return _free4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free5
        {
            set { _free5 = value; }
            get { return _free5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free6
        {
            set { _free6 = value; }
            get { return _free6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free7
        {
            set { _free7 = value; }
            get { return _free7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free8
        {
            set { _free8 = value; }
            get { return _free8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free9
        {
            set { _free9 = value; }
            get { return _free9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Free10
        {
            set { _free10 = value; }
            get { return _free10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? OpComponentId
        {
            set { _opcomponentid = value; }
            get { return _opcomponentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define22
        {
            set { _define22 = value; }
            get { return _define22; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define23
        {
            set { _define23 = value; }
            get { return _define23; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define24
        {
            set { _define24 = value; }
            get { return _define24; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define25
        {
            set { _define25 = value; }
            get { return _define25; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Define26
        {
            set { _define26 = value; }
            get { return _define26; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Define27
        {
            set { _define27 = value; }
            get { return _define27; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define28
        {
            set { _define28 = value; }
            get { return _define28; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define29
        {
            set { _define29 = value; }
            get { return _define29; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define30
        {
            set { _define30 = value; }
            get { return _define30; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define31
        {
            set { _define31 = value; }
            get { return _define31; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define32
        {
            set { _define32 = value; }
            get { return _define32; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Define33
        {
            set { _define33 = value; }
            get { return _define33; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Define34
        {
            set { _define34 = value; }
            get { return _define34; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? Define35
        {
            set { _define35 = value; }
            get { return _define35; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Define36
        {
            set { _define36 = value; }
            get { return _define36; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Define37
        {
            set { _define37 = value; }
            get { return _define37; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Ufts
        {
            set { _ufts = value; }
            get { return _ufts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuxUnitCode
        {
            set { _auxunitcode = value; }
            get { return _auxunitcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ChangeRate
        {
            set { _changerate = value; }
            get { return _changerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AuxBaseQtyN
        {
            set { _auxbaseqtyn = value; }
            get { return _auxbaseqtyn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AuxQty
        {
            set { _auxqty = value; }
            get { return _auxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReplenishQty
        {
            set { _replenishqty = value; }
            get { return _replenishqty; }
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
        public decimal? TransQty
        {
            set { _transqty = value; }
            get { return _transqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ProductType
        {
            set { _producttype = value; }
            get { return _producttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SoType
        {
            set { _sotype = value; }
            get { return _sotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SoDId
        {
            set { _sodid = value; }
            get { return _sodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SoCode
        {
            set { _socode = value; }
            get { return _socode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SoSeq
        {
            set { _soseq = value; }
            get { return _soseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DemandCode
        {
            set { _demandcode = value; }
            get { return _demandcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool QmFlag
        {
            set { _qmflag = value; }
            get { return _qmflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrgQty
        {
            set { _orgqty = value; }
            get { return _orgqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OrgAuxQty
        {
            set { _orgauxqty = value; }
            get { return _orgauxqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CostItemCode
        {
            set { _costitemcode = value; }
            get { return _costitemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CostItemName
        {
            set { _costitemname = value; }
            get { return _costitemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool RequisitionFlag
        {
            set { _requisitionflag = value; }
            get { return _requisitionflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RequisitionQty
        {
            set { _requisitionqty = value; }
            get { return _requisitionqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RequisitionIssQty
        {
            set { _requisitionissqty = value; }
            get { return _requisitionissqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CostWIPRel
        {
            set { _costwiprel = value; }
            get { return _costwiprel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid MoallocateSubId
        {
            set { _moallocatesubid = value; }
            get { return _moallocatesubid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSubSysBarCode
        {
            set { _csubsysbarcode = value; }
            get { return _csubsysbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PickingQty
        {
            set { _pickingqty = value; }
            get { return _pickingqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PickingAuxQty
        {
            set { _pickingauxqty = value; }
            get { return _pickingauxqty; }
        }
        #endregion Model

    }
    #endregion
}

