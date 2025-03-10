<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="delete_user.aspx.cs" Inherits="MyWebApp.DeleteUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Delete User</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Are you sure you want to delete this user?</h3>
    <form method="post">
        <input type="submit" value="Delete" />
    </form>
</asp:Content>
