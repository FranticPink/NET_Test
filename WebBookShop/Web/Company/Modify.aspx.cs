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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string compantNo= Request.Params["id"];
					ShowInfo(compantNo);
				}
			}
		}
			
	private void ShowInfo(string compantNo)
	{
		BookShop.BLL.Company bll=new BookShop.BLL.Company();
		BookShop.Model.Company model=bll.GetModel(compantNo);
		this.lblcompantNo.Text=model.compantNo;
		this.txtcompanyName.Text=model.companyName;
		this.txtaddress.Text=model.address;
		this.txtzipCode.Text=model.zipCode;
		this.txtcontactPerson.Text=model.contactPerson;
		this.txttelephone.Text=model.telephone;
		this.txtfax.Text=model.fax;
		this.txtemail.Text=model.email;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			string compantNo=this.lblcompantNo.Text;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
