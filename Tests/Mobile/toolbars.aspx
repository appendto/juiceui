<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="toolbars.aspx.cs" Inherits="Mobile.Toolbars" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Toolbars" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">
	
			<h2>Headers</h2>
			
			<div data-role="header">
				<h1>Page title</h1>
			</div>

	
			<h2>Adding buttons</h2>
	
			<div data-role="header">
				<a href="index.html" data-icon="delete">Cancel</a>
				<h1>Edit Contact</h1>
				<a href="index.html" data-icon="check">Save</a>
			</div>
			
			<h3>Making buttons visually stand out</h3>
			
			<div data-role="header">
				<a href="index.html" data-icon="delete">Cancel</a>
				<h1>Edit Contact</h1>
				<a href="index.html" data-icon="check" data-theme="b">Save</a>
			</div>
	
			<h3>Controlling button position with classes</h3>
	
			<div data-role="header" >
				<h1>Page Title</h1>
				<a href="index.html" data-icon="gear" class="ui-btn-right">Options</a>
			</div>
			
			
			<h3>Adding buttons to toolbars without heading</h3>
	

			<div data-role="header" >
				<a href="index.html" data-icon="gear" class="ui-btn-right">Options</a>
				<span class="ui-title" />
			</div>
			
			<div class="ui-bar ui-bar-b">
				<h3>I'm just a div with bar classes and a mini inline <a href="#" data-role="button" data-inline="true" data-mini="true">Button</a></h3>
			</div>
				
			<div class="ui-bar ui-bar-e">
				<h3 style="display:inline-block; width:92%; margin-top:5px;">This is an alert message. </h3><div style="display:inline-block; width:8%; margin-top:0px; text-align:right;"><a href="#" data-role="button" data-icon="delete" data-inline="true" data-iconpos="notext">Dismiss</a></div><p style="font-size:85%; margin:-.3em 0 1em;">And here's some additional text in a paragraph.</p>
			</div>

			<h2>Footers</h2>

			<div data-role="footer">
				<h4>Footer content</h4>
			</div>

			<p>This creates this toolbar with buttons sitting in a row</p>

			<div data-role="footer" class="ui-bar">
				<a href="index.html" data-icon="plus">Add</a>
				<a href="index.html" data-icon="arrow-u">Up</a>
				<a href="index.html" data-icon="arrow-d">Down</a>
			</div>

			<p>This creates a grouped set of buttons:</p>

			<div data-role="footer" class="ui-bar">
				<div data-role="controlgroup" data-type="horizontal">
					<a href="index.html" data-icon="plus">Add</a>
					<a href="index.html" data-icon="arrow-u">Up</a>
					<a href="index.html" data-icon="arrow-d">Down</a>
				</div>
			</div>
	
			<h2>Adding form elements</h2>

			<div data-role="footer" class="ui-bar">
				<label for="select-choice-1">Shipping:</label>
				<select name="select-choice-1" id="select-choice-1" data-theme="a" data-mini="true">
					<option value="standard">Standard: 7 day</option>
					<option value="rush">Rush: 3 days</option>
					<option value="express">Express: next day</option>
					<option value="overnight">Overnight</option>
				</select>
			</div>


		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
