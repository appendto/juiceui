<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accordion.aspx.cs" Inherits="Juice_Sample_Site.Accordion" %>
<%@ Register Assembly="Juice" Namespace="Juice" TagPrefix="Juice" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" />
    
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
    </form>
</body>
</html>
