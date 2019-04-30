<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Select.aspx.cs" Inherits="Share_Select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<base target="_self" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <script src="../js/jquery-1.9.1.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/bootstrap-datetimepicker.min.js"></script>

    <script src="../js/jquery.form.js"></script>

    <script src="../js/jquery.validate.js"></script>

    <script src="../Script/PublicJScript.js"></script>

    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/datetimepicker.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <title>选择人员</title>
    <script language="javascript" type="text/javascript">
		var s = new Object();
		s.flag = ""
		window.returnValue = s;
    </script> 

</head>
<body >
    <form id="form1" runat="server" > 
    <table width="100%">
        <%--<tr><td>
            <select id="ddl" runat="server" onchange="doChange()">
            </select>
        </td></tr>--%>
        <tr><td>
            <%--<asp:ListBox ID="ListBox1" runat="server" Height="200px" Width="100%" CssClass="form-control"></asp:ListBox>--%>
            <select id="sel1" runat="server"  class="form-control" multiple style="width:200px;height:200px"  ></select>
        </td></tr>
    </table>
    <div id="divinput" class="divbutton" runat="server">
        <input id="confirm" type="button" value="确定" class="btn btn-default btn-sm" onclick="sendback()" />
        <input id="cancel" type="button" value="取消" class="btn btn-default btn-sm" onclick="Anul()" />
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
//    getLoad()
//    
//    function getLoad()
//    {
//        var lst=document.getElementById("ListBox1");
//        
//        var dtable=AjaxMethod.GetWorkersByType("1").value;
//        if(dtable != null && typeof(dtable) == "object")
//        {	
//            for(var q=0;q<dtable.Rows.length;q++)
//            {
//                var id=dtable.Rows[q]["WID"];
//                var name=dtable.Rows[q]["WName"];
//                lst.options.add(new Option(name,id));
//            }
//        }
//    }
//    
//    function doChange()
//    {
//        var ddl=document.getElementById("ddl");
//        var type="";
//        for(var i=0;i<ddl.length;i++)
//        {
//            if(ddl[i].selected)
//            {
//                type = ddl.options[i].value;
//            }
//        }
//        var lst=document.getElementById("ListBox1")
//        
//        for(var i=lst.length-1;i>=0;i--)
//        {
//            lst.remove(i);
//        }

//        var dtable=AjaxMethod.GetWorkersByType(type).value;
//        if(dtable != null && typeof(dtable) == "object")
//        {	
//            for(var q=0;q<dtable.Rows.length;q++)
//            {
//                var id=dtable.Rows[q]["WID"];
//                var name=dtable.Rows[q]["WName"];
//                lst.options.add(new Option(name,id));
//            }
//        }
//    }
//    
    function sendback()
    {
        var s=new Object();
        s.type="ok";
        s.id="";
        s.txt="";
        var lb1 = document.getElementById("sel1");
        var len=lb1.length;
        for(var i=0;i<len;i++)
        {
            if(lb1.options[i].selected)
            {
                 s.id = lb1.options(i).value; 
                 s.name=lb1.options(i).text; 
             }
        }
        if(s.id==null)
        {
            alert("选择错误!");
            return false;
        }
        else
        {
            window.returnValue=s;
            window.close();
        }
        
    }
    
    function Anul()
    {
       var s=new Object();
       s.id = "";
       s.name="";
       s.std="";
	   s.com="";
	   
       window.returnValue=s;
       window.close();
    }
</script>
