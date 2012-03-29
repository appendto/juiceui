<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioButton.aspx.cs" Inherits="Juice_Sample_Site.RadioButton" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">

	<asp:checkbox ID="_Check" runat="server" Text="Llamas"/>
	<asp:radiobutton ID="_Radio" runat="server" Text="Llamas"/>
	<asp:button ID="_Button" runat="server" Text="Postback"/>

</asp:content>