<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinvantory.aspx.cs" Inherits="ElibrarManagement.adminbookinvantory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/book1.jpg.png" />
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
                                <asp:FileUpload Class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton4" class="btn btn-primary" runat="server"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>



                            <br />

                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                        <asp:ListItem Text="Gujarati" Value="Gujarati"></asp:ListItem>
                                        <asp:ListItem Text="Marathi" Value="Marathi"></asp:ListItem>
                                        <asp:ListItem Text="French" Value="French"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                         <asp:ListItem Text="Publisher 1" Value="Publisher 1"></asp:ListItem>
                                         <asp:ListItem Text="Publisher 2" Value="Publisher 2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="Author 1" Value="Author 1"></asp:ListItem>
                                        <asp:ListItem Text="Author 2" Value="Author 2"></asp:ListItem>
                                        <asp:ListItem Text="Author 3" Value="Author 3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label>Publish Date</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="publish date" TextMode="Date"></asp:TextBox>

                            </div>
                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:ListBox Class="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                                            <asp:ListItem Text="Adventure" Value="Adventure" />
                                            <asp:ListItem Text="Comic Book" Value="Comic Book " />
                                            <asp:ListItem Text="Self Help" Value="Self Help" />
                                            <asp:ListItem Text="Motivation" Value="Motivation" />
                                            <asp:ListItem Text="Wellness" Value="Wellness" />
                                            <asp:ListItem Text="Crime" Value="Crime" />
                                            <asp:ListItem Text="Drama" Value="Drama" />
                                            <asp:ListItem Text="Horror" Value="Horror" />
                                            <asp:ListItem Text="Poetry" Value="Poetry" />
                                            <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                            <asp:ListItem Text="Advanture" Value="Advanture" />
                                        </asp:ListBox>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Edition" TextMode="SingleLine" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Book Cost" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Actual Stock" TextMode="Number" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">

                            <div class="col">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button ID="Button2" CssClass="btn btn-outline-primary btn-block btn-lg" runat="server" Text="Add" />
                                </div>
                            </div>
                            <div class="col-4">
                                <div class="form-group">
                                    <asp:Button ID="Button3" CssClass="btn btn-outline-success btn-block btn-lg" runat="server" Text="Update" />
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
                                    <h4>Book Invantory List</h4>

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
