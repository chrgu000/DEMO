<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkOrderAdmin.aspx.cs" Inherits="PMMWS.WorkOrderAdmin" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx2" %>
<%@ Register Assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            color: #000000;
            font-weight: 700;
        }
        .style3
        {
            height: 24px;
        }
        .style4
        {
        }
        .style6
        {
            width: 83px;
        }
        .style7
        {
            width: 1px;
            height: 25px;
        }
        .style8
        {
            height: 35px;
            font-weight: 700;
        }
        .style9
        {
            width: 83px;
            height: 35px;
        }
        .style10
        {
            height: 30px;
        }
        .style11
        {
            height: 26px;
        }
        </style>
        <script type="text/javascript">
            var popupElement = null;
            var field = "";

            function ValidateDates() {
                var startDate = EdtStart.GetDate();
                var endDate = EdtEnd.GetDate();
                EdtStart.SetDate(startDate);
                EdtEnd.SetDate(endDate);
                if (endDate < startDate)
                    EdtEnd.SetDate(startDate);
            }

            function OnColumnClick(element, fieldName) {
                popupElement = element;
                field = fieldName;

                popup.PerformCallback(fieldName);
            }
            function OnPopupEndCallback(s, e) {
                s.ShowAtElement(popupElement);
            }
            function FilterGrid() {
                var filterString = field + "|";
                for (var i = 0; i < popup.cpCheckBoxCount; i++) {
                    var name = "cb_" + i.toString();
                    try {
                        var editor = eval(name);
                        if (editor && editor.GetChecked())
                            filterString += editor.GetText() + "|";
                    }
                    catch (e) { break; }
                }
                grid.PerformCallback(filterString);
            }

            function RedirecttoUrl() {

                grid.GetSelectedFieldValues('OrderId;MachineType', OnGetRowValues);

            }
            function OnGetRowValues(values) {
                if (values[0][1] == "Machining") {
                    var url = "MaintenanceWebInfo.aspx?OrderId=" + values[0][0];
                    window.open(url);
                }
                else if (values[0][1] == "Composite") {
                    var url = "MaintenanceWebInfoC.aspx?OrderId=" + values[0][0];
                    window.open(url);
                }
                else if (values[0][1] == "Sheet Metal") {
                    var url = "MaintenanceWebInfoB.aspx?OrderId=" + values[0][0];
                    window.open(url);
                }
                else if (values[0][1] == "Actuation") {
                    var url = "MaintenanceWebInfoD.aspx?OrderId=" + values[0][0];
                    window.open(url);
                }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width= "1024" border ="0" align="center" bgcolor="Silver" >
         <tr>
        <td>
            <uc1:TitleControl ID="TitleControl1" runat="server" />
        </td>
        </tr>
            <tr>
                <td>

              <strong style="font-size: x-large; color: #0033CC">查询历史工单记录选择区域Work Order Admin.</strong></td>
            </tr>
            <tr>
                <td align="left" class="style11">

                    <span class="style2">

                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="116px" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="MA">机加工</asp:ListItem>
                        <asp:ListItem Value="CM">复合材料</asp:ListItem>
                        <asp:ListItem Value="HP">液压系统</asp:ListItem>
                        <asp:ListItem Value="SM">钣金件</asp:ListItem>
                        <asp:ListItem Value="All">全部</asp:ListItem>
                    </asp:DropDownList>
                    </span>
                </td>
            </tr>
            <tr>
                <td align="left" class="style3">

                    <strong>报修时间Report Time:</strong></td>
            </tr>
            <tr>
                <td align="left" class="style3">

                    <table cellpadding="5" cellspacing="0" width="100%" border="1">
                                   <tr align="left">
                                       <td align="right" class="style7">
                                           <strong>从</strong></td>
                                       <td class="style7">
                                           <dx:ASPxDateEdit runat="server" EditFormat="Custom" 
                                               EditFormatString="yyyy-MM-dd " Width="150px" 
                                               DisplayFormatString="yyyy-MM-dd" ClientInstanceName="EdtStart" 
                                               ClientIDMode="AutoID" ID="dateTimePicker1">
<ClientSideEvents DateChanged="function(s, e) {
ValidateDates();
}"></ClientSideEvents>
</dx:ASPxDateEdit>

                                       </td>
                                       <td class="style7">
                                           &quot;0:00:00&quot;</td>
                                       <td class="style10">
                                           </td>
                                   </tr>
                                   <tr align="left">
                                       <td align="right" class="style8">
                                           至</td>
                                       <td class="style8">
                                           <dx:ASPxDateEdit runat="server" EditFormat="Custom" 
                                               EditFormatString="yyyy-MM-dd" Width="150px" 
                                               DisplayFormatString="yyyy-MM-dd " ClientInstanceName="EdtEnd" 
                                               EnableClientSideAPI="True" ClientIDMode="AutoID" ID="dateTimePicker2">
