<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PmPlan.aspx.cs" Inherits="PMMWS.PmPlan" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PM.Plan</title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
        }
.dxeIRadioButton {
	margin: 1px;
	display: inline-block;
	vertical-align: middle;
}
.dxEditors_edtRadioButtonUnchecked {
    background-position: 0px -40px;
}

.dxEditors_edtRadioButtonChecked,
.dxEditors_edtRadioButtonUnchecked,
.dxEditors_edtRadioButtonCheckedDisabled,
.dxEditors_edtRadioButtonUncheckedDisabled {
	width: 15px;
    height: 15px;
}
.dxEditors_edtError,
.dxEditors_edtCalendarPrevYear,
.dxEditors_edtCalendarPrevYearDisabled,
.dxEditors_edtCalendarPrevMonth,
.dxEditors_edtCalendarPrevMonthDisabled,
.dxEditors_edtCalendarNextMonth,
.dxEditors_edtCalendarNextMonthDisabled,
.dxEditors_edtCalendarNextYear,
.dxEditors_edtCalendarNextYearDisabled,
.dxEditors_edtCalendarFNPrevYear,
.dxEditors_edtCalendarFNNextYear,
.dxEditors_edtRadioButtonChecked,
.dxEditors_edtRadioButtonUnchecked,
.dxEditors_edtRadioButtonCheckedDisabled,
.dxEditors_edtRadioButtonUncheckedDisabled,
.dxEditors_edtEllipsis,
.dxEditors_edtEllipsisDisabled,
.dxEditors_edtDropDown,
.dxEditors_edtDropDownDisabled,
.dxEditors_edtSpinEditIncrementImage,
.dxEditors_edtSpinEditIncrementImageDisabled,
.dxEditors_edtSpinEditDecrementImage,
.dxEditors_edtSpinEditDecrementImageDisabled,
.dxEditors_edtSpinEditLargeIncImage,
.dxEditors_edtSpinEditLargeIncImageDisabled,
.dxEditors_edtSpinEditLargeDecImage,
.dxEditors_edtSpinEditLargeDecImageDisabled,
.dxEditors_fcadd,
.dxEditors_fcaddhot,
.dxEditors_fcremove,
.dxEditors_fcremovehot,
.dxEditors_fcgroupaddcondition,
.dxEditors_fcgroupaddgroup,
.dxEditors_fcgroupremove,
.dxEditors_fcopany,
.dxEditors_fcopbegin,
.dxEditors_fcopbetween,
.dxEditors_fcopcontain,
.dxEditors_fcopnotcontain,
.dxEditors_fcopnotequal,
.dxEditors_fcopend,
.dxEditors_fcopequal,
.dxEditors_fcopgreater,
.dxEditors_fcopgreaterorequal,
.dxEditors_fcopnotblank,
.dxEditors_fcopblank,
.dxEditors_fcopless,
.dxEditors_fcoplessorequal,
.dxEditors_fcoplike,
.dxEditors_fcopnotany,
.dxEditors_fcopnotbetween,
.dxEditors_fcopnotlike,
.dxEditors_fcgroupand,
.dxEditors_fcgroupor,
.dxEditors_fcgroupnotand,
.dxEditors_fcgroupnotor,
.dxEditors_caRefresh {
  

}

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
            font-size: large;
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
        <td colspan="4">
             
            <uc1:TitleControl ID="TitleControl1" runat="server" />
             
        </td>
     </tr>
         <tr align="center">
        <td colspan="4">
             
            &nbsp;</td>
     </tr>
         <tr align="center">
        <td class="style1" colspan="4">
             
            <strong>设备年度保养计划表/<span class="style3">Equipments Annual PM Plan Year</span></strong></td>
     </tr>
         <tr align="center" width="1024" >
        <td class="style2" align="left" width="200">
             
            &nbsp;</td>
        <td class="style1" align="left" width="100">
             
            &nbsp;</td>
        <td class="style1" align="left" width="100">
             
            &nbsp;</td>
        <td class="style1" align="left" width="60%">
             
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                GridViewID="grid">
            </dx:ASPxGridViewExporter>
             </td>
     </tr>
         <tr align="center">
        <td class="style1" align="left" colspan="4">
             
            <dx:ASPxButton ID="ASPxButton2" runat="server" onclick="ASPxButton2_Click" 
                Text="导出到EXCEL">
            </dx:ASPxButton>
            
             </td>
     </tr>
         <tr align="center">
        <td class="style1" align="left" colspan="4">
             
            <dx:ASPxButton 
                ID="ASPxButton4" runat="server" onclick="ASPxButton4_Click" Text="查看保养内容与记录" 
                Width="148px">
            </dx:ASPxButton>
            
             <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
                ClientInstanceName="pc" HeaderText="未完成原因" PopupHorizontalAlign="WindowCenter" 
                PopupVerticalAlign="WindowCenter">
                 <ContentCollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    未完成原因：<dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Width="170px">
    </dx:ASPxTextBox>
    下次完成时间：（yyyy-MM-dd）<br /> 
    <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" 
        DisplayFormatString="yyyy-MM-dd" Width="170px">
    </dx:ASPxTextBox>
    <br />
    <dx:ASPxButton ID="ASPxButton8" runat="server" AutoPostBack="False" Text="更新" 
        Width="89px">
    </dx:ASPxButton>
                     </dx:PopupControlContentControl>
