<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="admincar.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.admincar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

 <!-- /.row -->
            <div class="row">
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
                                    <div>Users!</div>
                                </div>
                            </div>
                        </div>
                        <a href="adminusers.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View users</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-car fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"></div>
                                    <br>
                                    <div>Car history!</div>
                                </div>
                            </div>
                        </div>
                        <a href="admincar.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View cars</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-bar-chart-o fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <br>
                                    <div>View Issues!</div>
                                </div>
                            </div>
                        </div>
                        <a href="adminissue.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View issues</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
  
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i> Number Plate:
                            <div class="pull-right">
                                
                                <div class="btn-group">
                                    


                                </div>
                               
                            </div>
                            
                        </div>


                        <!-- /.panel-heading -->
                      
                      <asp:Label ID="Label1" runat="server" ></asp:Label>

                        <div class="panel-body">
                            <div class="table">
                                            <div class="row">
                                                <div class="cell onecol">
                                                    <span>First Name: </span> 
                                                </div>
                                                <div class="cell twocol">
                                                     <span>Last Name: </span>
                                                </div>
                                                <div class="cell threecol">
                                                     <span>Licence Number: </span>
                                                </div>

                                                <div class="cell fourcol">
                                                     <span>Date of Birth: </span>
                                                </div>

                                                <div class="cell fivecol">
                                                     <span>Gender: </span>
                                                </div>

                                                <div class="cell sixcol">
                                                     <span>Phone: </span>
                                                </div>

                                                <div class="cell sevencol">
                                                     <span>Street: </span> 
                                                </div>

                                                <div class="cell eightcol">
                                                     <span>Suburb: </span> 
                                                </div>

                                                 <div class="cell ninecol">
                                                     <span>Postcode: </span>
                                                </div>

                                                 <div class="cell tencol">
                                                     <span>Territory: </span>
                                                </div>

                                                 <div class="cell elevencol">
                                                     <span>City: </span> 
                                                </div>

                                                <div class="cell twelvecol">
                                                     <span>Country: </span>
                                                </div>

                                                <input type="submit" value="Edit User Details"  class="btn btn-info">
  
                                                <input type="submit" value="View Booking History"  class="btn btn-info">
                                                </div>
                                                    

                                	numberPlate varchar(6) NOT NULL PRIMARY KEY,
	locationLat decimal(12,9) NULL,
	locationLong decimal(12,9) NULL,
	country varchar(50) NULL,
	brand varchar(50) NULL,
	model varchar(50) NULL,
	vehicleType varchar(20) NULL,
	seats varchar(2) NULL,
	doors varchar(2) NULL,
	transmission varchar(20) NULL,
	fuelType varchar(20) NULL,
	tankSize varchar(20) NULL,
	fuelConsumption varchar(20) NULL,
	averageRange varchar(20) NULL,
	hourlyRate varchar (2) NULL,
	status boolean NULL,
	cdPlayer boolean NULL,
	radio boolean NULL,
	gps boolean NULL,
	bluetooth boolean NULL
   
                            
                          </div>
                        </div>


                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                    <!-- /.panel-heading -->
                    <!-- /.table-responsive -->
                </div>
                <!-- /.col-lg-4 (nested) -->
                <div class="col-lg-8">
                    
                <!-- /.col-lg-8 (nested) -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.panel-body -->
   

</asp:Content>
