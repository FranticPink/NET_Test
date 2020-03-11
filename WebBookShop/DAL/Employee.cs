using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using Maticsoft.Common;
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Employee
	/// </summary>
	public partial class Employee
	{
		public Employee()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string employeeNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Employee");
			strSql.Append(" where employeeNo=@employeeNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@employeeNo", SqlDbType.Char,8)			};
			parameters[0].Value = employeeNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.Employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Employee(");
			strSql.Append("employeeNo,empPassword,empName,sex,birthday,department,title,salary,address,telephone,email)");
			strSql.Append(" values (");
			strSql.Append("@employeeNo,@empPassword,@empName,@sex,@birthday,@department,@title,@salary,@address,@telephone,@email)");
			SqlParameter[] parameters = {
					new SqlParameter("@employeeNo", SqlDbType.Char,8),
					new SqlParameter("@empPassword", SqlDbType.VarChar,10),
					new SqlParameter("@empName", SqlDbType.VarChar,12),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@department", SqlDbType.VarChar,30),
					new SqlParameter("@title", SqlDbType.VarChar,10),
					new SqlParameter("@salary", SqlDbType.Decimal,9),
					new SqlParameter("@address", SqlDbType.VarChar,40),
					new SqlParameter("@telephone", SqlDbType.VarChar,15),
					new SqlParameter("@email", SqlDbType.VarChar,20)};
			parameters[0].Value = model.employeeNo;
			parameters[1].Value = model.empPassword;
			parameters[2].Value = model.empName;
			parameters[3].Value = model.sex;
			parameters[4].Value = model.birthday;
			parameters[5].Value = model.department;
			parameters[6].Value = model.title;
			parameters[7].Value = model.salary;
			parameters[8].Value = model.address;
			parameters[9].Value = model.telephone;
			parameters[10].Value = model.email;

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
		public bool Update(BookShop.Model.Employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Employee set ");
			strSql.Append("empPassword=@empPassword,");
			strSql.Append("empName=@empName,");
			strSql.Append("sex=@sex,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("department=@department,");
			strSql.Append("title=@title,");
			strSql.Append("salary=@salary,");
			strSql.Append("address=@address,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("email=@email");
			strSql.Append(" where employeeNo=@employeeNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@empPassword", SqlDbType.VarChar,10),
					new SqlParameter("@empName", SqlDbType.VarChar,12),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@department", SqlDbType.VarChar,30),
					new SqlParameter("@title", SqlDbType.VarChar,10),
					new SqlParameter("@salary", SqlDbType.Decimal,9),
					new SqlParameter("@address", SqlDbType.VarChar,40),
					new SqlParameter("@telephone", SqlDbType.VarChar,15),
					new SqlParameter("@email", SqlDbType.VarChar,20),
					new SqlParameter("@employeeNo", SqlDbType.Char,8)};
			parameters[0].Value = model.empPassword;
			parameters[1].Value = model.empName;
			parameters[2].Value = model.sex;
			parameters[3].Value = model.birthday;
			parameters[4].Value = model.department;
			parameters[5].Value = model.title;
			parameters[6].Value = model.salary;
			parameters[7].Value = model.address;
			parameters[8].Value = model.telephone;
			parameters[9].Value = model.email;
			parameters[10].Value = model.employeeNo;

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
		public bool Delete(string employeeNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Employee ");
			strSql.Append(" where employeeNo=@employeeNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@employeeNo", SqlDbType.Char,8)			};
			parameters[0].Value = employeeNo;

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
		public bool DeleteList(string employeeNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Employee ");
			strSql.Append(" where employeeNo in ("+employeeNolist + ")  ");
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
		public BookShop.Model.Employee GetModel(string employeeNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 employeeNo,empPassword,empName,sex,birthday,department,title,salary,address,telephone,email from Employee ");
			strSql.Append(" where employeeNo=@employeeNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@employeeNo", SqlDbType.Char,8)			};
			parameters[0].Value = employeeNo;

			BookShop.Model.Employee model=new BookShop.Model.Employee();
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
		public BookShop.Model.Employee DataRowToModel(DataRow row)
		{
			BookShop.Model.Employee model=new BookShop.Model.Employee();
			if (row != null)
			{
				if(row["employeeNo"]!=null)
				{
					model.employeeNo=row["employeeNo"].ToString();
				}
				if(row["empPassword"]!=null)
				{
					model.empPassword=row["empPassword"].ToString();
				}
				if(row["empName"]!=null)
				{
					model.empName=row["empName"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["birthday"]!=null && row["birthday"].ToString()!="")
				{
					model.birthday=DateTime.Parse(row["birthday"].ToString());
				}
				if(row["department"]!=null)
				{
					model.department=row["department"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["salary"]!=null && row["salary"].ToString()!="")
				{
					model.salary=decimal.Parse(row["salary"].ToString());
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
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
			strSql.Append("select employeeNo,empPassword,empName,sex,birthday,department,title,salary,address,telephone,email ");
			strSql.Append(" FROM Employee ");
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
			strSql.Append(" employeeNo,empPassword,empName,sex,birthday,department,title,salary,address,telephone,email ");
			strSql.Append(" FROM Employee ");
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
			strSql.Append("select count(1) FROM Employee ");
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
				strSql.Append("order by T.employeeNo desc");
			}
			strSql.Append(")AS Row, T.*  from Employee T ");
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
			parameters[0].Value = "Employee";
			parameters[1].Value = "employeeNo";
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
            string strNo = ass.GetRandomCode(8);
            while (!ValidateNo(strNo))
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
            string strwhere = "employeeNo=" + str;
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

