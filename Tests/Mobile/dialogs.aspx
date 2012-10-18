<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="dialogs.aspx.cs" Inherits="Mobile.Dialogs" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">


<div data-role="page" class="type-interior">

	<div data-role="header">
		<h1>Dialogs</h1>
		<a href="/" data-icon="home" data-iconpos="notext" data-direction="reverse">Home</a>
	</div><!-- /header -->

	<div data-role="content" class="ui-body">
		<div class="content-primary">
			
			<h2>Dialog</h2>
	
			<a href="data/dialog.html" data-role="button" data-inline="true" data-rel="dialog" data-transition="pop">Open dialog</a>

			<div>
				<a href="data/dialog.html" data-role="button" data-inline="true" data-rel="dialog" data-transition="pop">data-transition="pop"</a>
				<a href="data/dialog.html" data-role="button" data-inline="true" data-rel="dialog" data-transition="slidedown">data-transition="slidedown"</a>
				<a href="data/dialog.html" data-role="button" data-inline="true" data-rel="dialog" data-transition="flip">data-transition="flip"</a>
			</div>

			<a href="data/dialog-alt.html" data-role="button" data-inline="true" data-rel="dialog" data-transition="pop">An alternate color scheme</a>
			<a href="data/dialog-overlay.html" data-role="button" data-inline="true" data-rel="dialog" data-transition="pop">Custom overlay swatch</a>
			<a href="data/dialog-buttons.html" data-role="button" data-inline="true" data-rel="dialog" data-transition="slidedown">Share photos...</a>

		</div><!--/content-primary -->		
	</div><!-- /content -->

	<div data-role="footer" class="footer-docs" data-theme="c">
			<p class="jqm-version"></p>
			<p>&copy; 2012 jQuery Foundation and other contributors</p>
	</div>

</div><!-- /page -->


</asp:Content>
