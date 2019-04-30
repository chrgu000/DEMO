<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairsScan.aspx.cs" Inherits="PMMWS.RepairsScan" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <script type="text/javascript">

      function OnGridFocusedRowChanged() {

          dGrid1.GetRowValues(dGrid1.GetFocusedRowIndex(), 'MachineName', OnGetRowValues);

      }
      function OnGetRowValues(values) {

          dText.SetText(values);
      }
      </script>

    <title></title>
    <style type="text/css">
        .style1
        {
            width: 67px;
            height: 57px;
        }
        .style2
        {
            color: #3366CC;
            font-size: xx-large;
            font-family: "Times New Roman", Times, serif;
        }
        .style3
        {
            color: #000000;
            height: 16px;
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
/* for IE6 */
    background-repeat: no-repeat;
    background-color: transparent;

}

        .style4
        {
            font-family: 宋体;
        }
        .style5
        {
            color: #333300;
        }
        .style6
        {
            color: #003366;
        }
        .style7
        {
            font-family: 宋体;
            color: #003366;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
        <td colspan="2">
            <img class="style1" src="ge_logo.gif" /> <span class="style2"><strong>GE 
            Aviation SuZhou&nbsp; 设备报修条码扫描系统</strong></span></td><tr>
        <td colspan="2">
            <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" 
                Width="100%">
                <TabPages>
                    <dx:TabPage Text="报修信息扫描">
                        <ActiveTabStyle Font-Size="XX-Large">
                        </ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                            <table id = "table2" width = "1024" style="background-color: #C0C0C0" border="1">                         
                                <tr>
                                    <td class="style3" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" rowspan="9" width="60%">
                                        <strong class="style5">当前停机设备：</strong><dx1:ASPxGridView ID="xOrderGridView" runat="server" 
                                            AutoGenerateColumns="False" Caption="当前故障停机信息" ClientInstanceName="dGrid0" 
                                            KeyFieldName="ScanId" Width="100%">
                                         
                                            <Columns>
                                                <dx1:GridViewDataTextColumn Caption="区域" FieldName="MachineType" 
                                                    ShowInCustomizationForm="True" VisibleIndex="0">
                                                </dx1:GridViewDataTextColumn>
                                                <dx1:GridViewDataTextColumn Caption="设备编号" FieldName="MachineName" 
                                                    ShowInCustomizationForm="True" VisibleIndex="1">
                                                </dx1:GridViewDataTextColumn>
                                                <dx1:GridViewDataTextColumn Caption="报修描述" FieldName="FaultInfo" 
                                                    ShowInCustomizationForm="True" VisibleIndex="2">
                                                </dx1:GridViewDataTextColumn>
                                                <dx1:GridViewDataTextColumn Caption="停机时间" FieldName="ST" 
                                                    ShowInCustomizationForm="True" VisibleIndex="3">
                                                </dx1:GridViewDataTextColumn>
                                                <dx1:GridViewCommandColumn Caption="选择" ShowInCustomizationForm="True" 
                                                    ShowSelectCheckbox="True" VisibleIndex="7">
                                                </dx1:GridViewCommandColumn>
                                                <dx1:GridViewDataTextColumn FieldName="ScanId" ShowInCustomizationForm="True" 
                                                    Visible="False" VisibleIndex="5">
                                                </dx1:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" 
                                                AllowSelectSingleRowOnly="True" />
                                        </dx1:ASPxGridView>
                                        <td align="left" class="style4">
                                            <strong><span class="style6">员工信息(Employee Info):</span></strong></td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style4">
                                        <strong>工号（ID）：</strong><dx:ASPxTextBox ID="workIdTextbox" runat="server" 
                                            Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style7">
                                        <strong>设备信息（WorkCenter Info):</strong></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>编号（NO）：</strong><dx:ASPxTextBox ID="equipmentIdTextbox" runat="server" 
                                            Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>区域（BU）：</strong><dx:ASPxComboBox ID="machineBUComboBox" runat="server" 
                                            SelectedIndex="0">
                                            <Items>
                                                <dx:ListEditItem Selected="True" Text="机加工" Value="Machining" />
                                                <dx:ListEditItem Text="板金件" Value="Sheet Metal" />
                                                <dx:ListEditItem Text="复合材料" Value="Composite" />
                                                <dx:ListEditItem Text="液压测试站" Value="Actuation" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style6">
                                        <strong>故障异常描述（Fault Description）:</strong></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <dx:ASPxMemo ID="faultInfoMemo" runat="server" Height="71px" NullText="故障描述.." 
                                            Width="170px">
                                        </dx:ASPxMemo>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>报警代码（Alarm Code）:</strong><dx:ASPxTextBox ID="alarmCodeText" 
                                            runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="确认提交" 
                                            OnClick="ASPxButton1_Click" AutoPostBack="False" 
                                            EnableClientSideAPI="True">
                                            <ClientSideEvents Click="function(s, e) {
