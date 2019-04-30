<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EHSDeviceInfo.aspx.cs" Inherits="PMMWS.EHSDeviceInfo" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx1" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EHSDevice.Info</title>
    <style type="text/css">


.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
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

.dxeEditAreaSys
{
	border: 0px!important;
	padding: 0px;
}
.dxeEditAreaSys
{
	width: 100%;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
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
.dxeButtonEditButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
} 
    .dxeButtonEditButton
{
    padding: 0px 2px 0px 3px;

    background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
.dxgvControl,
.dxgvDisabled
{
	border: Solid 1px #9F9F9F;
	font: 11px Tahoma;
	background-color: #F2F2F2;
	color: Black;
	cursor: default;
}

.dxgvTable
{
	background-color: White;
	border: 0;
	border-collapse: separate!important;
	overflow: hidden;
	font: 9pt Tahoma;
	color: Black;
}

.dxgvHeader {
	cursor: pointer;
	white-space: nowrap;
	padding: 4px 6px 5px;
	border: Solid 1px #9F9F9F;
	background-color: #DCDCDC;
	overflow: hidden;
	font-weight: normal;
	text-align: left;	
}
.dxgvFilterRow 
{
	background-color: #E7E7E7;
}
.dxgvCommandColumn
{
	padding: 2px;
}
        .style2
        {
            color: #000000;
        }
        .style3
        {
            font-family: "Times New Roman", Times, serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
    <tr align="center">
        <td width="100%">
            
            <uc1:TitleControl ID="TitleControl1" runat="server" />
            
        </td>
        </tr>
    <tr align="center">
        <td width="100%" class="dxtcLeftAlignCell">
            
            <strong style="font-size: x-large; color: #0033CC">公用设备信息查询Facilities 
            Information Admin.</strong></td>
        </tr>
    <tr align="left">
        <td width="100%" class="dxtcLeftAlignCell" align="left">
            
            <dx:ASPxButton ID="ASPxButton4" runat="server" onclick="ASPxButton4_Click" 
                Text="公用设施维修Facility Maintenance" Width="200px" Height="34px" 
                Font-Bold="True" Font-Size="Large">
            </dx:ASPxButton>
            
        </td>
        </tr>
    <tr align="center">
        <td width="100%" align="left">
            
          <span class="style2">需要编辑请输入密码：<span class="style3">Please inputs password to edit</span></span><dx:ASPxTextBox 
              ID="ASPxTextBox1" runat="server" Password="True" 
                Width="100px">
            </dx:ASPxTextBox>
             
            <dx:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认OK">
            </dx:ASPxButton>
            
            <dx:ASPxButton ID="ASPxButton6" runat="server" AutoPostBack="False" 
                Text="添加新类型Add New Device Type" Visible="False" Width="237px">
                <ClientSideEvents Click="function(s, e) {
	PopupControl.Show();
}" />
            </dx:ASPxButton>
            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                ClientInstanceName="PopupControl" HeaderText="添加新设备类型New Type" 
                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                <ContentCollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    类型Type：<dx:ASPxRadioButtonList 
        ID="ASPxRadioButtonList1" runat="server">
    <Items>
        <dx:ListEditItem Text="特殊设备Special facility" Value="特殊设备" />
        <dx:ListEditItem Text="辅助设备Assistant facility" Value="辅助设备" />
    </Items>
    </dx:ASPxRadioButtonList>
    名称Name：<dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px">
    </dx:ASPxTextBox>
    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="确定Confirm" AutoPostBack="False" 
        OnClick="ASPxButton5_Click">
    </dx:ASPxButton>
                    </dx:PopupControlContentControl>
</ContentCollection>
            </dx:ASPxPopupControl>
            
            <dx:ASPxButton ID="ASPxButton7" runat="server" AutoPostBack="False" 
                Text="添加新类型Add New Device Type" Visible="False" Width="237px">
                <ClientSideEvents Click="function(s, e) {
	PopupControl.Show();
}" />
            </dx:ASPxButton>
            
        </td>
        </tr>
    <tr align="center">
        <td width="100%" align="left">
            
            <dx1:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" 
                Width="100%">
                <TabPages>
                    
                    <dx1:TabPage Text="特殊设备Special facility">
                      
                        <ContentCollection>
                   
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <Table ID="Table3" Width="100%">
                                    <tr>
                                        <td>
                                            
                                            选择类型Type：<dx:ASPxComboBox ID="ASPxComboBox3" runat="server" 
                                                ClientInstanceName="CB1">
                                                <clientsideevents selectedindexchanged="function(s, e) {
	dGrid1.performCallback();
}" />
<ClientSideEvents SelectedIndexChanged="function(s, e) {
	dGrid1.PerformCallback();
}"></ClientSideEvents>
                                            </dx:ASPxComboBox>
                                            
                                        </td>
                                    </tr>
                                </Table>
                                <dx1:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
                                    ClientInstanceName="dGrid1" KeyFieldName="PMBackupId" 
                                    OnRowInserting="ASPxGridView2_RowInserting" OnRowUpdating="grid_RowUpdating" 
                                    Width="100%">
                                    <Columns>
                                        <dx1:GridViewCommandColumn ShowInCustomizationForm="True" Visible="False" 
                                            VisibleIndex="0">
                                            <EditButton Text="编辑" Visible="True">
                                            </EditButton>
                                            <NewButton Text="添加" Visible="True">
                                            </NewButton>
                                        </dx1:GridViewCommandColumn>
                                        <dx1:GridViewDataTextColumn Caption="序号NO." FieldName="Orders" 
                                            ShowInCustomizationForm="True" VisibleIndex="1" SortIndex="0" 
                                            SortOrder="Descending">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="设备类型Type" FieldName="MachineType" 
                                            ShowInCustomizationForm="True" VisibleIndex="2">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="设备名称Name" FieldName="MachineName" 
                                            ShowInCustomizationForm="True" VisibleIndex="3">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="设备号DeviceNO." FieldName="DeviceNumber" 
                                            ShowInCustomizationForm="True" VisibleIndex="4">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="规格型号Standard" FieldName="DeviceCode" 
                                            ShowInCustomizationForm="True" VisibleIndex="5">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="测量/品种范围Range" FieldName="MeasureContents" 
                                            ShowInCustomizationForm="True" VisibleIndex="6">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="系列号（出厂编号）SeriesNO." FieldName="SeriesCode" 
                                            ShowInCustomizationForm="True" VisibleIndex="8">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="Cal.(Y/N)" FieldName="IsCal" 
                                            ShowInCustomizationForm="True" VisibleIndex="9">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewCommandColumn Caption="选择" ShowInCustomizationForm="True" 
                                            ShowSelectCheckbox="True" VisibleIndex="17">
                                        </dx1:GridViewCommandColumn>
                                        <dx1:GridViewDataTextColumn Caption="最近外检报告编号CheckNO." FieldName="ReportCode" 
                                            ShowInCustomizationForm="True" VisibleIndex="10">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="注册编号RegisterNO." FieldName="RegisterCode" 
                                            ShowInCustomizationForm="True" VisibleIndex="7">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="最近外检日期CheckTime." FieldName="CheckTime" 
                                            ShowInCustomizationForm="True" VisibleIndex="11">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="下次外检日期NextCheckTime" FieldName="NextCheckTime" 
                                            ShowInCustomizationForm="True" VisibleIndex="12">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="备注Remarks" FieldName="Frequency" 
                                            ShowInCustomizationForm="True" VisibleIndex="13">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="位置Position" FieldName="Position" 
                                            ShowInCustomizationForm="True" VisibleIndex="14">
                                        </dx1:GridViewDataTextColumn>
                                        <dx1:GridViewDataTextColumn Caption="PMPlanid" FieldName="PMBackupId" 
                                            ShowInCustomizationForm="True" Visible="False" VisibleIndex="18">
                                        </dx1:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowSelectByRowClick="True" 
                                        AllowSelectSingleRowOnly="True" />
                                    <SettingsEditing EditFormColumnCount="3" Mode="PopupEditForm" 
                                        PopupEditFormHeight="200px" PopupEditFormWidth="800px" />
                                    <Settings ShowFilterRow="True" ShowTitlePanel="True" 
                                        />
                                    <SettingsText Title="特殊设备Special facility" />
                                </dx1:ASPxGridView>
                            </dx:ContentControl>
                            
                        </ContentCollection>
                    </dx1:TabPage>
                    
                    <dx1:TabPage Text="辅助设备Assistant facility">
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <table id="Table4" width="100%">
                                    <tr>
                                        <td>
                                            选择类型Type：<dx:ASPxComboBox ID="ASPxComboBox4" runat="server" 
                                                ClientInstanceName="CB2">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dGrid2.PerformCallback();
}" />
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx1:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" 
                                                ClientInstanceName="dGrid2" KeyFieldName="PMBackupId" 
                                                OnRowInserting="ASPxGridView3_RowInserting" OnRowUpdating="ASPxGridView3_RowUpdating" 
                                                Width="100%">
                                                <Columns>
                                                    <dx1:GridViewCommandColumn ShowInCustomizationForm="True" Visible="False" 
                                                        VisibleIndex="0">
                                                        <editbutton text="编辑" visible="True">
                                                        </editbutton>
                                                        <newbutton text="添加" visible="True">
                                                        </newbutton>
                                                    </dx1:GridViewCommandColumn>
                                                    <dx1:GridViewDataTextColumn Caption="序号NO." FieldName="Orders" 
                                                        ShowInCustomizationForm="True" VisibleIndex="1" SortIndex="0" 
                                                        SortOrder="Descending">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="设备类型Type" FieldName="MachineType" 
                                                        ShowInCustomizationForm="True" VisibleIndex="2">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="设备名称Name" FieldName="MachineName" 
                                                        ShowInCustomizationForm="True" VisibleIndex="3">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="设备号DeviceNO." FieldName="DeviceNumber" 
                                                        ShowInCustomizationForm="True" VisibleIndex="4">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="规格型号Standard" FieldName="DeviceCode" 
                                                        ShowInCustomizationForm="True" VisibleIndex="5">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="检查内容CheckContents" FieldName="MeasureContents" 
                                                        ShowInCustomizationForm="True" VisibleIndex="6">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewCommandColumn Caption="选择" ShowInCustomizationForm="True" 
                                                        ShowSelectCheckbox="True" VisibleIndex="11">
                                                    </dx1:GridViewCommandColumn>
                                                    <dx1:GridViewDataTextColumn Caption="保养频率/保养单位Frequency" FieldName="ReportCode" 
                                                        ShowInCustomizationForm="True" VisibleIndex="7">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="最近保养日期CheckTime" FieldName="CheckTime" 
                                                        ShowInCustomizationForm="True" VisibleIndex="8">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="厂房Factory" FieldName="Frequency" 
                                                        ShowInCustomizationForm="True" VisibleIndex="9">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="位置Position" FieldName="Position" 
                                                        ShowInCustomizationForm="True" VisibleIndex="10">
                                                    </dx1:GridViewDataTextColumn>
                                                    <dx1:GridViewDataTextColumn Caption="PMPlanid" FieldName="PMBackupId" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="18">
                                                    </dx1:GridViewDataTextColumn>
                                                </Columns>
                                                <settingsbehavior allowselectbyrowclick="True" 
                                                    allowselectsinglerowonly="True" />
                                                <settingsediting editformcolumncount="3" mode="PopupEditForm" 
                                                    popupeditformheight="200px" popupeditformwidth="800px" />
                                                <settings showfilterrow="True" showtitlepanel="True" 
                                                     />
                                                <settingstext title="辅助设备Assistant facility" />
                                            </dx1:ASPxGridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="ASPxButton9" runat="server" AutoPostBack="False" 
                                                OnClick="ASPxButton9_Click" Text="更改所有保养日期" Width="237px">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx1:TabPage>
                </TabPages>
            </dx1:ASPxPageControl>
            
        </td>
        </tr>
    <tr align="center">
        <td width="100%" align="left">
            
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="删除设备信息Delete" 
                        Visible="False" Width="144px" />
            
        </td>
        </tr>
    <tr align="center">
        <td width="100%" align="left">
            
            <dx:ASPxButton ID="ASPxButton8" runat="server" AutoPostBack="False" 
                Text="导出全部数据Export to Excel" onclick="ASPxButton8_Click" Width="237px">
            </dx:ASPxButton>
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                GridViewID="ASPxGridView4">
            </dx:ASPxGridViewExporter>
            
        </td>
        </tr>
    <tr align="center">
        <td width="100%" align="left">
            
            <dx1:ASPxGridView runat="server" ClientInstanceName="dGrid3" 
                KeyFieldName="PMBackupId" AutoGenerateColumns="False" Width="100%" 
                ID="ASPxGridView4" OnRowInserting="ASPxGridView2_RowInserting" 
                OnRowUpdating="grid_RowUpdating">
                <Columns>
                    <dx1:GridViewCommandColumn ShowInCustomizationForm="True" Visible="False" 
                        VisibleIndex="0">
                        <EditButton Visible="True" Text="编辑">
                        </EditButton>
                        <NewButton Visible="True" Text="添加">
                        </NewButton>
                    </dx1:GridViewCommandColumn>
                    <dx1:GridViewDataTextColumn FieldName="Orders" ShowInCustomizationForm="True" 
                        Caption="序号NO." VisibleIndex="1">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="MachineType" 
                        ShowInCustomizationForm="True" Caption="设备类型Type" VisibleIndex="2">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="MachineName" 
                        ShowInCustomizationForm="True" Caption="设备名称Name" VisibleIndex="3">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="DeviceNumber" 
                        ShowInCustomizationForm="True" Caption="设备号DeviceNO." VisibleIndex="4">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="DeviceCode" 
                        ShowInCustomizationForm="True" Caption="规格型号Standard" VisibleIndex="5">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="MeasureContents" 
                        ShowInCustomizationForm="True" Caption="测量/品种范围Range" VisibleIndex="6">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="SeriesCode" 
                        ShowInCustomizationForm="True" Caption="系列号（出厂编号）SeriesNO." VisibleIndex="8">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="IsCal" ShowInCustomizationForm="True" 
                        Caption="Cal.(Y/N)" VisibleIndex="9">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewCommandColumn ShowSelectCheckbox="True" 
                        ShowInCustomizationForm="True" Caption="选择" VisibleIndex="17">
                    </dx1:GridViewCommandColumn>
                    <dx1:GridViewDataTextColumn FieldName="ReportCode" 
                        ShowInCustomizationForm="True" Caption="最近外检报告编号CheckNO." VisibleIndex="10">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="RegisterCode" 
                        ShowInCustomizationForm="True" Caption="注册编号RegisterNO." VisibleIndex="7">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="CheckTime" 
                        ShowInCustomizationForm="True" Caption="最近外检日期CheckTime." VisibleIndex="11">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="NextCheckTime" 
                        ShowInCustomizationForm="True" Caption="下次外检日期NextCheckTime" VisibleIndex="12">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="Frequency" 
                        ShowInCustomizationForm="True" Caption="备注Remarks" VisibleIndex="13">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="Position" ShowInCustomizationForm="True" 
                        Caption="位置Position" VisibleIndex="14">
                    </dx1:GridViewDataTextColumn>
                    <dx1:GridViewDataTextColumn FieldName="PMBackupId" 
                        ShowInCustomizationForm="True" Caption="PMPlanid" Visible="False" 
                        VisibleIndex="18">
                    </dx1:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True">
                </SettingsBehavior>
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="800px" 
                    PopupEditFormHeight="200px" EditFormColumnCount="3">
                </SettingsEditing>
                <Settings ShowTitlePanel="True" ShowFilterRow="True">
                </Settings>
                <SettingsText Title="全部设备All facilities">
                </SettingsText>
            </dx1:ASPxGridView>
            
        </td>
        </tr>
    <tr align="center">
        <td width="100%" align="left">
            
            &nbsp;</td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
