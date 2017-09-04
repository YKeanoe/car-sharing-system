<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin_Theme/pages/Profile.master" AutoEventWireup="true" CodeBehind="profiledefault.aspx.cs" Inherits="car_sharing_system.Views.Admin_Theme.pages.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Profile" runat="server">


                     <asp:Label ID="Label1" runat="server" ></asp:Label>

                        <div class="panel-body">
   
                            
                                        <div class="form-group">
                            <form id="updateform" runat="server">
                                               

                                

                                <div id="field1"><asp:Label ID="fn" runat="server" Text="First name: "></asp:Label><br /></div>
                                <div id="field2"><asp:Label ID="ln" runat="server" Text="Last name: "></asp:Label><br /></div>
                                <div id="field3"><asp:Label ID="licenceNo" runat="server" Text="Licence Number: "></asp:Label><br /></div>
                                <div id="field4"><asp:Label ID="birth" runat="server" Text="Date of birth: "></asp:Label><br /></div>
                                <div id="field5"><asp:Label ID="gender" runat="server" Text="Gender: "></asp:Label><br /></div>
                                <div id="field6"><asp:Label ID="phone" runat="server" Text="Phone: "></asp:Label><br /></div>
                                <div id="field7"> <asp:Label ID="street" runat="server" Text="Street: "></asp:Label><br /></div>
                                <div id="field8"><asp:Label ID="suburb" runat="server" Text="Suburb: "></asp:Label><br /></div>
                                <div id="field9"> <asp:Label ID="postcode" runat="server" Text="Postcode: "></asp:Label><br /></div>
                                <div id="field10"> <asp:Label ID="territory" runat="server" Text="Territory: "></asp:Label><br /></div>
                                <div id="field11"> <asp:Label ID="city" runat="server" Text="City: "></asp:Label><br /></div>
                                <div id="field12"> <asp:Label ID="country" runat="server" Text="Country: "></asp:Label><br /></div>
                                <div id="field13"> <asp:Label ID="profileURL" runat="server" Text="ProfileURL: "></asp:Label><br /></div>

                             </form>




                                           <a href="/dashboard/update" class="btn btn-info">
                                                Edit
                                            </a>
                                        </div>
                        </div>

</asp:Content>





