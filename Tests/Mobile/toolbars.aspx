<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="toolbars.aspx.cs" Inherits="Mobile.Toolbars" ClientIDMode="Static" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Toolbars" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">
	
			<h2>Headers</h2>
			
			<mobile:header Text="Page title" runat="server" />
	
			<h2>Adding buttons</h2>
	
			<mobile:header Text="Edit Contact" runat="server">
				<a id="a1" runat="server" href="index.html">Cancel</a>
				<mobile:anchor TargetControlID="a1" runat="server" Icon="delete" />
				<a id="a2" runat="server" href="index.html">Save</a>
				<mobile:anchor TargetControlID="a2" runat="server" Icon="check" />
			</mobile:header>
			
			<h3>Making buttons visually stand out</h3>
			
			<mobile:header Text="Edit Contact" runat="server">
				<a id="a3" runat="server" href="index.html">Cancel</a>
				<mobile:anchor TargetControlID="a3" runat="server" Icon="delete" />
				<a id="a4" runat="server" href="index.html">Save</a>
				<mobile:anchor TargetControlID="a4" runat="server" Icon="check" Theme="b" />
			</mobile:header>
	
			<h3>Controlling button position with classes</h3>
	
			<mobile:header Text="Page title" runat="server">
				<a id="a5" runat="server" href="index.html" class="ui-btn-right">Options</a>
				<mobile:anchor TargetControlID="a5" runat="server" Icon="gear" />
			</mobile:header>
			
			
			<h3>Adding buttons to toolbars without heading</h3>
	
			<mobile:header runat="server">
				<a id="a6" runat="server" href="index.html" class="ui-btn-right">Options</a>
				<mobile:anchor TargetControlID="a6" runat="server" Icon="gear" />
				<span class="ui-title" />
			</mobile:header>
			
			<div class="ui-bar ui-bar-b">
				<h3>I'm just a div with bar classes and a mini inline <a href="#" data-role="button" data-inline="true" data-mini="true">Button</a></h3>
			</div>
				
			<div class="ui-bar ui-bar-e">
				<h3 style="display:inline-block; width:92%; margin-top:5px;">This is an alert message. </h3><div style="display:inline-block; width:8%; margin-top:0px; text-align:right;"><a href="#" data-role="button" data-icon="delete" data-inline="true" data-iconpos="notext">Dismiss</a></div><p style="font-size:85%; margin:-.3em 0 1em;">And here's some additional text in a paragraph.</p>
			</div>

			<!---- Footers ---->

			<h2>Footers</h2>

			<mobile:footer Text="Footer Content" runat="server" />

			<p>This creates this toolbar with buttons sitting in a row</p>

			<mobile:footer runat="server" class="ui-bar">
				<a id="a7" runat="server" href="index.html" data-icon="plus">Add</a>
				<mobile:anchor TargetControlID="a7" runat="server" Icon="plus" />
				<a id="a8" runat="server" href="index.html" data-icon="arrow-u">Up</a>
				<mobile:anchor TargetControlID="a8" runat="server" Icon="ArrowUp" />
				<a id="a9" runat="server" href="index.html" data-icon="arrow-d">Down</a>
				<mobile:anchor TargetControlID="a9" runat="server" Icon="ArrowDown" />
			</mobile:footer>

			<p>This creates a grouped set of buttons:</p>

			<mobile:footer runat="server" class="ui-bar">
				<mobile:controlgroup runat="server" GroupType="horizontal">
					<a href="index.html" data-icon="plus">Add</a>
					<a href="index.html" data-icon="arrow-u">Up</a>
					<a href="index.html" data-icon="arrow-d">Down</a>
				</mobile:controlgroup>
			</mobile:footer>
	
			<h2>Adding form elements</h2>

			<mobile:footer runat="server" class="ui-bar">
				<label for="s1">Shipping:</label>
				<select id="s1" runat="server" name="s1">
					<option value="standard">Standard: 7 day</option>
					<option value="rush">Rush: 3 days</option>
					<option value="express">Express: next day</option>
					<option value="overnight">Overnight</option>
				</select>
				<mobile:select TargetControlID="s1" runat="server" Theme="a" Mini="true" />
			</mobile:footer>


		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
