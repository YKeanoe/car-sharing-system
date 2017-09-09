<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="successregister.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.successregister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
    <div class="col-lg-8">
        <div class="panel panel-default">
            <div class="panel-heading">
                <i class="fa fa-user fa-fw"></i> Login
                <div class="pull-right">
                    <div class="btn-group">
                    </div>
                </div>
            </div>
            <div class="panel-body">
                  <h2>You have successfully registered an account</h2>
                  <p>You can now access the dash board.</p>
                  <a href="/dashboard">Dashboard</a>
            </div>
        </div>
    </div>
</div>

</asp:Content>
