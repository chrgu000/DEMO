
/////////////////////////////////////////////////////下拉列表
function GetDropDownListValue(obj) {
   var ddl = window.document.getElementById(obj);
   var ivalue = "";
   for (var i = 0; i < ddl.length; i++) {
       if (ddl.options[i].selected == true) {
           ivalue = ddl.options[i].value;
       }
   }
   return ivalue;
}

function SetDropDownListValue(obj,value) {
   var ddl = window.document.getElementById(obj);
   for (var i = 0; i < ddl.length; i++) {
       if (ddl.options[i].value == value) {
           ddl.options[i].selected = true;
       }
   }
   return true;
}

function BindDropDownList(obj, dtable, iid, name) {
    var ddl = window.document.getElementById(obj);
    for (var i = ddl.length - 1; i >= 0; i--) {
        ddl.remove(i);
    }
    if (dtable != null && typeof (dtable) == "object") {
        for (var q = 0; q < dtable.Rows.length; q++) {
            ddl.options.add(new Option(dtable.Rows[q][name], dtable.Rows[q][iid]));
        }
    }
    return true;
}
/////////////////////////////////////////////////////子表
//window.onresize = function() { AdjustSize(); AdjustSize2(); }
function OnInit(s, e) {

    AdjustSize();

}

function OnEndCallback(s, e) {

    AdjustSize();

}

function OnControlsInitialized(s, e) {

    ASPxClientUtils.AttachEventToElement(window, "resize", function(evt) {

        AdjustSize();

    });

}

function AdjustSize() {
    
    var objheight = document.getElementById("_ctl0_hiddenheight")
    if (objheight == null) {
        objheight = document.getElementById("_ctl0__ctl0_hiddenheight");
    }

    var height = 0;
    if (objheight != null) {
        height = objheight.value;
    }
    if (height == 0) {
        height = document.documentElement.clientHeight;
        if (objheight != null) {
            objheight.value = height;
        }
    }
    
//    var objwidth = document.getElementById("_ctl0_hiddenwidth")
//    if (objwidth != null) {
//        objwidth = document.getElementById("_ctl0__ctl0_hiddenwidth");
//    }
//    
//    var width = 0;
//    if (objwidth != "0") {
//        width = objwidth.value;
//    }
//    if (width == "") {
//        width = document.documentElement.clientWidth;
//        objwidth.value = width;
//    }
//    alert("A");
    var obj = document.all;
    var top = 0;
    var i = 0;
    var left = 0;
    var d;
    var len = obj.length;
    var dsel;
    var img;

    while (top == 0 && i < len) {
        var c = obj[i];
        
        if (c != null && c.id.indexOf("divSel") > -1) {
            top = c.offsetTop;
            left = c.offsetLeft;
            d = c;
        }
        if (c != null && c.id.indexOf("ASPxGridViewSel") > -1) {
            top = c.offsetTop;
            left = c.offsetLeft;
            dsel = c;
//            alert(dsel);
        }
        if (c != null && c.id.indexOf("WebChartControl1") > -1) {
            alert(c.id);
            img = c;
        }
        i = i + 1;
    }     
//    alert(height);
//    alert(top);
    if (d != null) {

        ASPxGridView1.SetHeight(height - top - 40);
        
        
//        ASPxGridView1.SetWidth(width - left - 10);
    }
    if (dsel != null) {
        ASPxGridViewSel.SetHeight(height - 40);
    }
    if (img != null) {
        img.style.height(height - top - 40);
    }
}

////////////////////////////////////////
function OnInit2(s, e) {

    AdjustSize2();

}

function OnEndCallback2(s, e) {

    AdjustSize2();

}

function OnControlsInitialized2(s, e) {

    ASPxClientUtils.AttachEventToElement(window, "resize", function(evt) {

        AdjustSize();

    });

}

