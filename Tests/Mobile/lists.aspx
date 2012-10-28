<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="lists.aspx.cs" Inherits="Mobile.Lists" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Listviews" runat="server">
			<a href="/" data-icon="home" data-iconpos="notext" data-direction="reverse">Home</a>
		</mobile:header>

		<mobile:content runat="server">

			<h2>Simple list</h2>
			<mobile:listview runat="server">
				<mobile:listviewitem runat="server"><a href="#">Acura</a></mobile:listviewitem>
				<li><a href="#">Audi</a></li>
				<li><a href="#">BMW</a></li>
				<li><a href="#">Cadillac</a></li>
				<li><a href="#">Ferrari</a></li>
			</mobile:listview>

			<h2>Count bubbles</h2>
			<mobile:listview runat="server">
				<li><a href="#">Inbox <span class="ui-li-count">12</span></a></li>
				<li><a href="#">Outbox <span class="ui-li-count">0</span></a></li>
				<li><a href="#">Drafts <span class="ui-li-count">4</span></a></li>
				<li><a href="#">Sent <span class="ui-li-count">328</span></a></li>
				<li><a href="#">Trash <span class="ui-li-count">62</span></a></li>
			</mobile:listview>
		
			<h2>Numbered list</h2>
			<mobile:listview runat="server" NumberedList="true">
				<li><a href="#">The Godfather</a></li>
				<li><a href="#">Inception</a></li>
				<li><a href="#">The Good, the Bad and the Ugly </a></li>
				<li><a href="#">Pulp Fiction</a></li>
				<li><a href="#">Schindler's List</a></li>
			</mobile:listview>
			
			<h2>Divided, formatted content</h2>
			<mobile:listview runat="server">
				<li>
					<a href="#">
						<h3>Stephen Weber</h3>
						<p><strong>You've been invited to a meeting at Filament Group in Boston, MA</strong></p>
						<p>Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
						<p class="ui-li-aside"><strong>6:24</strong>PM</p>
					</a>
				</li>
				<li>
					<a href="#">
						<h3>jQuery Team</h3>
						<p><strong>Boston Conference Planning</strong></p>
						<p>In preparation for the upcoming conference in Boston, we need to start gathering a list of sponsors and speakers.</p>
						<p class="ui-li-aside"><strong>9:18</strong>AM</p>
					</a>
				</li>
			</mobile:listview>
		
			<h2>Icon list</h2>
			<mobile:listview runat="server">
				<li><a href="#"><img src="images/gf.png" alt="France" class="ui-li-icon">France <span class="ui-li-count">4</span></a></li>
				<li><a href="#"><img src="images/de.png" alt="Germany" class="ui-li-icon">Germany <span class="ui-li-count">4</span></a></li>
				<li><a href="#"><img src="images/gb.png" alt="Great Britain" class="ui-li-icon">Great Britain <span class="ui-li-count">0</span></a></li>
				<li><a href="#"><img src="images/fi.png" alt="Finland" class="ui-li-icon">Finland <span class="ui-li-count">12</span></a></li>
				<li><a href="#"><img src="images/sj.png" alt="Norway" class="ui-li-icon">Norway <span class="ui-li-count">328</span></a></li>
				<li><a href="#"><img src="images/us.png" alt="United States" class="ui-li-icon">United States <span class="ui-li-count">62</span></a></li>
			</mobile:listview>
		
			<h2>Thumbnail, split button list</h2>
			<mobile:listview runat="server">
				<li>
					<a href="#">
						<img src="images/album-bb.jpg" />
						<h3>Broken Bells</h3>
						<p>Broken Bells</p>
					</a>
					<a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album</a>
				</li>
				<li>
					<a href="#">
						<img src="images/album-hc.jpg" />
						<h3>Warning</h3>
						<p>Hot Chip</p>
					</a>
					<a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album</a>
				</li>
				<li>
					<a href="#">
						<img src="images/album-p.jpg" />
						<h3>Wolfgang Amadeus Phoenix</h3>
						<p>Phoenix</p>
					</a>
					<a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album</a>
				</li>
			</mobile:listview>
			
			<h2>Divided, filterable list</h2>
			<mobile:listview runat="server" Filter="true" style="margin-bottom:2em;">
				<li data-role="list-divider">A</li>
				<li><a href="#">Adam Kinkaid</a></li>
				<li><a href="#">Alex Wickerham</a></li>
				<li><a href="#">Avery Johnson</a></li>
				<mobile:listviewitem runat="server" Divider="true">B</mobile:listviewitem>
				<li><a href="#">Bob Cabot</a></li>
				<li data-role="list-divider">C</li>
				<li><a href="#">Caleb Booth</a></li>
				<li><a href="#">Christopher Adams</a></li>
			</mobile:listview>

		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
