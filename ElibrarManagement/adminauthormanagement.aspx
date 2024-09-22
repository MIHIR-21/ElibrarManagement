<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="ElibrarManagement.adminauthormanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">


                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details </h4>

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/author-writer.jpg.png" />

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Go" />
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Author Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button ID="Button2" CssClass="btn btn-outline-success btn-block btn-lg" runat="server" Text="Add" />
                                </div>
                            </div>

                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button ID="Button3" CssClass="btn btn-outline-warning btn-block btn-lg" runat="server" Text="Update" />
                                </div>
                            </div>

                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button ID="Button4" CssClass="btn btn-outline-danger btn-block btn-lg" runat="server" Text="Delete" />
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
                                    <h4>Author List</h4>

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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
