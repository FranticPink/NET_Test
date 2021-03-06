﻿using System;
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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtshipNo.Text.Trim().Length==0)
			{
				strErr+="shipNo不能为空！\\n";	
			}
			if(this.txtorderNo.Text.Trim().Length==0)
			{
				strErr+="orderNo不能为空！\\n";	
			}
			if(this.txtISBN.Text.Trim().Length==0)
			{
				strErr+="ISBN不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string shipNo=this.txtshipNo.Text;
			string orderNo=this.txtorderNo.Text;
			string ISBN=this.txtISBN.Text;

			BookShop.Model.Ship model=new BookShop.Model.Ship();
			model.shipNo=shipNo;
			model.orderNo=orderNo;
			model.ISBN=ISBN;

			BookShop.BLL.Ship bll=new BookShop.BLL.Ship();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
