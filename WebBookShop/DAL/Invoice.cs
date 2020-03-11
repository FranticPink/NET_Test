﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Maticsoft.Common;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Invoice
	/// </summary>
	public partial class Invoice
	{
		public Invoice()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string invoiceNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Invoice");
			strSql.Append(" where invoiceNo=@invoiceNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@invoiceNo", SqlDbType.Char,10)			};
			parameters[0].Value = invoiceNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Invoice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Invoice(");
			strSql.Append("invoiceNo,invoiceUnit,invoiceSum)");
			strSql.Append(" values (");
			strSql.Append("@invoiceNo,@invoiceUnit,@invoiceSum)");
			SqlParameter[] parameters = {
					new SqlParameter("@invoiceNo", SqlDbType.Char,10),
					new SqlParameter("@invoiceUnit", SqlDbType.VarChar,40),
					new SqlParameter("@invoiceSum", SqlDbType.Decimal,9)};
			parameters[0].Value = model.invoiceNo;
			parameters[1].Value = model.invoiceUnit;
			parameters[2].Value = model.invoiceSum;

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
		public bool Update(BookShop.Model.Invoice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Invoice set ");
			strSql.Append("invoiceUnit=@invoiceUnit,");
			strSql.Append("invoiceSum=@invoiceSum");
			strSql.Append(" where invoiceNo=@invoiceNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@invoiceUnit", SqlDbType.VarChar,40),
					new SqlParameter("@invoiceSum", SqlDbType.Decimal,9),
					new SqlParameter("@invoiceNo", SqlDbType.Char,10)};
			parameters[0].Value = model.invoiceUnit;
			parameters[1].Value = model.invoiceSum;
			parameters[2].Value = model.invoiceNo;

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
		public bool Delete(string invoiceNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Invoice ");
			strSql.Append(" where invoiceNo=@invoiceNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@invoiceNo", SqlDbType.Char,10)			};
			parameters[0].Value = invoiceNo;

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
		public bool DeleteList(string invoiceNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Invoice ");
			strSql.Append(" where invoiceNo in ("+invoiceNolist + ")  ");
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
		public BookShop.Model.Invoice GetModel(string invoiceNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 invoiceNo,invoiceUnit,invoiceSum from Invoice ");
			strSql.Append(" where invoiceNo=@invoiceNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@invoiceNo", SqlDbType.Char,10)			};
			parameters[0].Value = invoiceNo;

			BookShop.Model.Invoice model=new BookShop.Model.Invoice();
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
		public BookShop.Model.Invoice DataRowToModel(DataRow row)
		{
			BookShop.Model.Invoice model=new BookShop.Model.Invoice();
			if (row != null)
			{
				if(row["invoiceNo"]!=null)
				{
					model.invoiceNo=row["invoiceNo"].ToString();
				}
				if(row["invoiceUnit"]!=null)
				{
					model.invoiceUnit=row["invoiceUnit"].ToString();
				}
				if(row["invoiceSum"]!=null && row["invoiceSum"].ToString()!="")
				{
					model.invoiceSum=decimal.Parse(row["invoiceSum"].ToString());
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
			strSql.Append("select invoiceNo,invoiceUnit,invoiceSum ");
			strSql.Append(" FROM Invoice ");
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
			strSql.Append(" invoiceNo,invoiceUnit,invoiceSum ");
			strSql.Append(" FROM Invoice ");
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
			strSql.Append("select count(1) FROM Invoice ");
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
				strSql.Append("order by T.invoiceNo desc");
			}
			strSql.Append(")AS Row, T.*  from Invoice T ");
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
			parameters[0].Value = "Invoice";
			parameters[1].Value = "invoiceNo";
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
            string strNo = ass.GetRandomCode(10);
            while (!ValidateNo(strNo))
            {
                strNo = ass.GetRandomCode(10);
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
            string strwhere = "invoiceNo=" + str;
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
