using System;
namespace BookShop.Model
{
	/// <summary>
	/// Company:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Company
	{
		public Company()
		{}
		#region Model
		private string _compantno;
		private string _companyname;
		private string _address;
		private string _zipcode;
		private string _contactperson;
		private string _telephone;
		private string _fax;
		private string _email;
		/// <summary>
		/// 
		/// </summary>
		public string compantNo
		{
			set{ _compantno=value;}
			get{return _compantno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
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
		public string contactPerson
		{
			set{ _contactperson=value;}
			get{return _contactperson;}
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
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		#endregion Model

	}
}

