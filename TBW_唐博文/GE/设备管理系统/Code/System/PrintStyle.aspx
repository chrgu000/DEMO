<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintStyle.aspx.cs" Inherits="System_PrintStyle" EnableEventValidation="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript" src="../Script/PublicJScript.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <asp:HiddenField ID="hidid" runat="server" />
    <FormatControls:Button ID="YxBtn" runat="server" OnToSave="ToSave"  Title="打印设置" />
    <asp:Panel runat="server" id="divSel" Width="100%">
        Flag<asp:DropDownList ID="DropDownList1"  runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True"  ></asp:DropDownList>
    </asp:Panel>
    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"  AllowPaging="false"  EnableEmptyContentRender="True" >
        <Columns>
            <asp:BoundField DataField="iID" HeaderText="iID" SortExpression="iID" />
            <asp:BoundField DataField="Row" HeaderText="Row" SortExpression="Row" />
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
            <asp:BoundField DataField="FontSize" HeaderText="FontSize" SortExpression="FontSize" />
            
            <asp:TemplateField 
                HeaderText="Height" SortExpression="FormText">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Height") %>'></asp:TextBox>
                    <asp:HiddenField ID="hidid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"iID") %>' />
                    <asp:HiddenField ID="hidrow" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"Row") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Width" SortExpression="FormText2">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Width") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FontSize" SortExpression="FormText2">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FontSize") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </FormatControls:SmartGridView>
    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRoleUser" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>--%>
    
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
var i = 0;
function doSave() {
//    var TextBox1 = document.getElementById("TextBox1");
//    if (TextBox1.value == "") {
//        alert(document.getElementById("Label1").innerHTML + "不可为空");
//        TextBox1.focus();
//        return false;
//    }
//    var TextBox2 = document.getElementById("TextBox2");
//    if (TextBox2.value == "") {
//        alert(document.getElementById("Label2").innerHTML + "不可为空");
//        TextBox2.focus();
//        return false;
//    }
    return true;
}

function DeleTable(i, obj) {
//    if (confirm('确认删除吗？')) {
//        return true;
//    }
//    else {
//        return false;
//    }
}
</script>