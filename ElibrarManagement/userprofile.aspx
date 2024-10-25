<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ElibrarManagement.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
 $(document).ready(function () {
     $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
 });
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container-fluid">
    <div class="row">
        <div class="col-md-5">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="100px" src="imgs/generaluser.jpg-removebg-preview.png" />
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Your Profile</h4>
                                <span>Account Status -</span>
                                <asp:Label ID="Label1" class="badge badge-pill badge-info" runat="server" Text="Label"></asp:Label>

                            </center>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-6">
                             <label>Full Name</label>
                             <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                             </div>
                        </div>

                        <div class="col-md-6">
                            <label>Date of Birth</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-6">
                             <label>Contact Number</label>
                             <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                             </div>
                        </div>

                        <div class="col-md-6">
                            <label>Email ID</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="select" Value="select" />
                                    <asp:ListItem Text="Gujarat" Value="Gujarat" />
                                    <asp:ListItem Text="Goa" Value="Goa" />
                                    <asp:ListItem Text="Kerala" Value="Kerala" />
                                    <asp:ListItem Text="Hariyana" Value="Hariyana" />
                                    <asp:ListItem Text="Bihar" Value="Bihar" />
                                    <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                    <asp:ListItem Text="Assam" Value="Assam" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <label>City</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="City" TextMode="SingleLine"></asp:TextBox>
                            <div class="form-group">

                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <label>Pin Code</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Pincode" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <label>Full Address</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                
                                <span class="badge badge-pill badge-info">Login Credentials</span>
                            </center>
                            <br />

                        </div>
                    </div>

                     <div class="row">
                         <div class="col-md-4">
                              <label>User ID</label>
                              <div class="form-group">
                                  <asp:TextBox Class="form-control" ID="TextBox8" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                              </div>
                         </div>

                         <div class="col-md-4">
                             <label>Old Password</label>
                             <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password" ReadOnly="True"></asp:TextBox>
                             </div>
                         </div>
                         
                         <div class="col-md-4">
                             <label>New Password</label>
                             <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                             </div>
                         </div>
                    </div>


                    <div class="row">
                        <div class="col-8 mx-auto">
                            
                                <center>
                                     <div class="form-group">
                                         <asp:Button ID="Button1" CssClass="btn btn-primary btn-block btn-lg" runat="server" Text="Update" OnClick="Button1_Click" />
                                     </div>
                                </center>
                            
                           
                        </div>
                    </div>
                </div>
            </div>

             <%--<a href="homepage.aspx"><< Back to Home</a>--%>
            <br />
            <br />

        </div>

        <div class="col-md-7">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="100px" src="imgs/book1.jpg.png" />
                                <br />
                            </center>
                        </div>
                    </div>  
                    
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Your Issued Books </h4>
                                <asp:Label ID="Label2" class="badge badge-pill badge-info" runat="server" Text="Your books info"></asp:Label>
                            </center>
                        </div>
                    </div>    
                    
                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>  
                    
                    <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="true"></asp:GridView>
                        </div>
                    </div>    
                </div>
        </div>
    </div>
    </div>
</div>

</asp:Content>
