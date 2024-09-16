<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="ElibrarManagement.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <img src="imgs/home-bg.jpg.png" class="img-fluid"/>
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>
                            Our Features
                        </h2>
                        <p>
                            <b>Our 3 Primery Features - </b>
                        </p>
                    </center>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/digital-inventory.jpg-removebg-preview.png" />
                        <h4>Digital Book Inventory</h4>
                        <p class="text-justify">
                            A book distributor is a person or company that fulfills the function of distribution. 
                            They take care of storage, shipping, delivery, and billing.
                        </p>
                    </center>
                </div> 
                <div class="col-md-4">
                    <center>
                        <%--<img width="150px" src="imgs/digital-inventory.jpg.png" />--%>
                        <img widt="110px" src="imgs/search-online.lpg-removebg-preview.png" />
                        <h4>Search Books</h4>
                        <p class="text-justify">
                            A book distributor is a person or company that fulfills the function of distribution. 
                            They take care of storage, shipping, delivery, and billing.
                        </p>
                    </center>
                </div> 
                <div class="col-md-4">
                    <center>
                        <%--<img width="150px" src="imgs/digital-inventory.jpg.png" />--%>
                        <img width="100px" src="imgs/defaulters-list.jpg-removebg-preview.png" />
                        <h4>Defaulters List</h4>
                        <p class="text-justify">
                            A book distributor is a person or company that fulfills the function of distribution. 
                            They take care of storage, shipping, delivery, and billing.
                        </p>
                    </center>
                </div>
            </div>
        </div>
    </section>

    <section>
        <img src="imgs/in-homepage-banner.jpg.png" class="img-fluid" />
    </section>

    <section>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <center>
                    <h2>
                        Our Process
                    </h2>
                    <p>
                        <b>We have a simple 3 steps process </b>
                    </p>
                </center>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <center>
                    <img width="150px" src="imgs/sign-up.jpg-removebg-preview.png" />
                    <h4>Sigh Up</h4>
                    <p class="text-justify">
                        A book distributor is a person or company that fulfills the function of distribution. 
                        They take care of storage, shipping, delivery, and billing.
                    </p>
                </center>
            </div> 
            <div class="col-md-4">
                <center>
                    <%--<img width="150px" src="imgs/digital-inventory.jpg.png" />--%>
                    <img widt="110px" src="imgs/search-online.lpg-removebg-preview.png" />
                    <h4>Search Books</h4>
                    <p class="text-justify">
                        A book distributor is a person or company that fulfills the function of distribution. 
                        They take care of storage, shipping, delivery, and billing.
                    </p>
                </center>
            </div> 
            <div class="col-md-4">
                <center>
                    <%--<img width="150px" src="imgs/digital-inventory.jpg.png" />--%>
                    <img width="135px" src="imgs/visit-us.jpg-removebg-preview.png" />
                    <h4>Visit Us</h4>
                    <p class="text-justify">
                        A book distributor is a person or company that fulfills the function of distribution. 
                        They take care of storage, shipping, delivery, and billing.
                    </p>
                </center>
            </div>
        </div>
    </div>
</section>
</asp:Content>
