<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs"  Inherits="car_sharing_system.Admin_Theme.pages.login" %>
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
                             <form id="form1" runat="server">  
                            <div class="row">
                                </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Username</label>
                                             <asp:TextBox ID="User" runat="server"></asp:TextBox> 
                                            <br />

                                            <label>Email</label>
                                             <asp:TextBox ID="Email" runat="server"></asp:TextBox> 
                                            <br />

                                            <label>First Name</label>
                                             <asp:TextBox ID="First" runat="server"></asp:TextBox> 
                                            <br />

                                            <label>License Number</label>
                                             <asp:TextBox ID="License" runat="server"></asp:TextBox> 
                                            <br />
                                    
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Password</label>
                                             <asp:TextBox ID="Password" runat="server"></asp:TextBox> 
                                            <br />


                                            <label>Last Name</label>
                                             <asp:TextBox ID="Lastname" runat="server"></asp:TextBox> 
                                            <br />

                                            <label>Phone Number</label>
                                            <asp:TextBox ID="PhoneNo" runat="server"></asp:TextBox> 
                                            <br />

                                            <asp:Button ID="Button1" runat="server" Text="Register" ></asp:Button>
                                                
                                            
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
      
</asp:Content>
