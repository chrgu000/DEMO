<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report6.aspx.cs" Inherits="Report_Report6"
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
            return true;
        }
        function doAudit() {
            return true;
        }
        function doUnAudit() {
            return true;
        }
    </script>

    <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToBeck="ToBeck"
        OnToDel="ToDel" OnToSave="ToSave" OnToNew="ToNew" OnToExport="ToExport" OnToEdit="ToEdit"
        OnToAudit="ToAudit" OnToUnAudit="ToUnAudit" />
    <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel">
        <table>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="开始日期" ></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="ASPxDateEdit1"  runat="server"></dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="结束日期"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="ASPxDateEdit2"  runat="server"></dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="行业编码">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxButtonEdit ID="ASPxButtonEditcInv" runat="server" ClientInstanceName="ASPxButtonEditcInv"
                        RightToLeft="False">
                        <ClientSideEvents ButtonClick="ASPxButtoncInv_CheckedChanged" />
                        <Buttons>
                            <dx:EditButton>
                            </dx:EditButton>
                        </Buttons>
                    </dx:ASPxButtonEdit>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
        KeyFieldName="cInvCCode" DataSourceID="ObjectDataSource1" onpageindexchanged="ASPxGridView1_PageIndexChanged" 
        onprerender="ASPxGridView1_PreRender">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="cInvCCode" Caption="行业编码"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="cInvCName" Caption="行业名称"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity1" Caption="内废"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity2" Caption="外废"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity3" Caption="委外报废"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity" Caption="报废汇总"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="outiQuantity" Caption="出货量"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Per" Caption="报废率"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Per2" Caption="标准报废率"></dx:GridViewDataTextColumn>
        </Columns>
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="iQuantity1" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="iQuantity2" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="iQuantity3" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="iQuantity" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="outiQuantity" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="合计" SummaryType="Sum" />
        </TotalSummary>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ReportData"
        SelectMethod="Report6" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="sDate" Type="String" />
            <asp:Parameter Name="eDate" Type="String" />
            <asp:Parameter Name="cInvCName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="ASPxGridView1" runat="server">
    </dx:ASPxGridViewExporter>
</asp:Content>
