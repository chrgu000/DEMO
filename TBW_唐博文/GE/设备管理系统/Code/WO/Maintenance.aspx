<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Maintenance.aspx.cs" Inherits="WO_Maintenance"
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
                <table id="">
                    <%--<tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="control-label">保修时间</asp:Label>
                        </td>
                        <td>
                             <FormatControls:CalendarStartEnd ID="cal" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="LabelS2" runat="server" CssClass="control-label">产线</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListS9" runat="server" CssClass="form-control" DataSourceID="ObjectDataSource2"
                                DataTextField="iText" DataValueField="iID" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                    <td>
                            <asp:Label ID="LabelDate1" runat="server" CssClass="control-label">保修日期</asp:Label>
                        </td>
                        <td>
                            <FormatControls:Calendar ID="Calendar1" runat="server"/>
                            </td>
                        <td><FormatControls:Calendar ID="Calendar2" runat="server"/>
                        </td>
                </table>
            </asp:Panel>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" class="table table-bordered table-condensed"  id="Table1" >
            <thead id="thead1" runat="server">
            </thead>
            <tbody id="tbody1" runat="server">
            </tbody>
        </table>
<%--        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetLookUpData" 
            TypeName="PublicData">
            <SelectParameters>
                <asp:Parameter Name="iType" Type="String" DefaultValue="1" />
            </SelectParameters>
        </asp:ObjectDataSource>--%>
    </div>
</asp:Content>
