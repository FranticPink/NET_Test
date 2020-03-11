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
namespace BookShop.Web.ShipSheet
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				string shipNo = "";
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					shipNo= Request.Params["id0"];
				}
				string orderNo = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					orderNo= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(shipNo,orderNo);
			}
		}
		
	private void ShowInfo(string shipNo,string orderNo)
	{
		BookShop.BLL.ShipSheet bll=new BookShop.BLL.ShipSheet();
		BookShop.Model.ShipSheet model=bll.GetModel(shipNo,orderNo);
		this.lblshipNo.Text=model.shipNo;
		this.lblorderNo.Text=model.orderNo;
		this.lblshipDate.Text=model.shipDate.ToString();
		this.lblcompanyNo.Text=model.companyNo;
		this.lblinvoiceNo.Text=model.invoiceNo;

	}


    }
}