e.processOnServer = confirm('确认要提交报修信息?');
}" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                  </table>              
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="复机信息扫描">
                        <ActiveTabStyle Font-Size="XX-Large">
                        </ActiveTabStyle>
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                           <table id = "table3" width ="1024"  style="background-color: #C0C0C0" >
                            <tr>
                                <td>
                                    
                                    <table ID="table4" style="background-color: #C0C0C0" width="1024" border= "1">
                                        <tr>
                                            <td class="style3" colspan="2">
                                                <strong class="style5">当前停机设备：</strong></td>
                                        </tr>
                                        <tr>
                                            <td align="left" rowspan="4" width="60%">
                                                <dx1:ASPxGridView ID="xOrderGridView0" runat="server" 
                                                    AutoGenerateColumns="False" Caption="当前故障停机信息" ClientInstanceName="dGrid1" 
                                                    KeyFieldName="ScanId" Width="100%">
                                                    <ClientSideEvents FocusedRowChanged="function(s, e) { OnGridFocusedRowChanged(); }" />
                                                    <Columns>
                                                        <dx1:GridViewDataTextColumn Caption="区域" FieldName="MachineType" 
                                                            ShowInCustomizationForm="True" VisibleIndex="0">
                                                        </dx1:GridViewDataTextColumn>
                                                        <dx1:GridViewDataTextColumn Caption="设备编号" FieldName="MachineName" 
                                                            ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx1:GridViewDataTextColumn>
                                                        <dx1:GridViewDataTextColumn Caption="报修描述" FieldName="FaultInfo" 
                                                            ShowInCustomizationForm="True" VisibleIndex="2">
                                                        </dx1:GridViewDataTextColumn>
                                                        <dx1:GridViewDataTextColumn Caption="停机时间" FieldName="ST" 
                                                            ShowInCustomizationForm="True" VisibleIndex="3">
                                                        </dx1:GridViewDataTextColumn>
                                                        <dx1:GridViewCommandColumn Caption="选择" ShowInCustomizationForm="True" 
                                                            ShowSelectCheckbox="True" VisibleIndex="7">
                                                        </dx1:GridViewCommandColumn>
                                                        <dx1:GridViewDataTextColumn FieldName="ScanId" ShowInCustomizationForm="True" 
                                                            Visible="False" VisibleIndex="5">
                                                        </dx1:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" 
                                                        AllowSelectSingleRowOnly="True" />
                                                </dx1:ASPxGridView>
                                                <td align="left" class="style4">
                                                    <strong style="color: #003366">设备信息（WorkCenter Info):</strong></td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong>编号（NO）：</strong><dx:ASPxTextBox ID="equipmentIdTextbox2" runat="server" 
                                                    Width="170px" ClientInstanceName="dText">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <strong style="color: #003366">确认复机：</strong></td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="提交" 
                                                    OnClick="ASPxButton2_Click" AutoPostBack="False" 
                                                    EnableClientSideAPI="True">
                                                    <ClientSideEvents Click="function(s, e) {
	e.processOnServer = confirm('确认要提交复机信息?');
}" />
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                           </table>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
            </dx:ASPxPageControl>
             </tr>
                
     </table>
    </div>
    </form>
</body>
</html>
