<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Selectable.aspx.cs" Inherits="Juice_Sample_Site.Selectable" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">

<style>
	#feedback { font-size: 1.4em; }
	ol .ui-selecting { background: #FECA40; }
	ol .ui-selected { background: #F39814; color: white; }
	ol { list-style-type: none; margin: 0; padding: 0; width: 60%; }
	ol li { margin: 3px; padding: 0.4em; font-size: 1.4em; height: 18px; }
</style>

<ol id="_Default" runat="server">
	<li class="ui-widget-content">Item 1</li>
	<li class="ui-widget-content">Item 2</li>
	<li class="ui-widget-content">Item 3</li>
	<li class="ui-widget-content">Item 4</li>
	<li class="ui-widget-content">Item 5</li>
	<li class="ui-widget-content">Item 6</li>
	<li class="ui-widget-content">Item 7</li>
</ol>
<juice:selectable ID="_Selectable" TargetControlID="_Default" runat="server"/>
<asp:button ID="_Button" runat="server" Text="Postback"/>
</asp:content>