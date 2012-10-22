<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="toolbars.aspx.cs" Inherits="Mobile.Toolbars" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Toolbars" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">
	


		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
