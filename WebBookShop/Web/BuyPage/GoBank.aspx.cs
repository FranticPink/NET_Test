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
using System.Runtime.InteropServices;
using BookShop.BLL;

namespace BookShop.Web.BuyPage
{
    public partial class GoBank : System.Web.UI.Page
    {
        BLL.OrderSheet OrderSh = new OrderSheet();

        public static BankPay bankpay = new BankPay();//实例化类对象
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bankpay = GetPayInfo();
                /*判断是否登录*/
                ST_check_Login();
            }
        }
        public void ST_check_Login()
        {

            if ((Session["UserName"] == null))
            {
                Response.Write("<script>alert('对不起！您还不是会员，请先注册再登录！');location='Default.aspx'</script>");
                Response.End();
            }
        }

        #region  初始化BankPay类
        public BankPay GetPayInfo()
        {
            string OrderID = Page.Request["OrderID"].Trim();
            //从订单信息表中获取订单编号、订单金额
            DataTable dsTable = OrderSh.GetList("orderNo="+OrderID).Tables[0];
            bankpay.Orderid = Request["OrderID"].Trim();                                                  //订单编号
            bankpay.Amount = Convert.ToString(decimal.Parse(dsTable.Rows[0]["orderMoney"].ToString()) * 100); //订单金额
            bankpay.OrderDate = DateTime.Now.ToString("yyyyMMddhhmmss");                                  //交易日期时间
            bankpay.Path1 = Server.MapPath(@"bank\user.crt");//公钥路径
            bankpay.Path2 = Server.MapPath(@"bank\user.crt");//拆分pfx后缀的证商品后的公钥路径
            bankpay.Path3 = Server.MapPath(@"bank\user.key");//拆分pfx后缀的证商品后的私钥路径
            //下面是需要加密的明文字符串
            bankpay.Msg = bankpay.InterfaceName + bankpay.InterfaceVersion + bankpay.MerID + bankpay.MerAcct + bankpay.MerURL + bankpay.NotifyType + bankpay.Orderid + bankpay.Amount + bankpay.CurType + bankpay.ResultType + bankpay.OrderDate + bankpay.VerifyJoinFlag;
            /*
            ICBCEBANKUTILLib.B2CUtil obj=new ICBCEBANKUTILLib.B2CUtil() ;//项目中引用组件，以声明的方式创建com组件
            if (obj.init(bankpay.Path1, bankpay.Path2, bankpay.Path3, bankpay.Key) == 0)//加载公钥、私钥、密码，如果返回0则初始化成功
            {
                bankpay.MerSignMsg = obj.signC(bankpay.Msg, bankpay.Msg.Length);//加密明文
                bankpay.MerCert = obj.getCert(1);//提取证商品           
            }
            else
            {
                Response.Write(obj.getRC());//返回签名失败信息
            }*/
            return (bankpay);
        }
        #endregion
    }
}