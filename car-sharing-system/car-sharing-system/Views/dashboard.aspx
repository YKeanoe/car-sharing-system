<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
    <!-- Profile Panel -->
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-xs-3">
                        <i class="fa fa-user fa-5x"></i>
                    </div>
                    <div class="col-xs-9 text-right">
                        <div class="huge"></div> 
                        <br>
                        <div>Profile!</div>
                    </div>
                </div>
            </div>
            <a href="profile">
                <div class="panel-footer">
                    <span class="pull-left">View profile details</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <!-- Booking History Panel -->
    <div class="col-lg-3 col-md-6">
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
            <a href="booking  ">
                <div class="panel-footer">
                    <span class="pull-left">View booking history</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <!-- Submit Concerns Panel -->
    <div class="col-lg-3 col-md-6">
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
            <a href="issue">
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
    <div class="col-lg-8">
        <div class="panel panel-default">
            <div class="panel-heading">
                <i class="fa fa-bar-chart-o fa-fw"></i> Current booking
                <div class="pull-right">
                    <div class="btn-group">                     
                    </div>
                </div>
            </div>
            <div class="panel-body">       
                <div class="col-lg-8">
                    <div id="bookings">Bookings Data</div>
                </div>
            </div>
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
                    <br>
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
                <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8&libraries=geometry"></script>
    <script src="/Theme/js/map-features.js"></script>
        </div>
    </div>
</div>

</asp:Content>
