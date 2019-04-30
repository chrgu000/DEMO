<%@ page language="C#" autoeventwireup="true" inherits="Login_Login, App_Web_ygac8sr9" stylesheettheme="Css" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="text-align:center;margin-left:auto;margin-right:auto;border-collapse:collapse;margin:15px 15px 15px 15px;width:100%">
            <tr>
                <td class="tdtitle" style="text-align:center;height: 20px;">
                    账号&nbsp; &nbsp;<asp:TextBox ID="LogName" runat="server" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tdtitle" style="text-align:center;height: 20px;">
                    密码&nbsp; &nbsp;<asp:TextBox ID="LogPwd" TextMode="Password" runat="server" MaxLength="50" /></td>
            </tr>
            <tr>
                <td colspan="2" class="divbutton">
                    <asp:Button ID="登陆" runat="server" Text="登陆" CssClass="button" OnClick="Button1_Click"/></td>
            </tr>
        </table>
    </form>
</body>
</html>