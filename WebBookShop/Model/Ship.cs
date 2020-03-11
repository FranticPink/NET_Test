using System;
namespace BookShop.Model
{
	/// <summary>
	/// Ship:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Ship
	{
		public Ship()
		{}
		#region Model
		private string _shipno;
		private string _orderno;
		private string _isbn;
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
		public string ISBN
		{
			set{ _isbn=value;}
			get{return _isbn;}
		}
		#endregion Model

	}
}

