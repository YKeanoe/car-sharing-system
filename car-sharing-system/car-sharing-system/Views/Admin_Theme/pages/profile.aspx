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
   
                            
                                        <div class="form-group">
                            <form id="updateform" runat="server">
                                               
                                 <div class="field1">
                                    <span>First Name: <%=fn%> </span ><br />
                                </div>

                                <div class="field2">
                                    <span>Last Name: </span> <asp:Label ID="ln" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field3">
                                    <span>Licence Number: </span> <asp:Label ID="licenceNo" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field4">
                                    <span>Date of Birth: </span> <asp:Label ID="birth" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field5">
                                    <span>Gender: </span> <asp:Label ID="gender" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field6">
                                    <span>Phone: </span> <asp:Label ID="phone" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field7"> 
                                    <span>Street: </span> <asp:Label ID="street" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field8">
                                    <span>Suburb: </span> <asp:Label ID="suburb" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field9">
                                     <span>Postcode: </span> <asp:Label ID="postcode" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field10">
                                     <span>Territory: </span> <asp:Label ID="territory" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field11">
                                     <span>City: </span> <asp:Label ID="city" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field12">
                                     <span>Country: </span> <asp:Label ID="country" runat="server" ></asp:Label><br />
                                </div>

                                <div class="field13">
                                     <span>ProfileURL: </span> <asp:Label ID="profileURL" runat="server" ></asp:Label><br />
                                </div>

                             </form>




                                           <a href="/dashboard/update" class="btn btn-info">
                                                Edit
                                            </a>
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
