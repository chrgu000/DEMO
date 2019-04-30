<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_CalendarStartEnd.ascx.cs" Inherits="YxCalendarStartEnd" %>
<script language="JavaScript" src="../Script/Calendar.js" type="text/javascript"></script>
<br />
从<input id="cals" runat="server" class="text" onfocus="javascript:SelectDate(this)" onkeypress="javascript:KeyPressEmpty()" style="width: 80px" type="text" /><br />
至<input id="cale" runat="server" class="text" onfocus="javascript:SelectDate(this)" onkeypress="javascript:KeyPressEmpty()" style="width: 80px" type="text" />
<script language="javascript" type="text/javascript">

function KeyPressEmpty()
{
    event.returnValue = false;
}

</script>
