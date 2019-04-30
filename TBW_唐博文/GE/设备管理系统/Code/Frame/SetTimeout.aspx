<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetTimeout.aspx.cs" Inherits="Frame_SetTimeout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<script language="javascript">
    //ID=window.setTimeout ("getCheckSession()",120000);1000=1秒
    ID=window.setTimeout ("getCheckSession()",600000);
	function getCheckSession()
	{
	    //每分钟触发一次
		location.href = "SetTimeout.aspx"
	}
</script>
<body>
    <form id="frmCheck" runat="server">
    <div>
        
    </div>
    </form>
</body>
</html>
