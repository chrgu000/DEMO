<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LookUpData_Index.aspx.cs" Inherits="System_LookUpData_Index" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" AUTOCOMPLETE="off">
    <FormatControls:Button ID="YxBtn" runat="server"  OnToBeck="ToBeck"  OnToDel="ToDel"  OnToSave ="ToSave" OnToNew="ToNew" OnToSelect="ToSelect" />
    <asp:Panel runat="server" id="divSel" Width="100%" CssClass="panel" >
        <asp:Label ID="LabelS1" runat="server"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>
    </asp:Panel>
    <FormatControls:SmartGridView ID="SmartGridView1" runat="server"    DataSourceID="ObjectDataSource1"  EnableEmptyContentRender="True">
        <Columns>
            <asp:TemplateField >
                <headertemplate>
                    
                </headertemplate>
                <itemtemplate>
                    <asp:CheckBox ID="chk" runat="server"  />
                    <asp:HiddenField ID="hiditype"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"iType") %>'/>
                    <asp:HiddenField ID="hidid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"iID") %>'/>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="iID" SortExpression="iID" >
                <itemtemplate>
                    <a href="LookUpData_Update.aspx?iType=<%# DataBinder.Eval(Container.DataItem,"iType") %>&ID=<%# DataBinder.Eval(Container.DataItem,"iID") %>"><%# DataBinder.Eval(Container.DataItem, "iID")%></a>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="iText" HeaderText="名称" SortExpression="iText" />
            <asp:BoundField DataField="iText2" HeaderText="英文名称" SortExpression="iText2" />
            <asp:BoundField DataField="bClose" HeaderText="是否关闭" SortExpression="bClose" />
            <asp:BoundField DataField="bSystem" HeaderText="是否系统" SortExpression="bSystem" />
            <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" />
        </Columns>
    </FormatControls:SmartGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLookUpData" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>
    </form>
</body>

</html>
<script language="javascript" type="text/javascript">
function doSelect() {
    return true;
}
</script>