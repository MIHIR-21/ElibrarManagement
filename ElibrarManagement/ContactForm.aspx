<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="ElibrarManagement.ContactForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="ElibrarManagement.ContactForm" %>--%>

    <style>
        /* Simple styling for the form */
        .form-container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f3f4f6;
            border-radius: 5px;
        }

        .form-group {
            margin-bottom: 15px;
        }

            .form-group label {
                display: block;
                margin-bottom: 5px;
            }

            .form-group input, .form-group select {
                width: 100%;
                padding: 8px;
                box-sizing: border-box;
            }

                .form-group input[type="submit"] {
                    background-color: #007bff;
                    color: white;
                    border: none;
                    cursor: pointer;
                }

                    .form-group input[type="submit"]:hover {
                        background-color: #0056b3;
                    }
    </style>


    <div class="container">
        <center>

            <h1>CONTACT </h1>
            _________________
            <br />
            <br />
            <p class="text-center">
                Whether you're looking for Classroom Solutions, Home Learning Solutions or to Digitize School Operations, we can help. 
                Reach out to Us for a Demo or Custom Quote.
            </p>
        </center>
    </div>
    <br />
    <br />

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="form-group">

                    <label>Your Name</label>
                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" PlaceHolder="Enter Your Name"></asp:TextBox>
                    <br />

                    <label>Your School Name</label>

                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Enter your school name"></asp:TextBox>
                    <br />

                    <label>Your School Location </label>

                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Enter your school location"></asp:TextBox>
                    <br />

                    <label>Your Email </label>

                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Enter your email"></asp:TextBox>
                    <br />

                    <label>Your Phone Number </label>

                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Enter your phone number"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button1" CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Book a Demo" />


                </div>
            </div>
        </div>
    </div>

    <%--<form id="form1" runat="server">
        <div class="form-container">
            <div class="form-group">
                <label for="txtName">Your Name *</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter your name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="txtSchoolName">Your School Name *</label>
                <asp:TextBox ID="txtSchoolName" runat="server" CssClass="form-control" Placeholder="Enter school name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSchoolName" runat="server" ControlToValidate="txtSchoolName"
                    ErrorMessage="School name is required." ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="txtSchoolLocation">Your School Location *</label>
                <asp:TextBox ID="txtSchoolLocation" runat="server" CssClass="form-control" Placeholder="Enter school location"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSchoolLocation" runat="server" ControlToValidate="txtSchoolLocation"
                    ErrorMessage="School location is required." ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="ddlService">Service Interested In</label>
                <asp:DropDownList ID="ddlService" runat="server" CssClass="form-control">
                    <asp:ListItem Value="" Text="Select Service Interested In"></asp:ListItem>
                    <asp:ListItem Value="Service1" Text="Service 1"></asp:ListItem>
                    <asp:ListItem Value="Service2" Text="Service 2"></asp:ListItem>
                    <asp:ListItem Value="Service3" Text="Service 3"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="txtEmail">Your Email *</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is required." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Invalid email format." 
                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" 
                    ForeColor="Red"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </form>--%>
</asp:Content>
