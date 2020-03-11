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
using System.Text.RegularExpressions;
using BookShop.BLL;

namespace BookShop.Web.BuyPage
{
    public partial class shopCart : System.Web.UI.Page
    {
        BookShop.BLL.Book book = new BookShop.BLL.Book();
      
        DataTable dtTable;
        Hashtable hashCar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*判断是否登录*/
                ST_check_Login();
                if (Session["ShopCart"] == null)
                {
                    //如果没有购物，则给出相应信息，并隐藏按钮
                    this.labMessage.Text = "您还没有购物！";
                    this.labMessage.Visible = true;        //显示提示信息
                    this.lnkbtnCheck.Visible = false;      //隐藏“前往服务台”按钮
                    this.lnkbtnClear.Visible = false;      //隐藏“清空购物车”按钮
                    this.lnkbtnContinue.Visible = false;   //隐藏“继续购物”按钮

                }
                else
                {
                    hashCar = (Hashtable)Session["ShopCart"]; //获取其购物车
                    if (hashCar.Count == 0)
                    {
                        //如果没有购物，则给出相应信息，并隐藏按钮
                        this.labMessage.Text = "您购物车中没有商品！";
                        this.labMessage.Visible = true;        //显示提示信息
                        this.lnkbtnCheck.Visible = false;      //隐藏“前往服务台”按钮
                        this.lnkbtnClear.Visible = false;      //隐藏“清空购物车”按钮
                        this.lnkbtnContinue.Visible = false;   //隐藏“继续购物”按钮

                    }
                    else
                    {
                        //设置购物车内容的数据源
                        dtTable = new DataTable();
                        DataColumn column1 = new DataColumn("No");        //序号列
                        DataColumn column2 = new DataColumn("ISBN");    //商品ID代号
                        DataColumn column3 = new DataColumn("bookTitle");  //商品名称
                        DataColumn column4 = new DataColumn("Num");       //数量
                        DataColumn column5 = new DataColumn("price");     //单价
                        DataColumn column6 = new DataColumn("totalPrice");//总价
                        dtTable.Columns.Add(column1);  //添加新列            
                        dtTable.Columns.Add(column2);
                        dtTable.Columns.Add(column3);
                        dtTable.Columns.Add(column4);
                        dtTable.Columns.Add(column5);
                        dtTable.Columns.Add(column6);
                        DataRow row;
                        //对数据表中每一行进行遍历，给每一行的新列赋值
                        foreach (object key in hashCar.Keys)
                        {
                            row = dtTable.NewRow();
                            row["ISBN"] = key.ToString();
                            row["Num"] = hashCar[key].ToString();
                            dtTable.Rows.Add(row);
                        }
                        //计算价格
                        DataTable dstable;
                        int i = 1;
                        float price;//商品单价
                        int count;  //商品数量
                        float totalPrice = 0; //商品总价格
                        foreach (DataRow drRow in dtTable.Rows)
                        {
                            string str = "'"+drRow["ISBN"].ToString()+"'";
                            dstable = book.GetList("ISBN=" + str).Tables[0];
                            drRow["No"] = i;//序号
                            drRow["bookTitle"] = dstable.Rows[0]["bookTitle"].ToString();//商品名称
                            drRow["price"] = (dstable.Rows[0]["Price"].ToString());//单价
                            price = float.Parse(dstable.Rows[0]["Price"].ToString());//单价
                            count = Int32.Parse(drRow["Num"].ToString());
                            drRow["totalPrice"] = price * count; //总价
                            totalPrice += price * count; //计算合价
                            i++;
                        }
                        this.labTotalPrice.Text = "总价：" + totalPrice.ToString();  //显示所有商品的价格
                        this.gvShopCart.DataSource = dtTable.DefaultView;   //绑定GridView控件
                        this.gvShopCart.DataKeyNames = new string[] { "ISBN" };
                        this.gvShopCart.DataBind();
                    }
                }

            }

        }
        public void ST_check_Login()
        {

            if ((Session["Username"] == null))
            {
                Response.Write("<script>alert('对不起！您不是会员，请先注册！');location='Default.aspx'</script>");
                Response.End();
            }
        }
        public void bind()
        {
            if (Session["ShopCart"] == null)
            {
                //如果没有购物，则给出相应信息，并隐藏按钮
                this.labMessage.Text = "您还没有购物！";
                this.labMessage.Visible = true;        //显示提示信息
                this.lnkbtnCheck.Visible = false;      //隐藏“前往服务台”按钮
                this.lnkbtnClear.Visible = false;      //隐藏“清空购物车”按钮
                this.lnkbtnContinue.Visible = false;   //隐藏“继续购物”按钮

            }
            else
            {
                hashCar = (Hashtable)Session["ShopCart"]; //获取其购物车
                if (hashCar.Count == 0)
                {
                    //如果没有购物，则给出相应信息，并隐藏按钮
                    this.labMessage.Text = "您购物车中没有商品！";
                    this.labMessage.Visible = true;        //显示提示信息
                    this.lnkbtnCheck.Visible = false;      //隐藏“前往服务台”按钮
                    this.lnkbtnClear.Visible = false;      //隐藏“清空购物车”按钮
                    this.lnkbtnContinue.Visible = false;   //隐藏“继续购物”按钮

                }
                else
                {
                    //设置购物车内容的数据源
                    dtTable = new DataTable();
                    DataColumn column1 = new DataColumn("No");        //序号列
                    DataColumn column2 = new DataColumn("ISBN");    //商品ID代号
                    DataColumn column3 = new DataColumn("bookTitle");  //商品名称
                    DataColumn column4 = new DataColumn("Num");       //数量
                    DataColumn column5 = new DataColumn("price");     //单价
                    DataColumn column6 = new DataColumn("totalPrice");//总价
                    dtTable.Columns.Add(column1);  //添加新列            
                    dtTable.Columns.Add(column2);
                    dtTable.Columns.Add(column3);
                    dtTable.Columns.Add(column4);
                    dtTable.Columns.Add(column5);
                    dtTable.Columns.Add(column6);
                    DataRow row;
                    //对数据表中每一行进行遍历，给每一行的新列赋值
                    foreach (object key in hashCar.Keys)
                    {
                        row = dtTable.NewRow();
                        row["ISBN"] = key.ToString();
                        row["Num"] = hashCar[key].ToString();
                        dtTable.Rows.Add(row);
                    }
                        //计算价格
                        DataTable dstable;
                        int i = 1;
                        float price;//商品单价
                        int count;  //商品数量
                        float totalPrice = 0; //商品总价格
                        foreach (DataRow drRow in dtTable.Rows)
                        {
                            string str = "'" + drRow["ISBN"].ToString() + "'";

                            dstable = book.GetList("ISBN=" + str).Tables[0];
                            drRow["No"] = i;//序号
                            drRow["bookTitle"] = dstable.Rows[0]["bookTitle"].ToString();//商品名称
                            drRow["price"] = (dstable.Rows[0]["Price"].ToString());//单价
                            price = float.Parse(dstable.Rows[0]["Price"].ToString());//单价
                            count = Int32.Parse(drRow["Num"].ToString());
                            drRow["totalPrice"] = price * count; //总价
                            totalPrice += price * count; //计算合价
                            i++;
                        }
                        this.labTotalPrice.Text = "总价：" + totalPrice.ToString();  //显示所有商品的价格
                        this.gvShopCart.DataSource = dtTable.DefaultView;   //绑定GridView控件
                        this.gvShopCart.DataKeyNames = new string[] { "ISBN" };
                        this.gvShopCart.DataBind();
                    }
            }



        }
        protected void lnkbtnUpdate_Click(object sender, EventArgs e)
        {
            hashCar = (Hashtable)Session["ShopCart"];  //获取其购物车
            //使用foreach语句，遍历更新购物车中的商品数量
            foreach (GridViewRow gvr in this.gvShopCart.Rows)
            {
                TextBox otb = (TextBox)gvr.FindControl("txtNum"); //找到用来输入数量的TextBox控件 
                int count = Int32.Parse(otb.Text);//获得用户输入的数量值
                string ISBN = gvr.Cells[1].Text;//得到该商品的ID代
                hashCar[ISBN] = count;//更新hashTable表
            }
            Session["UserID"] = Session["UserID"];
            Session["ShopCart"] = hashCar;//更新购物车
            Response.Redirect("shopCart.aspx");
        }
        protected void lnkbtnDelete_Command(object sender, CommandEventArgs e)
        {
            hashCar = (Hashtable)Session["ShopCart"];//获取其购物车
            //从Hashtable表中，将指定的商品从购物车中移除，其中，删除按钮(lnkbtnDelete)的CommandArgument参数值为商品ID代号
            hashCar.Remove(e.CommandArgument);
            Session["ShopCart"] = hashCar; //更新购物车
            Response.Redirect("shopCart.aspx");
        }
        protected void lnkbtnClear_Click(object sender, EventArgs e)
        {
            Session["ShopCart"] = null;
            Response.Redirect("shopCart.aspx");
        }
        protected void lnkbtnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void lnkbtnCheck_Click(object sender, EventArgs e)
        {
            Session["UserID"] = Session["UserID"];
            Response.Redirect("checkOut.aspx");
        }
        protected void gvShopCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShopCart.PageIndex = e.NewPageIndex;
            bind();

        }
        protected void txtNum_TextChanged(object sender, EventArgs e)
        {
            hashCar = (Hashtable)Session["ShopCart"];  //获取其购物车
            foreach (GridViewRow gvr in this.gvShopCart.Rows)
            {

                TextBox otb = (TextBox)gvr.FindControl("txtNum"); //找到用来输入数量的TextBox控件 
                int count = Int32.Parse(otb.Text);//获得用户输入的数量值
                string ISBN = gvr.Cells[1].Text;//得到该商品的ID代
                hashCar[ISBN] = count;//更新hashTable表

            }
            Session["ShopCart"] = hashCar;//更新购物车
            bind();

        }
    }
}