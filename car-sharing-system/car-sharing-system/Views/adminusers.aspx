<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="adminusers.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.adminusers" %>
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
				<div class="pull-right">
					<div class="btn-group">
					</div>
				</div>
			</div>
			<div class="panel-body">
				<div id="pagers"> 
					<ul id="car-page" class="pagination">
						<asp:PlaceHolder runat="server" ID="pages"></asp:PlaceHolder>
					</ul>
				</div>
				<div class="table" id="Usertable" runat="server">
					<table class="table table-striped table-hover">
						<thead>
							<tr>
								<th class="col-md-1">ID</th>
								<th class="col-md-2">Name</th>
								<th class="col-md-2">License Number</th>
								<th class="col-md-3">Email</th>
								<th class="col-md-1">View Profile</th>
								<th class="col-md-2">View Booking History</th>
							</tr>
						</thead>
						<tbody>
							<asp:PlaceHolder runat="server" ID="userrow"></asp:PlaceHolder>
						</tbody>
					</table>  
				</div>
			</div>
		</div>
	</div>
	<div class="col-lg-8">
	</div>
</div>

<link href="/Theme/css/admin-users.css" rel="stylesheet" />

</asp:Content>