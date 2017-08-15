<%@ Page Title="Ace Rentals Home Page" Language="C#" MasterPageFile="~/Homepage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="car_sharing_system.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section id="intro" class="intro-section">
    <div class="container">
      <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <div class="jumbotron float-test">
          <h1>Ace Rental</h1>
          <h2>Rent a car anywhere at a touch of a button</h2>
          <p>
            <a class="btn btn-warning btn-front-page-sign-register" href="#" role="button">Register</a>
            <a class="btn btn-primary btn-front-page-sign-register" href="#" role="button">Login</a>
          </p>
          <a class="btn btn-primary btn-front-page-rent" href="#" role="button">Rent a Car!</a>
        </div>
        <!-- Indicators -->
        <ol class="carousel-indicators">
          <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
          <li data-target="#myCarousel" data-slide-to="1"></li>
          <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
          <div class="item active">
            <img src="Images/car-placeholder-1.jpeg" alt="Los Angeles" style="width:100%;">
          </div>

          <div class="item">
            <img src="Images/car-placeholder-2.jpeg" alt="Chicago" style="width:100%;">
          </div>

          <div class="item">
            <img src="Images/car-placeholder-3.jpeg" alt="New york" style="width:100%;">
          </div>
        </div>
                
        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
          <span class="glyphicon glyphicon-chevron-left"></span>
          <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
          <span class="glyphicon glyphicon-chevron-right"></span>
          <span class="sr-only">Next</span>
        </a>
      </div>
    </div>
  </section>

  <!-- About Section -->
  <section id="cars" class="about-section">
    <div class="container">
      <div class="starter-template">
        <div class="container-fluid">

        <div class="jumbotron">
          <h1>Ace Rental</h1>
          <h2>Rent a car anywhereeeee at a touch of a button</h2>
          <p>
            <a class="btn btn-warning btn-front-page-sign-register" href="#" role="button">Register</a>
            <a class="btn btn-primary btn-front-page-sign-register" href="#" role="button">Login</a>
          </p>
          <a class="btn btn-primary btn-front-page-rent" href="#" role="button">Rent a Car!</a>
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
</asp:Content>
