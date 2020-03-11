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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string invoiceNo= Request.Params["id"];
					ShowInfo(invoiceNo);
				}
			}
		}
			
	private void ShowInfo(string invoiceNo)
	{
		BookShop.BLL.Invoice bll=new BookShop.BLL.Invoice();
		BookShop.Model.Invoice model=bll.GetModel(invoiceNo);
		this.lblinvoiceNo.Text=model.invoiceNo;
		this.txtinvoiceUnit.Text=model.invoiceUnit;
		this.txtinvoiceSum.Text=model.invoiceSum.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			string invoiceNo=this.lblinvoiceNo.Text;
			string invoiceUnit=this.txtinvoiceUnit.Text;
			decimal invoiceSum=decimal.Parse(this.txtinvoiceSum.Text);


			BookShop.Model.Invoice model=new BookShop.Model.Invoice();
			model.invoiceNo=invoiceNo;
			model.invoiceUnit=invoiceUnit;
			model.invoiceSum=invoiceSum;

			BookShop.BLL.Invoice bll=new BookShop.BLL.Invoice();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
