using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using Maticsoft.Common;

namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Member
	/// </summary>
	public partial class Member
	{
		public Member()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string memberNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Member");
			strSql.Append(" where memberNo=@memberNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@memberNo", SqlDbType.Char,9)			};
			parameters[0].Value = memberNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Member(");
			strSql.Append("memberNo,memPassword,memName,sex,birthday,telephone,email,address,zipCode,totalAmount,memLevel,discount)");
			strSql.Append(" values (");
			strSql.Append("@memberNo,@memPassword,@memName,@sex,@birthday,@telephone,@email,@address,@zipCode,@totalAmount,@memLevel,@discount)");
			SqlParameter[] parameters = {
					new SqlParameter("@memberNo", SqlDbType.Char,9),
					new SqlParameter("@memPassword", SqlDbType.VarChar,10),
					new SqlParameter("@memName", SqlDbType.VarChar,12),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telephone", SqlDbType.VarChar,15),
					new SqlParameter("@email", SqlDbType.VarChar,20),
					new SqlParameter("@address", SqlDbType.VarChar,40),
					new SqlParameter("@zipCode", SqlDbType.Char,6),
					new SqlParameter("@totalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@memLevel", SqlDbType.Char,1),
					new SqlParameter("@discount", SqlDbType.Float,8)};
			parameters[0].Value = model.memberNo;
			parameters[1].Value = model.memPassword;
			parameters[2].Value = model.memName;
			parameters[3].Value = model.sex;
			parameters[4].Value = model.birthday;
			parameters[5].Value = model.telephone;
			parameters[6].Value = model.email;
			parameters[7].Value = model.address;
			parameters[8].Value = model.zipCode;
			parameters[9].Value = model.totalAmount;
			parameters[10].Value = model.memLevel;
			parameters[11].Value = model.discount;

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
		public bool Update(BookShop.Model.Member model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Member set ");
			strSql.Append("memPassword=@memPassword,");
			strSql.Append("memName=@memName,");
			strSql.Append("sex=@sex,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("email=@email,");
			strSql.Append("address=@address,");
			strSql.Append("zipCode=@zipCode,");
			strSql.Append("totalAmount=@totalAmount,");
			strSql.Append("memLevel=@memLevel,");
			strSql.Append("discount=@discount");
			strSql.Append(" where memberNo=@memberNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@memPassword", SqlDbType.VarChar,10),
					new SqlParameter("@memName", SqlDbType.VarChar,12),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@telephone", SqlDbType.VarChar,15),
					new SqlParameter("@email", SqlDbType.VarChar,20),
					new SqlParameter("@address", SqlDbType.VarChar,40),
					new SqlParameter("@zipCode", SqlDbType.Char,6),
					new SqlParameter("@totalAmount", SqlDbType.Decimal,9),
					new SqlParameter("@memLevel", SqlDbType.Char,1),
					new SqlParameter("@discount", SqlDbType.Float,8),
					new SqlParameter("@memberNo", SqlDbType.Char,9)};
			parameters[0].Value = model.memPassword;
			parameters[1].Value = model.memName;
			parameters[2].Value = model.sex;
			parameters[3].Value = model.birthday;
			parameters[4].Value = model.telephone;
			parameters[5].Value = model.email;
			parameters[6].Value = model.address;
			parameters[7].Value = model.zipCode;
			parameters[8].Value = model.totalAmount;
			parameters[9].Value = model.memLevel;
			parameters[10].Value = model.discount;
			parameters[11].Value = model.memberNo;

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
		public bool Delete(string memberNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Member ");
			strSql.Append(" where memberNo=@memberNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@memberNo", SqlDbType.Char,9)			};
			parameters[0].Value = memberNo;

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
		public bool DeleteList(string memberNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Member ");
			strSql.Append(" where memberNo in ("+memberNolist + ")  ");
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
		public BookShop.Model.Member GetModel(string memberNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 memberNo,memPassword,memName,sex,birthday,telephone,email,address,zipCode,totalAmount,memLevel,discount from Member ");
			strSql.Append(" where memberNo=@memberNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@memberNo", SqlDbType.Char,9)			};
			parameters[0].Value = memberNo;

			BookShop.Model.Member model=new BookShop.Model.Member();
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
		public BookShop.Model.Member DataRowToModel(DataRow row)
		{
			BookShop.Model.Member model=new BookShop.Model.Member();
			if (row != null)
			{
				if(row["memberNo"]!=null)
				{
					model.memberNo=row["memberNo"].ToString();
				}
				if(row["memPassword"]!=null)
				{
					model.memPassword=row["memPassword"].ToString();
				}
				if(row["memName"]!=null)
				{
					model.memName=row["memName"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["birthday"]!=null && row["birthday"].ToString()!="")
				{
					model.birthday=DateTime.Parse(row["birthday"].ToString());
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["zipCode"]!=null)
				{
					model.zipCode=row["zipCode"].ToString();
				}
				if(row["totalAmount"]!=null && row["totalAmount"].ToString()!="")
				{
					model.totalAmount=decimal.Parse(row["totalAmount"].ToString());
				}
				if(row["memLevel"]!=null)
				{
					model.memLevel=row["memLevel"].ToString();
				}
				if(row["discount"]!=null && row["discount"].ToString()!="")
				{
					model.discount=decimal.Parse(row["discount"].ToString());
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
			strSql.Append("select memberNo,memPassword,memName,sex,birthday,telephone,email,address,zipCode,totalAmount,memLevel,discount ");
			strSql.Append(" FROM Member ");
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
			strSql.Append(" memberNo,memPassword,memName,sex,birthday,telephone,email,address,zipCode,totalAmount,memLevel,discount ");
			strSql.Append(" FROM Member ");
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
			strSql.Append("select count(1) FROM Member ");
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
				strSql.Append("order by T.memberNo desc");
			}
			strSql.Append(")AS Row, T.*  from Member T ");
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
			parameters[0].Value = "Member";
			parameters[1].Value = "memberNo";
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
            string strNo=ass.GetRandomCode(8);
            while (ValidateNo(strNo))
            {
                strNo = ass.GetRandomCode(8);
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
            string strwhere = "memberNo=" + str;
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

