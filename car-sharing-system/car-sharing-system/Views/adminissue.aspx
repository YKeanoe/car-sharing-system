<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="adminissue.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.adminissue" %>
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
				<i class="fa fa-tasks fa-fw"></i> Issues List
			</div>
			<div class="panel-body">
				<div id="issue-list">
					<table class="table table-striped" style="border-collapse:collapse;">
						<thead>
							<tr>
								<th>Issue Date</th>
								<th>Issuer Name</th>
								<th>Subject</th>
								<th>Responded</th>
								<th>Respond Date</th>
							</tr>
						</thead>
						<asp:PlaceHolder runat="server" ID="issuetableph"></asp:PlaceHolder>
					</table>
				</div>
			</div>
		</div>
	</div>
</div>

<link href="/Theme/css/issue.css" rel="stylesheet" />


</asp:Content>
