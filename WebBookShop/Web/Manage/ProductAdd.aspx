<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="BookShop.Web.Manage.ProductAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加商品</title>
</head>
<body  style="font-family :宋体; font-size: 9pt;">
<form id="Form1" method="post" runat="server">
			    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ISBN
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtISBN" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		bookTitle
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtbookTitle" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		author
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtauthor" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		publishDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtpublishDate" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		version
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtversion" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		stockNumber
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtstockNumber" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		price
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtprice" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		salePrice
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtsalePrice" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		introduction
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtintroduction" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		catalog
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcatalog" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		categoryId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcategoryId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		pressNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpressNo" runat="server" Width="200px"></asp:TextBox>
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
			
		</form>
	</body>
</html>
