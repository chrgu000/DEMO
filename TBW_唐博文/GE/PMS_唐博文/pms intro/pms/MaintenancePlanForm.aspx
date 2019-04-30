<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenancePlanForm.aspx.cs" Inherits="PMMWS.WebForm1" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>
<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>M.PlanForm</title>
    <style type="text/css">
        .style1
        {
            width: 30%;
            height: 43px;
        }
        .style2
        {
            width: 23%;
            height: 43px;
        }
        .style3
        {
            height: 43px;
        }
    </style>
</head>
<script type="text/javascript">
    // dGrid1
    var timeout;
    function scheduleGridUpdate(grid) {
        window.clearTimeout(timeout);
        timeout = window.setTimeout(
                function () { grid.Refresh(); },
                60000
            );
    }
    function grid_Init(s, e) {
        scheduleGridUpdate(s);
    }
    function grid_BeginCallback(s, e) {
        window.clearTimeout(timeout);
    }
    function grid_EndCallback(s, e) {
        scheduleGridUpdate(s);
    }
    //dGrid2
    var timeout1;
    function scheduleGridUpdate1(grid) {
        window.clearTimeout(timeout1);
        timeout1 = window.setTimeout(
                function () { grid.Refresh(); },
                61000
            );
    }
    function grid_Init1(s, e) {
        scheduleGridUpdate1(s);
    }
    function grid_BeginCallback1(s, e) {
        window.clearTimeout(timeout1);
    }
    function grid_EndCallback1(s, e) {
        scheduleGridUpdate1(s);
    }
    //dGrid3
    var timeout2;
    function scheduleGridUpdate2(grid) {
        window.clearTimeout(timeout2);
        timeout2 = window.setTimeout(
                function () { grid.Refresh(); },
                62000
            );
    }
    function grid_Init2(s, e) {
        scheduleGridUpdate2(s);
    }
    function grid_BeginCallback2(s, e) {
        window.clearTimeout(timeout2);
    }
    function grid_EndCallback2(s, e) {
        scheduleGridUpdate2(s);
    }
    //dGrid4
    var timeout3;
    function scheduleGridUpdate3(grid) {
        window.clearTimeout(timeout3);
        timeout3 = window.setTimeout(
                function () { grid.Refresh(); },
                63000
            );
    }
    function grid_Init3(s, e) {
        scheduleGridUpdate3(s);
    }
    function grid_BeginCallback3(s, e) {
        window.clearTimeout(timeout3);
    }
    function grid_EndCallback3(s, e) {
        scheduleGridUpdate3(s);
    }
    //Fauced Row changed 
    function RedirecttoUrl() {
        dGrid1.GetSelectedFieldValues('OrderId', OnGetRowValues);
    }
    function OnGetRowValues(values) {
        if (values != "") {
            var url = "MaintenanceWebInfo.aspx?OrderId=" + values;
            window.location = url;
        }
        else {
            alert("请选择一条数据");
        }
    }
    //
    function RedirecttoUrl1() {
        dGrid2.GetSelectedFieldValues('OrderId', OnGetRowValues1);
    }
    function OnGetRowValues1(values) {
        if (values != "") {
            var url = "MaintenanceWebInfoB.aspx?OrderId=" + values;
            window.location = url;
        }
        else {
            alert("请选择一条数据");
        }
    }
    //
    function RedirecttoUrl2() {
        dGrid3.GetSelectedFieldValues('OrderId', OnGetRowValues2);
    }
    function OnGetRowValues2(values) {
        if (values != "") {
            var url = "MaintenanceWebInfoC.aspx?OrderId=" + values;
            window.location = url;
        }
        else {
            alert("请选择一条数据");
        }
    }
    //
    function RedirecttoUrl3() {
        dGrid4.GetSelectedFieldValues('OrderId', OnGetRowValues3);
    }

    function OnGetRowValues3(values) {
        if (values != "") {
            var url = "MaintenanceWebInfoD.aspx?OrderId=" + values;
            window.location = url;
        }
        else {
            alert("请选择一条数据");
        }
    }

    // ]]> 
</script>

<body>
    <form id="form1" runat="server">
    <div>
    <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
    <tr align="center">
        <td width="100%" colspan="4">
            <uc1:TitleControl ID="TitleControl1" runat="server" />     
        </td>
    </tr>
     <tr>
        <td class="style1">
            <strong style="font-size: x-large; color: #0000CC"> 停机故障跟踪:ShutDown Track</strong></td>
        <td align="left" width="25%" class="style3">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/StatuesColor/Red.png" 
                Width="100px" Height="100%" />
            <strong>尚未开始维修ShutDown</strong></td>
    
        <td align="left" class="style2">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/StatuesColor/Yellow.png" 
                Width="100px" Height="100%" />
            <strong>正在维修Repairing</strong></td>
        <td class="style3">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/StatuesColor/Green.png" 
                Width="100px" Height="100%" />
            <strong>已完成维修Finished</strong></td>
     </tr>
     <tr style="background-color: #C0C0C0"> 
       <td colspan="4" align="center">
         
    <dx:ASPxGridView runat="server" ClientInstanceName="dGrid1" 
             AutoGenerateColumns="False" ID="xOrderGridView" Width="1024px" 
               Caption="MA.机加工区" KeyFieldName="OrderId" 
               onhtmlrowprepared="xOrderGridView_HtmlRowPrepared" 
               oncustomcolumndisplaytext="xOrderGridView_CustomColumnDisplayText"> 

   <ClientSideEvents Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback" />
