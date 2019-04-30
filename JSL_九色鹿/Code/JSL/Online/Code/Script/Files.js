var id = 0;
function TableFileInsert() {
    //    var id=document.getElementById("<%=hidid.ClientID%>"); 
    //    alert(id.value);
    if (id != null) {
        //        id.value=parseInt(id.value)+1;
        var i = parseInt(id.value) + 1;
        var oTable = document.getElementById("tablefile");
        //        if(oTable!=null)
        //        {
        var oRow = oTable.insertRow();
        oRow.id = "tr" + i;

        var oInput = oRow.insertCell();
        //oInput.width="45%";
        oInput.align = "center";
        oInput.className = "tdfileitem";
        oInput.innerHTML = "<input type='text'  id='ttx_" + i + "' name='ttx_" + i + "'  class='text' style='width: 98%'/>";

        var oFile = oRow.insertCell();
        //oFile.width="30%";
        oFile.align = "left";
        oFile.className = "tdfileitem";
        oFile.innerHTML = "<input type='file' id='fil_" + i + "'  class='file' name='fil_" + i + "' style='width: 100%' contenteditable='False' />";

        var oDelete = oRow.insertCell();
        //oDelete.width="20%";
        oDelete.align = "center";
        oDelete.className = "tdfileitem";
        oDelete.innerHTML = "<img src='../Images/PublicImages/delete.gif' id='del_" + i + "' name='del_" + i + "' onclick='this.parentNode.parentNode.removeNode(true);' style='cursor:hand'/>";
        //        }
    }
}

function DeleTable(i, obj) {
    if (confirm('确认删除吗？')) {
        var id = document.getElementById("<%=hidid.ClientID%>");
        if (id.value == "") {
            id.value = i;
        }
        else {
            id.value = id.value + "," + i;
        }
        obj.parentNode.parentNode.removeNode(true);
        return true;
    }
    else {
        return false;
    }

}

function TableFileShow(obj1, obj2) {
    var e1 = document.getElementById(obj1);
    var e2 = document.getElementById(obj2);

    if (e1.checked == true) {
        e2.style.display = "";
    }
    else {
        e2.style.display = "none";
    }

    //    var id=document.getElementById("<%=hidid.ClientID%>"); 
    if (id == "0") {
        TableFileInsert();
    }
}