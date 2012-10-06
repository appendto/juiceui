<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tooltip.aspx.cs" Inherits="WebForms.Tooltip" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
<div id="_Demo" runat="server">
 
	<p><a href="#" title="That's what this widget is">Tooltips</a> can be attached to any element. When you hover
	the element with your mouse, the title attribute is displayed in a little box next to the element, just like a native tooltip.</p>
	<p>But as it's not a native tooltip, it can be styled. Any themes built with
	<a href="http://themeroller.com" title="ThemeRoller: jQuery UI's theme builder application">ThemeRoller</a>
	will also style tooltips accordingly.</p>
	<p>Tooltips are also useful for form elements, to show some additional information in the context of each field.</p>
	<p><label for="age">Your age:</label><input id="age" title="We ask for your age only for statistical purposes." /></p>
	<p>Hover the field to see the tooltip.</p>
 
</div>
<juice:tooltip TargetControlID="_Demo" ID="_Tooltip" runat="server" />
</asp:content>