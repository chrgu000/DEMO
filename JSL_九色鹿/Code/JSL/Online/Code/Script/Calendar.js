
var cal;
var isFocus=false; //是否为焦点
function SelectDate(obj)
{
    var date = new Date();
    var by = date.getFullYear()-150;  //最小值 → 150 年前
    var ey = date.getFullYear()+50;  //最大值 → 50 年后
    //cal = new Calendar(by, ey,1,strFormat);    //初始化英文版，0 为中文版
    cal = (cal==null) ? new Calendar(by, ey, 0) : cal;    //不用每次都初始化 2006-12-03 修正
    cal.dateFormatStyle = "yyyy-MM-dd";
    cal.show(obj);
}
/**//**//**//**//**//**//**//**
* 返回日期
*/
String.prototype.toDate = function(style) {
  var y = this.substring(style.indexOf('y'),style.lastIndexOf('y')+1);//年
  var m = this.substring(style.indexOf('M'),style.lastIndexOf('M')+1);//月
  var d = this.substring(style.indexOf('d'),style.lastIndexOf('d')+1);//日
  if(isNaN(y)) y = new Date().getFullYear();
  if(isNaN(m)) m = new Date().getMonth();
  if(isNaN(d)) d = new Date().getDate();
  var dt ;
  eval ("dt = new Date('"+ y+"', '"+(m-1)+"','"+ d +"')");
  return dt;
}

