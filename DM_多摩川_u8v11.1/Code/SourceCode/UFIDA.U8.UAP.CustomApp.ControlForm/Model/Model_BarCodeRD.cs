using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class Model_BarCodeRD
    {
        public Model_BarCodeRD()
		{}
		#region Model
		private int _iid;
		private string _scode;
		private string _barcode;
		private string _xbarcode;
		private string _stype;
		private int? _exsid;
		private string _excode;
		private int? _exrowno;
		private string _cinvcode;
		private decimal? _qty;
		private string _createuid;
		private DateTime? _createdate;
		private int? _rdtype;
		/// <summary>
		/// 
		/// </summary>
		public int iID
		{
			set{ _iid=value;}
			get{return _iid;}
		}
		/// <summary>
		/// 扫描批次（同一次扫描的使用相同值）
		/// </summary>
		public string sCode
		{
			set{ _scode=value;}
			get{return _scode;}
		}
		/// <summary>
		/// 条形码
		/// </summary>
		public string BarCode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XBarCode
		{
			set{ _xbarcode=value;}
			get{return _xbarcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sType
		{
			set{ _stype=value;}
			get{return _stype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExsID
		{
			set{ _exsid=value;}
			get{return _exsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExCode
		{
			set{ _excode=value;}
			get{return _excode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExRowNo
		{
			set{ _exrowno=value;}
			get{return _exrowno;}
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
		public decimal? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUid
		{
			set{ _createuid=value;}
			get{return _createuid;}
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
		/// 收发类别，0 调拨，1 入库，2 出库
		/// </summary>
		public int? RDType
		{
			set{ _rdtype=value;}
			get{return _rdtype;}
		}

		#endregion Model

	}
}

