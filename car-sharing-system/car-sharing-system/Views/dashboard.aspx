<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<link href="/Datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />

<div class="row">
    <!-- Profile Panel -->
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
    <!-- Booking History Panel -->
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
    <!-- Submit Concerns Panel -->
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
<h2>Welcome back <%=newUser.fname%> <%=newUser.lname%></h2>
<div class="row">
	
	<div class="container-fluid" id="cardiv" runat="server">
		<div class="panel panel-default">
			<div class="panel-heading">
				<h2 id="aa">
					List of cars near you
				</h2>
			</div>
			<div class="panel-body">
				<div id="map"></div>
				<div class="list" >
					<div class="panel filter-panel">
						<label class="result-label">Refine Results</label>

						<div class="filter col-md-12">
							<div id="date-group">
								<div class="col-md-6 date-item">
									<label>Start date</label>
									<div class='input-group date' id='start-date-picker'>
										<input type='text' class="form-control" />
										<span class="input-group-addon">
											<span class="glyphicon glyphicon-calendar"></span>
										</span>
									</div>
								</div>
								<div class="col-md-6 date-item">
									<label>End date</label>
									<div class='input-group date' id='end-date-picker'>
										<input type='text' class="form-control" />
										<span class="input-group-addon">
											<span class="glyphicon glyphicon-calendar"></span>
										</span>
									</div>
								</div>								
							</div>
						</div>
						<div class="filter col-md-12">
							<div class="dropdown filter-dropdown-big filter-dropdown-left">
								<button class="btn btn-primary dropdown-toggle btn-filter-sortby" id="sortby-filter" type="button" data-toggle="dropdown">
									Sort by
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu filter-dropdown-menu-sortby" id="sortby-filter-dropdown">
									<li><a href:"#">Distance (Lowest) (Default)</a></li>
									<li><a href:"#">Distance (Highest)</a></li>
									<li><a href:"#">Rate (Lowest)</a></li>
									<li><a href:"#">Rate (Highest)</a></li>
								</ul>
							</div>
							<div class="dropdown filter-dropdown-big filter-dropdown-right">
								<button class="btn btn-primary dropdown-toggle btn-filter-sortby" id="transmission-filter" type="button" data-toggle="dropdown" style="float:right;">
									Transmission
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu dropdown-menu-right filter-dropdown-menu" id="transmission-filter-dropdown">
									<li><a href:"#">Any</a></li>
									<li><a href:"#">Automatic</a></li>
									<li><a href:"#">Manual</a></li>
								</ul>
							</div>
								
						</div>
						<div class="filter col-md-12">
							<div class="dropdown filter-dropdown">
								<button class="btn btn-primary dropdown-toggle btn-filter" id="brand-filter" type="button" data-toggle="dropdown">
									Brand
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu filter-dropdown-menu" id="brand-filter-dropdown">
									<li><a href:"#">Any</a></li>
									<li><a href:"#">Audi</a></li>
									<li><a href:"#">Ford</a></li>
									<li><a href:"#">Kia</a></li>
									<li><a href:"#">Mazda</a></li>
									<li><a href:"#">Mini</a></li>
									<li><a href:"#">Tesla</a></li>
									<li><a href:"#">Toyota</a></li>
									<li><a href:"#">Subaru</a></li>
									<li><a href:"#">Suzuki</a></li>
								</ul>
							</div>
							<div class="dropdown filter-dropdown">
								<button class="btn btn-primary dropdown-toggle btn-filter" id="seat-filter" type="button" data-toggle="dropdown">
									Seats
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu filter-dropdown-menu" id="seat-filter-dropdown">
									<li><a href:"#">Any</a></li>
									<li><a href:"#">2 Seats</a></li>
									<li><a href:"#">5 Seats</a></li>
									<li><a href:"#">7 Seats</a></li>
									<li><a href:"#">8+ Seats</a></li>
								</ul>
							</div>
							<div class="dropdown filter-dropdown">
								<button class="btn btn-primary dropdown-toggle btn-filter" id="type-filter" type="button" data-toggle="dropdown">
									Type
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu dropdown-menu-right filter-dropdown-menu" id="type-filter-dropdown">
									<li><a href:"#">Any</a></li>
									<li><a href:"#">Convertible</a></li>
									<li><a href:"#">Coupe</a></li>
									<li><a href:"#">Electric</a></li>
									<li><a href:"#">Hatch</a></li>
									<li><a href:"#">Hybrid</a></li>
									<li><a href:"#">Sedan</a></li>
									<li><a href:"#">SUV</a></li>
									<li><a href:"#">Ute</a></li>
									<li><a href:"#">Van</a></li>
									<li><a href:"#">Wagon</a></li>
								</ul>
							</div>
						</div>

						
						<div class="filter">
							<div class="dropdown filter-dropdown">
								<button class="btn btn-primary btn-filter-fill" id="x-filter" type="button" data-toggle="collapse" data-target="#filter-feat">
									Advance Filters
								</button>
							</div>
						</div>
						<div class="panel panel-default">
							<div id="filter-feat" class="panel-collapse collapse">
								<div class="panel-body">
									<div class="col-sm-12 advance-margin">
										<div class="col-sm-4">
											<button type="button" id="cd-btn" class="flat-butt flat-danger-butt">
												CD Player
											</button>			
										</div>
										<div class="col-sm-4">
											<button type="button" id="bt-btn" class="flat-butt flat-danger-butt">
												Bluetooth
											</button>			
										</div>
										<div class="col-sm-4">
											<button type="button" id="gps-btn" class="flat-butt flat-danger-butt">
												GPS
											</button>			
										</div>
									</div>
									<br />
									<div class="col-sm-12 advance-margin">
										<div class="col-sm-4">
											<button type="button" id="cc-btn" class="flat-butt flat-danger-butt">
												Cruise Control
											</button>
										</div>
										<div class="col-sm-4">
											<button type="button" id="rad-btn" class="flat-butt flat-danger-butt">
												Radio
											</button>
										</div>
										<div class="col-sm-4"> 
											<button type="button" id="rev-btn" class="flat-butt flat-danger-butt">
												Reverse Camera
											</button>			
										</div>
									</div>
								</div>
							</div>
						</div>
						<button class="btn btn-primary" id="list-collapse-btn" type="button">Filter</button>
					</div>
					<div class="collapse in" id="list-collapse">
						<!--<asp:PlaceHolder ID="carlist"  runat="server"/>-->
						<div id="carlist">
							<div id="carlist-accordion"></div>
							<ul id="car-page" class="pagination">
								<li class="active"><a href="javascript:void(0);">1</a></li>
								<li><a href="javascript:void(0);">2</a></li>
								<li><a href="javascript:void(0);">3</a></li>
								<li><a href="javascript:void(0);">4</a></li>
								<li><a href="javascript:void(0);">5</a></li>
								<li><a href="javascript:void(0);">6</a></li>
								<li><a href="javascript:void(0);">7</a></li>
								<li><a href="javascript:void(0);">8</a></li>
								<li><a href="javascript:void(0);">9</a></li>	
								<li><a href="javascript:void(0);">10</a></li>
							</ul>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>

    <div class="container-fluid" id="booklistdiv" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                <i class="fa fa-hourglass-half fa-fw"></i> Current Booking
                <div class="pull-right">
                    <div class="btn-group">                
                    </div>
                </div>
            </div>
            <div class="panel-body">
				<label>
					<asp:Label runat="server" ID="carNumberPlate">Plate</asp:Label>
					<asp:Label runat="server" ID="carBrandLabel">Brand</asp:Label>
					<asp:Label runat="server" ID="carModelLabel">Model</asp:Label>
				</label>
				<br />
				<label><asp:Label runat="server" ID="bookStart">Start on ddddd, dd MMMM yyyy at hh:mm</asp:Label></label>
				<br />
				<label><asp:Label runat="server" ID="bookEstEnd">Booked until ddddd, dd MMMM yyyy at hh:mm</asp:Label></label>
				<br />
				<asp:placeholder runat="server" ID="bookOverdue"></asp:placeholder>
				<br />

                <a href="/dashboard/return" class="btn btn-primary">
                    Return car
                </a>
				<a class="btn btn-primary" href="/dashboard/extendbooking" role="button" runat="server" id="extendBtn">
					Extend Booking
				</a>
				<a class="btn btn-primary" href="/dashboard/cancelbooking" role="button" runat="server" id="cancelBtn">
					Cancel Booking
				</a>
            </div>
        </div>
        <div class="col-lg-8">
        </div>
    </div>
</div>


<asp:PlaceHolder runat="server" ID="script"></asp:PlaceHolder>

</asp:Content>
