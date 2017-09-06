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
                                             <asp:TextBox ID="userRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic"
                                             ControlToValidate="userrego" ForeColor="Red" ErrorMessage="Please enter username." />
                                            <br />

                                            <label>Email</label>
                                            <br>
                                             <asp:TextBox ID=emailRego runat="server"></asp:TextBox> 
                                            <br>
                                             <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                             ControlToValidate="emailRego" ForeColor="Red" ErrorMessage="Invalid email address." />
                                            <br />

                                            <label>First Name</label> 
                                            <br>
                                             <asp:TextBox ID="firstRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="firstRego"
                                                 ErrorMessage="Please enter your first name"   
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />

                                            <label>Last Name</label>
                                            <br>
                                             <asp:TextBox ID="lastNameRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RequiredFieldValidator ID="lastNameValidator" runat="server"   
                                                ControlToValidate="lastNameRego" ErrorMessage="Please enter your last name"   
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                            <br />

                                            <label>License Number</label> 
                                            <br>
                                             <asp:TextBox ID="licenseRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="^[0-9]"
                                             ControlToValidate="licenseRego" ForeColor="Red" ErrorMessage="Invalid license number." />
                                            <br />
                                    
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label>Password</label>
                                            <br>
                                             <asp:TextBox ID="passwordRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                             ControlToValidate="passwordRego" ForeColor="Red" ErrorMessage="Enter password." />
                                            <br />


                                         

                                            <label>Phone Number</label>
                                            <br>
                                            <asp:TextBox ID="phoneNoRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="^[0-9]"
                                             ControlToValidate="phoneNoRego" ForeColor="Red" ErrorMessage="Invalid phone number." />
                                            
                                              <br>
                                            <asp:Button ID="Button1" runat="server" Text="Register" class="btn btn-primary"></asp:Button>
                                                
                                            
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                   
                </div>
              
                <div class="col-lg-8">
                    
                </div>
               
      
</asp:Content>
