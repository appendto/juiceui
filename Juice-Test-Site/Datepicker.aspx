<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datepicker.aspx.cs" Inherits="Juice_Sample_Site.Datepicker" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Head" runat="server">
  <style>
    .ui-datepicker-trigger {
      cursor: pointer;
      margin-left: 4px;
      position: relative;
      top: 3px;
    }
  </style>
</asp:content>
<asp:content contentplaceholderid="_Content" runat="server">
  <asp:TextBox runat="server" ID="DoB" />
  <Juice:Datepicker id="_Datepicker" runat="server" TargetControlID="DoB" DayNames="Domingo,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado" ButtonImage="/images/calendar-icon.png" ButtonImageOnly="true" ShowOn="both" ButtonText="Show date picker" />
	<asp:button ID="_Button" runat="server" Text="Postback"/>
</asp:content>