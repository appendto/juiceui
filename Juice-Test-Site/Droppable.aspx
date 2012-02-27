<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Droppable.aspx.cs" Inherits="Juice_Sample_Site.Droppable" %>
<asp:Content ID="Content2" ContentPlaceHolderID="_Content" runat="server">

	<style>
		.draggable { width: 100px; height: 100px; padding: 0.5em; float: left; margin: 10px 10px 10px 0; }
		.droppable { width: 150px; height: 150px; padding: 0.5em; float: left; margin: 10px; }
	</style>

	<script>
		$(function(){
			$( "#_Default" ).droppable( "option", "drop", function( event, ui ) {
				$( this )
					.addClass( "ui-state-highlight" )
					.find( "p" )
						.html( "Dropped!" );
				}
			);
		});
	</script>

	<asp:panel ID="_Draggable" CssClass="draggable ui-widget-content" runat="server">
		<p>Drag me to my target</p>
	</asp:panel>
	<juice:draggable TargetControlID="_Draggable" runat="server"/>

	<asp:panel ID="_Default" CssClass="droppable ui-widget-header" runat="server" ClientIDMode="Static">
		<p>Drop here</p>
	</asp:panel>
	<juice:droppable TargetControlID="_Default" runat="server"/>

</asp:Content>
