<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="adminusersview.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.adminusersview" %>
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
                    <div class="panel panel-primary">
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
                            <i class="fa fa-user fa-fw"></i> Account ID <%=newUser.id%>
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
                                <form id="updateform" runat="server">
                                               
                                  <div class="field1">
                                    <label id="labelBox">First Name: </label><input type="text" id="firstname" name="firstname" value="<%=newUser.fname%>">
                                </div>
                                 
                                <div class="field2">
                                    <label id="labelBox">Last Name: </label><input type="text" id="lastname" name="lastname" value="<%=newUser.lname %>">
                                </div>

                                <div class="field3">
                                    <label id="labelBox">Licence Number: </label><input type="text" id="licenceNo" name="licenceNo" value="<%=newUser.licenceNo %>">
                                </div>

                                <div class="field4">
                                    <label id="labelBox">Date of Birth: </label><input type="text" id="birth" name="birth" value="<%=newUser.birth %>">
                                </div>

                                <div class="field5">
                                    <label id="labelBox">Gender: </label><input type="text" id="gender" name="gender" value="<%=newUser.gender %>">
                                </div>

                                <div class="field6">
                                    <label id="labelBox">Phone: </label><input type="text" id="phone" name="phone" value="<%=newUser.phone %>">
                                </div>

                                <div class="field7"> 
                                    <label id="labelBox">Street: </label><input type="text" id="street" name="street" value="<%=newUser.street %>">
                                </div>

                                <div class="field8">
                                    <label id="labelBox">Suburb: </label><input type="text" id="suburb" name="suburb" value="<%=newUser.suburb %>">
                                </div>

                                <div class="field9">
                                     <label id="labelBox">Postcode: </label><input type="text" id="postcode" name="postcode" value="<%=newUser.postcode %>">
                                </div>

                                <div class="field10">
                                     <label id="labelBox">Territory: </label><input type="text" id="territory" name="territory" value="<%=newUser.territory %>">
                                </div>

                                <div class="field11">
                                     <label id="labelBox">City: </label><input type="text" id="city" name="city" value="<%=newUser.city %>">
                                </div>

                                <div class="field12">
                                     <label id="labelBox">Country: </label><input type="text" id="country" name="country" value="<%=newUser.country %>">
                                </div>

                                <div class="field13">
                                     <label id="labelBox">ProfileURL: </label><input type="text" id="profileURL" name="profileURL" value="<%=newUser.profileURL %>">
                                </div>

                             </form>
                                            <input type="submit" value="Submit"  class="btn btn-info"></p>
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

