<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="BookShop.Web.Message.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		messageNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmessageNo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		employeeNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblemployeeNo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memberNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmemberNo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		releaseDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblreleaseDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		messageContent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmessageContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		replyContent
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblreplyContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		replyDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblreplyDate" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




