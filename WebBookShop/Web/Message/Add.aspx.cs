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
namespace BookShop.Web.Message
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtmessageNo.Text.Trim().Length==0)
			{
				strErr+="messageNo不能为空！\\n";	
			}
			if(this.txtemployeeNo.Text.Trim().Length==0)
			{
				strErr+="employeeNo不能为空！\\n";	
			}
			if(this.txtmemberNo.Text.Trim().Length==0)
			{
				strErr+="memberNo不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtreleaseDate.Text))
			{
				strErr+="releaseDate格式错误！\\n";	
			}
			if(this.txtmessageContent.Text.Trim().Length==0)
			{
				strErr+="messageContent不能为空！\\n";	
			}
			if(this.txtreplyContent.Text.Trim().Length==0)
			{
				strErr+="replyContent不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtreplyDate.Text))
			{
				strErr+="replyDate格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string messageNo=this.txtmessageNo.Text;
			string employeeNo=this.txtemployeeNo.Text;
			string memberNo=this.txtmemberNo.Text;
			DateTime releaseDate=DateTime.Parse(this.txtreleaseDate.Text);
			string messageContent=this.txtmessageContent.Text;
			string replyContent=this.txtreplyContent.Text;
			DateTime replyDate=DateTime.Parse(this.txtreplyDate.Text);

			BookShop.Model.Message model=new BookShop.Model.Message();
			model.messageNo=messageNo;
			model.employeeNo=employeeNo;
			model.memberNo=memberNo;
			model.releaseDate=releaseDate;
			model.messageContent=messageContent;
			model.replyContent=replyContent;
			model.replyDate=replyDate;

			BookShop.BLL.Message bll=new BookShop.BLL.Message();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
