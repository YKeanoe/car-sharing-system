 <%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="bookingconfirmation.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.bookingconfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
	<div class="col-lg-8">
		<div class="panel panel-default">
			<div class="panel-heading">
				<i class="fa fa-car fa-fw"></i> 
				Booking
			</div>
			<div class="panel-body">
				<div class="panel-title">
					<label>Car Information</label>
				</div>
				<div class="panel-half">
					<label><asp:Label runat="server" ID="carBrandLabel">Brand</asp:Label></label>
					<label><asp:Label runat="server" ID="carModelLabel">Model</asp:Label></label>
					<label><asp:Label runat="server" ID="carTypeLabel">Type</asp:Label></label>
					<label><asp:Label runat="server" ID="carSeatsLabel">x Seats</asp:Label></label>
					<label><asp:Label runat="server" ID="carTransmissionLabel">Automatic</asp:Label></label>
					<label><asp:Label runat="server" ID="carRateLabel">$x per Hour</asp:Label></label>
		            
					<asp:PlaceHolder ID="featurelist"  runat="server"/>

					<div class="feature-list">
						<div class="panel-half">
							<i class="fa fa-check fa-fw" ></i> GPS
							<br />
							<i class="fa fa-times fa-fw" ></i> CD Player
							<br />
							<i class="fa fa-check fa-fw" ></i> Bluetooth
							<br />
						</div>
						<div class="panel-half">
							<i class="fa fa-times fa-fw" ></i> Cruise Control
							<br />
							<i class="fa fa-times fa-fw" ></i> Reverse Camera
							<br />
							<i class="fa fa-check fa-fw" ></i> Radio
							<br />
						</div>
					</div>

		            <button class="btn btn-primary" type="button">Next</button>


				</div>
				<div class="panel-half">
						<div id="map"><img id="googlemap" border="0" src="#"/></div>

				</div>
			</div>
		</div>
	</div>
</div>
<link rel="stylesheet" type="text/css" href="/Theme/css/bookingconfirmation.css" />
<script src="/Theme/js/idle-timer.min.js"></script>
<script src="/Theme/js/booking-confirmation-map.js"></script>
<script src="Theme/js/timeout-features.js"></script>

</asp:Content>