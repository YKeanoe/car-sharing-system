<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">
               
<div class="row">
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-user fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"></div>
                        <br>
                        <div>Profile!</div>
                    </div>
                </div>
            </div>
            <a href="/dashboard/profile">
                <div class="panel-footer">
                    <span class="pull-left">View profile details</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-red">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-tasks fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"></div>
                        <br>
                        <div>Booking history!</div>
                    </div>
                </div>
            </div>
            <a href="/dashboard/booking">
                <div class="panel-footer">
                    <span class="pull-left">View booking history</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-envelope-o fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"></div>
                        <br>
                        <div>Having issues?</div>
                    </div>
                </div>
            </div>
            <a href="/dashboard/issue">
                <div class="panel-footer">
                    <span class="pull-left">Submit concerns</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
</div>
<div class="row">
	<div class="col-lg-8">
		<div class="panel panel-default">
			<div class="panel-heading">
				<i class="fa fa-tasks fa-fw"></i> Booking history
				<div class="pull-right">
					<div class="btn-group">                
					</div>
				</div>
			</div>
			<div class="panel-body">
				<div id="booking-list">
					<div class="booking-item">
						<label> (ASDASD) Suzuki X </label>
						<br />
						<label>Start on ddddd, dd MMMM yyyy at hh:mm</label>
						<br />
						<label>Booked until ddddd, dd MMMM yyyy at hh:mm</label>
						<br />
						<asp:placeholder runat="server" ID="bookOverdue"></asp:placeholder>
						<br />
					</div>
					<div class="booking-item">
						<label> (ASDASD) Suzuki X </label>
						<br />
						<label>Start on ddddd, dd MMMM yyyy at hh:mm</label>
						<br />
						<label>Booked until ddddd, dd MMMM yyyy at hh:mm</label>
						<br />
						<asp:placeholder runat="server" ID="Placeholder1"></asp:placeholder>
						<br />
					</div>
				</div>
				<asp:PlaceHolder runat="server" ID="bookingList"></asp:PlaceHolder>
			</div>
		</div>
	</div>
</div>
    
                    
<link href="/Theme/css/booking-history.css" rel="stylesheet" />

</asp:Content>

