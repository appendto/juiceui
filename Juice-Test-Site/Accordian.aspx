<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datepicker.aspx.cs" Inherits="Juice_Sample_Site.Datepicker" masterpagefile="~/Base.Master" %>
<%@ Register Assembly="Juice" Namespace="Juice" TagPrefix="Juice" %>
<asp:content contentplaceholderid="_Content" runat="server">

  <Juice:Accordion runat="server">
    <Juice:AccordionPanel Title="Panel 1">
      <PanelContent>
        Panel 1's content.
      </PanelContent>
    </Juice:AccordionPanel>

    <Juice:AccordionPanel Title="Panel 2">
      <PanelContent>
        Panel 2's content.
      </PanelContent>
    </Juice:AccordionPanel>
  </Juice:Accordion>

</asp:content>