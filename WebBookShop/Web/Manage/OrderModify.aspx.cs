using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BookShop.BLL;
using BookShop.Model;

namespace BookShop.Web.Manage
{
    public partial class OrderModify : System.Web.UI.Page
    {
        BLL.Book book = new BLL.Book();
        BLL.Sale sale = new BLL.Sale();
        BLL.OrderSheet ordersh = new BLL.OrderSheet();
        Model.OrderSheet Mordersh = new Model.OrderSheet();
        Model.Sale Msale = new Model.Sale();
        DataTable dtTable;

        CommonClass ccObj = new CommonClass();

        public static Model.OrderSheet MOrderSh = new Model.OrderSheet();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["OrderID"] = "314121731310634";
            string str = this.Session["OrderID"].ToString();
            DataTable dsTableo = ordersh.GetList("orderNo=" + str).Tables[0];
            MOrderSh.orderNo = dsTableo.Rows[0]["orderNo"].ToString();
            MOrderSh.memberNo = dsTableo.Rows[0]["memberNo"].ToString();
            MOrderSh.employeeNo = dsTableo.Rows[0]["employeeNo"].ToString();
            MOrderSh.orderDate =DateTime.Parse( dsTableo.Rows[0]["orderDate"].ToString());
            MOrderSh.orderMoney =decimal.Parse( dsTableo.Rows[0]["orderMoney"].ToString());
            MOrderSh.payWay = dsTableo.Rows[0]["payWay"].ToString();
            MOrderSh.payFlag = dsTableo.Rows[0]["payFlag"].ToString();
            MOrderSh.orderState = dsTableo.Rows[0]["orderState"].ToString();
            MOrderSh.invoiceUnit = dsTableo.Rows[0]["invoiceUnit"].ToString();
            MOrderSh.receiver = dsTableo.Rows[0]["receiver"].ToString();
            MOrderSh.zipCode = dsTableo.Rows[0]["zipCode"].ToString();
            MOrderSh.shipAddress = dsTableo.Rows[0]["shipAddress"].ToString();
            MOrderSh.shipTel = dsTableo.Rows[0]["shipTel"].ToString();
            if (!IsPostBack)
            {
                ModifyBind();//显示订单状态
                rpBind();//显示订单中商品的详细信息
            }
        }
        /// <summary>
        /// 绑定定订状态
        /// </summary>
        public void ModifyBind()
        {
            string str ="'"+ Session["OrderID"].ToString()+"'";
            DataTable dsTable = sale.GetList("orderNo=" + str).Tables[0];
            this.chkConfirm.Checked =(Convert.ToInt32(dsTable.Rows[0]["bookState"].ToString())>0);    //是否被确认
            this.chkConsignment.Checked = Convert.ToInt32(dsTable.Rows[0]["bookState"].ToString())>1;//是否已发货
            this.chkPigeonhole.Checked = Convert.ToInt32(dsTable.Rows[0]["bookState"].ToString())>2; //是否已归档
            //对复选框按钮的隐藏，订单状态的顺序为（确认，发货，归档）
            if (this.chkConfirm.Checked == false)
            {
                this.chkConsignment.Visible = false;//发货复选框按钮隐藏
                this.chkPigeonhole.Visible = false;//归档复选框按钮隐藏
            }
            else
            {
                if (this.chkConsignment.Checked == false)
                {
                    this.chkConfirm.Enabled = false;  //确认复选框按钮不可用
                    this.chkPigeonhole.Visible = false;//归档复选框按钮隐藏
                }
                else
                {
                    if (this.chkPigeonhole.Checked == false)
                    {
                        this.chkConfirm.Enabled = false;//确认复选框按钮不可用
                        this.chkConsignment.Enabled = false;//归档复选框按钮不可用
                    }
                    else
                    {
                        this.btnSave.Visible = false;//修改按钮不可见

                    }
                }
            }
        }

