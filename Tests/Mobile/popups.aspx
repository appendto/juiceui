<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="popups.aspx.cs" Inherits="Mobile.Popups" ClientIDMode="Static" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Popups" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">

			<a id="a1" runat="server" href="#popupBasic">Open Popup</a>
			<a id="a1_1" runat="server" href="#popupTolerance">Open Popup w/ Tolerance</a>
			<a id="a2" runat="server" href="#popupInfo">Tooltip</a>
			<a id="a3" runat="server" href="#popupMenu">Menu</a>
			<a id="a4" runat="server" href="#popupNested">Nested menu</a>
			<a id="a5" runat="server" href="#popupLogin">Form</a>
			<a id="a6" runat="server" href="#popupDialog">Dialog</a>
			<a id="a7" runat="server" href="#popupPhoto">Photo</a>
			<a id="a8" runat="server" href="#popupCloseRight">Popup with close button right</a>
			<a id="a9" runat="server" href="#popupCloseLeft">Popup with close button left</a>
			<a id="a10" runat="server" href="#popupUndismissable">Undismissable Popup</a>
			<a id="a11" runat="server" href="#positionWindow">Position to window</a> 
			<a id="a12" runat="server" href="#positionOrigin">Position to origin</a>
			<a id="a13" runat="server" href="#positionSelector">Position to .ui-header</a>
			<a id="a14" runat="server" href="#transitionExample">No transition</a>
			<a id="a15" runat="server" href="#transitionExample">Pop</a>
			<a id="a16" runat="server" href="#transitionExample">Fade</a>
			<a id="a17" runat="server" href="#transitionExample">Flip</a>
			<a id="a18" runat="server" href="#transitionExample">Turn</a>
			<a id="a19" runat="server" href="#transitionExample">Flow</a>
			<a id="a20" runat="server" href="#transitionExample">Slide</a>
			<a id="a21" runat="server" href="#transitionExample">Slidefade</a>
			<a id="a22" runat="server" href="#transitionExample">Slide up</a>
			<a id="a23" runat="server" href="#transitionExample">Slide down</a>
			<a id="a24" runat="server" href="#theme">Theme A</a>
			<a id="a25" runat="server" href="#transparent">Theme "none", no shadow</a>
			<a id="a26" runat="server" href="#overlay">Overlay theme A</a>
			<a id="a27" runat="server" href="#both">Theme E + overlay A</a>
			
			<mobile:popupanchor TargetControlID="a1" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a1_1" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a2" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a3" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a4" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a5" runat="server" Inline="true" PositionTo="window" />
			<mobile:popupanchor TargetControlID="a6" runat="server" Inline="true" PositionTo="window" Transition="pop" />
			<mobile:popupanchor TargetControlID="a7" runat="server" Inline="true" PositionTo="window" Transition="fade" />
			<mobile:popupanchor TargetControlID="a8" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a9" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a10" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a11" runat="server" Inline="true" PositionTo="window" />
			<mobile:popupanchor TargetControlID="a12" runat="server" Inline="true" PositionTo="origin" />
			<mobile:popupanchor TargetControlID="a13" runat="server" Inline="true" PositionTo=".ui-header" />
			<mobile:popupanchor TargetControlID="a14" runat="server" Inline="true" Transition="none" />
			<mobile:popupanchor TargetControlID="a15" runat="server" Inline="true" Transition="pop" />
			<mobile:popupanchor TargetControlID="a16" runat="server" Inline="true" Transition="fade" />
			<mobile:popupanchor TargetControlID="a17" runat="server" Inline="true" Transition="flip" />
			<mobile:popupanchor TargetControlID="a18" runat="server" Inline="true" Transition="turn" />
			<mobile:popupanchor TargetControlID="a19" runat="server" Inline="true" Transition="flow" />
			<mobile:popupanchor TargetControlID="a20" runat="server" Inline="true" Transition="slide" />
			<mobile:popupanchor TargetControlID="a21" runat="server" Inline="true" Transition="slidefade" />
			<mobile:popupanchor TargetControlID="a22" runat="server" Inline="true" Transition="slideup" />
			<mobile:popupanchor TargetControlID="a23" runat="server" Inline="true" Transition="slidedown" />
			<mobile:popupanchor TargetControlID="a24" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a25" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a26" runat="server" Inline="true" />
			<mobile:popupanchor TargetControlID="a27" runat="server" Inline="true" />

			<!-- popups -->

			<mobile:popup runat="server" id="popupBasic">
				<p>This is a completely basic popup, no options set.</p>
			</mobile:popup>

			<mobile:popup runat="server" id="popupTolerance" Tolerance="60, 30, 60, 30">
				<p>This is a completely basic popup, no options set.</p>
			</mobile:popup>
		
			<mobile:popup runat="server" id="popupInfo" class="ui-content" theme="e" style="max-width:350px;">
				<p>Here is a <strong>tiny popup</strong> being used like a tooltip. The text will wrap to multiple lines as needed.</p>
			</mobile:popup>

			<mobile:popup runat="server" id="popupMenu" theme="a">
				<ul data-role="listview" data-inset="true" style="min-width:210px;" data-theme="b">
					<li data-role="divider" data-theme="a">Popup API</li>
					<li><a href="options.html">Options</a></li>
					<li><a href="methods.html">Methods</a></li>
					<li><a href="events.html">Events</a></li>
				</ul>
			</mobile:popup>

			<mobile:popup runat="server" id="popupNested" theme="none">
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
			</mobile:popup><!-- /popup -->

			<mobile:popup runat="server" id="popupLogin" theme="a" class="ui-corner-all">
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
			</mobile:popup>
		
			<mobile:popup runat="server" id="popupDialog" overlaytheme="a" theme="c" style="max-width:400px;" class="ui-corner-all">
				<div data-role="header" data-theme="a" class="ui-corner-top">
					<h1>Delete Page?</h1>
				</div>
				<div data-role="content" data-theme="d" class="ui-corner-bottom ui-content">
					<h3 class="ui-title">Are you sure you want to delete this page?</h3>
					<p>This action cannot be undone.</p>
					<a href="#" data-role="button" data-inline="true" data-rel="back" data-theme="c">Cancel</a>    
					<a href="#" data-role="button" data-inline="true" data-rel="back" data-transition="flow" data-theme="b">Delete</a>  
				</div>
			</mobile:popup>

			<mobile:popup runat="server" id="popupPhoto" overlaytheme="a" theme="d" corners="false">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Close</a><img class="popphoto" src="../../_assets/images/colorful-city.jpg" alt="Colorful city">
			</mobile:popup>
		
			<mobile:popup runat="server" id="popupCloseRight" class="ui-content" style="max-width:280px">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Close</a>
				<p>I have a close button at the top right corner with simple HTML markup.</p>
			</mobile:popup>
		
			<mobile:popup runat="server" id="popupCloseLeft" class="ui-content" style="max-width:280px">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-left">Close</a>
				<p>I have a close button at the top left corner with simple HTML markup.</p>
			</mobile:popup>
		
			<mobile:popup runat="server" id="popupUndismissable" class="ui-content" style="max-width:280px" dismissable="false">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-left">Close</a>
				<p>I have the <code>data-dismissable</code> attribute set to <code>false</code>. I'm not closeable by clicking outside of me.</p>
			</mobile:popup>

			<mobile:popup runat="server" id="positionWindow" class="ui-content" theme="d">
				<p>I am positioned to the window.</p>
			</mobile:popup>

			<mobile:popup runat="server" id="positionOrigin" class="ui-content" theme="d">
				<p>I am positioned over the origin.</p>
			</mobile:popup>
		
			<mobile:popup runat="server" id="positionSelector" class="ui-content" theme="d">
				<p>I am positioned over the header via selector.</p>
			</mobile:popup>

			<mobile:popup runat="server" id="transitionExample" class="ui-content" theme="d">
				<p>I'm a simple popup.</p>
			</mobile:popup>

			<mobile:popup runat="server" id="theme" theme="a" class="ui-content">
				<p>I have <code>data-theme="a"</code> set on me</p>
			</mobile:popup>
			
			<mobile:popup runat="server" id="transparent" theme="none" shadow="false">
				<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Close</a>
				<img src="../../_assets/images/firefox-logo.png" class="popphoto" alt="firefox logo on a transparent popup">
			</mobile:popup>
			
			<mobile:popup runat="server" id="overlay" overlaytheme="a" class="ui-content">
				<p>I have a <code>data-overlay-theme="a"</code> set on me</p>
			</mobile:popup>
			
			<mobile:popup runat="server" id="both" overlaytheme="a" theme="e" class="ui-content">
				<p>I have <code>data-theme="e"</code> and <code>data-overlay-theme="a"</code> set on me</p>
			</mobile:popup>
		
		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
