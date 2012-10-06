<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Spinner.aspx.cs" Inherits="WebForms.Spinner" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">

	<asp:label id="_Label" AssociatedControlId="_Text" Text="ASP.NET Textbox" runat="server" /> 
	<asp:textbox ID="_Text" runat="server" />
	<juice:spinner TargetControlID="_Text" ID="_TextSpinner" runat="server" AutoPostBack="true"/>

	<label for="_Content__Input">Html Input</label>
	<input type="text" id="_Input" runat="server"/>
	<juice:spinner TargetControlID="_Input" ID="_InputSpinner" runat="server"/>

<%--    <script>
    $(function() {
        var spinner = $( "#_Content__Input" ).spinner({
					change: function(){ console.log('change'); }
				});

    });
    </script>--%>

	<asp:button ID="_Button" runat="server" Text="Postback"/>
</asp:content>