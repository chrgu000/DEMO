<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeekARate.aspx.cs" Inherits="PMMWS.WeekARate" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>
<%@ Register assembly="DevExpress.XtraCharts.v11.1.Web, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<%@ Register assembly="DevExpress.XtraReports.v11.1.Web, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1.Export, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table id="table1" width="1024" align="center" style="background-color: #C0C0C0">
        <tr>
            <td>
                
                <dx:ASPxButton ID="ASPxButton1" runat="server" 
                    Text="导出到Excel" onclick="ASPxButton1_Click1">
                </dx:ASPxButton>
                
              
              </td>
        </tr>
        <tr>
            <td align="center">
                
                <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Width="800px" 
                    Height="200px" ClientInstanceName="Chart1">
                  
                           
                    <diagramserializable>
                        <cc1:XYDiagram>
                            <axisx visibleinpanesserializable="-1">
                                <range sidemarginsenabled="True" />
                            </axisx>
                            <axisy visibleinpanesserializable="-1">
                                <range auto="False" maxvalueserializable="1" minvalueserializable="0.9" 
                                    sidemarginsenabled="True" />
                            </axisy>
                        </cc1:XYDiagram>
                    </diagramserializable>
                  
                           
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

                    <seriesserializable>
                        <cc1:Series Name="标准线">
                            <points>
                                <cc1:SeriesPoint ArgumentSerializable="1" Values="0.99">
                                </cc1:SeriesPoint>
                                <cc1:SeriesPoint ArgumentSerializable="52" Values="0.99">
                                </cc1:SeriesPoint>
                            </points>
                            <viewserializable>
                                <cc1:LineSeriesView>
                                </cc1:LineSeriesView>
                            </viewserializable>
                            <labelserializable>
                                <cc1:PointSeriesLabel LineVisible="True">
                                    <fillstyle>
                                        <optionsserializable>
                                            <cc1:SolidFillOptions />
                                        </optionsserializable>
                                    </fillstyle>
                                </cc1:PointSeriesLabel>
                            </labelserializable>
                            <pointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </pointoptionsserializable>
                            <legendpointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </legendpointoptionsserializable>
                        </cc1:Series>
                    </seriesserializable>

<SeriesTemplate><ViewSerializable>
    <cc1:LineSeriesView AxisXName="Primary AxisX" AxisYName="Primary AxisY" 
        PaneName="Default Pane">
    </cc1:LineSeriesView>
</ViewSerializable>
<LabelSerializable>
    <cc1:PointSeriesLabel LineVisible="True">
        <fillstyle>
            <optionsserializable>
                <cc1:SolidFillOptions />
            </optionsserializable>
        </fillstyle>
    </cc1:PointSeriesLabel>
</LabelSerializable>
<PointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</PointOptionsSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

                    <titles>
                        <cc1:ChartTitle Text="机加工区周利用率" />
                    </titles>

                </dxchartsui:WebChartControl>
                
              
              </td>
        </tr>
        <tr>
            <td align="center">
                
                <dxchartsui:WebChartControl ID="WebChartControl2" runat="server" Width="800px" 
                    Height="200px" ClientInstanceName="Chart2">
                  
                           
                    <diagramserializable>
                        <cc1:XYDiagram>
                            <axisx visibleinpanesserializable="-1">
                                <range sidemarginsenabled="True" />
                            </axisx>
                            <axisy visibleinpanesserializable="-1">
                                <range auto="False" maxvalueserializable="1" minvalueserializable="0.9" 
                                    sidemarginsenabled="True" />
                            </axisy>
                        </cc1:XYDiagram>
                    </diagramserializable>
                  
                           
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

                    <seriesserializable>
                        <cc1:Series Name="标准线">
                            <points>
                                <cc1:SeriesPoint ArgumentSerializable="1" Values="0.99">
                                </cc1:SeriesPoint>
                                <cc1:SeriesPoint ArgumentSerializable="52" Values="0.99">
                                </cc1:SeriesPoint>
                            </points>
                            <viewserializable>
                                <cc1:LineSeriesView>
                                </cc1:LineSeriesView>
                            </viewserializable>
                            <labelserializable>
                                <cc1:PointSeriesLabel LineVisible="True">
                                    <fillstyle>
                                        <optionsserializable>
                                            <cc1:SolidFillOptions />
                                        </optionsserializable>
                                    </fillstyle>
                                </cc1:PointSeriesLabel>
                            </labelserializable>
                            <pointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </pointoptionsserializable>
                            <legendpointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </legendpointoptionsserializable>
                        </cc1:Series>
                    </seriesserializable>

<SeriesTemplate><ViewSerializable>
    <cc1:LineSeriesView AxisXName="Primary AxisX" AxisYName="Primary AxisY" 
        PaneName="Default Pane">
    </cc1:LineSeriesView>
</ViewSerializable>
<LabelSerializable>
    <cc1:PointSeriesLabel LineVisible="True">
        <fillstyle>
            <optionsserializable>
                <cc1:SolidFillOptions />
            </optionsserializable>
        </fillstyle>
    </cc1:PointSeriesLabel>