<ClientSideEvents BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback" 
            Init="grid_Init"></ClientSideEvents>
       <Columns>
<dx:GridViewDataTextColumn Caption="区域"  FieldName="MachineType"
         VisibleIndex="0"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MachineCode" 
                Caption="设备编号" VisibleIndex="1"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="FaultInfo" 
                Caption="报修描述" VisibleIndex="2"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="AlarmCode" 
                Caption="报警号" VisibleIndex="3"></dx:GridViewDataTextColumn>
           <dx:GridViewDataDateColumn Caption="报修时间" FieldName="ST" SortIndex="0" 
               SortOrder="Descending" VisibleIndex="4">
           </dx:GridViewDataDateColumn>
<dx:GridViewDataTextColumn FieldName="Statues" Caption="是否处理" VisibleIndex="5" 
               Visible="False"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="OrderId" Caption="Order_Id" VisibleIndex="6" 
               Visible="False"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="开始维修时间" FieldName="MST" VisibleIndex="8">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="结束维修时间" FieldName="MCT" 
               VisibleIndex="9">
           </dx:GridViewDataTextColumn>
<dx:GridViewCommandColumn ShowSelectCheckbox="True" 
                Caption="选择" VisibleIndex="10"></dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn Caption="维修工Id" FieldName="WorkerId" 
               VisibleIndex="7">
           </dx:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
        <SettingsLoadingPanel Mode="Disabled" />

<SettingsLoadingPanel Mode="Disabled"></SettingsLoadingPanel>
</dx:ASPxGridView>
       </td>
    </tr>
    <tr align="left">  
    <td align="left" colspan="4">

     <dx:ASPxButton ID="ASPxButton1" runat="server" ClientIDMode="AutoID" 
            Text="WorkOrderInfo机加工区工单维护" Width="200px" AutoPostBack="False" >
     <ClientSideEvents Click="function(s, e) {
	RedirecttoUrl();
}" />
    </dx:ASPxButton>

    </td>
    </tr>
    <tr>  
    <td  colspan="4" align="center">

    <dx:ASPxGridView runat="server" ClientInstanceName="dGrid2" 
             AutoGenerateColumns="False" ID="xOrderGridView0" Width="1024px" 
            Caption="SM.板金件区" KeyFieldName="OrderId" 
            onhtmlrowprepared="xOrderGridView0_HtmlRowPrepared" 
            oncustomcolumndisplaytext="xOrderGridView0_CustomColumnDisplayText"> 
         <ClientSideEvents Init="grid_Init1" BeginCallback="grid_BeginCallback1" EndCallback="grid_EndCallback1" />
       <Columns>
<dx:GridViewDataTextColumn Caption="区域"  FieldName="MachineType"
         VisibleIndex="0"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MachineCode" 
                Caption="设备编号" VisibleIndex="1"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="FaultInfo" 
                Caption="报修描述" VisibleIndex="2"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="AlarmCode" 
                Caption="报警号" VisibleIndex="3"></dx:GridViewDataTextColumn>
<dx:GridViewDataDateColumn FieldName="ST" Caption="报修时间" 
                VisibleIndex="4" SortIndex="0" SortOrder="Descending">
</dx:GridViewDataDateColumn>
<dx:GridViewDataTextColumn FieldName="Statues" Caption="是否处理" VisibleIndex="5" 
               Visible="False"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="Order_Id" FieldName="OrderId" 
               Visible="False" VisibleIndex="6">
           </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MST" Caption="开始维修时间" VisibleIndex="8"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="结束维修时间" FieldName="MCT" VisibleIndex="9">
           </dx:GridViewDataTextColumn>
<dx:GridViewCommandColumn ShowSelectCheckbox="True" 
                Caption="选择" VisibleIndex="10"></dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn Caption="维修工Id" FieldName="WorkerId" 
               VisibleIndex="7">
           </dx:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
         <SettingsLoadingPanel Mode="Disabled" />
</dx:ASPxGridView>

    </td>
    </tr>
    <tr>
     <td align="left" colspan="4">
            
     <dx:ASPxButton ID="ASPxButton2" runat="server" ClientIDMode="AutoID" 
            Text="WorkOrderInfo板金件区工单维护" Width="200px" AutoPostBack="False">
         <ClientSideEvents Click="function(s, e) {
	RedirecttoUrl1();
}" />
    </dx:ASPxButton>

        </td>
    </tr>
    <tr>
        <td colspan="4" align="center">
            
    <dx:ASPxGridView runat="server" ClientInstanceName="dGrid3" 
             AutoGenerateColumns="False" ID="xOrderGridView1" Width="1024px" 
                Caption="CM.复合材料区" KeyFieldName="OrderId" 
                onhtmlrowprepared="xOrderGridView1_HtmlRowPrepared" 
                oncustomcolumndisplaytext="xOrderGridView1_CustomColumnDisplayText"> 
      <ClientSideEvents Init="grid_Init2" BeginCallback="grid_BeginCallback2" EndCallback="grid_EndCallback2" />
       <Columns>
