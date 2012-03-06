<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tabs.aspx.cs" Inherits="Juice_Sample_Site.Tabs" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">

<%--	<asp:repeater id="_test" runat="server">
	<itemtemplate>
		<asp:TextBox runat="server" ID="dob1" />
		<juice:Datepicker runat="server" TargetControlID="dob1" />
	</itemtemplate>
	</asp:repeater>--%>

  <Juice:Tabs runat="server" ID="TabsDemo">
    <Juice:TabPage Title="Tab 1" ID="Tab1">
			<TabContent>
				<asp:TextBox runat="server" ID="dob1" ClientIDMode="Static" />
				<juice:Datepicker runat="server" TargetControlID="dob1" />
      </TabContent>
    </Juice:TabPage>

    <Juice:TabPage Title="Tab 2" ID="Tab2">
      <TabContent>
        <p>This should display on tab 2.</p>
      </TabContent>
    </Juice:TabPage>
  </Juice:Tabs>

</asp:content>
