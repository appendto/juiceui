<%@ Page Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="Mobile._Form" ClientIDMode="Static" %>
<asp:Content ID="_Page" runat="server" ContentPlaceHolderID="_Content">

	<mobile:page runat="server">
		
		<mobile:header Text="Forms" runat="server">
			<a href="/" id="_Home" runat="server">Home</a>
			<mobile:anchor TargetControlID="_Home" runat="server" IconPosition="NoText" Icon="Home" Direction="Reverse" />
		</mobile:header>
		
		<mobile:content runat="server">

			<mobile:fieldcontainer runat="server">
	      <label for="name">Text Input:</label>
	      <input type="text" name="name" id="name" value=""  />
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<label for="textarea">Textarea:</label>
				<textarea cols="40" rows="8" name="textarea" id="textarea"></textarea>
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<label for="search">Search Input:</label>
				<input type="search" name="password" id="search" value=""  />
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<label for="slider2">Flip switch:</label>
				<mobile:fliptoggle id="slider2" runat="server">
					<mobile:fliptoggleitem runat="server" value="off">Off</mobile:fliptoggleitem>
					<mobile:fliptoggleitem runat="server" value="on">On</mobile:fliptoggleitem>
				</mobile:fliptoggle>
			</mobile:fieldcontainer>

			<p>
				HTML 5 input types require the following updates for .NET 4.0:<br/>
				http://support.microsoft.com/kb/2468871<br/>
				http://support.microsoft.com/kb/2533523<br/><br/>
				This demo is using .NET 4.0.3.
			</p>

			<mobile:fieldcontainer runat="server">
				<label for="slider">Slider:</label>
				<asp:textbox runat="server" type="range" ID="slider" value="50" min="0" max="100" />
				<mobile:slider TargetControlID="slider" runat="server" Highlight="true" />
			</mobile:fieldcontainer>
			
			<p>To theme a checkbox or set it's mini-state, use the &lt;mobile:checkbox&gt; control.<p>

			<mobile:fieldcontainer runat="server">
				<mobile:controlgroup runat="server">
					<legend>Choose as many snacks as you'd like:</legend>

					<input type="checkbox" name="checkbox-1a" id="checkbox-1a" />
					<label for="checkbox-1a">Cheetos</label>

					<input type="checkbox" name="checkbox-2a" id="checkbox-2a" />
					<label for="checkbox-2a">Doritos</label>

					<input type="checkbox" name="checkbox-3a" id="checkbox-3a" />
					<label for="checkbox-3a">Fritos</label>

					<input type="checkbox" name="checkbox-4a" id="checkbox-4a" />
					<label for="checkbox-4a">Sun Chips</label>
				</mobile:controlgroup>
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<mobile:controlgroup runat="server" GroupType="Horizontal">
					<legend>Font styling:</legend>

					<input type="checkbox" name="checkbox-6" id="checkbox-6" />
					<label for="checkbox-6">b</label>

					<input type="checkbox" name="checkbox-7" id="checkbox-7" />
					<label for="checkbox-7"><em>i</em></label>

					<input type="checkbox" name="checkbox-8" id="checkbox-8" />
					<label for="checkbox-8">u</label>
				</mobile:controlgroup>
			</mobile:fieldcontainer>
			
			<mobile:fieldcontainer runat="server">
				<mobile:controlgroup runat="server">
					<legend>Choose a pet:</legend>

					<input type="radio" name="radio-choice-1" id="radio-choice-1" value="choice-1" checked="checked" />
					<label for="radio-choice-1">Cat</label>

					<input type="radio" name="radio-choice-1" id="radio-choice-2" value="choice-2"  />
					<label for="radio-choice-2">Dog</label>

					<input type="radio" name="radio-choice-1" id="radio-choice-3" value="choice-3"  />
					<label for="radio-choice-3">Hamster</label>

					<input type="radio" name="radio-choice-1" id="radio-choice-4" value="choice-4"  />
					<label for="radio-choice-4">Lizard</label>
				</mobile:controlgroup>
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<mobile:controlgroup runat="server" GroupType="Horizontal">
					<legend>Layout view:</legend>

			    <input type="radio" name="radio-choice-b" id="radio-choice-c" value="on" checked="checked" />
			    <label for="radio-choice-c">List</label>
			    
					<input type="radio" name="radio-choice-b" id="radio-choice-d" value="off" />
			    <label for="radio-choice-d">Grid</label>
			    
					<input type="radio" name="radio-choice-b" id="radio-choice-e" value="other" />
			    <label for="radio-choice-e">Gallery</label>
				</mobile:controlgroup>
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<label for="select-choice-1" class="select">Choose shipping method:</label>
				<select name="select-choice-1" id="select-choice-1">
					<option value="standard">Standard: 7 day</option>
					<option value="rush">Rush: 3 days</option>
					<option value="express">Express: next day</option>
					<option value="overnight">Overnight</option>
				</select>
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<label for="select-choice-3" class="select">Your state:</label>
				<select name="select-choice-3" id="select-choice-3">
					<option value="AL">Alabama</option>
					<option value="AK">Alaska</option>
					<option value="AZ">Arizona</option>
					<option value="AR">Arkansas</option>
					<option value="CA">California</option>
					<option value="CO">Colorado</option>
					<option value="CT">Connecticut</option>
					<option value="DE">Delaware</option>
					<option value="FL">Florida</option>
					<option value="GA">Georgia</option>
					<option value="HI">Hawaii</option>
					<option value="ID">Idaho</option>
					<option value="IL">Illinois</option>
					<option value="IN">Indiana</option>
					<option value="IA">Iowa</option>
					<option value="KS">Kansas</option>
					<option value="KY">Kentucky</option>
					<option value="LA">Louisiana</option>
					<option value="ME">Maine</option>
					<option value="MD">Maryland</option>
					<option value="MA">Massachusetts</option>
					<option value="MI">Michigan</option>
					<option value="MN">Minnesota</option>
					<option value="MS">Mississippi</option>
					<option value="MO">Missouri</option>
					<option value="MT">Montana</option>
					<option value="NE">Nebraska</option>
					<option value="NV">Nevada</option>
					<option value="NH">New Hampshire</option>
					<option value="NJ">New Jersey</option>
					<option value="NM">New Mexico</option>
					<option value="NY">New York</option>
					<option value="NC">North Carolina</option>
					<option value="ND">North Dakota</option>
					<option value="OH">Ohio</option>
					<option value="OK">Oklahoma</option>
					<option value="OR">Oregon</option>
					<option value="PA">Pennsylvania</option>
					<option value="RI">Rhode Island</option>
					<option value="SC">South Carolina</option>
					<option value="SD">South Dakota</option>
					<option value="TN">Tennessee</option>
					<option value="TX">Texas</option>
					<option value="UT">Utah</option>
					<option value="VT">Vermont</option>
					<option value="VA">Virginia</option>
					<option value="WA">Washington</option>
					<option value="WV">West Virginia</option>
					<option value="WI">Wisconsin</option>
					<option value="WY">Wyoming</option>
				</select>
			</mobile:fieldcontainer>

			<mobile:fieldcontainer runat="server">
				<label for="select_choice_a" class="select">Choose shipping method:</label>
				<select name="select-choice-a" id="select_choice_a" runat="server">
					<option>Custom menu example</option>
					<option value="standard">Standard: 7 day</option>
					<option value="rush">Rush: 3 days</option>
					<option value="express">Express: next day</option>
					<option value="overnight">Overnight</option>
				</select>
				<mobile:select runat="server" TargetControlID="select_choice_a" UseNativeMenu="false"/>
			</mobile:fieldcontainer>

			<div class="ui-body ui-body-b">
			<fieldset class="ui-grid-a">
				<div class="ui-block-a"><button type="submit" data-theme="d">Cancel</button></div>
				<div class="ui-block-b"><button type="submit" data-theme="a">Submit</button></div>
	    </fieldset>
			</div>


		</mobile:content>
		
		<mobile:footer runat="server"/>
	
	</mobile:page>

</asp:Content>
