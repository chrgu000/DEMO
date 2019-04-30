<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleInfo_Update.aspx.cs"
    Inherits="System_RoleInfo_Update" MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="container" style="width: 100%;">
        <div class="panel  panel-primary">
            <asp:HiddenField ID="hidid" runat="server" />
            <FormatControls:Button ID="YxBtn" runat="server"  OnToBack="ToBack" OnToSave="ToSave"
                OnToDel="ToDel" />
            <table class="TableUpdate" style="width: 1000px; margin-left: auto; margin-right: auto;">
                <tr>
                    <td class="tdlbl" width="200px">
                        <dx:ASPxLabel ID="Label1" runat="server" Text="*权限编码"></dx:ASPxLabel>
                    </td>
                    <td class="tdinput" width="400px">
                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                    </td>
                    <td class="tdlbl" width="200px">
                        <dx:ASPxLabel ID="Label2" runat="server" Text="*权限名称"></dx:ASPxLabel>
                    </td>
                    <td class="tdinput" width="400px">
                        <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                    </td>
                </tr>
            </table>
        </div>
        <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
            KeyFieldName="vchrUid" DataSourceID="ObjectDataSource1" >
            <Columns>
                <dx:GridViewDataTextColumn FieldName="vchrUid" Caption="用户编码">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vchrName" Caption="用户名称">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vchrRemark" Caption="备注">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn FieldName="iCheck" Width="30px" FixedStyle="Left">
                <DataItemTemplate>
                     <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Checked='<%#  DataBinder.Eval(Container.DataItem, "bChoosed")%>'>
                     </dx:ASPxCheckBox>
                </DataItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderTemplate>
                    <dx:ASPxCheckBox ID="ASPxCheckBoxAll" runat="server" AutoPostBack="false">
                        <ClientSideEvents CheckedChanged="doCheckChangeAll" />
                    </dx:ASPxCheckBox>
                </HeaderTemplate>
                <Settings AllowSort="False" />
                <HeaderStyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Center">
                </CellStyle>
            </dx:GridViewDataColumn>
            </Columns>
            <%--<SettingsPager Mode="ShowAllRecords"/>--%>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRoleUser"
            TypeName="OjbData" OnSelecting="ObjectDataSource1_Selecting"></asp:ObjectDataSource>
    </div>

    <script language="javascript" type="text/javascript">
var i = 0;
function doSave() {
    return true;
}

function doNew() {
    return true;
}

    </script>

</asp:Content>
