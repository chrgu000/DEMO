<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleRight_Tree.aspx.cs" Inherits="System_RoleRight_Tree"
    MasterPageFile="~/System/RoleRight.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterRightContent" runat="server">
    <FormatControls:Button ID="YxBtn" runat="server" OnToSave="ToSave" Title="权限设置" />
   <%-- <table>--%>
                    <%--<tr>
                        <td>
                            <dx:ASPxLabel ID="Label3" runat="server" Text="用户编码或名称">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="ASPxTextBox1" runat="server">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>--%>
              <%--  </table>--%>
   <%-- <table border="0" width="98%" cellpadding="0" cellspacing="0" class="div1">
        <tr>
            <td >--%><%--style="display:none;"--%>
                <asp:TreeView ID="treeDir" runat="server" ExpandDepth="1" ShowLines="True" Width="90%"
                    LineImagesFolder="../img/treeview/" ShowCheckBoxes="All">
                    <NodeStyle CssClass="tree_node" />
                    <SelectedNodeStyle CssClass="tree_node_select" />
                    <%--ShowCheckBoxes="All"--%>
                </asp:TreeView>
          <%--  </td>--%>
            <%--<td style="vertical-align:top;">
                <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server" DataSourceID="ObjectDataSource1"
                    KeyFieldName="vchrUid" >
                    <Columns>
                    
                        <dx:GridViewDataColumn FieldName="bChoosed" Caption=" ">
                            <DataItemTemplate>
                                <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Checked='<%#  DataBinder.Eval(Container.DataItem, "bChoosed")%>'>
                                </dx:ASPxCheckBox>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataTextColumn FieldName="vchrUid" Caption="用户编码">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="vchrName" Caption="用户名称">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager Mode="ShowAllRecords"/>
                </dx:ASPxGridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="OjbData"
            SelectMethod="GetRoleUser"  OnSelecting="ObjectDataSource1_Selecting"> 
            <SelectParameters>
                <asp:Parameter Name="sRoleID" Type="String" />
                <asp:Parameter Name="vchrUid" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            </td>--%>
<%--        </tr>
    </table>--%>

    <script language="javascript" type="text/javascript">
        function doSelect() {

            return true;
        }
        function doSave() {


            return true;
        }
    </script>

    <script>
        function setParentState(objNode) {
            var objParentDiv = WebForm_GetParentByTagName(objNode, "div");
            if (objParentDiv == null || objParentDiv == "undefined")
                return;
            var divID = objParentDiv.getAttribute("ID");
            var prefix = divID.substring(0, divID.indexOf("Nodes"));
            var parentID = prefix + "CheckBox";
            var parentChk = document.getElementById(parentID);
            if (parentChk == null || parentChk == "undefined")
                return;
            if (objNode.checked) {
                parentChk.checked = true;
            }
            else {
                if (isAllChildrenUnChecked(parentChk)) {
                    parentChk.checked = false;
                }
            }
            setParentState(parentChk);
        }
        function setChildState(objNode)//设定子控件状态
        {
            var nodeID = objNode.getAttribute("ID");   //chkBox ID 
            var prefix = nodeID.substring(0, nodeID.indexOf("CheckBox"));  //节点的前缀
            var childrenDiv = document.getElementById(prefix + "Nodes");
            if (childrenDiv == null || childrenDiv == "undefined")
                return;
            var childrenArray = childrenDiv.children; //取得所有子控件
            for (var i = 0; i < childrenArray.length; i++) {
                var container = childrenArray[i]; //子控件的容器
                var chk = WebForm_GetElementByTagName(container, "input"); //查找Check控件,由于只有一个种Input控件,就是CheckBox
                chk.checked = objNode.checked;
                setChildState(chk);
            }
        }
        function isAllChildrenUnChecked(objChk) {
            var objChkID = objChk.getAttribute("ID");
            var prefix = objChkID.substring(0, objChkID.indexOf("CheckBox"));  //节点的前缀
            var childrenDiv = document.getElementById(prefix + "Nodes");
            if (childrenDiv == null || childrenDiv == "undefined")
                return;
            var childrenArray = childrenDiv.children; //取得所有子控件        
            for (var i = 0; i < childrenArray.length; i++) {
                var container = childrenArray[i]; //子控件的容器
                var chk = WebForm_GetElementByTagName(container, "input"); //查找Check控件,由于只有一个种Input控件,就是CheckBox
                if (chk.checked)
                    return false;
            }
            return true;
        }
        //触发事件
        function HandleCheckEvent() {
            var objNode = event.srcElement;
            if (objNode.tagName != "INPUT" || objNode.type != "checkbox")
                return;
            if (objNode.checked == false) {
                //设定子Chk状态
                setChildState(objNode);
            }
            else {
                //设定父Chk状态
                setParentState(objNode);
            }
        }
    </script>

</asp:Content>
