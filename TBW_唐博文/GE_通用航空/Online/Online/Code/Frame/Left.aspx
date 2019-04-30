<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Frame_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/docs.css" rel="stylesheet" type="text/css" />
    <link href="../css/github.min.css" rel="stylesheet" type="text/css" />
    <%--
    <script src="../js/jquery-1.9.1.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/bootstrap-datetimepicker.min.js"></script>

    <script src="../js/jquery.form.js"></script>

    <script src="../js/jquery.validate.js"></script>

    <script src="../js/bootstrap-dropdown.js"></script>
--%>
</head>
<body>
    <form>
    <div class="bs-docs-section">
        <div class="bs-example">
            <ul class="nav nav-list bs-docs-sidenav" runat="server" >
                <asp:Repeater ID="rpItemList" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <li><a onclick="javascript:WindowOpenFrame('<%#DataBinder.Eval(Container.DataItem,"fPath") %>','0')" >
                            <%#DataBinder.Eval(Container.DataItem, "fchrFrmText")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    function WindowOpenFrame(url, flag) {
        if (flag == "0") {
            window.parent.frames.Right.location.href = url;
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
