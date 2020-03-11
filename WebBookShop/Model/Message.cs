using System;
namespace BookShop.Model
{
	/// <summary>
	/// Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private string _messageno;
		private string _employeeno;
		private string _memberno;
		private DateTime? _releasedate;
		private string _messagecontent;
		private string _replycontent;
		private DateTime? _replydate;
		/// <summary>
		/// 
		/// </summary>
		public string messageNo
		{
			set{ _messageno=value;}
			get{return _messageno;}
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
		public string memberNo
		{
			set{ _memberno=value;}
			get{return _memberno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? releaseDate
		{
			set{ _releasedate=value;}
			get{return _releasedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string messageContent
		{
			set{ _messagecontent=value;}
			get{return _messagecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string replyContent
		{
			set{ _replycontent=value;}
			get{return _replycontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? replyDate
		{
			set{ _replydate=value;}
			get{return _replydate;}
		}
		#endregion Model

	}
}

