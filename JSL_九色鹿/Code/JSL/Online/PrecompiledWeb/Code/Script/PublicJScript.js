//网页内按下回车触发
function document.onkeydown()
{
    if(event.keyCode==13)
    {
        event.returnValue=false;  
    }
    else if (event.keyCode==116)
    {     
        event.keyCode=0;     
        event.returnValue=false;  
    }     
}

////输入为数字,可为小数
//function KeyPressInt(){
//return ((event.keyCode=50));
//  //return ((event.keyCode >= 48) && (event.keyCode <= 57));
//}

function KeyPressText(str,isNumber)
{
    if(document.getElementById(isNumber).value=="true")
    {
        KeyPressNumber(str);
    }
}

function KeyPressNumber(str){    
   if(event.keyCode==46 && str.length==0)//起始位置不能输入小数点    
   {    
        alert("输入错误！请输入0--9之间的数字或'-'");    
        event.returnValue = false;    
   }else{    
        if(str.lastIndexOf('.')!=-1 && event.keyCode==46)//以有小数点并且按的是点键    
        {    
            alert("输入错误！请输入0--9之间的数字");    
            event.returnValue = false;    
           return;    
        }    
        if(event.keyCode==46 && str.lastIndexOf('.')==-1)//没有小数点    
        {    
             if(str.substr(0,1)=="-" && str.length==1)//并且当是负数时减号后面不能跟小数点    
            {        
                alert("输入错误！请输入数字");   
                event.returnValue = false;    
                return;    
            }    
            event.returnValue = true;    
            return;    
        }else  
        {    
            if (event.keyCode < 48 || event.keyCode > 57)//确认输入的是否是数字    
            {    
                 if(str.length==0 && event.keyCode==45)   
                 {
                    
                 }   
                 else  
                 {    
                    alert("输入错误！请输入0--9之间的数字");    
                    event.returnValue = false;    
                 }    
            }    
        }    
      }    
}    


////数字 包括正数小数
//function KeyPressPositiveNumber(str)
//{

//    var tmp=document.getElementById(str).value;
//    if((event.keyCode>=48 && event.keyCode<=57) ||event.keyCode==45)
//    {
//        if(tmp.lastIndexOf('.')!=-1 && event.keyCode==45)//已有小数点并且按的是点键    
//        {
//            alert("输入错误！请输入0--9之间的数字");    
//            event.returnValue = false;
//        }
//        else if(tmp.lastIndexOf('.')==0)
//        {
//            alert("输入错误！请输入0--9之间的数字");    
//            event.returnValue = false;
//        }
//    }
//    else
//    {
//        alert("输入错误！请输入0--9之间的数字、减号或小数点！");    
//        event.returnValue = false;    
//    }
//}

//数字 包括负数小数
function KeyPressNegativeNumber(str)
{
    var tmp=document.getElementById(str).value;
    if((event.keyCode>=48 && event.keyCode<=57) ||event.keyCode==45 ||event.keyCode==46)
    {
        if(tmp.lastIndexOf('.')!=-1 && event.keyCode==46)//已有小数点并且按的是点键    
        {
            alert("输入错误！请输入0--9之间的数字");    
            event.returnValue = false;
        }
        else if(tmp.lastIndexOf('-')!=-1 && event.keyCode==45)//已有负号并且按的是负号    
        {
            alert("输入错误！请输入0--9之间的数字");    
            event.returnValue = false;
        }
        else if(tmp.lastIndexOf('-')>0)
        {
            alert("输入错误！请输入0--9之间的数字");    
            event.returnValue = false;
        }
        else if(tmp.lastIndexOf('-')==0 && tmp.lastIndexOf('.')==1)
        {
            alert("输入错误！请输入0--9之间的数字");    
            event.returnValue = false;
        }
        else if(tmp.lastIndexOf('.')==0)
        {
            alert("输入错误！请输入0--9之间的数字");    
            event.returnValue = false;
        }
    }
    else
    {
        alert("输入错误！请输入0--9之间的数字、减号或小数点！");    
        event.returnValue = false;    
    }
}

//function RdoClick(id,s) 
//{
////alert(id.checked);
//if(id.checked==true)
//{
//id.checked=false;
//}
//else
//{
//id.checked=true;
//}
////    if(id.checked==true)
////    {
////        id.checked = false;
////    }
//}

