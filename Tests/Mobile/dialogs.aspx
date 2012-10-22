<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="dialogs.aspx.cs" Inherits="Mobile.Dialogs" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Dialogs" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">

			<h2>Dialog</h2>
	
			<a id="open" runat="server" href="data/dialog.html" data-rel="dialog">Open dialog</a>
			<mobile:button TargetControlID="open" runat="server" inline="true" />
			<mobile:dialog TargetControlID="open" runat="server" Transition="Pop" />

			<div>
				<a id="pop" runat="server" href="data/dialog.html" data-rel="dialog">data-transition="pop"</a>
				<mobile:button TargetControlID="pop" runat="server" inline="true" />
				<mobile:dialog TargetControlID="pop" runat="server" Transition="Pop" />

				<a id="slide" runat="server" href="data/dialog.html" data-rel="dialog">data-transition="slidedown"</a>
				<mobile:button TargetControlID="slide" runat="server" inline="true" />
				<mobile:dialog TargetControlID="slide" runat="server" Transition="Slidedown" />

				<a id="flip" runat="server" href="data/dialog.html" data-rel="dialog">data-transition="flip"</a>
				<mobile:button TargetControlID="flip" runat="server" inline="true" />
				<mobile:dialog TargetControlID="flip" runat="server" Transition="Flip" />

			</div>

			<a id="altcolor" runat="server" href="data/dialog-alt.html" data-rel="dialog">An alternate color scheme</a>
			<mobile:button TargetControlID="altcolor" runat="server" inline="true" />
			<mobile:dialog TargetControlID="altcolor" runat="server" Transition="Pop" />

			<a id="custom" runat="server" href="data/dialog-overlay.html" data-rel="dialog">Custom overlay swatch</a>
			<mobile:button TargetControlID="custom" runat="server" inline="true" />
			<mobile:dialog TargetControlID="custom" runat="server" Transition="Pop" />

			<a id="share" runat="server" href="data/dialog-buttons.html" data-rel="dialog">Share photos...</a>
			<mobile:button TargetControlID="share" runat="server" inline="true" />
			<mobile:dialog TargetControlID="share" runat="server" Transition="Slidedown" />

		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>


</asp:Content>
