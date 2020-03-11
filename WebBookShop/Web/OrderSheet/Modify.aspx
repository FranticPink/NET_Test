<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="BookShop.Web.OrderSheet.Modify" Title="修改页" %>
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
		<asp:label id="lblorderNo" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memberNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmemberNo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		employeeNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtemployeeNo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		orderDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtorderDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		orderMoney
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtorderMoney" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		payWay
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpayWay" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		payFlag
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpayFlag" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		orderState
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtorderState" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		invoiceUnit
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtinvoiceUnit" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		receiver
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtreceiver" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		zipCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtzipCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		shipAddress
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtshipAddress" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		shipTel
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtshipTel" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

