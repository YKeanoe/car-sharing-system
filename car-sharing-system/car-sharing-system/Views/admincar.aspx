<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="admincar.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.admincar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">
	         
<div class="row">
    <div class="col-lg-3 col-md-6 menu">
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
    <div class="col-lg-3 col-md-6 menu">
        <div class="panel panel-primary">
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
    <div class="col-lg-3 col-md-6 menu">
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
				<i class="fa fa-tasks fa-fw"></i> List of Cars
				<div class="pull-right">
					<div class="btn-group">                
					</div>
				</div>
			</div>
			<div class="panel-body">
				<div id="booking-list">
					<table class="table table-striped table-hover">
						<thead>
							<tr>
								<th>Car Plate</th>
								<th>Brand</th>
								<th>Model</th>
								<th>Type</th>
								<th>Rate</th>
								<th>Status</th>
								<th></th>
							</tr>
						</thead>
						<tbody>
						
						</tbody>
					</table>
					<ul id="car-page" class="pagination">
					</ul>
				</div>
			</div>
		</div>
	</div>
</div>

<link href="/Theme/css/booking-history.css" rel="stylesheet" />
<script src="/Theme/js/jquery.twbsPagination.min.js"></script>
<script src="/Theme/js/admin-cars-view.js"></script>

</asp:Content>
