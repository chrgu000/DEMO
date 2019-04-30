<%@ control language="C#" autoeventwireup="true" inherits="YxButtonUpdate, App_Web_htfqt-xo" %>
<script language="javascript" type="text/javascript" src="../Script/PublicJScript.js"></script>
<table style="text-align:center;width:100%">
<tr>

    <td>
        <asp:Button ID="lbToSave" Text="保存" OnClick="BtnToSave" OnClientClick="javascript:return doExecSave();" runat="server" CssClass="button"></asp:Button>
        <asp:Button ID="lbToDel" Text="删除" OnClick="BtnToDel" OnClientClick="javascript:return doExecDel();" runat="server" CssClass="button" Visible="false"></asp:Button>
<%--        <asp:Button ID="lbToChoose" Text="选择客户" OnClick="BtnToChoose" OnClientClick="javascript:return doExecChoose();" runat="server" CssClass="button" Visible="false"></asp:Button>--%>
        <asp:Button ID="lbToBack" Text="返回" OnClick="BtnToBack" runat="server" CssClass="button" ></asp:Button>
        
        <asp:HiddenField ID="hidPageID" runat="server" />
        <asp:HiddenField ID="hidPageSID" runat="server" />
        <asp:HiddenField ID="hidPageTable" runat="server" />
        <asp:HiddenField ID="hidPageSTable" runat="server" />
        <asp:HiddenField ID="hidPageIDName" runat="server" />
        <asp:HiddenField ID="hidPageSIDName" runat="server" />
        
        <asp:HiddenField ID="hidIsTrue" runat="server" />
        <asp:HiddenField ID="hidFlag" runat="server" />
    </td>
</tr>
</table>
<script language="javascript" type="text/javascript">
function doExecSave()
{
    if(doSave())
    {
        document.getElementById("<%=lbToSave.ClientID %>").display="";
        return true;
    }
    else
    {
        document.getElementById("<%=lbToSave.ClientID %>").display = "";
        return false;
    }
}

function doExecDel()
{
    if(confirm('确认删除吗？'))
    {
//        if(doDel())
//        {
            return true;
//        }
//        else
//        {
//            return false;
//        }
    }
    else
    {
        return false;
    }
}

function doExecAdd() {
    if (doAdd()) {
        return false;
    }
    else {
        return false;
    }
}

//function doExecChoose() {
//    if (doChoose()) {
//        return true;
//    }
//    else {
//        return false;
//    }
//}


</script>

<script type="text/jscript">
//if(window.parent['Top']!=null)
//{

//}
//else
//{
//    window.location.href="../ErrorPage.aspx";
//}
</script>