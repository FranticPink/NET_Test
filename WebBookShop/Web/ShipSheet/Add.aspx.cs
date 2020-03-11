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
namespace BookShop.Web.ShipSheet
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtshipNo.Text.Trim().Length==0)
			{
				strErr+="shipNo不能为空！\\n";	
			}
			if(this.txtorderNo.Text.Trim().Length==0)
			{
				strErr+="orderNo不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtshipDate.Text))
			{
				strErr+="shipDate格式错误！\\n";	
			}
			if(this.txtcompanyNo.Text.Trim().Length==0)
			{
				strErr+="companyNo不能为空！\\n";	
			}
			if(this.txtinvoiceNo.Text.Trim().Length==0)
			{
				strErr+="invoiceNo不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string shipNo=this.txtshipNo.Text;
			string orderNo=this.txtorderNo.Text;
			DateTime shipDate=DateTime.Parse(this.txtshipDate.Text);
			string companyNo=this.txtcompanyNo.Text;
			string invoiceNo=this.txtinvoiceNo.Text;

			BookShop.Model.ShipSheet model=new BookShop.Model.ShipSheet();
			model.shipNo=shipNo;
			model.orderNo=orderNo;
			model.shipDate=shipDate;
			model.companyNo=companyNo;
			model.invoiceNo=invoiceNo;

			BookShop.BLL.ShipSheet bll=new BookShop.BLL.ShipSheet();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
