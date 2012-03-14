<%@ Page Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="Juice_Sample_Site.Mobile.Page" %>

<asp:Content ContentPlaceHolderID="_Content" runat="server">

	<mobile:page id="mypage" runat="server">
		<mobile:header Text="Page Title" runat="server"/>
		<mobile:content runat="server">
			<p>Page content goes here.</p>
		</mobile:content>
		<mobile:footer Text="Page Footer" runat="server"/>
	</mobile:page>

</asp:Content>
