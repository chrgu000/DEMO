<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_ButtonIndex.ascx.cs" Inherits="YxButtonIndex" %>
<script language="javascript" type="text/javascript" src="../Script/PublicJScript.js"></script>
<table style="width:100%;border-bottom:double 3px #A2C4E2;">
    <tr>
        <td>
            <asp:Label ID="lblTitle" runat="server" CssClass="title" ></asp:Label>
        </td>
        <td style="text-align:right;">
            <asp:Button ID="lbToSelect" Text="查询" OnClick="BtnToSelect" OnClientClick="javascript:return doExecSelect();" runat="server" CssClass="button"></asp:Button>
            <asp:Button ID="lbToNew" Text="申请" OnClick="BtnToNew" runat="server" CssClass="button"></asp:Button>
            <asp:Button ID="lbToDel" Text="删除" OnClick="BtnToDel" OnClientClick="javascript:return doExecDel();" runat="server" CssClass="button" Visible="false"></asp:Button>
            <asp:Button ID="lbToBack" Text="返回" OnClick="BtnToBack" runat="server" CssClass="button"></asp:Button>
        </td>
        <asp:HiddenField ID="hidPageID" runat="server" />
    </tr>
</table>
<script type="text/jscript">
//if(window.parent['Top']!=null)
//{
//    
//}
//else
//{
//    window.location.href="../ErrorPage.aspx";
//}

function doExecPrint()
{
    if(doPrint())
    {
        if(doPrint())
        {
            return true;
        }
    }
    return true;
}

function doExecSelect()
{

    if(doSelect())
    {
        if(doSelect())
        {
            return true;
        }
    }
    return true;
    

}

function doExecDel() {
    if (confirm('确认删除吗？')) {
//        if (doDel()) {
            return true;
//        }
//        else {
//            return false;
//        }
    }
    else {
        return false;
    }
}


</script>