function AdjustSize2() {
    var height = document.documentElement.clientHeight;
    var width = document.documentElement.clientWidth;
    var obj = document.all;
    var top = 0;
    var i = 0;
    var left = 0;
    var d;
    var len = obj.length;
    while (top == 0 && i < len) {
        var c = obj[i];
        if (c != null && c.id.indexOf("ASPxGridView2") > -1) {
            top = c.offsetTop;
            left = c.offsetLeft;
            height = 200;
            //height = (height-top) / 2;
//            if (height < 230) {
//                height = 230;
//            }
            d = c;
        }
        i = i + 1;
    }
    if (d != null) {
        ASPxGridView2.SetHeight(height);
        ASPxGridView2.SetWidth(width - left - 10);
    }
}

////////////////////////////////////////////////////

function GetDefaultImg() {
    return "R0lGODlhQgBgAPcAAC49TaWttUxbadnf43uEjcTM0EJPXGJteI6ZojlIVba + xOTp7NHY3Gt4g1ZhbYeSnD9MWt7l55ykrEpWZLzDyKuyuMvR1XF9iVNgbDpKWmhzfjdFVNbc336Jk0JRYVtodebs7r / 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AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
}

//身份证
function IsCardno(obj) {
    var txt = document.getElementById(obj).value.toUpperCase();
    if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(txt))) {
        alert(Ajax.AjaxMethod.GetAlert(6).value);
        document.getElementById(obj).focus();
        return false;
    }
    return true;
}
//电话号码
function IsPhone(obj) {
    var txt = document.getElementById(obj).value.toUpperCase();
    if (!(/^1[3,5]\d{9}$/).test(txt) && !(/^0(([1-9]\d)|([3-9]\d{2}))\d{8}$/).test(txt)) {
        alert(Ajax.AjaxMethod.GetAlert(10).value);
        document.getElementById(obj).focus();
        return false;
    }
    return true;
}
//是否是数字
function IsNumber(obj) {
    var txt = document.getElementById(obj).value.toUpperCase();
    if (!(/^[0-9]*[1-9][0-9]*$/).test(txt)) {
        return false;
    }
    return true;
}
//是否为空
function IsEmpty(obj, lbl) {
    var txt = document.getElementById(obj);
    if (txt.value == "") {
        alert(lbl + " " + Ajax.AjaxMethod.GetAlert(1).value);
        txt.focus();
        return false;
    }
    return true;
}

//是否包含字符串
function HasChar(obj, lbl, ichar) {
    var txt = document.getElementById(obj);
    if (txt.value.indexOf(ichar) >= 0) {
        alert(lbl + " " + Ajax.AjaxMethod.GetAlert(22).value + "'" + ichar + "'");
        txt.focus();
        return false;
    }
    return true;
}


function StartDropDownList(obj, sid) {
    alert(sid.value);
    for (var i = 0; i < obj.length; i++) {
        if (obj.options[i].value == sid.value) {
            obj[i].selected = true;
        }
    }
}
function ChangeDropDownList(obj, sid) {
    for (var i = 0; i < obj.length; i++) {
        if (obj[i].selected == true) {
            sid.value = obj.options[i].value;
        }
    }
}


function SelectDate(obj) {
    $(obj).datetimepicker({
        language: 'zh-CN',
        format: 'yyyy-mm-dd',
        minView: '2',
        todayBtn: true,
        autoclose: true,
        todayHighlight: true,
        startDate: '2000-1-1',
        forceParse: false
    });
}


////////////////////////////////////////////////////弹出对话框
//参照
function ASPxButtonClick(s, flag) {
    var o = new Object();
    o.id = s.GetValue();
    o.flag = flag;
    var k = SelectModalDialog(o,flag);
    if (typeof (k.id) != "") {
        s.SetText(k.id);
        return true;
    }
    else {
        return false;
    }
}

