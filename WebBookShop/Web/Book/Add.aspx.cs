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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtISBN.Text.Trim().Length==0)
			{
				strErr+="ISBN不能为空！\\n";	
			}
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
			string ISBN=this.txtISBN.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
