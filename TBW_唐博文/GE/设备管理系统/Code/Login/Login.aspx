<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
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
</head>
<body  style="background-color:#FFFFFF">
<div class="bs-example">
    <form id="form1" runat="server" AUTOCOMPLETE="off"  class="form-horizontal" >
    <div style="text-align:center;width:300px;margin-left:auto;margin-right:auto;"  class="form-group">
        
        <table style="text-align:center;margin-left:auto;margin-right:auto;border-collapse:collapse;width:100%;font-size: 16px;">
            <tr>
                <td id="td4" colspan="2"  class="text-muted"><h1 id="compname" runat="server"></h1></td>
            </tr>
            <tr>
                <td id="td1"  class="text-muted">账号</td>
                <td ><asp:TextBox ID="LogName" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td id="td2" class="text-muted">密码</td>
                <td ><asp:TextBox ID="LogPwd" TextMode="Password" runat="server" MaxLength="50" CssClass="form-control" placeholder="Password"/></td>
            </tr>
            <tr style="display:none;"><%-- style="display:none;"--%>
                <td id="td3" class="text-muted">语言</td>
                <td ><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList><FormatControls:Calendar ID="cal" runat="server"/></td>
            </tr>
            <tr>
                <td colspan="2" >
                <div class="bs-example" style="max-width: 400px; margin: 0 auto 10px;">
                    <asp:Button ID="BtnLog" runat="server" Text="登陆" CssClass="btn btn-primary btn-lg btn-block" OnClick="Button1_Click"  /></td>
                </div>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="errorLabel" runat="server" CssClass="text-danger" /></td>
            </tr>
            
        </table></div>
    </form>
</div>
</body>
</html>
<script language="javascript" type="text/javascript">
//    doSel();
//    function doSel() {
//        alert(Ajax.EquipAjaxMethod.Test().value);
//    }

    function SelectLanguange(obj1,obj2) {
        var lb1 = document.getElementById(obj1);
        var lb2 = document.getElementById(obj2);
        if (lb1.value != "") {
            var s = Ajax.AjaxMethod.SelectLan(lb1.value).value;
            var lst1 = window.document.getElementById("DropDownList1");
            for (var i = 0; i < lst1.length; i++) {
                if (s == lst1.options[i].value) {
                    lst1.options[i].selected = true;
                }
            }
        }
        SelectLanguangeChange();
    }

    function SelectLanguangeChange() {
//        var lan = "";
//        var lst1 = window.document.getElementById("DropDownList1");
//        for (var i = 0; i < lst1.length; i++) {
//            if (true == lst1.options[i].selected) {
//                lan = lst1.options[i].value;
//            }
//        }
//        if (lan == "2") {
//            var td1 = document.getElementById("td1");
//            td1.innerHTML = "User";
//            var td2 = document.getElementById("td2");
//            td2.innerHTML = "Password";
//            var td3 = document.getElementById("td3");
//            td3.innerHTML = "Language";
//            var td4 = document.getElementById("BtnLog");
//            td4.value = "Login";
//            
//            lst1.options[0].text = "Chinese";
//            lst1.options[1].text = "English";
//        }
//        else {
//            var td1 = document.getElementById("td1");
//            td1.innerHTML = "账号";
//            var td2 = document.getElementById("td2");
//            td2.innerHTML = "密码";
//            var td3 = document.getElementById("td3");
//            td3.innerHTML = "语言";
//            var td4 = document.getElementById("BtnLog");
//            td4.value = "登陆";
//            
//            lst1.options[0].text = "中文";
//            lst1.options[1].text = "英文";
//        }
    }
</script>

<script type="text/javascript">
        var Sys = {};
        var ua = navigator.userAgent.toLowerCase();
        window.ActiveXObject ? Sys.ie = ua.match(/msie ([\d.]+)/)[1] :
        document.getBoxObjectFor ? Sys.firefox = ua.match(/firefox\/([\d.]+)/)[1] :
        window.MessageEvent && !document.getBoxObjectFor ? Sys.chrome = ua.match(/chrome\/([\d.]+)/)[1] :
        window.opera ? Sys.opera = ua.match(/opera.([\d.]+)/)[1] :
        window.openDatabase ? Sys.safari = ua.match(/version\/([\d.]+)/)[1] : 0;

        //以下进行测试
        if (Sys.ie != "9.0") {
            alert("如未使用IE9.0登陆，可能出现样式错误");
        }
//        if(Sys.ie) document.write('IE: '+Sys.ie);
//        if(Sys.firefox) document.write('Firefox: '+Sys.firefox);
//        if(Sys.chrome) document.write('Chrome: '+Sys.chrome);
//        if(Sys.opera) document.write('Opera: '+Sys.opera);
//        if(Sys.safari) document.write('Safari: '+Sys.safari);
</script>