<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="goodsList.aspx.cs" Inherits="BookShop.Web.BuyPage.goodsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style=" font-size: 9pt; font-family: 宋体; width:574px; height :806px; background-repeat :no-repeat; background-image: url(images/显示页面当前位置.jpg);">
        <tr>
            <td align="left"  style ="width :574px; height :27px;">
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="labTitle" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" style ="width:574px;height :763px;" valign="top" >
               <asp:DataList ID="dLGoodsList" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemCommand="dLGoodsList_ItemCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Both">
                    <ItemTemplate>
                         <table style=" height: 120px">
                            <tr>
                                <td rowspan="4" style="width: 29px">
                                 <asp:Image ID="imageRefine" runat="server"  ImageUrl ="../Images/ftp/9221944.jpg"/>
                                </td>
                                <td colspan="2">
                                <asp:LinkButton ID="lnkbtnRName" runat="server" CommandName="detailSee"  Font-Underline=false  CommandArgument =<%#DataBinder.Eval(Container.DataItem, "ISBN")%>>
                                <%#DataBinder.Eval(Container.DataItem, "bookTitle")%>
                                </asp:LinkButton>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    市场价：</td>
                                <td>
                                 <%#GetVarMKP(DataBinder.Eval(Container.DataItem, "Price").ToString())%>￥
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    热卖价：</td>
                                <td>
                                  <%#GetVarHot(DataBinder.Eval(Container.DataItem, "salePrice").ToString())%>￥
                                </td>
                            </tr>
                             <tr>
                                <td colspan="2">
                                    <asp:ImageButton ID="imagebtnRefine" runat="server" CommandName="buy" CommandArgument ='<%# DataBinder.Eval(Container.DataItem, "ISBN") %>' ImageUrl="~/images/购买.jpg"  />
                                    </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                   <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                   <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                   <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                   <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                </asp:DataList> 
                <p align =right >
                <asp:Label ID="labCP" runat="server" Text="当前页码为："></asp:Label>
                                [
                                <asp:Label ID="labPage" runat="server" Text="1"></asp:Label>
                                &nbsp;]
                                <asp:Label ID="labTP" runat="server" Text="总页码为："></asp:Label>
                                [
                                <asp:Label ID="labBackPage" runat="server"></asp:Label>
                                &nbsp;]<asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="Red"
                                    OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton> &nbsp; &nbsp; </p>
                </td>
        </tr>
        
    </table>
</asp:Content>
