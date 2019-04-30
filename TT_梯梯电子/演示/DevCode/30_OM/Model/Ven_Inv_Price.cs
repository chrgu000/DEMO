using System;
namespace OM.Model
{
    /// <summary>
    /// Ven_Inv_Price:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Ven_Inv_Price
    {
        public Ven_Inv_Price()
        { }
        #region Model
        private long _autoid;
        private string _cvencode;
        private string _cinvcode;
        private DateTime _denabledate;
        private DateTime? _ddisabledate;
        private string _cexch_name;
        private long _bpromotion;
        private string _cmemo;
        private long _isupplytype = 1;
        private long _btaxcost = 1;
        private string _ctermcode;
        private decimal _ilowerlimit;
        private decimal? _iupperlimit;
        private decimal _iunitprice;
        private decimal _itaxrate;
        private decimal _itaxunitprice;
        private long? _ipriceautoid;
        private string _cfree1;
        private string _cfree2;
        private string _cfree3;
        private string _cfree4;
        private string _cfree5;
        private string _cfree6;
        private string _cfree7;
        private string _cfree8;
        private string _cfree9;
        private string _cfree10;
        private string _csource;
        private string _csourcecode;
        private string _csourceautoid;
        /// <summary>
        /// 
        /// </summary>
        public long Autoid
        {
            set { _autoid = value; }
            get { return _autoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cVenCode
        {
            set { _cvencode = value; }
            get { return _cvencode; }
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
        public DateTime dEnableDate
        {
            set { _denabledate = value; }
            get { return _denabledate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dDisableDate
        {
            set { _ddisabledate = value; }
            get { return _ddisabledate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cExch_Name
        {
            set { _cexch_name = value; }
            get { return _cexch_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long bPromotion
        {
            set { _bpromotion = value; }
            get { return _bpromotion; }
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
        public long iSupplyType
        {
            set { _isupplytype = value; }
            get { return _isupplytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long btaxcost
        {
            set { _btaxcost = value; }
            get { return _btaxcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cTermCode
        {
            set { _ctermcode = value; }
            get { return _ctermcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iLowerLimit
        {
            set { _ilowerlimit = value; }
            get { return _ilowerlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? iUpperLimit
        {
            set { _iupperlimit = value; }
            get { return _iupperlimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iUnitPrice
        {
            set { _iunitprice = value; }
            get { return _iunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iTaxRate
        {
            set { _itaxrate = value; }
            get { return _itaxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal iTaxUnitPrice
        {
            set { _itaxunitprice = value; }
            get { return _itaxunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ipriceautoid
        {
            set { _ipriceautoid = value; }
            get { return _ipriceautoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree1
        {
            set { _cfree1 = value; }
            get { return _cfree1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree2
        {
            set { _cfree2 = value; }
            get { return _cfree2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree3
        {
            set { _cfree3 = value; }
            get { return _cfree3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree4
        {
            set { _cfree4 = value; }
            get { return _cfree4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree5
        {
            set { _cfree5 = value; }
            get { return _cfree5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree6
        {
            set { _cfree6 = value; }
            get { return _cfree6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree7
        {
            set { _cfree7 = value; }
            get { return _cfree7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree8
        {
            set { _cfree8 = value; }
            get { return _cfree8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree9
        {
            set { _cfree9 = value; }
            get { return _cfree9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfree10
        {
            set { _cfree10 = value; }
            get { return _cfree10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSource
        {
            set { _csource = value; }
            get { return _csource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSourceCode
        {
            set { _csourcecode = value; }
            get { return _csourcecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSourceAutoid
        {
            set { _csourceautoid = value; }
            get { return _csourceautoid; }
        }
        #endregion Model

    }
}

