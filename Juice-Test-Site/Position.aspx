<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Position.aspx.cs" Inherits="Juice_Sample_Site.Position" %>
<%@ Register Assembly="Juice" Namespace="Juice" TagPrefix="Juice" %>

<asp:Content ID="Content2" ContentPlaceHolderID="_Content" runat="server">
  <asp:TextBox runat="server" ID="TextBox1" />

  <asp:Label runat="server" id="ImportantInfo">Enter important information here.</asp:Label>

  <Juice:Position runat="server" TargetControlID="ImportantInfo" my="left" at="right" Of="TextBox1" />
</asp:Content>
