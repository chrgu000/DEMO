<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleRight_List.aspx.cs" Inherits="System_RoleRight_List" EnableEventValidation="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript" src="../Script/PublicJScript.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <asp:HiddenField ID="hidid" runat="server" />
     <FormatControls:SmartGridView ID="SmartGridView1" runat="server"  
        DataSourceID="ObjectDataSource1"  EnableEmptyContentRender="True" 
        onrowdatabound="SmartGridView1_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="vchrRoleID" HeaderText="角色编号" SortExpression="vchrRoleID" />
            <asp:BoundField DataField="vchrRoleText" HeaderText="角色编码" SortExpression="vchrRoleText" />
            <asp:BoundField DataField="vchrRemark" HeaderText="备注" SortExpression="vchrRemark" />
        </Columns>
    </FormatControls:SmartGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserRole" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>
    
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
function getChange(i) {
    var dt = document.getElementById("SmartGridView1");
    
    var s1 = dt.rows[i].cells[2].innerHTML;
    if (s1 == "&nbsp;") {
        s1=""
    }
    
    var s2 = dt.rows[i].cells[3].innerHTML;
    if (s2 == "&nbsp;") {
        s2 = ""
    }

    var s3 = dt.rows[i].cells[4].innerHTML;
    if (s3 == "&nbsp;") {
        s3 = ""
    }
    dt.rows[i].cells[6].getElementsByTagName("input")[0].value = s1;
    dt.rows[i].cells[7].getElementsByTagName("input")[0].value = s2;
    dt.rows[i].cells[8].getElementsByTagName("input")[0].value = s3;
    
}
</script>