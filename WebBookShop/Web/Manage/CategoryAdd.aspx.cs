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
using System.Data.SqlClient;
using BookShop.BLL;
using BookShop.Model;
using Maticsoft.Common;

namespace BookShop.Web.Manage
{
    public partial class CategoryAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (!PageValidate.IsNumber(txtId.Text))
            {
                strErr += "Id格式错误！\\n";
            }
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "Name不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int Id = int.Parse(this.txtId.Text);
            string Name = this.txtName.Text;

            BookShop.Model.Categories model = new BookShop.Model.Categories();
            model.Id = Id;
            model.Name = Name;

            BookShop.BLL.Categories bll = new BookShop.BLL.Categories();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}