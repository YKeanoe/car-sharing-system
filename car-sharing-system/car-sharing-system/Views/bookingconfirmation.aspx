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
				<div style="panel-title">
					<label>Car Information</label>
				</div>
				<div class="panel-half">
					<label>Tesla</label>
					<label>Model S 75D</label>
					<label>SUV</label>
					<label>2 Seats</label>
					<label>Automatic</label>
					<label>$30 per Hour</label>
				</div>
				<div class="panel-half">
			

				</div>
			</div>
		</div>
	</div>
</div>
<link rel="stylesheet" type="text/css" href="/Theme/css/bookingconfirmation.css" />
<script src="/Theme/js/idle-timer.min.js"></script>

<script type="text/javascript">

	$.idleTimer(2000);
	
	$(document).on("idle.idleTimer", function (event, elem, obj) {
		console.log("idle");
	});

	$(document).on("active.idleTimer", function (event, elem, obj, triggerevent) {
		console.log("active");
	});
</script>

</asp:Content>