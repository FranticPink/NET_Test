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
namespace BookShop.Web.Invoice
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtinvoiceNo.Text.Trim().Length==0)
			{
				strErr+="invoiceNo不能为空！\\n";	
			}
			if(this.txtinvoiceUnit.Text.Trim().Length==0)
			{
				strErr+="invoiceUnit不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtinvoiceSum.Text))
			{
				strErr+="invoiceSum格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string invoiceNo=this.txtinvoiceNo.Text;
			string invoiceUnit=this.txtinvoiceUnit.Text;
			decimal invoiceSum=decimal.Parse(this.txtinvoiceSum.Text);

			BookShop.Model.Invoice model=new BookShop.Model.Invoice();
			model.invoiceNo=invoiceNo;
			model.invoiceUnit=invoiceUnit;
			model.invoiceSum=invoiceSum;

			BookShop.BLL.Invoice bll=new BookShop.BLL.Invoice();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