<dx:GridViewDataTextColumn ShowInCustomizationForm="True" Caption="区域"  FieldName="MachineType"
         VisibleIndex="0"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MachineCode" ShowInCustomizationForm="True" 
                Caption="设备编号" VisibleIndex="1"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="FaultInfo" ShowInCustomizationForm="True" 
                Caption="报修描述" VisibleIndex="2"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="AlarmCode" ShowInCustomizationForm="True" 
                Caption="报警号" VisibleIndex="3"></dx:GridViewDataTextColumn>
<dx:GridViewDataDateColumn FieldName="ST" ShowInCustomizationForm="True" Caption="报修时间" 
                VisibleIndex="4" SortIndex="0" SortOrder="Descending">
<PropertiesDateEdit DisplayFormatString="yyyy/mm/dd hh:MM:ss"></PropertiesDateEdit>
</dx:GridViewDataDateColumn>
<dx:GridViewDataTextColumn FieldName="Statues" Caption="是否处理" VisibleIndex="5" 
                ShowInCustomizationForm="True" Visible="False"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="OrderId" Caption="Order_Id" VisibleIndex="6" 
                ShowInCustomizationForm="True" Visible="False"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="开始维修时间" FieldName="MST" VisibleIndex="8">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="结束维修时间" FieldName="MCT" VisibleIndex="9">
           </dx:GridViewDataTextColumn>
<dx:GridViewCommandColumn ShowSelectCheckbox="True" ShowInCustomizationForm="True" 
                Caption="选择" VisibleIndex="10"></dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn Caption="维修工Id" FieldName="WorkerId" 
               VisibleIndex="7">
           </dx:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
        <SettingsLoadingPanel Mode="Disabled" />
</dx:ASPxGridView>

        </td>
    </tr>
    <tr>
        <td align="left" colspan="4">
            
     <dx:ASPxButton ID="ASPxButton3" runat="server" ClientIDMode="AutoID" 
            Text="WorkOrderInfo复合材料区工单维护" Width="228px"
                Height="16px" AutoPostBack="False">
         <ClientSideEvents Click="function(s, e) {
	RedirecttoUrl2();
}" />
    </dx:ASPxButton>

        </td>
    </tr>
    <tr>
        <td colspan="4" align="center">
            
    <dx:ASPxGridView runat="server" ClientInstanceName="dGrid4" 
             AutoGenerateColumns="False" ID="xOrderGridView2" Width="1024px" 
                Caption="AT.液压测试区" KeyFieldName="OrderId" 
                onhtmlrowprepared="xOrderGridView2_HtmlRowPrepared" 
                oncustomcolumndisplaytext="xOrderGridView2_CustomColumnDisplayText"> 
      <ClientSideEvents Init="grid_Init3" BeginCallback="grid_BeginCallback3" EndCallback="grid_EndCallback3" />
       <Columns>
<dx:GridViewDataTextColumn Caption="区域"  FieldName="MachineType"
         VisibleIndex="0"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MachineCode" 
                Caption="设备编号" VisibleIndex="1"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="FaultInfo" 
                Caption="报修描述" VisibleIndex="2"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="AlarmCode" 
                Caption="报警号" VisibleIndex="3"></dx:GridViewDataTextColumn>
<dx:GridViewDataDateColumn FieldName="ST" Caption="报修时间" 
                VisibleIndex="4" SortIndex="0" SortOrder="Descending">
<PropertiesDateEdit DisplayFormatString="yyyy/mm/dd hh:MM:ss"></PropertiesDateEdit>
</dx:GridViewDataDateColumn>
<dx:GridViewDataTextColumn FieldName="Statues" Caption="是否处理" VisibleIndex="5" 
               Visible="False"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="OrderId" Caption="Order_Id" VisibleIndex="6" 
               Visible="False"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="开始维修时间" FieldName="MST" VisibleIndex="8">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="结束维修时间" FieldName="MCT" VisibleIndex="9">
           </dx:GridViewDataTextColumn>
<dx:GridViewCommandColumn ShowSelectCheckbox="True" 
                Caption="选择" VisibleIndex="10"></dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn Caption="维修工Id" FieldName="WorkerId" 
               VisibleIndex="7">
           </dx:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
        <SettingsLoadingPanel Mode="Disabled" />
</dx:ASPxGridView>

        </td>
    </tr>
       <tr style="background-color: #C0C0C0">
         <td align="left" colspan="4">                

     <dx:ASPxButton ID="ASPxButton4" runat="server" ClientIDMode="AutoID" 
            Text="WorkOrderInfo液压测试区工单维护" Width="228px"
                 Height="16px" AutoPostBack="False">
         <ClientSideEvents Click="function(s, e) {
	RedirecttoUrl3();
}" />
    </dx:ASPxButton>

        </td>
    </tr>
       </table>
    </div>
    </form>
</body>
</html>
