<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_CalendarStartEnd.ascx.cs" Inherits="FormatCalendarStartEnd" %>
<script src="../js/jquery-1.9.1.min.js"></script>
		<script src="../js/bootstrap.min.js"></script>
		<script src="../js/bootstrap-datetimepicker.min.js"></script>
		<script src="../js/bootstrap-datetimepicker.zh-CN.js"></script>
		<script src="../js/jquery.form.js"></script>
		<script src="../js/jquery.validate.js"></script>

<link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
<asp:Label ID="Label1" runat="server" CssClass="form-inline input-sm"></asp:Label><asp:TextBox ID="datetimepicker1" CssClass="form-inline input-sm"  runat="server" ></asp:TextBox>
<asp:Label ID="Label2" runat="server" CssClass="form-inline input-sm"></asp:Label><asp:TextBox ID="datetimepicker2" CssClass="form-inline input-sm"  runat="server" ></asp:TextBox>
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        // 日期控件
        $("#<%=datetimepicker1.ClientID%>").datetimepicker({

            language: 'zh-CN',
            format: 'yyyy-mm-dd',
            minView: '2',
            todayBtn: true,
            autoclose: true,
            todayHighlight: true,
            //            pickerPosition: 'top-left',
            startDate: '2000-1-1',
            forceParse: false
        })
//				.on('changeDate', function() {
//				    $(this).blur();
//				});
});

$(document).ready(function() {
    // 日期控件
    $("#<%=datetimepicker2.ClientID%>").datetimepicker({

        language: 'zh-CN',
        format: 'yyyy-mm-dd',
        minView: '2',
        todayBtn: true,
        autoclose: true,
        todayHighlight: true,
        //            pickerPosition: 'top-left',
        startDate: '2000-1-1',
        forceParse: false
    })
				.on('changeDate', function() {
				    $(this).blur();
				});
});

</script>
