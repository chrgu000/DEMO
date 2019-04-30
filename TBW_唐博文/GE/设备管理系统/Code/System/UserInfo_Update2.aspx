<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo_Update2.aspx.cs"
    Inherits="System_UserInfo_Update2" MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="container" style="width: 100%;" id="div1" runat="server">
        <div class="panel  panel-primary">
            <asp:HiddenField ID="hidid" runat="server" />
            <FormatControls:Button ID="YxBtn" runat="server" OnToBeck="ToBeck" OnToSave="ToSave"
                OnToDel="ToDel" />
            <table style="width:1000px;margin-left:auto;margin-right:auto" id="TableUpdate1"  runat="server">
                <tr>
                    <td class="tdlbl" width="20%">
                        <asp:Label ID="Label1" runat="server">*账号</asp:Label>
                    </td>
                    <td class="tdinput" width="30%">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdlbl" width="20%">
                        <asp:Label ID="Label2" runat="server">*姓名</asp:Label>
                    </td>
                    <td class="tdinput" width="30%">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdlbl">
                        <asp:Label ID="Label3" runat="server">*密码</asp:Label>
                    </td>
                    <td class="tdinput">
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="tdlbl">
                        <asp:Label ID="Label4" runat="server">*重复密码</asp:Label>
                    </td>
                    <td class="tdinput">
                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdlbl">
                        <asp:Label ID="Label5" runat="server">启用日期</asp:Label>
                    </td>
                    <td class="tdinput">
                        <FormatControls:Calendar ID="Calendar1" runat="server" />
                    </td>
                    <td class="tdlbl">
                        <asp:Label ID="Label6" runat="server">到期日期</asp:Label>
                    </td>
                    <td class="tdinput">
                        <FormatControls:Calendar ID="Calendar2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="tdlbl">
                        <asp:Label ID="Label7" runat="server">备注</asp:Label>
                    </td>
                    <td class="tdinput" colspan="3">
                        <asp:TextBox ID="TextBox7" runat="server" Width="98%" Rows="5" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
var i = 0;
function doSave() {
    var idleft = "_ctl0_CenterContent_";
    var TextBox1 = document.getElementById(idleft + "TextBox1");
    if (TextBox1.value == "") {
        alert(document.getElementById(idleft + "Label1").innerHTML + "不可为空");
        TextBox1.focus();
        return false;
    }
    var TextBox2 = document.getElementById(idleft + "TextBox2");
    if (TextBox2.value == "") {
        alert(document.getElementById(idleft + "Label2").innerHTML + "不可为空");
        TextBox2.focus();
        return false;
    }
    var TextBox3 = document.getElementById(idleft + "TextBox3");
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
    var TextBox4 = document.getElementById(idleft + "TextBox4");
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

function DeleTable(i, obj) {
    if (confirm('确认删除吗？')) {
        return true;
    }
    else {
        return false;
    }
}
    </script>

</asp:Content>