</ContentCollection>
            </dx:ASPxPopupControl>
            
             </td>
     </tr>
         <tr align="center">
        <td colspan="4">
             
                <dx1:ASPxGridView ID="grid" ClientInstanceName="grid1" runat="server"
        KeyFieldName="PMPlanId" AutoGenerateColumns="False" Width="100%" 
                        onrowupdating="grid_RowUpdating" 
                    onhtmlrowprepared="grid_HtmlRowPrepared" 
                    onhtmldatacellprepared="grid_HtmlDataCellPrepared">
        <Columns>
            <dx1:gridviewcommandcolumn VisibleIndex="0" Visible="False">
                <EditButton Visible="True" Text= "编辑" />
<EditButton Visible="True" Text="编辑"></EditButton>
            </dx1:gridviewcommandcolumn>
           <dx1:gridviewdatatextcolumn FieldName="Number" 
                Caption="序号" VisibleIndex="1" SortIndex="0" SortOrder="Ascending"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="MachineName" 
                Caption="设备名" VisibleIndex="2"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="MachineType" 
                Caption="型号" VisibleIndex="3"></dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="设备编号" FieldName="Equipments" 
                VisibleIndex="4">
            
            </dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="1" FieldName="Month1" VisibleIndex="5">
            </dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="Month2" 
                Caption="2" VisibleIndex="6"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="Month4" Caption="4" VisibleIndex="8">
            </dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="Month5" Caption="5" VisibleIndex="9">
            </dx1:gridviewdatatextcolumn>