function SelectModalDialog(s,flag) {
    if (s.flag != "") {
        var ow = "";
        var dwidth = "";
        var dheight = "";
        if (flag == "Ap") {
            ow = "../Share/SelectAp.aspx";
            dwidth = "950px";
            dheight = "500px";
        }
        else {
            ow = "../Share/Select.aspx";
            dwidth = "650px";
            dheight = "500px";
        }
        var k = showModalDialog(ow + "?flag=" + s.flag+"&id="+s.id, s, "dialogWidth:" + dwidth + ";dialogHeight:" + dheight + ";scrollbars:no;help:no;");
//        window.open(ow + "?flag=" + s.flag + "&id=" + s.id);
        if (k!=null && typeof (k.id) != "") {
            s.id = k.id;
            s.name = k.name;
            s.flag = k.flag;
            return s;
        }
        else {
            return false;
        }
    }
    else {
        alert("弹出对话框未设置");
        return false;
    }

}

////////////////////////////////////////////////////公用参照
//ASPxGridView1.GetEditor("cVenName").PerformCallback(s.GetValue().toString());
//客户
function ASPxButtoncCus_CheckedChanged(s, e) {
    ASPxButtonClick(s, "cCus");
}
function AspButcCus_CheckedChanged(s, e) {

    ASPxButtonClick(s, "cCus");
    var obj = Ajax.PublicAjaxMethod.GetVerdorName(s.GetValue());
    if (obj != null) {
        ASPxGridView1.GetEditor("cVenName").SetValue(obj.value);
    }

}

function AspButcCus_TextChanged(s, e) {
    var value = s.GetValue();
    var obj = Ajax.PublicAjaxMethod.GetVerID(value);
    if (obj != null && obj.value != "") {
        s.SetValue(obj.value);
    }
    var obj2 = Ajax.PublicAjaxMethod.GetVerName(obj.value);
    if (obj2 != null && obj2.value != "") {

        ASPxGridView1.GetEditor("cCusName").SetValue(obj2.value);
        value = obj2.value;

    }
    else {
        AspButcCus_CheckedChanged(s, "cCus");
    }
//    var obj = Ajax.PublicAjaxMethod.GetVerdorName(s.GetValue());
//    if (obj != null) {
//        ASPxGridView1.GetEditor("cVenName").SetValue(obj.value);
//    }
//    if (s.GetValue() != null) {
//        var obj = Ajax.PublicAjaxMethod.CheckVerdor(s.GetValue());
//        if (obj.value == false) {
//            AspButVendor_CheckedChanged(s, "Vendor");
//            return false;
//        }
//    }
}
//分类
function ASPxButtoncInv_CheckedChanged(s, e) {
    ASPxButtonClick(s, "cInv");
}
function AspButcInv_CheckedChanged(s, e) {

    ASPxButtonClick(s, "cInv");

    var obj = Ajax.PublicAjaxMethod.GetcInvName(s.GetValue());
    if (obj != null) {
        ASPxGridView1.GetEditor("cDepName").SetValue(obj.value);
    }
//    var obj2 = Ajax.PublicAjaxMethod.GetcInvNameLike(s.GetValue());
//    if (obj2 != null) {
//        s.SetValue(obj2.value);
//    }
}
function AspButcInv_TextChanged(s, e) {
    var value = s.GetValue();
    var obj = Ajax.PublicAjaxMethod.GetDeptID(value);
    if (obj != null && obj.value!="") {
        s.SetValue(obj.value);
    }
    var obj2 = Ajax.PublicAjaxMethod.GetDeptName(obj.value);
    if (obj2 != null && obj2.value != "") {
        
        
        ASPxGridView1.GetEditor("cDepName").SetValue(obj2.value);
        value = obj2.value;
    }
    else {
        AspButcInv_CheckedChanged(s, "cInv");
    }
}
//全选

function doCheckChangeAll(s, e) {
    var chk = s.GetChecked();
    //var irow = ASPxGridView1.GetRow(0).cells(0);

    var obj = document.all;
    for (var i = 0; i < obj.length; i++) {
        var c = obj[i];
        if (c.id.indexOf("CheckBox1") > -1) {
            try {
                eval(c.id).SetChecked(chk);
            }
            catch (e) {
            }
        }

    }
    return false;

}