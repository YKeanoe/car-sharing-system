<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="car_sharing_system.Views.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
	<div class="col-lg-8">
		<div class="panel panel-default">
			<div class="panel-heading">
				Change Password
            </div>
			<div class="panel-body">
				<form runat="server">
					<div class="input-div" id="cpInput">
						<label class="label-input-text">Enter your current password: </label>
						<input type="password" name="currPassword" id="currPassword" runat="server">
					</div>
					<div class="input-div" id="npInput">
						<label class="label-input-text">Enter your new password: </label>
						<input type="password" name="newPassword" id="newPassword" runat="server">
					</div>
					<div class="input-div" id="rnpInput">
						<label class="label-input-text">Re-enter your new password: </label>
						<input type="password" name="reNewPassword" id="reNewPassword" runat="server">
						<label id="unmatch-error" style="color:red; display:none">Password did not match</label>
					</div>
					<asp:Button runat="server" Text="Confirm" OnClick="submit" class="btn btn-primary"></asp:Button>
				</form>
			</div>
		</div>
	</div>
</div>

<script src="/Theme/js/change-password.js"></script>
<link href="/Theme/css/change-password.css" rel="stylesheet" />
</asp:Content>