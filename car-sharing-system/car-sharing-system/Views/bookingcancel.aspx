 <%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="bookingcancel.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.bookingcancel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
	<div class="col-lg-8">
		<div class="panel panel-default">
			<div class="panel-heading">
				<i class="fa fa-car fa-fw"></i> 
				Cancel Booking
			</div>
			<div id="carinfo" runat="server">
				<div class="panel-body">
					<div class="panel-title">
						<label>Car Information</label>
					</div>
					<form id="form1" runat="server">  
						<label><asp:Label runat="server" ID="carNumberPlate">Plate</asp:Label></label>
						<br />
						<label>
							<asp:Label runat="server" ID="carBrandLabel">Brand</asp:Label>
							<asp:Label runat="server" ID="carModelLabel">Model</asp:Label>
						</label>
						<br />
						<label><asp:Label runat="server" ID="carTypeLabel">Type</asp:Label></label>
						<br />
						<label><asp:Label runat="server" ID="carSeatsLabel">x Seats</asp:Label></label>
						<br />
						<label><asp:Label runat="server" ID="carTransmissionLabel">Automatic</asp:Label></label>
						<br />
						<label><asp:Label runat="server" ID="carRateLabel">$x per Hour</asp:Label></label>
						<br />
						<label><asp:Label runat="server" ID="bookStartTime">Start Time</asp:Label></label>
						<br />
						<label><asp:Label runat="server" ID="bookEndTime">End Time</asp:Label></label>
						<br />
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
						<br />
						<label>Are you sure you want to cancel this booking?</label>
						<br />
						<asp:Button ID="confirmbtn" runat="server" Text="Yes" CssClass="btn btn-primary" OnClick="cancelBook" />
						<a class="btn btn-primary" href="/dashboard" role="button">No</a>
					</form>
				</div>
			</div>
		
			<div id="returndiv" runat="server">
				<label><asp:label runat="server" ID="errorlabel"></asp:label></label>
				<br />
				<a class="btn btn-primary" href="/dashboard" role="button">Return to dashboard</a>
			</div>

		</div>
	</div>
</div>

<link rel="stylesheet" type="text/css" href="/Theme/css/bookingconfirmation.css" />


<asp:PlaceHolder runat="server" ID="script"></asp:PlaceHolder>

</asp:Content>