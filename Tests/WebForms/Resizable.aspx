<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resizable.aspx.cs" Inherits="WebForms.Resizable" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Head" runat="server">
<style>
	.demo { width: 200px; height: 200px; border: 1px dotted black; }
</style>
</asp:content>
<asp:content contentplaceholderid="_Content" runat="server">
  <asp:Panel runat="server" ID="ResizeMe" cssclass="demo" />
  <Juice:Resizable id="_Extender" runat="server" TargetControlID="ResizeMe" MaxHeight="300"  />
	<asp:button ID="_Button" runat="server" Text="Postback"/>
</asp:content>