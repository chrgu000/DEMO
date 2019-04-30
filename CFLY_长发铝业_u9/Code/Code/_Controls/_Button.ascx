<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_Button.ascx.cs" Inherits="FormatButton" %>
<table style="width: 100%; border-collapse: collapse; border-spacing: inherit;background-color:#d5dcee">
    <tr ><%--style="border-top-style: solid;border-top-width: 1px; border-top-color: #4A4952;border-left-style: solid;border-left-width: 1px; border-left-color: #4A4952;border-right-style: solid;border-right-width: 1px; border-right-color: #4A4952;"--%>
        <td style="width:100%;" >
            <dx:ASPxLabel ID="LabelTitle" runat="server" CssClass="title"></dx:ASPxLabel>
            <dx:ASPxLabel ID="LabelTitleID" runat="server" CssClass="title2"></dx:ASPxLabel>
        </td>
        <td><dx:ASPxButton ID="btnSelect" Text="查询" OnClick="BtnToSelect_Click" runat="server" Visible="False"></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnNew" Text="申请" OnClick="BtnToNewRow_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnNewRow" Text="增行" OnClick="BtnToSelect_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnEdit" Text="修改" OnClick="BtnToEdit_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnSave" Text="保存" OnClick="BtnToSave_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnExport" Text="导出" OnClick="BtnToExport_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnDel" Text="删除" OnClick="BtnToDel_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnAudit" Text="审核" OnClick="BtnToAudit_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnUnAudit" Text="弃审" OnClick="BtnToUnAudit_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnOpen" Text="打开" OnClick="BtnToOpen_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnClose" Text="关闭" OnClick="BtnToClose_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <td><dx:ASPxButton ID="btnBack" Text="返回" OnClick="BtnToBack_Click" runat="server" Visible="False" ></dx:ASPxButton></td>
        <%--<td style="text-align: right; border-bottom-style: solid; border-bottom-width: 2px;
            border-bottom-color: #66CCFF">
            
            
            <dx:ASPxButton ID="btnNew" Text="申请" OnClick="BtnToNew_Click" runat="server"  
                Visible="false" Wrap="False"></dx:ASPxButton>
            <asp:Button ID="btnNewRow" Text="增行" OnClick="BtnToNewRow_Click" OnClientClick="javascript:return doExecNewRow();"
                runat="server" CssClass="btn" Visible="false"></asp:Button>
            <asp:Button ID="btnEdit" Text="修改" OnClick="BtnToEdit_Click" OnClientClick="javascript:return doExecEdit();"
                runat="server" CssClass="btn" Visible="false"></asp:Button>
            <asp:Button ID="btnSave" Text="保存" OnClick="BtnToSave_Click" OnClientClick="javascript:return doExecSave();"
                runat="server" CssClass="btn" Visible="false"></asp:Button>
            <asp:Button ID="btnExport" Text="导出" OnClick="BtnToExport_Click" runat="server" CssClass="btn"
                Visible="false"></asp:Button>
            <asp:Button ID="btnDel" Text="删除" OnClick="BtnToDel_Click" OnClientClick="javascript:return doExecDel();"
                runat="server" CssClass="btn" Visible="false"></asp:Button>
            <asp:Button ID="btnAudit" Text="审核" OnClick="BtnToAudit_Click" runat="server" CssClass="btn"
                Visible="false"></asp:Button>
            <asp:Button ID="btnUnAudit" Text="弃审" OnClick="BtnToUnAudit_Click" runat="server"
                CssClass="btn" Visible="false"></asp:Button>
            <asp:Button ID="btnOpen" Text="打开" OnClick="BtnToOpen_Click" runat="server" CssClass="btn"
                Visible="false"></asp:Button>
            <asp:Button ID="btnClose" Text="关闭" OnClick="BtnToClose_Click" runat="server" CssClass="btn"
                Visible="false"></asp:Button>
            <asp:Button ID="btnBack" Text="返回" OnClick="BtnToBack_Click" runat="server" CssClass="btn"
                Visible="false"></asp:Button>
        </td>--%>
    </tr>
</table>
<%--<asp:HiddenField ID="hidID" runat="server" />--%>
<div style="display: none">
    <dx:ASPxTextBox ID="hidID" runat="server">
    </dx:ASPxTextBox>
    <asp:HiddenField ID="hidformID" runat="server" />
</div>

<script type="text/jscript">
    if (window.parent != null) {
        var session = '<%=Session["uID"]%>';
        if (session == "") {
            window.location.href = "../ErrorPage.aspx";
        }
    }
    else {
        window.location.href = "../ErrorPage.aspx";
    }

    function doExecNew() {
        if (doNew()) {
            return true;
        }
        else {
            return false;
        }

    }

    function doExecNewRow() {
        if (doNewRow()) {
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
    function doExecAudit() {

        if (doAudit()) {
            return true;
        }
        else {
            return false;
        }

    }
    function doExecUnAudit() {

        if (doUnAudit()) {
            return true;
        }
        else {
            return false;
        }

    }
    function doExecPrint() {

        if (doPrint()) {
            return true;
        }
        return true;
    }

    function doExecSelect() {
        if (doSelect()) {
            return true;
        }
        else {
            return false;
        }

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