<dx1:gridviewcommandcolumn ShowSelectCheckbox="True" Caption="选择" VisibleIndex="17">
            </dx1:gridviewcommandcolumn>
            <dx1:gridviewdatatextcolumn Caption="6" FieldName="Month6" 
                VisibleIndex="10">
            </dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="3" FieldName="Month3" VisibleIndex="7">
            </dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="7" FieldName="Month7" VisibleIndex="11">
            </dx1:gridviewdatatextcolumn>
            <dx1:GridViewDataTextColumn Caption="8" FieldName="Month8" VisibleIndex="12">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="9" FieldName="Month9" VisibleIndex="13">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="10" FieldName="Month10" VisibleIndex="14">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="11" FieldName="Month11" VisibleIndex="15">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="12" FieldName="Month12" VisibleIndex="16">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn FieldName="PMPlanId" Visible="False" 
                VisibleIndex="34" Caption="Id" ReadOnly="True">
            </dx1:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
        <SettingsEditing EditFormColumnCount="5" Mode="PopupEditForm" PopupEditFormWidth="800px" />
        <Settings ShowTitlePanel="true" ShowFilterRow="True" />
        <SettingsText Title="设备年度保养计划表" />


    </dx1:ASPxGridView>

        </td>
     </tr>
         <tr align="center">
        <td style="text-align: left" colspan="4">
             
            <strong>Comment/注释：Y：Year/年 H：Half/半年 Q：Quarter/三月 M：Month/月</strong></td>
     </tr>
         <tr align="center">
        <td style="text-align: left" colspan="4" align="left">
             
            <strong>From F 7513A-016 Issue 01</strong></td>
     </tr>
         <tr align="center">
        <td style="text-align: left" colspan="4" align="left">
             
            本月需要完成的保养设备清单：</td>
     </tr>
         <tr align="center">
        <td style="text-align: left" colspan="4" align="left">
             
            需要编辑请输入密码：</td>
     </tr>
         <tr align="left">
        <td style="text-align: left" colspan="4" align="left">
             
            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Password="True" 
                Width="100px">
            </dx:ASPxTextBox>
             
            <dx:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认">
            </dx:ASPxButton>
             </td>
     </tr>
         <tr align="left">
        <td style="text-align: left" colspan="4" align="left">
             
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" 
                GridViewID="grid0">
            </dx:ASPxGridViewExporter>
             
            <dx:ASPxButton ID="ASPxButton6" runat="server" onclick="ASPxButton6_Click" 
                Text="导出EXCEL">
            </dx:ASPxButton>
             </td>
     </tr>
         <tr align="left">
        <td style="text-align: left" colspan="4" align="left">
             
                <dx1:ASPxGridView ID="grid0" ClientInstanceName="grid1" runat="server"
        KeyFieldName="PMPlanId" AutoGenerateColumns="False" Width="80%" onrowupdating="grid0_RowUpdating" 
                     >
        <Columns>
            <dx1:gridviewcommandcolumn VisibleIndex="0" Visible="False">
                <EditButton Visible="True" Text= "编辑" />
