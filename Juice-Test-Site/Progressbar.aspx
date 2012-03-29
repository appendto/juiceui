<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Progressbar.aspx.cs" Inherits="Juice_Sample_Site.Progressbar" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
	<div style="height: 400px">
		<div id="_Wrapper" runat="server" style="height:30px;" class="ui-widget-default">
			<juice:progressbar ID="_Resizable" runat="server" Value="37" style="height: 100%;" />
		</div>
		<juice:resizable TargetControlID="_Wrapper" runat="server" />
		<asp:button ID="_Button" runat="server" Text="Postback"/>
	</div>
</asp:content>