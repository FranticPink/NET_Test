using System;
namespace BookShop.Model
{
	/// <summary>
	/// Press:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Press
	{
		public Press()
		{}
		#region Model
		private int _pressno;
		private string _pressname;
		private string _adress;
		private string _zipcode;
		private string _contactperson;
		private string _telephone;
		private string _fax;
		private string _email;
		/// <summary>
		/// 
		/// </summary>
		public int pressNo
		{
			set{ _pressno=value;}
			get{return _pressno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pressName
		{
			set{ _pressname=value;}
			get{return _pressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adress
		{
			set{ _adress=value;}
			get{return _adress;}
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

