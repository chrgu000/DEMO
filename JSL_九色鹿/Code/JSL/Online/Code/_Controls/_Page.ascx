<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_Page.ascx.cs" Inherits="YxPage" %>
<table id="TableCheck" class="TableUpdate" visible="false" runat="server" >
    <tr id="tr" runat="server" >
        <td class="tdlbl" style="white-space:nowrap;width:10%">
            状态
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">
            <asp:Label ID="lblFlag" runat="server" ></asp:Label>
        </td>
        <td class="tdlbl" style="white-space:nowrap;width:10%">
            核准员工
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">
            <asp:Label ID="lblCheckEmp" runat="server" ></asp:Label>
        </td>
        <td class="tdlbl" style="white-space:nowrap;width:10%">
            核准时间
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">
            <asp:Label ID="lblCheckTime" runat="server" ></asp:Label>
        </td>
    </tr>
</table>
<table id="TableAdd" class="TableUpdate" visible="false" runat="server" >
    <tr>
        <td class="tdlbl" style="white-space:nowrap;width:10%">
            序号[编码]
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">
            <asp:Label ID="lblNum" runat="server" ></asp:Label>
        </td>
        <td class="tdlbl" style="width:10%">
            制单时间
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">
            <asp:Label ID="lblAddTime" runat="server" ></asp:Label>
        </td>
        <td class="tdlbl" style="width:10%">
            制单员工
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">
            <asp:Label ID="lblAddEmp" runat="server" ></asp:Label>
        </td>
        <td class="tdlbl" style="width:10%">
            修改时间
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">
            <asp:Label ID="lblUpdateTime" runat="server" ></asp:Label>
        </td>
        <td class="tdlbl" style="white-space:nowrap;width:10%">
            修改员工
        </td>
        <td class="tdinput" style="white-space:nowrap;width:10%">   
            <asp:Label ID="lblUpdateEmp" runat="server" ></asp:Label>
        </td>
    </tr>
</table>