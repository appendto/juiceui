<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dialog.aspx.cs" Inherits="WebForms.Dialog" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
<div id="_Default" title="Basic dialog" runat="server">
	<p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
	<asp:textbox ID="_Test" runat="server"/>
</div>
<juice:dialog ID="_Dialog" Height="300px" TargetControlID="_Default" runat="server" Buttons="{ Ok: function() { $(this).dialog('close');}}" AutoOpen="false" />
<a href="#" id="opensesame">Open</a>
<asp:button ID="_Button" runat="server" Text="Postback" />


<script type="text/javascript">
 // Respond to the click 
 $("#opensesame").click(function (e) {
     e.preventDefault();
     // Open the dialog 
     $("#_Content__Default").dialog("open");
 }); 
</script>

</asp:content>