<%@ page language="C#" autoeventwireup="true" inherits="ErrorPage, App_Web_elfrijrb" stylesheettheme="Css" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>错误页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lbl" runat="server" Text="错误原因： 1、系统更新<br /> 2、程序有误<br /> 3、密码失效<br /> 请<br />"></asp:Label>
        
        
        <a onclick="javascript:doClose();">重新登录</a>
    </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
function doClose()
{
    if(self!=!top) 
    {
        this.parent.self.location="default.aspx";
    }
    else
    {
        this.location="default.aspx";
    }
}
</script>