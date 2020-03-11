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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtorderNo.Text.Trim().Length==0)
			{
				strErr+="orderNo不能为空！\\n";	
			}
			if(this.txtISBN.Text.Trim().Length==0)
			{
				strErr+="ISBN不能为空！\\n";	
			}
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
			string orderNo=this.txtorderNo.Text;
			string ISBN=this.txtISBN.Text;
			int quantity=int.Parse(this.txtquantity.Text);
			string boookState=this.txtboookState.Text;

			BookShop.Model.Sale model=new BookShop.Model.Sale();
			model.orderNo=orderNo;
			model.ISBN=ISBN;
			model.quantity=quantity;
			model.boookState=boookState;

			BookShop.BLL.Sale bll=new BookShop.BLL.Sale();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
