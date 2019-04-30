<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report4.aspx.cs" Inherits="Report_Report4"
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
                <td>
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="客户">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxButtonEdit ID="ASPxButtonEditcCus" runat="server" >
                        <ClientSideEvents ButtonClick="ASPxButtoncCus_CheckedChanged" />
                        <Buttons>
                            <dx:EditButton>
                            </dx:EditButton>
                        </Buttons>
                    </dx:ASPxButtonEdit>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="产品类别">
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
    <dx:ASPxGridView ID="ASPxGridView2" ClientInstanceName="ASPxGridView2" runat="server"
        KeyFieldName="iYear" DataSourceID="ObjectDataSource1" >
        <ClientSideEvents Init="OnInit2" EndCallback="OnEndCallback2" />
        <Columns>
            <dx:GridViewDataTextColumn FieldName="iYear" Caption="年份"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S1" Caption="一月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S2" Caption="二月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S3" Caption="三月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S4" Caption="四月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S5" Caption="五月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S6" Caption="六月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S7" Caption="七月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S8" Caption="八月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S9" Caption="九月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S10" Caption="十月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S11" Caption="十一月"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="S12" Caption="十二月"></dx:GridViewDataTextColumn>
        </Columns>
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="S1" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S2" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S3" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S4" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S5" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S6" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S7" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S8" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S9" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S10" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S11" SummaryType="Sum" DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="S12" SummaryType="Sum" DisplayFormat="{0,2}"/>
        </TotalSummary>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ReportData"
        SelectMethod="Report4" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="cCusName" Type="String" />
            <asp:Parameter Name="cInvCName" Type="String" />
            <asp:Parameter Name="sDate" Type="String" />
            <asp:Parameter Name="eDate" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div class="div1">
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Width="800px" Height="400px">
        </dxchartsui:WebChartControl>
    </div>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="ASPxGridView2" runat="server">
    </dx:ASPxGridViewExporter>
</asp:Content>
