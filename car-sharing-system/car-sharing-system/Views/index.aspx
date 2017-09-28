<%@ Page Title="Ace Rentals Home Page" Language="C#" MasterPageFile="~/FrontPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="car_sharing_system.FrontPage" %>
<asp:Content ID="IndexContent" ContentPlaceHolderID="FrontPageHolder" runat="server">
  
<!-- Intro Section -->
<section id="intro" class="intro-section">
	<div class="container-full-width">
      
		<!-- Jumbotron Div -->
		<div class=" float-jumbo">
			<img src="/Theme/Images/logo2.png" />
			<h2>Rent a car anywhere at a touch of a button</h2>          
			<p>
				<a class="btn btn-warning btn-front-page-sign-register" href="/dashboard/register" role="button">Register</a>
				<a class="btn btn-primary btn-front-page-sign-register" href="/dashboard/login" role="button">Login</a>
			</p>
		</div>

      <!-- Carousel Div -->
      <div id="carCarousel" class="carousel slide" data-ride="carousel" data-interval="20000">
        <div class="carousel-inner">
            <div class="item active">
                <!-- Set the first background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Theme/Images/test1.jpg');"></div>
                <div class="carousel-caption">
                  
                </div>
            </div>
            <div class="item">
                <!-- Set the second background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Theme/Images/test2.jpg');"></div>
                <div class="carousel-caption">
                   
                </div>
            </div>
            <div class="item">
                <!-- Set the third background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Theme/Images/test3.jpg');"></div>
                <div class="carousel-caption">
                 
                </div>
            </div>
        </div>
      </div>
    </div>
  </section>

<!-- Car Section -->
<section id="cars" class="car-section">
	<div class="container-fluid">
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

						<div class="filter">
							<div id="date-group">
								<div class="col-md-6">
									<label>Start date</label>
									<div class='input-group date' id='start-date-picker'>
										<input type='text' class="form-control" />
										<span class="input-group-addon">
											<span class="glyphicon glyphicon-calendar"></span>
										</span>
									</div>
								</div>
								<div class="col-md-6">
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
</section>
  

  <!-- Services Section -->
  <section id="book" class="services-section">
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <h1>News</h1>

            <div id="pagewrap">

	<div class="middle">
	
        <img src="../Theme/Images/middle.png" />
	</div>
	
	<div class="middle">
        <img src="../Theme/Images/middle.png" />
	</div>


	<div class="middle">
		
		  <img src="../Theme/Images/middle.png" />

	</div>
	
</div>
        </div>
      </div>
    </div>
  </section>

  <!-- Contact Section -->
  <section id="contact" class="contact-section">
    <div class="container">

      <div class="row">
         
        <div class="col-lg-12">
          <h1>Contact Us</h1>
            <h2><p>Need Help? Want to send us feedback?</p></h2>
                <h2><p>Call us, Email us or submit a support ticket.</p></h2>
            <div class="dropdown">
                <select id="mySelect" onchange="dropdown()">
                    <option value="English">English
                    <option value="Espanol">Espanol
                    <option value="Francais">Francais
                </select>

                <p id="language"></p>

            </div>
            <h3><p>24 Hour Phone Support: (03) 9560 2122</p></h3>
            

            <h3><p>Email: support@acecarrentals.com</p></h3>
            
            <a href="https://www.w3schools.com"><h3>Submit a support ticket</h3></a>

            

        </div>
      </div>
    </div>
  </section>

<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8&libraries=geometry"></script>
<script src="/Datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
<script src="/Theme/js/map-features.js"></script>
<script src="/Theme/js/dropdown.js"></script>
</asp:Content>
