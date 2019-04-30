<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_Select.ascx.cs" Inherits="FormatSelect" %>
<table><tr><td><asp:TextBox ID="txtText" runat="server" ReadOnly="True" ></asp:TextBox></td>
<td><input type="button" id="btn" value="选择" runat="server" class="btn btn-default btn-sm"  /></td>
</tr></table>


<%--<asp:Image ID="Image1" runat="server"  CssClass="btn btn-default btn-sm"  />--%>
<asp:HiddenField  ID="txtHid" runat="server"  />
<asp:HiddenField ID="txtHidFlag" runat="server"/>

<script language="javascript" type="text/jscript">
function Select(obj1,obj2,obj3)
{
    var lb1=document.getElementById(obj1);
    var lb2 = document.getElementById(obj2);
    var lb3 = document.getElementById(obj3);
    var s=new Object();
    var k="";
    if(obj1.length!=0)
    {
        s.id = lb1.value;
        s.flag = lb3.value;
    } 
    else
    {
        s.id = "";
        s.flag = "";
    }
    k=showModalDialog("../Share/Select.aspx",s,"dialogWidth:300px;dialogHeight:350px;scrollbars:no;help:no;");
    if (typeof(k.id) != "undefined" || typeof(k.name) != "undefined")
    {
        
        lb1.value=k.id;
        lb2.value = k.name;
        
        return true;
    }
    else
    {
        return false;
    } 
}
</script>