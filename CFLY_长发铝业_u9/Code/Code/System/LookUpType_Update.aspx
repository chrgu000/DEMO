<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LookUpType_Update.aspx.cs"
    Inherits="System_LookUpType_Update" MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="container" style="width: 100%;" id="div1" runat="server">
        <div class="panel  panel-primary">
            <asp:HiddenField ID="hidid" runat="server" />
            <FormatControls:Button ID="YxBtn" runat="server" OnToBeck="ToBeck" OnToDel="ToDel"
                OnToSave="ToSave" OnToNew="ToNew" OnToSelect="ToSelect" />
            <table class="TableUpdate" style="width: 1000px; margin-left: auto; margin-right: auto">
                <tr>
                    <td class="tdlbl" width="30%">
                        <asp:Label ID="Label1" runat="server">*序号</asp:Label>
                    </td>
                    <td class="tdinput" width="45%" colspan="3">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdlbl">
                        <asp:Label ID="Label2" runat="server">*名称</asp:Label>
                    </td>
                    <td class="tdinput">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdlbl">
                        <asp:Label ID="Label3" runat="server">*英文名称</asp:Label>
                    </td>
                    <td class="tdinput">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
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
