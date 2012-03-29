<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sortable.aspx.cs" Inherits="Juice_Sample_Site.Sortable" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">

<style>
	ul { list-style-type: none; margin: 0; padding: 0; width: 60%; }
	li { margin: 0 3px 3px 3px; padding: 0.4em; padding-left: 1.5em; font-size: 1.4em; height: 18px; }
	li span { position: absolute; margin-left: -1.3em; }
</style>

<ul id="_Default" runat="server">
	<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 1</li>
	<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 2</li>
	<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 3</li>
	<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 4</li>
	<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 5</li>
	<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 6</li>
	<li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 7</li>
</ul>
<juice:sortable id="_Sortable" TargetControlID="_Default" runat="server" />
<asp:button ID="_Button" runat="server" Text="Postback"/>
</asp:content>