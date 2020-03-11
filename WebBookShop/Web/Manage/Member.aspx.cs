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
    public partial class Member : System.Web.UI.Page
    {

        BLL.Employee Bemp = new BLL.Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvAdminBind();
            }
        }
        public void gvAdminBind()
        {

            DataTable dsTable = Bemp.GetAllList().Tables[0];
            this.gvAdminList.DataSource = dsTable.DefaultView;
            this.gvAdminList.DataKeyNames = new string[] { "employeeNo" };
            this.gvAdminList.DataBind();
        }
        protected void gvAdminList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdminList.PageIndex = e.NewPageIndex;
            gvAdminBind();
        }
        protected void gvAdminList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string employeeNo = gvAdminList.DataKeys[e.RowIndex].Value.ToString();
            Bemp.Delete("employeeNo=" + employeeNo);

        }
    }
}