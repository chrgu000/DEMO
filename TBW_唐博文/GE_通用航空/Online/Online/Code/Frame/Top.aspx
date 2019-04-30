<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Frame_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <%--
    <link href="../css/docs.css" rel="stylesheet" type="text/css" />--%>

    <script src="../js/jquery-1.9.1.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/bootstrap-datetimepicker.min.js"></script>

    <script src="../js/jquery.form.js"></script>

    <script src="../js/jquery.validate.js"></script>

    <script src="../js/bootstrap-dropdown.js"></script>

</head>
<body>
    <form>
    <nav class="navbar navbar-default" role="navigation">
  <div class="navbar-header" >
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
      <span class="sr-only"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
      <span class="icon-bar"></span>
    </button>
    <a class="navbar-brand" href="#" id="compname" runat="server"></a>
  </div>

  <!-- Collect the nav links, forms, and other content for toggling -->
<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1" >
    <ul class="nav navbar-nav navbar-right" id="menuid" runat="server">
    <asp:Repeater ID="rpItemList" runat="server" EnableViewState="false">
    <ItemTemplate>
    <li><a onclick="javascript:WindowOpenFrame('<%#DataBinder.Eval(Container.DataItem,"fPath") %>','<%#DataBinder.Eval(Container.DataItem,"fchrNameSpace") %>','0')"><%#DataBinder.Eval(Container.DataItem, "fchrFrmText")%></a></li>
    </ItemTemplate>
</asp:Repeater>
      <%--<li><a href="#">维修状态</a></li>
      <li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Dropdown <b class="caret"></b></a>
        <ul class="dropdown-menu" >
          <li><a href="#">Action</a></li>
          <li><a href="#">Another action</a></li>
          <li><a href="#">Something else here</a></li>
          <li class="divider"></li>
          <li><a href="#">Action</a></li>
          <li><a href="#">Separated link</a></li>
        </ul>
      </li>
      <li><a onclick="javascript:WindowOpenFrame('../Equip/Index.aspx','0')">保养计划</a></li>
      <li><a href="#">设备信息</a></li>
      <li><a href="#">备件信息</a></li>--%>
    </ul>
    </div>
<!-- /.navbar-collapse -->
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
            OpenWindow(url, '', '', '', '', '');
        }
    }

</script>

<style>
    a
    {
        cursor:pointer;
    }
</style>
