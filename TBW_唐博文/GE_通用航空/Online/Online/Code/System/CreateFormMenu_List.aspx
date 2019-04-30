<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateFormMenu_List.aspx.cs" Inherits="System_CreateFormMenu_List" EnableEventValidation="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript" src="../Script/PublicJScript.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <asp:HiddenField ID="hidid" runat="server" />
    <FormatControls:Button ID="YxBtn" runat="server"  OnToBeck="ToBeck"  OnToSave ="ToSave"/>
    <table class="TableUpdate">
        <tr><td class="tdtitle" colspan="4" >窗体信息</td></tr>
        <tr>
            <td class="tdlbl" width="30%">
                <asp:Label ID="Label1" runat="server" >菜单编码</asp:Label>
            </td>
            <td class="tdinput" width="45%">
                <asp:TextBox ID="TextBox1"  runat="server" ></asp:TextBox>
            </td>
            <td class="tdlbl" >
                <asp:Label ID="Label2" runat="server">排序</asp:Label>
            </td>
            <td class="tdinput" >
                <asp:TextBox ID="TextBox2"  runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdlbl" >
                <asp:Label ID="Label3" runat="server">菜单名称</asp:Label>
            </td>
            <td class="tdinput" >
                <asp:TextBox ID="TextBox3"  runat="server" ></asp:TextBox>
            </td>
            <td class="tdlbl" >
                <asp:Label ID="Label4" runat="server">英文名称</asp:Label>
            </td>
            <td class="tdinput" >
                <asp:TextBox ID="TextBox4"  runat="server" ></asp:TextBox>
            </td>
        </tr>
    </table>
    
    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"  AllowPaging="false"
            EnableEmptyContentRender="True" >
        <Columns>
            <asp:TemplateField>
                <headertemplate>
                    选择
                </headertemplate>
                <itemtemplate>
                    <%--<asp:CheckBox ID="chk" runat="server" Checked='<%# Convert.ToBoolean(Eval("bChoose")) %>'   />--%>
                    <input type="checkbox" id="chk" runat="server" checked='<%# Convert.ToBoolean(Eval("bChoose")) %>' value='<%# (Container.DataItemIndex + 1)%>' onchange="javascript:getChange(this.value)" />
                    <asp:HiddenField ID="hidid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"btnCode") %>'/>
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
            <asp:BoundField DataField="btnCode" HeaderText="按钮编号" SortExpression="btnCode" />
            <asp:BoundField DataField="btnName" HeaderText="按钮名称" SortExpression="btnName" />
            <asp:BoundField DataField="btnName2" HeaderText="按钮英文名称" SortExpression="btnName2" />
            <asp:BoundField DataField="iOrder" HeaderText="排序" SortExpression="iOrder" />
            <asp:BoundField DataField="bEnable" HeaderText="Enable属性" SortExpression="bEnable" />
            <%--<asp:BoundField DataField="vchrRemark" HeaderText="窗体Enable属性" SortExpression="vchrRemark" />--%><asp:TemplateField 
                HeaderText="窗体按钮名称" SortExpression="FormText">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FormText") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="窗体按钮英文名称" SortExpression="FormText2">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FormText2") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="窗体按钮顺序" SortExpression="FormEnable">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FormEnable") %>'></asp:TextBox>
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