        public void rpBind()
        {
            //设置购物车内容的数据源
            dtTable = new DataTable();
          
            DataColumn column2 = new DataColumn("ISBN");    //商品ID代号
            DataColumn column3 = new DataColumn("bookTitle");  //商品名称
            DataColumn column4 = new DataColumn("Num");       //数量
            DataColumn column5 = new DataColumn("price");     //单价
            DataColumn column6 = new DataColumn("totalPrice");//总价
            DataColumn column7 = new DataColumn("bookState");//状态
                 
            dtTable.Columns.Add(column2);
            dtTable.Columns.Add(column3);
            dtTable.Columns.Add(column4);
            dtTable.Columns.Add(column5);
            dtTable.Columns.Add(column6);
            dtTable.Columns.Add(column7);
           
            string str = "'" + Session["OrderID"].ToString() + "'";
            DataTable dsTableo = ordersh.GetList("orderNo=" + str).Tables[0];
            DataTable dsTables = sale.GetList("orderNo=" + str).Tables[0];
            DataTable  dsTableb;
            foreach (DataRow Rrow in dsTables.Rows)
            {
                DataRow row = dtTable.NewRow();
                row["ISBN"] = Rrow["ISBN"];
                dsTableb = book.GetList("ISBN=" +"'"+ Rrow["ISBN"].ToString()+"'").Tables[0];
                row["bookTitle"] = dsTableb.Rows[0]["bookTitle"];
                row["Num"] = Rrow["quantity"];
                row["price"] = dsTableb.Rows[0]["salePrice"];
                row["totalPrice"] = (int.Parse(row["Num"].ToString()) * float.Parse(row["price"].ToString())).ToString();
                row["bookState"] = Rrow["bookState"];
                dtTable.Rows.Add(row);
            }

            this.rptOrderItems.DataSource = dtTable.DefaultView;
            this.rptOrderItems.DataBind();
        }
        //绑定商品热门价
        public string GetHotPrice(string strHotPrice)
        {
            return ccObj.VarStr(strHotPrice, 2);
        }
        //绑定商品总费用
        public string GetTotailPrice(string strTotailPrice)
        {
            return ccObj.VarStr(strTotailPrice, 2);
        }
        public string GetStatus(string OrderID)
        {
            string str="";
            DataTable dsTable = sale.GetList("orderNo=" +"'"+ OrderID+"'").Tables[0];
            if (int.Parse(dsTable.Rows[0]["bookState"].ToString()) ==1)
            {
                str = "已确认";
            }
            else if (int.Parse(dsTable.Rows[0]["bookState"].ToString()) == 2)
            {
                str = "已确认|已发货";
            }
            else if (int.Parse(dsTable.Rows[0]["bookState"].ToString()) == 2)
            {
                str = "已确认·已发货|已归档";
            }
            return str;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {   
            bool blConfirm = Convert.ToBoolean(this.chkConfirm.Checked); //是否被确认
            bool blSend = Convert.ToBoolean(this.chkConsignment.Checked);//是否已发货
            bool blEnd = Convert.ToBoolean(this.chkPigeonhole.Checked);  //是否已归档
            string state="";
            if (blConfirm)
            {
                state = "1";
            }
            else if (blSend)
            {
                state = "2";
            }
            else if (blEnd)
            {
                state = "2";
            }
            string AdminID = Session["AID"].ToString(); //根单员ID代号
            //修改订单表中订单状态
            string str = "'" + Session["OrderID"].ToString() + "'";
            Model.OrderSheet or= ordersh.GetModel("orderNo="+str);
            //or.employeeNo = AdminID;
            ordersh.Update(or);

            Model.Sale s=new Model.Sale ();
            DataTable dt = sale.GetList("orderNo="+str).Tables[0];
            s.orderNo=dt.Rows[0]["orderNo"].ToString();
            s.ISBN = dt.Rows[0]["ISBN"].ToString();
            s.quantity = int.Parse(dt.Rows[0]["quantity"].ToString());
            s.bookState = state;
            sale.Update(s);
            Response.Write(ccObj.MessageBox("修改成功！", "main.aspx"));
        }
    
    }
}