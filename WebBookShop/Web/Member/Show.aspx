<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="BookShop.Web.Member.Show" Title="显示页" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		memberNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmemberNo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memPassword
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmemPassword" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmemName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		sex
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		birthday
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblbirthday" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		telephone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltelephone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		email
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblemail" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		address
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbladdress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		zipCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblzipCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		totalAmount
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltotalAmount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memLevel
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmemLevel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		discount
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbldiscount" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




