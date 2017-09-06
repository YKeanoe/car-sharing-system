<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs"  Inherits="car_sharing_system.Admin_Theme.pages.register" %>
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
                                             ControlToValidate="userRego" ForeColor="Red" ErrorMessage="Please enter username." />
                                            <br />

                                            <label>Email</label>
                                            <br>
                                             <asp:TextBox ID=emailRego runat="server"></asp:TextBox> 
                                            <br>
                                             <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                             ControlToValidate="emailRego" ForeColor="Red" ErrorMessage="Invalid email address." />
                                            <br />

                                            <label>Password</label>
                                            <br>
                                             <asp:TextBox ID="passwordRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                             ControlToValidate="passwordRego" ForeColor="Red" ErrorMessage="Enter password." />
                                            <br />

                                              <label>License Number</label> 
                                            <br>
                                             <asp:TextBox ID="licenseRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="^[0-9]"
                                             ControlToValidate="licenseRego" ForeColor="Red" ErrorMessage="Invalid license number." />
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

                                            <label>Gender</label> 
                                            <br>
                                             <asp:RadioButtonList id=RadioButtonList1 runat="server">
                                             <asp:ListItem>Male</asp:ListItem>
                                               <asp:ListItem>Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <br>
                                            
                                            <br />
                                    
                                       <label>Birth</label> 
                                            <br>
                                             <asp:TextBox ID="BirthRego" runat="server" placeholder="dd/mm/yy"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
                                                runat="server" Display="Dynamic" 
                                             ControlToValidate="BirthRego" ForeColor="Red" ErrorMessage="Enter birth." />
                                            <br />
                                         

                                            <label>Phone Number</label>
                                            <br>
                                            <asp:TextBox ID="phoneNoRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="^[0-9]"
                                             ControlToValidate="phoneNoRego" ForeColor="Red" ErrorMessage="Invalid phone number." />
                                            
                                              <br>


                                             <label>Street address</label>
                                            <br>
                                            <asp:TextBox ID="StreetRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 
                                             ControlToValidate="StreetRego" ForeColor="Red" ErrorMessage="Enter street address." />
                                            
                                              <br>

                                             
                                             <label>Suburb</label>
                                            <br>
                                            <asp:TextBox ID="suburbRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                             ControlToValidate="suburbRego" ForeColor="Red" ErrorMessage="Enter suburb." />
                                            
                                              <br>

                                            <label>Post code</label>
                                            <br>
                                            <asp:TextBox ID="postRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                                 ValidationExpression="^[0-9]"
                                             ControlToValidate="postRego" ForeColor="Red" ErrorMessage="Enter postcode." />
                                            
                                              <br>


                                             <label>Territory</label>
                                            <br>
                                            <asp:TextBox ID="terrRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                             ControlToValidate="terrRego" ForeColor="Red" ErrorMessage="Enter territory." />
                                            
                                              <br>

                                             <label>City</label>
                                            <br>
                                            <asp:TextBox ID="cityRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                             ControlToValidate="cityRego" ForeColor="Red" ErrorMessage="Enter city." />
                                            
                                              <br>

                                             <label>Profile URL</label>
                                            <br>
                                            <asp:TextBox ID="urlRego" runat="server"></asp:TextBox> 
                                            <br>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" 
                                             ControlToValidate="urlRego" ForeColor="Red" ErrorMessage="Invalid URL." />
                                            
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
