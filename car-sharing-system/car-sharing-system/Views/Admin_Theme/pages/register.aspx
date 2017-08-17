<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i> Login
                            <div class="pull-right">
                                
                                <div class="btn-group">


                                </div>
                               
                            </div>
                            
                        </div>


                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="row">
                                <form role="form">
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Username</label>
                                            <input class="form-control" placeholder="Username" />
                                            <br />

                                            <label>Email</label>
                                            <input class="form-control" placeholder="Email" />
                                            <br />

                                            <label>First Name</label>
                                            <input class="form-control" placeholder="First Name" />
                                            <br />

                                            <label>License Number</label>
                                            <input class="form-control" placeholder="License Number" />
                                            <br />
                                    
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Password</label>
                                            <input class="form-control" placeholder="Password" />
                                            <br />

                                            <label>Password Again</label>
                                            <input class="form-control" placeholder="Password Again" />
                                            <br />

                                            <label>Last Name</label>
                                            <input class="form-control" placeholder="Last Name" />
                                            <br />

                                            <label>Phone Number</label>
                                            <input class="form-control" placeholder="Phone Number" />
                                            <br />

                                            <a href="/Admin_Theme/pages/successregister.aspx" class="btn btn-primary">
                                                Register
                                            </a>
                                        </div>
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
                    <div id="morris-bar-chart"></div>
                </div>
                <!-- /.col-lg-8 (nested) -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.panel-body -->
    </div>
</asp:Content>
