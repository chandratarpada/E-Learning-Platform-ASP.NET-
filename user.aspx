<%@ Page Title="User Management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="Admin_learning.user" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* General Body Styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 800px;
            margin: auto;
            text-align: center;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        table, th, td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        .button-save {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
            border-radius: 5px;
            margin-top: 10px;
            font-size: 16px;
            transition: 0.3s;
        }

        .button-save:hover {
            background-color: #45a049;
        }

        .grid-container {
            margin-top: 20px;
            width: 100%;
            overflow-x: auto;
        }

        .grid-container img {
            border-radius: 5px;
            object-fit: cover;
            width: 50px;
            height: 50px;
        }

        .btn-delete {
            background-color: red;
            color: white;
            padding: 5px 10px;
            border: none;
            cursor: pointer;
            border-radius: 3px;
        }

        .btn-delete:hover {
            background-color: darkred;
        }
    </style>

    <div class="container">
        <h2>User Management</h2>

        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID"
            CssClass="table" OnRowDeleting="GridViewUsers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:ImageField DataImageUrlField="ProfileImage" HeaderText="Profile Image">
                    <ControlStyle Width="50px" Height="50px" />
                </asp:ImageField>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-delete"
                            CommandName="Delete" CommandArgument='<%# Eval("UserID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
