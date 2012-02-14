<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Progressbar.aspx.cs" Inherits="Juice_Sample_Site.Progressbar" masterpagefile="~/Base.Master" %>
<%@ Register Assembly="Juice" Namespace="Juice" TagPrefix="Juice" %>
<asp:content contentplaceholderid="_Content" runat="server">
	<Juice:Progressbar id="progress" runat="server" Value="42" Disabled="false" />
</asp:content>