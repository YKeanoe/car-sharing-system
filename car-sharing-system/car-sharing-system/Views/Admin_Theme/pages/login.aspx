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
                            <form role="form">
                                <div class="form-group">
                                    <label>Email   </label>
                                    <input class="form-control" placeholder="Email" />
                                    <br />

                                    <label>Password</label>
                                    <input class="form-control" placeholder="Password" />
                                    <br />

                                    <a href="/Admin_Theme/pages/register.aspx" class="btn btn-info">
                                        Register
                                    </a>

                                    <button class="btn btn-primary">
                                        Login
                                    </button>
                                    <asp:Literal runat="server" ID="MyData" />
                                    
                                </div>
                            </form>
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
    </div>
</asp:Content>
