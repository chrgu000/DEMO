<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Frame_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" onunload="exic();">
<head runat="server">
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<frameset rows="500px,*" border="0" framespacing="0" frameborder="0">
    <frame src="Top.aspx" frameborder="no" scrolling="no" marginwidth="0" marginheight="0" name="Top" id="Top"></frame>
    <frameset cols="0,*" border="0" framespacing="0" frameborder="0"  id="frm">
        <frame src="Left.aspx" frameborder="no" scrolling="no" marginwidth="0" marginheight="0" name="Left" id="Left" noresize/>	
        <frame src="../WO/Maintenance.aspx" frameborder="no" scrolling="auto" marginwidth="0" marginheight="0" name="Right" id="Right" noresize />	
    </frameset>
</frameset>
</html>
