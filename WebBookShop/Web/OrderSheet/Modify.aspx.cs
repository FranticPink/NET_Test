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
namespace BookShop.Web.OrderSheet
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string orderNo= Request.Params["id"];
					ShowInfo(orderNo);
				}
			}
		}
			
	private void ShowInfo(string orderNo)
	{
		BookShop.BLL.OrderSheet bll=new BookShop.BLL.OrderSheet();
		BookShop.Model.OrderSheet model=bll.GetModel(orderNo);
		this.lblorderNo.Text=model.orderNo;
		this.txtmemberNo.Text=model.memberNo;
		this.txtemployeeNo.Text=model.employeeNo;
		this.txtorderDate.Text=model.orderDate.ToString();
		this.txtorderMoney.Text=model.orderMoney.ToString();
		this.txtpayWay.Text=model.payWay;
		this.txtpayFlag.Text=model.payFlag;
		this.txtorderState.Text=model.orderState;
		this.txtinvoiceUnit.Text=model.invoiceUnit;
		this.txtreceiver.Text=model.receiver;
		this.txtzipCode.Text=model.zipCode;
		this.txtshipAddress.Text=model.shipAddress;
		this.txtshipTel.Text=model.shipTel;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtmemberNo.Text.Trim().Length==0)
			{
				strErr+="memberNo不能为空！\\n";	
			}
			if(this.txtemployeeNo.Text.Trim().Length==0)
			{
				strErr+="employeeNo不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtorderDate.Text))
			{
				strErr+="orderDate格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtorderMoney.Text))
			{
				strErr+="orderMoney格式错误！\\n";	
			}
			if(this.txtpayWay.Text.Trim().Length==0)
			{
				strErr+="payWay不能为空！\\n";	
			}
			if(this.txtpayFlag.Text.Trim().Length==0)
			{
				strErr+="payFlag不能为空！\\n";	
			}
			if(this.txtorderState.Text.Trim().Length==0)
			{
				strErr+="orderState不能为空！\\n";	
			}
			if(this.txtinvoiceUnit.Text.Trim().Length==0)
			{
				strErr+="invoiceUnit不能为空！\\n";	
			}
			if(this.txtreceiver.Text.Trim().Length==0)
			{
				strErr+="receiver不能为空！\\n";	
			}
			if(this.txtzipCode.Text.Trim().Length==0)
			{
				strErr+="zipCode不能为空！\\n";	
			}
			if(this.txtshipAddress.Text.Trim().Length==0)
			{
				strErr+="shipAddress不能为空！\\n";	
			}
			if(this.txtshipTel.Text.Trim().Length==0)
			{
				strErr+="shipTel不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string orderNo=this.lblorderNo.Text;
			string memberNo=this.txtmemberNo.Text;
			string employeeNo=this.txtemployeeNo.Text;
			DateTime orderDate=DateTime.Parse(this.txtorderDate.Text);
			decimal orderMoney=decimal.Parse(this.txtorderMoney.Text);
			string payWay=this.txtpayWay.Text;
			string payFlag=this.txtpayFlag.Text;
			string orderState=this.txtorderState.Text;
			string invoiceUnit=this.txtinvoiceUnit.Text;
			string receiver=this.txtreceiver.Text;
			string zipCode=this.txtzipCode.Text;
			string shipAddress=this.txtshipAddress.Text;
			string shipTel=this.txtshipTel.Text;


			BookShop.Model.OrderSheet model=new BookShop.Model.OrderSheet();
			model.orderNo=orderNo;
			model.memberNo=memberNo;
			model.employeeNo=employeeNo;
			model.orderDate=orderDate;
			model.orderMoney=orderMoney;
			model.payWay=payWay;
			model.payFlag=payFlag;
			model.orderState=orderState;
			model.invoiceUnit=invoiceUnit;
			model.receiver=receiver;
			model.zipCode=zipCode;
			model.shipAddress=shipAddress;
			model.shipTel=shipTel;

			BookShop.BLL.OrderSheet bll=new BookShop.BLL.OrderSheet();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
