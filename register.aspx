<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="my_project.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Register</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-container">
        <form id="form1" runat="server">
            <h3>Register Now</h3>

            <!-- Input fields -->
            <p>Your Name <span>*</span></p>
            <asp:TextBox ID="name" runat="server" Placeholder="Enter your name" MaxLength="50" CssClass="box" Required="true"></asp:TextBox>

            <p>Your Email <span>*</span></p>
            <asp:TextBox ID="email" runat="server" Placeholder="Enter your email" MaxLength="50" CssClass="box" Required="true"></asp:TextBox>

            <p>Your Password <span>*</span></p>
            <asp:TextBox ID="pass" runat="server" TextMode="Password" Placeholder="Enter your password" MaxLength="20" CssClass="box" Required="true"></asp:TextBox>

            <p>Confirm Password <span>*</span></p>
            <asp:TextBox ID="c_pass" runat="server" TextMode="Password" Placeholder="Confirm your password" MaxLength="20" CssClass="box" Required="true"></asp:TextBox>

            <p>Select Profile <span>*</span></p>
            <asp:FileUpload ID="profileImage" runat="server" CssClass="box" />

            <asp:Button ID="submitBtn" runat="server" Text="Register New" CssClass="btn" OnClick="RegisterUser_Click" />

            <br /><br />

            <!-- Hidden Buttons -->
            <asp:Button ID="btnRead" runat="server" Text="View Users" OnClick="ReadUser_Click" CssClass="btn" Visible="false" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update User" OnClick="UpdateUser_Click" CssClass="btn" Visible="false" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete User" OnClick="DeleteUser_Click" CssClass="btn" Visible="false" />
        </form>
    </section>
</asp:Content>
