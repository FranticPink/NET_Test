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
    public partial class Login : System.Web.UI.Page
    {
        BLL.Employee employee = new Employee();
        //创建公共类CommonClass一个新实例对象
        CommonClass ccObj = new CommonClass();
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//判断页面是否是第一次加载
            {
                this.labCode.Text = ccObj.RandomNum(4);//产生验证码
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //判断用户是否已输入了必要的信息
            if (this.txtAdminName.Text.Trim() == "" || this.txtAdminPwd.Text.Trim() == "")
            {
                //调用公共类CommonClass中的MessageBox方法
                Response.Write(ccObj.MessageBox("登录名和密码不能为空！"));
            }
            else
            {
                //判断用户输入的验证码是否正确
                if (txtAdminCode.Text.Trim().ToLower() == labCode.Text.Trim().ToLower())
                {
                    //定义一个字符串，获取用户信息

                    DataTable dsTable = employee.GetList("employeeNo=" + this.txtAdminName.Text.Trim() + "AND " + "empPassword=" + this.txtAdminPwd.Text.Trim()).Tables[0];
    ;
                    //判断用户是否存在
                    if (dsTable.Rows.Count > 0)
                    {
                        Session["AID"] = Convert.ToInt32(dsTable.Rows[0]["employeeNo"].ToString());//保存用户ID
                        Session["AName"] = dsTable.Rows[0]["empPassword"].ToString();//保存用户名
                        Response.Write("<script language=javascript>window.open('AdminIndex.aspx');window.close();</script>");
                    }
                    else
                    {
                        Response.Write(ccObj.MessageBox("您输入的用户名或密码错误，请重新输入！"));
                    }
                }
                else
                {
                    Response.Write(ccObj.MessageBox("验证码输入有误，请重新输入！"));
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();location='javascript:history.go(-1)';</script>");
        }
    }
}