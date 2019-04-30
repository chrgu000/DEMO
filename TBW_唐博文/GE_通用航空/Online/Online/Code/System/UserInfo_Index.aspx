<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo_Index.aspx.cs" Inherits="System_UserInfo_Index" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToNew="ToNew" OnToDel="ToDel" Title="用户" />

    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"  
        DataSourceID="ObjectDataSource1"  EnableEmptyContentRender="True">
        <Columns>
            <asp:TemplateField>
                <headertemplate>
                    
                </headertemplate>
                <itemtemplate>
                    <asp:CheckBox ID="chk" runat="server"  />
                    <asp:HiddenField ID="hidid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"vchrUid") %>'/>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <headertemplate>
                    <a onclick="return true;" href="javascript:__doPostBack('SmartGridView1','Sort$vchrUid')">账号</a>
                </headertemplate>
                <itemtemplate>
                    <a href="UserInfo_Update.aspx?ID=<%# DataBinder.Eval(Container.DataItem,"vchrUid") %>"><%# DataBinder.Eval(Container.DataItem, "vchrUid")%></a>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="vchrName" HeaderText="姓名" SortExpression="vchrName" />
            <asp:TemplateField HeaderText="启用日期" SortExpression="dtmCreate">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dtmCreate","{0:yyyy-MM-dd}")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="失效日期" SortExpression="dtmClose">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dtmClose","{0:yyyy-MM-dd}")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="vchrRemark" HeaderText="备注" SortExpression="vchrRemark" />
        </Columns>
    </FormatControls:SmartGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserInfo" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>
    </form>
</body>

</html>
<script language="javascript" type="text/javascript">
    function doSelect() {


        return true;
    }
    function doNew() {
        return true;
    }
</script>