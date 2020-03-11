using System;
namespace BookShop.Model
{
	/// <summary>
	/// ShipSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ShipSheet
	{
		public ShipSheet()
		{}
		#region Model
		private string _shipno;
		private string _orderno;
		private DateTime? _shipdate;
		private string _companyno;
		private string _invoiceno;
		/// <summary>
		/// 
		/// </summary>
		public string shipNo
		{
			set{ _shipno=value;}
			get{return _shipno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? shipDate
		{
			set{ _shipdate=value;}
			get{return _shipdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyNo
		{
			set{ _companyno=value;}
			get{return _companyno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invoiceNo
		{
			set{ _invoiceno=value;}
			get{return _invoiceno;}
		}
		#endregion Model

	}
}

