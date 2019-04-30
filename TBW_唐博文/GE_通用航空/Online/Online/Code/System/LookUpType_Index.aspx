<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LookUpType_Index.aspx.cs" Inherits="System_LookUpType_Index" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <FormatControls:Button ID="YxBtn" runat="server"  OnToBeck="ToBeck"  OnToDel="ToDel"  OnToSave ="ToSave" OnToNew="ToNew" OnToSelect="ToSelect" />
    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"    DataSourceID="ObjectDataSource1"  EnableEmptyContentRender="True">
        <Columns>
            <asp:TemplateField>
                <headertemplate>
                    
                </headertemplate>
                <itemtemplate>
                    <asp:CheckBox ID="chk" runat="server"  />
                    <asp:HiddenField ID="hidid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"iID") %>'/>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <headertemplate>
                    <a onclick="return true;" href="javascript:__doPostBack('SmartGridView1','Sort$iID')">序号</a>
                </headertemplate>
                <itemtemplate>
                    <a href="LookUpType_Update.aspx?ID=<%# DataBinder.Eval(Container.DataItem,"iID") %>"><%# DataBinder.Eval(Container.DataItem, "iID")%></a>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="iType" HeaderText="名称" SortExpression="iType" />
            <asp:BoundField DataField="iType2" HeaderText="英文名称" SortExpression="iType2" />
            <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" />
        </Columns>
    </FormatControls:SmartGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLookUpType" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>
    </form>
</body>

</html>
<script language="javascript" type="text/javascript">
function doSelect() {
    return true;
}
</script>