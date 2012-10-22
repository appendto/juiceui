<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="popups.aspx.cs" Inherits="Mobile.Popups" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Popups" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">

			<a href="#popupBasic" data-rel="popup" data-role="button" data-inline="true">Open Popup</a>
		
			<div data-role="popup" id="popupBasic">
				<p>This is a completely basic popup, no options set.</p>
			</div>
		
			<a href="#popupInfo" data-rel="popup" data-role="button" data-inline="true">Tooltip</a>
			<a href="#popupMenu" data-rel="popup" data-role="button" data-inline="true">Menu</a>
			<a href="#popupNested" data-rel="popup" data-role="button" data-inline="true">Nested menu</a>
			<a href="#popupLogin" data-rel="popup" data-position-to="window" data-role="button" data-inline="true">Form</a>
			<a href="#popupDialog" data-rel="popup" data-position-to="window" data-role="button" data-inline="true" data-transition="pop">Dialog</a>
			<a href="#popupPhoto" data-rel="popup" data-position-to="window" data-role="button" data-inline="true" data-transition="fade">Photo</a>
		
			<div data-role="popup" id="popupInfo" class="ui-content" data-theme="e" style="max-width:350px;">
				<p>Here is a <strong>tiny popup</strong> being used like a tooltip. The text will wrap to multiple lines as needed.</p>
			</div>

			<div data-role="popup" id="popupMenu" data-theme="a">
				<ul data-role="listview" data-inset="true" style="min-width:210px;" data-theme="b">
					<li data-role="divider" data-theme="a">Popup API</li>
					<li><a href="options.html">Options</a></li>
					<li><a href="methods.html">Methods</a></li>
					<li><a href="events.html">Events</a></li>
				</ul>
			</div>

			<div data-role="popup" id="popupNested" data-theme="none">
				<div data-role="collapsible-set" data-theme="b" data-content-theme="c" data-collapsed-icon="arrow-r" data-expanded-icon="arrow-d" style="margin:0; width:250px;">
					<div data-role="collapsible" data-inset="false">
						<h2>Farm animals</h2>
						<ul data-role="listview">
							<li><a href="data/dialog.html" data-rel="dialog">Chicken</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Cow</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Duck</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Sheep</a></li>
						</ul>
					</div><!-- /collapsible -->
					<div data-role="collapsible" data-inset="false">
						<h2>Pets</h2>
						<ul data-role="listview">
							<li><a href="data/dialog.html" data-rel="dialog">Cat</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Dog</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Iguana</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Mouse</a></li>
						</ul>
					</div><!-- /collapsible -->
					<div data-role="collapsible" data-inset="false">
						<h2>Ocean Creatures</h2>
						<ul data-role="listview">
							<li><a href="data/dialog.html" data-rel="dialog">Fish</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Octopus</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Shark</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Starfish</a></li>
						</ul>
					</div><!-- /collapsible -->
					<div data-role="collapsible" data-inset="false">
						<h2>Wild Animals</h2>
						<ul data-role="listview">
							<li><a href="data/dialog.html" data-rel="dialog">Lion</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Monkey</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Tiger</a></li>
							<li><a href="data/dialog.html" data-rel="dialog">Zebra</a></li>
						</ul>
					</div><!-- /collapsible -->
				</div><!-- /collapsible set -->
			</div><!-- /popup -->
		

			<div data-role="popup" id="popupLogin" data-theme="a" class="ui-corner-all">
				<form>
					<div style="padding:10px 20px;">
						<h3>Please sign in</h3>
								<label for="un" class="ui-hidden-accessible">Username:</label>
								<input type="text" name="user" id="un" value="" placeholder="username" data-theme="a" />

								<label for="pw" class="ui-hidden-accessible">Password:</label>
								<input type="password" name="pass" id="pw" value="" placeholder="password" data-theme="a" />

		    			<button type="submit" data-theme="b">Sign in</button>
					</div>
				</form>
			</div>
		
			<div data-role="popup" id="popupDialog" data-overlay-theme="a" data-theme="c" style="max-width:400px;" class="ui-corner-all">
				<div data-role="header" data-theme="a" class="ui-corner-top">
					<h1>Delete Page?</h1>
				</div>
				<div data-role="content" data-theme="d" class="ui-corner-bottom ui-content">
					<h3 class="ui-title">Are you sure you want to delete this page?</h3>
					<p>This action cannot be undone.</p>
					<a href="#" data-role="button" data-inline="true" data-rel="back" data-theme="c">Cancel</a>    
					<a href="#" data-role="button" data-inline="true" data-rel="back" data-transition="flow" data-theme="b">Delete</a>  
				</div>
			</div>

			<div data-role="popup" id="popupPhoto" data-overlay-theme="a" data-theme="d" data-corners="false">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Close</a><img class="popphoto" src="../../_assets/images/colorful-city.jpg" alt="Colorful city">
			</div>
			
			<a href="#popupCloseRight" data-rel="popup" data-role="button" data-inline="true">Popup with close button right</a>
			<a href="#popupCloseLeft" data-rel="popup" data-role="button" data-inline="true">Popup with close button left</a>
			<a href="#popupUndismissable" data-rel="popup" data-role="button" data-inline="true">Undismissable Popup</a>
		
			<div data-role="popup" id="popupCloseRight" class="ui-content" style="max-width:280px">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Close</a>
				<p>I have a close button at the top right corner with simple HTML markup.</p>
			</div>
		
			<div data-role="popup" id="popupCloseLeft" class="ui-content" style="max-width:280px">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-left">Close</a>
				<p>I have a close button at the top left corner with simple HTML markup.</p>
			</div>
		
			<div data-role="popup" id="popupUndismissable" class="ui-content" style="max-width:280px" data-dismissable="false">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-left">Close</a>
				<p>I have the <code>data-dismissable</code> attribute set to <code>false</code>. I'm not closeable by clicking outside of me.</p>
			</div>

			<a href="#positionWindow" data-role="button" data-inline="true" data-rel="popup" data-position-to="window">Position to window</a> 
			<a href="#positionOrigin" data-role="button" data-inline="true" data-rel="popup" data-position-to="origin">Position to origin</a>
			<a href="#positionSelector" data-role="button" data-inline="true" data-rel="popup" data-position-to="#codeSample">Position to #codeSample</a>

			<div data-role="popup" id="positionWindow" class="ui-content" data-theme="d">
				<p>I am positioned to the window.</p>
			</div>

			<div data-role="popup" id="positionOrigin" class="ui-content" data-theme="d">
				<p>I am positioned over the origin.</p>
			</div>
		
			<div data-role="popup" id="positionSelector" class="ui-content" data-theme="d">
				<p>I am positioned over the code sample via selector.</p>
			</div>
				
			<a href="#transitionExample" data-transition="none" data-role="button" data-inline="true" data-rel="popup">No transition</a>
			<a href="#transitionExample" data-transition="pop" data-role="button" data-inline="true" data-rel="popup">Pop</a>
			<a href="#transitionExample" data-transition="fade" data-role="button" data-inline="true" data-rel="popup">Fade</a>
			<a href="#transitionExample" data-transition="flip" data-role="button" data-inline="true" data-rel="popup">Flip</a>
			<a href="#transitionExample" data-transition="turn" data-role="button" data-inline="true" data-rel="popup">Turn</a>
			<a href="#transitionExample" data-transition="flow" data-role="button" data-inline="true" data-rel="popup">Flow</a>
			<a href="#transitionExample" data-transition="slide" data-role="button" data-inline="true" data-rel="popup">Slide</a>
			<a href="#transitionExample" data-transition="slidefade" data-role="button" data-inline="true" data-rel="popup">Slidefade</a>
			<a href="#transitionExample" data-transition="slideup" data-role="button" data-inline="true" data-rel="popup">Slide up</a>
			<a href="#transitionExample" data-transition="slidedown" data-role="button" data-inline="true" data-rel="popup">Slide down</a>


			<div data-role="popup" id="transitionExample" class="ui-content" data-theme="d">
				<p>I'm a simple popup.</p>
			</div>
											
			<a href="#theme" data-rel="popup" data-role="button" data-inline="true">Theme A</a>
			<div id="theme" data-role="popup" data-theme="a" class="ui-content">
				<p>I have <code>data-theme="a"</code> set on me</p>
			</div>
		
			<a href="#transparent" data-rel="popup" data-role="button" data-inline="true">Theme "none", no shadow</a>
			<div id="transparent" data-role="popup" data-theme="none" data-shadow="false">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Close</a>
				<img src="../../_assets/images/firefox-logo.png" class="popphoto" alt="firefox logo on a transparent popup">
			</div>

			<a href="#overlay" data-rel="popup" data-role="button" data-inline="true">Overlay theme A</a>
			<div id="overlay" data-role="popup" data-overlay-theme="a" class="ui-content">
				<p>I have a <code>data-overlay-theme="a"</code> set on me</p>
			</div>

			<a href="#both" data-rel="popup" data-role="button" data-inline="true">Theme E + overlay A</a>
			<div id="both" data-role="popup" data-overlay-theme="a" data-theme="e" class="ui-content">
				<p>I have <code>data-theme="e"</code> and <code>data-overlay-theme="a"</code> set on me</p>
			</div>
		
		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
