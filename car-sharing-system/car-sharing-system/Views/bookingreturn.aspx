 <%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="bookingreturn.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.bookingreturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
	<div class="col-lg-8">
		<div class="panel panel-default">
			<div runat="server" id="carinfo">
				<div class="panel-heading">
					<i class="fa fa-car fa-fw"></i> 
					Returning Car
				</div>
				<div class="panel-body">
					<div class="panel-title">
						<label>Returning car</label>
					</div>
					<div class="panel-full">
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
							<asp:PlaceHolder runat="server" ID="bookOverdue"></asp:PlaceHolder>
							<label>Total price</label>
							<label><asp:Label runat="server" ID="bookEstimatePrice">Estimated price</asp:Label></label>
							<asp:PlaceHolder ID="featurelist"  runat="server"/>
							<asp:Button ID="confirmbtn" runat="server" Text="Return car" CssClass="btn btn-primary" OnClick="confirmReturn"></asp:Button>
						</form>
					</div>
				</div>
			</div>
		
			<div runat="server" id="errorinfo">
				<label><asp:Label runat="server" ID="errorlabel"></asp:Label></label>
				<br />
				<a href="/dashboard/" class="btn btn-primary">Return to dashboard</a>
			</div>
		</div>
	</div>
</div>


<link rel="stylesheet" type="text/css" href="/Theme/css/bookingconfirmation.css" />

<asp:PlaceHolder runat="server" ID="script"></asp:PlaceHolder>

</asp:Content>