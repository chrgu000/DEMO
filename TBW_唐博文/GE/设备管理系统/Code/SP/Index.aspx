<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="SP_Index"
    MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">

    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $('#Table1').dataTable();
        });
	</script>

    <script language="javascript" type="text/javascript">

        function doSelect() {
            return true;
        }
        function doSave() {
            return true;
        }
        function doNew() {
            return true;
        }
    </script>
<FormatControls:Calendar  ID="aaa"  runat="server" />
    <div class="container" style="width: 100%">
        <div class="panel  panel-primary">
            <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToBeck="ToBeck"
                OnToDel="ToDel" OnToSave="ToSave" OnToNew="ToNew" OnToExport="ToExport" />
            <asp:Panel runat="server" ID="divSel" Width="100%" >
                <table>
                    <tr>
<%--                        <td>
                            <asp:Label ID="LabelS2" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                        <td>
                            <FormatControls:DropDownList ID="DropDownListS1" DataTextField="iText" DataValueField="iID"
                                iType="3" runat="server" />
                        </td>--%>
                        <td>
                            <asp:Label ID="LabelDate1" runat="server" CssClass="control-label">入库日期</asp:Label>
                        </td>
                        <td>
                            <FormatControls:Calendar ID="Calendar1" runat="server"/></td>
                        <td><FormatControls:Calendar ID="Calendar2" runat="server"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="table table-bordered table-condensed"
            id="Table1">
            <thead id="thead1" runat="server">
            </thead>
            <tbody id="tbody1" runat="server">
            </tbody>
        </table>
        <p class="text-info">
        当前库存小于安全库存量的备件
        </p>
        <table cellpadding="0" cellspacing="0" border="0" class="table table-bordered table-condensed"
            id="Table2">
            <thead id="thead2" runat="server">
            </thead>
            <tbody id="tbody2" runat="server">
            </tbody>
        </table>
    </div>
</asp:Content>
