<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="WebForms.UpdatePanel" MasterPageFile="~/Base.Master" %>
<asp:Content ContentPlaceHolderID="_Content" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Wizard runat="server">
                <WizardSteps>
                    <asp:WizardStep>
                        <asp:Label runat="server" AssociatedControlID="FirstName">First Name</asp:Label>
                        <asp:TextBox runat="server" ID="FirstName" />
                        <asp:Label runat="server" AssociatedControlID="LastName">Last Name</asp:Label>
                        <asp:TextBox runat="server" ID="LastName" />
                    </asp:WizardStep>
                    <asp:WizardStep>
                        <asp:Label runat="server" AssociatedControlID="Age">Age</asp:Label>
                        <Juice:Slider runat="server" ID="Age" Max="123" />
                    </asp:WizardStep>
                    <asp:WizardStep OnActivate="FinalStep_Activated">
                        <asp:Literal runat="server" ID="PersistedMinValue" />
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
