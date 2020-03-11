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
namespace BookShop.Web.OrderSheet
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
					string orderNo= strid;
					ShowInfo(orderNo);
				}
			}
		}
		
	private void ShowInfo(string orderNo)
	{
		BookShop.BLL.OrderSheet bll=new BookShop.BLL.OrderSheet();
		BookShop.Model.OrderSheet model=bll.GetModel(orderNo);
		this.lblorderNo.Text=model.orderNo;
		this.lblmemberNo.Text=model.memberNo;
		this.lblemployeeNo.Text=model.employeeNo;
		this.lblorderDate.Text=model.orderDate.ToString();
		this.lblorderMoney.Text=model.orderMoney.ToString();
		this.lblpayWay.Text=model.payWay;
		this.lblpayFlag.Text=model.payFlag;
		this.lblorderState.Text=model.orderState;
		this.lblinvoiceUnit.Text=model.invoiceUnit;
		this.lblreceiver.Text=model.receiver;
		this.lblzipCode.Text=model.zipCode;
		this.lblshipAddress.Text=model.shipAddress;
		this.lblshipTel.Text=model.shipTel;

	}


    }
}
