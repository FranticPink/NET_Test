using System;
namespace BookShop.Model
{
	/// <summary>
	/// Sale:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sale
	{
		public Sale()
		{}
		#region Model
		private string _orderno;
		private string _isbn;
		private int? _quantity;
		private string _bookState;
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
		public string ISBN
		{
			set{ _isbn=value;}
			get{return _isbn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bookState
		{
			set{ _bookState=value;}
			get{return _bookState;}
		}
		#endregion Model

	}
}