<ClientSideEvents DateChanged="function(s, e) {
   ValidateDates();
}"></ClientSideEvents>
</dx:ASPxDateEdit>

                                       </td>
                                       <td class="style9" align="left">
                                           &quot;23:59:59&quot;</td>
                                       <td class="style8">
                                           <dx:ASPxButton ID="ASPxButton4" runat="server" onclick="ASPxButton4_Click" 
                                               Text="确认">
                                           </dx:ASPxButton>
                                       </td>
                                   </tr>
                                   <tr align="left">
                                       <td align="left" class="style4" colspan="4">

                    <span class="style2">需要编辑请输入密码 Please inputs password to edit</span></td>
                                   </tr>
                                   <tr align="left">
                                       <td align="right" class="style4">
                                           &nbsp;</td>
                                       <td>
                                           <dx2:ASPxTextBox 
                        ID="ASPxTextBox1" runat="server" Password="True" Height="16px" Width="137px">
            </dx2:ASPxTextBox>
             
                                       </td>
                                       <td class="style6" align="left">
             
            <dx2:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认">
            </dx2:ASPxButton>
                                       </td>
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                               </table>
                         
                             
                </td>
            </tr>
            <tr>
                <td align="left">

                <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server"
        KeyFieldName="OrderId" AutoGenerateColumns="False" Width="100%" 
                        onrowupdating="grid_RowUpdating" onrowdeleting="grid_RowDeleting" 
                        OnCustomCallback="gridView_CustomCallback" 
                        oncustomcolumndisplaytext="grid_CustomColumnDisplayText" 
                        onrowinserting="grid_RowInserting"
                       >
     <%--         <Templates>
                <HeaderCaption>
                    <div style="float: left;">
                        <%#Eval("Caption")%>
                    </div>
                    <div style="float: right;">
                        <img alt="" src="Images/Key.bmp" onclick="OnColumnClick(this, '<%#Eval("Caption")%>');" />
                    </div>
                </HeaderCaption>
            </Templates>--%>

                    <ClientSideEvents BeginCallback="function(s, e) {

}" EndCallback="function(s, e) {

}" CustomButtonClick="function(s, e) {
	RedirecttoUrl();
}" />

        <SettingsEditing EditFormColumnCount="3" Mode="PopupEditForm" PopupEditFormWidth="800px" />
        <Settings ShowTitlePanel="true" ShowFilterRow="True" />
        <SettingsText Title="历史工单管理Word Order Admin" />

<ClientSideEvents CustomButtonClick="function(s, e) {
	RedirecttoUrl();
}" BeginCallback="function(s, e) {

}" EndCallback="function(s, e) {

}"></ClientSideEvents>

        <Columns>
            <dx:GridViewCommandColumn Caption="操作" 
                VisibleIndex="0" Visible="False">
                <EditButton Text="编辑" Visible="True">
                </EditButton>
                <NewButton Text="添加" Visible="True">
                </NewButton>
                <DeleteButton Text="删除">
                </DeleteButton>
                <UpdateButton Visible="True">
                </UpdateButton>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="Custom" Text="查看完整">
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn FieldName="MachineCode" 
                Caption="设备编号" VisibleIndex="2" >
                <HeaderCaptionTemplate>
                     <div style="float: left;">
                        <%#Eval("FieldName")%>
                    </div>
                    <div style="float: right;">
                        <img alt="" src="Images/Key.bmp" onclick="OnColumnClick(this, '<%#Eval("FieldName")%>');" />
                    </div>
                </HeaderCaptionTemplate>
                </dx:GridViewDataTextColumn>


<dx:GridViewDataTextColumn FieldName="FaultInfo" 
                Caption="报修描述" VisibleIndex="3"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="AlarmCode" 
                Caption="报警号" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="报修时间" FieldName="ST" VisibleIndex="5">
                <PropertiesTextEdit DisplayFormatInEditMode="True" 
                    DisplayFormatString="yyyy-MM-dd HH:mm:ss">
                </PropertiesTextEdit>
                <Settings AllowAutoFilterTextInputTimer="True" />

