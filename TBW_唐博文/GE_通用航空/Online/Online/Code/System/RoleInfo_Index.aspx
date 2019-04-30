<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleInfo_Index.aspx.cs" Inherits="System_RoleInfo_InIndex" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToNew="ToNew" OnToDel="ToDel"  />
    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"  
        DataSourceID="ObjectDataSource1"  EnableEmptyContentRender="True">
        <Columns>
            <asp:TemplateField>
                <headertemplate>
                    
                </headertemplate>
                <itemtemplate>
                    <asp:CheckBox ID="chk" runat="server"  />
                    <asp:HiddenField ID="hidid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"vchrRoleID") %>'/>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <headertemplate>
                    <a onclick="return true;" href="javascript:__doPostBack('SmartGridView1','Sort$vchrRoleID')">角色编号</a>
                </headertemplate>
                <itemtemplate>
                    <a href="RoleInfo_Update.aspx?ID=<%# DataBinder.Eval(Container.DataItem,"vchrRoleID") %>"><%# DataBinder.Eval(Container.DataItem, "vchrRoleID")%></a>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="vchrRoleText" HeaderText="角色编码" SortExpression="vchrRoleText" />
            <asp:TemplateField HeaderText="创建日期" SortExpression="dtmCreate">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dtmCreate","{0:yyyy-MM-dd}")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="vchrRemark" HeaderText="备注" SortExpression="vchrRemark" />
            <%--<asp:BoundField DataField="bClosed" HeaderText="是否关闭" SortExpression="bClosed" />--%>
        </Columns>
    </FormatControls:SmartGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRoleInfo" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>
    </form>
</body>

</html>
<script language="javascript" type="text/javascript">
    function doSelect() {


    return true;
}
</script>