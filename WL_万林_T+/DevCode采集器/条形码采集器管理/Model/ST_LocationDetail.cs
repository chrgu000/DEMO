using System;
namespace BarCode.Model
{
    /// <summary>
    /// ST_LocationDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ST_LocationDetail
    {
        public ST_LocationDetail()
        { }
        #region Model
        private decimal? _quantity;
        private decimal? _quantity2;
        private decimal? _basequantity;
        private decimal? _subquantity;
        private decimal? _changerate;
        private string _batch;
        private string _memo;
        private DateTime? _ts;
        private int _id;
        private int _idinvlocation;
        private int? _idbaseunit;
        private int? _idsubunit;
        private int? _idunit;
        private int? _idunit2;
        private int _idassemdetachdetaildto;
        private int _idrdrecorddetaildto;
        private int _idshapedetaildto;
        private DateTime? _expirydate;
        private DateTime? _productiondate;
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity2
        {
            set { _quantity2 = value; }
            get { return _quantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? baseQuantity
        {
            set { _basequantity = value; }
            get { return _basequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? subQuantity
        {
            set { _subquantity = value; }
            get { return _subquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? changeRate
        {
            set { _changerate = value; }
            get { return _changerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ts
        {
            set { _ts = value; }
            get { return _ts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idinvlocation
        {
            set { _idinvlocation = value; }
            get { return _idinvlocation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idbaseunit
        {
            set { _idbaseunit = value; }
            get { return _idbaseunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idsubunit
        {
            set { _idsubunit = value; }
            get { return _idsubunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idunit
        {
            set { _idunit = value; }
            get { return _idunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? idunit2
        {
            set { _idunit2 = value; }
            get { return _idunit2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idAssemDetachDetailDTO
        {
            set { _idassemdetachdetaildto = value; }
            get { return _idassemdetachdetaildto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idRDRecordDetailDTO
        {
            set { _idrdrecorddetaildto = value; }
            get { return _idrdrecorddetaildto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idShapeDetailDTO
        {
            set { _idshapedetaildto = value; }
            get { return _idshapedetaildto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? expiryDate
        {
            set { _expirydate = value; }
            get { return _expirydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? productionDate
        {
            set { _productiondate = value; }
            get { return _productiondate; }
        }
        #endregion Model

    }
}

