<%@ page language="C#" autoeventwireup="true" inherits="In_InUpdate, App_Web_y0b7i4rm" enableeventvalidation="true" stylesheettheme="Css" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidid" runat="server" />
    <YxControls:YxButtonUpdateTop ID="YxBtnTop" runat="server" Title="条码扫描入库" />
    <table class="TableUpdate">
        <tr>
            <tr>
                <td class="tdlbl" style="width: 11%">
                    货位
                </td>
                <td class="tdinput" colspan="2">
                    <asp:TextBox ID="txtcPosCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdlbl" style="width: 11%">
                    入库日期
                </td>
                <td class="tdinput" colspan="2">
                    <YxControls:YxCalendar ID="dDate" runat="server" />
                    共<asp:Label ID="lblCount" runat="server">0</asp:Label>条
                </td>
            </tr>
            <td class="tdlbl">
                盒号
            </td>
            <td class="tdinput" style="width: 25%">
                <asp:TextBox ID="BoxID" runat="server"></asp:TextBox><input type="button" id="BtnAdd"
                    title="增加" runat="server" value="增加" class="button" />
            </td>
            <td class="tdinput" style="width: 25%">
                <%-- <asp:RadioButton ID="r1"  GroupName="r11" runat="server" Text="蓝字" Checked="true"/>
                <asp:RadioButton ID="r2"  GroupName="r11" runat="server" Text="红字"/>--%>
            </td>
        </tr>
    </table>
    <table id="table2" class="TableUpdate" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tdtitle">
                盒号
            </td>
            <td class="tdtitle">
                删除
            </td>
        </tr>
    </table>
    <YxControls:YxButtonUpdate ID="YxBtn" runat="server" OnToBeck="ToBeck" OnToChoose="ToChoose" />
    <YxControls:YxPage ID="YP" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    var i = 0;
    function doSave() {
        var ddate = document.getElementById("dDate_cal");
        var hid = document.getElementById("<%=hidid.ClientID%>");
        var boxid = document.getElementById("<%=BoxID.ClientID%>");
        var txtcPosCode = document.getElementById("<%=txtcPosCode.ClientID%>");
        var oTable = document.getElementById("table2");
        var snew = "";
        var flag = "";
        if (ddate.value == "") {
            alert("日期不可为空");
            return false;
        }
        if (txtcPosCode.value == "") {
            alert("货位不可为空");
            return false;
        }
        //    if (document.getElementById("r1").checked==true) {
        flag = 1;
        //    }
        //    if (document.getElementById("r2").checked == true) {
        //        flag = 2;
        //    }

        for (var s = 1; s < oTable.rows.length; s++) {
            if (snew != "") {
                snew = snew + ",";
            }
            snew = snew + oTable.rows[s].cells[0].childNodes[0].innerHTML;
        }
        if (snew == "") {
            alert("无需入库的内容");
            return false;
        }
        var s = AjaxMethod.GetIn(snew, ddate.value, flag, txtcPosCode.value).value;
        if (s == "保存成功") {
            alert("入库成功，请继续");
            for (var s = oTable.rows.length - 1; s >= 1; s--) {
                oTable.deleteRow(s);
            }
            boxid.value = "";
            hid.value = "";
            i = 0;
            document.getElementById("lblCount").innerText = i;
        }
        else {

            alert(s);
        }

        return false;
    }

    function doAdd(obj1, obj2, obj3) {
        var boxid = document.getElementById(obj1);

        if (boxid.value.length == 20 || (boxid.value.length == 10 && boxid.value.substr(0, 2) == "PK")) {
            var ddate = document.getElementById(obj2);
            var hid = document.getElementById(obj3);
            if (hid.value.indexOf(boxid.value) < 0) {
                i++;
                var oTable = document.getElementById("table2");
                var oRow = oTable.insertRow();
                oRow.id = "tr" + i;
                var oInput = oRow.insertCell();
                oInput.align = "center";
                oInput.className = "tdfileitem";
                oInput.innerHTML = "<label id='lbl_" + i + "' >" + boxid.value + "</label>";

                var oDelete = oRow.insertCell();
                oDelete.align = "center";
                oDelete.className = "tdfileitem";
                oDelete.innerHTML = "<img src='../Images/PublicImages/delete.gif' id='del_" + i + "' name='del_" + i + "' onclick='DeleTable(i, this)' style='cursor:hand'/>";

                if (hid.value != "") {
                    hid.value = hid.value + ",";
                }
                hid.value = hid.value + boxid.value;
                document.getElementById("lblCount").innerText = i;
                boxid.value = "";
            }
            else {
                alert("已有该盒号");
            }
        }
        return false;
    }

    function DeleTable(i, obj) {
        //    if (confirm('确认删除吗？')) {
        var id = document.getElementById("<%=hidid.ClientID%>");
        i--;
        document.getElementById("lblCount").innerText = i;
        obj.parentNode.parentNode.removeNode(true);

        return true;
        //    }


    }
</script>

