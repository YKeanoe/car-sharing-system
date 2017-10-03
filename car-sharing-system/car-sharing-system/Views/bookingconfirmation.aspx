 <%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="bookingconfirmation.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.bookingconfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
	<div class="col-lg-8">
		<div class="panel panel-default">
			<div id="carinfo" runat="server">
				<div class="panel-heading">
					<i class="fa fa-car fa-fw"></i> 
					Booking
				</div>
				<div class="panel-body">
					<div class="panel-title">
						<label>Car Information</label>
					</div>
					<div class="panel-half">
						<form id="form1" runat="server">  
							<label><asp:Label runat="server" ID="carNumberPlate">Plate</asp:Label></label>
							<label>
								<asp:Label runat="server" ID="carBrandLabel">Brand</asp:Label>
								<asp:Label runat="server" ID="carModelLabel">Model</asp:Label>
							</label>
							<label><asp:Label runat="server" ID="carTypeLabel">Type</asp:Label></label>
							<label><asp:Label runat="server" ID="carSeatsLabel">x Seats</asp:Label></label>
							<label><asp:Label runat="server" ID="carTransmissionLabel">Automatic</asp:Label></label>
							<label><asp:Label runat="server" ID="carRateLabel">$x per Hour</asp:Label></label>
							<label><asp:Label runat="server" ID="bookStartTime">Start Time</asp:Label></label>
							<label><asp:Label runat="server" ID="bookEndTime">End Time</asp:Label></label>
							<label>Estimated price</label>
							<label><asp:Label runat="server" ID="bookEstimatePrice">Estimated price</asp:Label></label>
							<asp:PlaceHolder ID="featurelist"  runat="server"/>
							<div class="panel-full">
								<label>Car's Features</label>
								<div class="panel-half">
									<asp:PlaceHolder ID="leftfeat" runat="server"></asp:PlaceHolder>
								</div>
								<div class="panel-half">
									<asp:PlaceHolder ID="rightfeat" runat="server"></asp:PlaceHolder>
								</div>
							</div>
							<asp:Button ID="confirmbtn" runat="server" Text="Confirm" CssClass="btn btn-primary" OnClick="confirmBook" />
						</form>
					</div>
					<div class="panel-half">
							<div id="map"><img id="googlemap" border="0" src="javascript:void(0);"/></div>
					</div>
				</div>
			</div>
		
			<div id="returndiv" runat="server">
				<label><asp:label runat="server" ID="errorlabel"></asp:label></label>
				<br />
				<button class="btn btn-primary">Return to dashboard</button>
			</div>
		</div>
	</div>
</div>

<link rel="stylesheet" type="text/css" href="/Theme/css/bookingconfirmation.css" />


<asp:PlaceHolder runat="server" ID="script"></asp:PlaceHolder>

</asp:Content>