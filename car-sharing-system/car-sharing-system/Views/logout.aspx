<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">
    
<div class="row">
    <div class="col-lg-8">
        <div class="panel panel-default">          
            <div class="panel-heading">
                <i class="fa fa-user fa-fw"></i> Profile details
                <div class="pull-right">
                    <div class="btn-group">
                    </div>
                </div>
            </div>
            <div class="panel-body">
                Are you sure you want to logout?
                <form id="form2" runat="server">
                    <asp:LinkButton class="btn btn-primary" Text="Log out" OnClick="LoginLink_OnClick" runat="server" />
                </form>
            </div>
        </div>
    </div>
</div>

</asp:Content>
