<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="collapsables.aspx.cs" Inherits="Mobile.Collapsables" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Collapsables" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>

		<mobile:content runat="server">

			<h2>Inset, individual collapsible</h2>

			<div data-role="collapsible" data-theme="b" data-content-theme="c">
				<h2>Choose a car model...</h2>
				<ul data-role="listview">
					<li><a href="index.html">Acura</a></li>
					<li><a href="index.html">Audi</a></li>
					<li><a href="index.html">BMW</a></li>
					<li><a href="index.html">Cadillac</a></li>
					<li><a href="index.html">Chrysler</a></li>
					<li><a href="index.html">Dodge</a></li>
					<li><a href="index.html">Ferrari</a></li>
					<li><a href="index.html">Ford</a></li>
					<li><a href="index.html">GMC</a></li>
					<li><a href="index.html">Honda</a></li>
					<li><a href="index.html">Hyundai</a></li>
					<li><a href="index.html">Infiniti</a></li>
					<li><a href="index.html">Jeep</a></li>
					<li><a href="index.html">Kia</a></li>
					<li><a href="index.html">Lexus</a></li>
					<li><a href="index.html">Mini</a></li>
					<li><a href="index.html">Nissan</a></li>
					<li><a href="index.html">Porsche</a></li>
					<li><a href="index.html">Subaru</a></li>
					<li><a href="index.html">Toyota</a></li>
					<li><a href="index.html">Volkswagon</a></li>
					<li><a href="index.html">Volvo</a></li>
				</ul>
			</div>
			
			<h2>Inset, collapsible set</h2>

			<mobile:collapsibleset runat="server" theme="b" contenttheme="d">

				<div data-role="collapsible">
					<h2>Filtered list</h2>
					<ul data-role="listview" data-filter="true" data-filter-theme="c" data-divider-theme="d">
						<li><a href="index.html">Adam Kinkaid</a></li>
						<li><a href="index.html">Alex Wickerham</a></li>
						<li><a href="index.html">Avery Johnson</a></li>
						<li><a href="index.html">Bob Cabot</a></li>
						<li><a href="index.html">Caleb Booth</a></li>
					</ul>
				</div>

				<div data-role="collapsible">
					<h2>Formatted text</h2>
					<ul data-role="listview" data-theme="d" data-divider-theme="d">
						<li data-role="list-divider">Friday, October 8, 2010 <span class="ui-li-count">2</span></li>
						<li><a href="index.html">
							<h3>Stephen Weber</h3>
							<p><strong>You've been invited to a meeting at Filament Group in Boston, MA</strong></p>
							<p>Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
							<p class="ui-li-aside"><strong>6:24</strong>PM</p>
						</a></li>
						<li><a href="index.html">
							<h3>jQuery Team</h3>
							<p><strong>Boston Conference Planning</strong></p>
							<p>In preparation for the upcoming conference in Boston, we need to start gathering a list of sponsors and speakers.</p>
							<p class="ui-li-aside"><strong>9:18</strong>AM</p>
						</a></li>
					</ul>
				</div>

				<div data-role="collapsible">
					<h2>Thumbnails and split button</h2>
					<ul data-role="listview" data-split-icon="gear" data-split-theme="d">
						<li><a href="index.html">
							<img src="images/album-bb.jpg" />
							<h3>Broken Bells</h3>
							<p>Broken Bells</p>
							</a><a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album
						</a></li>
						<li><a href="index.html">
							<img src="images/album-hc.jpg" />
							<h3>Warning</h3>
							<p>Hot Chip</p>
						</a><a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album
						</a></li>
						<li><a href="index.html">
							<img src="images/album-p.jpg" />
							<h3>Wolfgang Amadeus Phoenix</h3>
							<p>Phoenix</p>
							</a><a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album
						</a></li>	
					</ul>
				</div>

			</mobile:collapsibleset>
			
			<h2>Non-inset, collapsible set</h2>

			<mobile:collapsibleset runat="server" theme="b" contenttheme="d" inset="false">
				
				<div data-role="collapsible">
					<h2>Mailbox</h2>
					<ul data-role="listview">
						<li><a href="index.html">Inbox <span class="ui-li-count">12</span></a></li>
						<li><a href="index.html">Outbox <span class="ui-li-count">0</span></a></li>
						<li><a href="index.html">Drafts <span class="ui-li-count">4</span></a></li>
						<li><a href="index.html">Sent <span class="ui-li-count">328</span></a></li>
						<li><a href="index.html">Trash <span class="ui-li-count">62</span></a></li>
					</ul>
				</div>

				<div data-role="collapsible">
					<h2>Calendar</h2>
					<ul data-role="listview" data-theme="d" data-divider-theme="d">
						<li data-role="list-divider">Friday, October 8, 2010 <span class="ui-li-count">2</span></li>
						<li><a href="index.html">
								<h3>Stephen Weber</h3>
								<p><strong>You've been invited to a meeting at Filament Group in Boston, MA</strong></p>
								<p>Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
								<p class="ui-li-aside"><strong>6:24</strong>PM</p>
						</a></li>
						<li><a href="index.html">
							<h3>jQuery Team</h3>
							<p><strong>Boston Conference Planning</strong></p>
							<p>In preparation for the upcoming conference in Boston, we need to start gathering a list of sponsors and speakers.</p>
							<p class="ui-li-aside"><strong>9:18</strong>AM</p>
						</a></li>
						<li data-role="list-divider">Thursday, October 7, 2010 <span class="ui-li-count">1</span></li>
						<li><a href="index.html">
							<h3>Avery Walker</h3>
							<p><strong>Re: Dinner Tonight</strong></p>
							<p>Sure, let's plan on meeting at Highland Kitchen at 8:00 tonight. Can't wait! </p>
							<p class="ui-li-aside"><strong>4:48</strong>PM</p>
						</a></li>
						<li data-role="list-divider">Wednesday, October 6, 2010 <span class="ui-li-count">3</span></li>
						<li><a href="index.html">
							<h3>Amazon.com</h3>
							<p><strong>4-for-3 Books for Kids</strong></p>
							<p>As someone who has purchased children's books from our 4-for-3 Store, you may be interested in these featured books.</p>
							<p class="ui-li-aside"><strong>12:47</strong>PM</p>
						</a></li>
					</ul>
				</div>

				<div data-role="collapsible">
					<h2>Contacts</h2>
					<ul data-role="listview" data-autodividers="true" data-theme="d" data-divider-theme="d">
						<li><a href="index.html">Adam Kinkaid</a></li>
						<li><a href="index.html">Alex Wickerham</a></li>
						<li><a href="index.html">Avery Johnson</a></li>
						<li><a href="index.html">Bob Cabot</a></li>
						<li><a href="index.html">Caleb Booth</a></li>
						<li><a href="index.html">Christopher Adams</a></li>
						<li><a href="index.html">Culver James</a></li>	
					</ul>
				</div>

			</mobile:collapsibleset>
					
			<h2>Non-inset, individual collapsibles</h2>

			<div data-role="collapsible" data-theme="b" data-content-theme="d" data-collapsed-icon="arrow-r" data-expanded-icon="arrow-d" data-inset="false">
				<h2>Pets</h2>
				<ul data-role="listview">
					<li><a href="index.html">Canary</a></li>
					<li><a href="index.html">Cat</a></li>
					<li><a href="index.html">Dog</a></li>
					<li><a href="index.html">Gerbil</a></li>
					<li><a href="index.html">Iguana</a></li>
					<li><a href="index.html">Mouse</a></li>
				</ul>
			</div><!-- /collapsible -->

			<div data-role="collapsible" data-theme="b" data-content-theme="d" data-collapsed-icon="arrow-r" data-expanded-icon="arrow-d" data-inset="false">
				<h2>Farm animals</h2>
				<ul data-role="listview">
					<li><a href="index.html">Chicken</a></li>
					<li><a href="index.html">Cow</a></li>
					<li><a href="index.html">Duck</a></li>
					<li><a href="index.html">Horse</a></li>
					<li><a href="index.html">Pig</a></li>
					<li><a href="index.html">Sheep</a></li>
				</ul>
			</div><!-- /collapsible -->

			<div data-role="collapsible" data-theme="b" data-content-theme="d" data-collapsed-icon="arrow-r" data-expanded-icon="arrow-d" data-inset="false">
				<h2>Wild Animals</h2>
				<ul data-role="listview">
					<li><a href="index.html">Aardvark</a></li>
					<li><a href="index.html">Alligator</a></li>
					<li><a href="index.html">Ant</a></li>
					<li><a href="index.html">Bear</a></li>
					<li><a href="index.html">Beaver</a></li>
					<li><a href="index.html">Cougar</a></li>
					<li><a href="index.html">Dingo</a></li>
				</ul>
			</div><!-- /collapsible -->

		</div>

		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
