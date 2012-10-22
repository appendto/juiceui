<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="buttons.aspx.cs" Inherits="Mobile.Buttons" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Buttons" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">
	
			<a id="b1" runat="server" href="#">Link button</a>
			<mobile:button targetcontrolid="b1" runat="server" />

			<div id="b2" runat="server">Button</div>
			<mobile:button targetcontrolid="b2" runat="server" theme="c" icon="refresh" IconPosition="notext"/>

			<h2>Grouped</h2>

			<mobile:controlgroup runat="server">
				<a id="b3" runat="server" href="#">Yes</a>
				<mobile:button targetcontrolid="b3" runat="server" />

				<a id="b4" runat="server" href="#">No</a>
				<mobile:button targetcontrolid="b4" runat="server" />

				<a id="b5" runat="server" href="#">Maybe</a>
				<mobile:button targetcontrolid="b5" runat="server" />
			</mobile:controlgroup>

			<mobile:controlgroup runat="server" GroupType="horizontal">
				<a id="b6" runat="server" href="#">Yes</a>
				<mobile:button targetcontrolid="b6" runat="server" />

				<a id="b7" runat="server" href="#">No</a>
				<mobile:button targetcontrolid="b7" runat="server" />

				<a id="b8" runat="server" href="#">Maybe</a>
				<mobile:button targetcontrolid="b8" runat="server" />
			</mobile:controlgroup>

			<h2>Icons</h2>

			<a id="b9" runat="server" href="#">Delete</a>
			<mobile:button targetcontrolid="b9" runat="server" icon="delete" />

			<mobile:controlgroup runat="server" GroupType="horizontal">
				<a id="b10" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b10" runat="server" inline="true" theme="a" IconPosition="notext" icon="ArrowLeft" />

				<a id="b11" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b11" runat="server" inline="true" theme="a" IconPosition="notext" icon="ArrowRight" />

				<a id="b12" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b12" runat="server" inline="true" theme="a" IconPosition="notext" icon="ArrowUp" />
				
				<a id="b13" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b13" runat="server" inline="true" theme="a" IconPosition="notext" icon="ArrowDown" />
				
				<a id="b14" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b14" runat="server" inline="true" theme="a" IconPosition="notext" icon="delete" />
				
				<a id="b15" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b15" runat="server" inline="true" theme="a" IconPosition="notext" icon="plus" />
				
				<a id="b16" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b16" runat="server" inline="true" theme="a" IconPosition="notext" icon="minus" />
				
				<a id="b17" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b17" runat="server" inline="true" theme="a" IconPosition="notext" icon="check" />
				
				<a id="b18" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b18" runat="server" inline="true" theme="a" IconPosition="notext" icon="gear" />
			</mobile:controlgroup>
			
			<mobile:controlgroup runat="server" GroupType="horizontal">
				<a id="b19" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b19" runat="server" inline="true" theme="a" IconPosition="notext" icon="refresh" />

				<a id="b20" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b20" runat="server" inline="true" theme="a" IconPosition="notext" icon="forward" />

				<a id="b21" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b21" runat="server" inline="true" theme="a" IconPosition="notext" icon="back" />

				<a id="b22" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b22" runat="server" inline="true" theme="a" IconPosition="notext" icon="grid" />

				<a id="b23" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b23" runat="server" inline="true" theme="a" IconPosition="notext" icon="star" />

				<a id="b24" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b24" runat="server" inline="true" theme="a" IconPosition="notext" icon="alert" />

				<a id="b25" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b25" runat="server" inline="true" theme="a" IconPosition="notext" icon="info" />

				<a id="b26" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b26" runat="server" inline="true" theme="a" IconPosition="notext" icon="home" />

				<a id="b27" runat="server" href="#">My button</a>
				<mobile:button targetcontrolid="b27" runat="server" inline="true" theme="a" IconPosition="notext" icon="search" />
			</mobile:controlgroup>

			<h2>Inline</h2>

			<a id="b28" runat="server" href="#">Cancel</a>
			<mobile:button targetcontrolid="b28" runat="server" inline="true" />

			<a id="b29" runat="server" href="#">Save</a>	
			<mobile:button targetcontrolid="b29" runat="server" inline="true" theme="b"/>

		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>
	
</asp:Content>
