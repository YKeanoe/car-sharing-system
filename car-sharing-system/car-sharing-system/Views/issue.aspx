<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="issue.aspx.cs" Inherits="car_sharing_system.Admin_Theme.pages.issue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">
  
    <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"></div>
                                    <br>
                                    <div>Profile!</div>
                                </div>
                            </div>
                        </div>
                        <a href="/dashboard/profile">
                            <div class="panel-footer">
                                <span class="pull-left">View profile details</span>
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
                                <span class="pull-left">View booking history</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
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


 <div class="row">
    <div class="col-lg-8">
        <div class="panel panel-default">
            <div class="panel-heading">
                <i class="fa fa-tasks fa-fw"></i> Booking history
                <div class="pull-right">
                    <div class="btn-group">                
                    </div>
                </div>
            </div>
            <div class="panel-body">
           
                    <form id="form2" runat="server"> 
                        <div class="form-group">
                          
                           <div class="panel-body">
                            <label>Subject</label> 
                            <br>
                            <asp:TextBox ID="subjectIssue" runat="server" placeholder="Title"></asp:TextBox> 
                           <br>
                            <br>
                            <asp:TextBox ID="description" runat="server" placeholder="Enter description"
                                TextMode="Multiline" rows="10" columns="100"></asp:TextBox> 
                            <br>
                            <br>
                            
                            <asp:Button Text="Submit" runat="server" class="btn btn-primary" OnClick="Button2_Click" href="/successIssue.aspx" > </asp:Button>
                            <span id="issueFail" runat="server"></span>
                        </div>
                            </div>
                    </form>
                    
                </div>
            </div>
        </div>
        </div>
    
</asp:Content>
