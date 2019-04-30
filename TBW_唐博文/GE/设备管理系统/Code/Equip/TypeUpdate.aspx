<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TypeUpdate.aspx.cs" Inherits="Equip_TypeUpdate"
    EnableEventValidation="true" MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="container" style="width: 100%;" id="div1" runat="server">
        <div class="panel  panel-primary">
            <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToBeck="ToBeck"
                OnToDel="ToDel" OnToSave="ToSave" OnToNew="ToNew" OnToExport="ToExport" />
            <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel">
            
                <table style="width:1000px;margin-left:auto;margin-right:auto" id="TableUpdate1"  runat="server">
                    <tbody  id="tbody1"></tbody>
                </table>
                <asp:HiddenField ID="hidDel" runat="server" />
            </asp:Panel>
        </div>
    </div>
<label  id="l1" runat="server" ></label>
    <script language="javascript" type="text/javascript">
        //保存
        function doSave() {
            var idleft = "_ctl0_CenterContent_";
            var lblisinput = "lblisinput_";
            var lbltitle = "lbltitle_";
            var iid = document.getElementById(idleft + "YxBtn_hidID").value;
            var s1;
            var s2;
            var s3;
            var s4;
            var s5;
            var s6;
            var s7;
            var s8;
            var s9;
            var s10;
            var s11;
            var s12;
            var s13;
            var s14;
            var s15;
            var date1;
            var date2;
            var date3;
            var date4;
            var date5;
            var d1;
            var d2;
            var d3;
            var d4;
            var d5;
            var d6;
            var d7;
            var d8;
            var d9;
            var d10;

            for (var i = 1; i <= 15; i++) {
                var s = "";
                var textS = document.getElementById(idleft + "textS" + i);
                if (textS != null) {
                    s = textS.value;
                }
                else {
                    var ddlS = document.getElementById(idleft + "ddlS" + i);
                    if (ddlS != null) {
                        s = GetDropDownListValue(idleft + "ddlS" + i);
                    }
                }
                var lblisinputS = document.getElementById(lblisinput + "S" + i);
                /*必输*/
                if (lblisinputS != null && lblisinputS.innerHTML == "*") {
                    if (s == "") {
                        alert(document.getElementById(lbltitle + "S" + i).innerHTML + "请必须输入");
                        if (textS != null) {
                            textS.focus();
                            return false;
                        }
                        else if (ddlS != null) {
                        ddlS.focus();
                        return false;
                        }
                    }
                }
                switch (i) {
                    case 1:
                        s1 = s;
                        break;
                    case 2:
                        s2 = s;
                        break;
                    case 3:
                        s3 = s;
                        break;
                    case 4:
                        s4 = s;
                        break;
                    case 5:
                        s5 = s;
                        break;
                    case 6:
                        s6 = s;
                        break;
                    case 7:
                        s7 = s;
                        break;
                    case 8:
                        s8 = s;
                        break;
                    case 9:
                        s9 = s;
                        break;
                    case 10:
                        s10 = s;
                        break;
                    case 11:
                        s11 = s;
                        break;
                    case 12:
                        s12 = s;
                        break;
                    case 13:
                        s13 = s;
                        break;
                    case 14:
                        s14 = s;
                        break;
                    case 15:
                        s15 = s;
                        break;
                }
            }

            for (var i = 1; i <= 5; i++) {
                var s = "";
                var Date = document.getElementById(idleft + "DateDate" + i + "_datetimepicker");
                if (Date != null) {
                    s = Date.value;
                }
                var lblisinputS = document.getElementById(lblisinput + "Date" + i);
                /*必输*/
                if (lblisinputS != null && lblisinputS.innerHTML == "*") {
                    if (s == "") {
                        alert(document.getElementById(lbltitle + "Date" + i).innerHTML + "请必须输入");
                        if (Date != null) {
                            Date.focus();
                            return false;
                        }
                    }
                }
                switch (i) {
                    case 1:
                        date1 = s;
                        break;
                    case 2:
                        date2 = s;
                        break;
                    case 3:
                        date3 = s;
                        break;
                    case 4:
                        date4 = s;
                        break;
                    case 5:
                        date5 = s;
                        break;
                }
            }

            for (var i = 1; i <= 10; i++) {
                var s = "";
                var D = document.getElementById(idleft + "textD" + i);
                if (D != null) {
                    s = D.value;
                }
                var lblisinputS = document.getElementById(lblisinput + "D" + i);
                /*必输*/
                if (lblisinputS != null && lblisinputS.innerHTML == "*") {
                    if (s == "") {
                        alert(document.getElementById(lbltitle + "D" + i).innerHTML + "请必须输入");
                        if (D != null) {
                            D.focus();
                            return false;
                        }
                    }
                    else {
                        if (!IsNumber(idleft + "textD" + i)) {
                            alert(document.getElementById(lbltitle + "D" + i).innerHTML + "请必须为数字");
                            if (D != null) {
                                D.focus();
                                return false;
                            }
                        }
                    }
                }
                switch (i) {
                    case 1:
                        d1 = s;
                        break;
                    case 2:
                        d2 = s;
                        break;
                    case 3:
                        d3 = s;
                        break;
                    case 4:
                        d4 = s;
                        break;
                    case 5:
                        d5 = s;
                        break;
                    case 6:
                        d6 = s;
                        break;
                    case 7:
                        d7 = s;
                        break;
                    case 8:
                        d8 = s;
                        break;
                    case 9:
                        d9 = s;
                        break;
                    case 10:
                        d10 = s;
                        break;
                }
            }

            var icheck = Ajax.EquipTypeAjaxMethod.Check(iid, s1, s2);
            if (icheck != null && icheck.value == true) {
                alert("类型编码或名称重复！");
                return false;
            }
            
            var obj = Ajax.EquipTypeAjaxMethod.Insert(iid, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, date1, date2, date3, date4, date5, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10);
            if(obj!=null && obj.value==true)
            {
                window.location.href = "Type.aspx";
                return false;
            }

        }

        function doDel() {
            var idleft = "_ctl0_CenterContent_";
            var iid = document.getElementById(idleft + "YxBtn_hidID").value;
            var s1 = document.getElementById(idleft + "textS1");
            var isdel = Ajax.EquipTypeAjaxMethod.IsDelete(s1.value);
            if (isdel != null && isdel.value == true) {
                alert("已使用，不可删除！");
                return false;
            }
            
            var obj = Ajax.EquipTypeAjaxMethod.IsDelete(iid);
            if (obj != null && obj.value==true) {
                window.location.href = "Type.aspx";
                return false;
            }
        }

        function doNew() {
            return false;
        }
    </script>

</asp:Content>
