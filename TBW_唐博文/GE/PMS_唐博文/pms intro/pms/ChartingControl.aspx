<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartingControl.aspx.cs" Inherits="PMMWS.ChartingControl" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>
<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.XtraCharts.v11.1.Web, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<%@ Register assembly="DevExpress.XtraReports.v11.1.Web, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
    function RedirecttoUrl() {
      
        var url = "WeekARate.aspx";
        window.open(url);  
        var url1 = "ReportView.aspx";
        window.open(url1);
    }


  </script>
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            color: #0000FF;
            font-size: x-large;
        }
        .style4
        {
            color: #0000FF;
        }
        .style5
        {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width = "1024" align="center" style="background-color: #C0C0C0" >
           <tr>
            <td colspan="2">
                
                <uc1:TitleControl ID="TitleControl1" runat="server" />
                
            </td>
           </tr>
           <tr>
            <td colspan="2">
                
                <strong><span class="style3" >选择时间：</span></strong></td>
           </tr>
           <tr>
            <td align="left" width="20%">
                
                
                <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server">
                    <ClientSideEvents ValueChanged="function(s, e) {
	Combo.PerformCallback();
}" />
                </dx:ASPxDateEdit>
                
                
                周数:<dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ClientInstanceName="Combo" 
                    oncallback="ASPxComboBox1_Callback" SelectedIndex="-1" Width="50px">
                </dx:ASPxComboBox>
                
                
               </td>
            <td align="left" width="80%">
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="Data Source=.;Initial Catalog=GE_SUZHOU;User ID=sa;Password=CTC1349s" 
                    ProviderName="System.Data.SqlClient" 
                    
                    SelectCommand="SELECT [Report_Id], [Machine_Name], [Machine_Type], [ST], [CT], [MST], [MCT], [MTime], [StopTime], [Scan_Id], [Fault_Info], [WeekNum] FROM [MA_Report] WHERE ([WeekNum] = @WeekNum)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ASPxLabel1" Name="WeekNum" PropertyName="Text" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                </td>
           </tr>
           <tr>
            <td align="left" width="20%" class="style4">
                
                <dx:ASPxButton 
                    ID="ASPxButton1" runat="server" 
                    Text="确定时间" Width="144px" AutoPostBack="False" 
                   >
                    <ClientSideEvents Click="function(s, e) {
	CallbackPanel.PerformCallback();
}" />
                </dx:ASPxButton>
                
               </td>
            <td align="left" width="80%">
                
                &nbsp;</td>
           </tr>
           <tr>
            <td align="left" width="20%" class="style4">
                
                <strong><span class="style3" >图表显示:</span></strong><dx:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="xlabel" 
                    Visible="False">
                </dx:ASPxLabel>
                
               </td>
            <td align="left" width = "80%">
                
                &nbsp;</td>
           </tr>
           <tr>
            <td colspan="2" class="style5" align="left">
                
                <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" 
                    ClientInstanceName="CallbackPanel" oncallback="ASPxCallbackPanel1_Callback" 
                    Width="80%">
                    <PanelCollection>
    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
        <dx:ASPxLabel ID="ASPxLabel2" runat="server" ClientInstanceName="xlabel" 
            style="font-size: large; font-weight: 700; margin-bottom: 0px;" Visible="False" 
            Width="500px">
        </dx:ASPxLabel>
        <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" 
            style="font-weight: 700" Text="显示" Visible="False" Width="144px">
            <ClientSideEvents Click="function(s, e) {
	RedirecttoUrl();
}" />
        </dx:ASPxButton>
                        </dx:PanelContent>
</PanelCollection>
                </dx:ASPxCallbackPanel>
                
 
                </td>
           </tr>
           <tr>
            <td colspan="2" align="center">
                
                &nbsp;</td>
           </tr>
           <tr>
            <td colspan="2" align="center">
                
                &nbsp;</td>
           </tr>
     
           <tr>
            <td align="center" colspan="2">
        
                &nbsp;</td>

               
           </tr>
           <tr>
            <td colspan="2" align="center">
                
                &nbsp;</td>
           </tr>
        </table>
    </div>
    </form>
</body>
</html>
