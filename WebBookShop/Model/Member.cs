using System;
namespace BookShop.Model
{
	/// <summary>
	/// Member:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Member
	{
		public Member()
		{}
		#region Model
		private string _memberno;
		private string _mempassword;
		private string _memname;
		private string _sex;
		private DateTime? _birthday;
		private string _telephone;
		private string _email;
		private string _address;
		private string _zipcode;
		private decimal? _totalamount;
		private string _memlevel;
		private decimal? _discount;
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
		public string memPassword
		{
			set{ _mempassword=value;}
			get{return _mempassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memName
		{
			set{ _memname=value;}
			get{return _memname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
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
		public decimal? totalAmount
		{
			set{ _totalamount=value;}
			get{return _totalamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memLevel
		{
			set{ _memlevel=value;}
			get{return _memlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		#endregion Model

	}
}

