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
using System.Text;
namespace BookShop.Web.Book
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					string ISBN= strid;
					ShowInfo(ISBN);
				}
			}
		}
		
	private void ShowInfo(string ISBN)
	{
		BookShop.BLL.Book bll=new BookShop.BLL.Book();
		BookShop.Model.Book model=bll.GetModel(ISBN);
		this.lblISBN.Text=model.ISBN;
		this.lblbookTitle.Text=model.bookTitle;
		this.lblauthor.Text=model.author;
		this.lblpublishDate.Text=model.publishDate.ToString();
		this.lblversion.Text=model.version.ToString();
		this.lblstockNumber.Text=model.stockNumber.ToString();
		this.lblprice.Text=model.price.ToString();
		this.lblsalePrice.Text=model.salePrice.ToString();
		this.lblintroduction.Text=model.introduction;
		this.lblcatalog.Text=model.catalog;
		this.lblcategoryId.Text=model.categoryId.ToString();
		this.lblpressNo.Text=model.pressNo.ToString();

	}


    }
}
