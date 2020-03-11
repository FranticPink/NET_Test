using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
namespace BookShop.Web.BuyPage
{
    public partial class feedback : System.Web.UI.Page
    {
        BLL.Message msg = new BLL.Message();
        Model.Message Mmsg = new Model.Message();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Write("<script>alert('对不起！您不是会员，请先注册！');location='Default.aspx'</script>");
                    Response.End();

                }
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Mmsg.messageNo = msg.CreateNo();
                Mmsg.employeeNo = "";
                Mmsg.memberNo = Session["UserID"].ToString();
                Mmsg.releaseDate=DateTime.Now;
                Mmsg.messageContent=this.FreeTextBox1.Text.ToString();
                Mmsg.replyContent="";
                Mmsg.replyDate=DateTime.Now;
                msg.Add(Mmsg);
               string str = "<script language=javascript>alert('添加成功');location='Default.aspx';</script>";
               Response.Write(str);
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.txtTitle.Text = "";
            this.FreeTextBox1.Text = "";
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}