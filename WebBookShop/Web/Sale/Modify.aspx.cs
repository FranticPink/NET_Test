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
namespace BookShop.Web.Sale
{
    public partial class Modify : Page
    {       

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
		this.txtquantity.Text=model.quantity.ToString();
		this.txtboookState.Text=model.boookState;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtquantity.Text))
			{
				strErr+="quantity格式错误！\\n";	
			}
			if(this.txtboookState.Text.Trim().Length==0)
			{
				strErr+="boookState不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string orderNo=this.lblorderNo.Text;
			string ISBN=this.lblISBN.Text;
			int quantity=int.Parse(this.txtquantity.Text);
			string boookState=this.txtboookState.Text;


			BookShop.Model.Sale model=new BookShop.Model.Sale();
			model.orderNo=orderNo;
			model.ISBN=ISBN;
			model.quantity=quantity;
			model.boookState=boookState;

			BookShop.BLL.Sale bll=new BookShop.BLL.Sale();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
