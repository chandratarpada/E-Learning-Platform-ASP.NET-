<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="my_project.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-container">
        <form id="loginForm" runat="server" method="post">
            <h3>Login Now</h3>
            <p>Your email <span>*</span></p>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your email" CssClass="box" MaxLength="50" />
            <p>Your password <span>*</span></p>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter your password" CssClass="box" MaxLength="20" />
            <asp:Button ID="btnLogin" runat="server" Text="Login Now" CssClass="btn" OnClick="btnLogin_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="error-message" />
        </form>
    </section>
</asp:Content>
