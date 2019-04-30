using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH.Model
{
    /// <summary>
	/// mom_moallocate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
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
        private decimal? _baseqtyn = 0;
        private decimal? _baseqtyd = 0;

        private decimal? _parentscrap = 0;


        private decimal? _compscrap = 0;
        private decimal? _qty = 0;


        private decimal? _issqty = 0;


        private decimal? _declaredqty = 0;


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
        private decimal? _changerate = 0;
        private decimal? _auxbaseqtyn = 0;

        private decimal? _auxqty = 0;
        private decimal? _replenishqty = 0;


        private string _remark;
        private decimal? _transqty = 0;

        private long? _producttype = 1;
        private long? _sotype = 0;
        private string _sodid;
        private string _socode;
        private long? _soseq = 0;
        private string _demandcode;
        private bool _qmflag = false;
        private decimal? _orgqty = 0;

        private decimal? _orgauxqty = 0;


        private string _costitemcode;
        private string _costitemname;
        private bool _requisitionflag = false;
        private decimal? _requisitionqty = 0;


        private decimal? _requisitionissqty = 0;


        private bool _costwiprel = false;
        private Guid _moallocatesubid;
        private string _csubsysbarcode;
        private decimal? _pickingqty = 0;

        private decimal? _pickingauxqty = 0;

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
}
