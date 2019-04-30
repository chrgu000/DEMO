<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="PMMWS.Test" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width =1024>
         <tr>
           <td>
        <strong>手动发送Email：</strong></td>
            <tr>
           <td>
               密码：<dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Password="True" 
                Width="100px">
            </dx:ASPxTextBox>
             
        <dx:ASPxButton ID="ASPxButton4" runat="server" Text="确定 " 
            onclick="ASPxButton4_Click" AutoPostBack="False" Width="155px">
        </dx:ASPxButton>
            </td>
            <tr>
           <td>
               &nbsp;</td>
            <tr>
           <td>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="发送计划维护提醒" 
            onclick="ASPxButton1_Click" AutoPostBack="False" Width="155px" Visible="False">
        </dx:ASPxButton>
               <asp:Button ID="Button1" runat="server" onclick="ASPxButton1_Click" Text="计划提醒" 
                   Visible="False" />
            </td>
            <tr>
           <td>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="发送备件库存提醒" 
            onclick="ASPxButton2_Click" AutoPostBack="False" Width="155px" Visible="False">
        </dx:ASPxButton>
               <asp:Button ID="Button2" runat="server" onclick="ASPxButton2_Click" Text="备件提醒" 
                   Visible="False" />
            </td>
            <tr>
           <td>
        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="发送设备外检提醒" 
            onclick="ASPxButton3_Click" AutoPostBack="False" Width="155px" Visible="False">
        </dx:ASPxButton>
               <asp:Button ID="Button3" runat="server" onclick="ASPxButton3_Click" Text="外检提醒" 
                   Visible="False" />
            </td>
            </table>
    </form>
</body>
</html>
