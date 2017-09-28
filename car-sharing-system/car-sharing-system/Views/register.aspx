<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs"  Inherits="car_sharing_system.Admin_Theme.pages.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
    <div class="col-lg-8">
        <div class="panel panel-default">
            <div class="panel-heading">
                <i class="fa fa-user fa-fw"></i> Login
                <div class="pull-right">
                    <div class="btn-group"></div>
                </div>        
            </div>
            
            <!-- /.panel-heading -->
            <div class="panel-body">
                <form id="form1" runat="server">  
                    <div class="form-group"> 
                            <!-- Email Label -->
                        <div class = "emailRego">
                            <label class="label2">Email:</label>
                            <asp:TextBox Type="email" ID="emailRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="emailRego" ForeColor="Red" ErrorMessage="Invalid email address."></asp:RequiredFieldValidator>
                                </div>
                       
                            <!-- Password Label -->
                            <div class = "passwordRego">
                            <label class="label2">Password:</label>
                            <asp:TextBox ID="passwordRego" runat="server" Type="password"></asp:TextBox> 
                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="passwordRego"
                                ValidationExpression="[0-9]{1,}[a-z]{1,}[A-Z]{1,}"
                                ErrorMessage="Password Requires a capital letter, a lower case letter and a number"   
                                ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            <!-- License Label -->
                        <div class = "licenseRego">
                            <label class="label2">License Number:</label>
                            <asp:TextBox ID="licenseRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator runat="server" 
                                ValidationExpression="^[0-9]{1,9}$"
                                ControlToValidate="licenseRego" ForeColor="Red" ErrorMessage="Invalid license number."></asp:RequiredFieldValidator>
                                </div>

                            <!-- First Name Label -->
                        <div class = "firstRego">
                            <label class="label2">First name:</label> 
                            <asp:TextBox ID="firstRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="firstRego"
                                ValidationExpression="^[a-zA-zZ]"
                                ErrorMessage="Please enter your first name"   
                                ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            <!-- Last Name Label -->
                        <div class = "lastNameRego">
                            <label class="label2">Last name:</label>
                            <asp:TextBox ID="lastNameRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator  runat="server"   
                                ControlToValidate="lastNameRego" ErrorMessage="Please enter your last name"   
                                ValidationExpression="^[a-zA-zZ]"
                                ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                            <!-- Gender Label -->
                        <div class = "RadioButtonList1">
                            <label class="label2">Gender:</label>
                            <asp:RadioButtonList id=RadioButtonList1 runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                                </div>

                            <!-- Birth date Label -->
                        <div class = "birthRego">
                            <label class="label2">Birth:</label> 
                            <asp:TextBox ID="birthRego" runat="server" placeholder="dd/mm/yy"></asp:TextBox> 
                            <asp:RequiredFieldValidator ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
                                runat="server" Display="Dynamic" 
                                ControlToValidate="birthRego" ForeColor="Red" ErrorMessage="Enter birth."></asp:RequiredFieldValidator>
                                 </div>
                 
                            <!-- Phone Label -->
                        <div class = "phoneNoRego">
                            <label class="label2">Phone Number:</label>
                            <asp:TextBox ID="phoneNoRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" 
                                ValidationExpression="^[0-9]{10}$"
                                ControlToValidate="phoneNoRego" ForeColor="Red" ErrorMessage="Invalid phone number."></asp:RequiredFieldValidator>
                            <br>         
                            <br>
                                 </div>

                            <!-- Address Label -->
                        <div class = "streetRego">
                            <label class="label2">Street:</label>
                            <asp:TextBox ID="streetRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic"
                                ValidationExpression="^[A-Za-z0-9_.]+$"
                                ControlToValidate="streetRego" ForeColor="Red" ErrorMessage="Enter street address."></asp:RequiredFieldValidator>           
                                 </div>

                            <!-- Suburb Label -->
                        <div class = "suburbRego">
                            <label class="label2">Suburb:</label> 
                            <asp:TextBox ID="suburbRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="suburbRego"
                                ValidationExpression="^[a-zA-zZ]"
                                ErrorMessage="Please enter your suburb"   
                                ForeColor="Red"></asp:RequiredFieldValidator>     
                                 </div>

                            <!-- Postcode Label -->
                        <div class = "postRego">
                            <label class="label2">Postcode:</label>
                            <asp:TextBox ID="postRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" 
                                ValidationExpression="^[0-9]{4}$"
                                ControlToValidate="postRego" ForeColor="Red" ErrorMessage="Enter postcode." />           
                                 </div>

                            <!-- Territory Label -->
                        <div class = "terrRego">
                            <label class="label2">Territory:</label> 
                            <asp:TextBox ID="terrRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="terrRego"
                                ValidationExpression="^[a-zA-zZ]"
                                ErrorMessage="Please enter your territory"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                                 </div>

                            <!-- City Label -->
                        <div class = "cityRego">
                           <label class="label2">City:</label> 
                            <asp:TextBox ID="cityRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="cityRego"
                                ValidationExpression="^[a-zA-zZ]"
                                ErrorMessage="Please enter city"   
                                ForeColor="Red"></asp:RequiredFieldValidator>
                                 </div>

                            <!-- Country Label -->
                        <div class = "countryRego">
                            <label class="label2">Country:</label> 
                            <asp:TextBox ID="countryRego" runat="server"></asp:TextBox> 
                            <asp:RequiredFieldValidator  runat="server" ControlToValidate="countryRego"
                                ValidationExpression="^[a-zA-zZ]"
                                ErrorMessage="Please enter your country"   
                                ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <br>
                            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Register" OnClick="Button1_Click"  href="/successIssue.aspx"></asp:Button>                   
                            <span id="regFail" runat="server"></span>
                       </div>
                       </form>
                        </div>
                  </div>
                    </div>
            </div>
       
    
   
      
</asp:Content>
