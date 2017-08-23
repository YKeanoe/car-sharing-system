<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.logout" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- /.row -->
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i> Profile details
                            <div class="pull-right">
                                
                                <div class="btn-group">
                                    


                                </div>
                               
                            </div>
                            
                        </div>


                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            ya sure you want to logout

                            <form id="form2" runat="server">
                                <asp:LinkButton class="btn btn-primary" Text="Log out" OnClick="LoginLink_OnClick" runat="server" />
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
                    <div id="morris-bar-chart"></div>
                </div>
                <!-- /.col-lg-8 (nested) -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.panel-body -->

</asp:Content>
