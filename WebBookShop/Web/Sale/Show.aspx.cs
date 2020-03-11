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
namespace BookShop.Web.Sale
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				string orderNo = "";
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					orderNo= Request.Params["id0"];
				}
				string ISBN = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					ISBN= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(orderNo,ISBN);
			}
		}
		
	private void ShowInfo(string orderNo,string ISBN)
	{
		BookShop.BLL.Sale bll=new BookShop.BLL.Sale();
		BookShop.Model.Sale model=bll.GetModel(orderNo,ISBN);
		this.lblorderNo.Text=model.orderNo;
		this.lblISBN.Text=model.ISBN;
		this.lblquantity.Text=model.quantity.ToString();
		this.lblboookState.Text=model.boookState;

	}


    }
}
