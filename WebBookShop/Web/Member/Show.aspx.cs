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
namespace BookShop.Web.Member
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
					string memberNo= strid;
					ShowInfo(memberNo);
				}
			}
		}
		
	private void ShowInfo(string memberNo)
	{
		BookShop.BLL.Member bll=new BookShop.BLL.Member();
		BookShop.Model.Member model=bll.GetModel(memberNo);
		this.lblmemberNo.Text=model.memberNo;
		this.lblmemPassword.Text=model.memPassword;
		this.lblmemName.Text=model.memName;
		this.lblsex.Text=model.sex;
		this.lblbirthday.Text=model.birthday.ToString();
		this.lbltelephone.Text=model.telephone;
		this.lblemail.Text=model.email;
		this.lbladdress.Text=model.address;
		this.lblzipCode.Text=model.zipCode;
		this.lbltotalAmount.Text=model.totalAmount.ToString();
		this.lblmemLevel.Text=model.memLevel;
		this.lbldiscount.Text=model.discount.ToString();

	}


    }
}
