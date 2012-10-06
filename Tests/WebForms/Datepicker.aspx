<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datepicker.aspx.cs" Inherits="WebForms.Datepicker" masterpagefile="~/Base.Master" %>
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
  <asp:TextBox ID="txt_DueDate" Type="date" MaxLength="50" CssClass="requiredField" Width="75" runat="server" />
	<Juice:Datepicker ID="dp_DueDate" TargetControlID="txt_DueDate" ButtonImage="/images/calendar-icon.png" DateFormat="dd/mm/yy" ButtonImageOnly="true" ShowOn="both" ButtonText="Select date" runat="server" />
	<asp:button ID="_Button" runat="server" Text="Postback"/>

</asp:content>