<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profileedit.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.profileedit" %>
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
                                    <label id="labelBox">First Name: </label><input type="text" id="labelFormatter" name="firstname" value="<%=fn %>">
                                </div>

                                <div class="field2">
                                    <label id="labelBox">Last Name: </label><input type="text" id="labelFormatter" name="lastname" value="<%=ln %>">
                                </div>

                                <div class="field3">
                                    <label id="labelBox">Licence Number: </label><input type="text" id="labelFormatter" name="licenceNo" value="<%=licenceNo %>">
                                </div>

                                <div class="field4">
                                    <label id="labelBox">Date of Birth: </label><input type="text" id="labelFormatter" name="birth" value="<%=birth %>">
                                </div>

                                <div class="field5">
                                    <label id="labelBox">Gender: </label><input type="text" id="labelFormatter" name="gender" value="<%=gender %>">
                                </div>

                                <div class="field6">
                                    <label id="labelBox">Phone: </label><input type="text" id="labelFormatter" name="phone" value="<%=phone %>">
                                </div>

                                <div class="field7"> 
                                    <label id="labelBox">Street: </label><input type="text" id="labelFormatter" name="street" value="<%=street %>">
                                </div>

                                <div class="field8">
                                    <label id="labelBox">Suburb: </label><input type="text" id="labelFormatter" name="suburb" value="<%=suburb %>">
                                </div>

                                <div class="field9">
                                     <label id="labelBox">Postcode: </label><input type="text" id="labelFormatter" name="postcode" value="<%=postcode %>">
                                </div>

                                <div class="field10">
                                     <label id="labelBox">Territory: </label><input type="text" id="labelFormatter" name="territory" value="<%=territory %>">
                                </div>

                                <div class="field11">
                                     <label id="labelBox">City: </label><input type="text" id="labelFormatter" name="city" value="<%=city %>">
                                </div>

                                <div class="field12">
                                     <label id="labelBox">Country: </label><input type="text" id="labelFormatter" name="country" value="<%=country %>">
                                </div>

                                <div class="field13">
                                     <label id="labelBox">ProfileURL: </label><input type="text" id="labelFormatter" name="profileURL" value="<%=profileURL %>">
                                </div>

                             </form>




                                           <a href="/dashboard/update" class="btn btn-info">
                                                Submit
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
