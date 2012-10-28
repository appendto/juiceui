<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="navbars.aspx.cs" Inherits="Mobile.Navbars" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Navbars" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">
				
			<mobile:navbar runat="server">
				<mobile:navbaritem runat="server"><a href="#" class="ui-btn-active">One</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Two</a></mobile:navbaritem>
			</mobile:navbar>
					
			<mobile:navbar runat="server">
				<mobile:navbaritem runat="server"><a href="#" class="ui-btn-active">One</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Two</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Three</a></mobile:navbaritem>
			</mobile:navbar>
					
			<mobile:navbar runat="server" Grid="c">
				<mobile:navbaritem runat="server"><a href="#" class="ui-btn-active">One</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Two</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Three</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Four</a></mobile:navbaritem>
			</mobile:navbar>

			<mobile:navbar runat="server" Grid="d">
				<mobile:navbaritem runat="server"><a href="#" class="ui-btn-active">One</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Two</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Three</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Four</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Five</a></mobile:navbaritem>
			</mobile:navbar>

			<mobile:navbar runat="server">
				<mobile:navbaritem runat="server"><a href="#" class="ui-btn-active">One</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Two</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Three</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Four</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Five</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Six</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Seven</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Eight</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Nine</a></mobile:navbaritem>
				<mobile:navbaritem runat="server"><a href="#">Ten</a></mobile:navbaritem>
			</mobile:navbar>
	
			<mobile:navbar runat="server">
				<mobile:navbaritem runat="server"><a href="#" class="ui-btn-active">One</a></mobile:navbaritem>
			</mobile:navbar>
	
			<mobile:header Text="I'm a header" runat="server">
				<a href="index.html" data-icon="gear" class="ui-btn-right">Options</a>
				
				<mobile:navbar runat="server">
					<mobile:navbaritem runat="server"><a href="#">One</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#">Two</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#">Three</a></mobile:navbaritem>
				</mobile:navbar>
			</mobile:header>
	
			<mobile:footer runat="server">		
				<mobile:navbar runat="server">
					<mobile:navbaritem runat="server"><a href="#">One</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#">Two</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#">Three</a></mobile:navbaritem>
				</mobile:navbar>
			</mobile:footer>
	
			<mobile:footer runat="server">
				<mobile:navbar runat="server">
					<mobile:navbaritem runat="server"><a href="#" data-icon="grid">Summary</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="star" class="ui-btn-active">Favs</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="gear">Setup</a></mobile:navbaritem>
				</mobile:navbar>
			</mobile:footer>
	
			<mobile:footer runat="server">
				<mobile:navbar runat="server" IconPosition="bottom">
					<mobile:navbaritem runat="server"><a href="#" data-icon="grid">Summary</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="star" class="ui-btn-active">Favs</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="gear">Setup</a></mobile:navbaritem>
				</mobile:navbar>
			</mobile:footer>
	
			<mobile:footer runat="server">
				<mobile:navbar runat="server" IconPosition="left">
					<mobile:navbaritem runat="server"><a href="#" data-icon="grid">Summary</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="star" class="ui-btn-active">Favs</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="gear">Setup</a></mobile:navbaritem>
				</mobile:navbar>
			</mobile:footer>
	
				
			<mobile:footer runat="server">
				<mobile:navbar runat="server" IconPosition="right">
					<mobile:navbaritem runat="server"><a href="#" data-icon="grid">Summary</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="star" class="ui-btn-active">Favs</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="gear">Setup</a></mobile:navbaritem>
				</mobile:navbar>
			</mobile:footer>
	
			<mobile:footer runat="server">
				<mobile:navbar runat="server">
					<mobile:navbaritem runat="server"><a href="#" data-icon="grid"data-theme="a">A</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="star" data-theme="b">B</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="gear" data-theme="c">C</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="arrow-l" data-theme="d">D</a></mobile:navbaritem>
					<mobile:navbaritem runat="server"><a href="#" data-icon="arrow-r" data-theme="e">E</a></mobile:navbaritem>
				</mobile:navbar>
			</mobile:footer>

		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
