<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                         

                        

                              <form id="updateform" runat="server">
            
                            
                                        <div class="form-group">

                                               

                            <asp:TextBox class="form-control" placeholder="FirstName" id="fn" value="fn"runat="server"></asp:TextBox>

                            <asp:Label ID="fn" runat="server" Text="First name: "></asp:Label><br />
                            <asp:Label ID="ln" runat="server" Text="Last name: "></asp:Label><br />
                            <asp:Label ID="licenceNo" runat="server" Text="Licence Number: "></asp:Label><br />
                            <asp:Label ID="birth" runat="server" Text="Date of birth: "></asp:Label><br />
                            <asp:Label ID="gender" runat="server" Text="Gender: "></asp:Label><br />
                            <asp:Label ID="phone" runat="server" Text="Phone: "></asp:Label><br />
                            <asp:Label ID="street" runat="server" Text="Street: "></asp:Label><br />
                            <asp:Label ID="suburb" runat="server" Text="Suburb: "></asp:Label><br />
                            <asp:Label ID="postcode" runat="server" Text="Postcode: "></asp:Label><br />
                            <asp:Label ID="territory" runat="server" Text="Territory: "></asp:Label><br />
                            <asp:Label ID="city" runat="server" Text="City: "></asp:Label><br />
                            <asp:Label ID="country" runat="server" Text="Country: "></asp:Label><br />
                            <asp:Label ID="profileURL" runat="server" Text="ProfileURL: "></asp:Label><br />






                                           <a href="/dashboard/update" class="btn btn-info">
                                                Edit
                                            </a>
                                        </div>
                        </div>
              
                            </form>


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
    </div>

</asp:Content>
