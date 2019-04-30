<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>错误页面</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css/datetimepicker.css" rel="stylesheet" type="text/css" />

    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="container" style="width: 100%">
    <form id="form1" runat="server"  autocomplete="off" class="form-horizontal">
<p  id="lbl" runat="server" class="text-warning"></p>
<a onclick="javascript:doClose();"  class="btn btn-default" role="button">重新登录</a>
    </form>
    </div>
</body>
</html>

<script type="text/javascript" language="javascript">
    function doClose() {
        if (window.parent == null && window.opener == null) {
            window.location = "default.aspx";
        }
        else if (window.parent.parent != null) {
            window.parent.parent.location = "default.aspx";
        }
        else if (window.parent != null) {
            window.parent.location = "default.aspx";
        }
        else if (window.opener.parent != null) {
            window.opener.parent.location = "default.aspx";
        }
        else if (window.opener.parent.parent != null) {
            window.opener.parent.parent.location = "default.aspx";
        }
    }
</script>