<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleRight_Index.aspx.cs" Inherits="System_RoleRight_Index" MasterPageFile="~/Frame/MasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
	<frameset cols="50%,*" border="0" framespacing="0" frameborder="0" id="Frameset1" AUTOCOMPLETE="off"> 
	    <frame src="RoleRight_List.aspx" frameborder="NO" id="Frame1" name="middle" marginwidth="0" marginheight="0" class="col" noresize>
		<frame src="RoleRight_Left_Tree.aspx" scrolling="auto" name="left" id="left" scrolling="auto" noresize>
	</frameset>	
</asp:Content>