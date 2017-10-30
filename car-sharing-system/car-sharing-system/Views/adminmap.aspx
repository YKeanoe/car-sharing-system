<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="adminmap.aspx.cs" Inherits="car_sharing_system.Views.adminmap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
	<div id="col-lg-12">
		<div id="map">
			<p>
				Please wait while we load the map.
				If it's taking too long, try reloading the page.
			</p>
		</div>
	</div>
</div>

<link href="/Theme/css/admin-map.css" rel="stylesheet" />
<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8&libraries=geometry"></script>
<script src="/Theme/js/admin-map-features.js"></script>
</asp:Content>