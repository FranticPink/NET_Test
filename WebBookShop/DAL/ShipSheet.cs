using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Maticsoft.Common;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:ShipSheet
	/// </summary>
	public partial class ShipSheet
	{
		public ShipSheet()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string shipNo,string orderNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ShipSheet");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,12),
					new SqlParameter("@orderNo", SqlDbType.Char,15)			};
			parameters[0].Value = shipNo;
			parameters[1].Value = orderNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.ShipSheet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ShipSheet(");
			strSql.Append("shipNo,orderNo,shipDate,companyNo,invoiceNo)");
			strSql.Append(" values (");
			strSql.Append("@shipNo,@orderNo,@shipDate,@companyNo,@invoiceNo)");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,12),
					new SqlParameter("@orderNo", SqlDbType.Char,15),
					new SqlParameter("@shipDate", SqlDbType.DateTime),
					new SqlParameter("@companyNo", SqlDbType.Char,12),
					new SqlParameter("@invoiceNo", SqlDbType.NChar,10)};
			parameters[0].Value = model.shipNo;
			parameters[1].Value = model.orderNo;
			parameters[2].Value = model.shipDate;
			parameters[3].Value = model.companyNo;
			parameters[4].Value = model.invoiceNo;

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
		public bool Update(BookShop.Model.ShipSheet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ShipSheet set ");
			strSql.Append("shipDate=@shipDate,");
			strSql.Append("companyNo=@companyNo,");
			strSql.Append("invoiceNo=@invoiceNo");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipDate", SqlDbType.DateTime),
					new SqlParameter("@companyNo", SqlDbType.Char,12),
					new SqlParameter("@invoiceNo", SqlDbType.NChar,10),
					new SqlParameter("@shipNo", SqlDbType.Char,12),
					new SqlParameter("@orderNo", SqlDbType.Char,15)};
			parameters[0].Value = model.shipDate;
			parameters[1].Value = model.companyNo;
			parameters[2].Value = model.invoiceNo;
			parameters[3].Value = model.shipNo;
			parameters[4].Value = model.orderNo;

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
		public bool Delete(string shipNo,string orderNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShipSheet ");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,12),
					new SqlParameter("@orderNo", SqlDbType.Char,15)			};
			parameters[0].Value = shipNo;
			parameters[1].Value = orderNo;

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
		public BookShop.Model.ShipSheet GetModel(string shipNo,string orderNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 shipNo,orderNo,shipDate,companyNo,invoiceNo from ShipSheet ");
			strSql.Append(" where shipNo=@shipNo and orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@shipNo", SqlDbType.Char,12),
					new SqlParameter("@orderNo", SqlDbType.Char,15)			};
			parameters[0].Value = shipNo;
			parameters[1].Value = orderNo;

			BookShop.Model.ShipSheet model=new BookShop.Model.ShipSheet();
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
		public BookShop.Model.ShipSheet DataRowToModel(DataRow row)
		{
			BookShop.Model.ShipSheet model=new BookShop.Model.ShipSheet();
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
				if(row["shipDate"]!=null && row["shipDate"].ToString()!="")
				{
					model.shipDate=DateTime.Parse(row["shipDate"].ToString());
				}
				if(row["companyNo"]!=null)
				{
					model.companyNo=row["companyNo"].ToString();
				}
				if(row["invoiceNo"]!=null)
				{
					model.invoiceNo=row["invoiceNo"].ToString();
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
			strSql.Append("select shipNo,orderNo,shipDate,companyNo,invoiceNo ");
			strSql.Append(" FROM ShipSheet ");
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
			strSql.Append(" shipNo,orderNo,shipDate,companyNo,invoiceNo ");
			strSql.Append(" FROM ShipSheet ");
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
			strSql.Append("select count(1) FROM ShipSheet ");
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
				strSql.Append("order by T.orderNo desc");
			}
			strSql.Append(")AS Row, T.*  from ShipSheet T ");
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
			parameters[0].Value = "ShipSheet";
			parameters[1].Value = "orderNo";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 创建独一无二的ID
        /// </summary>
        /// <returns></returns>
        public string CreateNo()
        {
            Assistant ass = new Assistant();
            string strNo = ass.GetRandomCode(12);
            while (!ValidateNo(strNo))
            {
                strNo = ass.GetRandomCode(12);
            }
            return strNo;
        }
        /// <summary>
        /// 验证ID是否存在
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool ValidateNo(string str)
        {
            string strwhere = "shipNo=" + str;
            if (0 == GetRecordCount(strwhere))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
		#endregion  ExtensionMethod
	}
}

