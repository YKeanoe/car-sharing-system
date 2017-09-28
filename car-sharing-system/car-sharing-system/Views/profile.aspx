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
                      

                        <div class="panel-body">
   
                            
                                        <div class="form-group">
                            <div id="showData"  runat="server">
                                <div >
                                    <label id="firstName">First Name: </label><span></span>
                                </div>
                                 
                                <div >
                                    <label id="lastName">Last Name: </label><span></span>
                                </div>

                                <div >
                                    <label id="licenseNo">License Number: </label><span></span>
                                </div>

                                <div >
                                    <label id="birth">Date of Birth: </label><span></span>
                                </div>

                                <div >
                                    <label id="gender">Gender: </label><span></span>
                                </div>

                                <div >
                                    <label id="phone">Phone: </label><span></span>
                                </div>

                                <div > 
                                    <label id="street">Street: </label><span></span>
                                </div>

                                <div >
                                    <label id="suburb">Suburb: </label><span></span>
                                </div>

                                <div >
                                     <label id="postcode">Postcode: </label><span></span>
                                </div>

                                <div >
                                     <label id="territory">Territory: </label><span></span>
                                </div>

                                <div >
                                     <label id="city">City: </label><span></span>
                                </div>

                                <div >
                                     <label id="country">Country: </label><span></span>
                                </div>

                                <div class="last">
                                     <label id="profileURL">ProfileURL: </label><span></span>
                                </div>
                                <img src='<%=newUser.profileURL%>'/>
                                <a class="btn btn-info" id="edit" href="/dashboard/profile?edit=1">Edit</a>
                            </div>

                            <form id="updateform" runat="server">
                                               
                                <div >
                                    <label class="label">First Name: </label><input type="text" name="firstname" value="<%=newUser.fname%>"/>
                                </div>
                                 
                                <div >
                                    <label class="label">Last Name: </label><input type="text" name="lastname" value="<%=newUser.lname %>"/>
                                </div>

                                <div >
                                    <label class="label">License Number: </label><input type="text" name="licenseNo" value="<%=newUser.licenseNo %>"/>
                                </div>

                                <div >
                                    <label class="label">Date of Birth: </label><input type="text" name="birth" value="<%=newUser.birth %>"/>
                                </div>

                                <div >
                                    <label class="label">Gender: </label><input type="text" name="gender" value="<%=newUser.gender %>"/>
                                </div>

                                <div >
                                    <label class="label">Phone: </label><input type="text" name="phone" value="<%=newUser.phone %>"/>
                                </div>

                                <div > 
                                    <label class="label">Street: </label><input type="text" name="street" value="<%=newUser.street %>"/>
                                </div>

                                <div >
                                    <label class="label">Suburb: </label><input type="text" name="suburb" value="<%=newUser.suburb %>"/>
                                </div>

                                <div >
                                     <label class="label">Postcode: </label><input type="text" name="postcode" value="<%=newUser.postcode %>"/>
                                </div>

                                <div >
                                     <label class="label">Territory: </label><input type="text" name="territory" value="<%=newUser.territory %>"/>
                                </div>

                                <div >
                                     <label class="label">City: </label><input type="text" name="city" value="<%=newUser.city %>"/>
                                </div>

                                <div >
                                     <label class="label">Country: </label><input type="text" name="country" value="<%=newUser.country %>"/>
                                </div>

                                <div class="last">
                                     <label  class="label" >ProfileURL: </label><input runat="server" type="text"  name="profileURL" />
                                    <img src="<%=newUser.profileURL %>"/>
                                </div>
                                 <input type="submit" value="Submit" OnClick="Button1_Click" class="btn btn-info">
                                     <label id="profileImg">ProfileURL: </label>
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