</LabelSerializable>
<PointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</PointOptionsSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

                    <titles>
                        <cc1:ChartTitle Text="钣金件区周利用率" />
                    </titles>

                </dxchartsui:WebChartControl>
                
            </td>
        </tr>
        <tr>
            <td align="center">
                
                <dxchartsui:WebChartControl ID="WebChartControl3" runat="server" Width="800px" 
                    Height="200px">
                  
                           
                    <diagramserializable>
                        <cc1:XYDiagram>
                            <axisx visibleinpanesserializable="-1">
                                <range sidemarginsenabled="True" />
                            </axisx>
                            <axisy visibleinpanesserializable="-1">
                                <range auto="False" maxvalueserializable="1" minvalueserializable="0.9" 
                                    sidemarginsenabled="True" />
                            </axisy>
                        </cc1:XYDiagram>
                    </diagramserializable>
                  
                           
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

                    <seriesserializable>
                        <cc1:Series Name="标准线">
                            <points>
                                <cc1:SeriesPoint ArgumentSerializable="1" Values="0.99">
                                </cc1:SeriesPoint>
                                <cc1:SeriesPoint ArgumentSerializable="52" Values="0.99">
                                </cc1:SeriesPoint>
                            </points>
                            <viewserializable>
                                <cc1:LineSeriesView>
                                </cc1:LineSeriesView>
                            </viewserializable>
                            <labelserializable>
                                <cc1:PointSeriesLabel LineVisible="True">
                                    <fillstyle>
                                        <optionsserializable>
                                            <cc1:SolidFillOptions />
                                        </optionsserializable>
                                    </fillstyle>
                                </cc1:PointSeriesLabel>
                            </labelserializable>
                            <pointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </pointoptionsserializable>
                            <legendpointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </legendpointoptionsserializable>
                        </cc1:Series>
                    </seriesserializable>

<SeriesTemplate><ViewSerializable>
    <cc1:LineSeriesView AxisXName="Primary AxisX" AxisYName="Primary AxisY" 
        PaneName="Default Pane">
    </cc1:LineSeriesView>
</ViewSerializable>
<LabelSerializable>
    <cc1:PointSeriesLabel LineVisible="True">
        <fillstyle>
            <optionsserializable>
                <cc1:SolidFillOptions />
            </optionsserializable>
        </fillstyle>
    </cc1:PointSeriesLabel>
</LabelSerializable>
<PointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</PointOptionsSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

                    <titles>
                        <cc1:ChartTitle Text="复合材料区周利用率" />
                    </titles>

                </dxchartsui:WebChartControl>
                
            </td>
        </tr>
        <tr>
            <td align="center">
                
                <dxchartsui:WebChartControl ID="WebChartControl4" runat="server" Width="800px" 
                    Height="200px">
                  
                           
                    <diagramserializable>
                        <cc1:XYDiagram>
                            <axisx visibleinpanesserializable="-1">
                                <range sidemarginsenabled="True" />
                            </axisx>
                            <axisy visibleinpanesserializable="-1">
                                <range auto="False" maxvalueserializable="1" minvalueserializable="0.9" 
                                    sidemarginsenabled="True" />
                            </axisy>
                        </cc1:XYDiagram>
                    </diagramserializable>
                  
                           
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

                    <seriesserializable>
                        <cc1:Series Name="标准线">
                            <points>
                                <cc1:SeriesPoint ArgumentSerializable="1" Values="0.99">
                                </cc1:SeriesPoint>
                                <cc1:SeriesPoint ArgumentSerializable="52" Values="0.99">
                                </cc1:SeriesPoint>
                            </points>
                            <viewserializable>
                                <cc1:LineSeriesView>
                                </cc1:LineSeriesView>
                            </viewserializable>
                            <labelserializable>
                                <cc1:PointSeriesLabel LineVisible="True">
                                    <fillstyle>
                                        <optionsserializable>
                                            <cc1:SolidFillOptions />
                                        </optionsserializable>
                                    </fillstyle>
                                </cc1:PointSeriesLabel>
                            </labelserializable>
                            <pointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </pointoptionsserializable>
                            <legendpointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </legendpointoptionsserializable>
                        </cc1:Series>
                    </seriesserializable>

<SeriesTemplate><ViewSerializable>
    <cc1:LineSeriesView AxisXName="Primary AxisX" AxisYName="Primary AxisY" 
        PaneName="Default Pane">
    </cc1:LineSeriesView>
</ViewSerializable>
<LabelSerializable>
    <cc1:PointSeriesLabel LineVisible="True">
        <fillstyle>
            <optionsserializable>
                <cc1:SolidFillOptions />
            </optionsserializable>
        </fillstyle>
    </cc1:PointSeriesLabel>
