<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerInfo.aspx.cs" Inherits="PMMWS.WorkerInfo" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx2" %>

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
        .style1
        {
            width: 100%;
            font-size: 0;
            padding: 1px 2px;
        }
        .style2
        {
            color: #000000;
            font-weight: 700;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
     <tr align="center">
        <td>
            <uc1:TitleControl ID="TitleControl1" runat="server" />
        </td>
     </tr>

     <tr align="center">
        <td align="left">
        
              
                    <span class="style2">需要编辑请输入密码：<dx2:ASPxTextBox 
                        ID="ASPxTextBox1" runat="server" Password="True" Height="16px" Width="137px">
            </dx2:ASPxTextBox>
             
            <dx2:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                Text="确认">
            </dx2:ASPxButton>
             
                                       </span>

              
        </td>
     </tr>

     <tr align="center">
        <td align="left">
        
              
    <dx:ASPxGridView ID="grid"  runat="server"
        KeyFieldName="WorkerId" AutoGenerateColumns="False" Width="100%" 
                        onrowupdating="grid_RowUpdating" 
                onrowinserting="grid_RowInserting" onrowdeleting="grid_RowDeleting">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" Caption="操作" Visible="False">
             <EditButton Visible="True" Text="编辑"></EditButton>
                <NewButton Text="新建" Visible="True">
                </NewButton>
                <DeleteButton Text="删除">
                </DeleteButton>
           </dx:GridViewCommandColumn>
           <dx:GridViewDataTextColumn FieldName="WorkerId" Caption="员工Id" VisibleIndex="1"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="员工姓名" FieldName="WorkerName" VisibleIndex="2"></dx:GridViewDataTextColumn>
           <dx:GridViewDataTextColumn Caption="SSO" FieldName="WorkerSSO" VisibleIndex="3"></dx:GridViewDataTextColumn>
        </Columns>

        <SettingsBehavior AllowSelectByRowClick="True" 
            AllowSelectSingleRowOnly="True" />

<SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="400px" EditFormColumnCount="1"></SettingsEditing>

<Settings ShowTitlePanel="True" ShowFilterRow="True"></Settings>

<SettingsText Title="维修人员信息"></SettingsText>
    </dx:ASPxGridView>

              
        </td>
     </tr>

     <tr align="center">
        <td align="left">
        
              
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="删除人员" 
                Visible="False" Width="67px" />

              
        </td>
     </tr>

    </table>
    </div>
    </form>
</body>
</html>
