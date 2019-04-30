<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TitleControl.ascx.cs" Inherits="PMMWS.TitleControl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dx" %>


<table id="table1" border="0" cellpadding="0" cellspacing="0" width="100%" 
    align="center">
    <tr>
        <td align="left" width = "100%"
            style="font-family: 'Times New Roman', Times, serif; font-style: normal; font-weight: bolder; font-variant: small-caps; color: #0000FF; background-color: #FFFFFF; font-size: x-large;" 
            valign="middle">
            <div align="left" id="demo" 
                style="overflow:hidden;height:60px;border-width:1px 1px 1px 1px;border-style:dotted dotted dotted dotted; background-color: #FFFFFF;">
            <!-- 定义内容-->
               <asp:Image ID="Image1" runat="server" Height="59px" ImageUrl="~/mono_aviation.gif" Width="250px"/>     
                Welcome to PMMS 欢迎进入通用电气航空系统(苏州)预测维护及管理系统
            </div>
        </td>
    </tr>
    <tr>
       <td colspan="2">
        <table id="table2" border="0" cellpadding="0" cellspacing="0" 
    width="100%" style="background-color: #CCCCFF">
            <tr>
                <td>
                    <dx:ASPxMenu ID="ASPxMenu1" runat="server" ClientIDMode="AutoID" Width="100%">
                        <Items>
                            <dx:MenuItem Text="MaintenanceTrack.维修状态" NavigateUrl="~/MaintenancePlanForm.aspx">
                       
                            </dx:MenuItem>
                            <dx:MenuItem Text="HistoryInfo.维修历史记录" NavigateUrl="~/MaintenanceHistor.aspx">
                            </dx:MenuItem>
                            <dx:MenuItem Text="Planned M.保养计划" NavigateUrl="~/PmPlan.aspx">
                            </dx:MenuItem>
                            <dx:MenuItem Text="Equip.Info.设备信息" NavigateUrl="~/EquipmentsInfo.aspx">
                            </dx:MenuItem>
                            <dx:MenuItem NavigateUrl="~/SPInfo.aspx" Text="SP.Info.备件信息">
                            </dx:MenuItem>
                            <dx:MenuItem NavigateUrl="~/EHSDeviceInfo.aspx" Text="PublicFacilities.公用设施">
                            </dx:MenuItem>
                            <dx:MenuItem Text="ChartDisp.图表查看" NavigateUrl="~/ChartingControl.aspx">
                            </dx:MenuItem>
                            <dx:MenuItem Text="WO.Manage.工单管理" NavigateUrl="~/WorkOrderAdmin.aspx">
                            </dx:MenuItem>
                            <dx:MenuItem NavigateUrl="~/WorkerInfo.aspx" Text="WorkerInfo.人员信息">
                            </dx:MenuItem>
                        </Items>
                        <ItemStyle>
                        <Border BorderColor="#000099" BorderWidth="1px" />
<Border BorderColor="#000099" BorderWidth="1px"></Border>
                        </ItemStyle>
                    </dx:ASPxMenu>
                    </td>
                 
            </tr>
        </table>
       </td>
    </tr>
</table>
<%--<script language="javascript" type="text/javascript">
<!--
    var demo = document.getElementById("demo");
    var demo1 = document.getElementById("demo1");
    var demo2 = document.getElementById("demo2");
    var speed = 100;    //数值越大滚动速度越慢
    demo2.innerHTML = demo1.innerHTML;
    demo.scrollTop = demo.scrollHeight;
    function Marquee() {
        if (demo1.offsetTop - demo.scrollTop >= 0)
            demo.scrollTop += demo2.offsetHeight
        else {
            demo.scrollTop--
        }
    }
    var MyMar = setInterval(Marquee, speed);
    demo.onmouseover = function () { clearInterval(MyMar) }
    demo.onmouseout = function () { MyMar = setInterval(Marquee, speed) }
-->
</script>--%>
