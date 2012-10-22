<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Mobile._Default" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="JuiceUI Mobile Demo" runat="server"/>

		<mobile:content runat="server">

			<mobile:listview runat="server" Theme="c" DividerTheme="d">
        <mobile:listviewitem runat="server" Icon="Gear"><a href="buttons.aspx">Buttons</a></mobile:listviewitem>
        <li><a href="collapsibles.aspx">Collapsables</a></li>
				<li><a href="dialogs.aspx">Dialogs</a></li>
				<li><a href="form.aspx">Form Elements</a></li>
        <li><a href="lists.aspx">Listviews</a></li>
				<li><a href="lists.aspx">Popups</a></li>
        <li><a href="navbars.aspx">Navigation Bars</a></li>
				<li><a href="toolbars.aspx">Toolbars</a></li>
			</mobile:listview>

		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
