<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="bookinghistory.aspx.cs" Inherits="car_sharing_system.Views.bookinghistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">


<div class="row">
    <!-- User Panel -->
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
                        <div>Users!</div>
                    </div>
                </div>
            </div>
            <a href="adminusers.aspx">
                <div class="panel-footer">
                    <span class="pull-left">View users</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <!-- Booking History Panel -->
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-car fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"></div>
                        <br>
                        <div>Car history!</div>
                    </div>
                </div>
            </div>
            <a href="admincar.aspx  ">
                <div class="panel-footer">
                    <span class="pull-left">View cars</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <!-- Issue Panel -->
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-bar-chart-o fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"></div>
                        <br>
                        <div>View Issues!</div>
                    </div>
                </div>
            </div>
            <a href="adminissue.aspx">
                <div class="panel-footer">
                    <span class="pull-left">View issues</span>
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
                <i class="fa fa-bar-chart-o fa-fw"></i> Bookings History
                <div class="pull-right">
                    <div class="btn-group">                     
                    </div>
                </div>
            </div>
            <div class="panel-body">       
                <div class="col-lg-8">
                    <h2 id="bookings">Bookings History</h2>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
