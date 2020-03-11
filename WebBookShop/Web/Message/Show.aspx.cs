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
namespace BookShop.Web.Message
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
					string messageNo= strid;
					ShowInfo(messageNo);
				}
			}
		}
		
	private void ShowInfo(string messageNo)
	{
		BookShop.BLL.Message bll=new BookShop.BLL.Message();
		BookShop.Model.Message model=bll.GetModel(messageNo);
		this.lblmessageNo.Text=model.messageNo;
		this.lblemployeeNo.Text=model.employeeNo;
		this.lblmemberNo.Text=model.memberNo;
		this.lblreleaseDate.Text=model.releaseDate.ToString();
		this.lblmessageContent.Text=model.messageContent;
		this.lblreplyContent.Text=model.replyContent;
		this.lblreplyDate.Text=model.replyDate.ToString();

	}


    }
}
