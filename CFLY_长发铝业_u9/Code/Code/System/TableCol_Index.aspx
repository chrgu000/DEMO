<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TableCol_Index.aspx.cs" Inherits="System_TableCol_Index"
    MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
<link href="../css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
	</script>
    <div class="container" style="width: 100%">
        <div class="panel  panel-primary">
            <asp:HiddenField ID="hidid" runat="server" />
            <FormatControls:Button ID="YxBtn" runat="server" OnToSave="ToSave" Title="表列信息" />
            <asp:Panel runat="server" ID="divSel" Width="100%">
                数据库名称<asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"
                    Width="120px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                数据表名称<asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"
                    Width="120px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </asp:Panel>
        </div>
        <FormatControls:SmartGridView ID="SmartGridView1" runat="server" AllowPaging="false" CssClass="table table-bordered table-condensed"
            EnableEmptyContentRender="True" >
            <Columns>
                <asp:BoundField DataField="TABLE_CATALOG" HeaderText="数据库名称" SortExpression="TABLE_CATALOG"  />
                <asp:BoundField DataField="TABLE_NAME" HeaderText="表名" SortExpression="TABLE_NAME" />
                <asp:BoundField DataField="COLUMN_NAME" HeaderText="列名" SortExpression="COLUMN_NAME" />
                <asp:BoundField DataField="DataType" HeaderText="数据类型" SortExpression="DataType" />
                <asp:TemplateField HeaderText="列标题" SortExpression="FormText">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxCOLUMN_Text" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"COLUMN_Text") %>'></asp:TextBox>
                        <asp:HiddenField ID="hid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"iID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="列英文标题" SortExpression="COLUMN_Text2">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxCOLUMN_Text2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"COLUMN_Text2") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="表列排序" SortExpression="VisibleIndex">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxVisibleIndex" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"VisibleIndex") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="表列类型" SortExpression="ColType">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxColType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ColType") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="表列定向" SortExpression="ColLink">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxColLink" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ColLink") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="下拉列表类型" SortExpression="ColSel">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxColSel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ColSel") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="下拉列表参数" SortExpression="ColSelFlag">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxColSelFlag" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ColSelFlag") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否必输" SortExpression="IsInput">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxIsInput" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsInput") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改页排序" SortExpression="UpdateVisibleIndex">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxUpdateVisibleIndex" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"UpdateVisibleIndex") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改页控件类型" SortExpression="UpdateType">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxUpdateType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"UpdateType") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </FormatControls:SmartGridView>
        <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRoleUser" TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting" ></asp:ObjectDataSource>--%>
    </div>

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

</asp:Content>
