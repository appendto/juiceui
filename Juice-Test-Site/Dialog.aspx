<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dialog.aspx.cs" Inherits="Juice_Sample_Site.Dialog" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
<div id="_Default" title="Basic dialog" runat="server">
	<p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
</div>
<juice:dialog TargetControlID="_Default" runat="server" />
</asp:content>