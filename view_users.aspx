<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="view_users.aspx.cs" Inherits="MyWebApp.ViewUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Users</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Registered Users</h3>
    
    <table border="1">
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Profile Picture</th>
            <th>Actions</th>
        </tr>
        
        <asp:Repeater ID="RepeaterUsers" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Email") %></td>
                    <td>
                        <%# Eval("ProfilePicture") != DBNull.Value ? "<img src='data:image;base64," + Convert.ToBase64String((byte[])Eval("ProfilePicture")) + "' width='50' height='50' />" : "No Image Available" %>
                    </td>
                    <td>
                        <a href="edit_user.aspx?userId=<%# Eval("UserId") %>">Edit</a> |
                        <a href="delete_user.aspx?userId=<%# Eval("UserId") %>" onclick="return confirm('Are you sure you want to delete this user?');">Delete</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
