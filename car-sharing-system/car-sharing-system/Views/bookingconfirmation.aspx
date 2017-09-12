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
					<div class="feature-list">
						<i class="fa fa-check fa-fw" ></i> GPS
						<i class="fa fa-times fa-fw" ></i> GPS
						<i class="fa fa-check fa-fw" ></i> GPS
						<i class="fa fa-check fa-fw" ></i> GPS
					</div>

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



<script type="text/javascript">
	var userPos = { lat: "", lng: "" };
	var carPos = { lat: "", lng: "" };

	$.idleTimer(2000);
	
	$(document).on("idle.idleTimer", function (event, elem, obj) {
		console.log("idle");
	});

	$(document).on("active.idleTimer", function (event, elem, obj, triggerevent) {
		console.log("active");
	});

	$(window).on('load', function () {
		console.log("setting map");
		var dfd = $.Deferred();
		var getLocationStatus = getLocation();
		getLocationStatus.then(sendRequestForCarLocation).done(function () {
			dfd.resolve();
			var googleurl = "https://maps.googleapis.com/maps/api/staticmap?"
							+ "&zoom=5"
							+ "&size=500x500"
							+ "&markers=color:red%7Clabel:C%7C" + carPos.lat + "," + carPos.lng
							+ "&markers=color:blue%7Clabel:U%7C" + userPos.lat + "," + userPos.lng
							+ "&key=AIzaSyA7zQh6CSIAHNX4fJdw0sY5GPL2wjemyHY"
			console.log(googleurl);
			$('#googlemap').attr('src', googleurl);
			console.log("setmap done");
		})
	});

	function setMap(data) {
		var carLocs = JSON.parse(data.d);
		console.log(carLocs);
		carPos = carLocs;
	}

	function getLocation() {
		var dfd = $.Deferred();
		if (navigator.geolocation) {
			navigator.geolocation.getCurrentPosition(function (position) {
				userPos = { lat: position.coords.latitude, lng: position.coords.longitude }
				console.log(userPos);
				dfd.resolve();
			}, function () {
				dfd.reject();
			});
		} else {
			x.innerHTML = "Geolocation is not supported by this browser.";
			reject();
		}
		console.log("getlocation done");
		return dfd.promise();
	}

	function sendRequestForCarLocation() {
		var dfd = $.Deferred();
		$.ajax({
			type: "POST",
			url: "/Views/bookingconfirmation.aspx/getCarLocation",
			data: "{}",
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (response) {
				setMap(response);
				dfd.resolve();
			},
			failure: function () {
				console.error("Car JSON error");
				dfd.reject();
			}
		});
		return dfd.promise();
	}
</script>

</asp:Content>