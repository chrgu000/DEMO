<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ld.aspx.cs" Inherits="PMMWS.ld" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxScheduler.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>

<%@ Register assembly="DevExpress.Web.ASPxScheduler.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler.Controls" tagprefix="dxwschsc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  <script type="text/javascript">
    // <![CDATA[
      function ValidateDates() {
          var startDate = EdtStart.GetDate();
          var endDate = EdtEnd.GetDate();
          EdtStart.SetDate(startDate);
          EdtEnd.SetDate(endDate);
          if (endDate < startDate)
              EdtEnd.SetDate(startDate);
      }
    // ]]> 
    </script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 42px;
            height: 35px;
            margin-right: 0px;
        }
        .style3
        {
            width: 114px;
        }
        .style4
        {
            width: 1px;
        }
        .style6
        {
            width: 83px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: 'Times New Roman', Times, serif; font-size: medium; font-weight: bold; font-style: normal; background-image: none; color: #0000FF; background-color: #C0C0C0;">

    <img alt="" class="style1" src="TitleImage/ge_logo.gif" height ="30px" />Welcome to 
        PMMS </div>
 
    <div align="right" style="background-color: #000066">

    <div align="left">
        
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" 
            ClientIDMode="AutoID" Width="100%">
            <TabPages>
                <dx:TabPage Name="Tab1" Text="当前选定日期所有工单">
                    <ContentCollection>
                        <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">
                           
                           <div align="left" 
                                style="background-color: #C0C0C0; font-style: normal; font-weight: bold;">
                         
                             
                               历史工单查询时间<table cellpadding="5" cellspacing="0" width="100%">
                                   <tr align="left">
                                       <td align="right" class="style4" style="height: 50px">
                                           从：</td>
                                       <td class="style3" style="height: 50px">
                                           <dx:ASPxDateEdit ID="dateTimePicker1" runat="server" ClientIDMode="AutoID" 
                                               ClientInstanceName="EdtStart" DisplayFormatString="yyyy-MM-dd hh:mm:ss" 
                                               Width="150px" EditFormat="Custom" EditFormatString="yyyy-MM-dd hh:mm:ss">
                                               <ClientSideEvents DateChanged="function(s, e) {
ValidateDates();
dGrid2.PerformCallback(s.GetValue());
}" />
                                           </dx:ASPxDateEdit>
                                       </td>
                                       <td class="style6" style="height: 50px">
                                           &nbsp;</td>
                                       <td style="height: 50px">
                                           &nbsp;</td>
                                       <td style="height: 50px">
                                           &nbsp;</td>
                                   </tr>
                                   <tr align="left">
                                       <td align="right" class="style4">
                                           至：</td>
                                       <td class="style3">
                                           <dx:ASPxDateEdit ID="dateTimePicker2" runat="server" ClientIDMode="AutoID" 
                                               ClientInstanceName="EdtEnd" DisplayFormatString="yyyy-MM-dd hh:mm:ss" 
                                               Width="150px" EditFormat="Custom" EditFormatString="yyyy-MM-dd hh:mm:ss" 
                                               EnableClientSideAPI="True">
                                               <ClientSideEvents DateChanged="function(s, e) {
   ValidateDates();
