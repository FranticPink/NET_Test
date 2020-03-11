<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="BookShop.Web.Book.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ISBN
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblISBN" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		bookTitle
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblbookTitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		author
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblauthor" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		publishDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpublishDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		version
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblversion" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		stockNumber
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblstockNumber" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		price
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblprice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		salePrice
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsalePrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		introduction
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblintroduction" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		catalog
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcatalog" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		categoryId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcategoryId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		pressNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpressNo" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