<EditButton Visible="True" Text="编辑"></EditButton>
            </dx1:gridviewcommandcolumn>
           <dx1:gridviewdatatextcolumn FieldName="Number" 
                Caption="序号" VisibleIndex="1" SortIndex="0" SortOrder="Ascending"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="MachineName" 
                Caption="设备名" VisibleIndex="2"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="MachineType" 
                Caption="型号" VisibleIndex="3"></dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="设备编号" FieldName="Equipments" 
                VisibleIndex="4" >
            
            </dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="1月" FieldName="Month1" VisibleIndex="6" 
                Visible="False">
            </dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="Month2" 
                Caption="2月" VisibleIndex="7" Visible="False"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="Month4" Caption="4月" VisibleIndex="9" 
                Visible="False">
            </dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="Month5" Caption="5月" VisibleIndex="10" 
                Visible="False">
            </dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="6月" FieldName="Month6" VisibleIndex="11" Visible="False">
            </dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="3月" FieldName="Month3" VisibleIndex="8" 
                Visible="False">
            </dx1:gridviewdatatextcolumn>
            <dx1:gridviewdatatextcolumn Caption="7月" FieldName="Month7" VisibleIndex="12" 
                Visible="False">
            </dx1:gridviewdatatextcolumn>
            <dx1:GridViewDataTextColumn Caption="8月" FieldName="Month8" VisibleIndex="13" 
                Visible="False">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="9月" FieldName="Month9" VisibleIndex="14" 
                Visible="False">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="10月" FieldName="Month10" VisibleIndex="15" 
                Visible="False">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="11月" FieldName="Month11" VisibleIndex="16" 
                Visible="False">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="12月" FieldName="Month12" VisibleIndex="17" 
                Visible="False">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn FieldName="PMPlanId" Visible="False" 
                VisibleIndex="5" Caption="PMPlanid">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataCheckColumn Caption="是否完成" FieldName="IsDown" 
                VisibleIndex="22">
                <PropertiesCheckEdit DisplayTextChecked="是" DisplayTextUnchecked="否" 
                    AllowGrayed="True">
                </PropertiesCheckEdit>
            </dx1:GridViewDataCheckColumn>
            <dx1:GridViewDataTextColumn Caption="保养负责人" FieldName="Worker" 
                VisibleIndex="18">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="持续时间" FieldName="Duration" 
                VisibleIndex="19">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="让出时间" FieldName="StartTime" 
                VisibleIndex="20">
            </dx1:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
        <SettingsEditing EditFormColumnCount="5" Mode="PopupEditForm" PopupEditFormWidth="800px" />
        <Settings ShowTitlePanel="true" ShowFilterRow="True" />
        <SettingsText Title="设备月保养计划表" />


    </dx1:ASPxGridView>

             </td>
     </tr>
         <tr align="center">
        <td style="text-align: left" colspan="4" align="left">
             
                <strong>下月需要完成的保养设备清单：</strong></td>
     </tr>
         <tr align="left">
        <td style="text-align: left" colspan="4" align="left">
             
            <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="100%" Visible="False">
            <PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">需要编辑请输入密码：<dx:ASPxTextBox 
        ID="ASPxTextBox2" runat="server" Password="True" Width="100px">
    </dx:ASPxTextBox>
    <dx:ASPxButton ID="ASPxButton5" runat="server" OnClick="ASPxButton5_Click" 
        Text="确认">
    </dx:ASPxButton>
     
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter3" runat="server" 
        GridViewID="grid1">
    </dx:ASPxGridViewExporter>
    <dx:ASPxButton ID="ASPxButton7" runat="server" OnClick="ASPxButton7_Click" 
        Text="导出EXCEL">
    </dx:ASPxButton>
     
    <dx1:ASPxGridView ID="grid1" runat="server" AutoGenerateColumns="False" 
        ClientInstanceName="grid1" KeyFieldName="PMPlanId" 
        OnRowUpdating="grid1_RowUpdating" Width="80%">
        <Columns>
            <dx1:GridViewCommandColumn ShowInCustomizationForm="True" Visible="False" 
                VisibleIndex="0">
                <EditButton Text="编辑" Visible="True">
                </EditButton>
            </dx1:GridViewCommandColumn>
            <dx1:GridViewDataTextColumn Caption="序号" FieldName="Number" 
                ShowInCustomizationForm="True" SortIndex="0" SortOrder="Ascending" 
                VisibleIndex="1">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="设备名" FieldName="MachineName" 
                ShowInCustomizationForm="True" VisibleIndex="2">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="型号" FieldName="MachineType" 
                ShowInCustomizationForm="True" VisibleIndex="3">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="设备编号" FieldName="Equipments" 
                ShowInCustomizationForm="True" VisibleIndex="4">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="1月" FieldName="Month1" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="2月" FieldName="Month2" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="7">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="4月" FieldName="Month4" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="5月" FieldName="Month5" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="10">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="6月" FieldName="Month6" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="3月" FieldName="Month3" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="8">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="7月" FieldName="Month7" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="8月" FieldName="Month8" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="9月" FieldName="Month9" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="14">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="10月" FieldName="Month10" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="11月" FieldName="Month11" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="16">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="12月" FieldName="Month12" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="17">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="PMPlanid" FieldName="PMPlanId" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataCheckColumn Caption="是否完成" FieldName="IsDown" 
                ShowInCustomizationForm="True" Visible="False" VisibleIndex="21">
                <PropertiesCheckEdit AllowGrayed="True" DisplayTextChecked="是" 
                    DisplayTextUnchecked="否">
                </PropertiesCheckEdit>
            </dx1:GridViewDataCheckColumn>
            <dx1:GridViewDataTextColumn Caption="保养负责人" FieldName="Worker" 
                ShowInCustomizationForm="True" VisibleIndex="18">
            </dx1:GridViewDataTextColumn>
            <dx1:GridViewDataTextColumn Caption="持续时间" FieldName="Duration" 
                ShowInCustomizationForm="True" VisibleIndex="19">
            </dx1:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="True" 
            AllowSelectSingleRowOnly="True" />
        <SettingsEditing EditFormColumnCount="5" Mode="PopupEditForm" 
            PopupEditFormWidth="800px" />
        <Settings ShowFilterRow="True" ShowTitlePanel="True" />
        <SettingsText Title="设备月保养计划表" />
    </dx1:ASPxGridView>
                </dx:PanelContent>
</PanelCollection>
            </dx:ASPxPanel>

             </td>
     </tr>
         <tr align="left">
        <td style="text-align: left" colspan="4" align="left">
             
            &nbsp;</td>
     </tr>
         <tr align="center">
        <td style="text-align: left" colspan="4" align="left">
             
                &nbsp;</td>
     </tr>
     </table>
    </div>
    </form>
</body>
</html>
