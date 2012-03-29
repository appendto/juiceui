<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autocomplete.aspx.cs" Inherits="Juice_Sample_Site.Autocomplete" masterpagefile="~/Base.Master" %>
<asp:content contentplaceholderid="_Content" runat="server">
  <asp:TextBox runat="server" ID="_Textbox" />
  
  <Juice:Autocomplete id="_Autocomplete" runat="server" TargetControlID="_Textbox" Source="ActionScript, AppleScript, Asp, BASIC, C, C++, Clojure, COBOL, ColdFusion, Erlang, Fortran, Groovy, Haskell, Java, JavaScript, Lisp, Perl, PHP, Python, Ruby, Scala, Scheme" /> 
	<%--<Juice:Autocomplete id="_Autocomplete" runat="server" TargetControlID="_Textbox" SourceUrl="AutoCompleteData.ashx" /> --%>
	
	<asp:button ID="_Button" runat="server" Text="Postback" />

</asp:content>