<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="admincaradd.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardPageHolder" runat="server">

 <!-- /.row -->
            <div class="row">
                <div class="col-lg-3 col-md-6 menu">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"></div>
                                    <br>
                                    <div>Users!</div>
                                </div>
                            </div>
                        </div>
                        <a href="adminusers.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View users</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 menu">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-car fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"></div>
                                    <br>
                                    <div>Car history!</div>
                                </div>
                            </div>
                        </div>
                        <a href="admincar.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View cars</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 menu">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-bar-chart-o fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <br>
                                    <div>View Issues!</div>
                                </div>
                            </div>
                        </div>
                        <a href="adminissue.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View issues</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
  
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-8">
                    <div class="panel panel-default">
                        
                        <div class="panel-heading">
                            <i class="fa fa-user fa-fw"></i> Number Plate:
                            <div class="pull-right">
                                
                                <div class="btn-group">
                                    


                                </div>
                               
                            </div>
                            
                        </div>


                        <!-- /.panel-heading -->
                      
                      <asp:Label ID="Label1" runat="server" ></asp:Label>

                        <div class="panel-body">
                            <form id="updateform" runat="server">
                                               
                                <div class="formFormat">
                                    <label class="label2">Number Plate: </label>
                                    <asp:TextBox  name="numberPlate" id="numberPlate" runat="server" ></asp:TextBox>
                                </div>
                                 
                                <div class="formFormat">
                                    <label class="label2">Brand: </label>
                                    <asp:TextBox  name="breand" id="brand" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Model: </label>
                                    <asp:TextBox  name="model" id="model" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Vechicle Type: </label>
                                    <asp:TextBox  name="Vt" id="Vt" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Number Of Seats: </label>
                                    <asp:TextBox  name="seats" id="seats" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Doors: </label>
                                    <asp:TextBox  name="doors" id="doors" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat"> 
                                    <label class="label2">Transmission: </label>
                                    <asp:TextBox  name="transmission" id="transmission" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Fuel Type: </label>
                                    <asp:TextBox  name="fT" id="fT" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Tank Size: </label>
                                    <asp:TextBox  name="tanksize" id="tanksize" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Fuel Consumption: </label>
                                    <asp:TextBox  name="fC" id="fC" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                    <label class="label2">Average Range: </label>
                                    <asp:TextBox  name="AverageRange" id="AverageRange" runat="server" ></asp:TextBox>
                                </div>

                                <div class="formFormat">
                                     <label class="label2">Status: </label>
                                     <asp:TextBox  name="status" id="status" runat="server"></asp:TextBox>
                                </div>

                                <div class="last">
                                     <label  class="label2" >ProfileURL: </label>
                                    <asp:TextBox id="edprofileURL" runat="server"></asp:TextBox>
                                    <img src="" id="eprofileIMG" runat="server"/>
                                </div>

                                <br>

                                <div class="submit1">
                                    <asp:Button runat="server" Text="Submit"  class="btn btn-primary"></asp:Button>
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
                    
                <!-- /.col-lg-8 (nested) -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.panel-body -->
   

</asp:Content>
