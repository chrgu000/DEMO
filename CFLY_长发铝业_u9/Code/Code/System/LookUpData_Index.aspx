<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LookUpData_Index.aspx.cs"
    Inherits="System_LookUpDataIndex" MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">

    <script language="javascript" type="text/javascript">
var isEdit="0";
        function doSelect() {
            return true;
        }
        function doSave() {
            return true;
        }
        function doEdit(){
        isEdit="1";
        
        }
        function doNew() {
//            var ddl = window.document.getElementById("_ctl0_CenterContent_DropDownListS9_ddl");
//            var ivalue = "";
//            for (var i = 0; i < ddl.length; i++) {
//                if (ddl.options[i].selected == true) {
//                    ivalue = ddl.options[i].value;
//                }
//            }
//            if (ivalue == "0") {
//                alert("请先选择类别");
//                return false;
//            }
Grid.AddNewRow();
            return true;
        }
        function doDel()
        {
//            Grid.DeleteRow(Grid.GetFocusedRowIndex());
return true;
        }
function RowDBClick() { 
if(isEdit=="1")
{
Grid.StartEditRow(Grid.GetFocusedRowIndex());
}
}
function DeleteRow()
{

}

    </script>

    <div class="container" style="width: 100%">
        <div class="panel  panel-primary">
            <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToBeck="ToBeck"
                OnToDel="ToDel" OnToSave="ToSave" OnToNew="ToNew" OnToExport="ToExport" />
            <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelS2" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="ASPxComboBoxLookUpType" TextField="iText" ValueField="iID" DataSourceID="ObjectDataSourceLookUpType"
                                runat="server">
                            </dx:ASPxComboBox>
                            <asp:ObjectDataSource ID="ObjectDataSourceLookUpType" runat="server" TypeName="PublicData"
                                SelectMethod="GetLookUpType"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="Grid" runat="server" KeyFieldName="iID" DataSourceID="ObjectDataSource1" 
            OnRowDeleted="ASPxGridView1_RowDeleted" OnRowDeleting="ASPxGridView1_RowDeleting"
            OnRowInserted="ASPxGridView1_RowInserted" OnRowInserting="ASPxGridView1_RowInserting"
            OnRowUpdated="ASPxGridView1_RowUpdated" OnRowUpdating="ASPxGridView1_RowUpdating">
            <%-- <ClientSideEvents  RowDblClick="function(s, e) {RowDBClick();}" />--%>
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" Width="100px">
                    <EditButton Visible="True" Text="更改">
                    </EditButton>
                    <NewButton Visible="True" Text="增行">
                    </NewButton>
                    <CancelButton Text="取消">
                    </CancelButton>
                    <UpdateButton Text="保存">
                    </UpdateButton>
                    <CellStyle Wrap="False">
                    </CellStyle>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="iID" Caption="序号">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="iType" Caption="类别">
                    <PropertiesComboBox TextField="iText" ValueField="iID" EnableSynchronization="False"
                        IncrementalFilteringMode="StartsWith" DataSourceID="ObjectDataSourceLookUpType">
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="iText" Caption="内容">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Remark" Caption="备注">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="bSystem" Caption="系统">
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn FieldName="bClose" Caption="关闭">
                </dx:GridViewDataCheckColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="LookUpDataData"
            SelectMethod="Get" UpdateMethod="Insert" InsertMethod="Insert" DeleteMethod="Delete"
            OnInserted="ObjectDataSource1_Inserted" OnSelecting="ObjectDataSource1_Selecting"
            OnUpdating="ObjectDataSource1_Updating" OnUpdated="ObjectDataSource1_Updated"
            OnInserting="ObjectDataSource1_Inserting" OldValuesParameterFormatString="iType_{0}"
            OnDeleted="ObjectDataSource1_Deleted" OnDeleting="ObjectDataSource1_Deleting"> <%----%>
            <SelectParameters>
                <asp:Parameter Name="iType" Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="iID" Type="String" />
                <asp:Parameter Name="iType" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="iID" Type="String" />
                <asp:Parameter Name="iType" Type="Int32" />
                <asp:Parameter Name="iText" Type="String" />
                <asp:Parameter Name="Remark" Type="String" />
                <asp:Parameter Name="bClose" Type="Boolean" />
                <asp:Parameter Name="bSystem" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="iID" Type="String" />
                <asp:Parameter Name="iType" Type="Int32" />
                <asp:Parameter Name="iText" Type="String" />
                <asp:Parameter Name="Remark" Type="String" />
                <asp:Parameter Name="bClose" Type="Boolean" />
                <asp:Parameter Name="bSystem" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
