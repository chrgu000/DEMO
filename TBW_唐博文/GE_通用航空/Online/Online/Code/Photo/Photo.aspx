<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Photo.aspx.cs" Inherits="Photo_Photo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<base target="_self" />
    <title></title>
    <script language="javascript" type="text/javascript">
		var s = new Object();
		s.id = "";
		s.name = "";
    </script> 
</head>
<body >
    <form id="form1" runat="server" > 
        <object id="My_Cam" align="middle" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
            codebase="swflash.cab"
            height="283" viewastext="" width="616">
            <param name="allowScriptAccess" value="always" />
            <param name="movie" value="PhotoOnline.swf" />
            <param name="quality" value="high" />
            <param name="bgcolor" value="#ffffff" />
            <embed align="middle" allowscriptaccess="sameDomain" bgcolor="#ffffff" height="283"
                name="My_Cam" pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high"
                src="PhotoOnline.swf" type="application/x-shockwave-flash" width="616"></embed>
        </object>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function show(s) {

        s = s.replace(/ /g, "+");
//        document.getElementById("Img1").src = "data:image/gif;base64," + s;
        sendback(s);
    }
    function sendback(str) {
        var s = new Object();
        s.id = "ok";
        s.name = str;
        window.returnValue = s;
        window.close();
    }
    
    function Anul()
    {
       var s=new Object();
       s.id = "";
       s.name = "";
	   
       window.returnValue=s;
       window.close();
    }
</script>
