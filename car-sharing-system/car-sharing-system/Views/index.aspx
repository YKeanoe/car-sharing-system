<%@ Page Title="Ace Rentals Home Page" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="car_sharing_system.FrontPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FrontPageHolder" runat="server">
  
  <!-- Intro Section -->
  <section id="intro" class="intro-section">
    <div class="container-full-width">
      
      <!-- Jumbotron Div -->
      <div class=" float-jumbo">
        <img src="Images/logo2.png" />
        <h2>Rent a car anywhere at a touch of a button</h2>          
        <p>
          <a class="btn btn-warning btn-front-page-sign-register" href="Admin_Theme/pages/register.aspx" role="button">Register</a>
          <a class="btn btn-primary btn-front-page-sign-register" href="Admin_Theme/pages/index.aspx" role="button">Login</a>
        </p>
      </div>

      <!-- Carousel Div -->
      <div id="carCarousel" class="carousel slide" data-ride="carousel" data-interval="20000">
        <div class="carousel-inner">
            <div class="item active">
                <!-- Set the first background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Views/Images/test1.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 1</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the second background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Views/Images/test2.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 2</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the third background image using inline CSS below. -->
                <div class="fill" style="background-image:url('/Views/Images/test3.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 3</h2>
                </div>
            </div>
        </div>
      </div>
    </div>
  </section>

  <!-- About Section -->
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
          <div class="list">
            
            <!-- Panel default -->
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
            </div>
            
            <asp:PlaceHolder ID="carlist"  runat="server"/>
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
          <div runat="server" id="hiddenD">
            <h1 id="hiddentext">This should be hidden</h1>
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
          <h1>Contact Section</h1>
        </div>
      </div>
    </div>
  </section>

    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8&callback=initMap"></script>
    <!--<script src="index.js"></script>-->
    <script type="text/javascript">
      // Function to initialize google map and its marker
      function initializeMap(position) {
        // Initialize cars (DUMMY DATA)
        var car1 = { lat: -37.816261, lng: 144.970976 };
        var car2 = { lat: -37.815555, lng: 144.970107 };
        var car3 = { lat: -37.815539, lng: 144.966278 };

        // Get longitude and latitude from user's position
        var locLat = position.coords.latitude;
        var locLng = position.coords.longitude;
        var x = { lat: locLat, lng: locLng };
        var usericon = 'Images/marker-circle-small.png';
        var markers = [];
        var bounds = new google.maps.LatLngBounds();

        // Initialize map
        var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 14,
          center: x
        });

        // Set markers for user and cars
        var markerUser = new google.maps.Marker({
          position: x,
          title: "User",
          icon: usericon
        });
        var markerCar1 = new google.maps.Marker({
          position: car1,
          title: "Car 1"
        });
        var markerCar2 = new google.maps.Marker({
          position: car2,
          title: "Car 2"
        });
        var markerCar3 = new google.maps.Marker({
          position: car3,
          title: "Car 3"
        });

        // Push all markers into array
        markers.push(markerCar1);
        markers.push(markerCar2);
        markers.push(markerCar3);
        markers.push(markerUser);

        // Set all markers into map
        markerUser.setMap(map);
        markerCar1.setMap(map);
        markerCar2.setMap(map);
        markerCar3.setMap(map);

        // Set boundary so that the map can fit all markers
        for (var i = 0; i < markers.length; i++) {
          bounds.extend(markers[i].getPosition());
        }
        bounds.extend(x);
        map.fitBounds(bounds);
      }

      // Function to get user's location
      function getLocation() {
        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(initializeMap);
        } else {
          x.innerHTML = "Geolocation is not supported by this browser.";
        }
      }

      // Get location of user after load is successful
      window.onload = getLocation
      var data = '<%=cars%>';
      window.alert(data);
    </script>

</asp:Content>
