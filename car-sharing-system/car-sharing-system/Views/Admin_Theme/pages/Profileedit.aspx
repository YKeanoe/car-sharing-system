<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin_Theme/pages/Profile.master" AutoEventWireup="true" CodeBehind="profileedit.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Profile" runat="server">


                      
                      <asp:Label ID="Label1" runat="server" ></asp:Label>

                        <div class="panel-body">
   
                            
                                        <div class="form-group">
                            <form id="updateform" runat="server">
                                               

                                

                                <asp:TextBox class="form-control" ID="fn" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="ln" placeholder="LastName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="licenceNo" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="birth" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="gender" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="phone" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="street" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="suburb" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="postcode" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="territory" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="city" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="country" placeholder="FirstName" runat="server"></asp:TextBox>
                                <asp:TextBox class="form-control" ID="profileURL" placeholder="FirstName" runat="server"></asp:TextBox>

                             </form>




                                           <a href="/dashboard/update" class="btn btn-info">
                                                Edit
                                            </a>
                                        </div>
                        </div>

</asp:Content>



