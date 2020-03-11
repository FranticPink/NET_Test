using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;
using System.Data;
namespace BookShop.Web.BuyPage
{
    public partial class Register : System.Web.UI.Page
    {
        CommonClass ccObj = new CommonClass();
        UserClass ucObj = new UserClass();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Member Mmember = new Model.Member();
            BLL.Member Bmember=new BLL.Member ();

            Mmember.memberNo = Bmember.CreateNo();
            Mmember.memPassword = txtPassword.Text.Trim();
            Mmember.memName = txtName.Text.Trim();
            Mmember.sex = transfer(this.ddlSex.SelectedItem.Text);
            Mmember.birthday = DateTime.Now;
            Mmember.telephone = txtPhone.Text.Trim();
            Mmember.email= txtEmail.Text.Trim();
            Mmember.address= txtAddress.Text.Trim();
            Mmember.zipCode=txtPostCode.Text.Trim();
            Mmember.totalAmount=0;
            Mmember.memLevel="1";
            Mmember.discount=0;
            //判断是否输入必要的信息
            if (this.txtPostCode.Text.Trim() == "" && this.txtPhone.Text.Trim() == "" && this.txtEmail.Text.Trim() == "")
            {
                Response.Write(ccObj.MessageBoxPage("请输入必要的信息！"));
            }
            else
            {
                bool flag = Bmember.Add(Mmember);
            if (flag)
                {
                    Response.Write(ccObj.MessageBox("恭喜您，注册成功！"+"会员账号为："+Mmember.memberNo+"  密码为："+Mmember.memPassword, "Default.aspx"));
                }
                else
                {
                    Response.Write(ccObj.MessageBox("注册失败，该名字已存在！"));

                }

            }

        }
        /// <summary>
        ///  将性别转化为Bool值
        /// </summary>
        /// <param name="strValue">需要转化的性别值</param>
        /// <returns>返回转化后的性别值</returns>
        protected  string transfer(string strValue)
        {
            if (strValue == "男")
            {
                return "M";
            }
            else
            {
                return "F";

            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";     //用户名
            this.txtPassword.Text = ""; //用户密码
            this.txtTrueName.Text = ""; //用户真实姓名
            this.txtPhone.Text = "";    //用户电话号码
            this.txtPostCode.Text = ""; //邮政编码
            this.txtEmail.Text = "";    //Email
            this.txtAddress.Text = "";  //详细地址
        }
    }
}