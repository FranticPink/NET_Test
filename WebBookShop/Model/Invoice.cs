using System;
namespace BookShop.Model
{
	/// <summary>
	/// Invoice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Invoice
	{
		public Invoice()
		{}
		#region Model
		private string _invoiceno;
		private string _invoiceunit;
		private decimal? _invoicesum;
		/// <summary>
		/// 
		/// </summary>
		public string invoiceNo
		{
			set{ _invoiceno=value;}
			get{return _invoiceno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string invoiceUnit
		{
			set{ _invoiceunit=value;}
			get{return _invoiceunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? invoiceSum
		{
			set{ _invoicesum=value;}
			get{return _invoicesum;}
		}
		#endregion Model

	}
}

