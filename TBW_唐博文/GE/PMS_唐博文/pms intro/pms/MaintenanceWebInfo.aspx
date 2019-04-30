<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceWebInfo.aspx.cs" Inherits="PMMWS.MaintenanceWebInfo" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register src="TitleControl.ascx" tagname="TitleControl" tagprefix="uc1" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallback" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>M.WebInfo机加工工单维护</title>
    <script language="javascript" type="text/javascript">
  
        function OnButtonClick() {

          var bin = confirm("确认要?");
          if (bin == true) { 
            
          }
        }
   

    </script>

    <style type="text/css">
        .style5
        {
            width: 15%;
        }
        .style6
        {
            font-family: 华文楷体;
            font-size: medium;
        }
        .style9
        {
            font-size: medium;
            font-family: 华文中宋;
        }
        .style10
        {
            font-family: "Times New Roman", Times, serif;
            font-size: x-large;
        }
        .style11
        {
            width: 15%;
            font-family: 华文中宋;
        }
        .style17
        {
        }
        .style19
        {
            font-size: medium;
            font-family: 华文中宋;
            width: 245px;
        }
        .style23
        {
            width: 271px;
        }
        .style24
        {
            font-size: medium;
            font-family: 华文楷体;
            width: 245px;
        }
        .style26
        {
            width: 271px;
            font-family: 华文楷体;
            font-size: medium;
        }
        .style29
        {
            font-family: 华文楷体;
            font-size: medium;
            width: 17%;
            text-align: center;
        }
        .style32
        {
            font-family: 华文楷体;
            width: 17%;
        }
        .style33
        {
        }
        .style34
        {
            height: 20px;
        }
        .style35
        {
            font-family: 华文楷体;
            font-size: medium;
            width: 17%;
            height: 25px;
            text-align: center;
        }
        .style36
        {
            height: 25px;
        }
        .style37
        {
            font-family: 华文楷体;
            font-size: medium;
            height: 25px;
        }
        .style38
        {
            font-family: "Times New Roman", Times, serif;
            font-size: x-large;
            height: 21px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" >
     <table align="center" bgcolor="#CCFFFF" width="1024" border="0">
           <tr>
    <td>
    <uc1:TitleControl ID="TitleControl1" runat="server" />
    </td>
    </tr>
    <div>
        <table align="center" bgcolor="#CCFFFF" width="1024" border="1">
           
            
            
            <tr>
            <td align="left" class="style38" colspan="7">

         <asp:Button ID="saveButton" runat="server" CssClass="dxcaTextBoxCell" 
             onclick="saveButton_Click" Text="工单保存" Width="103px" />

                    <font class="font8"><strong>&nbsp;&nbsp;&nbsp;

         <asp:Button ID="cancelButton" runat="server" CssClass="dxcaTextBoxCell" 
             onclick="cancelButton_Click" style="height: 22px" Text="取消" Width="103px" />

                    &nbsp;

                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="ASPxLabel">
                </dx:ASPxLabel>

                    </strong></font></td>
            </tr>
            <tr>
            <td align="center" class="style10" colspan="7">
                    <font class="font8"><strong>设备维修记录单 Medical Record of Machine</strong></font></td>
            </tr>
            <tr>
            <td align="center" class="style5" rowspan="4">
                    <strong>故障</strong><span class="style9"><strong>描述</strong></span><font class="font5"></font></td>
            <td align="left" class="style29">
                工单号</td>
            <td align="center" class="style33">
                    <dx:ASPxTextBox ID="workOrderNum" runat="server" Height="100%" Width="100%" 
                        ReadOnly="True">
                        <ReadOnlyStyle BackColor="Silver">
                        </ReadOnlyStyle>
                    </dx:ASPxTextBox>
            </td>
            <td align="center" class="style6" width="20%" colspan="3">
                &nbsp;</td>
            <td align="left">
                                &nbsp;</td>
            </tr>
            <tr>
            <td align="left" class="style29">
                    <font class="style70"><span class="style6">设备名称</span></font></td>
            <td align="center" class="style33">
                    <dx:ASPxTextBox ID="machineName" runat="server" Height="100%" Width="100%" ReadOnly="True">
                        <ReadOnlyStyle BackColor="Silver">
                        </ReadOnlyStyle>
                    </dx:ASPxTextBox>
            </td>
            <td align="center" class="style6" colspan="3">
                报修时间</td>
            <td align="center">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="reportTime" runat="server" Height="100%" 
                        Width="100%" DisplayFormatString="yyyy-MM-dd HH:mm:ss" ReadOnly="True">
                                    <ReadOnlyStyle BackColor="Silver">
                                    </ReadOnlyStyle>
                                </dx:ASPxTextBox>
                    </span>
            </td>
            </tr>
            <tr>
            <td align="left" class="style35">
                区域</td>
            <td align="center" class="style36">
                                <dx:ASPxComboBox ID="xMachineTypeBox" runat="server" ClientIDMode="AutoID" 
                                    ValueType="System.String" ReadOnly="True">
                                    <Items>
                                        <dx:ListEditItem Text="机加工" Value="0" />
                                        <dx:ListEditItem Text="液压系统" Value="1" />
                                        <dx:ListEditItem Text="钣金件" Value="2" />
                                        <dx:ListEditItem Text="复合材料" Value="3" />
                                    </Items>
                                    <ReadOnlyStyle BackColor="Silver">
                                    </ReadOnlyStyle>
                                </dx:ASPxComboBox>
                                
            </td>
            <td align="center" class="style37" colspan="3">
                报警号</td>
            <td align="center" class="style36">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="alarmCode" runat="server" Height="100%" 
                        Width="100%">
                                    <ReadOnlyStyle BackColor="Silver">
                                    </ReadOnlyStyle>
                                </dx:ASPxTextBox>
                    </span>
            </td>
            </tr>
            <tr>
            <td align="left" class="style29">
                报修描述</td>
            <td align="center" colspan="5">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="description" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
            </td>
            </tr>
            <tr>
            <td align="center" class="style11" rowspan="7">
                    <strong>维修信息</strong></td>
            <td align="center" class="style29">
                             
                                维修工Id</td>
            <td align="left" class="style33">
                   
                    <dx:ASPxTextBox ID="WorkName" runat="server" Height="100%" Width="100%">
                        <ReadOnlyStyle BackColor="Silver">
                        </ReadOnlyStyle>
                    </dx:ASPxTextBox>
                </td>
            <td align="left" class="style6" colspan="2">
                    开始维修时间</td>
            <td align="left" colspan="2">
                    <dx:ASPxDateEdit ID="AlarmsStaterTime" runat="server" 
                        DisplayFormatString="yyyy-MM-dd HH:mm:ss" EditFormat="DateTime" 
                        EditFormatString="yyyy-MM-dd HH:mm:ss">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                                &nbsp;</td>
            <td align="left" class="style33">
                   
                    &nbsp;</td>
            <td align="left" class="style6" colspan="2">
                    结束维修时间</td>
            <td align="left" colspan="2">
                    <dx:ASPxDateEdit ID="AlarmEndTime" runat="server" 
                        DisplayFormatString="yyyy-MM-dd HH:mm:ss" EditFormat="DateTime" 
                        EditFormatString="yyyy-MM-dd HH:mm:ss">
                    </dx:ASPxDateEdit>
                    </td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                                故障类型</td>
            <td align="left" class="style33">
                   
                    <dx:ASPxComboBox ID="Faulttype" runat="server">
                        <Items>
                            <dx:ListEditItem Text="停机故障（操作）" Value="0" />
                            <dx:ListEditItem Text="停机故障（人为）" Value="1" />
                            <dx:ListEditItem Text="停机故障（质量）" Value="2" />
                            <dx:ListEditItem Text="停机故障（备件）" Value="3" />
                            <dx:ListEditItem Text="停机故障（机台测试）" Value="4" />
                            <dx:ListEditItem Text="非停机故障" Value="5" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            <td align="left" class="style6" colspan="2">
                    &nbsp;</td>
            <td align="left" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                                故障详述</td>
            <td align="left" class="style17" colspan="5">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="defination" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                                故障位置</td>
            <td align="left" class="style17" colspan="5">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="olcation" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                                原因分析</td>
            <td align="left" class="style17" colspan="5">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="reason" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                                维修方法</td>
            <td align="left" class="style17" colspan="5">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="remedy" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            <tr>
            <td align="center" class="style11" rowspan="4">
                    <strong>更换备件</strong></td>
            <td align="center" class="style29">
                             
                                名称/库存号</td>
            <td align="center" class="style32">
                   
                                型号</td>
            <td align="center" class="style24">
                    价格</td>
            <td align="center" class="style26">
                    数量</td>
            <td align="center" colspan="2" class="style6">
                    等待时间</td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partName0" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="left" class="style33">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partType0" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="left" class="style19">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partPrice0" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="center" class="style23">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partNum0" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="center" colspan="2">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partWaitTime0" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partName1" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="left" class="style33">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partType1" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="left" class="style19">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partPrice1" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="center" class="style23">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partNum1" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="center" colspan="2">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partWaitTime1" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            <tr>
            <td align="center" class="style29">
                             
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partName2" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="left" class="style33">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partType2" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="left" class="style19">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partPrice2" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="center" class="style23">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partNum2" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="center" colspan="2">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="partWaitTime2" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            <tr>
            <td align="center" class="style11">
                    <strong>设备操作工</strong></td>
            <td align="center" class="style29">
                             
                                停机结束时间</td>
            <td align="left" class="style33" colspan="2">
                   
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="stopTime" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            <td align="center" class="style26">
                    操作工</td>
            <td align="center" colspan="2">
                    <span style="mso-ignore:vglayout2">
                                <dx:ASPxTextBox ID="Operator" runat="server" Height="100%" 
                        Width="100%">
                                </dx:ASPxTextBox>
                    </span>
                </td>
            </tr>
            </table>
    </div>
     <table align="center" width="1024" bgcolor="#FFCCFF">
     <tr>
     <td class="style34" width="25%">

         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

     <td class="style34" width="25%">

         &nbsp;</td>
     <td class="style34" width="25%">

         &nbsp;</td>
     </tr>
    </table>
    </form>
</body>
</html>
 