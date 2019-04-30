<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo_Index.aspx.cs" Inherits="System_UserInfo_Index"
    MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">

    <script language="javascript" type="text/javascript">
        function doSelect() {
            return true;
        }
        function doNew() {
            alert("s");
            ASPxGridView1.AddNewRow();
            return false;
        }
        function doNewRow() {
            
            ASPxGridView1.AddNewRow();
            return false;
        }
        function doDel() {
            return true;
        }

        function doEdit() {
            return false;
        }
    </script>
    
        <script type="text/javascript">
            function RowClickUserInfo(vchrUid) {
                window.location.href = "UserInfo_Update.aspx?ID=" + vchrUid;
            }
    </script>

    <div class="container" style="width: 100%">
        <div class="panel  panel-primary">
            <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToNew="ToNew" OnToNewRow="ToNewRow"
                OnToDel="ToDel" Title="用户" />
            <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel">
                <table>
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="Label3" runat="server" Text="用户编码或名称">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
            KeyFieldName="vchrUid" DataSourceID="ObjectDataSource1" OnRowDeleted="ASPxGridView1_RowDeleted"
            OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserted="ASPxGridView1_RowInserted"
            OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdated="ASPxGridView1_RowUpdated"
            OnRowUpdating="ASPxGridView1_RowUpdating" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize"
            AutoGenerateColumns="False">
           
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" Width="100px">
                    <NewButton Visible="true" Text="新增">
                    </NewButton>
                    <EditButton Visible="True" Text="更改">
                    </EditButton>
                    <CancelButton Text="取消">
                    </CancelButton>
                    <UpdateButton Text="保存">
                    </UpdateButton>
                    <CellStyle Wrap="False" >
                    </CellStyle>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="vchrUid" Caption="用户编码">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vchrName" Caption="用户名称">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vchrPwd" Caption="密码" PropertiesTextEdit-Password="true">
                    <PropertiesTextEdit Password="True">
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="vchrRemark" Caption="备注">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="dtmCreate" Caption="启用日期"></dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="dtmClose" Caption="停用日期"></dx:GridViewDataDateColumn>
                <dx:GridViewDataColumn FieldName="iCheck" Caption="  ">
                    <DataItemTemplate>
                        <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server">
                        </dx:ASPxCheckBox>
                    </DataItemTemplate>
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <HeaderStyle Font-Bold="false" />
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn><DataItemTemplate><input type="button" id="btn1" value="权限设定" class="btn" onclick="javascript:RowClickUserInfo('<%#  DataBinder.Eval(Container.DataItem, "vchrUid")%>')" /></DataItemTemplate></dx:GridViewDataColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="UserInfoData"
            SelectMethod="Get" UpdateMethod="Insert" InsertMethod="Insert" DeleteMethod="Delete"
            OnInserted="ObjectDataSource1_Inserted" OnSelecting="ObjectDataSource1_Selecting"
            OnUpdating="ObjectDataSource1_Updating" OnUpdated="ObjectDataSource1_Updated"
            OnInserting="ObjectDataSource1_Inserting" OnDeleted="ObjectDataSource1_Deleted"
            OnDeleting="ObjectDataSource1_Deleting">
            <SelectParameters>
                <asp:Parameter Name="vchrUid" Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="vchrUid" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="vchrUid" Type="String" />
                <asp:Parameter Name="vchrName" Type="String" />
                <asp:Parameter Name="vchrPwd" Type="String" />
                <asp:Parameter Name="vchrRemark" Type="String" />
                <asp:Parameter Name="dtmCreate" Type="DateTime" />
                <asp:Parameter Name="dtmClose" Type="DateTime" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="vchrUid" Type="String" />
                <asp:Parameter Name="vchrName" Type="String" />
                <asp:Parameter Name="vchrPwd" Type="String" />
                <asp:Parameter Name="vchrRemark" Type="String" />
                <asp:Parameter Name="dtmCreate" Type="DateTime" />
                <asp:Parameter Name="dtmClose" Type="DateTime" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceDepartment" runat="server" TypeName="PublicData"
            SelectMethod="GetDepartment"></asp:ObjectDataSource>
    </div>
</asp:Content>
