<%@ Page Title="Ace Rentals Home Page" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="car_sharing_system.FrontPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FrontPageHolder" runat="server">
  <!-- Intro Section -->
  <section id="intro" class="intro-section">

      <!-- Carousel Div -->
      <div id="carCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
          <ol class="carousel-indicators">
            <li data-target="#carCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#carCarousel" data-slide-to="1"></li>
            <li data-target="#carCarousel" data-slide-to="2"></li>
          </ol>

          <!-- Wrapper for slides -->
          <div class="carousel-inner">
            <div class="caousel-item active" style="background-image: url('Images/car-placeholder-1.jpeg')" ></div>
            <div class="carousel-item" style="background-image: url('Images/car-placeholder-2.jpeg')"></div>
            <div class="carousel-item" style="background-image: url('Images/car-placeholder-3.jpeg')"></div>
 
          </div>

          <!-- Left and right controls -->
          <a class="left carousel-control" href="#carCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="right carousel-control" href="#carCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
            <span class="sr-only">Next</span>
          </a>

    </div>
  </section>

  <!-- About Section -->
  <section id="cars" class="about-section">
    <div class="container-fluid">
      <div class="jumbotron carPanel">
        <div id="map"></div>
        <div class="list">
          List of cars near you 
          <asp:PlaceHolder ID="carlist"  runat="server"/>

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
      <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8&callback=initMap"></script>

    <script src="index.js"></script>

</asp:Content>
