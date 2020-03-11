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

namespace BookShop.Web.Manage
{
    public partial class Product : System.Web.UI.Page
    {
        BLL.Book Bbook = new BLL.Book();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource= Bbook.GetAllList().Tables[0];
                GridView1.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Key = "'%"+this.txtKey.Text+"%'";
            string where = "bookTitle like"+Key +"or ISBN like"+Key+"or auther like"+Key;
            DataTable dt = Bbook.GetList(where).Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
     
    }
}