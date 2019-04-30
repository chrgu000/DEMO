<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report8.aspx.cs" Inherits="Report_Report8"
    MasterPageFile="~/Frame/MasterPage.master" %>

<%@ Register Assembly="DevExpress.XtraCharts.v11.1.Web, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
    
<%@ Register assembly="DevExpress.XtraCharts.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>
    
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
            </tr>
        </table>
    </asp:Panel>
    <table><tr><td style="vertical-align:top">
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
        KeyFieldName="cCusName" DataSourceID="ObjectDataSource1" Width="580" >
        <Columns>
            <dx:GridViewDataTextColumn FieldName="cCusName" Caption="客户名称" CellStyle-Wrap="False" Width="300"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity" Caption="实际重量"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Symbol" Caption="币种" Width="50"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iMoney" Caption="金额"></dx:GridViewDataTextColumn>
        </Columns>
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="iQuantity" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="iMoney" SummaryType="Sum"  DisplayFormat="{0,2}"/>
        </TotalSummary>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ReportData"
        SelectMethod="Report8" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="sDate" Type="String" />
            <asp:Parameter Name="eDate" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </td><td style="vertical-align:top">
    <div class="div1">
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Width="800px" Height="400px" >
        </dxchartsui:WebChartControl>
    </div>
    </td></tr></table>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1"  GridViewID="ASPxGridView1" runat="server">
    </dx:ASPxGridViewExporter>
</asp:Content>
