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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtpressNo.Text))
			{
				strErr+="pressNo格式错误！\\n";	
			}
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
			int pressNo=int.Parse(this.txtpressNo.Text);
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
