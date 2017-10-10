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
                                   <div class="p1">Profile!</div>
                                </div>
                            </div>
                        </div>
                        <a href="/dashboard/profile">
                            <div class="panel-footer">
                                <span class="pull-left">View profile!</span>
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
                        <a href="/dashboard/booking">
                            <div class="panel-footer">
                                <span class="pull-left">View booking!</span>
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
                        <a href="/dashboard/issue">
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
   
                            <h2 id="updated" runat="server"></h2>
                            <div class="form-group">
                                <div id="showData"  runat="server">
                                <div class="formFormat">
                                    <label class="label2">First Name: </label>
                                    <span id="fN" runat="server"></span>
                                </div>
                                <div >
                                    <label class="label2">Last Name: </label><span id="lN" runat="server"></span>
                                </div>
                                <div class="formFormat">
                                    <label class="label2">License Number: </label><span id="LiN" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Date of Birth: </label><span id="dob" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Gender: </label><span id="gen" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Phone: </label><span id="ph" runat="server"></span>
                                </div>

                                <div class="formFormat"> 
                                    <label class="label2">Street: </label><span id="st" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Suburb: </label><span id="sb" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                     <label class="label2">Postcode: </label><span id="pc" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                     <label class="label2">Territory: </label><span id="ter" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                     <label class="label2">City: </label><span id="ci" runat="server"></span>
                                </div>

                                <div class="formFormat">
                                     <label class="label2">Country: </label><span id="co" runat="server"></span>
                                </div>
                                    <a class="editb" id="edit" href="/dashboard/profile?edit=<%=theID %>">Edit</a>
                                    <br />

                                <img id="pu" src="" runat="server"/>

                                
                            </div>

                            <form id="updateform" runat="server">
                                               
                                <div class="formFormat">
                                    <label class="label2">First Name: </label>
                                    <asp:TextBox  name="firstname" id="edfirstname" runat="server" ></asp:TextBox>
                                </div>
                                 
                                <div class="formFormat">
                                    <label class="label2">Last Name: </label>
                                    <asp:TextBox  name="lastname" id="edlastname" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">License Number: </label>
                                    <asp:TextBox  name="licenseNo" id="edlicenseNo" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Date of Birth: </label>
                                    <asp:TextBox  name="birth" id="edbirth" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Gender: </label>
                                    <asp:TextBox  name="gender" id="edgender" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Phone: </label>
                                    <asp:TextBox  name="phone" id="edphone" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat"> 
                                    <label class="label2">Street: </label>
                                    <asp:TextBox  name="street" id="edstreet" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Suburb: </label>
                                    <asp:TextBox  name="suburb" id="edsuburb" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Postcode: </label>
                                    <asp:TextBox  name="postcode" id="edpostcode" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Territory: </label>
                                    <asp:TextBox  name="territory" id="edterritory" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">City: </label>
                                    <asp:TextBox  name="city" id="edcity" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                     <label class="label2">Country: </label>
                                     <asp:TextBox  name="country" id="edcountry" runat="server"></asp:TextBox>
                                </div>

                                <div class="last">
                                     <label  class="label2" >ProfileURL: </label>
                                    <asp:TextBox id="edprofileURL" runat="server"></asp:TextBox>
                                    <img src="" id="eprofileIMG" runat="server"/>
                                </div>

                                <br>

                                <div class="submit1">
                                    <asp:Button runat="server" Text="Submit" OnClick="submit" class="btn btn-primary"></asp:Button>
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