<Settings AllowAutoFilterTextInputTimer="True"></Settings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="结束时间" FieldName="CT" VisibleIndex="6">
                <PropertiesTextEdit DisplayFormatInEditMode="True" 
                    DisplayFormatString="yyyy-MM-dd HH:mm:ss">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="Operator" 
                Caption="操作工" VisibleIndex="7"></dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MST" Caption="维修开始时间" VisibleIndex="9" >
    <PropertiesTextEdit DisplayFormatInEditMode="True" 
        DisplayFormatString="yyyy-MM-dd HH:mm:ss">
    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="MCT" Caption="维修结束时间" VisibleIndex="10">
    <PropertiesTextEdit DisplayFormatInEditMode="True" 
        DisplayFormatString="yyyy-MM-dd HH:mm:ss">
    </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataComboBoxColumn Caption="故障类型" FieldName="FaultType" 
                VisibleIndex="11">
                <PropertiesComboBox>
                    <Items>
                        <dx:ListEditItem Text="停机故障（操作）" Value="停机故障（操作）" />
                        <dx:ListEditItem Text="停机故障（人为）" Value="停机故障（人为）" />
                        <dx:ListEditItem Text="停机故障（质量）" Value="停机故障（质量）" />
                        <dx:ListEditItem Text="停机故障（备件）" Value="停机故障（备件）" />
                        <dx:ListEditItem Text="停机故障（机台测试）" Value="停机故障（机台测试）" />
                        <dx:ListEditItem Text="非停机故障" Value="非停机故障" />
                    </Items>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="序号" FieldName="OrderId" VisibleIndex="1" 
                SortIndex="0" SortOrder="Descending">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="维修工" FieldName="WorkerId" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
        
            <dx:GridViewDataTextColumn FieldName="MachineType" 
                VisibleIndex="14" Caption="设备类型" Visible="False">
            </dx:GridViewDataTextColumn>
        
            <dx:GridViewDataTextColumn Caption="工单号" FieldName="OrderNo" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
        
            <dx:GridViewDataCheckColumn Caption="EHS相关" FieldName="IsEHS" VisibleIndex="13">
                <PropertiesCheckEdit DisplayTextChecked="是" DisplayTextUnchecked="否">
                </PropertiesCheckEdit>
            </dx:GridViewDataCheckColumn>
        
        </Columns>
<SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>

<SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="800px" EditFormColumnCount="3"></SettingsEditing>
<Settings ShowTitlePanel="True" ShowFilterRow="True"></Settings>

<SettingsText Title="历史工单管理"></SettingsText>

    </dx:ASPxGridView>

                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="删除工单" 
                        Visible="False" Width="96px" />
                </td>
            </tr>
            <tr>
                <td>
             
                  <dx:ASPxPopupControl ID="popupControl" runat="server" AllowResize="True" ClientInstanceName="popup"
        FooterText="" Height="120px" MinHeight="70px" MinWidth="50px" PopupVerticalAlign="Below"
        RenderMode="Lightweight" ShowFooter="True" ShowHeader="False" ScrollBars="Vertical"
        Width="200px" OnWindowCallback="popupControl_WindowCallback">
        <ContentCollection>
            <dx:PopupControlContentControl ID="MainPopupControlContentControlMain" runat="server"
                CssClass="popupControlContentControl">
                <dx:ASPxPanel ID="CheckBoxPanel" runat="server">
                </dx:ASPxPanel>
                <br />
                <table width="100%">
                    <tr>
                        <td width="33%">
                            <dx:ASPxButton ID="btnOK" runat="server" Text="OK" AutoPostBack="False" Width="100%">
                                <ClientSideEvents Click="function(s, e) { 
                                    FilterGrid();
                                    popup.Hide();
                                }" />
                            </dx:ASPxButton>
                        </td>
                        <td width="33%">
                            <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancel" AutoPostBack="False" Width="100%">
                                <ClientSideEvents Click="function(s, e) { 
                                    popup.Hide(); 
                                }" />
                            </dx:ASPxButton>
                        </td>
                        <td width="34%">
                            <dx:ASPxButton ID="btnClear" runat="server" Text="Clear" AutoPostBack="False" Width="100%">
                                <ClientSideEvents Click="function(s, e) { 
                                    grid.PerformCallback('Clear');
                                    popup.Hide(); 
                                }" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ClientSideEvents EndCallback="OnPopupEndCallback" />
    </dx:ASPxPopupControl>
             
                </td>
            </tr>
      </table>
    </div>
    </form>
</body>
</html>
