<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairPageForm.aspx.cs" Inherits="PMMWS.RepairPageForm" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 257px;
            height: 57px;
        }
        .style2
        {
            width: 257px;
            height: 57px;
            color: #0066FF;
            font-size: large;
        }
        .style3
        {
            color: #0066FF;
        }
        .style4
        {
            color: #CC3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #C0C0C0" >
        <Table width = "1024" align="center" border="0"  bgcolor="#CCFFFF">
            <tr>
                <td colspan="3">
                     <img class="style1" src="mono_aviation.gif" />
                                    
                    <strong><span class="style2">通用电气航空系统（苏州）维修管理系统</span></strong></td>
            </tr>

            <tr>
                <td width="50%" rowspan="4">
         
    <dx1:ASPxGridView runat="server" ClientInstanceName="dGrid1" 
             AutoGenerateColumns="False" ID="xOrderGridView" Width="100%" Caption="当前故障停机信息" 
                        KeyFieldName="ScanId" > 
       <Columns>
<dx1:gridviewdatatextcolumn Caption="区域"  FieldName="MachineType"
         VisibleIndex="0"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="MachineName" 
                Caption="设备名称" VisibleIndex="1"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="FaultInfo" 
                Caption="报修描述" VisibleIndex="2"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="ST" 
                Caption="停机时间" VisibleIndex="3"></dx1:gridviewdatatextcolumn>
           <dx1:GridViewDataTextColumn FieldName="ScanId" Visible="False" VisibleIndex="4">
           </dx1:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
</dx1:ASPxGridView>
                </td>
                <td align="right" class="style3">
                     <strong>维修工</strong></td>
                <td align="left">
                     <dx:ASPxTextBox ID="WorkerName" runat="server" Width="170px">
                     </dx:ASPxTextBox>
                </td>
            </tr>

            <tr>
                <td align="right" class="style3">
                     <strong>正在维修设备</strong></td>
                <td align="left">
                     <dx:ASPxTextBox ID="RepairManitance" runat="server" Width="170px">
                     </dx:ASPxTextBox>
                </td>
            </tr>

            <tr>
                <td align="right" class="style3">
                     <strong>故障类型</strong></td>
                <td align="left">
                   
                    <dx:ASPxComboBox ID="Faulttype" runat="server">
                        <Items>
                            <dx:ListEditItem Text="停机故障（操作）" Value="0" />
                            <dx:ListEditItem Text="停机故障（人为）" Value="1" />
                            <dx:ListEditItem Text="停机故障（质量）" Value="2" />
                            <dx:ListEditItem Text="停机故障（备件）" Value="3" />
                            <dx:ListEditItem Text="停机故障（机台测试）" Value="4" />
                            <dx:ListEditItem Text="非停机故障" Value="5" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>

            <tr>
                <td class="style3" align="right">
                     <strong>维修<span class="style4">结束</span>请点击</strong></td>
                <td align="left">
                     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确认" 
                         Width="98px" />
                </td>
            </tr>

        </Table>
    </form>
</body>
</html>
