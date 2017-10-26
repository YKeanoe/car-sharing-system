<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="issuerespond.aspx.cs" Inherits="car_sharing_system.Views.issuerespond" %>
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
						<div class="p1">Profile!</div>
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
		<div class="panel">
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
				<form id="form2" runat="server"> 
					<div class="form-group">
						<div class="panel-body">
							<label style="font-size:16px;">Issuer:</label> 
							<br />
							<label style="font-weight:400;"><asp:Label runat="server" ID="usernamelabel"></asp:Label></label>
							<br />
							<label style="font-size:16px;">Issue Subject:</label>
							<br />
							<label style="font-weight:400;"><asp:Label runat="server" ID="issuesubjectlabel"></asp:Label></label>
							<br />
							<label style="font-size:16px;">Issue Date:</label>
							<br />
							<label style="font-weight:400;"><asp:Label runat="server" ID="issuedatelabel"></asp:Label></label>
							<br />
                            <label style="font-size:16px;">Description:</label>
							<br />
							<label style="font-weight:400;"><asp:Label runat="server" ID="issuedesclabel"></asp:Label></label>
							<br />
							<br />
							<asp:TextBox ID="description" runat="server" placeholder="Enter respond"
								TextMode="Multiline"  class="description"></asp:TextBox> 
							<br />
							<br />
							<asp:Button Text="Submit" runat="server" class="btn btn-primary" OnClick="respondIssue" href="/dashboard/admin/issues/"> </asp:Button>
							<span id="issueFail" runat="server"></span>
						</div>
					</div>
				</form>  
			</div>
		</div>
	</div>
</div>
    
</asp:Content>
