<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Select.aspx.cs" Inherits="Share_Select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <meta charset="gb2312">

    <script src="../Script/PublicJScript.js"></script>

    <title>查询参照</title>

    <script language="javascript" type="text/javascript">
        var s = window.dialogArguments;
        window.returnValue = s;
        
    </script>

    <%--    <script>    
document.onkeydown =function{ 
if(event.keyCode==13) 
return false;
}
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <%--<asp:HiddenField ID="hidflag" runat="server"  /> --%>
    <table style="margin: auto; text-align: center; width: 98%">
        <tr>
            <td style="width: 100px">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="编码或名称">
                </dx:ASPxLabel>
            </td>
            <td style="text-align: left">
                <dx:ASPxTextBox ID="ASPxTextBox1" runat="server">
                </dx:ASPxTextBox>
            </td>
            <td style="width: 200px" style="text-align: right">
                <asp:Button ID="btnSelect" runat="server" CssClass="btn" Text="查询" OnClick="btnSelect_Click" />
                <input id="confirm" type="button" value="确定" class="btn btn-default btn-sm" runat="server"
                    onclick="sendback()" />
                <input id="cancel" type="button" value="取消" class="btn btn-default btn-sm" onclick="Anul()" />
            </td>
        </tr>
    </table>
    <dx:ASPxGridView ID="ASPxGridViewSel" runat="server" KeyFieldName="iID" OnPageIndexChanged="ASPxGridViewSel_PageIndexChanged" >
        <Columns>
            <dx:GridViewDataColumn FieldName="" Caption="" Width="30px">
                <DataItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="编码" Width="50%">
                <DataItemTemplate>
                    <asp:Label ID="LabelID" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "iID")%>'></asp:Label>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="名称" Width="50%">
                <DataItemTemplate>
                    <asp:Label ID="LabelName" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "iName")%>'></asp:Label>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
        </Columns>
    </dx:ASPxGridView>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    //    function RowDblClick(s, e) {
    //         s
    //    }
    //
    //    alert(s.id);
    //    var chk = document.getElementsByTagName("input");
    //    for (var i = 0; i < chk.length; i++) {
    //        var c = chk[i];
    //        if (c.id.indexOf("ASPxTextBox1") >= 0) {
    //            c.value = s.id;
    //        }
    //    }

    function CheckBoxChange(s) {
        var k = document.getElementById(s);
        if (k.checked) {
            var chk = document.getElementsByTagName("input");
            for (var i = 0; i < chk.length; i++) {
                var c = chk[i];
                if (c.type == 'checkbox' && c.id.indexOf("CheckBox1")) {
                    if (k.id != c.id) {
                        c.checked = false;
                    }
                }
            }
        }

    }
    function sendback() {
        //        var b = document.getElementsByName("ASPxGridViewSel_cell0_1_LabelID");

        //        alert(b);
        //        alert(b[0].innerText);

        var k = new Object();
        k.type = "ok";
        k.id = "";
        k.name = "";
        var chk = document.getElementsByTagName("input");
        var span = document.getElementsByTagName("span");
        for (var i = 0; i < chk.length; i++) {
            var c = chk[i];
            if (c.type == 'checkbox' && c.id.indexOf("CheckBox1") >= 0) {
                if (c.checked) {
                    var p = c.id;
                    var p1 = p.replace("0_CheckBox1", "1_LabelID");
                    var p2 = p.replace("0_CheckBox1", "2_LabelName");
                    for (var j = 0; j < span.length; j++) {
                        var b = span[j];
                        if (b.id.indexOf(p1) >= 0) {
                            k.id = b.innerHTML;
                        }
                        else if (b.id.indexOf(p2) >= 0) {
                            k.name = b.innerHTML;
                        }
                    }
                    //                    k.id = document.getElementsByName(p1)[0].innerText;
                    //                    k.name = document.getElementsByName(p2)[0].innerText;
                }
            }
        }
        if (k.id == "") {
            alert("请选择!");
            return false;
        }
        else {
            window.returnValue = k;
            window.close();
        }

    }

    function Anul() {
        var s = new Object();
        s.id = "";
        s.name = "";
        s.flag = "";

        window.returnValue = s;
        window.close();
    }
</script>

