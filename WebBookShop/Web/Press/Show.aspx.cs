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
namespace BookShop.Web.Press
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
					int pressNo=(Convert.ToInt32(strid));
					ShowInfo(pressNo);
				}
			}
		}
		
	private void ShowInfo(int pressNo)
	{
		BookShop.BLL.Press bll=new BookShop.BLL.Press();
		BookShop.Model.Press model=bll.GetModel(pressNo);
		this.lblpressNo.Text=model.pressNo.ToString();
		this.lblpressName.Text=model.pressName;
		this.lbladress.Text=model.adress;
		this.lblzipCode.Text=model.zipCode;
		this.lblcontactPerson.Text=model.contactPerson;
		this.lbltelephone.Text=model.telephone;
		this.lblfax.Text=model.fax;
		this.lblemail.Text=model.email;

	}


    }
}
