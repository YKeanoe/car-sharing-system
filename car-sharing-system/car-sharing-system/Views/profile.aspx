<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.profile" %>
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
                            <div id="showData"  runat="server">
                                <div class="field1">
                                    <label id="firstName">First Name: </label><%=newUser.fname%>
                                </div>
                                 
                                <div class="field2">
                                    <label id="lastName">Last Name: </label><%=newUser.lname %>
                                </div>

                                <div class="field3">
                                    <label id="licenseNo">License Number: </label><%=newUser.licenseNo %>
                                </div>

                                <div class="field4">
                                    <label id="birth">Date of Birth: </label><%=newUser.birth %>
                                </div>

                                <div class="field5">
                                    <label id="gender">Gender: </label><%=newUser.gender %>
                                </div>

                                <div class="field6">
                                    <label id="phone">Phone: </label><%=newUser.phone %>
                                </div>

                                <div class="field7"> 
                                    <label id="street">Street: </label><%=newUser.street %>
                                </div>

                                <div class="field8">
                                    <label id="suburb">Suburb: </label><%=newUser.suburb %>
                                </div>

                                <div class="field9">
                                     <label id="postcode">Postcode: </label><%=newUser.postcode %>
                                </div>

                                <div class="field10">
                                     <label id="territory">Territory: </label><%=newUser.territory %>
                                </div>

                                <div class="field11">
                                     <label id="city">City: </label><%=newUser.city %>
                                </div>

                                <div class="field12">
                                     <label id="country">Country: </label><%=newUser.country %>
                                </div>

                                <div class="field13">
                                     <label id="profileURL">ProfileURL: </label><%=newUser.profileURL %>
                                </div>
                                <img src='<%=newUser.profileURL%>'/>
                                <a class="btn btn-info" id="edit" href="/dashboard/profile?edit=1">Edit</a>
                            </div>
                            <form id="updateform" runat="server">
                                               
                                  <div class="field1">
                                    <label id="firstName">First Name: </label><input type="text" name="firstname" value="<%=newUser.fname%>">
                                </div>
                                 
                                <div class="field2">
                                    <label id="lastName">Last Name: </label><input type="text" name="lastname" value="<%=newUser.lname %>">
                                </div>

                                <div class="field3">
                                    <label id="licenseNo">License Number: </label><input type="text" name="licenseNo" value="<%=newUser.licenseNo %>">
                                </div>

                                <div class="field4">
                                    <label id="birth">Date of Birth: </label><input type="text" name="birth" value="<%=newUser.birth %>">
                                </div>

                                <div class="field5">
                                    <label id="gender">Gender: </label><input type="text" name="gender" value="<%=newUser.gender %>">
                                </div>

                                <div class="field6">
                                    <label id="phone">Phone: </label><input type="text" name="phone" value="<%=newUser.phone %>">
                                </div>

                                <div class="field7"> 
                                    <label id="street">Street: </label><input type="text" name="street" value="<%=newUser.street %>">
                                </div>

                                <div class="field8">
                                    <label id="suburb">Suburb: </label><input type="text" name="suburb" value="<%=newUser.suburb %>">
                                </div>

                                <div class="field9">
                                     <label id="postcode">Postcode: </label><input type="text" name="postcode" value="<%=newUser.postcode %>">
                                </div>

                                <div class="field10">
                                     <label id="territory">Territory: </label><input type="text" name="territory" value="<%=newUser.territory %>">
                                </div>

                                <div class="field11">
                                     <label id="city">City: </label><input type="text" name="city" value="<%=newUser.city %>">
                                </div>

                                <div class="field12">
                                     <label id="country">Country: </label><input type="text" name="country" value="<%=newUser.country %>">
                                </div>

                                <div class="field13">
                                     <label id="profileURL">ProfileURL: </label><input type="text" name="profileURL" value="<%=newUser.profileURL %>">
                                </div>
                                <br>
                                <div class="submit1">
                                 <input type="submit" value="Submit" OnClick="Button1_Click" class="btn btn-primary">
                                    </div>
                             </form>

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
