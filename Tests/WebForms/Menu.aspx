<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WebForms.Menu" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">

	<juice:menu id="_Menu" runat="server">
		<juice:menuitem runat="server"><Content><a href="#">Item 1</a></Content></juice:menuitem>
		<juice:menuitem runat="server"><Content><a href="#">Item 2</a></Content></juice:menuitem>
		<juice:menuitem runat="server"><Content><a href="#">Item 3</a></Content>
		<Items>
				<juice:menuitem runat="server"><Content><a href="#">Item 3-1</a></Content></juice:menuitem>
				<juice:menuitem runat="server"><Content><a href="#">Item 3-2</a></Content></juice:menuitem>
				<juice:menuitem runat="server"><Content><a href="#">Item 3-3</a></Content></juice:menuitem>
				<juice:menuitem runat="server"><Content><a href="#">Item 3-4</a></Content></juice:menuitem>
				<juice:menuitem runat="server"><Content><a href="#">Item 3-5</a></Content></juice:menuitem>
		</Items>
		</juice:menuitem>
		<juice:menuitem runat="server"><Content><a href="#">Item 4</a></Content></juice:menuitem>
		<juice:menuitem runat="server"><Content><a href="#">Item 5</a></Content></juice:menuitem>

	</juice:menu>

	<asp:button ID="_Button" runat="server" Text="Postback"/>
</asp:content>