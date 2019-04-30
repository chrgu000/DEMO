<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cInvCType.aspx.cs" Inherits="Invoice_cInvCType"
    MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">

    <script language="javascript" type="text/javascript">
        function doSelect() {
            return true;
        }
        function doSave() {
            return true;
        }
        function doNew() {
            return false;
        }
        function doNewRow() {
            ASPxGridView1.AddNewRow();
            return false;
        }

        function doDel() {
            //            ASPxGridView1.DeleteRow();
            //            ASPxGridView1.GetSelectedRowCount();
            //            for (var i = 0; i < ASPxGridView1.VisibleRowCount; i++) {
            //                var id = ASPxGridView1.GetValue("iID");
            ////                ASPxGridView1.DeleteRow(0);
            //            }
            return true;
        }

        function doEdit() {
            //            window.open("Import.aspx");

            //            var o = new Object();
            //            var k = showModalDialog("Import.aspx", o, "dialogWidth:1200px;dialogHeight:500px;scrollbars:no;help:no;");
            //            if (k != null && typeof (k.id) != "") {
            //                if (k.type == "ok") {
            //                    return true;
            //                }
            //                else {
            //                    return false;
            //                }
            //            }
            //            else {
            //                return false;
            //            }
            return true;
        }

        function doAudit() {
            return true;
        }
        function doUnAudit() {
            return true;
        }

        function doClose() {
        }

        function doOpen() {
        }

        function doShow(cVen) {
            var o = new Object();
            var k = showModalDialog("SelectVer.aspx?cVenCode=" + cVen, o, "dialogWidth:900px;dialogHeight:500px;scrollbars:no;help:no;");
            return false;
        }
    </script>

    <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToBeck="ToBeck"
        OnToDel="ToDel" OnToSave="ToSave" OnToNew="ToNew" OnToExport="ToExport" OnToEdit="ToEdit"
        OnToAudit="ToAudit" OnToUnAudit="ToUnAudit" OnToClose="ToClose" OnToOpen="ToOpen" />
    <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel">
        <table>
            
        </table>
    </asp:Panel>
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
        KeyFieldName="cInvCCode" DataSourceID="ObjectDataSource1" OnCellEditorInitialize="ASPxGridView1_CellEditorInitialize"
        onpageindexchanged="ASPxGridView1_PageIndexChanged" 
        onprerender="ASPxGridView1_PreRender">
        <Columns>
            <dx:GridViewCommandColumn Width="70px" >
                <EditButton Visible="True" Text="更改">
                </EditButton>
                <CancelButton Text="取消">
                </CancelButton>
                <UpdateButton Text="保存">
                </UpdateButton>
                <CellStyle Wrap="False">
                </CellStyle>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataColumn FieldName="cInvCCode" Caption="分类编码">
                <EditItemTemplate>
                    <dx:ASPxLabel ID="lblcInvCCode" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "cInvCCode")%>'>
                    </dx:ASPxLabel>
                </EditItemTemplate>
                <HeaderStyle Font-Bold="false" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn FieldName="cInvCName"  Caption="分类名称">
                <EditItemTemplate>
                    <dx:ASPxLabel ID="lblcInvCName" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "cInvCName")%>'>
                    </dx:ASPxLabel>
                </EditItemTemplate>
                <HeaderStyle Font-Bold="false" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataTextColumn FieldName="Per" Width="200px" ToolTip="Per"  Caption="标准报废率">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="cInvcTypeData"
        SelectMethod="Get" UpdateMethod="Insert" InsertMethod="Insert" DeleteMethod="Delete"
        OnInserted="ObjectDataSource1_Inserted" OnSelecting="ObjectDataSource1_Selecting"
        OnUpdating="ObjectDataSource1_Updating" OnUpdated="ObjectDataSource1_Updated"
        OnInserting="ObjectDataSource1_Inserting" OnDeleting="ObjectDataSource1_Deleting">
        <SelectParameters>
        </SelectParameters>
        <DeleteParameters>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="cInvCCode" Type="String" />
            <asp:Parameter Name="Per" Type="Decimal" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="cInvCCode" Type="String" />
            <asp:Parameter Name="Per" Type="Decimal" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
