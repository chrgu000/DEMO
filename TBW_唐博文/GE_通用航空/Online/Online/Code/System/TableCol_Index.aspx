<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableCol_Index.aspx.cs" Inherits="System_TableCol_Index" EnableEventValidation="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript" src="../Script/PublicJScript.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <script src="../js/jquery-1.9.1.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/bootstrap-datetimepicker.min.js"></script>

    <script src="../js/jquery.form.js"></script>

    <script src="../js/jquery.validate.js"></script>

    <script src="../Script/PublicJScript.js"></script>

    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <asp:HiddenField ID="hidid" runat="server" />
    <FormatControls:Button ID="YxBtn" runat="server" OnToSave="ToSave"  Title="表列信息" />
    <asp:Panel runat="server" id="divSel" Width="100%">
        数据库名称<asp:DropDownList ID="DropDownList1"  runat="server" CssClass="form-control"  Width="120px"
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True"  ></asp:DropDownList>
        数据表名称<asp:DropDownList ID="DropDownList2"  runat="server"  CssClass="form-control" Width="120px"
            onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
            AutoPostBack="True"  ></asp:DropDownList>
    </asp:Panel>
    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"  AllowPaging="false"  EnableEmptyContentRender="True" CssClass="table" BorderWidth="0" >
        <Columns>
            <asp:BoundField DataField="TABLE_CATALOG" HeaderText="数据库名称" SortExpression="TABLE_CATALOG" />
            <asp:BoundField DataField="TABLE_NAME" HeaderText="表名" SortExpression="TABLE_NAME" />
            <asp:BoundField DataField="COLUMN_NAME" HeaderText="列名" SortExpression="COLUMN_NAME" />
            <asp:BoundField DataField="DataType" HeaderText="数据类型" SortExpression="DataType" />
            
            <asp:TemplateField 
                HeaderText="列标题" SortExpression="FormText">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"COLUMN_Text") %>'></asp:TextBox>
                    <asp:HiddenField ID="hid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"iID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="列英文标题" SortExpression="FormText2">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"COLUMN_Text2") %>'></asp:TextBox>
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