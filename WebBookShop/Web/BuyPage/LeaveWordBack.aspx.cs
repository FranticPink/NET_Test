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
    public partial class LeaveWordBack : System.Web.UI.Page
    {
        BLL.Message Bmessage = new BLL.Message();
        Model.Message Mmessage = new Model.Message();
        public string ShowSubject, ShowTime, ShowContent;
        CommonClass ccObj = new CommonClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["ID"].ToString();
                DataTable dsTable = Bmessage.GetList("MESSAGEnO="+id).Tables[0];
                if (dsTable.Rows.Count > 0)
                {
                    this.txtSubject.Text = dsTable.Rows[0]["Subject"].ToString();
                }
                /*判断是否登录*/
                ST_check_Login();
            }


        }
        public void ST_check_Login()
        {

            if ((Session["Username"] == null))
            {
                Response.Write("<script>alert('对不起！您还不是会员，请先注册再登录！');location='Default.aspx'</script>");
                Response.End();
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            Mmessage.messageContent = this.FreeTextBox1.Text;
            Mmessage.messageNo = Request["ID"].ToString();
            Mmessage.releaseDate = DateTime.Now;
            Mmessage.memberNo = this.txtUid.Text;
            Bmessage.Add(Mmessage);
            string strUrl = "LeaveWordView.aspx?ID=" + Request["ID"];
            Response.Redirect(strUrl);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtUid.Text = "";
            this.FreeTextBox1.Text = "";
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}