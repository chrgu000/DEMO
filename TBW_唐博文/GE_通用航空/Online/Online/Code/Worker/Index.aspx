<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Worker_Index"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
</head>
<body>
    <div class="container" style="width: 100%">
        <form id="form1" runat="server" autocomplete="off" class="form-horizontal">
        <div class="panel  panel-primary">
            <FormatControls:Button ID="YxBtn" runat="server" OnToSelect="ToSelect" OnToBeck="ToBeck"
                OnToDel="ToDel" OnToSave="ToSave" OnToNew="ToNew" OnToExport="ToExport" />
            <asp:Panel runat="server" ID="divSel" Width="100%" CssClass="panel">
                <%--<FormatControls:CalendarStartEnd ID="cal" runat="server" />--%>
                <%--<asp:Label ID="LabelDate3" runat="server"></asp:Label><asp:TextBox runat="server"
                    CssClass="form-control"></asp:TextBox>
                 <FormatControls:Calendar runat="server" ID="calll" ReadOnly="true" CssClass="datepickerCompleted">
                </FormatControls:Calendar>
                <a class="form-control" runat="server"></a>
                --%>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelS2" runat="server" CssClass="control-label"></asp:Label>
                        </td>
                        <td>
                            <FormatControls:DropDownList ID="DropDownListS1" DataTextField="iText" DataValueField="iID"
                                iType="5" runat="server" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" KeyFieldName="iID" EnableDefaultAppearance="False"
            DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" Width="100%" CssClass="table">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0" Width="100px">
                    <EditButton Visible="True" Text="更改">
                    </EditButton>
                    <NewButton Visible="True" Text="增行">
                    </NewButton>
                    <DeleteButton Visible="True" Text="删除">
                    </DeleteButton>
                    <CancelButton Text="取消">
                    </CancelButton>
                    <UpdateButton Text="确定">
                    </UpdateButton>
                    <CellStyle Wrap="False">
                    </CellStyle>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataColumn FieldName="iID" VisibleIndex="1" ReadOnly="true">
                    <EditItemTemplate>
                        <asp:Label ID="labeliID" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem,"iID") %>'></asp:Label>
                    </EditItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="S1" VisibleIndex="2">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn FieldName="S2" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="S3" VisibleIndex="4" ShowInCustomizationForm="true">
                    <EditItemTemplate>
                        <FormatControls:DropDownList ID="DropDownList3" DataTextField="iText" DataValueField="iID"
                            iType="5" runat="server" Value='<%# Bind("S3") %>' />
                    </EditItemTemplate>
                    <PropertiesComboBox TextField="iText" ValueField="iID" EnableSynchronization="False"
                        DataSourceID="ObjectDataSource2">
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                
                <dx:GridViewDataTextColumn FieldName="S4" VisibleIndex="5">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S5" VisibleIndex="6">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S6" VisibleIndex="7">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S7" VisibleIndex="8">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S8" VisibleIndex="9">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S9" VisibleIndex="10">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S10" VisibleIndex="11">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S11" VisibleIndex="12">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S12" VisibleIndex="13">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S13" VisibleIndex="14">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S14" VisibleIndex="15">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="S15" VisibleIndex="16">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn FieldName="Date1" VisibleIndex="17" Visible="true" Width="10%">
                    <EditItemTemplate>
                        <FormatControls:Calendar ID="Calendar1" runat="server" ReadOnly="true" CssClass="datepickerCompleted"
                            Value='<%# Bind("Date1") %>'></FormatControls:Calendar>
                    </EditItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Date2" VisibleIndex="17" Visible="true" Width="10%">
                    <EditItemTemplate>
                        <FormatControls:Calendar ID="Calendar2" runat="server" ReadOnly="true" CssClass="datepickerCompleted"
                            Value='<%# Bind("Date2") %>'></FormatControls:Calendar>
                    </EditItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Date3" VisibleIndex="17" Visible="true" Width="10%">
                    <EditItemTemplate>
                        <FormatControls:Calendar ID="Calendar3" runat="server" ReadOnly="true" CssClass="datepickerCompleted"
                            Value='<%# Bind("Date3") %>'></FormatControls:Calendar>
                    </EditItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Date4" VisibleIndex="17" Visible="true" Width="10%">
                    <EditItemTemplate>
                        <FormatControls:Calendar ID="Calendar4" runat="server" ReadOnly="true" CssClass="datepickerCompleted"
                            Value='<%# Bind("Date4") %>'></FormatControls:Calendar>
                    </EditItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Date5" VisibleIndex="17" Visible="true" Width="10%">
                    <EditItemTemplate>
                        <FormatControls:Calendar ID="Calendar5" runat="server" ReadOnly="true" CssClass="datepickerCompleted"
                            Value='<%# Bind("Date5") %>'></FormatControls:Calendar>
                    </EditItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn FieldName="D1" VisibleIndex="18">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D2" VisibleIndex="19">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D3" VisibleIndex="20">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D4" VisibleIndex="21">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D5" VisibleIndex="22">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D6" VisibleIndex="23">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D7" VisibleIndex="24">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D8" VisibleIndex="25">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D9" VisibleIndex="26">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="D10" VisibleIndex="27">
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior ConfirmDelete="True" />
            <SettingsText ConfirmDelete="是否删除?" EmptyDataRow="" />
            <SettingsEditing EditFormColumnCount="3" Mode="Inline" />
            <Styles EnableDefaultAppearance="False">
                <Table CssClass="table">
                </Table>
                <Header Font-Bold="True">
                </Header>
            </Styles>
            <SettingsPager PageSize="10" />
            <StylesPager>
            </StylesPager>
            <Settings ShowTitlePanel="true" />
            <StylesEditors>
                <Style CssClass="form-control">
                    </Style>
                <DropDownWindow Font-Bold="False">
                </DropDownWindow>
            </StylesEditors>
        </dx:ASPxGridView>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <label id="Labeel1" runat="server">
        </label>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1">
        </dx:ASPxGridViewExporter>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="WorkerData"
            SelectMethod="Get" UpdateMethod="Insert" InsertMethod="Insert" DeleteMethod="Delete"
            OnInserted="ObjectDataSource1_Inserted" OnSelecting="ObjectDataSource1_Selecting"
            OnUpdating="ObjectDataSource1_Updating" OnUpdated="ObjectDataSource1_Updated"
            OnInserting="ObjectDataSource1_Inserting">
            <SelectParameters>
                <asp:Parameter Name="iID" Type="String" />
                <asp:Parameter Name="S1" Type="String" />
                <asp:Parameter Name="S2" Type="String" />
                <asp:Parameter Name="S3" Type="String" />
                <asp:Parameter Name="S4" Type="String" />
                <asp:Parameter Name="S5" Type="String" />
                <asp:Parameter Name="S6" Type="String" />
                <asp:Parameter Name="S7" Type="String" />
                <asp:Parameter Name="S8" Type="String" />
                <asp:Parameter Name="S9" Type="String" />
                <asp:Parameter Name="S10" Type="String" />
                <asp:Parameter Name="S11" Type="String" />
                <asp:Parameter Name="S12" Type="String" />
                <asp:Parameter Name="S13" Type="String" />
                <asp:Parameter Name="S14" Type="String" />
                <asp:Parameter Name="S15" Type="String" />
                <asp:Parameter Name="sDate1" Type="DateTime" />
                <asp:Parameter Name="eDate1" Type="DateTime" />
                <asp:Parameter Name="sDate2" Type="DateTime" />
                <asp:Parameter Name="eDate2" Type="DateTime" />
                <asp:Parameter Name="sDate3" Type="DateTime" />
                <asp:Parameter Name="eDate3" Type="DateTime" />
                <asp:Parameter Name="sDate4" Type="DateTime" />
                <asp:Parameter Name="eDate4" Type="DateTime" />
                <asp:Parameter Name="sDate5" Type="DateTime" />
                <asp:Parameter Name="eDate5" Type="DateTime" />
            </SelectParameters>
            <DeleteParameters>
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="iID" Type="String" />
                <asp:Parameter Name="S1" Type="String" />
                <asp:Parameter Name="S2" Type="String" />
                <asp:Parameter Name="S3" Type="String" />
                <asp:Parameter Name="S4" Type="String" />
                <asp:Parameter Name="S5" Type="String" />
                <asp:Parameter Name="S6" Type="String" />
                <asp:Parameter Name="S7" Type="String" />
                <asp:Parameter Name="S8" Type="String" />
                <asp:Parameter Name="S9" Type="String" />
                <asp:Parameter Name="S10" Type="String" />
                <asp:Parameter Name="S11" Type="String" />
                <asp:Parameter Name="S12" Type="String" />
                <asp:Parameter Name="S13" Type="String" />
                <asp:Parameter Name="S14" Type="String" />
                <asp:Parameter Name="S15" Type="String" />
                <asp:Parameter Name="Date1" Type="DateTime" />
                <asp:Parameter Name="Date2" Type="DateTime" />
                <asp:Parameter Name="Date3" Type="DateTime" />
                <asp:Parameter Name="Date4" Type="DateTime" />
                <asp:Parameter Name="Date5" Type="DateTime" />
                <asp:Parameter Name="D1" Type="Decimal" />
                <asp:Parameter Name="D2" Type="Decimal" />
                <asp:Parameter Name="D3" Type="Decimal" />
                <asp:Parameter Name="D4" Type="Decimal" />
                <asp:Parameter Name="D5" Type="Decimal" />
                <asp:Parameter Name="D6" Type="Decimal" />
                <asp:Parameter Name="D7" Type="Decimal" />
                <asp:Parameter Name="D8" Type="Decimal" />
                <asp:Parameter Name="D9" Type="Decimal" />
                <asp:Parameter Name="D10" Type="Decimal" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="iID" Type="String" />
                <asp:Parameter Name="S1" Type="String" />
                <asp:Parameter Name="S2" Type="String" />
                <asp:Parameter Name="S3" Type="String" />
                <asp:Parameter Name="S4" Type="String" />
                <asp:Parameter Name="S5" Type="String" />
                <asp:Parameter Name="S6" Type="String" />
                <asp:Parameter Name="S7" Type="String" />
                <asp:Parameter Name="S8" Type="String" />
                <asp:Parameter Name="S9" Type="String" />
                <asp:Parameter Name="S10" Type="String" />
                <asp:Parameter Name="S11" Type="String" />
                <asp:Parameter Name="S12" Type="String" />
                <asp:Parameter Name="S13" Type="String" />
                <asp:Parameter Name="S14" Type="String" />
                <asp:Parameter Name="S15" Type="String" />
                <asp:Parameter Name="Date1" Type="DateTime" />
                <asp:Parameter Name="Date2" Type="DateTime" />
                <asp:Parameter Name="Date3" Type="DateTime" />
                <asp:Parameter Name="Date4" Type="DateTime" />
                <asp:Parameter Name="Date5" Type="DateTime" />
                <asp:Parameter Name="D1" Type="Decimal" />
                <asp:Parameter Name="D2" Type="Decimal" />
                <asp:Parameter Name="D3" Type="Decimal" />
                <asp:Parameter Name="D4" Type="Decimal" />
                <asp:Parameter Name="D5" Type="Decimal" />
                <asp:Parameter Name="D6" Type="Decimal" />
                <asp:Parameter Name="D7" Type="Decimal" />
                <asp:Parameter Name="D8" Type="Decimal" />
                <asp:Parameter Name="D9" Type="Decimal" />
                <asp:Parameter Name="D10" Type="Decimal" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetLookUpData"
            TypeName="PublicData">
            <SelectParameters>
                <asp:Parameter Name="iType" Type="String" DefaultValue="5" />
            </SelectParameters>
        </asp:ObjectDataSource>
        </form>
    </div>
</body>
</html>

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

