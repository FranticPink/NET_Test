using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BookShop.BLL;
using BookShop.Model;
/// <summary>
/// UserClass 的摘要说明
/// </summary>
public class UserClass
{
    BookShop.BLL.Member member = new BookShop.BLL.Member();
    BookShop.Model.Member Model = new BookShop.Model.Member();
	public UserClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    //***************************************登录界面************************************************************
    /// <summary>
    /// 判断用户是否能登录
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPwd">用户密码</param>
    /// <returns>返回数据源的数据表</returns>
    public DataTable UserLogin(string strName,string strPwd)
    {
        DataSet ds=member.GetList("memberNo=" + strName + "AND " + "memPassword="+strPwd);
        DataTable dt = ds.Tables[0];
        return dt;
    }
    //***************************************注册界面************************************************************
    /// <summary>
    /// 向用户表中插入信息
    /// </summary>
    /// <param name="strName">会员名</param>
    /// <param name="strPassword">密码</param>
    /// <param name="strRealName">真实姓名</param>
    /// <param name="blSex">性别</param>
    /// <param name="strPhonecode">电话号码</param>
    /// <param name="strEmail">E_Mail</param>
    /// <param name="strAddress">会员详细地址</param>
    /// <param name="strPostCode">邮编</param>
    /// <returns>返回用户ID代号</returns>
    public string  AddUser(string strName, string strPassword, string strRealName, bool blSex, string strPhonecode, string strEmail, string strAddress, string strPostCode)
    {
        Model.memberNo = member.CreateNo();
        Model.memName = strName;
        Model.memPassword = strPassword;
        Model.sex = blSex ? "M" : "F";
        Model.birthday = DateTime.Now;
        Model.telephone = strPhonecode;
        Model.email = strEmail;
        Model.zipCode = strPostCode;
        Model.address = strAddress;
        Model.totalAmount = 0;
        Model.memLevel = "1";
        Model.discount = 0;
        bool flag=member.Add(Model);
        return Model.memberNo;
    }
  
    //***************************************修改界面************************************************************
    /// <summary>
    /// 通过用户ID，获取用户的详细信息
    /// </summary>
    /// <param name="IntMemberID">用户ID代号</param>
    /// <returns>返回数据集的表的集合</returns>
    public DataTable GetUserInfo(int IntMemberID)
    {
        DataSet ds = member.GetList("memberNo=" + IntMemberID.ToString());
        DataTable dt = ds.Tables[0];
        return dt;
    }
    /// <summary>
    /// 修改用户表的信息
    /// </summary>
    /// <param name="strName">会员名</param>
    /// <param name="strPassword">密码</param>
    /// <param name="strRealName">真实姓名</param>
    /// <param name="blSex">性别</param>
    /// <param name="strPhonecode">电话号码</param>
    /// <param name="strEmail">E_Mail</param>
    /// <param name="strAddress">会员详细地址</param>
    /// <param name="strPostCode">邮编</param>
    /// <param name="IntMemberID">用户的ID代号</param>
    public void MedifyUser(string strMemberNo, string strPassword, string strName, bool blSex, string strPhonecode, string strEmail, string strAddress, string strPostCode)
    {
        Model.memberNo = strMemberNo;
        Model.memName = strName;
        Model.memPassword = strPassword;
        Model.sex = blSex ? "M" : "F";
        Model.birthday = DateTime.Now;
        Model.telephone = strPhonecode;
        Model.email = strEmail;
        Model.zipCode = strPostCode;
        Model.address = strAddress;
        Model.totalAmount = 0;
        Model.memLevel = "1";
        Model.discount = 0;
        member.Update(Model);
    }

}
