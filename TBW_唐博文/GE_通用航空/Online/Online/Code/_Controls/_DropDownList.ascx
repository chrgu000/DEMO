<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_DropDownList.ascx.cs" Inherits="FormatDropDownList" %>
<script src="../js/jquery-1.9.1.min.js"></script>
		<script src="../js/bootstrap.min.js"></script>
		<script src="../js/bootstrap-datetimepicker.min.js"></script>
		<script src="../js/jquery.form.js"></script>
		<script src="../js/jquery.validate.js"></script>

<link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <%--<asp:DropDownList ID="ddl" CssClass="form-control" runat="server" AutoPostBack="false" ></asp:DropDownList>
    <asp:TextBox ID="ddlhid" runat="server"></asp:TextBox>
    
        <script language="javascript" type="text/javascript">
            StartDropDownList('<%=ddl.ClientID%>','<%=ddlhid.ClientID%>');
</script>

--%>
<select id="ddl" runat="server" class="form-control">
</select>