using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Maticsoft.Common;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Company
	/// </summary>
	public partial class Company
	{
		public Company()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string compantNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Company");
			strSql.Append(" where compantNo=@compantNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@compantNo", SqlDbType.Char,12)			};
			parameters[0].Value = compantNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Company(");
			strSql.Append("compantNo,companyName,address,zipCode,contactPerson,telephone,fax,email)");
			strSql.Append(" values (");
			strSql.Append("@compantNo,@companyName,@address,@zipCode,@contactPerson,@telephone,@fax,@email)");
			SqlParameter[] parameters = {
					new SqlParameter("@compantNo", SqlDbType.Char,12),
					new SqlParameter("@companyName", SqlDbType.VarChar,20),
					new SqlParameter("@address", SqlDbType.VarChar,40),
					new SqlParameter("@zipCode", SqlDbType.Char,6),
					new SqlParameter("@contactPerson", SqlDbType.VarChar,12),
					new SqlParameter("@telephone", SqlDbType.VarChar,15),
					new SqlParameter("@fax", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,20)};
			parameters[0].Value = model.compantNo;
			parameters[1].Value = model.companyName;
			parameters[2].Value = model.address;
			parameters[3].Value = model.zipCode;
			parameters[4].Value = model.contactPerson;
			parameters[5].Value = model.telephone;
			parameters[6].Value = model.fax;
			parameters[7].Value = model.email;

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
		public bool Update(BookShop.Model.Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Company set ");
			strSql.Append("companyName=@companyName,");
			strSql.Append("address=@address,");
			strSql.Append("zipCode=@zipCode,");
			strSql.Append("contactPerson=@contactPerson,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("fax=@fax,");
			strSql.Append("email=@email");
			strSql.Append(" where compantNo=@compantNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@companyName", SqlDbType.VarChar,20),
					new SqlParameter("@address", SqlDbType.VarChar,40),
					new SqlParameter("@zipCode", SqlDbType.Char,6),
					new SqlParameter("@contactPerson", SqlDbType.VarChar,12),
					new SqlParameter("@telephone", SqlDbType.VarChar,15),
					new SqlParameter("@fax", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,20),
					new SqlParameter("@compantNo", SqlDbType.Char,12)};
			parameters[0].Value = model.companyName;
			parameters[1].Value = model.address;
			parameters[2].Value = model.zipCode;
			parameters[3].Value = model.contactPerson;
			parameters[4].Value = model.telephone;
			parameters[5].Value = model.fax;
			parameters[6].Value = model.email;
			parameters[7].Value = model.compantNo;

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
		public bool Delete(string compantNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Company ");
			strSql.Append(" where compantNo=@compantNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@compantNo", SqlDbType.Char,12)			};
			parameters[0].Value = compantNo;

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
		public bool DeleteList(string compantNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Company ");
			strSql.Append(" where compantNo in ("+compantNolist + ")  ");
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
		public BookShop.Model.Company GetModel(string compantNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 compantNo,companyName,address,zipCode,contactPerson,telephone,fax,email from Company ");
			strSql.Append(" where compantNo=@compantNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@compantNo", SqlDbType.Char,12)			};
			parameters[0].Value = compantNo;

			BookShop.Model.Company model=new BookShop.Model.Company();
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
		public BookShop.Model.Company DataRowToModel(DataRow row)
		{
			BookShop.Model.Company model=new BookShop.Model.Company();
			if (row != null)
			{
				if(row["compantNo"]!=null)
				{
					model.compantNo=row["compantNo"].ToString();
				}
				if(row["companyName"]!=null)
				{
					model.companyName=row["companyName"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["zipCode"]!=null)
				{
					model.zipCode=row["zipCode"].ToString();
				}
				if(row["contactPerson"]!=null)
				{
					model.contactPerson=row["contactPerson"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["fax"]!=null)
				{
					model.fax=row["fax"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
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
			strSql.Append("select compantNo,companyName,address,zipCode,contactPerson,telephone,fax,email ");
			strSql.Append(" FROM Company ");
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
			strSql.Append(" compantNo,companyName,address,zipCode,contactPerson,telephone,fax,email ");
			strSql.Append(" FROM Company ");
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
			strSql.Append("select count(1) FROM Company ");
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
				strSql.Append("order by T.compantNo desc");
			}
			strSql.Append(")AS Row, T.*  from Company T ");
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
			parameters[0].Value = "Company";
			parameters[1].Value = "compantNo";
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
            string strwhere = "companyNo=" + str;
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

