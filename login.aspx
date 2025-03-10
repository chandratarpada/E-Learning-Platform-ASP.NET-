<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Admin_learning.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background: #f4f4f4;
        }

        .login-box {
            width: 350px;
            padding: 20px;
            background: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            text-align: center;
        }

        h3 {
            margin-bottom: 15px;
            font-size: 22px;
            color: #333;
        }

        p {
            text-align: left;
            margin: 10px 0 5px;
            font-weight: bold;
            color: #555;
        }

        .box {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
        }

        .btn {
            width: 100%;
            padding: 10px;
            background: #28a745;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: 0.3s;
        }

        .btn:hover {
            background: #218838;
        }

        .error-message {
            color: red;
            margin-top: 10px;
            display: block;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-container">
        <div class="login-box">
            <h3>Login Now</h3>
            
            <p>Your Email <span>*</span></p>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your email" CssClass="box" MaxLength="50" />

            <p>Your Password <span>*</span></p>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter your password" CssClass="box" MaxLength="20" />

            <p>Select Role <span>*</span></p>
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="box">
                <asp:ListItem Text="Select Role" Value="" />
                <asp:ListItem Text="Admin" Value="Admin" />
                <asp:ListItem Text="Lecturer" Value="Lecturer" />
            </asp:DropDownList>

            <asp:Button ID="btnLogin" runat="server" Text="Login Now" CssClass="btn" OnClick="btnLogin_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message" />
        </div>
    </section>
</asp:Content>

