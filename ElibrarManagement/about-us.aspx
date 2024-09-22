<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="about-us.aspx.cs" Inherits="ElibrarManagement.about_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section>
        <%--<img src="imgs/about-us.jpg%20-%20Copy.png" width="100%" height="600px"/>--%>
        <img src="imgs/about-us2.jpg" width="100%" />
    </section>

    <div class="container">
        <div class="row">
            <center>
                <h1>About Us</h1>
                <p class="text-center">
                    Welcome to [Library Name], your one-stop solution for efficient and seamless library management. 
                    Our mission is to empower libraries of all sizes to provide a better experience for both staff and patrons by streamlining the management of books, resources, and member services.
                </p>
                <p>
                    With our state-of-the-art library management system, we aim to make the organization, cataloging, and circulation of library materials simple and accessible. 
                    Whether you're a small community library, an academic institution, or a large public library, our platform offers a comprehensive suite of tools designed to meet your unique needs. 
                    From automated cataloging and inventory management to user-friendly patron services and analytics, we cover all aspects of library operations.
                </p>
                <p>
                    At [Library Name], we believe in fostering a love for reading and knowledge by making it easier for everyone to access and manage the resources they need. 
                    Our team is dedicated to providing an intuitive and reliable system, backed by continuous support and innovation, to ensure that your library thrives in the digital age.
                </p>
            </center>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <center>
                    <h1>Our Goals </h1>
                    <h5>At [Library Name], our goal is to empower libraries by providing a user-friendly, efficient, and secure management system. 
                    We aim to enhance the experience for both staff and patrons, promote reading and learning, streamline daily operations, and support data-driven decision-making. 
                    By fostering community engagement and ensuring privacy and security, we are dedicated to evolving and innovating our platform to meet the ever-changing needs of libraries and their communities.

                    </h5>
                </center>
            </div>
        </div>
        <br />
        <br />
        <div class="container">
            <center>

                <h2>Conntect Us</h2>
                <a href="ContactForm.aspx">Contact </a>
                <br />
            </center>


        </div>
    </div>
</asp:Content>
