<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_Button.ascx.cs" Inherits="FormatButton" %>

<div class="panel-heading">
<table style="width:100%;">
    <tr  style="height:20px;">
        <td  style="height:20px;">
            <asp:Label ID="lblTitle" runat="server" CssClass="title" ></asp:Label><asp:Label ID="labeliID" runat="server" CssClass="title" ></asp:Label>
        </td>
        <td style="text-align:right;height:20px;">
            <asp:Button ID="lbToSelect" Text="查询" OnClick="BtnToSelect" OnClientClick="javascript:return doExecSelect();" runat="server" CssClass="btn btn-default btn-sm" Visible="false"></asp:Button>
            <asp:Button ID="lbToNew" Text="申请" OnClick="BtnToNew" OnClientClick="javascript:return doExecNew();"  runat="server" CssClass="btn btn-default btn-sm" Visible="false"></asp:Button>
            <asp:Button ID="lbToEdit" Text="修改" OnClick="BtnToEdit" OnClientClick="javascript:return doExecEdit();"  runat="server" CssClass="btn btn-default btn-sm" Visible="false"></asp:Button>
            <asp:Button ID="lbToSave" Text="保存" OnClick="BtnToSave"  OnClientClick="javascript:return doExecSave();" runat="server" CssClass="btn btn-default btn-sm" Visible="false"></asp:Button>
            <asp:Button ID="lbToExport" Text="导出" OnClick="BtnToExport"  runat="server" CssClass="btn btn-default btn-sm" Visible="false"></asp:Button>
            <asp:Button ID="lbToDel" Text="删除" OnClick="BtnToDel" OnClientClick="javascript:return doExecDel();" runat="server" CssClass="btn btn-default btn-sm" Visible="false" ></asp:Button>
            <asp:Button ID="lbToBack" Text="返回" OnClick="BtnToBack" runat="server" CssClass="btn btn-default btn-sm" Visible="false"></asp:Button>
            <asp:HiddenField ID="hidID" runat="server" />
            <asp:HiddenField ID="hidformID" runat="server" />
        </td>
    </tr>
</table>
</div>
<script type="text/jscript">
if(window.parent!=null)
{
    var session ='<%=Session["uID"]%>';
    if (session == "") {
        window.location.href = "../ErrorPage.aspx";
    }
}
else
{
    window.location.href="../ErrorPage.aspx";
}

function doExecNew() {

    if (doNew()) {
        return true;
    }
    else {
        return false;
    }

}
function doExecEdit() {

    if (doEdit()) {
        return true;
    }
    else {
        return false;
    }

}
function doExecPrint() {

    if(doPrint())
    {
            return true;
    }
    return true;
}

function doExecSelect()
{

    if(doSelect())
    {
            return true;
    }
    return true;
    

}

function doExecDel() {
    if (confirm('确认删除吗？')) {
        if (doDel()) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}

function doExecSave() {
    if (doSave()) {
        return true;
    }
    else {
        return false;
    }
}

</script>