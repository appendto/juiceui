<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="buttons.aspx.cs" Inherits="Mobile.Buttons" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Buttons" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">
			<p>Page content goes here.</p>
		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

<!--
<a href="#" data-role="button">Link button</a>

<div data-role="button" data-theme="c" data-icon="refresh" data-iconpos="notext">Button</div>

<h2>Grouped</h2>

<div data-role="controlgroup">
	<a href="#" data-role="button">Yes</a>
	<a href="#" data-role="button">No</a>
	<a href="#" data-role="button">Maybe</a>
</div>

<div data-role="controlgroup" data-type="horizontal">
	<a href="#" data-role="button">Yes</a>
	<a href="#" data-role="button">No</a>
	<a href="#" data-role="button">Maybe</a>
</div>

<h2>Icons</h2>

<a href="#" data-role="button" data-icon="delete">Delete</a>

<div data-role="controlgroup"  data-type="horizontal">
	<a href="#" data-role="button" data-icon="arrow-l" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="arrow-r" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="arrow-u" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="arrow-d" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="delete" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="plus" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="minus" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="check" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="gear" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	</div>
	<div data-role="controlgroup"  data-type="horizontal">
	<a href="#" data-role="button" data-icon="refresh" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="forward" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="back" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="grid" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="star" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="alert" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
	<a href="#" data-role="button" data-icon="info" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
  <a href="#" data-role="button" data-icon="home" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
  <a href="#" data-role="button" data-icon="search" data-iconpos="notext" data-theme="a" data-inline="true">My button</a>
</div>

<h2>Inline</h2>

<a href="#" data-role="button" data-inline="true">Cancel</a>
<a href="#" data-role="button" data-inline="true" data-theme="b">Save</a>
-->

</asp:Content>
