<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report1.aspx.cs" Inherits="Report_Report1"
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
    <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel" >
        <table >
            <tr >
                <td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="开始日期" ></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="ASPxDateEdit1"  runat="server" >
                    </dx:ASPxDateEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="结束日期"></dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxDateEdit ID="ASPxDateEdit2"  runat="server"></dx:ASPxDateEdit>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
        KeyFieldName="Flag" DataSourceID="ObjectDataSource1" 
        onpageindexchanged="ASPxGridView1_PageIndexChanged" AutoGenerateColumns="False" >
        <Columns>
            <dx:GridViewDataTextColumn FieldName="Flag" Caption="类别" Width="150" 
                VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S1" Caption="一月" VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S2" Caption="二月" VisibleIndex="3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S3" Caption="三月" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S4" Caption="四月" VisibleIndex="5"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S5" Caption="五月" VisibleIndex="6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S6" Caption="六月" VisibleIndex="7"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S7" Caption="七月" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S8" Caption="八月" VisibleIndex="9"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S9" Caption="九月" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S10" Caption="十月" VisibleIndex="11"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S11" Caption="十一月" VisibleIndex="12"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S12" Caption="十二月" VisibleIndex="13"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="合计" Caption="合计" VisibleIndex="14"></dx:GridViewDataTextColumn>
        </Columns>
      
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="S1" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S2" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S3" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S4" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S5" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S6" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S7" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S8" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S9" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S10" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S11" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="S12" SummaryType="Sum" DisplayFormat="{0,1}"/>
            <dx:ASPxSummaryItem FieldName="合计" SummaryType="Sum" DisplayFormat="{0,1}"/>
        </TotalSummary>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ReportData"
        SelectMethod="Report1" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="sDate" Type="String" />
            <asp:Parameter Name="eDate" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="ASPxGridView1" runat="server">
    </dx:ASPxGridViewExporter>
</asp:Content>
