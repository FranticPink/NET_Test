<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="BookShop.Web.Manage.Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品管理</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div style="background-image: url()">
            <table cellSpacing="0" cellPadding="0" width="640" align="center" border="0" style ="font-family :宋体; font-size :9pt;">
				<tr>
					<td style="font-family :宋体; font-size :9pt; height: 25px;" align="left">
						&nbsp;&nbsp; 商品管理</td>
					
				<tr>
				<tr>
				<td>
				 <table cellSpacing="0" cellPadding="0" width="640" align="center" border="0">
			 <tr>
					
					<td align="center" style ="font-family :宋体; font-size :9pt;">
              请输入关键字：&nbsp;
						 <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>&nbsp;
						<asp:Button id="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click"></asp:Button>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
				</tr>
          
            <tr>
                <td style ="font-family :宋体; font-size :9pt;" >
                    <br />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
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
