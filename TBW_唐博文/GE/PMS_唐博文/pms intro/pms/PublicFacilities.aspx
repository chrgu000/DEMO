<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicFacilities.aspx.cs" Inherits="PMMWS.PublicFacilities" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx2" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.dxeTextBox,
.dxeMemo
{
    background-color: white;
    border: solid 1px #9f9f9f;
}
.dxeTextBoxSys, .dxeMemoSys
{
    border-collapse:separate!important;
}

.dxeTextBox .dxeEditArea
{
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
        .style2
        {
            color: #000000;
            font-weight: 700;
        }
        .style3
        {
            height: 14px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" bgcolor="#CCFFFF" width="1024" border="0">
            <tr>
                <td>
                    
                    <uc1:TitleControl ID="TitleControl1" runat="server" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    
                    <strong>公用设施维修记录：</strong></td>
            </tr>
            <tr align="left">
                <td>
                    
                    <span class="style2">
             
            <dx2:ASPxButton ID="ASPxButton6" runat="server" 
                Text="厂务报修" AutoPostBack="False" Font-Bold="True" Font-Size="Large" Height="25px">
                <ClientSideEvents Click="function(s, e) {
	Popup.Show();
}" />
            </dx2:ASPxButton>
             
                                       </span></td>
            </tr>
            <tr>
                <td align ="left">
                    
                    <span class="style2">需要编辑请输入密码：<dx2:ASPxTextBox 
                        ID="ASPxTextBox1" runat="server" Password="True" Height="16px" Width="137px">
            </dx2:ASPxTextBox>
             
            <dx2:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认">
            </dx2:ASPxButton>
             
                                       <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" 
                        runat="server" GridViewID="grid">
                    </dx:ASPxGridViewExporter>
             
                                       <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" 
                        runat="server" GridViewID="grid">
                    </dx:ASPxGridViewExporter>
                    <dx:ASPxButton ID="ASPxButton4" runat="server" onclick="ASPxButton4_Click" 
                        Text="导出Excel">
                    </dx:ASPxButton>
             
                                       </span></td>
            </tr>
            <tr>
                <td align ="left">
                    
                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server"
                    KeyFieldName="WorkerId" AutoGenerateColumns="False" Width="100%" 
                    onrowupdating="grid_RowUpdating" onrowinserting="grid_RowInserting" onrowdeleting="grid_RowDeleting" 
                       >
        <Columns>
            <dx:GridViewCommandColumn Caption="操作" 
                VisibleIndex="0" Visible="False">
                <EditButton Text="编辑" Visible="True">
                </EditButton>
                <NewButton Text="添加" Visible="True">
                </NewButton>
                <DeleteButton Text="删除" Visible="True">
                </DeleteButton>
                <UpdateButton Visible="True">
                </UpdateButton>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn FieldName="MachineName" 
                Caption="设备名称" VisibleIndex="2" >
                </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="FaultReason" 
                Caption="故障原因" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="报修时间" FieldName="ST" VisibleIndex="5">
                <PropertiesTextEdit DisplayFormatInEditMode="True" ></PropertiesTextEdit>
            <Settings AllowAutoFilterTextInputTimer="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="结束时间" FieldName="CT" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MWorker" Caption="维修工" VisibleIndex="8"></dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn Caption="工单号" FieldName="WorkerId" 
                VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Contents" Caption="内容" VisibleIndex="12"></dx:GridViewDataTextColumn>

<dx:GridViewDataTextColumn FieldName="EHS" 
                Caption="EHS相关" VisibleIndex="14"></dx:GridViewDataTextColumn>
        
            <dx:GridViewDataComboBoxColumn Caption="厂务类型" FieldName="FType" 
                VisibleIndex="16">
                <PropertiesComboBox>
                    <Items>
                        <dx:ListEditItem Text="Asbestos Removal" 
                            Value="Asbestos Removal" />
                        <dx:ListEditItem Text="Assembly Operations" Value="Assembly Operations" />
                        <dx:ListEditItem Text="Blasting" Value="Blasting" />
                        <dx:ListEditItem Text="Blending" Value="Blending" />
                        <dx:ListEditItem Text="Brazing" Value="Brazing" />
                        <dx:ListEditItem Text="Business Meeting/Event/Travel" 
                            Value="Business Meeting/Event/Travel" />
                        <dx:ListEditItem Text="Cafeteria Operations" Value="Cafeteria Operations" />
                        <dx:ListEditItem Text="Chemical Production Operations" 
                            Value="Chemical Production Operations" />
                        <dx:ListEditItem Text="Cleaning Operation" Value="Cleaning Operation" />
                        <dx:ListEditItem Text="Compounding" Value="Compounding" />
                        <dx:ListEditItem Text="Compressed Gas Cylinder Operations" 
                            Value="Compressed Gas Cylinder Operations" />
                        <dx:ListEditItem Text="Confined Space Operations" 
                            Value="Confined Space Operations" />
                        <dx:ListEditItem Text="Construction" Value="Construction" />
                        <dx:ListEditItem Text="Customer Assistance" Value="Customer Assistance" />
                        <dx:ListEditItem Text="Demolition" Value="Demolition" />
                        <dx:ListEditItem Text="Disassembly operations" Value="Disassembly operations" />
                        <dx:ListEditItem Text="Electrical Work" Value="Electrical Work" />
                        <dx:ListEditItem Text="Elevated Work Operations" 
                            Value="Elevated Work Operations" />
                        <dx:ListEditItem Text="Equipment  De-Installation" 
                            Value="Equipment  De-Installation" />
                        <dx:ListEditItem Text="Equipment Installation" Value="Equipment Installation" />
                        <dx:ListEditItem Text="Extrusion" Value="Extrusion" />
                        <dx:ListEditItem Text="Flight Operations" Value="Flight Operations" />
                        <dx:ListEditItem Text="Forming" Value="Forming" />
                        <dx:ListEditItem Text="Housekeeping" Value="Housekeeping" />
                        <dx:ListEditItem Text="Inspecting" Value="Inspecting" />
                        <dx:ListEditItem Text="Laboratory Operations" Value="Laboratory Operations" />
                        <dx:ListEditItem Text="Ladder Operations" Value="Ladder Operations" />
                        <dx:ListEditItem Text="Lifting" Value="Lifting" />
                        <dx:ListEditItem Text="Loading/Unloading" Value="Loading/Unloading" />
                        <dx:ListEditItem Text="Machining" Value="Machining" />
                        <dx:ListEditItem Text="Maintenance" Value="Maintenance" />
                        <dx:ListEditItem Text="Material Handing" Value="Material Handing" />
                        <dx:ListEditItem Text="Non-Specific Site Activity" 
                            Value="Non-Specific Site Activity" />
                        <dx:ListEditItem Text="Office Work" Value="Office Work" />
                        <dx:ListEditItem Text="Packging" Value="Packging" />
                        <dx:ListEditItem Text="Pipeline Operation" Value="Pipeline Operation" />
                        <dx:ListEditItem Text="Plating" Value="Plating" />
                        <dx:ListEditItem Text="Press Operations" Value="Press Operations" />
                        <dx:ListEditItem Text="Plating" Value="Plating" />
                        <dx:ListEditItem Text="Press Operations" Value="Press Operations" />
                        <dx:ListEditItem Text="Railcar Movement" Value="Railcar Movement" />
                        <dx:ListEditItem Text="Repair" Value="Repair" />
                        <dx:ListEditItem Text="Resident Assistance" Value="Resident Assistance" />
                        <dx:ListEditItem Text="Security/Emergency Response Operations" 
                            Value="Security/Emergency Response Operations" />
                        <dx:ListEditItem Text="Shipping/Receiving" Value="Shipping/Receiving" />
                        <dx:ListEditItem Text="Surface Cleaning" Value="Surface Cleaning" />
                        <dx:ListEditItem Text="Surface Coating" Value="Surface Coating" />
                        <dx:ListEditItem Text="Testing" Value="Testing" />
                        <dx:ListEditItem Text="Vehicle Operations" Value="Vehicle Operations" />
                        <dx:ListEditItem Text="Vessel Inserting/Purging" 
                            Value="Vessel Inserting/Purging" />
                        <dx:ListEditItem Text="Waste Management" Value="Waste Management" />
                        <dx:ListEditItem Text="Welding" Value="Welding" />
                        <dx:ListEditItem Text="Woodworking" Value="Woodworking" />
                    </Items>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        
            <dx:GridViewDataTextColumn Caption="报修人" FieldName="RName" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
        
        </Columns>
<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>

<SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="800px" EditFormColumnCount="3"></SettingsEditing>
<Settings ShowTitlePanel="True" ShowFilterRow="True"></Settings>

<SettingsText Title="已完成公用设施维修记录"></SettingsText>

    </dx:ASPxGridView>

                </td>
            </tr>
            <tr>
                <td align ="left">
                    
                    <span class="style2">
                    <dx:ASPxButton ID="ASPxButton5" runat="server" onclick="ASPxButton5_Click" 
                        Text="导出Excel">
                    </dx:ASPxButton>
             
                                       </span>

                </td>
            </tr>
            <tr>
                <td>
                    
                <dx:ASPxGridView ID="grid0" ClientInstanceName="grid0" runat="server"
                    KeyFieldName="WorkerId" AutoGenerateColumns="False" Width="100%" 
                    onrowupdating="grid_RowUpdating" onrowinserting="grid_RowInserting" onrowdeleting="grid_RowDeleting" 
                       >
        <Columns>
            <dx:GridViewCommandColumn Caption="操作" 
                VisibleIndex="0" Visible="False">
                <EditButton Text="编辑" Visible="True">
                </EditButton>
                <NewButton Text="添加" Visible="True">
                </NewButton>
                <DeleteButton Text="删除" Visible="True">
                </DeleteButton>
                <UpdateButton Visible="True">
                </UpdateButton>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn FieldName="MachineName" 
                Caption="设备名称" VisibleIndex="2" >
                </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="FaultReason" 
                Caption="故障原因" VisibleIndex="3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="报修时间" FieldName="ST" VisibleIndex="5">
                <PropertiesTextEdit DisplayFormatInEditMode="True" ></PropertiesTextEdit>
            <Settings AllowAutoFilterTextInputTimer="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="结束时间" FieldName="CT" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MWorker" Caption="维修工" VisibleIndex="8"></dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn Caption="工单号" FieldName="WorkerId" 
                VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Contents" Caption="内容" VisibleIndex="12"></dx:GridViewDataTextColumn>

<dx:GridViewDataTextColumn FieldName="EHS" 
                Caption="EHS相关" VisibleIndex="14"></dx:GridViewDataTextColumn>
        
            <dx:GridViewDataComboBoxColumn Caption="厂务类型" FieldName="FType" 
                VisibleIndex="16">
                <PropertiesComboBox>
                    <Items>
                        <dx:ListEditItem Text="Asbestos Removal" Selected="True" 
                            Value="Asbestos Removal" />
                        <dx:ListEditItem Text="Assembly Operations" Value="Assembly Operations" />
                        <dx:ListEditItem Text="Blasting" Value="Blasting" />
                        <dx:ListEditItem Text="Blending" Value="Blending" />
                        <dx:ListEditItem Text="Brazing" Value="Brazing" />
                        <dx:ListEditItem Text="Business Meeting/Event/Travel" 
                            Value="Business Meeting/Event/Travel" />
                        <dx:ListEditItem Text="Cafeteria Operations" Value="Cafeteria Operations" />
                        <dx:ListEditItem Text="Chemical Production Operations" 
                            Value="Chemical Production Operations" />
                        <dx:ListEditItem Text="Cleaning Operation" Value="Cleaning Operation" />
                        <dx:ListEditItem Text="Compounding" Value="Compounding" />
                        <dx:ListEditItem Text="Compressed Gas Cylinder Operations" 
                            Value="Compressed Gas Cylinder Operations" />
                        <dx:ListEditItem Text="Confined Space Operations" 
                            Value="Confined Space Operations" />
                        <dx:ListEditItem Text="Construction" Value="Construction" />
                        <dx:ListEditItem Text="Customer Assistance" Value="Customer Assistance" />
                        <dx:ListEditItem Text="Demolition" Value="Demolition" />
                        <dx:ListEditItem Text="Disassembly operations" Value="Disassembly operations" />
                        <dx:ListEditItem Text="Electrical Work" Value="Electrical Work" />
                        <dx:ListEditItem Text="Elevated Work Operations" 
                            Value="Elevated Work Operations" />
                        <dx:ListEditItem Text="Equipment  De-Installation" 
                            Value="Equipment  De-Installation" />
                        <dx:ListEditItem Text="Equipment Installation" Value="Equipment Installation" />
                        <dx:ListEditItem Text="Extrusion" Value="Extrusion" />
                        <dx:ListEditItem Text="Flight Operations" Value="Flight Operations" />
                        <dx:ListEditItem Text="Forming" Value="Forming" />
                        <dx:ListEditItem Text="Housekeeping" Value="Housekeeping" />
                        <dx:ListEditItem Text="Inspecting" Value="Inspecting" />
                        <dx:ListEditItem Text="Laboratory Operations" Value="Laboratory Operations" />
                        <dx:ListEditItem Text="Ladder Operations" Value="Ladder Operations" />
                        <dx:ListEditItem Text="Lifting" Value="Lifting" />
                        <dx:ListEditItem Text="Loading/Unloading" Value="Loading/Unloading" />
                        <dx:ListEditItem Text="Machining" Value="Machining" />
                        <dx:ListEditItem Text="Maintenance" Value="Maintenance" />
                        <dx:ListEditItem Text="Material Handing" Value="Material Handing" />
                        <dx:ListEditItem Text="Non-Specific Site Activity" 
                            Value="Non-Specific Site Activity" />
                        <dx:ListEditItem Text="Office Work" Value="Office Work" />
                        <dx:ListEditItem Text="Packging" Value="Packging" />
                        <dx:ListEditItem Text="Pipeline Operation" Value="Pipeline Operation" />
                        <dx:ListEditItem Text="Plating" Value="Plating" />
                        <dx:ListEditItem Text="Press Operations" Value="Press Operations" />
                        <dx:ListEditItem Text="Plating" Value="Plating" />
                        <dx:ListEditItem Text="Press Operations" Value="Press Operations" />
                        <dx:ListEditItem Text="Railcar Movement" Value="Railcar Movement" />
                        <dx:ListEditItem Text="Repair" Value="Repair" />
                        <dx:ListEditItem Text="Resident Assistance" Value="Resident Assistance" />
                        <dx:ListEditItem Text="Security/Emergency Response Operations" 
                            Value="Security/Emergency Response Operations" />
                        <dx:ListEditItem Text="Shipping/Receiving" Value="Shipping/Receiving" />
                        <dx:ListEditItem Text="Surface Cleaning" Value="Surface Cleaning" />
                        <dx:ListEditItem Text="Surface Coating" Value="Surface Coating" />
                        <dx:ListEditItem Text="Testing" Value="Testing" />
                        <dx:ListEditItem Text="Vehicle Operations" Value="Vehicle Operations" />
                        <dx:ListEditItem Text="Vessel Inserting/Purging" 
                            Value="Vessel Inserting/Purging" />
                        <dx:ListEditItem Text="Waste Management" Value="Waste Management" />
                        <dx:ListEditItem Text="Welding" Value="Welding" />
                        <dx:ListEditItem Text="Woodworking" Value="Woodworking" />
                    </Items>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        
            <dx:GridViewDataTextColumn Caption="报修人" FieldName="RName" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
        
        </Columns>
<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>

<SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="800px" EditFormColumnCount="3"></SettingsEditing>
<Settings ShowTitlePanel="True" ShowFilterRow="True"></Settings>

<SettingsText Title="未完成公用设施维修记录"></SettingsText>

    </dx:ASPxGridView>

                </td>
            </tr>
            <tr>
                <td>
                    
                    <strong>注:EHS相关-化学品伤害,电击伤害,工具使用不当</strong></td>
            </tr>
            <tr>
                <td align ="left">
                    
                    <span class="style2">
             
                   <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                        HeaderText="添加新报修项目" Width="600px" ClientInstanceName="Popup" 
                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                                  

                       <ContentCollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
        <div>   
            <table border="0" cellpadding="0" cellspacing="0" width = "600">
                <tr>
                    <td width="20%">
                        <strong>设备名称:</strong></td>
                    <td>
                        <dx:ASPxTextBox ID="xMachineName" runat="server" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="style2"><strong>故障原因:</strong></span></td>
                    <td>
                        <span class="style2">
                        <dx:ASPxTextBox ID="Reason" runat="server" Width="170px">
                        </dx:ASPxTextBox>
                        </span></td>
                </tr>
                <tr>
                    <td class="style3">
                        <strong>报修</strong><span class="style2"><strong>时间:</strong></span></td>
                    <td class="style3">
                        <span class="style2">
                        <dx:ASPxTextBox ID="ReportTime" runat="server" DisplayFormatString="yyyy-MM-dd" 
                            NullText="yyyy-MM-dd" Width="170px">
                        </dx:ASPxTextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>报修人：</strong></td>
                    <td>
                        <span class="style2">
                        <dx:ASPxTextBox ID="ReportPerson" runat="server" Width="170px">
                        </dx:ASPxTextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>EHS相关：</strong></td>
                    <td>
                        <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" CheckState="Unchecked">
                            <ClientSideEvents CheckedChanged="function(s, e) {
	MyCallBack.PerformCallback();
}" />
                        </dx:ASPxCheckBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" 
                            ClientInstanceName="MyCallBack" OnCallback="ASPxCallbackPanel1_Callback" 
                            Width="100%">
                            <panelcollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <dx:ASPxListBox ID="ASPxListBox1" runat="server" SelectionMode="CheckColumn" 
                                        Visible="False" Width="100%">
                                        <Items>
                                            <dx:ListEditItem Text="1化学危害" Value="1化学危害" />
                                            <dx:ListEditItem Text="2电气危害" Value="2电气危害" />
                                            <dx:ListEditItem Text="3环境危害(废水,废气,废渣)" Value="3环境危害(废水,废气,废渣)" />
                                            <dx:ListEditItem Text="4设备安全危害" Value="4设备安全危害" />
                                            <dx:ListEditItem Text="5人机工程危害" Value="5人机工程危害" />
                                            <dx:ListEditItem Text="6火灾/烟雾危害" Value="6火灾/烟雾危害" />
                                            <dx:ListEditItem Text="7清洁整理问题" Value="7清洁整理问题" />
                                            <dx:ListEditItem Text="8辐射危害(激光,紫外线,X光)" Value="8辐射危害(激光,紫外线,X光)" />
                                            <dx:ListEditItem Text="9泄露排放危害" Value="9泄露排放危害" />
                                            <dx:ListEditItem Text="10其他不安全情况" Value="10其他不安全情况" />
                                        </Items>
                                    </dx:ASPxListBox>
                                </dx:PanelContent>
                            </panelcollection>
                        </dx:ASPxCallbackPanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <span class="style2">
                        <dx:ASPxButton ID="ASPxButton7" runat="server" AutoPostBack="False" 
                            OnClick="ASPxButton7_Click" Text="确认添加">
                            <ClientSideEvents Click="function(s, e) {

}" />
                        </dx:ASPxButton>
                        </span>
                    </td>
                </tr>
            </table>
         </div>

</dx:PopupControlContentControl>
</ContentCollection>
                                  

                    </dx:ASPxPopupControl>
             
                                       </span></td>
            </tr>
            <tr>
                <td align ="left">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td align ="left">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td align ="left">
                    
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
