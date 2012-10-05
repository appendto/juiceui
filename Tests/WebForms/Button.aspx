<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Button.aspx.cs" Inherits="Juice_Sample_Site.Button" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
  <a runat="server" href="http://google.com" ID="_Button">Oh Hai</a>
  <Juice:Button runat="server" TargetControlID="_Button" ID="_JuiceButton" />

	<div id="_Buttonset" runat="server">
		<input type="radio" id="radio1" name="radio" /><label for="radio1">Choice 1</label>
		<input type="radio" id="radio2" name="radio" checked="checked" /><label for="radio2">Choice 2</label>
		<input type="radio" id="radio3" name="radio" /><label for="radio3">Choice 3</label>
	</div>
	<Juice:Buttonset runat="server" TargetControlID="_Buttonset" />
	<asp:button ID="_Postback" runat="server" Text="Postback"/>

	<button id="mBtnPrevious" runat="server" onserverclick="BtnPreviousClick">Previous</button>
	<%--<juice:Button TargetControlID="mBtnPrevious" runat="server" />--%>
</asp:content>