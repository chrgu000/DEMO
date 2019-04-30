<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Frame_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">


</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>

    <script src="js/bootstrap-dropdown.js" type="text/javascript"></script>


</head>
<body>
    <form>
<nav class="navbar navbar-default" role="navigation" >
  <div class="navbar-header" >
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
      <span class="sr-only"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
    </button>
    <a class="navbar-brand" href="#" id="compname" runat="server"></a>
  </div>

<div class="collapse navbar-collapse" id="div1" runat="server">
    <ul class="nav navbar-nav navbar-right" id="menuid" runat="server">
    <asp:Repeater ID="rpItemList" runat="server" EnableViewState="false" >
    <ItemTemplate>
    
    <li>
    <a class="dropdown-toggle" data-toggle="dropdown" href="#" ><%#DataBinder.Eval(Container.DataItem, "fchrFrmText")%>
    <b class="caret"></b></a><%--onclick="javascript:WindowOpenFrame('<%#DataBinder.Eval(Container.DataItem,"fPath") %>','<%#DataBinder.Eval(Container.DataItem,"fchrNameSpace") %>','0')"--%>
     <ul id="menu2" class="dropdown-menu">
                    <li><a href="#">动作</a></li>
                    <li><a href="#">另一个动作</a></li>
                    <li><a href="#">其他</a></li>
                    <li class="divider"></li>
                    <li><a href="#">另一个链接</a></li>
                </ul>
                </li>
    </ItemTemplate>
</asp:Repeater>
    </ul>
    </div>
    
</nav>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    function WindowOpenFrame(url, fchrNameSpace, flag) {
        if (flag == "0") {
            window.parent.frames.Right.location.href = url;
            window.parent.frames.Left.location.href = "Left.aspx?iID=" + fchrNameSpace;
        }
        else if (flag == "1") {
            window.parent.location.href = "../Default.aspx";
        }
        else {
            OpenWindow("Default2.aspx", '', '', '', '', '');
        }
    }

</script>

<style>
    a
    {
        cursor: pointer;
    }
</style>
