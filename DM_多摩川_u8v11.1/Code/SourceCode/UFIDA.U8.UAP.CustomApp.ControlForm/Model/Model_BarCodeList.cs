using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class Model_BarCodeList
    {
        public Model_BarCodeList()
        {}

		private long _iid;
		private string _barcode;
		private long? _exsid;
		private string _excode;
		private long? _exrowno;
		private string _extype;
		private string _exvencode;
		private string _exvenname;
		private string _exdepcode;
		private string _exdepname;
		private decimal? _exquantity;
		private decimal? _exbatchqty;
		private string _cwhcode;
		private string _cwhname;
		private decimal? _iqty;
		private string _batch;
		private string _serialno;
		private string _poscode;
		private string _createusername;
		private DateTime? _createdate;
		private long? _prlongcout;
		private DateTime? _sysdate;
		private Guid _guid;
		private long? _afsid;
		private string _afcode;
		private long? _afrowno;
		private string _aftype;
		private string _afvencode;
		private string _afvenname;
		private string _afcusname;
		private string _afcuscode;
		private decimal? _afquantity;
		private string _xbarcode;
		private string _cinvcode;
		private string _cinvname;
		private string _cinvstd;
        private bool _valid;
        private int? _used;
        private string _barcodehis;
        private string _excptcode;
        private string _excptname;
        private string _excinvdefine3;
        private string _exccomunitname;
        private string _excmemo;
        private string _excinvdefine4;
        private string _excinvdefine5;

		/// <summary>
		/// 
		/// </summary>
		public long iID
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BarCode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 来源单据ID
		/// </summary>
		public long? ExsID
		{
			set{ _exsid=value;}
			get{return _exsid;}
		}
		/// <summary>
		/// 来源单据号
		/// </summary>
		public string ExCode
		{
			set{ _excode=value;}
			get{return _excode;}
		}
		/// <summary>
		/// 来源单据行号
		/// </summary>
		public long? ExRowNo
		{
			set{ _exrowno=value;}
			get{return _exrowno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExType
		{
			set{ _extype=value;}
			get{return _extype;}
		}
		/// <summary>
		/// 来源供应商编码
		/// </summary>
		public string ExVenCode
		{
			set{ _exvencode=value;}
			get{return _exvencode;}
		}
		/// <summary>
		/// 来源供应商
		/// </summary>
		public string ExVenName
		{
			set{ _exvenname=value;}
			get{return _exvenname;}
		}
		/// <summary>
		/// 来源客户编码
		/// </summary>
		public string ExDepCode
		{
			set{ _exdepcode=value;}
			get{return _exdepcode;}
		}
		/// <summary>
		/// 来源客户
		/// </summary>
		public string ExDepName
		{
			set{ _exdepname=value;}
			get{return _exdepname;}
		}
		/// <summary>
		/// 来源单据数量
		/// </summary>
		public decimal? ExQuantity
		{
			set{ _exquantity=value;}
			get{return _exquantity;}
		}
		/// <summary>
		/// 来源包装批量
		/// </summary>
		public decimal? ExBatchQty
		{
			set{ _exbatchqty=value;}
			get{return _exbatchqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cWhCode
		{
			set{ _cwhcode=value;}
			get{return _cwhcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cWhName
		{
			set{ _cwhname=value;}
			get{return _cwhname;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public decimal? iQty
		{
			set{ _iqty=value;}
			get{return _iqty;}
		}
		/// <summary>
		/// 批号
		/// </summary>
		public string Batch
		{
			set{ _batch=value;}
			get{return _batch;}
		}
		/// <summary>
		/// 序列号
		/// </summary>
		public string SerialNO
		{
			set{ _serialno=value;}
			get{return _serialno;}
		}
		/// <summary>
		/// 货位
		/// </summary>
		public string PosCode
		{
			set{ _poscode=value;}
			get{return _poscode;}
		}
		/// <summary>
		/// 制单人
		/// </summary>
		public string CreateUserName
		{
			set{ _createusername=value;}
			get{return _createusername;}
		}
		/// <summary>
		/// 制单日期
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 打印次数
		/// </summary>
		public long? PrlongCout
		{
			set{ _prlongcout=value;}
			get{return _prlongcout;}
		}
		/// <summary>
		/// 系统日期
		/// </summary>
		public DateTime? SysDate
		{
			set{ _sysdate=value;}
			get{return _sysdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid GUID
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 使用单据ID
		/// </summary>
		public long? AFsID
		{
			set{ _afsid=value;}
			get{return _afsid;}
		}
		/// <summary>
		/// 使用单据号
		/// </summary>
		public string AFCode
		{
			set{ _afcode=value;}
			get{return _afcode;}
		}
		/// <summary>
		/// 使用单据行号
		/// </summary>
		public long? AFRowNo
		{
			set{ _afrowno=value;}
			get{return _afrowno;}
		}
		/// <summary>
		/// 使用单据类型
		/// </summary>
		public string AFType
		{
			set{ _aftype=value;}
			get{return _aftype;}
		}
		/// <summary>
		/// 使用供应商编码
		/// </summary>
		public string AFVenCode
		{
			set{ _afvencode=value;}
			get{return _afvencode;}
		}
		/// <summary>
		/// 使用供应商
		/// </summary>
		public string AFVenName
		{
			set{ _afvenname=value;}
			get{return _afvenname;}
		}
		/// <summary>
		/// 使用客户
		/// </summary>
		public string AFCusName
		{
			set{ _afcusname=value;}
			get{return _afcusname;}
		}
		/// <summary>
		/// 使用客户编码
		/// </summary>
		public string AFCusCode
		{
			set{ _afcuscode=value;}
			get{return _afcuscode;}
		}
		/// <summary>
		/// 使用单据数量
		/// </summary>
		public decimal? AFQuantity
		{
			set{ _afquantity=value;}
			get{return _afquantity;}
		}
		/// <summary>
		/// 归属箱码
		/// </summary>
		public string XBarCode
		{
			set{ _xbarcode=value;}
			get{return _xbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvCode
		{
			set{ _cinvcode=value;}
			get{return _cinvcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvName
		{
			set{ _cinvname=value;}
			get{return _cinvname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cInvStd
		{
			set{ _cinvstd=value;}
			get{return _cinvstd;}
		}
		/// <summary>
		/// 判断条形码是否有效
		/// </summary>
		public bool valid
		{
			set{ _valid=value;}
			get{return _valid;}
        }		
        /// <summary>
        /// 条形码是否使用过，每次使用一次加1
        /// </summary>
        public int? Used
        {
            set { _used = value; }
            get { return _used; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string BarCodeHis
		{
			set{ _barcodehis=value;}
			get{return _barcodehis;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string ExcPTCode
        {
            set { _excptcode = value; }
            get { return _excptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExcPTName
        {
            set { _excptname = value; }
            get { return _excptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExcInvDefine3
        {
            set { _excinvdefine3 = value; }
            get { return _excinvdefine3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExcComUnitName
        {
            set { _exccomunitname = value; }
            get { return _exccomunitname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ExcMemo
        {
            set { _excmemo = value; }
            get { return _excmemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExcInvDefine4
        {
            set { _excinvdefine4 = value; }
            get { return _excinvdefine4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExcInvDefine5
        {
            set { _excinvdefine5 = value; }
            get { return _excinvdefine5; }
        }

	}
}

