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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace BookShop.Web.Book
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string ISBN= Request.Params["id"];
					ShowInfo(ISBN);
				}
			}
		}
			
	private void ShowInfo(string ISBN)
	{
		BookShop.BLL.Book bll=new BookShop.BLL.Book();
		BookShop.Model.Book model=bll.GetModel(ISBN);
		this.lblISBN.Text=model.ISBN;
		this.txtbookTitle.Text=model.bookTitle;
		this.txtauthor.Text=model.author;
		this.txtpublishDate.Text=model.publishDate.ToString();
		this.txtversion.Text=model.version.ToString();
		this.txtstockNumber.Text=model.stockNumber.ToString();
		this.txtprice.Text=model.price.ToString();
		this.txtsalePrice.Text=model.salePrice.ToString();
		this.txtintroduction.Text=model.introduction;
		this.txtcatalog.Text=model.catalog;
		this.txtcategoryId.Text=model.categoryId.ToString();
		this.txtpressNo.Text=model.pressNo.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtbookTitle.Text.Trim().Length==0)
			{
				strErr+="bookTitle不能为空！\\n";	
			}
			if(this.txtauthor.Text.Trim().Length==0)
			{
				strErr+="author不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtpublishDate.Text))
			{
				strErr+="publishDate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtversion.Text))
			{
				strErr+="version格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtstockNumber.Text))
			{
				strErr+="stockNumber格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtprice.Text))
			{
				strErr+="price格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtsalePrice.Text))
			{
				strErr+="salePrice格式错误！\\n";	
			}
			if(this.txtintroduction.Text.Trim().Length==0)
			{
				strErr+="introduction不能为空！\\n";	
			}
			if(this.txtcatalog.Text.Trim().Length==0)
			{
				strErr+="catalog不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcategoryId.Text))
			{
				strErr+="categoryId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtpressNo.Text))
			{
				strErr+="pressNo格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string ISBN=this.lblISBN.Text;
			string bookTitle=this.txtbookTitle.Text;
			string author=this.txtauthor.Text;
			DateTime publishDate=DateTime.Parse(this.txtpublishDate.Text);
			int version=int.Parse(this.txtversion.Text);
			int stockNumber=int.Parse(this.txtstockNumber.Text);
			decimal price=decimal.Parse(this.txtprice.Text);
			decimal salePrice=decimal.Parse(this.txtsalePrice.Text);
			string introduction=this.txtintroduction.Text;
			string catalog=this.txtcatalog.Text;
			int categoryId=int.Parse(this.txtcategoryId.Text);
			int pressNo=int.Parse(this.txtpressNo.Text);


			BookShop.Model.Book model=new BookShop.Model.Book();
			model.ISBN=ISBN;
			model.bookTitle=bookTitle;
			model.author=author;
			model.publishDate=publishDate;
			model.version=version;
			model.stockNumber=stockNumber;
			model.price=price;
			model.salePrice=salePrice;
			model.introduction=introduction;
			model.catalog=catalog;
			model.categoryId=categoryId;
			model.pressNo=pressNo;

			BookShop.BLL.Book bll=new BookShop.BLL.Book();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
