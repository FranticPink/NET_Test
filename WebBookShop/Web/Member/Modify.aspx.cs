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
namespace BookShop.Web.Member
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string memberNo= Request.Params["id"];
					ShowInfo(memberNo);
				}
			}
		}
			
	private void ShowInfo(string memberNo)
	{
		BookShop.BLL.Member bll=new BookShop.BLL.Member();
		BookShop.Model.Member model=bll.GetModel(memberNo);
		this.lblmemberNo.Text=model.memberNo;
		this.txtmemPassword.Text=model.memPassword;
		this.txtmemName.Text=model.memName;
		this.txtsex.Text=model.sex;
		this.txtbirthday.Text=model.birthday.ToString();
		this.txttelephone.Text=model.telephone;
		this.txtemail.Text=model.email;
		this.txtaddress.Text=model.address;
		this.txtzipCode.Text=model.zipCode;
		this.txttotalAmount.Text=model.totalAmount.ToString();
		this.txtmemLevel.Text=model.memLevel;
		this.txtdiscount.Text=model.discount.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtmemPassword.Text.Trim().Length==0)
			{
				strErr+="memPassword不能为空！\\n";	
			}
			if(this.txtmemName.Text.Trim().Length==0)
			{
				strErr+="memName不能为空！\\n";	
			}
			if(this.txtsex.Text.Trim().Length==0)
			{
				strErr+="sex不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtbirthday.Text))
			{
				strErr+="birthday格式错误！\\n";	
			}
			if(this.txttelephone.Text.Trim().Length==0)
			{
				strErr+="telephone不能为空！\\n";	
			}
			if(this.txtemail.Text.Trim().Length==0)
			{
				strErr+="email不能为空！\\n";	
			}
			if(this.txtaddress.Text.Trim().Length==0)
			{
				strErr+="address不能为空！\\n";	
			}
			if(this.txtzipCode.Text.Trim().Length==0)
			{
				strErr+="zipCode不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txttotalAmount.Text))
			{
				strErr+="totalAmount格式错误！\\n";	
			}
			if(this.txtmemLevel.Text.Trim().Length==0)
			{
				strErr+="memLevel不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtdiscount.Text))
			{
				strErr+="discount格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string memberNo=this.lblmemberNo.Text;
			string memPassword=this.txtmemPassword.Text;
			string memName=this.txtmemName.Text;
			string sex=this.txtsex.Text;
			DateTime birthday=DateTime.Parse(this.txtbirthday.Text);
			string telephone=this.txttelephone.Text;
			string email=this.txtemail.Text;
			string address=this.txtaddress.Text;
			string zipCode=this.txtzipCode.Text;
			decimal totalAmount=decimal.Parse(this.txttotalAmount.Text);
			string memLevel=this.txtmemLevel.Text;
			decimal discount=decimal.Parse(this.txtdiscount.Text);


			BookShop.Model.Member model=new BookShop.Model.Member();
			model.memberNo=memberNo;
			model.memPassword=memPassword;
			model.memName=memName;
			model.sex=sex;
			model.birthday=birthday;
			model.telephone=telephone;
			model.email=email;
			model.address=address;
			model.zipCode=zipCode;
			model.totalAmount=totalAmount;
			model.memLevel=memLevel;
			model.discount=discount;

			BookShop.BLL.Member bll=new BookShop.BLL.Member();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
