using System;
namespace BookShop.Model
{
	/// <summary>
	/// OrderSheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderSheet
	{
		public OrderSheet()
		{}
		#region Model
		private string _orderno;
		private string _memberno;
		private string _employeeno;
		private DateTime? _orderdate;
		private decimal? _ordermoney;
		private string _payway;
		private string _payflag;
		private string _orderstate;
		private string _invoiceunit;
		private string _receiver;
		private string _zipcode;
		private string _shipaddress;
		private string _shiptel;
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
		public string memberNo
		{
			set{ _memberno=value;}
			get{return _memberno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string employeeNo
		{
			set{ _employeeno=value;}
			get{return _employeeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? orderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? orderMoney
		{
			set{ _ordermoney=value;}
			get{return _ordermoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string payWay
		{
			set{ _payway=value;}
			get{return _payway;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string payFlag
		{
			set{ _payflag=value;}
			get{return _payflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderState
		{
			set{ _orderstate=value;}
			get{return _orderstate;}
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
		public string receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shipAddress
		{
			set{ _shipaddress=value;}
			get{return _shipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shipTel
		{
			set{ _shiptel=value;}
			get{return _shiptel;}
		}
		#endregion Model

	}
}

