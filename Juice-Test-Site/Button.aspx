<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Button.aspx.cs" Inherits="Juice_Sample_Site.Button" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
  <a runat="server" href="http://google.com" ID="_Button">Oh Hai</a>
  
  <Juice:Button runat="server" TargetControlID="_Button" />
</asp:content>