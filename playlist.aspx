<%@ Page Title="Playlist Management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="playlist.aspx.cs" Inherits="Admin_learning.Playlist" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="style.css" />

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
        }

        .form-container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            margin-top: 20px;
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

        th {
            background-color: #f6f6f9;
            font-weight: bold;
        }

        .button-save {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
            border-radius: 5px;
            transition: 0.3s;
        }

        .button-save:hover {
            background-color: #45a049;
        }

        .grid-container {
            margin-top: 30px;
            width: 100%;
            overflow-x: auto;
            text-align: center;
        }

        .grid-container table {
            margin: 0 auto;
            width: 100%;
        }

        .grid-container td, .grid-container th {
            padding: 12px;
            text-align: center;
        }

        .action-buttons {
            display: flex;
            gap: 10px;
            justify-content: center;
        }

        .edit-button, .delete-button {
            text-decoration: none;
            padding: 6px 12px;
            border-radius: 5px;
            color: white;
            transition: 0.3s;
        }

        .edit-button {
            background-color: #007bff;
        }

        .edit-button:hover {
            background-color: #0056b3;
        }

        .delete-button {
            background-color: #dc3545;
        }

        .delete-button:hover {
            background-color: #a71d2a;
        }
    </style>

    <div class="form-container">
        <h2>Manage Playlists</h2>
        <table>
            <tr>
                <td><strong>Name:</strong></td>
                <td><asp:TextBox ID="txtName" runat="server" CssClass="input-field"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Description:</strong></td>
                <td><asp:TextBox ID="txtDescription" runat="server" CssClass="input-field"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Upload Image:</strong></td>
                <td><asp:FileUpload ID="fileUploadPimg" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button-save" />
                </td>
            </tr>
        </table>
    </div>

    <div class="grid-container">
        <h2>Playlist List</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="activity-grid" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Playlist_id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" />

                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="PlaylistImage" runat="server" ImageUrl='<%# Eval("Pimg") %>' Width="80px" Height="80px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <div class="action-buttons">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Playlist_id") %>' CommandName="cmd_edit" CssClass="edit-button">Edit</asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("Playlist_id") %>' CommandName="cmd_delete" CssClass="delete-button">Delete</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
