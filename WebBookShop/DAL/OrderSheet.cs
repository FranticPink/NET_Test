using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Maticsoft.Common;//Please add references
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:OrderSheet
	/// </summary>
	public partial class OrderSheet
	{
		public OrderSheet()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string orderNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OrderSheet");
			strSql.Append(" where orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.Char,15)			};
			parameters[0].Value = orderNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BookShop.Model.OrderSheet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrderSheet(");
			strSql.Append("orderNo,memberNo,employeeNo,orderDate,orderMoney,payWay,payFlag,orderState,invoiceUnit,receiver,zipCode,shipAddress,shipTel)");
			strSql.Append(" values (");
			strSql.Append("@orderNo,@memberNo,@employeeNo,@orderDate,@orderMoney,@payWay,@payFlag,@orderState,@invoiceUnit,@receiver,@zipCode,@shipAddress,@shipTel)");
			SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.Char,15),
					new SqlParameter("@memberNo", SqlDbType.Char,9),
					new SqlParameter("@employeeNo", SqlDbType.Char,8),
					new SqlParameter("@orderDate", SqlDbType.DateTime),
					new SqlParameter("@orderMoney", SqlDbType.Decimal,9),
					new SqlParameter("@payWay", SqlDbType.Char,1),
					new SqlParameter("@payFlag", SqlDbType.Char,1),
					new SqlParameter("@orderState", SqlDbType.Char,1),
					new SqlParameter("@invoiceUnit", SqlDbType.VarChar,40),
					new SqlParameter("@receiver", SqlDbType.VarChar,20),
					new SqlParameter("@zipCode", SqlDbType.Char,6),
					new SqlParameter("@shipAddress", SqlDbType.VarChar,40),
					new SqlParameter("@shipTel", SqlDbType.VarChar,15)};
			parameters[0].Value = model.orderNo;
			parameters[1].Value = model.memberNo;
			parameters[2].Value = model.employeeNo;
			parameters[3].Value = model.orderDate;
			parameters[4].Value = model.orderMoney;
			parameters[5].Value = model.payWay;
			parameters[6].Value = model.payFlag;
			parameters[7].Value = model.orderState;
			parameters[8].Value = model.invoiceUnit;
			parameters[9].Value = model.receiver;
			parameters[10].Value = model.zipCode;
			parameters[11].Value = model.shipAddress;
			parameters[12].Value = model.shipTel;

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
		public bool Update(BookShop.Model.OrderSheet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrderSheet set ");
			strSql.Append("memberNo=@memberNo,");
			strSql.Append("employeeNo=@employeeNo,");
			strSql.Append("orderDate=@orderDate,");
			strSql.Append("orderMoney=@orderMoney,");
			strSql.Append("payWay=@payWay,");
			strSql.Append("payFlag=@payFlag,");
			strSql.Append("orderState=@orderState,");
			strSql.Append("invoiceUnit=@invoiceUnit,");
			strSql.Append("receiver=@receiver,");
			strSql.Append("zipCode=@zipCode,");
			strSql.Append("shipAddress=@shipAddress,");
			strSql.Append("shipTel=@shipTel");
			strSql.Append(" where orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@memberNo", SqlDbType.Char,9),
					new SqlParameter("@employeeNo", SqlDbType.Char,8),
					new SqlParameter("@orderDate", SqlDbType.DateTime),
					new SqlParameter("@orderMoney", SqlDbType.Decimal,9),
					new SqlParameter("@payWay", SqlDbType.Char,1),
					new SqlParameter("@payFlag", SqlDbType.Char,1),
					new SqlParameter("@orderState", SqlDbType.Char,1),
					new SqlParameter("@invoiceUnit", SqlDbType.VarChar,40),
					new SqlParameter("@receiver", SqlDbType.VarChar,20),
					new SqlParameter("@zipCode", SqlDbType.Char,6),
					new SqlParameter("@shipAddress", SqlDbType.VarChar,40),
					new SqlParameter("@shipTel", SqlDbType.VarChar,15),
					new SqlParameter("@orderNo", SqlDbType.Char,15)};
			parameters[0].Value = model.memberNo;
			parameters[1].Value = model.employeeNo;
			parameters[2].Value = model.orderDate;
			parameters[3].Value = model.orderMoney;
			parameters[4].Value = model.payWay;
			parameters[5].Value = model.payFlag;
			parameters[6].Value = model.orderState;
			parameters[7].Value = model.invoiceUnit;
			parameters[8].Value = model.receiver;
			parameters[9].Value = model.zipCode;
			parameters[10].Value = model.shipAddress;
			parameters[11].Value = model.shipTel;
			parameters[12].Value = model.orderNo;

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
		public bool Delete(string orderNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderSheet ");
			strSql.Append(" where orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.Char,15)			};
			parameters[0].Value = orderNo;

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
		public bool DeleteList(string orderNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrderSheet ");
			strSql.Append(" where orderNo in ("+orderNolist + ")  ");
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
		public BookShop.Model.OrderSheet GetModel(string orderNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 orderNo,memberNo,employeeNo,orderDate,orderMoney,payWay,payFlag,orderState,invoiceUnit,receiver,zipCode,shipAddress,shipTel from OrderSheet ");
			strSql.Append(" where orderNo=@orderNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@orderNo", SqlDbType.Char,15)			};
			parameters[0].Value = orderNo;

			BookShop.Model.OrderSheet model=new BookShop.Model.OrderSheet();
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
		public BookShop.Model.OrderSheet DataRowToModel(DataRow row)
		{
			BookShop.Model.OrderSheet model=new BookShop.Model.OrderSheet();
			if (row != null)
			{
				if(row["orderNo"]!=null)
				{
					model.orderNo=row["orderNo"].ToString();
				}
				if(row["memberNo"]!=null)
				{
					model.memberNo=row["memberNo"].ToString();
				}
				if(row["employeeNo"]!=null)
				{
					model.employeeNo=row["employeeNo"].ToString();
				}
				if(row["orderDate"]!=null && row["orderDate"].ToString()!="")
				{
					model.orderDate=DateTime.Parse(row["orderDate"].ToString());
				}
				if(row["orderMoney"]!=null && row["orderMoney"].ToString()!="")
				{
					model.orderMoney=decimal.Parse(row["orderMoney"].ToString());
				}
				if(row["payWay"]!=null)
				{
					model.payWay=row["payWay"].ToString();
				}
				if(row["payFlag"]!=null)
				{
					model.payFlag=row["payFlag"].ToString();
				}
				if(row["orderState"]!=null)
				{
					model.orderState=row["orderState"].ToString();
				}
				if(row["invoiceUnit"]!=null)
				{
					model.invoiceUnit=row["invoiceUnit"].ToString();
				}
				if(row["receiver"]!=null)
				{
					model.receiver=row["receiver"].ToString();
				}
				if(row["zipCode"]!=null)
				{
					model.zipCode=row["zipCode"].ToString();
				}
				if(row["shipAddress"]!=null)
				{
					model.shipAddress=row["shipAddress"].ToString();
				}
				if(row["shipTel"]!=null)
				{
					model.shipTel=row["shipTel"].ToString();
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
			strSql.Append("select orderNo,memberNo,employeeNo,orderDate,orderMoney,payWay,payFlag,orderState,invoiceUnit,receiver,zipCode,shipAddress,shipTel ");
			strSql.Append(" FROM OrderSheet ");
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
			strSql.Append(" orderNo,memberNo,employeeNo,orderDate,orderMoney,payWay,payFlag,orderState,invoiceUnit,receiver,zipCode,shipAddress,shipTel ");
			strSql.Append(" FROM OrderSheet ");
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
			strSql.Append("select count(1) FROM OrderSheet ");
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
			strSql.Append(")AS Row, T.*  from OrderSheet T ");
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
			parameters[0].Value = "OrderSheet";
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
            string strNo = ass.GetRandomCode(15);
            while (ValidateNo(strNo))
            {
                strNo = ass.GetRandomCode(15);
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
            string strwhere = "orderNo=" + str;
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

