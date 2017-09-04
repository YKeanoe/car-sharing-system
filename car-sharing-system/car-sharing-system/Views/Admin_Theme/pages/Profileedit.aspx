<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin_Theme/pages/Profile.master" AutoEventWireup="true" CodeBehind="profileedit.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Profile" runat="server">


                      
                      <asp:Label ID="Label1" runat="server" ></asp:Label>

                        <div class="panel-body">
   
                            
                                        <div class="form-group">
                            <form id="updateform" runat="server">
                                               

                                

                                <div id="field1"><asp:TextBox class="form-control" ID="fn" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field2"><asp:TextBox class="form-control" ID="ln" placeholder="LastName" runat="server"></asp:TextBox></div>
                                <div id="field3"><asp:TextBox class="form-control" ID="licenceNo" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field4"><asp:TextBox class="form-control" ID="birth" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field5"><asp:TextBox class="form-control" ID="gender" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field6"><asp:TextBox class="form-control" ID="phone" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field7"><asp:TextBox class="form-control" ID="street" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field8"><asp:TextBox class="form-control" ID="suburb" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field9"><asp:TextBox class="form-control" ID="postcode" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field10"><asp:TextBox class="form-control" ID="territory" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field11"><asp:TextBox class="form-control" ID="city" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field12"><asp:TextBox class="form-control" ID="country" placeholder="FirstName" runat="server"></asp:TextBox></div>
                                <div id="field13"><asp:TextBox class="form-control" ID="profileURL" placeholder="FirstName" runat="server"></asp:TextBox></div>

                             </form>




                                           <a href="/dashboard/update" class="btn btn-info">
                                                Edit
                                            </a>
                                        </div>
                        </div>

</asp:Content>



