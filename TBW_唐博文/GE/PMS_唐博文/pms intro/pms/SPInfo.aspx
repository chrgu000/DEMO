<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPInfo.aspx.cs" Inherits="PMMWS.SPInfo" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx2" %>


<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx1" %>


<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .style1
        {
            color: #FF0000;
        }
        .style2
        {
            color: #000000;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
      <td>
          <uc1:TitleControl ID="TitleControl1" runat="server" />
      </td>  
          <tr>
      <td>
          <strong style="font-size: x-large; color: #0033CC">备件信息查询</strong></tr>
          <tr>
      <td align="left" class="style1">
          <span class="style2">需要编辑请输入密码：</span><dx2:ASPxTextBox 
              ID="ASPxTextBox1" runat="server" Password="True" 
                Width="100px">
            </dx2:ASPxTextBox>
             
            <dx2:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认">
            </dx2:ASPxButton>
            
              
          <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" 
              GridViewID="ASPxGridView1">
          </dx:ASPxGridViewExporter>
            
              
          <dx:ASPxButton ID="ASPxButton6" runat="server" onclick="ASPxButton6_Click" 
              Text="添加新类型" Visible="False">
          </dx:ASPxButton>
            
              
          </tr>
          <tr>
      <td align="left" class="style1">
          <dx:ASPxPanel ID="ASPxPanel1" runat="server" Visible="False" Width="200px">
              <PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">
    <span class="style2">添加新备件类：</span><dx:ASPxTextBox ID="ASPxTextBox2" 
        runat="server" Width="170px">
    </dx:ASPxTextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认" 
        Width="77px" />
                  &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" 
        Text="删除" Width="77px" />
                  </dx:PanelContent>
</PanelCollection>
          </dx:ASPxPanel>
          </tr>
          <tr>
      <td align="left" class="style1">
          <dx:ASPxComboBox ID="ASPxComboBox2" runat="server" 
              Width="120px">
              <ClientSideEvents SelectedIndexChanged="function(s, e) {
	dGrid.PerformCallback();
}" />
          </dx:ASPxComboBox>
          <dx:ASPxButton ID="ASPxButton4" runat="server" onclick="ASPxButton4_Click" 
              Text="导出Excel">
          </dx:ASPxButton>
          </tr>
          <tr>
      <td class="style1">
          <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
              Width="1024px" ClientInstanceName="dGrid" KeyFieldName="SPId" 
              onrowinserting="ASPxGridView1_RowInserting" 
              onrowupdating="ASPxGridView1_RowUpdating">
                 <ClientSideEvents EndCallback="function(s, e) {
	dGrid2.PerformCallback();
}" />
                 <Columns>
         <dx:GridViewCommandColumn VisibleIndex="0" Visible="False">
                <EditButton Visible="True" Text = "编辑"></EditButton>
                <NewButton Text="添加" Visible="True">
                </NewButton>
                <CancelButton Text="取消"></CancelButton>
                <UpdateButton Text="更新"></UpdateButton>
         </dx:GridViewCommandColumn>

<dx:GridViewDataTextColumn FieldName="MaterialCode" Caption="存货编码" VisibleIndex="1"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="ItemDescription" Caption="物品描述" VisibleIndex="2">
    <Settings FilterMode="DisplayText" />
                     </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Specification" Caption="规格" VisibleIndex="3"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="零件编号" FieldName="ItemNO" 
               VisibleIndex="4">
           </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="UM" Caption="U/M" VisibleIndex="5"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="数量" FieldName="Qty" 
               VisibleIndex="6">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="需求日期" FieldName="DueDate" VisibleIndex="8">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="单价" FieldName="UnitPrice" VisibleIndex="9">
           </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="入库时间" FieldName="CheckingDate" 
                         VisibleIndex="10">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="用途" FieldName="Purpose" VisibleIndex="11">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="库存状态" FieldName="StorageStatus" 
                         VisibleIndex="12">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn FieldName="SPId" Visible="False" VisibleIndex="14">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewCommandColumn Caption="选择" ShowSelectCheckbox="True" 
                         VisibleIndex="13">
                         <ClearFilterButton Visible="True">
                         </ClearFilterButton>
                     </dx:GridViewCommandColumn>
                     <dx:GridViewDataTextColumn Caption="安全库存量" FieldName="SafeQty" VisibleIndex="7">
                     </dx:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
<Settings ShowFilterRow="True"></Settings>
          
          </dx:ASPxGridView>
              </tr>
          <tr>
      <td class="style1">

    <asp:Button runat="server" Text="删除" Width="101px" ID="Button2" 
              OnClick="Button2_Click" Visible="False"></asp:Button>

                  </tr>
          <tr>
      <td class="style1">
          <strong style="font-size: x-large; " class="style1">当前库存小于安全库存量的备件</strong></tr>
          <tr>
      <td class="style1">
          <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
              Width="1024px" ClientInstanceName="dGrid2" KeyFieldName="SPId" 
              onrowinserting="ASPxGridView1_RowInserting" 
              onrowupdating="ASPxGridView1_RowUpdating" 
              oncustomcallback="ASPxGridView2_CustomCallback">
                 <Columns>

<dx:GridViewDataTextColumn FieldName="MaterialCode" Caption="存货编码" VisibleIndex="1"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="ItemDescription" Caption="物品描述" VisibleIndex="2">
    <Settings FilterMode="DisplayText" />
                     </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Specification" Caption="规格" VisibleIndex="3"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="零件编号" FieldName="ItemNO" 
               VisibleIndex="4">
           </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="UM" Caption="U/M" VisibleIndex="5"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="数量" FieldName="Qty" 
               VisibleIndex="6">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="需求日期" FieldName="DueDate" VisibleIndex="8">
           </dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="单价" FieldName="UnitPrice" VisibleIndex="9">
           </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="入库时间" FieldName="CheckingDate" 
                         VisibleIndex="10">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="用途" FieldName="Purpose" VisibleIndex="11">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="库存状态" FieldName="StorageStatus" 
                         VisibleIndex="12">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn FieldName="SPId" Visible="False" VisibleIndex="14">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewCommandColumn Caption="选择" ShowSelectCheckbox="True" 
                         VisibleIndex="13">
                         <ClearFilterButton Visible="True">
                         </ClearFilterButton>
                     </dx:GridViewCommandColumn>
                     <dx:GridViewDataTextColumn Caption="设备名称" FieldName="SPName" VisibleIndex="0">
                     </dx:GridViewDataTextColumn>
                     <dx:GridViewDataTextColumn Caption="安全库存量" FieldName="SafeQty" VisibleIndex="7">
                     </dx:GridViewDataTextColumn>
</Columns>

<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>          
          </dx:ASPxGridView>
              </tr>
          <tr>
      <td class="style1">
          &nbsp;</tr>
      </table>
    </div>
    </form>
</body>
</html>
