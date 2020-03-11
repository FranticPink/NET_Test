<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="BookShop.Web.Member.Add" Title="增加页" %>


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
		<asp:TextBox id="txtmemberNo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memPassword
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmemPassword" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmemName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		sex
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtsex" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		birthday
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtbirthday" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		telephone
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttelephone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		email
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtemail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		address
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtaddress" runat="server" Width="200px"></asp:TextBox>
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
		totalAmount
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttotalAmount" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		memLevel
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmemLevel" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		discount
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtdiscount" runat="server" Width="200px"></asp:TextBox>
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
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
