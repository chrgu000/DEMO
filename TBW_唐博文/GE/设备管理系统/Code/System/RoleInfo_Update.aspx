<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleInfo_Update.aspx.cs" Inherits="System_RoleInfo_Update" EnableEventValidation="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <asp:HiddenField ID="hidid" runat="server" />
    <FormatControls:Button ID="YxBtn" runat="server"  OnToBeck="ToBeck"  OnToDel="ToDel"  OnToSave ="ToSave" OnToNew="ToNew" OnToSelect="ToSelect" />
    <table class="TableUpdate">
        <tr><td class="tdtitle" colspan="2" >角色设置</td></tr>
        <tr>
            <td class="tdlbl" width="30%">
                <asp:Label ID="Label1" runat="server" >*角色编号</asp:Label>
            </td>
            <td class="tdinput" width="60%">
                <asp:TextBox ID="TextBox1"  runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdlbl" >
                <asp:Label ID="Label2" runat="server">*角色名称</asp:Label>
            </td>
            <td class="tdinput" >
                <asp:TextBox ID="TextBox2"  runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdlbl" >
                <asp:Label ID="Label5" runat="server">创建日期</asp:Label>
            </td>
            <td class="tdinput" >
                <FormatControls:Calendar ID="Calendar1"  runat="server" />
            </td>
        </tr>
         <tr>
            <td class="tdlbl" >
                <asp:Label ID="Label7" runat="server">备注</asp:Label>
            </td>
            <td class="tdinput" >
                <asp:TextBox ID="TextBox7"  runat="server" Width="98%" Rows="5" 
                    TextMode="MultiLine" ></asp:TextBox>
            </td>
        </tr>
    </table>
    
    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"  DataSourceID="ObjectDataSource1"  EnableEmptyContentRender="True">
        <Columns>
            <asp:TemplateField>
                <headertemplate>
                    选择
                </headertemplate>
                <itemtemplate>
                    <asp:CheckBox ID="chk" runat="server" Checked='<%# Convert.ToBoolean(Eval("bChoosed")) %>' />
                    <asp:HiddenField ID="hidid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"vchrUid") %>'/>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <%--<asp:TemplateField>
                <headertemplate>
                    <a onclick="return true;" href="javascript:__doPostBack('SmartGridView1','Sort$iID')">ID</a>
                </headertemplate>
                <itemtemplate>
                    <a href="Update.aspx?ID=<%# DataBinder.Eval(Container.DataItem,"iID") %>"><%# DataBinder.Eval(Container.DataItem, "iID")%></a>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>--%>
            <asp:BoundField DataField="vchrUid" HeaderText="用户编码" SortExpression="vchrUid" />
            <asp:BoundField DataField="vchrName" HeaderText="用户名称" SortExpression="vchrName" />
            <asp:BoundField DataField="vchrRemark" HeaderText="备注" SortExpression="vchrRemark" />
        </Columns>
    </FormatControls:SmartGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRoleUser" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>
    </form>
</body>
</html>
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
</script>