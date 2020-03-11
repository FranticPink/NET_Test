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
namespace BookShop.Web.Press
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int pressNo=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(pressNo);
				}
			}
		}
			
	private void ShowInfo(int pressNo)
	{
		BookShop.BLL.Press bll=new BookShop.BLL.Press();
		BookShop.Model.Press model=bll.GetModel(pressNo);
		this.lblpressNo.Text=model.pressNo.ToString();
		this.txtpressName.Text=model.pressName;
		this.txtadress.Text=model.adress;
		this.txtzipCode.Text=model.zipCode;
		this.txtcontactPerson.Text=model.contactPerson;
		this.txttelephone.Text=model.telephone;
		this.txtfax.Text=model.fax;
		this.txtemail.Text=model.email;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtpressName.Text.Trim().Length==0)
			{
				strErr+="pressName不能为空！\\n";	
			}
			if(this.txtadress.Text.Trim().Length==0)
			{
				strErr+="adress不能为空！\\n";	
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
			int pressNo=int.Parse(this.lblpressNo.Text);
			string pressName=this.txtpressName.Text;
			string adress=this.txtadress.Text;
			string zipCode=this.txtzipCode.Text;
			string contactPerson=this.txtcontactPerson.Text;
			string telephone=this.txttelephone.Text;
			string fax=this.txtfax.Text;
			string email=this.txtemail.Text;


			BookShop.Model.Press model=new BookShop.Model.Press();
			model.pressNo=pressNo;
			model.pressName=pressName;
			model.adress=adress;
			model.zipCode=zipCode;
			model.contactPerson=contactPerson;
			model.telephone=telephone;
			model.fax=fax;
			model.email=email;

			BookShop.BLL.Press bll=new BookShop.BLL.Press();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
