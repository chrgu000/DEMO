<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo_Update.aspx.cs"
    Inherits="System_UserInfo_Update" MasterPageFile="~/Frame/MasterPage.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="container" style="width: 100%;">
        <div class="panel  panel-primary">
            <asp:HiddenField ID="hidid" runat="server" />
            <FormatControls:Button ID="YxBtn" runat="server"  OnToBack="ToBack" OnToSave="ToSave"
                OnToDel="ToDel" />
            <table class="TableUpdate" style="width: 1000px; margin-left: auto; margin-right: auto;">
                <tr>
                    <td class="tdlbl" width="200px">
                        <dx:ASPxLabel ID="Label1" runat="server" Text="*账号"></dx:ASPxLabel>
                    </td>
                    <td class="tdinput" width="400px">
                        <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                    </td>
                    <td class="tdlbl" width="200px">
                        <dx:ASPxLabel ID="Label2" runat="server" Text="*姓名"></dx:ASPxLabel>
                    </td>
                    <td class="tdinput" width="400px">
                        <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" ReadOnly="true"></dx:ASPxTextBox>
                    </td>
                </tr><%--
                <tr>
                    <td class="tdlbl">
                        <dx:ASPxLabel ID="Label3" runat="server">*密码</dx:ASPxLabel>
                    </td>
                    <td class="tdinput">
                        <dx:ASPxTextBox ID="TextBox3" runat="server" TextMode="Password"></dx:ASPxTextBox>
                    </td>
                    <td class="tdlbl">
                        <dx:ASPxLabel ID="Label4" runat="server">*重复密码</dx:ASPxLabel>
                    </td>
                    <td class="tdinput">
                        <dx:ASPxTextBox ID="TextBox4" runat="server" TextMode="Password"></dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdlbl">
                        <dx:ASPxLabel ID="Label5" runat="server">启用日期</dx:ASPxLabel>
                    </td>
                    <td class="tdinput">
                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="tdlbl">
                        <dx:ASPxLabel ID="Label6" runat="server">到期日期</dx:ASPxLabel>
                    </td>
                    <td class="tdinput">
                        <dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td class="tdlbl">
                        <dx:ASPxLabel ID="Label7" runat="server">备注</dx:ASPxLabel>
                    </td>
                    <td class="tdinput" colspan="3">
                        <dx:ASPxTextBox ID="TextBox7" runat="server" Width="98%" Rows="5" TextMode="MultiLine"></dx:ASPxTextBox>
                    </td>
                </tr>--%>
            </table>
        </div>
        <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
            KeyFieldName="vchrRoleID" DataSourceID="ObjectDataSource1" 
            RightToLeft="False" >
            <Columns>
                 <dx:GridViewDataTextColumn FieldName="vchrRoleID" Caption="角色编号" Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vchrRoleText" Caption="角色编码"  Width="100px">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vchrRemark" Caption="备注"  Width="100px">
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
            <SettingsPager Mode="ShowAllRecords"/>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUserRole"
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
