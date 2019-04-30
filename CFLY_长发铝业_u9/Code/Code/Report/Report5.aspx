<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report5.aspx.cs" Inherits="Report_Report5"
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
                    <dx:ASPxLabel ID="LabelDate1" runat="server" Text="年">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server"> 
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="月">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:MonthEdit ID="MonthEdit1" runat="server">
                    </dx:MonthEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="至">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server"> 
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="月">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:MonthEdit ID="MonthEdit2" runat="server">
                    </dx:MonthEdit>
                </td>
<%--                <td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="客户">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="ASPxTextBox3" runat="server"> 
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="产品类别">
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
                </td>--%>
            </tr>
        </table>
    </asp:Panel>
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
        KeyFieldName="iMonth2" DataSourceID="ObjectDataSource1" onpageindexchanged="ASPxGridView1_PageIndexChanged" 
        onprerender="ASPxGridView1_PreRender">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="iMonth2" Caption="月份"></dx:GridViewDataTextColumn>
        </Columns>
        <TotalSummary>
<%--            <dx:ASPxSummaryItem FieldName="公用用材" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="建材" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="交通运输" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="流水线" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="散热器" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="无缝管" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="消费用品" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="新能源" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="展示器材" SummaryType="Sum" />
            <dx:ASPxSummaryItem FieldName="合计" SummaryType="Sum" />--%>
        </TotalSummary>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ReportData"
        SelectMethod="Report5" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="Year1" Type="String" />
            <asp:Parameter Name="Year2" Type="String" />
<%--            <asp:Parameter Name="cCusCode" Type="String" />
--%>            <asp:Parameter Name="cInvCName" Type="String" />
            <asp:Parameter Name="Month1" Type="Int32" />
            <asp:Parameter Name="Month2" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="ASPxGridView1" runat="server">
    </dx:ASPxGridViewExporter>
</asp:Content>
