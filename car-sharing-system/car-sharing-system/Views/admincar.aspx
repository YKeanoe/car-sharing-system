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
                                                    <span>Brand: </span> 
                                                </div>
                                                <div class="cell twocol">
                                                     <span>Model: </span>
                                                </div>
                                                <div class="cell threecol">
                                                     <span>Vehicle Type: </span>
                                                </div>

                                                <div class="cell fourcol">
                                                     <span>Seats : </span>
                                                </div>

                                                <div class="cell fivecol">
                                                     <span>Doors: </span>
                                                </div>

                                                <div class="cell sixcol">
                                                     <span>Transmission: </span>
                                                </div>

                                                <div class="cell sevencol">
                                                     <span>Fuel Type: </span> 
                                                </div>

                                                <div class="cell eightcol">
                                                     <span>Tank Size: </span> 
                                                </div>

                                                 <div class="cell ninecol">
                                                     <span>Fuel Consumption: </span>
                                                </div>

                                                 <div class="cell tencol">
                                                     <span>Average Range: </span>
                                                </div>

                                                 <div class="cell elevencol">
                                                     <span>Hourly Rate: </span> 
                                                </div>

                                                <div class="cell twelvecol">
                                                     <span>Status: </span>
                                                </div>

                                                <div class="cell thirteencol">
                                                     <span>CD Player: </span>
                                                </div>

                                                <div class="cell fourteencol">
                                                     <span>Radio: </span>
                                                </div>

                                                <div class="cell fifthteencol">
                                                     <span>GPS: </span>
                                                </div>

                                                <div class="cell sixthteencol">
                                                     <span>Bluetooth: </span>
                                                </div>

                                                <div class="cell seventeencol">
                                                     <span>Cruise Control: </span>
                                                </div>

                                                <div class="cell eighteencol">
                                                     <span>Reverse Camera: </span>
                                                </div>
                                                <input type="submit" value="Edit Car Details"  class="btn btn-info">
  
                                                <input type="submit" value="View Car Booking History"  class="btn btn-info">
                                                </div>
                                                    

                                
                            
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
