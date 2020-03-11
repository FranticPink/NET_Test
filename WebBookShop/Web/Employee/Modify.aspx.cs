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
namespace BookShop.Web.Employee
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string employeeNo= Request.Params["id"];
					ShowInfo(employeeNo);
				}
			}
		}
			
	private void ShowInfo(string employeeNo)
	{
		BookShop.BLL.Employee bll=new BookShop.BLL.Employee();
		BookShop.Model.Employee model=bll.GetModel(employeeNo);
		this.lblemployeeNo.Text=model.employeeNo;
		this.txtempPassword.Text=model.empPassword;
		this.txtempName.Text=model.empName;
		this.txtsex.Text=model.sex;
		this.txtbirthday.Text=model.birthday.ToString();
		this.txtdepartment.Text=model.department;
		this.txttitle.Text=model.title;
		this.txtsalary.Text=model.salary.ToString();
		this.txtaddress.Text=model.address;
		this.txttelephone.Text=model.telephone;
		this.txtemail.Text=model.email;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtempPassword.Text.Trim().Length==0)
			{
				strErr+="empPassword不能为空！\\n";	
			}
			if(this.txtempName.Text.Trim().Length==0)
			{
				strErr+="empName不能为空！\\n";	
			}
			if(this.txtsex.Text.Trim().Length==0)
			{
				strErr+="sex不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtbirthday.Text))
			{
				strErr+="birthday格式错误！\\n";	
			}
			if(this.txtdepartment.Text.Trim().Length==0)
			{
				strErr+="department不能为空！\\n";	
			}
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="title不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtsalary.Text))
			{
				strErr+="salary格式错误！\\n";	
			}
			if(this.txtaddress.Text.Trim().Length==0)
			{
				strErr+="address不能为空！\\n";	
			}
			if(this.txttelephone.Text.Trim().Length==0)
			{
				strErr+="telephone不能为空！\\n";	
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
			string employeeNo=this.lblemployeeNo.Text;
			string empPassword=this.txtempPassword.Text;
			string empName=this.txtempName.Text;
			string sex=this.txtsex.Text;
			DateTime birthday=DateTime.Parse(this.txtbirthday.Text);
			string department=this.txtdepartment.Text;
			string title=this.txttitle.Text;
			decimal salary=decimal.Parse(this.txtsalary.Text);
			string address=this.txtaddress.Text;
			string telephone=this.txttelephone.Text;
			string email=this.txtemail.Text;


			BookShop.Model.Employee model=new BookShop.Model.Employee();
			model.employeeNo=employeeNo;
			model.empPassword=empPassword;
			model.empName=empName;
			model.sex=sex;
			model.birthday=birthday;
			model.department=department;
			model.title=title;
			model.salary=salary;
			model.address=address;
			model.telephone=telephone;
			model.email=email;

			BookShop.BLL.Employee bll=new BookShop.BLL.Employee();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
