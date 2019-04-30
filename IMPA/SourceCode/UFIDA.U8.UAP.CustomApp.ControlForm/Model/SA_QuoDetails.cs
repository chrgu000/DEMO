using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// SA_QuoDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SA_QuoDetails
    {
        public SA_QuoDetails()
        { }
        #region Model
        private long _autoid = 0;
        private string _cinvcode;
        private decimal? _iquantity;
        private decimal? _inum;
        private decimal? _iquotedprice;
        private decimal? _iunitprice;
        private decimal? _itaxunitprice;
        private decimal? _imoney;
        private decimal? _itax;
        private decimal? _isum;
        private decimal? _idiscount;
        private decimal? _inatunitprice;
        private decimal? _inatmoney;
        private decimal? _inattax;
        private decimal? _inatsum;
        private decimal? _inatdiscount;
        private string _cmemo;
        private string _cfree1;
        private string _cfree2;
        private decimal? _kl = 0M;
        private decimal? _kl2 = 0M;
        private decimal? _itaxrate = 0M;
        private string _cdefine22;
        private string _cdefine23;
        private string _cdefine24;
        private string _cdefine25;
        private decimal? _cdefine26;
        private decimal? _cdefine27;
        private string _citemcode;
        private string _citem_class;
        private string _citemname;
        private string _citem_cname;
        private string _cfree3;
        private string _cfree4;
        private string _cfree5;
        private string _cfree6;
        private string _cfree7;
        private string _cfree8;
        private string _cfree9;
        private string _cfree10;
        private decimal? _iinvexchrate;
        private long _id;
        private string _cdefine28;
        private string _cdefine29;
        private string _cdefine30;
        private string _cdefine31;
        private string _cdefine32;
        private string _cdefine33;
        private long? _cdefine34;
        private long? _cdefine35;
        private DateTime? _cdefine36;
        private DateTime? _cdefine37;
        private string _cunitid = "null";
        private decimal? _fsalecost;
        private decimal? _fsaleprice;
        private long? _icusbomid;
        private long? _ippartseqid;
        private long? _ippartid;
        private decimal? _ippartqty;
        private string _ccusinvcode;
        private string _ccusinvname;
        private bool _brefpa = false;
        private decimal? _fcusminprice;
        private long? _irowno;
        private bool _bsaleprice;
        private bool _bgift;
        private decimal? _fdhquantity;
        private decimal? _fdhnum;
        private decimal? _fhtquantity;
        private decimal? _fhtnum;
        private string _cbsysbarcode;
        private Guid _body_outid;
        /// <summary>
        /// 
        /// </summary>
        public long AutoID
        {
            set { _autoid = value; }
            get { return _autoid; }
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
        public decimal? iQuantity
        {
            set { _iquantity = value; }
            get { return _iquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNum
        {
            set { _inum = value; }
            get { return _inum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iQuotedPrice
        {
            set { _iquotedprice = value; }
            get { return _iquotedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iUnitPrice
        {
            set { _iunitprice = value; }
            get { return _iunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxUnitPrice
        {
            set { _itaxunitprice = value; }
            get { return _itaxunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iMoney
        {
            set { _imoney = value; }
            get { return _imoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTax
        {
            set { _itax = value; }
            get { return _itax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iSum
        {
            set { _isum = value; }
            get { return _isum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iDisCount
        {
            set { _idiscount = value; }
            get { return _idiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatUnitPrice
        {
            set { _inatunitprice = value; }
            get { return _inatunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatMoney
        {
            set { _inatmoney = value; }
            get { return _inatmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatTax
        {
            set { _inattax = value; }
            get { return _inattax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatSum
        {
            set { _inatsum = value; }
            get { return _inatsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iNatDisCount
        {
            set { _inatdiscount = value; }
            get { return _inatdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cMemo
        {
            set { _cmemo = value; }
            get { return _cmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree1
        {
            set { _cfree1 = value; }
            get { return _cfree1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree2
        {
            set { _cfree2 = value; }
            get { return _cfree2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? KL
        {
            set { _kl = value; }
            get { return _kl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? KL2
        {
            set { _kl2 = value; }
            get { return _kl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iTaxRate
        {
            set { _itaxrate = value; }
            get { return _itaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine22
        {
            set { _cdefine22 = value; }
            get { return _cdefine22; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine23
        {
            set { _cdefine23 = value; }
            get { return _cdefine23; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine24
        {
            set { _cdefine24 = value; }
            get { return _cdefine24; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine25
        {
            set { _cdefine25 = value; }
            get { return _cdefine25; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine26
        {
            set { _cdefine26 = value; }
            get { return _cdefine26; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? cDefine27
        {
            set { _cdefine27 = value; }
            get { return _cdefine27; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItemCode
        {
            set { _citemcode = value; }
            get { return _citemcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItem_class
        {
            set { _citem_class = value; }
            get { return _citem_class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItemName
        {
            set { _citemname = value; }
            get { return _citemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cItem_CName
        {
            set { _citem_cname = value; }
            get { return _citem_cname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree3
        {
            set { _cfree3 = value; }
            get { return _cfree3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree4
        {
            set { _cfree4 = value; }
            get { return _cfree4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree5
        {
            set { _cfree5 = value; }
            get { return _cfree5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree6
        {
            set { _cfree6 = value; }
            get { return _cfree6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree7
        {
            set { _cfree7 = value; }
            get { return _cfree7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree8
        {
            set { _cfree8 = value; }
            get { return _cfree8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree9
        {
            set { _cfree9 = value; }
            get { return _cfree9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cFree10
        {
            set { _cfree10 = value; }
            get { return _cfree10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iInvExchRate
        {
            set { _iinvexchrate = value; }
            get { return _iinvexchrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine28
        {
            set { _cdefine28 = value; }
            get { return _cdefine28; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine29
        {
            set { _cdefine29 = value; }
            get { return _cdefine29; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine30
        {
            set { _cdefine30 = value; }
            get { return _cdefine30; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine31
        {
            set { _cdefine31 = value; }
            get { return _cdefine31; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine32
        {
            set { _cdefine32 = value; }
            get { return _cdefine32; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cDefine33
        {
            set { _cdefine33 = value; }
            get { return _cdefine33; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cDefine34
        {
            set { _cdefine34 = value; }
            get { return _cdefine34; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cDefine35
        {
            set { _cdefine35 = value; }
            get { return _cdefine35; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine36
        {
            set { _cdefine36 = value; }
            get { return _cdefine36; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? cDefine37
        {
            set { _cdefine37 = value; }
            get { return _cdefine37; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cUnitID
        {
            set { _cunitid = value; }
            get { return _cunitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fSaleCost
        {
            set { _fsalecost = value; }
            get { return _fsalecost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fSalePrice
        {
            set { _fsaleprice = value; }
            get { return _fsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iCusBomID
        {
            set { _icusbomid = value; }
            get { return _icusbomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iPPartSeqID
        {
            set { _ippartseqid = value; }
            get { return _ippartseqid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? iPPartID
        {
            set { _ippartid = value; }
            get { return _ippartid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iPPartQty
        {
            set { _ippartqty = value; }
            get { return _ippartqty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusInvCode
        {
            set { _ccusinvcode = value; }
            get { return _ccusinvcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cCusInvName
        {
            set { _ccusinvname = value; }
            get { return _ccusinvname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool brefpa
        {
            set { _brefpa = value; }
            get { return _brefpa; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fcusminprice
        {
            set { _fcusminprice = value; }
            get { return _fcusminprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? irowno
        {
            set { _irowno = value; }
            get { return _irowno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bsaleprice
        {
            set { _bsaleprice = value; }
            get { return _bsaleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bgift
        {
            set { _bgift = value; }
            get { return _bgift; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fdhquantity
        {
            set { _fdhquantity = value; }
            get { return _fdhquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fdhnum
        {
            set { _fdhnum = value; }
            get { return _fdhnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fhtquantity
        {
            set { _fhtquantity = value; }
            get { return _fhtquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fhtnum
        {
            set { _fhtnum = value; }
            get { return _fhtnum; }
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
        public Guid body_outid
        {
            set { _body_outid = value; }
            get { return _body_outid; }
        }
        #endregion Model

    }
}

