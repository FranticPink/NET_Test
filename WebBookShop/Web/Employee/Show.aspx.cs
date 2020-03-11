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
namespace BookShop.Web.Employee
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					string employeeNo= strid;
					ShowInfo(employeeNo);
				}
			}
		}
		
	private void ShowInfo(string employeeNo)
	{
		BookShop.BLL.Employee bll=new BookShop.BLL.Employee();
		BookShop.Model.Employee model=bll.GetModel(employeeNo);
		this.lblemployeeNo.Text=model.employeeNo;
		this.lblempPassword.Text=model.empPassword;
		this.lblempName.Text=model.empName;
		this.lblsex.Text=model.sex;
		this.lblbirthday.Text=model.birthday.ToString();
		this.lbldepartment.Text=model.department;
		this.lbltitle.Text=model.title;
		this.lblsalary.Text=model.salary.ToString();
		this.lbladdress.Text=model.address;
		this.lbltelephone.Text=model.telephone;
		this.lblemail.Text=model.email;

	}


    }
}
