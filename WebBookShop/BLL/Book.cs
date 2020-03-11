using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop.Model;
namespace BookShop.BLL
{
	/// <summary>
	/// Book
	/// </summary>
	public partial class Book
	{
		private readonly BookShop.DAL.Book dal=new BookShop.DAL.Book();
		public Book()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ISBN)
		{
			return dal.Exists(ISBN);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Book model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Book model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ISBN)
		{
			
			return dal.Delete(ISBN);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ISBNlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(ISBNlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Book GetModel(string ISBN)
		{
			
			return dal.GetModel(ISBN);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BookShop.Model.Book GetModelByCache(string ISBN)
		{
			
			string CacheKey = "BookModel-" + ISBN;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ISBN);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BookShop.Model.Book)objModel;
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
		public List<BookShop.Model.Book> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Book> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.Book> modelList = new List<BookShop.Model.Book>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.Book model;
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
        public DataSet SearchList(string strWhere)
        {

            return dal.SearchList(strWhere);
        }
		#endregion  ExtensionMethod
	}
}

