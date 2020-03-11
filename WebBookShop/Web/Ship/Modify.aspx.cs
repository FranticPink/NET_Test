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
namespace BookShop.Web.Ship
{
    public partial class Modify : Page
    {       

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
				string ISBN = "";
				if (Request.Params["id2"] != null && Request.Params["id2"].Trim() != "")
				{
					ISBN= Request.Params["id2"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(shipNo,orderNo,ISBN);
			}
		}
			
	private void ShowInfo(string shipNo,string orderNo,string ISBN)
	{
		BookShop.BLL.Ship bll=new BookShop.BLL.Ship();
		BookShop.Model.Ship model=bll.GetModel(shipNo,orderNo,ISBN);
		this.lblshipNo.Text=model.shipNo;
		this.lblorderNo.Text=model.orderNo;
		this.lblISBN.Text=model.ISBN;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string shipNo=this.lblshipNo.Text;
			string orderNo=this.lblorderNo.Text;
			string ISBN=this.lblISBN.Text;


			BookShop.Model.Ship model=new BookShop.Model.Ship();
			model.shipNo=shipNo;
			model.orderNo=orderNo;
			model.ISBN=ISBN;

			BookShop.BLL.Ship bll=new BookShop.BLL.Ship();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
