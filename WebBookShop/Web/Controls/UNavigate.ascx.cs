using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using System.Data;
using System.Data.SqlClient;

namespace BookShop.Web.UserControl
{
    public partial class UNavigate : System.Web.UI.UserControl
    {
        GoodsClass gcObj = new GoodsClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Categories categ = new BLL.Categories();
            if (!IsPostBack)
            {
                this.dlClass.DataSource = categ.GetAllList().Tables[0];
                 this.dlClass.DataBind();
                //gcObj.DLClassBind(this.dlClass);
                //gcObj.DLNewGoods(this.dlNewGoods);

            }
        }
        protected void dlClass_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                Response.Redirect("~/BuyPage/goodsList.aspx?id=" + e.CommandArgument);
            }
        }
        public string GetClassName(int IntClassID)
        {
            return gcObj.GetClass(IntClassID);
        }
        protected void dlNewGoods_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detailSee")
            {
                Session["address"] = "";
                Session["address"] = "Default.aspx";
                Response.Redirect("~/BuyPage/showInfo.aspx?id=" + Convert.ToInt32(e.CommandArgument.ToString()));
            }

        }
    }
}