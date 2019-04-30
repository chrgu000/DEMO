<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LookUpData_Update.aspx.cs"
    Inherits="System_LookUpData_Update" MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="container" style="width: 100%;" id="div1" runat="server">
        <div class="panel  panel-primary">
            <asp:HiddenField ID="hidid" runat="server" />
            <FormatControls:Button ID="YxBtn" runat="server" OnToBeck="ToBeck" OnToDel="ToDel"
                OnToSave="ToSave" OnToNew="ToNew" OnToSelect="ToSelect" />
            <table style="width:1000px;margin-left:auto;margin-right:auto" id="TableUpdate1"  runat="server">
                <tr>
                    <td class="tdlbl" width="30%">
                        <asp:Label ID="Label1" runat="server">*序号</asp:Label>
                    </td>
                    <td class="tdinput" width="45%" colspan="3">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hidiType" runat="server" />
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
                        <asp:Label ID="Label4" runat="server">是否关闭</asp:Label>
                    </td>
                    <td class="tdinput">
                        <asp:CheckBox ID="CheckBox4" runat="server" Checked="false"></asp:CheckBox>
                    </td>
                    <td class="tdlbl">
                        <asp:Label ID="Label5" runat="server">是否系统</asp:Label>
                    </td>
                    <td class="tdinput">
                        <asp:CheckBox ID="CheckBox5" runat="server" Checked="false"></asp:CheckBox>
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
            var TextBox1 = document.getElementById("TextBox1");
            if (TextBox1.value == "") {
                alert(document.getElementById("Label1").innerHTML + "不可为空");
                TextBox1.focus();
                return false;
            }
            var TextBox2 = document.getElementById("TextBox2");
            if (TextBox2.value == "") {
                alert(document.getElementById("Label2").innerHTML + "不可为空");
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

        function doNew() {
        }
    </script>

</asp:Content>
