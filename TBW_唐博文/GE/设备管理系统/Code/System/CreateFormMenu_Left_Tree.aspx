<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateFormMenu_Left_Tree.aspx.cs"
    Inherits="System_CreateFormMenu_Left_Tree" SmartNavigation="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  >
    <form id="frmLeftTree" runat="server" onkeydown="return(event.keyCode!=13)">
        <table border="0" width="98%" cellpadding="0" cellspacing="0" class="InputFrameMain">
            <tr>
                <td class="InputFrameMain">
                    <asp:TreeView ID="treeDir" runat="server" ExpandDepth="1" ShowLines="True"  
                        LineImagesFolder="../Images/treeview/">
                        <NodeStyle CssClass="tree_node" />
                        <SelectedNodeStyle CssClass="tree_node_select" />  <%--ShowCheckBoxes="All"--%>
                    </asp:TreeView>
                </td> 
            </tr>
        </table>
    </form>
</body>
</html>
