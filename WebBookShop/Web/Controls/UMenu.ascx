<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UMenu.ascx.cs" Inherits="BookShop.Web.UserControl.UMenu" %>
<table style="width :778px; height :89px;　font-size: 9pt; font-family: 宋体; vertical-align :top; background-image: url(../images/banner.jpg); background-repeat:no-repeat "  border="0" cellpadding="0" cellspacing="0">
    <tr valign =top >
    <td  align =left style="width: 778px; height: 51px; "  valign =top><br />
     <p align="right">
     <a href="mailto:www.bcty365.com" style=" color:Black; font-size: 9pt; font-family: 宋体;  text-decoration :none;">
         <span style="color: #ffffff; background-color: darkred">联系客服</span></a><span style="color: #ffffff;
             background-color: darkred"> |</span><a href="#" style=" color:Black; font-size: 9pt; font-family: 宋体;  text-decoration :none;" onclick ="this.style.behavior='url(#default#homepage)';this.sethomepage('hppt://www.bc110.com')"><span
                     style="color: #ffffff; background-color: darkred">设置主页</span></a><span style="color: #ffcc99;
                         background-color: darkred"> |</span><a href="#" onclick="window.external.addFavorite('http://www.mrbccd.com','XXX科技有限公司');"><font color="white" style=" color:Black; font-size: 9pt; font-family: 宋体;  text-decoration :none;"><span
                             style="color: #ffffff; background-color: darkred">收藏本站</span></font></a>&nbsp;&nbsp;
        </p>
    <P align=right>
    <a href="~/BuyPage/shopCart.aspx" style=" color:Black; font-size: 9pt; font-family: 宋体;  text-decoration :none;"></a>&nbsp;&nbsp;&nbsp;
    </p>
</td> 
     </tr> 
     <tr valign="top">
         <td id="Td1" align="center" style="width: 778px; height: 7px" valign="top" runat="server" class="Navigate">
             <asp:Label ID="labDate" runat="server" Text="Label" Height="7px" Width ="100"  Font-Size="3pt"></asp:Label>|
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/BuyPage/Default.aspx" Font-Underline="False" Height="7px" >首页</asp:HyperLink>|
             <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/BuyPage/goodsList.aspx?id=2&&var=1" Font-Underline="False" Height="7px">推荐图书</asp:HyperLink>|
             <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/BuyPage/goodsList.aspx?id=3&&var=1" Font-Underline="False" Height="7px">最新图书</asp:HyperLink>|
             <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/BuyPage/goodsList.aspx?id=4&&var=1" Font-Underline="False" Height="7px">热门图书</asp:HyperLink>|
             <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/BuyPage/shopCart.aspx" Height="7px" Font-Overline="False">购物车</asp:HyperLink>|
             <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/BuyPage/buyFlow.aspx" Height="7px" Font-Overline="False">购物流程</asp:HyperLink>|
             <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/BuyPage/feedback.aspx" Height="7px" Font-Overline="False">网站留言</asp:HyperLink>|
             <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/BuyPage/MyWord.aspx" Height="7px" Font-Overline="False">我的留言</asp:HyperLink>|
             <asp:LinkButton ID="lnkbtnOut" runat="server" Font-Underline=false ForeColor =black OnClick="lnkbtnOut_Click" CausesValidation="False" Height="7px" >退出登录</asp:LinkButton>
             </td>
     </tr>
          <tr valign="bottom">
          <td id="Td2" align="center" style="width: 778px; height: 20px" valign="top" runat="server" class="Navigate">
           </td>
          </tr>
     </table>
<table style="background-image: url(../Images/index1_11.gif); width :766px; height :109px">
     <tr>

        <td style="width: 100px">
        </td>
    </tr>
</table>