</LabelSerializable>
<PointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</PointOptionsSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

                    <titles>
                        <cc1:ChartTitle Text="液压测试站周利用率" />
                    </titles>

                </dxchartsui:WebChartControl>
                
            </td>
        </tr>
        <tr>
            <td align="center">
                
                <dxchartsui:WebChartControl ID="WebChartControl5" runat="server" Width="800px" 
                    Height="200px">
                  
                           
                    <diagramserializable>
                        <cc1:XYDiagram>
                            <axisx visibleinpanesserializable="-1">
                                <range sidemarginsenabled="True" />
                            </axisx>
                            <axisy visibleinpanesserializable="-1">
                                <range auto="False" maxvalueserializable="1" minvalueserializable="0.9" 
                                    sidemarginsenabled="True" />
                            </axisy>
                        </cc1:XYDiagram>
                    </diagramserializable>
                  
                           
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

                    <seriesserializable>
                        <cc1:Series Name="标准线">
                            <points>
                                <cc1:SeriesPoint ArgumentSerializable="1" Values="0.99">
                                </cc1:SeriesPoint>
                                <cc1:SeriesPoint ArgumentSerializable="52" Values="0.99">
                                </cc1:SeriesPoint>
                            </points>
                            <viewserializable>
                                <cc1:LineSeriesView>
                                </cc1:LineSeriesView>
                            </viewserializable>
                            <labelserializable>
                                <cc1:PointSeriesLabel LineVisible="True">
                                    <fillstyle>
                                        <optionsserializable>
                                            <cc1:SolidFillOptions />
                                        </optionsserializable>
                                    </fillstyle>
                                </cc1:PointSeriesLabel>
                            </labelserializable>
                            <pointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </pointoptionsserializable>
                            <legendpointoptionsserializable>
                                <cc1:PointOptions>
                                </cc1:PointOptions>
                            </legendpointoptionsserializable>
                        </cc1:Series>
                    </seriesserializable>

<SeriesTemplate><ViewSerializable>
    <cc1:LineSeriesView AxisXName="Primary AxisX" AxisYName="Primary AxisY" 
        PaneName="Default Pane">
    </cc1:LineSeriesView>
</ViewSerializable>
<LabelSerializable>
    <cc1:PointSeriesLabel LineVisible="True">
        <fillstyle>
            <optionsserializable>
                <cc1:SolidFillOptions />
            </optionsserializable>
        </fillstyle>
    </cc1:PointSeriesLabel>
</LabelSerializable>
<PointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</PointOptionsSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

                    <titles>
                        <cc1:ChartTitle Text="全设备周利用率" />
                    </titles>

                </dxchartsui:WebChartControl>
                
            </td>
        </tr>
        <tr>
            <td align="center">
                
                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" 
                    GridViewID="ASPxGridView2">
                </dx:ASPxGridViewExporter>
                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter4" runat="server" 
                    GridViewID="ASPxGridView4">
                </dx:ASPxGridViewExporter>
                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter3" runat="server" 
                    GridViewID="ASPxGridView3">
                </dx:ASPxGridViewExporter>
                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" 
                    GridViewID="ASPxGridView1">
                </dx:ASPxGridViewExporter>
                
                <dx:ASPxButton ID="ASPxButton2" runat="server" 
                    Text="导出到Excel" AutoPostBack="False" onclick="ASPxButton2_Click" >
                </dx:ASPxButton>
                
              
              </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr align ="center">
                        <td align ="left" width="25%">
                               <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                    Caption="机加工周利用率" ClientInstanceName="dgrid1">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="区域" VisibleIndex="0" 
                            FieldName="MachineType">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周数" VisibleIndex="1" FieldName="Week" 
                            SortIndex="0" SortOrder="Descending">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周利用率" VisibleIndex="2" FieldName="Rate">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                        </td>
                        <td align = "left" width="25%">
                               <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
                    Caption="钣金件周利用率" ClientInstanceName="dgrid2" >
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="区域" VisibleIndex="0" 
                            FieldName="MachineType">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周数" VisibleIndex="1" FieldName="Week" 
                            SortIndex="0" SortOrder="Descending">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周利用率" VisibleIndex="2" FieldName="Rate">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                        </td>
                        <td width="25%">
                               <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" 
                    Caption="复合材料周利用率" ClientInstanceName="dgrid3">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="区域" VisibleIndex="0" 
                            FieldName="MachineType">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周数" VisibleIndex="1" FieldName="Week" 
                            SortIndex="0" SortOrder="Descending">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周利用率" VisibleIndex="2" FieldName="Rate">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                        </td>
                        <td width="25%">
                               <dx:ASPxGridView ID="ASPxGridView4" runat="server" AutoGenerateColumns="False" 
                    Caption="液压测试周利用率" ClientInstanceName="dgrid4">
                   <Columns>
                        <dx:GridViewDataTextColumn Caption="区域" VisibleIndex="0" 
                            FieldName="MachineType">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周数" VisibleIndex="1" FieldName="Week" 
                            SortIndex="0" SortOrder="Descending">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="周利用率" VisibleIndex="2" FieldName="Rate">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                        </td>
                    </tr>
                </table>
                


             
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
