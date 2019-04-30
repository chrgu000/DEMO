// 对Date的扩展，将 Date 转化为指定格式的String   
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
// 例子：   
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};

var Common = {
    /**
     * 格式化日期（不含时间）
     */
    formatterDate: function (date) {
        if (date == undefined) {
            return "";
        }
        /*json格式时间转js时间格式*/
        date = date.substr(1, date.length - 2);
        var obj = eval('(' + "{Date: new " + date + "}" + ')');
        var date = obj["Date"];
        if (date.getFullYear() < 1900) {
            return "";
        }

        var datetime = date.getFullYear()
                + "-"// "年"
                + ((date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0" + (date.getMonth() + 1))
                + "-"// "月"
                + (date.getDate() < 10 ? "0" + date.getDate() : date
                        .getDate());
        return datetime;
    },
    /**
     * 格式化日期（含时间"00:00:00"）
     */
    formatterDate2: function (date) {
        if (date == undefined) {
            return "";
        }
        /*json格式时间转js时间格式*/
        date = date.substr(1, date.length - 2);
        var obj = eval('(' + "{Date: new " + date + "}" + ')');
        var date = obj["Date"];
        if (date.getFullYear() < 1900) {
            return "";
        }

        /*把日期格式化*/
        var datetime = date.getFullYear()
                + "-"// "年"
                + ((date.getMonth() + 1) > 10 ? (date.getMonth() + 1) : "0"
                        + (date.getMonth() + 1))
                + "-"// "月"
                + (date.getDate() < 10 ? "0" + date.getDate() : date
                        .getDate()) + " " + "00:00:00";
        return datetime;
    },
    /**
     * 格式化去日期（含时间）
     */
    formatterDateTime: function (date) {
        if (date == undefined) {
            return "";
        }
        /*json格式时间转js时间格式*/
        date = date.substr(1, date.length - 2);
        var obj = eval('(' + "{Date: new " + date + "}" + ')');
        var date = obj["Date"];
        if (date.getFullYear() < 1900) {
            return "";
        }

        var datetime = date.getFullYear()
                + "-"// "年"
                + ((date.getMonth() + 1) >= 10 ? (date.getMonth() + 1) : "0" + (date.getMonth() + 1))
                + "-"// "月"
                + (date.getDate() < 10 ? "0" + date.getDate() : date
                        .getDate())
                + " "
                + (date.getHours() < 10 ? "0" + date.getHours() : date
                        .getHours())
                + ":"
                + (date.getMinutes() < 10 ? "0" + date.getMinutes() : date
                        .getMinutes())
                + ":"
                + (date.getSeconds() < 10 ? "0" + date.getSeconds() : date
                        .getSeconds());
        return datetime;
    },
    /**
    *获取当前时间
    */
    newDateTime: function () {
        var date = new Date();
        var seperator1 = "-";
        var seperator2 = ":";
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
                + " " + date.getHours() + seperator2 + date.getMinutes()
                + seperator2 + date.getSeconds();
        return currentdate;
    }
};


/*
*得到当前操作的事件对象
*/
function getEvent() {
    if (window.event) { return window.event; }
    var func = getEvent.caller;
    while (func != null) {
        var arg0 = func.arguments[0];
        if (arg0) {
            if ((arg0.constructor == Event || arg0.constructor == MouseEvent
            || arg0.constructor == KeyboardEvent)
            || (typeof (arg0) == "object" && arg0.preventDefault
            && arg0.stopPropagation)) {
                return arg0;
            }
        }
        func = func.caller;
    }
    return null;
}

/*
获取鼠标的位置
*/
function getMousePosition() {
    e = getEvent();
    var obj = e.currentTarget || document.activeElement;
    var position = {
        left: e.pageX || (e.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft)),
        top: e.pageY || (e.clientY + (document.documentElement.scrollTop || document.body.scrollTop))
    };
    return position;
}

/*
*取消当前操作的事件冒泡
*/
function CancelEventBubble() {
    var e = getEvent();
    if (window.event) {
        //e.returnValue=false;//阻止自身行为
        // 由于Chrome浏览器也能识别window.event对象，所以针对此浏览器再做区分
        if (!/chrome/.test(navigator.userAgent.toLowerCase())) {
            e.cancelBubble = true; //阻止冒泡
        }
        else {
            e.stopPropagation(); //阻止冒泡
        }
    } else if (e.preventDefault) {
        //e.preventDefault();//阻止自身行为
        e.stopPropagation(); //阻止冒泡
    }
}
/*
*阻止默认浏览器动作（主要用于阻止超链接）
*/
function CancelEvent() {
    var e = getEvent();
    if (e && e.preventDefault)
        //阻止默认浏览器动作(W3C) 
        e.preventDefault();
    else
        //IE中阻止函数器默认动作的方式 
        window.event.returnValue = false;
    return false;
}

/*
*截取取字符串长度(区分中英文)
str:被截取字符串
len:需截取的长度
*/
function LeftString(str, len) {
    if (str == null)
        return "";
    len *= 2;
    var actualLen = 0;

    for (var i = 0; i < str.length; i++) {
        if (str.charCodeAt(i) < 255)
            actualLen++;
        else
            actualLen += 2;
    }
    if (actualLen > len) {
        //拼接
        var s = "";
        for (var i = 0, index = 0; i < len - 1; index++) {
            s += str.charAt(index);
            if (str.charCodeAt(i) < 255)
                i++;
            else
                i += 2;
        }
        s += "...";
        return s;
    }
    else {
        return str;
    }
}

/*
得到字符串长度，中文按两个算
*/
function getStringLength(str) {
    var actualLen = 0;
    for (var i = 0; i < str.length; i++) {
        if (str.charCodeAt(i) < 255)
            actualLen++;
        else
            actualLen += 2;
    }
    return actualLen;
}

function GetIdTimestamp() {
    var array = "0123456789".split("");
    var str = "";
    var strts = "";
    for (var i = 0; i < 4; i++) {
        str += array[Math.floor(Math.random() * array.length)];
    }
    var reg = /^\d$/;
    var now = new Date;
    var y = now.getYear() + 1;
    var m = now.getMonth() + 1;
    var d = now.getDate();

    y = reg.test(y) ? "0" + y : y;
    m = reg.test(m) ? "0" + m : m;
    d = reg.test(d) ? "0" + d : d;
    strts += now.getFullYear() + m + d;

    var hh = now.getHours();
    var mi = now.getMinutes();
    var ss = now.getSeconds();

    hh = reg.test(hh) ? "0" + hh : hh;
    mi = reg.test(mi) ? "0" + mi : mi;
    ss = reg.test(ss) ? "0" + ss : ss;

    strts += hh.toString() + mi.toString() + ss.toString();
    str = strts + str;
    return str;
}

function ChangeToTable(printDatagrid) {
    var tableString = '<table border="1" cellspacing="0" class="pb">';
    var frozenColumns = printDatagrid.datagrid("options").frozenColumns;  // 得到frozenColumns对象  
    var columns = printDatagrid.datagrid("options").columns;    // 得到columns对象  
    var nameList = new Array();

    // 载入title  
    if (typeof columns != 'undefined' && columns != '') {
        $(columns).each(function (index) {
            tableString += '\n<tr>';
            //            if (typeof frozenColumns != 'undefined' && typeof frozenColumns[index] != 'undefined') {
            //                for (var i = 0; i < frozenColumns[index].length; ++i) {
            //                    if (!frozenColumns[index][i].hidden) {
            //                        tableString += '\n<th width="' + frozenColumns[index][i].width + '"';
            //                        if (typeof frozenColumns[index][i].rowspan != 'undefined' && frozenColumns[index][i].rowspan > 1) {
            //                            tableString += ' rowspan="' + frozenColumns[index][i].rowspan + '"';
            //                        }
            //                        if (typeof frozenColumns[index][i].colspan != 'undefined' && frozenColumns[index][i].colspan > 1) {
            //                            tableString += ' colspan="' + frozenColumns[index][i].colspan + '"';
            //                        }
            //                        if (typeof frozenColumns[index][i].field != 'undefined' && frozenColumns[index][i].field != '') {
            //                            nameList.push(frozenColumns[index][i]);
            //                        }
            //                        tableString += '>' + frozenColumns[0][i].title + '</th>';
            //                    }
            //                }
            //            }
            for (var i = 0; i < columns[index].length - 1; ++i) {
                if (!columns[index][i].hidden) {
                    tableString += '\n<th width="' + columns[index][i].width + '"';
                    if (typeof columns[index][i].rowspan != 'undefined' && columns[index][i].rowspan > 1) {
                        tableString += ' rowspan="' + columns[index][i].rowspan + '"';
                    }
                    if (typeof columns[index][i].colspan != 'undefined' && columns[index][i].colspan > 1) {
                        tableString += ' colspan="' + columns[index][i].colspan + '"';
                    }
                    if (typeof columns[index][i].field != 'undefined' && columns[index][i].field != '') {
                        nameList.push(columns[index][i]);
                    }
                    tableString += '>' + columns[index][i].title + '</th>';
                }
            }
            tableString += '\n</tr>';
        });
    }
    // 载入内容  
    var rows = printDatagrid.datagrid("getRows"); // 这段代码是获取当前页的所有行  
    for (var i = 0; i < rows.length; ++i) {
        tableString += '\n<tr>';
        for (var j = 0; j < nameList.length; ++j) {
            var e = nameList[j].field.lastIndexOf('_0');

            tableString += '\n<td';
            if (nameList[j].align != 'undefined' && nameList[j].align != '') {
                tableString += ' style="text-align:' + nameList[j].align + ';vnd.ms-excel.numberformat:@"';
            }
            tableString += '>';
            if (e + 2 == nameList[j].field.length) {
                tableString += String(rows[i][nameList[j].field.substring(0, e)]);
            }
            else
                if (String(rows[i][nameList[j].field]).indexOf('/Date') < 0)
                    tableString += String(rows[i][nameList[j].field]);
                else
                    tableString += Common.formatterDateTime(String(rows[i][nameList[j].field]));
            tableString += '</td>';
        }
        tableString += '\n</tr>';
    }
    tableString += '\n</table>';
    return tableString;

}


//将表单数据转为json
function form2Json(id) {

    var arr = $("#" + id).serializeArray()
    var jsonStr = "";

    jsonStr += '{';
    for (var i = 0; i < arr.length; i++) {
        jsonStr += '"' + arr[i].name + '":"' + arr[i].value + '",'
    }
    jsonStr = jsonStr.substring(0, (jsonStr.length - 1));
    jsonStr += '}'

    var json = JSON.parse(jsonStr)
    return json
}
