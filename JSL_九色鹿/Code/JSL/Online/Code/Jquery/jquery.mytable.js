// JScript 文件

$(function() {
            //在表格裡塞入選取欄位
//            $("#SmartGridView1 th:nth-child(1)")
//            .after("<th><input type='checkbox' id='cbxSelAll' /></th>");
//            $("#SmartGridView1 td:nth-child(1)")
//            .after("<td><input type='checkbox' class='clsHideCbx' /></td>");
            //配合SuperTable的多Table同步處理，加上列號
            $("#SmartGridView1 tr").each(function(i) {
                $(this).attr("rowidx", i)
                .find("td").each(function(j) {
                    $(this).attr("pos", i + "_" + j);
                });
            });
            //設定SuperTable
//            $("#SmartGridView1").toSuperTable({ width: "640px", height: "480px", fixedCols: 3 })(this.sFHeaderWidth * -1)/*2011-11-09 yux*/
             $("#SmartGridView1").toSuperTable({ width: ($(window).width()-10)+"px", height: ($(window).height()-$("#SmartGridView1").offset().top-60)+"px", headerRows:1})//fixedCols: 3,
            .find("tr:even").addClass("altRow");
            //加上全選/全不選功能(.sFHeader為配合SuperTable才加)/*2011-11-09 yux*/
//            $(".sFHeader #cbxSelAll")
//            .click(function() {
//                if (this.checked)
//                    $(".clsHideCbx").attr("checked", "checked");
//                else
//                    $(".clsHideCbx").removeAttr("checked");
//            });
            //加上隱藏/顯示功能
            $("#btnHide,#btnShowAll").click(toggleRow);
            //隱藏/顯示共用一個事件，由evt.target判別按的是哪一顆
            function toggleRow(evt) {
                var show = (evt.target.id == "btnShowAll");
                var rowSet = (show) ?
                    $(".sFData tr:not(:visible)") : $(".sFData .clsHideCbx:checked").closest("tr");
                rowSet.toggle(show)
                //一般情況到hide()即可，以下這段是為了SuperTable而加的
                //把捲動區裡那一份<table>對應的資料列也同步藏起來
                .each(function() {
                    $(".sData tbody tr[rowidx=" + $(this).attr("rowidx") + "]").toggle(show);
                });
                $(".sData tbody").find(".altRow").removeClass("altRow")
                .end().find("tr:visible:even").addClass("altRow");
                //修正IE隱藏結尾會不齊的問題
                if ($.browser.msie) {
                    var fixedColZone = $(".sFDataInner");
                    var cellZone = $(".sData table");
                    var p1 = fixedColZone.offset().top;
                    var p2 = cellZone.offset().top;
                    if (p1 != p2) {
                        fixedColZone.css("top", (p2 - fixedColZone.parent().offset().top) + "px");
                    }
                }
            }
 
            function getPosVal(s) {
                return parseInt(s.replace("px", ""));
            }
 
            $("#btnScroll").click(function() {
                scrollToRow($("#rowIdx").val());
            });
 
            //捲動到指定列數
            function scrollToRow(rowIdx) {
                //IE下有一列的位移，鋸箭法校正
                if ($.browser.msie && !isNaN(rowIdx))
                    rowIdx = parseInt(rowIdx) - 1;
                var x = $(".sData tr[rowidx=" + rowIdx + "]");
                if (x.length > 0) {
                    //alert($(".sData").scrollTop() + "," + x.position().top);
                    $(".sData").scrollTop(
                        $(".sData").scrollTop() +
                        x.position().top);
                }
            }
            //捲動到指定的欄數
            function scrollToCol(colIdx) {
                var x = $(".sData td:eq(" + colIdx + ")");
                $(".sData").scrollLeft($(".sData").scrollLeft() + x.position().left);
            }
 
            //保留所有Cell的集合
            var allCells = $(".sData #SmartGridView1 td");
 
            $("#btnFind").click(function() {
                var keywd = $("#keywd").val();
                //先找到上次的焦點
                var focusIdx = 0;
                var hasPrevFocus = false;
                allCells.filter("td[findfocus]").each(function() {
                    focusIdx = allCells.index(this);
                    //將focus移除
                    $(this).removeAttr("findfocus")
                    //去除Highlight
                    .html($(this).text());
                    hasPrevFocus = true;
                });
                //由焦點開始往後找
                allCells.filter("td:gt(" + focusIdx + ")")
                .each(function() {
                    var td = $(this);
                    if (td.text().indexOf(keywd) > -1) {
                        var p = td.attr("pos").split("_");
                        scrollToRow(p[0]);
                        var cell = allCells.filter("td[pos=" + td.attr("pos") + "]");
                        cell.attr("findfocus", "true")
                        .html(cell.text().replace(keywd, 
                            "<span style='background-color:yellow;'>" + keywd + "</span>"));
                        scrollToCol(p[1]);
                        return false;
                    }
                });
                if (!allCells.is("td[findfocus]")) {
                    if (hasPrevFocus) {
                        if (confirm("已搜寻至结尾，要从头开始再找一次吗?"))
                            $("#btnFind").click();
                    } else
                        alert("找不到指定的关键字!");
                }
            });
 
        });