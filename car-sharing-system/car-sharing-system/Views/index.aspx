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
          <a class="btn btn-warning btn-front-page-sign-register" href="dashboard/register" role="button">Register</a>
          <a class="btn btn-primary btn-front-page-sign-register" href="dashboard/login" role="button">Login</a>
        </p>
      </div>

      <!-- Carousel Div -->
      <div id="carCarousel" class="carousel slide" data-ride="carousel" data-interval="20000">
        <div class="carousel-inner">
            <div class="item active">
                <!-- Set the first background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Theme/Images/test1.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 1</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the second background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Theme/Images/test2.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 2</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the third background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Theme/Images/test3.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 3</h2>
                </div>
            </div>
        </div>
      </div>
    </div>
  </section>

  <!-- Car Section -->
  <section id="cars" class="about-section">
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
            <div class="panel">
              <label class="result-label">Refine Results</label>
              <div class="filter">
                <div class="dropdown filter-dropdown">
                  <button class="btn btn-primary dropdown-toggle btn-filter" id="brand-filter" type="button" data-toggle="dropdown">
                    Brand
                    <span class="caret"></span>
                  </button>
                  <ul class="dropdown-menu filter-dropdown-menu" id="brand-filter-dropdown">
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
                    <li><a href:"#">2 Seats</a></li>
                    <li><a href:"#">4 Seats</a></li>
                  </ul>
                </div>
                <div class="dropdown filter-dropdown">
                  <button class="btn btn-primary dropdown-toggle btn-filter-sortby" id="sortby-filter" type="button" data-toggle="dropdown">
                    Sort by
                    <span class="caret"></span>
                  </button>
                  <ul class="dropdown-menu filter-dropdown-menu-sortby" id="sortby-filter-dropdown">
                    <li><a href:"#">Distance (Lowest)</a></li>
                    <li><a href:"#">Distance (Highest)</a></li>
                    <li><a href:"#">Rate (Lowest)</a></li>
                    <li><a href:"#">Rate (Highest)</a></li>
                  </ul>
                </div>
              </div>
              <button class="btn btn-primary" id="list-collapse-btn" type="button">Filter</button>
            </div>
            <div class="collapse in" id="list-collapse">
              <!--<asp:PlaceHolder ID="carlist"  runat="server"/>-->
              <div id="carlist"></div>
              <!-- Panel default
              <div class="panel-default car-panel">
                <div class="panel-heading">
                    <a data-toggle="collapse" href="#collapse1" class="car-panel-title">
                        Suzuki x
                      <span style="float:right;">10km away</span>
                    </a>
                  </div>
                  <div id="collapse1" class="panel-collapse collapse">
                  <div class="panel-body">
                    asdasd asdasd
                  </div>
                </div>
              </div>-->
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
          <h1>Services Section</h1>
        </div>
      </div>
    </div>
  </section>

  <!-- Contact Section -->
  <section id="contact" class="contact-section">
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <h1>Contact Section</h1>
        </div>
      </div>
    </div>
  </section>

    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8&libraries=geometry"></script>
    <script src="/Theme/js/map-features.js"></script>

</asp:Content>
