<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report3.aspx.cs" Inherits="Report_Report3"
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
                    <dx:ASPxLabel ID="LabelDate1" runat="server" Text="年">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server"> 
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="月">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:MonthEdit ID="MonthEdit1" runat="server">
                    </dx:MonthEdit>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div class="div1">
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Width="800px" Height="400px">
        </dxchartsui:WebChartControl>
    </div>
</asp:Content>
