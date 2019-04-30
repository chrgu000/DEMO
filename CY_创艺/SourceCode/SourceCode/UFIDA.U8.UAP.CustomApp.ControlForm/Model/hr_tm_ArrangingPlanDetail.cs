using System;
namespace UFIDA.U8.UAP.CustomApp.ControlForm.Model
{
	/// <summary>
	/// hr_tm_ArrangingPlanDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class hr_tm_ArrangingPlanDetail
	{
		public hr_tm_ArrangingPlanDetail()
		{}
		#region Model
		private string _voucherid;
        private string _date;
		private string _dutycode;
		private string _dutypepole;
		private string _dutypepolenames;
		/// <summary>
		/// 
		/// </summary>
		public string VoucherID
		{
			set{ _voucherid=value;}
			get{return _voucherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DutyCode
		{
			set{ _dutycode=value;}
			get{return _dutycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DutyPepole
		{
			set{ _dutypepole=value;}
			get{return _dutypepole;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DutyPepoleNames
		{
			set{ _dutypepolenames=value;}
			get{return _dutypepolenames;}
		}
		#endregion Model

	}
}

