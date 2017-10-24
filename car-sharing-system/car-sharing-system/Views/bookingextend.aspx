 <%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="bookingextend.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.bookingextend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
	<div class="col-lg-8">
		<div class="panel panel-default">
			<div class="panel-heading">
				<i class="fa fa-car fa-fw"></i> 
				Extend Booking
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
						<label><asp:Label runat="server" ID="carRateLabel">$x per Hour</asp:Label></label>
						<br />
						<label><asp:Label runat="server" ID="bookStartTime">Start Time</asp:Label></label>
						<br />
						<label><asp:Label runat="server" ID="bookEndTime">End Time</asp:Label></label>
						<br />
						<label>Estimated price</label>
						<label><asp:Label runat="server" ID="bookEstimatePrice">Estimated price</asp:Label></label>
						<br />
						
						<label>Extend until</label>
						<div class="date-div">
							<div class='input-group date' id='new-end-date-picker'>
								<input type='text' class="form-control" />
								<span class="input-group-addon">
									<span class="glyphicon glyphicon-calendar"></span>
								</span>
							</div>
						</div>
						<label>New estimated price $</label><label id="newPrice"></label>
						<br />	
						<label id="errormsg" runat="server"></label>
						<br />
						<asp:Button ID="confirmbtn" runat="server" Text="Confirm" CssClass="btn btn-primary" OnClick="extendBook" />
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
<link href="/Datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />


<asp:PlaceHolder runat="server" ID="script"></asp:PlaceHolder>

</asp:Content>