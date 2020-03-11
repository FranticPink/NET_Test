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

namespace BookShop.Web.Manage
{
    public partial class Main : System.Web.UI.Page
    {
        BLL.OrderSheet ordersh = new OrderSheet();
        CommonClass ccObj = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvNewOBind();
            }
        }
        public void gvNewOBind()
        {
            DataTable dsTable = ordersh.GetList("DATEDIFF(day, OrderDate, getdate()) < 1").Tables[0];
            this.gvOrderList.DataSource = dsTable.DefaultView;
            this.gvOrderList.DataKeyNames = new string[] { "orderNo" };
            this.gvOrderList.DataBind();
        }
        protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrderList.PageIndex = e.NewPageIndex;
            gvNewOBind();

        }

        protected void orderNo_Click(object sender, EventArgs e)
        {
            Session["AID"] = Session["AID"].ToString();//保存用户ID
            Session["AName"] = Session["AName"].ToString();//保存用户名
            Session["OrderID"] = ((LinkButton)sender).Text.ToString();
            Response.Write("<script language=javascript>window.open('OrderModify.aspx');window.close();</script>");
        }
    }
}