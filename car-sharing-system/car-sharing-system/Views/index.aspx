<%@ Page Title="Ace Rentals Home Page" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="car_sharing_system.FrontPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FrontPageHolder" runat="server">
  <!-- Intro Section -->
  <section id="intro" class="intro-section">
    <div class="container-full-width">
      
      
      <!-- Jumbotron Div -->
      <div class="jumbotron float-jumbo">
        <h1>Ace Rental</h1>
        <h2>Rent a car anywhere at a touch of a button</h2>          
        <p>
          <a class="btn btn-warning btn-front-page-sign-register" href="#" role="button">Register</a>
          <a class="btn btn-primary btn-front-page-sign-register" href="#" role="button">Login</a>
        </p>
      </div>

      <!-- Carousel Div -->
      <div id="carCarousel" class="carousel slide" data-ride="carousel" data-interval="20000">
        <div class="carousel-inner">
            <div class="item active">
                <!-- Set the first background image using inline CSS below. -->
                <div class="fill" style="background-image:url('Images/test1.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 1</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the second background image using inline CSS below. -->
                <div class="fill" style="background-image:url('Images/test2.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Caption 2</h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the third background image using inline CSS below. -->
                <div class="fill" style="background-image:url('Images/test3.jpg');"></div>
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
