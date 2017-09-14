 <%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

<div class="row">
    <div class="col-lg-8">
        <div class="panel panel-default">
            <div class="panel-heading">
                <i class="fa fa-user fa-fw"></i> Login
                <div class="pull-right">
                    <div class="btn-group"> </div>
                </div>
            </div>

            <div class="panel-body">
                <form id="form1" runat="server">
                    <asp:Login 
                    ID = "Login1" 
                    runat = "server" 
                    OnAuthenticate= "ValidateUser" 
                    DestinationPageUrl="/dashboard">
                        <LayoutTemplate>
                            <div class="form-group">
                                <asp:TextBox class="form-control" placeholder="Email" id="UserName" runat="server"></asp:TextBox>
                                <asp:requiredfieldvalidator id="UserNameRequired" runat="server" ControlToValidate="UserName" Text="*"></asp:requiredfieldvalidator>
                                <br />
                                <asp:TextBox class="form-control" placeholder="Password" id="Password" runat="server" textMode="Password"></asp:TextBox>
                                <asp:requiredfieldvalidator id="PasswordRequired" runat="server" ControlToValidate="Password" Text="*"></asp:requiredfieldvalidator>
                                <br />
                                <asp:button id="Button1" class="btn btn-primary" CommandName="Login" runat="server" Text="Login"></asp:button>
                                <a href="/dashboard/register" class="btn btn-info">Register</a>
                                <asp:Checkbox id="RememberMe" runat="server" Text="Remember my login"></asp:Checkbox>
                                <br />
                                <asp:Literal id="FailureText" runat="server"></asp:Literal></td>
                            </div>
                        </LayoutTemplate>
                    </asp:Login>
                </form>
            </div>
        </div>
    </div>
</div>
</asp:Content>
