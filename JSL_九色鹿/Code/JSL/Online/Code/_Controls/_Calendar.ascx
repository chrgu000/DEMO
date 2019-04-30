<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_Calendar.ascx.cs" Inherits="YxCalendar" %>
<script language="JavaScript" src="../Script/Calendar.js" type="text/javascript"></script>

<input id="cal" runat="server" class="text"  onfocus="javascript:SelectDate(this)" onkeypress="javascript:KeyPressEmpty()" style="width: 70px" type="text" />
<asp:DropDownList ID="ddlH" runat="server" Visible="false">
</asp:DropDownList> 
<asp:Label ID="txt" runat="server" Text="：" Width="5px" Visible="false"></asp:Label>
<asp:DropDownList ID="ddlM" runat="server" Visible="false">
</asp:DropDownList>
<asp:Label ID="lbl" runat="server" Visible="false"></asp:Label>
<script language="javascript" type="text/javascript">

function KeyPressEmpty()
{
    event.returnValue = false;
}

</script>