<%@ Page Title="Lecturer Management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="lecturer.aspx.cs" Inherits="lecturer.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* General Page Styling */
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

        /* Form Container */
        .form-container {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 50%;
            margin-top: 20px;
        }

        /* Table Styling */
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        table, th, td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
        }

        th {
            background-color: #f6f6f9;
            font-weight: bold;
            text-align: center;
        }

        /* Input Fields */
        .input-field, .dropdown, .file-upload {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-top: 5px;
        }

        /* Button Styling */
        .button-save {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
            border-radius: 5px;
            display: block;
            width: 100%;
            text-align: center;
            transition: 0.3s;
        }

        .button-save:hover {
            background-color: #45a049;
        }

        /* GridView Styling */
        .grid-container {
            margin-top: 30px;
            width: 80%;
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

        /* Action Buttons */
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Form Container -->
    <div class="form-container">
        <h2>Lecturer Management</h2>
        <table>
            <tr>
                <td><strong>Name:</strong></td>
                <td><asp:TextBox ID="txtName" runat="server" CssClass="input-field"></asp:TextBox></td>
            </tr>
            <tr>
                <td><strong>Video:</strong></td>
                <td><asp:FileUpload ID="fileUploadVideo" runat="server" CssClass="file-upload" /></td>
            </tr>
            <tr>
                <td><strong>Playlist:</strong></td>
                <td><asp:DropDownList ID="ddlPlaylist" runat="server" CssClass="dropdown"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><strong>Staff:</strong></td>
                <td><asp:DropDownList ID="ddlStaff" runat="server" CssClass="dropdown"></asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="BtnSave_Click" CssClass="button-save" />
                </td>
            </tr>
        </table>
    </div>

    <!-- GridView Container -->
    <div class="grid-container">
        <h2>Lecturer List</h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="activity-grid" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Video" HeaderText="Video" />
                <asp:BoundField DataField="PlaylistName" HeaderText="Playlist" />
                <asp:BoundField DataField="StaffName" HeaderText="Staff" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <div class="action-buttons">
                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("Id") %>' 
                                CommandName="cmd_edit" CssClass="edit-button">Edit</asp:LinkButton>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("Id") %>' 
                                CommandName="cmd_delete" CssClass="delete-button"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');">
                                Delete
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
