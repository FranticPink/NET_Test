using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop.Model;
namespace BookShop.BLL
{
	/// <summary>
	/// Employee
	/// </summary>
	public partial class Employee
	{
		private readonly BookShop.DAL.Employee dal=new BookShop.DAL.Employee();
		public Employee()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string employeeNo)
		{
			return dal.Exists(employeeNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Employee model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Employee model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string employeeNo)
		{
			
			return dal.Delete(employeeNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string employeeNolist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(employeeNolist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Employee GetModel(string employeeNo)
		{
			
			return dal.GetModel(employeeNo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BookShop.Model.Employee GetModelByCache(string employeeNo)
		{
			
			string CacheKey = "EmployeeModel-" + employeeNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(employeeNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BookShop.Model.Employee)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Employee> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Employee> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.Employee> modelList = new List<BookShop.Model.Employee>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.Employee model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 创建独一无二的ID
        /// </summary>
        /// <returns></returns>
        public string CreateNo()
        {
            return dal.CreateNo();
        }
        /// <summary>
        /// 验证ID是否存在
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool ValidateNo(string str)
        {
            return dal.ValidateNo(str);
        }
		#endregion  ExtensionMethod
	}
}

