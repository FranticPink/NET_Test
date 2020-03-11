using System;
namespace BookShop.Model
{
	/// <summary>
	/// Book:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Book
	{
		public Book()
		{}
		#region Model
		private string _isbn;
		private string _booktitle;
		private string _author;
		private DateTime? _publishdate;
		private int? _version;
		private int? _stocknumber;
		private decimal _price;
		private decimal _saleprice;
		private string _introduction;
		private string _catalog;
		private int? _categoryid;
		private int? _pressno;
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
		public string bookTitle
		{
			set{ _booktitle=value;}
			get{return _booktitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? publishDate
		{
			set{ _publishdate=value;}
			get{return _publishdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? stockNumber
		{
			set{ _stocknumber=value;}
			get{return _stocknumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal salePrice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string introduction
		{
			set{ _introduction=value;}
			get{return _introduction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string catalog
		{
			set{ _catalog=value;}
			get{return _catalog;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? categoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pressNo
		{
			set{ _pressno=value;}
			get{return _pressno;}
		}
		#endregion Model

	}
}

