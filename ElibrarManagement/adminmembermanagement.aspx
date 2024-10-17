<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="ElibrarManagement.adminmembermanagement" %>
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
                                <h4>Member Details</h4>
                                
                            </center>
                        </div>
                    </div>    
                    
                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="150px" src="imgs/generaluser.jpg-removebg-preview.png" />
                            </center>
                        </div>
                    </div>  
                    
                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>
                    
                    <div class="row">

                        <div class="col-md-3">
                         <label>Member ID</label>
                         <div class="form-group">
                             <div class="input-group">
                                 <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="ID"></asp:TextBox>
                                 <asp:LinkButton ID="LinkButton4" class="btn btn-primary" runat="server" OnClick="LinkButton4_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>

                             </div>
                         </div>
                        </div>
                        <div class="col-md-4">
                            <label>Full Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-5">
                            <label>Account Satus</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="TextBox3" runat="server" placeholder="Status" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" class="btn btn-success mr-1" runat="server" OnClick="LinkButton1_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" class="btn btn-warning mr-1" runat="server" OnClick="LinkButton2_Click"><i class="fa-solid fa-pause"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" class="btn btn-danger mr-1" runat="server" OnClick="LinkButton3_Click"><i class="fa-solid fa-xmark"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    <br />

                    </div>
                    
                    <div class="row">

                        <div class="col-md-4">
                            <label>DOB</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="DOB" ReadOnly="True" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <label>Contact No</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-5">
                             <label>Email ID</label>
                             <div class="form-group">
                                 <div class="input-group">
                                     <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email ID" ReadOnly="True" TextMode="Email"></asp:TextBox>
                                 </div>

                             </div>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="state" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                             <label>City</label>
                             <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="city" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                             </div>
                        </div>
                        <div class="col-md-4">
                             <label>Pin Code</label>
                             <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="pin code" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                             </div>
                        </div>
                    </div>

                      <div class="row">

                          <div class="col">
                              <label>Full Postal Address</label>
                              <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Address" TextMode="MultiLine" ReadOnly="True" Rows="2"></asp:TextBox>
                              </div>
                          </div>
     
                      </div>

  
                    <div class="row">
                        <div class="col-8 mx-auto">
                            <div class="form-group">
                                 <asp:Button ID="Button2" CssClass="btn btn-outline-danger btn-block btn-lg" runat="server" Text="Delete User Permanently" OnClick="Button2_Click" />
                            </div>
                        </div>
                        
                      
                    </div>
                </div>
            </div>

                <a href="homepage.aspx"><< Back to Home</a>
            <br />
            <br />

        </div>

        <div class="col-md-7">

            <div class="card">
                <div class="card-body">

                    
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Member List</h4>
                                
                            </center>
                        </div>
                    </div>    

                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>  
                    
                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString3 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [member_master_tb1]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="Member_id" ReadOnly="True" SortExpression="member_id" />
                                    <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                    <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                    <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                    <asp:BoundField DataField="email" HeaderText="Email ID" SortExpression="email" />
                                    <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                    <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>    
                </div>

        </div>
    </div>
    </div>
</div>


</asp:Content>
