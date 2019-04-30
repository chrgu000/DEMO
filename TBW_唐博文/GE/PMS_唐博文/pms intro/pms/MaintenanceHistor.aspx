<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceHistor.aspx.cs" Inherits="PMMWS.MaintenanceHistor" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>M.HistoryInfo</title>

</head>
<body>
    <form id="form1" runat="server">
   <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
    <tr align="center">
        <td>
              <uc1:TitleControl ID="TitleControl1" runat="server" />
        </td>
     </tr>
    <tr align="center">
        <td align="left">
              <strong style="font-size: x-large; color: #0033CC">查询历史维修记录请选择区域</strong>
            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" SelectedIndex="0">
 <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dGrid1.PerformCallback(s.GetValue());
}" />
<ClientSideEvents SelectedIndexChanged="function(s, e) {
	dGrid1.PerformCallback(s.GetValue());
}"></ClientSideEvents>
                  <Items>
                      <dx:ListEditItem Selected="True" Text="机加工区" Value="MA" />
                      <dx:ListEditItem Text="板金件区" Value="SM" />
                      <dx:ListEditItem Text="复合材料区" Value="CM" />
                      <dx:ListEditItem Text="液压测试区" Value="HP" />
                      <dx:ListEditItem Text="全部" Value="All" />
                  </Items>
            </dx:ASPxComboBox>
            
              <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                  GridViewID="xOrderGridView">
              </dx:ASPxGridViewExporter>
        </td>
     </tr>
    <tr align="center">
        <td align="left">
              <dx:ASPxButton ID="ASPxButton1" runat="server" onclick="ASPxButton1_Click" 
                  Text="导出到Excel">
              </dx:ASPxButton>
        </td>
     </tr>
    <tr align="center">
        <td>
         
    <dx:ASPxGridView runat="server" ClientInstanceName="dGrid1" 
            KeyFieldName="OrderId" AutoGenerateColumns="False" ID="xOrderGridView" 
                Width="1024px" Caption="已完成的历史维护数据：" 
                oncustomcallback="xOrderGridView_CustomCallback" 
                oncustomcolumndisplaytext="xOrderGridView_CustomColumnDisplayText">
        <Columns>
<dx:GridViewDataTextColumn FieldName="MachineCode" 
                Caption="设备编号" VisibleIndex="1"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="FaultInfo" 
                Caption="报修描述" VisibleIndex="3"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="AlarmCode" 
                Caption="报警号" VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="报修时间" FieldName="ST" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="结束时间" FieldName="CT" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Operator" 
                Caption="操作工" VisibleIndex="4"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MST" Caption="维修开始时间" VisibleIndex="6"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MCT" Caption="维修结束时间" VisibleIndex="7"></dx:GridViewDataTextColumn>
<dx:GridViewCommandColumn ShowSelectCheckbox="True" Caption="选择" VisibleIndex="10"></dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="故障类型" FieldName="FaultType" 
                VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OrderId" 
                VisibleIndex="0" Caption="序号" SortIndex="0" SortOrder="Descending">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="维修工Id" FieldName="WorkerId" 
                VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="维修方法" FieldName="Remedy" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
</Columns>
<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
<Settings ShowFilterRow="True"></Settings>
</dx:ASPxGridView>
        </td>
     </tr>
    </table>
    
    </form>
</body>
</html>
