<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="PublicFacilities_Index"
    MasterPageFile="~/Frame/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
<link href="../css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
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

    <div class="container" style="width: 100%">
        <div class="panel  panel-primary">
            <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToBeck="ToBeck"
                OnToDel="ToDel" OnToSave="ToSave" OnToNew="ToNew" OnToExport="ToExport" />
            <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelDate1" runat="server" CssClass="control-label">最近外检日期</asp:Label>
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
    </div>
</asp:Content>
