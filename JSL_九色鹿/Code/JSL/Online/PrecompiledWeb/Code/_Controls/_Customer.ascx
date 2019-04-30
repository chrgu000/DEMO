<%@ control language="C#" autoeventwireup="true" inherits="YxCustomer, App_Web_htfqt-xo" %>
<asp:Label ID="lbl" runat="server" Visible="false" ></asp:Label>
<input id="txt" runat="server" class="text" style="width: 100px" type="text" readonly="true" />
<asp:Image ID="img" runat="server" ImageUrl="~/Images/PublicImages/open.gif" CssClass="style:cursor"  />
<input id="hid" runat="server" class="text"  type="hidden" />

<script language="javascript" type="text/javascript">
function SelectVendor(obj1,obj2)
{
    var lb1=document.getElementById(obj1);
    var lb2=document.getElementById(obj2);
    
    var s=new Object();
    var k="";
    s.id=lb2.value;

    k = showModalDialog("../Share/CustomerSelect.aspx?id=" + s.id + "&name=", s, "dialogWidth:600px;dialogHeight:350px;scrollbars:no;help:no;");
    if (typeof(k.id) != "undefined")
    {
        lb1.value=k.name;
        lb2.value=k.id;
        return true;
    }
    else
    {
        return false;
    } 
}

</script>