<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PmContents.aspx.cs" Inherits="PMMWS.PmContents" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx1" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PM.Content</title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            height: 22px;
        }

.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
.dxeButtonEdit .dxeEditArea {
    background-color: white;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}
.dxeEditAreaSys
{
	width: 100%;
}

.dxeEditAreaSys, .dxeEditAreaNotStrechSys
{
	border: 0px!important;
	padding: 0px;
}
.dxeButtonEditButton,
.dxeSpinIncButton,
.dxeSpinDecButton,
.dxeSpinLargeIncButton,
.dxeSpinLargeDecButton
{
    padding: 0px 2px 0px 3px;

    background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
.dxeButtonEditButton,
.dxeCalendarButton,
.dxeSpinIncButton,
.dxeSpinDecButton,
.dxeSpinLargeIncButton,
.dxeSpinLargeDecButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
} 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
          <tr align="center">
           <td>
               <uc1:TitleControl ID="TitleControl1" runat="server" />
           </td>
          </tr>
          <tr align="center">
           <td>
               &nbsp;</td>
          </tr>
          <tr align="center">
           <td class="style1">
               <strong>保养内容与记录/PM Contents and Records</strong></td>
          </tr>
          <tr align="center">
           <td style="text-align: left">
               <strong>机器名/Machine Name：</strong></td>
          </tr>
          <tr align="center">
           <td align="left">
               <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" SelectedIndex="0">
                   <clientsideevents selectedindexchanged="function(s, e) {
		grid1.PerformCallback();
}" />
                   <Items>
                       <dx:ListEditItem Selected="True" Text="LU-35/45" Value="LU-35/45" />
                       <dx:ListEditItem Text="DMG100U/125U" Value="DMG100U/125U" />
                       <dx:ListEditItem Text="CNC VTL" Value="CNC VTL" />
                       <dx:ListEditItem Text="MA-400" Value="MA-400" />
                       <dx:ListEditItem Text="MA-550/650" Value="MA-550/650" />
                       <dx:ListEditItem Text="OKK CNC vertical machining centers" 
                           Value="OKK CNC vertical machining centers" />
                       <dx:ListEditItem Text="斗山车床240/CNC Lathe CNC" Value="斗山车床240/CNC Lathe CNC" />
                       <dx:ListEditItem Text="斗山铣床400/CNC Machining Center" 
                           Value="斗山铣床400/CNC Machining Center" />
                       <dx:ListEditItem Text="内外圆磨床/KEL-UNIVERSAL GRINDING" 
                           Value="内外圆磨床/KEL-UNIVERSAL GRINDING" />
                   </Items>
               </dx:ASPxComboBox>
               <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                   GridViewID="grid">
               </dx:ASPxGridViewExporter>
           </td>
          </tr>
          <tr align="center">
           <td align="left">
             
            <dx1:ASPxButton ID="ASPxButton2" runat="server" onclick="ASPxButton2_Click" 
                Text="导出到EXCEL">
            </dx1:ASPxButton>
            
           </td>
          </tr>
          <tr align="center">
           <td align="left">
             
            需要编辑请输入密码：<dx1:ASPxTextBox ID="ASPxTextBox1" runat="server" Password="True" 
                Width="100px">
            </dx1:ASPxTextBox>
             
            <dx1:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认">
            </dx1:ASPxButton>
           </td>
          </tr>
          <tr align="center">
           <td align="left">
             
                <dx:ASPxGridView ID="grid" ClientInstanceName="grid1" runat="server"
        KeyFieldName="PMContentId" AutoGenerateColumns="False" Width="100%" 
                        onrowupdating="grid_RowUpdating">
        <Columns>
            <dx:gridviewcommandcolumn VisibleIndex="0" Visible="False">
                <EditButton Visible="True" Text= "编辑" />
<EditButton Visible="True" Text="编辑"></EditButton>
            </dx:gridviewcommandcolumn>
<dx:gridviewdatatextcolumn FieldName="MachineName" 
                Caption="设备名" VisibleIndex="1"></dx:gridviewdatatextcolumn>
<dx:gridviewdatatextcolumn FieldName="Contents1" 
                Caption="年保养" VisibleIndex="2"></dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="保养人" FieldName="MWorker" 
                VisibleIndex="6">
            
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="1" FieldName="Month1" VisibleIndex="7">
            </dx:gridviewdatatextcolumn>
<dx:gridviewdatatextcolumn FieldName="Month2" 
                Caption="2" VisibleIndex="8"></dx:gridviewdatatextcolumn>
<dx:gridviewdatatextcolumn FieldName="Month4" Caption="4" VisibleIndex="10">
            </dx:gridviewdatatextcolumn>
<dx:gridviewdatatextcolumn FieldName="Month5" Caption="5" VisibleIndex="11">
            </dx:gridviewdatatextcolumn>
<dx:gridviewcommandcolumn ShowSelectCheckbox="True" Caption="选择" VisibleIndex="19">
            </dx:gridviewcommandcolumn>
            <dx:gridviewdatatextcolumn Caption="6" FieldName="Month6" 
                VisibleIndex="12">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="3" FieldName="Month3" VisibleIndex="9">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="7" FieldName="Month7" VisibleIndex="13">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="8" FieldName="Month8" VisibleIndex="14">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="9" FieldName="Month9" VisibleIndex="15">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="10" FieldName="Month10" VisibleIndex="16">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="11" FieldName="Month11" VisibleIndex="17">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn Caption="12" FieldName="Month12" VisibleIndex="18">
            </dx:gridviewdatatextcolumn>
            <dx:gridviewdatatextcolumn FieldName="PMContentId" Visible="False" 
                VisibleIndex="20" Caption="PMPlanid">
            </dx:gridviewdatatextcolumn>
           <dx:gridviewdatatextcolumn FieldName="Contents2" 
                Caption="半年保养" VisibleIndex="3">
            </dx:gridviewdatatextcolumn>
            <dx:GridViewDataTextColumn Caption="季保养" FieldName="Contents3" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="月保养" FieldName="Contents4" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
        <SettingsEditing EditFormColumnCount="5" Mode="PopupEditForm" PopupEditFormWidth="800px" />
        <Settings ShowTitlePanel="true" ShowFilterRow="True" />
        <SettingsText Title="保养内容与记录" />


    </dx:ASPxGridView>

           </td>
          </tr>
          <tr align="center">
           <td align="left">
             
                Form F 7513A-017 Issue 01</td>
          </tr>
          <tr align="center">
           <td align="left">
             
                &nbsp;</td>
          </tr>
      </table>
    </div>
    </form>
</body>
</html>
