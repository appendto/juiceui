<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Progressbar.aspx.cs" Inherits="Juice_Sample_Site.Progressbar" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
	<Juice:Progressbar id="progress" runat="server" Value="42" Disabled="false" />

	<juice:progressbar ID="_Resizable" runat="server" Value="37" />
	<juice:resizable TargetControlID="_Resizable" runat="server" />
</asp:content>