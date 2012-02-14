<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datepicker.aspx.cs" Inherits="Juice_Sample_Site.Datepicker" masterpagefile="~/Base.Master" %>
<%@ Register Assembly="Juice" Namespace="Juice" TagPrefix="Juice" %>
<asp:content contentplaceholderid="_Content" runat="server">

  <Juice:Tabs runat="server" ID="TabsDemo">
    <Juice:TabPage Title="Tab 1" ID="Tab1">
      <TabContent>
        <p>This should display on tab 1.</p>
      </TabContent>
    </Juice:TabPage>

    <Juice:TabPage Title="Tab 2" ID="Tab2">
      <TabContent>
        <p>This should display on tab 2.</p>
      </TabContent>
    </Juice:TabPage>
  </Juice:Tabs>

</asp:content>
