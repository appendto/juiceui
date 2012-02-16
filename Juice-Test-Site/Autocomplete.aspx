<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autocomplete.aspx.cs" Inherits="Juice_Sample_Site.Autocomplete" masterpagefile="~/Base.Master" %>
<%@ Register Assembly="Juice" Namespace="Juice" TagPrefix="Juice" %>
<asp:content contentplaceholderid="_Content" runat="server">
  <asp:TextBox runat="server" ID="_Autocomplete" />
  
  <Juice:Autocomplete runat="server" TargetControlID="_Autocomplete" Source="ActionScript, AppleScript, Asp, BASIC, C, C++, Clojure, COBOL, ColdFusion, Erlang, Fortran, Groovy, Haskell, Java, JavaScript, Lisp, Perl, PHP, Python, Ruby, Scala, Scheme" /> 
</asp:content>