using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
    /// <summary>
    /// _AmountOfExchangeProfitAndLoss:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class _AmountOfExchangeProfitAndLoss
    {
        public _AmountOfExchangeProfitAndLoss()
        { }
        #region Model
        private long _iyear;
        private long _iperiod;
        private long _autoid;
        private string _ccode;
        private long? _irowno;
        private string _cexch_name;
        private DateTime? _ddate;
        private string _cinvcode;
        private string _cinvname;
        private string _cinvstd;
        private decimal? _iorisum;
        private decimal? _nflat;
        private decimal? _nflat2;
        private decimal? _amountofexchangeprofitandloss;
        private string _ino_id;
        private string _csign;
        private long _i_id;
        private long _redi_id;
        /// <summary>
        /// 
        /// </summary>
        public long iYear
        {
            set { _iyear = value; }
            get { return _iyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long iPeriod
        {
            set { _iperiod = value; }
            get { return _iperiod; }
        }
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
        public string cCode
        {
            set { _ccode = value; }
            get { return _ccode; }
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
        public string cExch_Name
        {
            set { _cexch_name = value; }
            get { return _cexch_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? dDate
        {
            set { _ddate = value; }
            get { return _ddate; }
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
        public decimal? iOriSum
        {
            set { _iorisum = value; }
            get { return _iorisum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? nflat
        {
            set { _nflat = value; }
            get { return _nflat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? nflat2
        {
            set { _nflat2 = value; }
            get { return _nflat2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AmountOfExchangeProfitAndLoss
        {
            set { _amountofexchangeprofitandloss = value; }
            get { return _amountofexchangeprofitandloss; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ino_id
        {
            set { _ino_id = value; }
            get { return _ino_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cSign
        {
            set { _csign = value; }
            get { return _csign; }
        }

        /// <summary>
        /// 
        /// </summary>
        public long i_ID
        {
            set { _i_id = value; }
            get { return _i_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long redi_ID
        {
            set { _redi_id = value; }
            get { return _redi_id; }
        }
        #endregion Model

    }
}

