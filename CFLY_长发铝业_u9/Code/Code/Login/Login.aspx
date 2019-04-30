<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCloudControl" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <script src="../js/jquery-1.9.1.min.js"></script>

</head>
<body style="background-color: #ced7e7; background:url(../img/destop-1.jpg) center;background-repeat: no-repeat; "><%--overflow-x: hidden; overflow-y: hidden--%>
    <form id="form1" runat="server" autocomplete="off">
    <table border="0" cellpadding="0" cellspacing="0" class="div1" style="padding-top: 15px;">
        <tr>
            <td rowspan="2" width="536" height="384" align="left" valign="top">
                <%--<img border="0" src="../img/1_00x00.bmp" width="536" height="384" />--%>
            </td>
            <td width="536" height="192" align="left" valign="top">
                <%--<img border="0" src="../img/2_00x00.bmp" width="536" height="192" />--%>
            </td>
        </tr>
        <tr>
            <td width="536" height="192" align="left" valign="top"><%--style="background-color: #ffffff" --%>
                <table border="0" cellpadding="0" cellspacing="0" 
                                <tr>
                                    <td align="right" style="height: 30px; ">
                                        <dx:ASPxLabel ID="UserNameLabel" runat="server" Text="用户名:">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="UserName" runat="server" Width="100px">
                                        </dx:ASPxTextBox>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 30px; ">
                                        <dx:ASPxLabel ID="PasswordLabel" runat="server" Text="密码:">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="Password" runat="server" Password="true" Width="100px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height: 30px; ">
                                        <dx:ASPxButton ID="LoginButton" runat="server" Text="登录" OnClick="LoginButton_Click">
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
            </td>
        </tr>
        <tr>
            <td width="536" height="384" align="left" valign="top">
              <%--  <img border="0" src="../img/1_01x00.bmp" width="536" height="384">--%>
            </td>
            <td width="536" height="384" align="left" valign="top">
                <%--<img border="0" src="../img/1_01x01.bmp" width="536" height="384">--%>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
