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

namespace BookShop.Web.BuyPage
{
    public partial class MyWord : System.Web.UI.Page
    {
        BLL.Message msg = new BLL.Message();
        Model.Message Mmsg = new Model.Message();

        CommonClass ccObj = new CommonClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('对不起！您不是会员，请先注册！');location='Default.aspx'</script>");
                Response.End();
            }
            this.dlBind();//显示留言信息
        }
        public void dlBind()
        {
            int curpage = Convert.ToInt32(labNowPage.Text); //当前页
            PagedDataSource ps = new PagedDataSource(); //定义一个PagedDataSource类对象
            //获取留言信息
            DataTable dsTable = msg.GetList("memberNo=" + Session["UserID"].ToString()).Tables[0];
            ps.DataSource = dsTable.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 10; //显示的数量
            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
            lnkbtnPrve.Enabled = true;
            lnkbtnTop.Enabled = true;
            lnkbtnNext.Enabled = true;
            lnkbtnLast.Enabled = true;
            if (curpage == 1)
            {
                lnkbtnTop.Enabled = false;//不显示第一页按钮
                lnkbtnPrve.Enabled = false;//不显示上一页按钮
            }
            if (curpage == ps.PageCount)
            {
                lnkbtnNext.Enabled = false;//不显示下一页
                lnkbtnLast.Enabled = false;//不显示最后一页

            }
            this.labCount.Text = Convert.ToString(ps.PageCount);//页的总数
            //绑定DataList控件，显示留言信息
            this.dlMyWord.DataSource = ps;
            this.dlMyWord.DataKeyField = "messageNo";
            this.dlMyWord.DataBind();
        }

        protected void lnkbtnTop_Click(object sender, EventArgs e)
        {
            this.labNowPage.Text = "1";
            this.dlBind();
        }
        protected void lnkbtnPrve_Click(object sender, EventArgs e)
        {
            this.labNowPage.Text = Convert.ToString(Convert.ToInt32(this.labNowPage.Text) - 1);
            this.dlBind();
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labNowPage.Text = Convert.ToString(Convert.ToInt32(this.labNowPage.Text) + 1);
            this.dlBind();
        }
        protected void lnkbtnLast_Click(object sender, EventArgs e)
        {
            this.labNowPage.Text = this.labCount.Text;
            this.dlBind();
        }

        protected void dlMyWord_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            msg.Delete(this.dlMyWord.DataKeys[e.Item.ItemIndex].ToString());
            Page.Response.Redirect("MyWord.aspx");

        }
    }
}