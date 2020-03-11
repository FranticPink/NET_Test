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

namespace BookShop.Web.Manage
{
    public partial class MemberAdd : System.Web.UI.Page
    {
        BLL.Employee Bemp = new BLL.Employee();
        Model.Employee Memp = new Model.Employee();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtPassWord.Text = "";
            this.txtTrueName.Text = "";
            this.txtEmail.Text = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string empName =  this.txtName.Text.Trim();
            DataTable dsTable = Bemp.GetList("where="+empName).Tables[0];
            if (dsTable.Rows.Count > 0)
            {
                Response.Write("该用户名已存在！");
            }
            else
            {
                Memp.empName=this.txtName.Text.Trim();

                Memp.empPassword = this.txtPassWord.Text.Trim();

                Memp.email = this.txtEmail.Text.Trim();
                Bemp.Add(Memp);
                Response.Write("添加成功！");
            }
        }
    }
}