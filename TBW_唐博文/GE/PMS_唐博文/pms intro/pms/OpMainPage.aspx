<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpMainPage.aspx.cs" Inherits="PMMWS.OpMainPage" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            color: #0066FF;
        }
    </style>
      <script type="text/javascript">

          function OnGridFocusedRowChanged() {
      
              dGrid1.GetRowValues(dGrid1.GetFocusedRowIndex(), 'MachineCode', OnGetRowValues);
          
          }
          function OnGetRowValues(values) {
     
              dText.SetText(values);
          }
      </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="1024" border= "0" align="center" >
            <tr>
                <td>    
                    
               <asp:Image ID="Image1" runat="server" Height="59px" ImageUrl="~/mono_aviation.gif" Width="250px"/>     
                    
                    <strong><span class="style1">通用电气航空系统（苏州）维修管理系统</span></strong></td>
             <tr>
                <td height="200">    
                    <table width="1024" border="0" bgcolor="#66CCFF">
                       <tr>
                            <td align="right" width="20%">    
                                
                                <strong>维修工刷机床名称：</strong></td>
                            <td width="20%">    
                                
                                <dx:ASPxTextBox ID="xMachineName" runat="server" Width="170px" 
                                    ClientInstanceName="dText">
                                </dx:ASPxTextBox>
                                
                            </td>
                            <td width="60%">    
                                
                            </td>
                        <tr>
                            <td align="right" width="20%">    
                                
                                <strong>维修工选择状态：</strong></td>
                            <td width="30%">    
                                
                                <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" ReadOnly="True" 
                                    SelectedIndex="0">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="开始维修" Value="0" />
                                        <dx:ListEditItem Text="结束维修" Value="1" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                            <td width="30%">    
                                
                                &nbsp;</td>
                        <tr>
                            <td align="right" width="20%">    
                                
                               <strong> 维修工刷员工Id：</strong></td>
                            <td width="30%">    
                                
                                <dx:ASPxTextBox ID="xWorkerId" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                                
                            </td>
                            <td width="30%" align="left">    
                                
                    <dx:ASPxButton ID="ASPxButton1" runat="server" onclick="ASPxButton1_Click" 
                        Text="提交">
                    </dx:ASPxButton>
                                <dx:ASPxLabel ID="ASPxLabel1" runat="server">
                                </dx:ASPxLabel>
                            </td>
                        </table>
                    <br />
         
    <dx1:ASPxGridView runat="server" ClientInstanceName="dGrid1" 
             AutoGenerateColumns="False" ID="xOrderGridView" Width="100%" Caption="当前故障停机信息" 
                        KeyFieldName="ScanId"> 
   <SettingsBehavior AllowFocusedRow="True" />
        <ClientSideEvents FocusedRowChanged="function(s, e) { OnGridFocusedRowChanged(); }" />
 
       <Columns>
<dx1:gridviewdatatextcolumn Caption="区域"  FieldName="MachineType"
         VisibleIndex="0"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="MachineCode" 
                Caption="设备编号" VisibleIndex="1"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="FaultInfo" 
                Caption="报修描述" VisibleIndex="2"></dx1:gridviewdatatextcolumn>
<dx1:gridviewdatatextcolumn FieldName="ST" 
                Caption="停机时间" VisibleIndex="3"></dx1:gridviewdatatextcolumn>
<dx1:gridviewcommandcolumn ShowSelectCheckbox="True" 
                Caption="选择" VisibleIndex="7"></dx1:gridviewcommandcolumn>
           <dx1:GridViewDataTextColumn FieldName="ScanId" Visible="False" VisibleIndex="5">
           </dx1:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
</dx1:ASPxGridView>
                 </td>
                         
             </table>
    
    </div>
    </form>
</body>
</html>
