/*
function MouseDownToResize(obj){ 
setTableLayoutToFixed(); 
obj.mouseDownX=event.clientX; 
obj.pareneTdW=obj.parentElement.offsetWidth; 
obj.pareneTableW=theObjTable.offsetWidth; 
obj.setCapture(); 
} 
function MouseMoveToResize(obj){ 
    if(!obj.mouseDownX) return false; 
    var newWidth=obj.pareneTdW*1+event.clientX*1-obj.mouseDownX; 
    if(newWidth>10) 
    { 
	var theObjTable = document.getElementById("SmartGridView1");
	obj.parentElement.style.width = newWidth; 
	theObjTable.style.width=obj.pareneTdW*1+event.clientX*1-obj.mouseDownX; 
	} 
} 
function MouseUpToResize(obj){ 
obj.releaseCapture(); 
obj.mouseDownX=0; 
} 
function setTableLayoutToFixed() 
{ 
 var theObjTable = document.getElementById("SmartGridView1");
 if(theObjTable.style.tableLayout=='fixed') return; 
   var headerTr=theObjTable.rows[0]; 
    for(var i=0;i<headerTr.cells.length;i++) 
    { 
    headerTr.cells[i].styleOffsetWidth=headerTr.cells[i].offsetWidth; 
    } 
     
    for(var i=0;i<headerTr.cells.length;i++) 
    { 
    headerTr.cells[i].style.width=headerTr.cells[i].styleOffsetWidth; 
    } 
    theObjTable.style.tableLayout='fixed'; 
} 

function theObjTable(o,a,b,c){
	var t=document.getElementById(o).getElementsByTagName("tr");
	for(var i=0;i<t.length;i++){
		t[i].style.backgroundColor=(t[i].sectionRowIndex%2==0)?a:b;
		t[i].onclick=function(){
			if(this.x!="1"){
			}else{
				this.x="0";
				this.style.backgroundColor=(this.sectionRowIndex%2==0)?a:b;
			}
		}
		t[i].onmouseover=function(){
			if(this.x!="1")this.style.backgroundColor=c;
		}
		t[i].onmouseout=function(){
			if(this.x!="1")this.style.backgroundColor=(this.sectionRowIndex%2==0)?a:b;
		}
	}
}
*/

//2011-1-21
//www.cnblogs.com/xxfss2


 var lineMove = false;
 var currTh = null;
 $(document).ready(function() {//function(event) { $(this).css({ 'cursor': '/web/Page/frameset/images/splith.cur' }
     $("body").append("<div id=\"line\" style=\"width:1px;height:200px;border-left:1px solid #00000000; position:absolute;display:none\" ></div> ");
     $("body").bind("mousemove", function(event) {
         if (lineMove == true) {
             $("#line").css({ "left": event.clientX }).show();
         }
     });

     $("th").bind("mousemove", function(event) {
         var th = $(this);
         if (th.prevAll().length <= 1 || th.nextAll().length < 1) {
             return;
         }
         var left = th.offset().left;
         if (event.clientX - left < 6 || (th.width() - (event.clientX - left)) < 6) {
             th.css({ 'cursor': 'e-resize' });
         }
         else {
             th.css({ 'cursor': 'default' });
             }
             
         if (lineMove == true) {
             $("#line").hide();
             var pos = currTh.offset();
             var index = currTh.prevAll().length;
             currTh.width(event.clientX - pos.left);
             currTh.parent().parent().find("tr").each(function() {
                 $(this).children().eq(index).width(event.clientX - pos.left);
             }); //.children().eq(index).width(event.clientX - pos.left);
         }
     });

     $("th").bind("mousedown", function(event) {
         var th = $(this);
         if (th.prevAll().length <= 1 | th.nextAll().length < 1) {
             return;
         }
         var pos = th.offset();
         if (event.clientX - pos.left < 6 || (th.width() - (event.clientX - pos.left)) < 6) {
             var height = th.parent().parent().height();
             var top = pos.top;
             $("#line").css({ "height": height, "top": top,"left":event .clientX,"display":"" });
             lineMove = true;
             if (event.clientX - pos.left < th.width() / 2) {
                 currTh = th.prev();
             }
             else {
                 currTh = th;
             }
         }
     });

     $("body").bind("mouseup", function(event) {
         if (lineMove == true) {
             $("#line").hide();
             lineMove = false;
             var pos = currTh.offset();
             var index = currTh.prevAll().length;
             currTh.width(event.clientX - pos.left);
             currTh.parent().parent().find("tr").each(function() {
                 $(this).children().eq(index).width(event.clientX - pos.left);
             }); //.children().eq(index).width(event.clientX - pos.left);
         }
     });
 });