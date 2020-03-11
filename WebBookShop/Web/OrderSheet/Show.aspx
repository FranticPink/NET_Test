<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="BookShop.Web.OrderSheet.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		orderNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorderNo" runat="server"></asp:Label>
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
		employeeNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblemployeeNo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		orderDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorderDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		orderMoney
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorderMoney" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		payWay
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpayWay" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		payFlag
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpayFlag" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		orderState
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorderState" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		invoiceUnit
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblinvoiceUnit" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		receiver
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblreceiver" runat="server"></asp:Label>
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
		shipAddress
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblshipAddress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		shipTel
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblshipTel" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




