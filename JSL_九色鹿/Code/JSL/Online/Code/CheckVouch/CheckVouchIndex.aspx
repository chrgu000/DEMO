<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckVouchIndex.aspx.cs" Inherits="CheckVouch_CheckVouchIndex" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <YxControls:YxButtonIndex ID="YxBtnIndex" runat="server" OnToSelect="ToSelect" OnToNew="ToNew" OnToDel="ToDel" Title="盘点单" />
    <asp:Panel runat="server" id="divSel" Width="100%">
        单据日期<YxControls:YxCalendarStartEnd ID="Cal" runat="server" />
    </asp:Panel>
    <yyc:SmartGridView ID="SmartGridView1" runat="server"  DataSourceID="ObjectDataSource1"  DataKeyNames="ID" EnableEmptyContentRender="True">
        <Columns>
            <asp:TemplateField>
                <headertemplate>
                    选择
                </headertemplate>
                <itemtemplate>
                    <asp:CheckBox ID="chk" runat="server" />
                    <asp:HiddenField ID="hidid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"ID") %>'/>
                    <asp:HiddenField ID="hidsid"  runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"AutoID") %>'/>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <headertemplate>
                    <a onclick="return true;" href="javascript:__doPostBack('SmartGridView1','Sort$ID')">序号</a>
                </headertemplate>
                <itemtemplate>
                    <%# DataBinder.Eval(Container.DataItem,"ID") %>
                    <%--<a href="CheckVouchUpdate.aspx?ID=<%# DataBinder.Eval(Container.DataItem,"ID") %>"><%# DataBinder.Eval(Container.DataItem, "ID")%></a>--%>
                </itemtemplate>
                <itemstyle width="10px" />
            </asp:TemplateField>
            <asp:BoundField DataField="CheckCode" HeaderText="单据号" SortExpression="CheckCode" />
            <asp:BoundField DataField="dDate" HeaderText="单据日期" SortExpression="dDate" />
            <asp:BoundField DataField="cInvCode" HeaderText="物料编码" SortExpression="cInvCode" />
            <asp:BoundField DataField="BoxNo" HeaderText="箱号" SortExpression="BoxNo" />
            <asp:BoundField DataField="sBoxNo" HeaderText="盒号" SortExpression="sBoxNo" />
        </Columns>
    </yyc:SmartGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCheckVouch" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>
    </form>
</body>

</html>
<script language="javascript" type="text/javascript">
    function doSelect() {


    return true;
}
</script>