function formatDate(date,pattern){ 
    var d;   
    if((d=parseDate(date))==null){   
        return "";   
    }   
    if(!pattern){   
        pattern = "yyyy-MM-dd";   
    }   
    var arrWeek = ["星期日","星期一","星期二","星期三","星期四","星期五","星期六","Sunday","Monday","Tuesday","Tuesday","Thursday","Friday","Saturday"];   
    var value = new Object();   
    value["y"] = parseString(date.getFullYear());   
    value["M"] = parseString(date.getMonth() + 1);   
    value["d"] = parseString(date.getDate());   
    value["H"] = parseString(date.getHours());   
    value["h"] = parseString(value["H"] > 12 ? (value["H"]-12) : value["H"]);   
    value["m"] = parseString(date.getMinutes());   
    value["s"] = parseString(date.getSeconds());   
    value["S"] = parseString(date.getMilliseconds());   
    value["E"] = arrWeek[date.getDay()];   
    value["e"] = arrWeek[date.getDay() + 7];   
    value["a"] = (value["H"] > 12 ? "PM" : "AM");   
    value["A"] = (value["H"] > 12 ? "下午" : "上午");   
    var result = "";   
    var i = 0;   
    var hasE = false;//是否出现过星期   
    var hasAMPM = false;//是否出现过上午下午   
    while(i < pattern.length){   
        var c = pattern.charAt(i++);   
        var lc = c;//记录本次要处理的字母,如'y'   
        var tmpStr = c;//本次在处理的字母格式,如'yyyy'   
        while(i < pattern.length && (c=pattern.charAt(i))==lc){   
            tmpStr += c;   
            i++;   
        }   
        if(value[lc]!=""&&value[lc]!=null&&value[lc]!="undefined"){   
            //本次要处理的字母是模式母   
            if((lc == "E" || lc == "e") && !hasE){   
                //星期   
                result += value[lc];   
                hasE = true;   
            } else if(lc == "E" || lc == "e") {   
                result += tmpStr;   
            } else if((lc=="a" || lc == "A")  && !hasAMPM){   
                //上下午   
                result += value[lc];   
                hasAMPM = true;   
            } else if((lc=="a" || lc == "A") ){   
               result += tmpStr;   
            } else {   
                //如果是 单个的日期，月份，小时，分，秒的字符串，不能再进行字符串的截取操作   
              if(tmpStr == "d" || tmpStr == "M" || tmpStr=="H" || tmpStr=="h" || tmpStr == "m" || tmpStr == "s"){   
                    result += value[lc];   
                } else {   
                    result += value[lc].fillChar(tmpStr.length);   
               }   
            }   
      } else {//非模式字母，直接输出   
           result += tmpStr;   
        }   
    }   
    return result;   
}  

function parseDate(value) {   
    var date = null;   
    if (Date.prototype.isPrototypeOf(value)) {   
        date = value;   
    } else if (typeof (value) == "string") {   
        date = new Date(value.replace(/-/g, "/"));   
    } else if (value != null && value.getTime) {   
        date = new Date(value.getTime());   
    }   
    ;   
    return date;   
};   
  
/**  
 * 将对象转换为字符串类型  
 */  
function parseString(value) {   
    if (value == null) {   
        return "";   
    } else {   
        return value.toString();   
    }   
};   
String.prototype.fillChar = function(length,mode,char){   
    if(!char){   
        char = "0";   
    }   
    if(this.length>length){//比实际想要的长度更大   
        if(mode=="after"){//如果是要在后面填充，截取的时候会将会后面的部分截取掉   
            return this.substr(0,length);   
       } else {//默认截取前一部分的数据   
           return this.substr(this.length - length,length);   
       }   
    }   
    var appendStr = "";   
    for(var i = 0; i < (length - this.length)/char.length;i++){   
        appendStr += char;   
    }   
    if(mode == "after"){   
        return this + appendStr;   
   }   
    else {   
       return appendStr + this;   
    }   
};  

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



//var format = '{0}\r\n{1}';
    
//document.all.onmouseover = function()
//{alert(this.innerText);
//    if(this.innerText!="")
//    {
//        var srcElmt = event.srcElement;
//        srcElmt.title=this.innerText;
//    }
////    
////    if ( srcElmt && srcElmt.tagName )
////    {
////        if ( srcElmt.clientWidth < srcElmt.scrollWidth )
////        {
////            if ( !srcElmt.__title )
////            {
////                if ( srcElmt.title == srcElmt.innerText )
////                {
////                    return;
////                }
////                if ( srcElmt.title )
////                {
////                    srcElmt.__title = srcElmt.title;
////                }
////            }
////            else
////            {
////                return;
////            }
////            if ( srcElmt.__title )
////            {
////                srcElmt.title = StringHelper.Format(format, srcElmt.__title, srcElmt.innerText);
////            }
////            else
////            {
////                srcElmt.title = srcElmt.innerText;
////            }
////        }
////    }
//}

//document.body.onmouseout = function()
//{
//    var srcElmt = event.srcElement;
//    if ( srcElmt && srcElmt.tagName )
//    {
//        if ( srcElmt.clientWidth >= srcElmt.scrollWidth )
//        {
//            if ( srcElmt.__title )
//            {
//                srcElmt.title = srcElmt.__title;
//                srcElmt.__title = null;
//            }
//            else
//            {
//                if ( srcElmt.title == srcElmt.innerText )
//                {
//                    srcElmt.title = '';
//                }
//            }
//        }
//    }
//}
function fnExist(fnName) {   
       //return fnName in this && eval(fnName) instanceof Function;   
       return fnName in this && typeof (eval(fnName)) == "function";   
      }  