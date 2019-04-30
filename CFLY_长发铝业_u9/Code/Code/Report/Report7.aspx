<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report7.aspx.cs" Inherits="Report_Report7"
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
                    <dx:ASPxButtonEdit ID="ASPxButtonEditcCus" runat="server" ClientInstanceName="ASPxButtonEditcCus"
                        RightToLeft="False">
                        <ClientSideEvents ButtonClick="ASPxButtoncCus_CheckedChanged" />
                        <Buttons>
                            <dx:EditButton>
                            </dx:EditButton>
                        </Buttons>
                    </dx:ASPxButtonEdit>
                </td>
               <%-- <td>
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="产品类别">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="ASPxTextBox4" runat="server"> 
                    </dx:ASPxTextBox>
                </td>--%>
            </tr>
        </table>
    </asp:Panel>
    <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server"
        KeyFieldName="cCusCode" DataSourceID="ObjectDataSource1" onpageindexchanged="ASPxGridView1_PageIndexChanged" 
        onprerender="ASPxGridView1_PreRender">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="cCusName" Caption="客户" Width="300"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity1" Caption="内废"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity2" Caption="外废"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity3" Caption="委外报废"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="iQuantity" Caption="报废汇总"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="outiQuantity" Caption="出货量"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Per" Caption="报废率"></dx:GridViewDataTextColumn>
        </Columns>
        <TotalSummary>
            <dx:ASPxSummaryItem FieldName="iQuantity1" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="iQuantity2" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="iQuantity3" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="iQuantity" SummaryType="Sum"  DisplayFormat="{0,2}"/>
            <dx:ASPxSummaryItem FieldName="outiQuantity" SummaryType="Sum"  DisplayFormat="{0,2}"/>
        </TotalSummary>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ReportData"
        SelectMethod="Report7" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
           <asp:Parameter Name="sDate" Type="String" />
            <asp:Parameter Name="eDate" Type="String" />
            <asp:Parameter Name="cCusCode" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" GridViewID="ASPxGridView1" runat="server">
    </dx:ASPxGridViewExporter>
    
    <div class="div1">
        <dx:WebChartControl ID="WebChartControl1" runat="server" Width="800px" Height="400px">
        </dx:WebChartControl>
    </div>
</asp:Content>
