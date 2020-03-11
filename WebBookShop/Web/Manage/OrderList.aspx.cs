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
    public partial class OrderList : System.Web.UI.Page
    {
        BookShop.BLL.OrderSheet bOrdersh = new BookShop.BLL.OrderSheet();
        BookShop.BLL.Employee bemployee = new BLL.Employee();
        CommonClass ccObj = new CommonClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*判断是否登录*/
                ST_check_Login();
                //判断是否已点击“搜索”按钮
                ViewState["search"] = null;
                pageBind(); //绑定订单信息
            }
        }
        public void ST_check_Login()
        {

            if ((Session["AName"] == null))
            {
                Response.Write("<script>alert('对不起！您不是管理员，无权限浏览此页！');location='../Default.aspx'</script>");
                Response.End();
            }
        }
        //绑定货品总额
        public string GetVarGF(string strGoodsFee)
        {
            return ccObj.VarStr(strGoodsFee, 2);
        }
        //绑定运费
        public string GetVarSF(string strShipFee)
        {
            return ccObj.VarStr(strShipFee, 2);
        }
        //绑定总金额
        public string GetVarTP(string strTotalPrice)
        {
            return ccObj.VarStr(strTotalPrice, 2);
        }
        public string GetStatus(string IntOrderID)
        {
            DataSet ds= bOrdersh.GetList("orderNo=" + IntOrderID.ToString());
            string str=ds.Tables[0].Rows[0]["orderState"].ToString();
            string manange = "";
            switch (int.Parse(str))
            { 
                case 0:
                    manange = "未确认|未发货<Br>未归档";
                    break;
                case 1:
                    manange = "已确认|未发货<Br>未归档";
                    break;
                case 2:
                    manange = "已确认|已发货<Br>未归档";
                    break;
                case 3:
                    manange = "已确认|已发货<Br>已归档";
                    break;
                default:
                    manange = "未确认|未发货<Br>未归档";
                    break;
            }



            return manange;
        }
        public string GetAdminName(string IntOrderID)
        {
           DataSet ds= bOrdersh.GetList("orderNo=" + IntOrderID.ToString());
           string AdminId = ds.Tables[0].Rows[0]["employeeNo"].ToString();
           DataSet dsN= bemployee.GetList("employeeNo="+AdminId);
           string strAdminName = dsN.Tables[0].Rows[0]["empName"].ToString();
            if (strAdminName == "")
            {
                return "无";
            }
            else
            {
                return strAdminName;
            }
        }
        /// <summary>
        /// 获取指定订单的信息
        /// </summary>
        string strSql;
        public void pageBind()
        {
            string state = "";
            //获取Request["OrderList"]对象的值，确定查询条件

            string strOL = "00";//Request["OrderList"].Trim();
            switch (strOL)
            {
                case "00"://表示未确定
                    state="0";
                    break;
                case "01"://表示已确定
                    state="1";
                    break;
                case "10": //表示未发货
                    state="1";
                    break;
                case "11"://表示已发货
                    state="2";
                    break;
                case "20": //表示收货人未验收货物
                    state="2";
                    break;
                case "21": //表示收货人已验收货物
                    state="3";
                    break;
                default:
                    break;
            }
            state = "0";
            //获取查询信息，并将其绑定到GridView控件中
            DataTable dsTable =bOrdersh.GetList("orderState="+state).Tables[0];
            
            string s = dsTable.Rows[0][0].ToString();
            this.gvOrderList.DataSource = dsTable.DefaultView;
            this.gvOrderList.DataKeyNames = new string[] { "orderNo" };
            this.gvOrderList.DataBind();
        }
        /// <summary>
        /// 获取符合条件的订单信息
        /// </summary>
        public void gvSearchBind()
        {
           
        }

        protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrderList.PageIndex = e.NewPageIndex;
            if (ViewState["search"] == null)
            {
                pageBind();//绑定所有订单信息
            }
            else
            {
                gvSearchBind();//绑定查询后的订单信息

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //将ViewState["search"]对象值1
            ViewState["search"] = 1;
            gvSearchBind();//绑定查询后的订单信息
        }
        protected void gvOrderList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string s = bOrdersh.GetList("orderNo=" + gvOrderList.DataKeys[e.RowIndex].Value.ToString()).Tables[0].Rows[0]["orderState"].ToString();
            //判断该订单是否已被确认或归档，如果已被确认但未归档，不能删除该订单
            if (int.Parse(s)<4)
            {
                bOrdersh.Delete(gvOrderList.DataKeys[e.RowIndex].Value.ToString());
            }
            else
            {
                Response.Write(ccObj.MessageBox("该订单还未归档，无法删除！"));
                return;
            }
            //重新绑定
            if (ViewState["search"] == null)
            {
                pageBind();
            }
            else
            {
                gvSearchBind();

            }
        }
        public string TransmitNo(string str)
        {
            Response.Redirect("OrderModify.aspx?OrderID=" + str);
            return str;
        }

        protected void btnManage_Click(object sender, EventArgs e)
        {
            
            Session["OrderID"] = (sender as Button).Text.ToString();
            Response.Redirect("OrderModify.aspx");
        }
    }
}