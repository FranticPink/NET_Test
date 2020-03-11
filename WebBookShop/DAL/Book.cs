using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Book
	/// </summary>
	public partial class Book
	{
		public Book()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ISBN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Book");
			strSql.Append(" where ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ISBN;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Book model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Book(");
			strSql.Append("ISBN,bookTitle,author,publishDate,version,stockNumber,price,salePrice,introduction,catalog,categoryId,pressNo)");
			strSql.Append(" values (");
			strSql.Append("@ISBN,@bookTitle,@author,@publishDate,@version,@stockNumber,@price,@salePrice,@introduction,@catalog,@categoryId,@pressNo)");
			SqlParameter[] parameters = {
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@bookTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@author", SqlDbType.NVarChar,200),
					new SqlParameter("@publishDate", SqlDbType.DateTime),
					new SqlParameter("@version", SqlDbType.Int,4),
					new SqlParameter("@stockNumber", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@salePrice", SqlDbType.Money,8),
					new SqlParameter("@introduction", SqlDbType.NVarChar,-1),
					new SqlParameter("@catalog", SqlDbType.NVarChar,-1),
					new SqlParameter("@categoryId", SqlDbType.Int,4),
					new SqlParameter("@pressNo", SqlDbType.Int,4)};
			parameters[0].Value = model.ISBN;
			parameters[1].Value = model.bookTitle;
			parameters[2].Value = model.author;
			parameters[3].Value = model.publishDate;
			parameters[4].Value = model.version;
			parameters[5].Value = model.stockNumber;
			parameters[6].Value = model.price;
			parameters[7].Value = model.salePrice;
			parameters[8].Value = model.introduction;
			parameters[9].Value = model.catalog;
			parameters[10].Value = model.categoryId;
			parameters[11].Value = model.pressNo;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Book model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Book set ");
			strSql.Append("bookTitle=@bookTitle,");
			strSql.Append("author=@author,");
			strSql.Append("publishDate=@publishDate,");
			strSql.Append("version=@version,");
			strSql.Append("stockNumber=@stockNumber,");
			strSql.Append("price=@price,");
			strSql.Append("salePrice=@salePrice,");
			strSql.Append("introduction=@introduction,");
			strSql.Append("catalog=@catalog,");
			strSql.Append("categoryId=@categoryId,");
			strSql.Append("pressNo=@pressNo");
			strSql.Append(" where ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@bookTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@author", SqlDbType.NVarChar,200),
					new SqlParameter("@publishDate", SqlDbType.DateTime),
					new SqlParameter("@version", SqlDbType.Int,4),
					new SqlParameter("@stockNumber", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@salePrice", SqlDbType.Money,8),
					new SqlParameter("@introduction", SqlDbType.NVarChar,-1),
					new SqlParameter("@catalog", SqlDbType.NVarChar,-1),
					new SqlParameter("@categoryId", SqlDbType.Int,4),
					new SqlParameter("@pressNo", SqlDbType.Int,4),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.bookTitle;
			parameters[1].Value = model.author;
			parameters[2].Value = model.publishDate;
			parameters[3].Value = model.version;
			parameters[4].Value = model.stockNumber;
			parameters[5].Value = model.price;
			parameters[6].Value = model.salePrice;
			parameters[7].Value = model.introduction;
			parameters[8].Value = model.catalog;
			parameters[9].Value = model.categoryId;
			parameters[10].Value = model.pressNo;
			parameters[11].Value = model.ISBN;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ISBN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Book ");
			strSql.Append(" where ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ISBN;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ISBNlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Book ");
			strSql.Append(" where ISBN in ("+ISBNlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Book GetModel(string ISBN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ISBN,bookTitle,author,publishDate,version,stockNumber,price,salePrice,introduction,catalog,categoryId,pressNo from Book ");
			strSql.Append(" where ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)			};
			parameters[0].Value = ISBN;

			BookShop.Model.Book model=new BookShop.Model.Book();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Book DataRowToModel(DataRow row)
		{
			BookShop.Model.Book model=new BookShop.Model.Book();
			if (row != null)
			{
				if(row["ISBN"]!=null)
				{
					model.ISBN=row["ISBN"].ToString();
				}
				if(row["bookTitle"]!=null)
				{
					model.bookTitle=row["bookTitle"].ToString();
				}
				if(row["author"]!=null)
				{
					model.author=row["author"].ToString();
				}
				if(row["publishDate"]!=null && row["publishDate"].ToString()!="")
				{
					model.publishDate=DateTime.Parse(row["publishDate"].ToString());
				}
				if(row["version"]!=null && row["version"].ToString()!="")
				{
					model.version=int.Parse(row["version"].ToString());
				}
				if(row["stockNumber"]!=null && row["stockNumber"].ToString()!="")
				{
					model.stockNumber=int.Parse(row["stockNumber"].ToString());
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["salePrice"]!=null && row["salePrice"].ToString()!="")
				{
					model.salePrice=decimal.Parse(row["salePrice"].ToString());
				}
				if(row["introduction"]!=null)
				{
					model.introduction=row["introduction"].ToString();
				}
				if(row["catalog"]!=null)
				{
					model.catalog=row["catalog"].ToString();
				}
				if(row["categoryId"]!=null && row["categoryId"].ToString()!="")
				{
					model.categoryId=int.Parse(row["categoryId"].ToString());
				}
				if(row["pressNo"]!=null && row["pressNo"].ToString()!="")
				{
					model.pressNo=int.Parse(row["pressNo"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ISBN,bookTitle,author,publishDate,version,stockNumber,price,salePrice,introduction,catalog,categoryId,pressNo ");
			strSql.Append(" FROM Book ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ISBN,bookTitle,author,publishDate,version,stockNumber,price,salePrice,introduction,catalog,categoryId,pressNo ");
			strSql.Append(" FROM Book ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }

			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet SearchList(string strWhere)
        {

            return DbHelperSQL.ExecuteProc("proc_SearchBook", "@keywords", strWhere);
        }
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Book ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ISBN desc");
			}
			strSql.Append(")AS Row, T.*  from Book T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Book";
			parameters[1].Value = "ISBN";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

