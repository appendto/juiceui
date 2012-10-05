<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accordion.aspx.cs" Inherits="Juice_Sample_Site.Accordion" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">

  <Juice:Accordion ID="_Accordion" runat="server">
    <Juice:AccordionPanel Title="Panel 1">
      <PanelContent>
        Panel 1's content.
				<asp:TextBox runat="server" ID="dob1" ClientIDMode="Static" />
				<juice:Datepicker runat="server" TargetControlID="dob1" />
      </PanelContent>
    </Juice:AccordionPanel>

    <Juice:AccordionPanel Title="Panel 2">
      <PanelContent>
        Panel 2's content.
      </PanelContent>
    </Juice:AccordionPanel>
  </Juice:Accordion>

	<asp:button ID="_Postback" runat="server" Text="Postback"/>

</asp:content>