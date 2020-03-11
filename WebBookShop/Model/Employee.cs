using System;
namespace BookShop.Model
{
	/// <summary>
	/// Employee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Employee
	{
		public Employee()
		{}
		#region Model
		private string _employeeno;
		private string _emppassword;
		private string _empname;
		private string _sex;
		private DateTime? _birthday;
		private string _department;
		private string _title;
		private decimal _salary;
		private string _address;
		private string _telephone;
		private string _email;
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
		public string empPassword
		{
			set{ _emppassword=value;}
			get{return _emppassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string empName
		{
			set{ _empname=value;}
			get{return _empname;}
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
		public string department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal salary
		{
			set{ _salary=value;}
			get{return _salary;}
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
		#endregion Model

	}
}

