<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="Admin_learning.logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript">
        // Redirect after logout
        setTimeout(function () {
            window.location.href = "login.aspx"; // Redirect to login page
        }, 2000);
    </script>

   
</asp:Content>