/**//**//**//**//**//**//**//**
* 格式化日期
* @param   d the delimiter
* @param   p the pattern of your date
* @author  meizz
*/
Date.prototype.format = function(style) {
  var o = {
    "M+" : this.getMonth() + 1, //month
    "d+" : this.getDate(),      //day
    "h+" : this.getHours(),     //hour
    "m+" : this.getMinutes(),   //minute
    "s+" : this.getSeconds(),   //second
    "w+" : "天一二三四五六".charAt(this.getDay()),   //week
    "q+" : Math.floor((this.getMonth() + 3) / 3),  //quarter
    "S"  : this.getMilliseconds() //millisecond
  }
  if(/(y+)/.test(style)) {
    style = style.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
  }
  for(var k in o){
    if(new RegExp("("+ k +")").test(style)){
      style = style.replace(RegExp.$1,
        RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    }
  }
  return style;
};

/**//**//**//**//**//**//**//**
* 日历类
* @param   beginYear 1990
* @param   endYear   2010
* @param   lang      0(中文)|1(英语) 可自由扩充
* @param   dateFormatStyle  "yyyy-MM-dd";
* @update
*/
function Calendar(beginYear, endYear, lang, dateFormatStyle) {
  this.beginYear = 1990;
  this.endYear = 2010;
  this.lang = 0;  
  this.dateFormatStyle = "yyyy-MM-dd";

  if (beginYear != null && endYear != null){
    this.beginYear = beginYear;
    this.endYear = endYear;
  }
  if (lang != null){
    this.lang = lang
  }

  if (dateFormatStyle != null){
    this.dateFormatStyle = dateFormatStyle
  }

  this.dateControl = null;
  this.container=this.getElementById("ContainerPanel");
  this.container1=this.getElementById("ContainerPanel1");
  this.container2=this.getElementById("ContainerPanel2");
  this.form  = null;

  this.date = new Date();
  this.year = this.date.getFullYear();
  this.month = this.date.getMonth();


  this.colors = {
  "cur_word"      : "#FFFFFF",  //当日日期文字颜色
  "cur_bg"        : "#00FF00",  //当日日期单元格背影色
  "sel_bg"        : "#FFCCCC",  //已被选择的日期单元格背影色
  "sun_word"      : "#FF0000",  //星期天文字颜色
  "sat_word"      : "#0000FF",  //星期六文字颜色
  "td_word_light" : "#333333",  //单元格文字颜色
  "td_word_dark"  : "#CCCCCC",  //单元格文字暗色
  "td_bg_out"     : "#EFEFEF",  //单元格背影色
  "td_bg_over"    : "#FFCC00",  //单元格背影色
  "tr_word"       : "#FFFFFF",  //日历头文字颜色
  "tr_bg"         : "#666666",  //日历头背影色
  "input_border"  : "#CCCCCC",  //input控件的边框颜色
  "input_bg"      : "#EFEFEF"   //input控件的背影色
  }

  this.draw();
  this.bindYear();
  this.bindMonth();
}

/**//**//**//**//**//**//**//**
* 日历类属性（语言包，可自由扩展）
*/
Calendar.language = {
  "year"   : [[""], [""]],
  "months" : [["一月","二月","三月","四月","五月","六月","七月","八月","九月","十月","十一月","十二月"],
        ["JAN","FEB","MAR","APR","MAY","JUN","JUL","AUG","SEP","OCT","NOV","DEC"]
         ],
  "weeks"  : [["日","一","二","三","四","五","六"],
        ["SUN","MON","TUR","WED","THU","FRI","SAT"]
         ],
  "clear"  : [["清空"], ["CLS"]],
  "today"  : [["今天"], ["TODAY"]],
  "close"  : [["关闭"], ["CLOSE"]]
}

Calendar.prototype.draw = function() {
  calendar = this;

  var mvAry = [];
  mvAry[mvAry.length]  = '    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;">';
  mvAry[mvAry.length]  = '      <tr>';
  mvAry[mvAry.length]  = '        <th>';
  mvAry[mvAry.length]  = '            <input style="border: solid 1px ' + calendar.colors["input_border"] + ';background-color:' + calendar.colors["input_bg"] + ';width:28px;position:absolute;top:0px;left:0px" name="prevYear" type="button" id="prevYear" value="<<" />';
  mvAry[mvAry.length]  = '            <input style="border: solid 1px ' + calendar.colors["input_border"] + ';background-color:' + calendar.colors["input_bg"] + ';width:24px;position:absolute;top:0px;left:28px" name="prevMonth" type="button" id="prevMonth" value="&lt;" />';
  mvAry[mvAry.length]  = '            <div style="overflow-x:hidden;width:30px;position:absolute;top:0px;left:52px;"><select style="width:50px;font-size:12px;margin:-1px" name="calendarYear" id="calendarYear" ></select></div>';
  mvAry[mvAry.length]  = '            <div style="overflow-x:hidden;width:41px;position:absolute;top:0px;left:82px;"><select style="width:60px;font-size:12px;margin:-1px" name="calendarMonth" id="calendarMonth"  ></select></div>';
  mvAry[mvAry.length]  = '            <input style="border: solid 1px ' + calendar.colors["input_border"] + ';background-color:' + calendar.colors["input_bg"] + ';width:24px;position:absolute;top:0px;left:123px;" name="nextMonth" type="button" id="nextMonth" value="&gt;" />';
  mvAry[mvAry.length]  = '            <input style="border: solid 1px ' + calendar.colors["input_border"] + ';background-color:' + calendar.colors["input_bg"] + ';width:28px;position:absolute;top:0px;left:147px;" name="nextYear" type="button" id="nextYear" value=">>" />';
  mvAry[mvAry.length]  = '        </th>';
  mvAry[mvAry.length]  = '      </tr>';
  mvAry[mvAry.length]  = '    </table>';
  mvAry[mvAry.length]  = '    <table id="calendarTable" border="0" cellpadding="0" cellspacing="0" style="position:absolute;top:15px;left:0px;border-collapse:collapse;">';
  mvAry[mvAry.length]  = '      <tr>';
  for(var i = 0; i < 7; i++) {
    mvAry[mvAry.length]  = '      <th style="width:25px;height:15px;border:solid 1px #ffffff;font-weight:normal;background-color:' + calendar.colors["tr_bg"] + ';color:' + calendar.colors["tr_word"] + ';">' + Calendar.language["weeks"][this.lang][i] + '</th>';
  }
  mvAry[mvAry.length]  = '      </tr>';
  for(var i = 0; i < 6;i++){
    mvAry[mvAry.length]  = '    <tr align="center">';
    for(var j = 0; j < 7; j++) {
      if (j == 0){
        mvAry[mvAry.length]  = '  <td style="cursor:default;color:' + calendar.colors["sun_word"] + ';border:solid 1px #ffffff;width:25px;height:15px"></td>';
      } else if(j == 6) {  
        mvAry[mvAry.length]  = '  <td style="cursor:default;color:' + calendar.colors["sat_word"] + ';border:solid 1px #ffffff;width:25px;height:15px"></td>';
      } else {
        mvAry[mvAry.length]  = '  <td style="cursor:default;border:solid 1px #ffffff;width:25px;height:15px"></td>';
      }
    }
    mvAry[mvAry.length]  = '    </tr>';
  }
  mvAry[mvAry.length]  = '      <tr style="background-color:' + calendar.colors["input_bg"] + ';">';
  mvAry[mvAry.length]  = '        <th colspan="2" style="height:15px;border:0;"><input name="calendarClear" type="button" id="calendarClear" value="' + Calendar.language["clear"][this.lang] + '" style="border: 1px solid ' + calendar.colors["input_border"] + ';background-color:' + calendar.colors["input_bg"] + ';width:100%;font-size:12px;"/></th>';
  mvAry[mvAry.length]  = '        <th colspan="3" style="height:15px;border:0;"><input name="calendarToday" type="button" id="calendarToday" value="' + Calendar.language["today"][this.lang] + '" style="border: 1px solid ' + calendar.colors["input_border"] + ';background-color:' + calendar.colors["input_bg"] + ';width:100%;font-size:12px;"/></th>';
  mvAry[mvAry.length]  = '        <th colspan="2" style="height:15px;border:0;"><input name="calendarClose" type="button" id="calendarClose" value="' + Calendar.language["close"][this.lang] + '" style="border: 1px solid ' + calendar.colors["input_border"] + ';background-color:' + calendar.colors["input_bg"] + ';width:100%;font-size:12px;"/></th>';
  mvAry[mvAry.length]  = '      </tr>';
  mvAry[mvAry.length]  = '    </table>';
  this.container.innerHTML = mvAry.join("");
  
  var obj = this.getElementById("prevMonth");
  obj.onclick = function () {calendar.goPrevMonth(calendar);}
  obj.onblur = function () {calendar.onblur();}
  this.prevMonth= obj;
  
  obj = this.getElementById("nextMonth");
  obj.onclick = function () {calendar.goNextMonth(calendar);}
  obj.onblur = function () {calendar.onblur();}
  this.nextMonth= obj;
  
  var obj = this.getElementById("prevYear");
  obj.onclick = function () {calendar.goPrevYear(calendar);}
  obj.onblur = function () {calendar.onblur();}
  this.prevYear= obj;
  
  obj = this.getElementById("nextYear");
  obj.onclick = function () {calendar.goNextYear(calendar);}
  obj.onblur = function () {calendar.onblur();}
  this.nextYear= obj;

obj = this.getElementById("calendarClear");
  obj.onclick = function () {calendar.dateControl.value = "";calendar.hide();}
  this.calendarClear = obj;
  
  obj = this.getElementById("calendarClose");
  obj.onclick = function () {calendar.hide();}
  this.calendarClose = obj;
  
  obj = this.getElementById("calendarYear");
  obj.onchange = function () {calendar.update(calendar);}
  obj.onblur = function () {calendar.onblur();}
  this.calendarYear = obj;
  
  obj = this.getElementById("calendarMonth");
  with(obj)
  {
    onchange = function () {calendar.update(calendar);}
    onblur = function () {calendar.onblur();}
  }this.calendarMonth = obj;

  obj = this.getElementById("calendarToday");
  obj.onclick = function () {
    var today = new Date();
    calendar.dateControl.value = today.format(calendar.dateFormatStyle);
    calendar.hide();
  }
  this.calendarToday = obj;

}

//年份下拉框绑定数据
Calendar.prototype.bindYear = function() {
  var cy = this.calendarYear;
  cy.length = 0;
  for (var i = this.beginYear; i <= this.endYear; i++){
    cy.options[cy.length] = new Option(i + Calendar.language["year"][this.lang], i);
  }
}

//月份下拉框绑定数据
Calendar.prototype.bindMonth = function() {
  var cm = this.calendarMonth;
  cm.length = 0;
  for (var i = 0; i < 12; i++){
    cm.options[cm.length] = new Option(Calendar.language["months"][this.lang][i], i);
  }
}

//向前一月
Calendar.prototype.goPrevMonth = function(e){
  if (this.year == this.beginYear && this.month == 0){return;}
  this.month--;
  if (this.month == -1) {
    this.year--;
    this.month = 11;
  }
  this.date = new Date(this.year, this.month, 1);
  this.changeSelect();
  this.bindData();
}

//向后一月
Calendar.prototype.goNextMonth = function(e){
  if (this.year == this.endYear && this.month == 11){return;}
  this.month++;
  if (this.month == 12) {
    this.year++;
    this.month = 0;
  }
  this.date = new Date(this.year, this.month, 1);
  this.changeSelect();
  this.bindData();
}

//向前一年
Calendar.prototype.goPrevYear = function(e){
  if (this.year == this.beginYear && this.month == 0){return;}
  this.year--;
  this.date = new Date(this.year, this.month, 1);
  this.changeSelect();
  this.bindData();
}

//向后一年
Calendar.prototype.goNextYear = function(e){
  if (this.year == this.endYear && this.month == 11){return;}
  this.year++;
  this.date = new Date(this.year, this.month, 1);
  this.changeSelect();
  this.bindData();
}

//改变SELECT选中状态
Calendar.prototype.changeSelect = function() {
  var cy = this.calendarYear;
  var cm = this.calendarMonth;
  cy[this.date.getFullYear()-this.beginYear].selected = true;
  cm[this.date.getMonth()].selected =true;
}

//更新年、月
Calendar.prototype.update = function (e){
  this.year  = e.calendarYear.options[e.calendarYear.selectedIndex].value;
  this.month = e.calendarMonth.options[e.calendarMonth.selectedIndex].value;
  this.date = new Date(this.year, this.month, 1);
  this.changeSelect();
  this.bindData();
}

//绑定数据到月视图
Calendar.prototype.bindData = function () {
  var calendar = this;
  var dateArray = this.getMonthViewArray(this.date.getFullYear(), this.date.getMonth());
var tds = this.getElementById("calendarTable").getElementsByTagName("td");
  for(var i = 0; i < tds.length; i++) {
  tds[i].style.backgroundColor = calendar.colors["td_bg_out"];
    tds[i].onclick = function () {return;}
    tds[i].onmouseover = function () {return;}
    tds[i].onmouseout = function () {return;}
    if (i > dateArray.length - 1) break;
    tds[i].innerHTML = dateArray[i];
      if (dateArray[i] != "&nbsp;"){
      tds[i].onclick = function () {
        if (calendar.dateControl != null){
          calendar.dateControl.value = new Date(calendar.date.getFullYear(),
                                                calendar.date.getMonth(),
                                                this.innerHTML).format(calendar.dateFormatStyle);
        }
        calendar.hide();
      }
      tds[i].onmouseover = function () {
        this.style.backgroundColor = calendar.colors["td_bg_over"];
        this.style.cursor="hand";
      }
      tds[i].onmouseout = function () {
        this.style.backgroundColor = calendar.colors["td_bg_out"];
      }
      
      if (new Date().format(calendar.dateFormatStyle) ==
          new Date(calendar.date.getFullYear(),
                   calendar.date.getMonth(),
                   dateArray[i]).format(calendar.dateFormatStyle)) {
        tds[i].style.backgroundColor = calendar.colors["cur_bg"];
        tds[i].onmouseover = function () {
          this.style.backgroundColor = calendar.colors["td_bg_over"];
          
        }
        tds[i].onmouseout = function () {
          this.style.backgroundColor = calendar.colors["cur_bg"];
        }
      }
      
      //设置已被选择的日期单元格背影色
      if (calendar.dateControl != null && calendar.dateControl.value == new Date(calendar.date.getFullYear(),
                   calendar.date.getMonth(),
                   dateArray[i]).format(calendar.dateFormatStyle)) {
        tds[i].style.backgroundColor = calendar.colors["sel_bg"];
        tds[i].onmouseover = function () {
          this.style.backgroundColor = calendar.colors["td_bg_over"];
        }
        tds[i].onmouseout = function () {
          this.style.backgroundColor = calendar.colors["sel_bg"];
        }
      }
    }
  }
}

//根据年、月得到月视图数据(数组形式)
Calendar.prototype.getMonthViewArray = function (y, m) {
  var mvArray = [];
  var dayOfFirstDay = new Date(y, m, 1).getDay();
  var daysOfMonth = new Date(y, m + 1, 0).getDate();
  for (var i = 0; i < 42; i++) {
    mvArray[i] = "&nbsp;";
  }
  for (var i = 0; i < daysOfMonth; i++){
    mvArray[i + dayOfFirstDay] = i + 1;
  }
  return mvArray;
}

//扩展 document.getElementById(id) 多浏览器兼容性 from meizz tree source
Calendar.prototype.getElementById = function(id){
  if (typeof(id) != "string" || id == "") return null;
  if (document.getElementById) return document.getElementById(id);
  if (document.all) return document.all(id);
  try {return eval(id);} catch(e){ return null;}
}

//扩展 object.getElementsByTagName(tagName)
Calendar.prototype.getElementsByTagName = function(object, tagName){
  if (document.getElementsByTagName) return document.getElementsByTagName(tagName);
  if (document.all) return document.all.tags(tagName);
}

//取得HTML控件绝对位置
Calendar.prototype.getAbsPoint = function (e){
  var x = e.offsetLeft;
  var y = e.offsetTop;
  while(e = e.offsetParent){
    x += e.offsetLeft;
    y += e.offsetTop;
  }
  return {"x": x, "y": y};
}

//显示日历
Calendar.prototype.show = function (dateObj, popControl) {
  if (dateObj == null){
    throw new Error("arguments[0] is necessary")
  }
  this.dateControl = dateObj;
  
  this.date = (dateObj.value.length > 0) ? new Date(dateObj.value.toDate(this.dateFormatStyle)) : new Date() ;
  this.year = this.date.getFullYear();
  this.month = this.date.getMonth();
  this.changeSelect();
  this.bindData();
  if (popControl == null){
    popControl = dateObj;
  }
  var xy = this.getAbsPoint(popControl);

//  this.container1.style.left=(xy.x)+ "px";
//  this.container1.style.top = (xy.y + dateObj.offsetHeight) + "px";
  this.container1.style.left=(xy.x)+ "px";
  this.container1.style.top = (xy.y + dateObj.offsetHeight) + "px";
  this.container1.style.display = "";
  
  this.container.style.left=(xy.x)+ "px";
  this.container.style.top = (xy.y + dateObj.offsetHeight) + "px";
  this.container.style.display = "";
  
//  this.container2.style.left=(xy.x)+ "px";
//  this.container2.style.top = (xy.y + dateObj.offsetHeight) + "px";
  this.container2.style.display = "";
  
  dateObj.onblur = function(){calendar.onblur();}
  this.container.onmouseover = function(){isFocus=true;}
  this.container.onmouseout = function(){isFocus=false;}
}

//隐藏日历
Calendar.prototype.hide = function() {
  //this.panel.style.display = "none";
  this.container.style.display = "none";
  this.container1.style.display = "none";
//  this.container1.style.display = "none";
//  this.container2.style.display = "none";
  isFocus=false;  
}

//焦点转移时隐藏日历
Calendar.prototype.onblur = function() {
    if(!isFocus){this.hide();}
}

//// 用<iframe> 遮住 IE 的下拉框
////设置控件显示或隐藏
//Calendar.prototype.setDisplayStyle = function(tagName, style) {
//  var tags = this.getElementsByTagName(null, tagName)
//  for(var i = 0; i < tags.length; i++) {
//    if (tagName.toLowerCase() == "select" &&
//       (tags[i].name == "calendarYear" ||
//      tags[i].name == "calendarMonth")){
//      continue;
//    }
//    tags[i].style.display = style;
//  }
//}

document.write('<div id="ContainerPanel1" style="z-index:10;position:absolute;width:175px;heitht:150px;display:none;">');
document.write('<iframe id="ContainerPanel2" style="position:absolute;z-index:-1;width:100%;height:100%;top:0;left:0;scrolling:no;frameborder="0"></iframe> ');
document.write('<div id="ContainerPanel" style="width:175px;height:150px;display:none;" ></div></div>');




