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
                                <p>First Name: <%=newUser.fname%></p>
                                <p>Last Name: <%=newUser.lname%></p>
                                <p>license Number: <%=newUser.licenseNo%></p>
                                <p>Date of Birth: <%=newUser.birth%></p>
                                <p>license Number: <%=newUser.licenseNo%></p>
                                <p>gender: <%=newUser.gender%></p>
                                <p>phone: <%=newUser.phone%></p>
                                <p>street: <%=newUser.street%></p>
                                <p>suburb: <%=newUser.suburb%></p>
                                <p>postcode: <%=newUser.postcode%></p>
                                <p>territory: <%=newUser.territory%></p>
                                <p>city: <%=newUser.city%></p>
                                <p>country: <%=newUser.country%></p>
                                <img src='<%=newUser.profileURL%>'/>
                                <a class="btn btn-info" id="edit" href="/dashboard/profile?edit=1">Edit</a>
                            </div>
                            <form id="updateform" runat="server">
                                               
                                  <div class="field1">
                                    <label  >First Name: </label><input type="text" id="firstname" name="firstname" value="<%=newUser.fname%>">
                                </div>
                                 
                                <div class="field2">
                                    <label  >Last Name: </label><input type="text" id="lastname" name="lastname" value="<%=newUser.lname %>">
                                </div>

                                <div class="field3">
                                    <label  >license Number: </label><input type="text" id="licenseNo" name="licenseNo" value="<%=newUser.licenseNo %>">
                                </div>

                                <div class="field4">
                                    <label  >Date of Birth: </label><input type="text" id="birth" name="birth" value="<%=newUser.birth %>">
                                </div>

                                <div class="field5">
                                    <label  >Gender: </label><input type="text" id="gender" name="gender" value="<%=newUser.gender %>">
                                </div>

                                <div class="field6">
                                    <label  >Phone: </label><input type="text" id="phone" name="phone" value="<%=newUser.phone %>">
                                </div>

                                <div class="field7"> 
                                    <label  >Street: </label><input type="text" id="street" name="street" value="<%=newUser.street %>">
                                </div>

                                <div class="field8">
                                    <label  >Suburb: </label><input type="text" id="suburb" name="suburb" value="<%=newUser.suburb %>">
                                </div>

                                <div class="field9">
                                     <label  >Postcode: </label><input type="text" id="postcode" name="postcode" value="<%=newUser.postcode %>">
                                </div>

                                <div class="field10">
                                     <label  >Territory: </label><input type="text" id="territory" name="territory" value="<%=newUser.territory %>">
                                </div>

                                <div class="field11">
                                     <label  >City: </label><input type="text" id="city" name="city" value="<%=newUser.city %>">
                                </div>

                                <div class="field12">
                                     <label  >Country: </label><input type="text" id="country" name="country" value="<%=newUser.country %>">
                                </div>

                                <div class="field13">
                                     <label  >ProfileURL: </label><input type="text" id="profileURL" name="profileURL" value="<%=newUser.profileURL %>">
                                </div>
                                 <input type="submit" value="Submit" OnClick="Button1_Click" class="btn btn-info">
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
