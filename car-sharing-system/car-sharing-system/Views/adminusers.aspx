﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

 <!-- /.row -->
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
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
                                <span class="pull-left">View Details</span>
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
                                    <i class="fa fa-tasks fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"></div>
                                    <br>
                                    <div>Booking history!</div>
                                </div>
                            </div>
                        </div>
                        <a href="booking">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
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
                                    <div>View kms!</div>
                                </div>
                            </div>
                        </div>
                        <a href="detail">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span>
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
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i> My Account Information
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
                                                <div class="cell twocol">
                                                    <span>First Name</span>
                                                </div>
                                                <div class="cell twocol">
                                                     <span>Last Name</span>
                                                </div>
                                                <div class="cell twocol">
                                                     <span>Licence Number</span>
                                                </div>

                                                <div class="cell twocol">
                                                     <span>Date of Birth</span>
                                                </div>

                                                <div class="cell twocol">
                                                     <span>Gender</span>
                                                </div>

                                                <div class="cell twocol">
                                                     <span>Phone</span>
                                                </div>

                                                <div class="cell twocol">
                                                     <span>Street</span>
                                                </div>

                                                <div class="cell twocol">
                                                     <span>Suburb</span>
                                                </div>

                                                 <div class="cell twocol">
                                                     <span>Postcode</span>
                                                </div>

                                                 <div class="cell twocol">
                                                     <span>Territory</span>
                                                </div>

                                                 <div class="cell twocol">
                                                     <span>City</span>
                                                </div>

                                                <div class="cell twocol">
                                                     <span>Country</span>
                                                </div>

                                                <div class="cell twocol">
                                                     <span>ProfileURL</span>
                                                </div>

                                                </div>
                                                    
                                            <div class="row">
                                                <div class="cell onecol">
                                                <span>Content3</span>
                                               </div>
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