dGrid2.PerformCallback(s.GetValue());
}" />
                                           </dx:ASPxDateEdit>
                                       </td>
                                       <td class="style6" align="left">
                                           &nbsp;</td>
                                       <td colspan="2">
                                           &nbsp;</td>
                                   </tr>
                               </table>
                         
                             
                              </div>
                       
                            <div align="right" style="background-color: #C0C0C0">
                                 <div style="background-color: #FFFFCC; font-family: 黑体; font-size: medium; color: #000000;" 
                                align="left">
                                     未完成工单 
                            </div>
                                 <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                                     ClientIDMode="AutoID" ClientInstanceName="dGrid1" KeyFieldName="WorkOrderNo" 
                                     Width="90%"
                                   >
                                     <Columns>
                                         <dx:GridViewDataTextColumn Caption="工单号" FieldName="WorkOrderNo" 
                                             ShowInCustomizationForm="True" VisibleIndex="0">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="机床名称" FieldName="Machine" 
                                             ShowInCustomizationForm="True" VisibleIndex="1">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="部门" FieldName="COE" 
                                             ShowInCustomizationForm="True" VisibleIndex="2">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="报修时间" FieldName="ReportTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="3">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="描述" FieldName="Description" 
                                             ShowInCustomizationForm="True" VisibleIndex="4">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="工单类型" FieldName="MalfunctionType" 
                                             ShowInCustomizationForm="True" VisibleIndex="5">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="组长" FieldName="GroupLeader" 
                                             ShowInCustomizationForm="True" VisibleIndex="6">
                                   
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="是否停机" FieldName="IsStop" 
                                             ShowInCustomizationForm="True" VisibleIndex="7">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataDateColumn Caption="开始时间" FieldName="AlarmStartTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="8">
                                             <PropertiesDateEdit DisplayFormatString="">
                                             </PropertiesDateEdit>
                                         </dx:GridViewDataDateColumn>
                                         <dx:GridViewDataDateColumn Caption="结束时间" FieldName="AlarmEndTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="9">
                                             <PropertiesDateEdit DisplayFormatString="">
                                             </PropertiesDateEdit>
                                         </dx:GridViewDataDateColumn>
                                         <dx:GridViewDataTextColumn Caption="停机时间" FieldName="StopTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="10">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="报警号" FieldName="AlarmCode" 
                                             ShowInCustomizationForm="True" VisibleIndex="11">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewCommandColumn Caption="选择" ShowInCustomizationForm="True" 
                                             ShowSelectCheckbox="True" VisibleIndex="12">
                                         </dx:GridViewCommandColumn>
                                     </Columns>
                                     <SettingsBehavior AllowSelectByRowClick="True" 
                                         AllowSelectSingleRowOnly="True" />
                                     <Settings ShowFilterRow="True" />
                                 </dx:ASPxGridView>
                                &nbsp;&nbsp;&nbsp;
                            </div>
                            <div style="background-color: #CCCCFF; font-family: 黑体; font-size: medium; color: #000000;">
                                已完成工单</div>
                            <div align="right" style="background-color: #C0C0C0">
                                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
                                    ClientIDMode="AutoID" ClientInstanceName="dGrid2" 
                        
                                    OnCustomCallback="ASPxGridView2_CustomCallback" Width="90%" 
                                   >
                                   <Columns>
                                         <dx:GridViewDataTextColumn Caption="工单号" FieldName="WorkOrderNo" 
                                             ShowInCustomizationForm="True" VisibleIndex="0">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="机床名称" FieldName="Machine" 
                                             ShowInCustomizationForm="True" VisibleIndex="1">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="部门" FieldName="COE" 
                                             ShowInCustomizationForm="True" VisibleIndex="2">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="报修时间" FieldName="ReportTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="3">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="描述" FieldName="Description" 
                                             ShowInCustomizationForm="True" VisibleIndex="4">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="工单类型" FieldName="MalfunctionType" 
                                             ShowInCustomizationForm="True" VisibleIndex="5">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="组长" FieldName="GroupLeader" 
                                             ShowInCustomizationForm="True" VisibleIndex="6">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="是否停机" FieldName="IsStop" 
                                             ShowInCustomizationForm="True" VisibleIndex="7">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataDateColumn Caption="开始时间" FieldName="AlarmStartTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="8">
                                             <PropertiesDateEdit DisplayFormatString="">
                                             </PropertiesDateEdit>
                                         </dx:GridViewDataDateColumn>
                                         <dx:GridViewDataDateColumn Caption="结束时间" FieldName="AlarmEndTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="9">
                                             <PropertiesDateEdit DisplayFormatString="">
                                             </PropertiesDateEdit>
                                         </dx:GridViewDataDateColumn>
                                         <dx:GridViewDataTextColumn Caption="停机时间" FieldName="StopTime" 
                                             ShowInCustomizationForm="True" VisibleIndex="10">
                                         </dx:GridViewDataTextColumn>
                                         <dx:GridViewDataTextColumn Caption="报警号" FieldName="AlarmCode" 
                                             ShowInCustomizationForm="True" VisibleIndex="11">
                                         </dx:GridViewDataTextColumn>
                                     </Columns>
                                    <Settings ShowFilterRow="True" />
                                </dx:ASPxGridView>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Name="Tab2" Text="月计划工单查询">
                    <ContentCollection>
                        <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">
                            <div style="font-family: 黑体; font-size: medium; color: #000000; background-color: #99CCFF">
                                月计划工单查询<br />&nbsp;&nbsp;&nbsp;&nbsp;
                                <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ClientIDMode="AutoID" 
                                    Height="18px" SelectedIndex="0" ValueType="System.String" Width="91px">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dGrid3.PerformCallback(s.GetValue());
}" />
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="1月" Value="1" />
                                        <dx:ListEditItem Text="2月" Value="2" />
                                        <dx:ListEditItem Text="3月" Value="3" />
                                        <dx:ListEditItem Text="4月" Value="4" />
                                        <dx:ListEditItem Text="5月" Value="5" />
                                        <dx:ListEditItem Text="6月" Value="6" />
                                        <dx:ListEditItem Text="7月" Value="7" />
                                        <dx:ListEditItem Text="8月" Value="8" />
                                        <dx:ListEditItem Text="9月" Value="9" />
                                        <dx:ListEditItem Text="10月" Value="10" />
                                        <dx:ListEditItem Text="11月" Value="11" />
                                        <dx:ListEditItem Text="12月" Value="12" />
                                    </Items>
                            
                                    <ButtonStyle Width="13px">
                                    </ButtonStyle>
                                </dx:ASPxComboBox>
                                &nbsp;&nbsp;&nbsp;
                            </div>
                            <div style="background-color: #c0c0c0">
                                <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" 
                                    ClientIDMode="AutoID" ClientInstanceName="dGrid3" 
                                    OnCustomCallback="ASPxGridView3_CustomCallback">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0">
                                            <ClearFilterButton Visible="True">
                                            </ClearFilterButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="序号" FieldName="Plan_Id" 
                                            ShowInCustomizationForm="True" Visible="False" VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="月份" FieldName="Plan_Month" 
                                            ShowInCustomizationForm="True" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="设备名称" FieldName="Device_Name" 
                                            ShowInCustomizationForm="True" VisibleIndex="2">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="使用单位" FieldName="Device_User" 
                                            ShowInCustomizationForm="True" VisibleIndex="3">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="设备维护项目" FieldName="Maintance_Project" 
                                            ShowInCustomizationForm="True" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="定期保养时间(16h/天)" FieldName="Maintance_time" 
                                            ShowInCustomizationForm="True" VisibleIndex="5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="确认状况" FieldName="Confirm_Statues" 
                                            ShowInCustomizationForm="True" VisibleIndex="6">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="完成状况" FieldName="Work_Statues" 
                                            ShowInCustomizationForm="True" VisibleIndex="7">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="保养时间" FieldName="Work_time" 
                                            ShowInCustomizationForm="True" VisibleIndex="8">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Settings ShowFilterRow="True" />
                                </dx:ASPxGridView>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>
    </div>
    </div>
    </form>
</body>
</html>



