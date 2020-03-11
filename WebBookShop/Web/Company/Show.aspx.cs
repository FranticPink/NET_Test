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
namespace BookShop.Web.Company
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
					string compantNo= strid;
					ShowInfo(compantNo);
				}
			}
		}
		
	private void ShowInfo(string compantNo)
	{
		BookShop.BLL.Company bll=new BookShop.BLL.Company();
		BookShop.Model.Company model=bll.GetModel(compantNo);
		this.lblcompantNo.Text=model.compantNo;
		this.lblcompanyName.Text=model.companyName;
		this.lbladdress.Text=model.address;
		this.lblzipCode.Text=model.zipCode;
		this.lblcontactPerson.Text=model.contactPerson;
		this.lbltelephone.Text=model.telephone;
		this.lblfax.Text=model.fax;
		this.lblemail.Text=model.email;

	}


    }
}
