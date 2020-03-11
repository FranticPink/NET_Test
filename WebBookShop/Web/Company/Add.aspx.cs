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
namespace BookShop.Web.Company
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcompantNo.Text.Trim().Length==0)
			{
				strErr+="compantNo不能为空！\\n";	
			}
			if(this.txtcompanyName.Text.Trim().Length==0)
			{
				strErr+="companyName不能为空！\\n";	
			}
			if(this.txtaddress.Text.Trim().Length==0)
			{
				strErr+="address不能为空！\\n";	
			}
			if(this.txtzipCode.Text.Trim().Length==0)
			{
				strErr+="zipCode不能为空！\\n";	
			}
			if(this.txtcontactPerson.Text.Trim().Length==0)
			{
				strErr+="contactPerson不能为空！\\n";	
			}
			if(this.txttelephone.Text.Trim().Length==0)
			{
				strErr+="telephone不能为空！\\n";	
			}
			if(this.txtfax.Text.Trim().Length==0)
			{
				strErr+="fax不能为空！\\n";	
			}
			if(this.txtemail.Text.Trim().Length==0)
			{
				strErr+="email不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string compantNo=this.txtcompantNo.Text;
			string companyName=this.txtcompanyName.Text;
			string address=this.txtaddress.Text;
			string zipCode=this.txtzipCode.Text;
			string contactPerson=this.txtcontactPerson.Text;
			string telephone=this.txttelephone.Text;
			string fax=this.txtfax.Text;
			string email=this.txtemail.Text;

			BookShop.Model.Company model=new BookShop.Model.Company();
			model.compantNo=compantNo;
			model.companyName=companyName;
			model.address=address;
			model.zipCode=zipCode;
			model.contactPerson=contactPerson;
			model.telephone=telephone;
			model.fax=fax;
			model.email=email;

			BookShop.BLL.Company bll=new BookShop.BLL.Company();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
