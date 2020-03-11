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
namespace BookShop.Web.Invoice
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
					string invoiceNo= strid;
					ShowInfo(invoiceNo);
				}
			}
		}
		
	private void ShowInfo(string invoiceNo)
	{
		BookShop.BLL.Invoice bll=new BookShop.BLL.Invoice();
		BookShop.Model.Invoice model=bll.GetModel(invoiceNo);
		this.lblinvoiceNo.Text=model.invoiceNo;
		this.lblinvoiceUnit.Text=model.invoiceUnit;
		this.lblinvoiceSum.Text=model.invoiceSum.ToString();

	}


    }
}
