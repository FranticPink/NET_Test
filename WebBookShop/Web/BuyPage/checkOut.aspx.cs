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
using BookShop.Model;
using System.Globalization;

namespace BookShop.Web.BuyPage
{
    public partial class checkOut : System.Web.UI.Page
    {
        BookShop.BLL.Book book = new BookShop.BLL.Book();
        BookShop.BLL.Member member = new BookShop.BLL.Member();
        BookShop.Model.Sale Msale = new Model.Sale();
        Model.OrderSheet MOrderSh = new Model.OrderSheet();
        BLL.Sale Bsale = new BLL.Sale();
        BLL.OrderSheet BOrderSh = new BLL.OrderSheet();

        CommonClass ccObj = new CommonClass();

        UserClass ucObj = new UserClass();
        DataTable dtTable;
        Hashtable hashCar;
        string UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    //Response.Redirect("Default.aspx");
                    Response.Write("<script lanuage=javascript>alert('对不起,您还不是会员！');location='kaoshi_timu.aspx'</script>");
                }
                //if (Session["Username"] != null)
                else
                {
                    //如果用户已登录，则显示用户的基本信息
                   // DataTable dsTable = ucObj.GetUserInfo(Convert.ToInt32(Session["UserID"].ToString()));
                    UserID = Session["UserID"].ToString();
                    DataTable dsTable = member.GetList("memberNo="+Session["UserID"].ToString()).Tables[0];
                    this.txtReciverName.Text = dsTable.Rows[0]["memName"].ToString();     //收货人姓名
                    this.txtReceiverPhone.Text = dsTable.Rows[0]["telephone"].ToString();   //收货人电话号码
                    this.txtReceiverEmails.Text = dsTable.Rows[0]["email"].ToString();  //收货人Email
                    this.txtReceiverPostCode.Text = dsTable.Rows[0]["zipCode"].ToString();//收货人邮编
                    this.txtReceiverAddress.Text = dsTable.Rows[0]["address"].ToString();  //收货人详细地址
                }
                if (Session["ShopCart"] == null)
                {
                    //如果没有购物，则给出相应信息，并隐藏按钮
                    this.labMessage.Text = "您还没有购物！"; //显示提示信息
                    this.btnConfirm.Visible = false;         //隐藏“确认”按钮
                }
                else
                {
                    hashCar = (Hashtable)Session["ShopCart"];  //获取其购物车
                    if (hashCar.Count == 0)
                    {
                        //如果没有购物，则给出相应信息，并隐藏按钮
                        this.labMessage.Text = "您购物车中没有商品！";//显示提示信息
                        this.btnConfirm.Visible = false;              //隐藏“确认”按钮
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
                        this.labTotalPrice.Text =totalPrice.ToString();  //显示所有商品的价格
                        this.gvShopCart.DataSource = dtTable.DefaultView;   //绑定GridView控件
                        this.gvShopCart.DataKeyNames = new string[] { "ISBN" };
                        this.gvShopCart.DataBind();
                    }
                }
            }

        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //得到用户输入的信息
                string strPhone;  //电话号码
                string strEmail;  //Email
                string strZip;    //邮政编码
                float fltShipFee; //邮递方式及其费用
                if (IsValidPostCode(this.txtReceiverPostCode.Text.Trim()) == true) //判断输入的邮编是否合法
                {
                    strZip = this.txtReceiverPostCode.Text.Trim();
                }
                else
                {
                    Response.Write(ccObj.MessageBox("输入有误！"));
                    return;
                }
                if (IsValidPhone(this.txtReceiverPhone.Text.Trim()) == true)//判断输入的电话号码是否合法
                {
                    strPhone = this.txtReceiverPhone.Text.Trim();
                }
                else
                {
                    Response.Write(ccObj.MessageBox("输入有误！"));
                    return;
                }
                if (IsValidEmail(this.txtReceiverEmails.Text.Trim()) == true)//判断输入的Email是否合法
                {
                    strEmail = this.txtReceiverEmails.Text.Trim();
                }
                else
                {
                    Response.Write(ccObj.MessageBox("输入有误！"));
                    return;
                }
                if (this.ddlShipType.SelectedIndex != 0)//获取邮递方式及其费用
                {
                    fltShipFee = float.Parse(this.ddlShipType.SelectedValue.ToString());
                }
                else
                {
                    Response.Write(ccObj.MessageBox("请选择运输方式！"));
                    return;
                }
                string strName = this.txtReciverName.Text.Trim();       //收货人姓名
                string strAddress = this.txtReceiverAddress.Text.Trim();//收货人详细地址
                string strRemark = this.txtRemark.Text.Trim();          //备注
                int IntTotalNum = int.Parse(this.labTotalNum.Text);     //商品总数
                float fltTotalShipFee = IntTotalNum * fltShipFee;       //运输总费用
                //将订单信息插入订单表中
                MOrderSh.orderNo = BOrderSh.CreateNo();
                MOrderSh.memberNo = Session["UserID"].ToString();
                MOrderSh.employeeNo = "";
                MOrderSh.orderDate = DateTime.Now;
                string TotalPrice = this.labTotalPrice.Text.Trim().ToString();
                MOrderSh.orderMoney =decimal.Parse(TotalPrice); 
                MOrderSh.payWay = "";
                MOrderSh.payFlag = "";
                MOrderSh.orderState = "0";//012345
                MOrderSh.invoiceUnit = "";
                MOrderSh.receiver = strName;
                MOrderSh.zipCode = txtReceiverPostCode.Text.Trim().ToString();
                MOrderSh.shipAddress = strAddress;
                MOrderSh.shipTel = txtReceiverPhone.Text.Trim().ToString();

                BOrderSh.Add(MOrderSh);

                string OrderID = MOrderSh.orderNo;
                string ISBN; //商品ID
                int IntNum;    //购买商品数量
                float fltTotalPrice;
                //对订单中的每一个货物插入订单详细表中
                foreach (GridViewRow gvr in this.gvShopCart.Rows)
                {
                    ISBN = gvr.Cells[1].Text;
                    IntNum = int.Parse(gvr.Cells[3].Text);
                    fltTotalPrice = float.Parse(gvr.Cells[5].Text);
                    Msale.orderNo = OrderID;
                    Msale.ISBN = ISBN;
                    Msale.quantity = IntNum;
                    Msale.bookState = "0";
                    Bsale.Add(Msale);
                }
                //设置Session
                Session["ShopCart"] = null;  //清空购物车
                Response.Redirect("PayWay.aspx?OrderID=" + OrderID);
                //Response.Redirect("GoBank.aspx?OrderID=" + IntOrderID );


            }
        }
        //判断修改的数据是否为有效的数据
        public bool IsValidPostCode(string num)
        {//验证邮编
            return Regex.IsMatch(num, @"\d{6}");
        }
        public bool IsValidPhone(string num)
        {//验证电话号码
            return Regex.IsMatch(num, @"(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$");
        }
        public bool IsValidEmail(string num)
        {//验证Email
            return Regex.IsMatch(num, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }


    }
}