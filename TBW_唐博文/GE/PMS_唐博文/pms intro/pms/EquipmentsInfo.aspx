<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipmentsInfo.aspx.cs" Inherits="PMMWS.EquipmentsInfo" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            color: #0066FF;
            font-size: x-large;
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
        <tr align="center">
        <td width="100%" align="left" class="style2">
       
            <strong>选择区域：</strong></td>
        <tr align="center">
        <td width="100%" align="left">
       
            <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" SelectedIndex="0">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dGrid1.PerformCallback();
}" />
                <Items>
                    <dx:ListEditItem Text="机加工" Value="机加工" Selected="True" />
                    <dx:ListEditItem Text="钣金件" Value="钣金件" />
                    <dx:ListEditItem Text="复合材料" Value="复合材料" />
                    <dx:ListEditItem Text="液压测试站" Value="液压测试站" />
                    <dx:ListEditItem Text="全部" Value="All" />
                </Items>
            </dx:ASPxComboBox>
            
        </td>
        <tr align="center">
        <td width="100%" align="left">
       
            &nbsp;</td>
           
        <tr align="center">
        <td width="100%" align="left">
       
          <span class="style2">需要编辑请输入密码：</span><dx:ASPxTextBox 
              ID="ASPxTextBox1" runat="server" Password="True" 
                Width="100px">
            </dx:ASPxTextBox>
             
            <dx:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认">
            </dx:ASPxButton>
            
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                GridViewID="xOrderGridView">
            </dx:ASPxGridViewExporter>
            
        </td>
           
        <tr align="center">
        <td width="100%" align="left">
       
            <dx:ASPxButton ID="ASPxButton4" runat="server" AutoPostBack="False" 
                onclick="ASPxButton4_Click" Text="导出Excel">
            </dx:ASPxButton>
            
        </td>
           
        <tr align="center">
        <td width="100%">
       
    <dx1:ASPxGridView runat="server" ClientInstanceName="dGrid1" 
             AutoGenerateColumns="False" ID="xOrderGridView" Width="1000px" Caption="设备信息" KeyFieldName="MachineCode" 
              
           onrowupdating="xOrderGridView_RowUpdating" onrowinserting="xOrderGridView_RowInserting"  
                      > 
       <Columns>
         <dx:GridViewCommandColumn VisibleIndex="0" Visible="False">
                <EditButton Visible="True" Text = "编辑"></EditButton>
                <NewButton Text="添加" Visible="True">
                </NewButton>
                <CancelButton Text="取消"></CancelButton>
                <UpdateButton Text="更新"></UpdateButton>
         </dx:GridViewCommandColumn>

<dx:GridViewDataTextColumn FieldName="MachineBu" Caption="区域" VisibleIndex="3"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MachineName" Caption="设备名称" VisibleIndex="4"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MachineType" Caption="设备类型" VisibleIndex="5"></dx:GridViewDataTextColumn>
           <dx:GridViewCommandColumn Caption="选择" ShowSelectCheckbox="True" 
               VisibleIndex="11">
               <ClearFilterButton Visible="True">
               </ClearFilterButton>
           </dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn Caption="设备编号*" FieldName="MachineCode" 
               VisibleIndex="6">
           </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MachineSerialNum" Caption="系列号" VisibleIndex="7"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="产地" FieldName="ProducingArea" 
               VisibleIndex="8">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="供应商" FieldName="Supplier" VisibleIndex="9">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="使用日期" FieldName="UseDate" VisibleIndex="10">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="工厂" FieldName="Factory" VisibleIndex="2">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="序号" FieldName="Orders" SortIndex="0" 
               SortOrder="Ascending" VisibleIndex="1">
           </dx:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
<Settings ShowFilterRow="True" />
<Settings ShowFilterRow="True"></Settings>

</dx1:ASPxGridView>
            
        </td>
           
        <tr align="left">
        <td width="100%">
       
            <asp:Button ID="Button1" runat="server" Text="删除" onclick="Button1_Click" 
                Visible="False" Width="68px" />
            
        </td>
           
        </table>
    </tr>
    </div>
    </form>
</body>
</html>
