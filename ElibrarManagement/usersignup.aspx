<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="ElibrarManagement.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="container">
    <div class="row">
        <div class="col-md-6 mx-auto">

            <div class="card">
                <div class="card-body">

                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="150px" src="imgs/generaluser.jpg-removebg-preview.png" />
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Member Sigh Up</h3>
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
                            

                            <div class="form-group">
                                <label>Member ID</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                            </div>
                            
                            <div class="form-group">
                                <label>Create Password</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="create Password" TextMode="Password"></asp:TextBox>
                            </div>
                            
                            <div class="form-group">
                                <label>Conform Password</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Conform Password" TextMode="Password"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Login" />
                            </div>
                            
                           
                        </div>
                    </div>



                </div>
            </div>


           
            <br />
            <br />

        </div>
    </div>
</div>

</asp:Content>
