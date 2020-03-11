using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using Maticsoft.Common;
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Message
	/// </summary>
	public partial class Message
	{
		public Message()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string messageNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Message");
			strSql.Append(" where messageNo=@messageNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@messageNo", SqlDbType.Char,10)			};
			parameters[0].Value = messageNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Message(");
			strSql.Append("messageNo,employeeNo,memberNo,releaseDate,messageContent,replyContent,replyDate)");
			strSql.Append(" values (");
			strSql.Append("@messageNo,@employeeNo,@memberNo,@releaseDate,@messageContent,@replyContent,@replyDate)");
			SqlParameter[] parameters = {
					new SqlParameter("@messageNo", SqlDbType.Char,10),
					new SqlParameter("@employeeNo", SqlDbType.Char,8),
					new SqlParameter("@memberNo", SqlDbType.Char,9),
					new SqlParameter("@releaseDate", SqlDbType.DateTime),
					new SqlParameter("@messageContent", SqlDbType.VarChar,100),
					new SqlParameter("@replyContent", SqlDbType.VarChar,100),
					new SqlParameter("@replyDate", SqlDbType.DateTime)};
			parameters[0].Value = model.messageNo;
			parameters[1].Value = model.employeeNo;
			parameters[2].Value = model.memberNo;
			parameters[3].Value = model.releaseDate;
			parameters[4].Value = model.messageContent;
			parameters[5].Value = model.replyContent;
			parameters[6].Value = model.replyDate;

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
		public bool Update(BookShop.Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Message set ");
			strSql.Append("employeeNo=@employeeNo,");
			strSql.Append("memberNo=@memberNo,");
			strSql.Append("releaseDate=@releaseDate,");
			strSql.Append("messageContent=@messageContent,");
			strSql.Append("replyContent=@replyContent,");
			strSql.Append("replyDate=@replyDate");
			strSql.Append(" where messageNo=@messageNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@employeeNo", SqlDbType.Char,8),
					new SqlParameter("@memberNo", SqlDbType.Char,9),
					new SqlParameter("@releaseDate", SqlDbType.DateTime),
					new SqlParameter("@messageContent", SqlDbType.VarChar,100),
					new SqlParameter("@replyContent", SqlDbType.VarChar,100),
					new SqlParameter("@replyDate", SqlDbType.DateTime),
					new SqlParameter("@messageNo", SqlDbType.Char,10)};
			parameters[0].Value = model.employeeNo;
			parameters[1].Value = model.memberNo;
			parameters[2].Value = model.releaseDate;
			parameters[3].Value = model.messageContent;
			parameters[4].Value = model.replyContent;
			parameters[5].Value = model.replyDate;
			parameters[6].Value = model.messageNo;

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
		public bool Delete(string messageNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Message ");
			strSql.Append(" where messageNo=@messageNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@messageNo", SqlDbType.Char,10)			};
			parameters[0].Value = messageNo;

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
		public bool DeleteList(string messageNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Message ");
			strSql.Append(" where messageNo in ("+messageNolist + ")  ");
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
		public BookShop.Model.Message GetModel(string messageNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 messageNo,employeeNo,memberNo,releaseDate,messageContent,replyContent,replyDate from Message ");
			strSql.Append(" where messageNo=@messageNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@messageNo", SqlDbType.Char,10)			};
			parameters[0].Value = messageNo;

			BookShop.Model.Message model=new BookShop.Model.Message();
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
		public BookShop.Model.Message DataRowToModel(DataRow row)
		{
			BookShop.Model.Message model=new BookShop.Model.Message();
			if (row != null)
			{
				if(row["messageNo"]!=null)
				{
					model.messageNo=row["messageNo"].ToString();
				}
				if(row["employeeNo"]!=null)
				{
					model.employeeNo=row["employeeNo"].ToString();
				}
				if(row["memberNo"]!=null)
				{
					model.memberNo=row["memberNo"].ToString();
				}
				if(row["releaseDate"]!=null && row["releaseDate"].ToString()!="")
				{
					model.releaseDate=DateTime.Parse(row["releaseDate"].ToString());
				}
				if(row["messageContent"]!=null)
				{
					model.messageContent=row["messageContent"].ToString();
				}
				if(row["replyContent"]!=null)
				{
					model.replyContent=row["replyContent"].ToString();
				}
				if(row["replyDate"]!=null && row["replyDate"].ToString()!="")
				{
					model.replyDate=DateTime.Parse(row["replyDate"].ToString());
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
			strSql.Append("select messageNo,employeeNo,memberNo,releaseDate,messageContent,replyContent,replyDate ");
			strSql.Append(" FROM Message ");
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
			strSql.Append(" messageNo,employeeNo,memberNo,releaseDate,messageContent,replyContent,replyDate ");
			strSql.Append(" FROM Message ");
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
			strSql.Append("select count(1) FROM Message ");
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
				strSql.Append("order by T.messageNo desc");
			}
			strSql.Append(")AS Row, T.*  from Message T ");
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
			parameters[0].Value = "Message";
			parameters[1].Value = "messageNo";
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
            while (ValidateNo(strNo))
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
            string strwhere = "messageNo=" + str;
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

