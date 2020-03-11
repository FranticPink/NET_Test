using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop.Model;
namespace BookShop.BLL
{
	/// <summary>
	/// Invoice
	/// </summary>
	public partial class Invoice
	{
		private readonly BookShop.DAL.Invoice dal=new BookShop.DAL.Invoice();
		public Invoice()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string invoiceNo)
		{
			return dal.Exists(invoiceNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Invoice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Invoice model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string invoiceNo)
		{
			
			return dal.Delete(invoiceNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string invoiceNolist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(invoiceNolist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Invoice GetModel(string invoiceNo)
		{
			
			return dal.GetModel(invoiceNo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BookShop.Model.Invoice GetModelByCache(string invoiceNo)
		{
			
			string CacheKey = "InvoiceModel-" + invoiceNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(invoiceNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BookShop.Model.Invoice)objModel;
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
		public List<BookShop.Model.Invoice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Invoice> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.Invoice> modelList = new List<BookShop.Model.Invoice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.Invoice model;
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

