<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="successBook.aspx.cs" Inherits="car_sharing_system.Views.pages.successBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
    <div class="col-lg-8">
        <div class="panel panel-default">
            <div class="panel-heading">
                <i class="fa fa-user fa-fw"></i> Return car
            </div>
            <div class="panel-body">
                <h2>You have successfully return the car</h2>
                <p>You can now access the dash board.</p>
				<p>
					The car has been returned at 
					<asp:Label runat="server" ID="latlonglabel"></asp:Label>
				</p>
				<a class="btn btn-primary" href="/dashboard/" role="button">To Dashboard</a>
            </div>
        </div>
    </div>
</div>

</asp:Content>
