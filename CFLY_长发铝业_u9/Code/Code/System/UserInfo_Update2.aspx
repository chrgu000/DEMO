<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo_Update2.aspx.cs"
    Inherits="System_UserInfo_Update2" MasterPageFile="~/Frame/MasterPage.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="container" style="width: 100%;" id="div1" runat="server">
        <div class="panel  panel-primary">
            <asp:HiddenField ID="hidid" runat="server" />
            <FormatControls:Button ID="YxBtn" runat="server" />
            <table style="width: 242px; margin-left: auto; margin-right: auto" id="TableUpdate1"
                runat="server">
                <tr>
                    <td class="tdlbl" style="width: 63px">
                        <dx:ASPxLabel ID="Label1" runat="server" Text="*账号">
                        </dx:ASPxLabel>
                    </td>
                    <td class="tdinput" width="400px">
                        <dx:ASPxTextBox ID="TextBox1" runat="server" ReadOnly="true">
                        </dx:ASPxTextBox>
                    </td>
                    </tr>
                <tr>
                    <td class="tdlbl" style="width: 63px">
                        <dx:ASPxLabel ID="Label2" runat="server" Text="*姓名">
                        </dx:ASPxLabel>
                    </td>
                    <td class="tdinput" width="400px">
                        <dx:ASPxTextBox ID="TextBox2" runat="server" ReadOnly="true">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdlbl" style="width: 63px">
                        <dx:ASPxLabel ID="Label3" runat="server" Text="*密码">
                        </dx:ASPxLabel>
                    </td>
                    <td class="tdinput">
                        <dx:ASPxTextBox ID="TextBox3" runat="server" Password="true">
                        </dx:ASPxTextBox>
                    </td>
                    </tr>
                <tr>
                    <td class="tdlbl" style="width: 63px">
                        <dx:ASPxLabel ID="Label4" runat="server" Text="*重复密码">
                        </dx:ASPxLabel>
                    </td>
                    <td class="tdinput">
                        <dx:ASPxTextBox ID="TextBox4" runat="server" Password="true">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
            </table>
            <div id="divinput" class="divbutton" style="text-align: center" runat="server">
                <asp:Button ID="confirm" Text="确定" OnClick="ToSave" OnClientClick="javascript:return doSave();"
                runat="server" CssClass="btn" ></asp:Button>
                <asp:Button ID="cal" Text="取消"  OnClientClick="javascript:return Anul();"
                runat="server" CssClass="btn" ></asp:Button>
            </div>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        var i = 0;
        function doSave() {
            var idleft = "_ctl0_CenterContent_";
            var TextBox1 = document.getElementById(idleft + "TextBox1" + "_I");
            if (TextBox1.value == "") {
                alert(document.getElementById(idleft + "Label1").innerHTML + "不可为空");
                TextBox1.focus();
                return false;
            }
            var TextBox2 = document.getElementById(idleft + "TextBox2" + "_I");
            if (TextBox2.value == "") {
                alert(document.getElementById(idleft + "Label2").innerHTML + "不可为空");
                TextBox2.focus();
                return false;
            }
            var TextBox3 = document.getElementById(idleft + "TextBox3" + "_I");
            if (TextBox3.value == "") {
                alert(document.getElementById(idleft + "Label3").innerHTML + "不可为空");
                TextBox3.focus();
                return false;
            }
            if (TextBox3.value == "123456") {
                alert(document.getElementById(idleft + "Label3").innerHTML + "不可为123456");
                TextBox3.focus();
                return false;
            }
            var TextBox4 = document.getElementById(idleft + "TextBox4" + "_I");
            if (TextBox4.value == "") {
                alert(document.getElementById(idleft + "Label4").innerHTML + "不可为空");
                TextBox4.focus();
                return false;
            }
            if (TextBox3.value != TextBox4.value) {
                alert("两次输入密码必须相同");
                TextBox3.focus();
                return false;
            }
            return true;
        }
        function Anul() {
            window.location.href = "../List.aspx";
        }
    </script>

</asp:Content>
