<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="BookShop.Web.Manage.Manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理会员</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div style="background-image: url()">
     <table class="tableBorder" cellSpacing="0" cellPadding="0" width="650" align="center" border="0">
				<tr>
					<th class="tableHeaderText" height="25" align="left">
                        管理会员</th>
					
				<tr>
				</tr>
			</table>
			<table class="tableBorder" cellSpacing="0" cellPadding="0" width="650" align="center" border="0">
				<tr>
					<td height="23" >
<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
                        <table cellpadding="2" cellspacing="1" class="border" style="width: 100%;">
                            <tr>
                                <td align="right" class="tdbg" style="width: 80px">
                                    <b>关键字：</b>
                                </td>
                                <td class="tdbg">
                                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
                                </td>
                                <td class="tdbg">
                                </td>
                            </tr>
                        </table>
            <!--Search end-->
                        <br />
                        <asp:GridView ID="gridView" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="false" BorderWidth="1px" CellPadding="3" 
                            DataKeyNames="memberNo" OnPageIndexChanging="gridView_PageIndexChanging" 
                            OnRowCreated="gridView_OnRowCreated" OnRowDataBound="gridView_RowDataBound" 
                            PageSize="10" RowStyle-HorizontalAlign="Center" Width="100%">
                            <Columns>
                                <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="DeleteThis" runat="server" onclick="javascript:CCA(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="memberNo" HeaderText="memberNo" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="memberNo" />
                                <asp:BoundField DataField="memPassword" HeaderText="memPassword" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="memPassword" />
                                <asp:BoundField DataField="memName" HeaderText="memName" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="memName" />
                                <asp:BoundField DataField="sex" HeaderText="sex" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="sex" />
                                <asp:BoundField DataField="birthday" HeaderText="birthday" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="birthday" />
                                <asp:BoundField DataField="telephone" HeaderText="telephone" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="telephone" />
                                <asp:BoundField DataField="email" HeaderText="email" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="email" />
                                <asp:BoundField DataField="address" HeaderText="address" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="address" />
                                <asp:BoundField DataField="zipCode" HeaderText="zipCode" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="zipCode" />
                                <asp:BoundField DataField="totalAmount" HeaderText="totalAmount" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="totalAmount" />
                                <asp:BoundField DataField="memLevel" HeaderText="memLevel" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="memLevel" />
                                <asp:BoundField DataField="discount" HeaderText="discount" 
                                    ItemStyle-HorizontalAlign="Center" SortExpression="discount" />
                               
                                <asp:TemplateField ControlStyle-Width="50" HeaderText="删除" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="Delete" Text="删除"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                            <tr>
                                <td style="width: 1px;">
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除" />
                                </td>
                            </tr>
                        </table>
					</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
