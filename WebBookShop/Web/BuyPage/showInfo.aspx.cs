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

namespace BookShop.Web.BuyPage
{
    public partial class showInfo : System.Web.UI.Page
    {
        BookShop.BLL.Book book = new BookShop.BLL.Book();
        BookShop.BLL.Categories categ = new BookShop.BLL.Categories();
        Press press = new Press();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetGoodsInfo();
            }
        }
        /// <summary>
        /// 获取指定商品的信息，并将其显示在界面上
        /// </summary>
        public void GetGoodsInfo()
        {
            string str = "'" + Request["id"].Trim() + "'";
            DataTable dsTable = book.GetList("ISBN=" + str).Tables[0];
            this.txtCategory.Text = categ.GetList("Id=" + dsTable.Rows[0]["categoryId"].ToString()).Tables[0].Rows[0]["Name"].ToString();
            this.txtName.Text = dsTable.Rows[0]["bookTitle"].ToString();
            this.txtAuthor.Text = dsTable.Rows[0]["author"].ToString();
            this.txtCompany.Text = press.GetList("pressNo=" + dsTable.Rows[0]["pressNo"].ToString()).Tables[0].Rows[0]["pressName"].ToString();
            this.txtMarketPrice.Text = dsTable.Rows[0]["Price"].ToString();
            this.txtHotPrice.Text = dsTable.Rows[0]["salePrice"].ToString();
            this.catalog.Text = dsTable.Rows[0]["catalog"].ToString();
            this.ImageMapPhoto.ImageUrl = "../Images/ftp/9221944.jpg";
            this.cbxCommend.Checked = true;
            this.cbxHot.Checked = true;
            this.cbxDiscount.Checked = true;
            this.txtShortDesc.Text = dsTable.Rows[0]["introduction"].ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string strUrl = Session["address"].ToString();
            Response.Redirect(strUrl);
        }
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                Response.Write("<script language=javascript>alert('字符串含有非法字符！')</script>");
                Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()
                Response.Write("<script language=javascript>window.location.href='default.aspx';</script>");
            }
        }
    }
}