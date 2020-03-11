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
namespace BookShop.Web.ShipSheet
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
		this.txtshipDate.Text=model.shipDate.ToString();
		this.txtcompanyNo.Text=model.companyNo;
		this.txtinvoiceNo.Text=model.invoiceNo;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtshipDate.Text))
			{
				strErr+="shipDate格式错误！\\n";	
			}
			if(this.txtcompanyNo.Text.Trim().Length==0)
			{
				strErr+="companyNo不能为空！\\n";	
			}
			if(this.txtinvoiceNo.Text.Trim().Length==0)
			{
				strErr+="invoiceNo不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string shipNo=this.lblshipNo.Text;
			string orderNo=this.lblorderNo.Text;
			DateTime shipDate=DateTime.Parse(this.txtshipDate.Text);
			string companyNo=this.txtcompanyNo.Text;
			string invoiceNo=this.txtinvoiceNo.Text;


			BookShop.Model.ShipSheet model=new BookShop.Model.ShipSheet();
			model.shipNo=shipNo;
			model.orderNo=orderNo;
			model.shipDate=shipDate;
			model.companyNo=companyNo;
			model.invoiceNo=invoiceNo;

			BookShop.BLL.ShipSheet bll=new BookShop.BLL.ShipSheet();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
