<%@ Page Title="Staff Management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="staff.aspx.cs" Inherits="Admin_learning.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* General Body Styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            min-height: 100vh;
        }

        /* Form Container */
        .form-container {
            
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            width: 90%;
            text-align: center;
        }

        /* Table Styling */
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

        /* Input Fields */
        input[type="text"], input[type="email"], input[type="tel"], .file-upload {
            width: calc(100% - 20px);
            padding: 8px;
            margin: 5px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        /* Button Styling */
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

        /* GridView Styling */
        .grid-container {
            margin-top: 20px;
            width: 100%;
            max-width: 1000px;
            overflow-x: auto;
        }

        .grid-container table {
            width: 100%;
            border-collapse: collapse;
        }

        .grid-container td, .grid-container th {
            padding: 10px;
            text-align: center;
        }

        /* Link Button Styling */
        .link-button {
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
        }

        .link-button:hover {
            text-decoration: underline;
        }

        /* Image Styling */
        .grid-container img {
            border-radius: 5px;
            object-fit: cover;
        }

    </style>

    <!-- Form container -->
    <div class="form-container">
        <table>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Contact:</td>
                <td><asp:TextBox ID="txtContact" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Qualification:</td>
                <td><asp:TextBox ID="txtQualification" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Experience:</td>
                <td><asp:TextBox ID="txtExperience" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Picture:</td>
                <td><asp:FileUpload ID="fileUploadPicture" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" CssClass="button-save" /></td>
            </tr>
        </table>
    </div>

    <!-- GridView for displaying staff details -->
    <div class="grid-container">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Contact" HeaderText="Contact" />
                <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                <asp:BoundField DataField="Experience" HeaderText="Experience" />
                <asp:TemplateField HeaderText="Picture">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="60" Width="60" ImageUrl='<%# Eval("Picture") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="cmd_edt" CssClass="link-button">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="cmd_dlt" CssClass="link-button">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
