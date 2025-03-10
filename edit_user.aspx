<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="MyWebApp.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit User</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" />
        </div>
        <div>
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" />
        </div>
        <div>
            <label for="profileImage">Profile Picture:</label>
            <asp:FileUpload ID="profileImage" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update User" OnClick="btnUpdate_Click" />
        </div>
    </form>
</asp:Content>
