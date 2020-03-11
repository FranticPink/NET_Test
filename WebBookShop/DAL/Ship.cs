using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Ship
	/// </summary>
	public partial class Ship
	{
		public Ship()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string shipNo,string orderNo,string ISBN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ship");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo and ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,3),
					new SqlParameter("@orderNo", SqlDbType.Char,15),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)			};
			parameters[0].Value = shipNo;
			parameters[1].Value = orderNo;
			parameters[2].Value = ISBN;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Ship model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ship(");
			strSql.Append("shipNo,orderNo,ISBN)");
			strSql.Append(" values (");
			strSql.Append("@shipNo,@orderNo,@ISBN)");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,3),
					new SqlParameter("@orderNo", SqlDbType.Char,15),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.shipNo;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.ISBN;

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
		public bool Update(BookShop.Model.Ship model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ship set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("shipNo=@shipNo,");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("ISBN=@ISBN");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo and ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,3),
					new SqlParameter("@orderNo", SqlDbType.Char,15),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.shipNo;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.ISBN;

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
		public bool Delete(string shipNo,string orderNo,string ISBN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ship ");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo and ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,3),
					new SqlParameter("@orderNo", SqlDbType.Char,15),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)			};
			parameters[0].Value = shipNo;
			parameters[1].Value = orderNo;
			parameters[2].Value = ISBN;

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
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Ship GetModel(string shipNo,string orderNo,string ISBN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 shipNo,orderNo,ISBN from Ship ");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo and ISBN=@ISBN ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,3),
					new SqlParameter("@orderNo", SqlDbType.Char,15),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50)			};
			parameters[0].Value = shipNo;
			parameters[1].Value = orderNo;
			parameters[2].Value = ISBN;

			BookShop.Model.Ship model=new BookShop.Model.Ship();
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
		public BookShop.Model.Ship DataRowToModel(DataRow row)
		{
			BookShop.Model.Ship model=new BookShop.Model.Ship();
			if (row != null)
			{
				if(row["shipNo"]!=null)
				{
					model.shipNo=row["shipNo"].ToString();
				}
				if(row["orderNo"]!=null)
				{
					model.orderNo=row["orderNo"].ToString();
				}
				if(row["ISBN"]!=null)
				{
					model.ISBN=row["ISBN"].ToString();
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
			strSql.Append("select shipNo,orderNo,ISBN ");
			strSql.Append(" FROM Ship ");
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
			strSql.Append(" shipNo,orderNo,ISBN ");
			strSql.Append(" FROM Ship ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Ship ");
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
			strSql.Append(")AS Row, T.*  from Ship T ");
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
			parameters[0].Value = "Ship";
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

