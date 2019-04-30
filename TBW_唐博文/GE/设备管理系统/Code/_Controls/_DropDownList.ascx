<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_DropDownList.ascx.cs" Inherits="FormatDropDownList" %>

    <%--<asp:DropDownList ID="ddl" CssClass="form-control" runat="server" AutoPostBack="false" ></asp:DropDownList>
    <asp:TextBox ID="ddlhid" runat="server"></asp:TextBox>
    
        <script language="javascript" type="text/javascript">
            StartDropDownList('<%=ddl.ClientID%>','<%=ddlhid.ClientID%>');
</script>

--%>
<select id="ddl" runat="server" class="form-control">
</select>