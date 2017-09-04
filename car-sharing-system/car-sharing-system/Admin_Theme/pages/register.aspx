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

          <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>


                            <div class="row">
                                </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Username</label> 
                                            <br>
                                             <asp:TextBox ID="User" runat="server"></asp:TextBox> 
                                            <br />

                                            <label>Email</label>
                                            <br>
                                             <asp:TextBox ID="Email" runat="server"></asp:TextBox> 
                                            <br>
                                             <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                             ControlToValidate="Email" ForeColor="Red" ErrorMessage="Invalid email address." />
                                            <br />

                                            <label>First Name</label> 
                                            <br>
                                             <asp:TextBox ID="First" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="First"
                                                 ErrorMessage="Please enter your first name"   
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />

                                            <label>Last Name</label>
                                            <br>
                                             <asp:TextBox ID="lastName" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RequiredFieldValidator ID="lastNameValidator" runat="server"   
                                                ControlToValidate="lastName" ErrorMessage="Please enter your last name"   
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />

                                            <label>License Number</label> 
                                            <br>
                                             <asp:TextBox ID="license" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="^[0-9]"
                                             ControlToValidate="license" ForeColor="Red" ErrorMessage="Invalid license number." />
                                            <br />
                                    
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Password</label>
                                            <br>
                                             <asp:TextBox ID="password" runat="server"></asp:TextBox> 
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                             ControlToValidate="license" ForeColor="Red" ErrorMessage="Enter password." />
                                            <br />


                                         

                                            <label>Phone Number</label>
                                            <br>
                                            <asp:TextBox ID="phoneNo" runat="server"></asp:TextBox> 
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="^[0-9]"
                                             ControlToValidate="phoneNo" ForeColor="Red" ErrorMessage="Invalid phone number." />
                                            <br />
                                              <br>
                                            <asp:Button ID="Button1" runat="server" Text="Register" class="btn btn-primary"></asp:Button>
                                                <br/>
                                            
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
