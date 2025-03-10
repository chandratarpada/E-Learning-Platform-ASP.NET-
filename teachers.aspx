<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="teachers.aspx.cs" Inherits="my_project.teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Teachers</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="teachers">
        <h1 class="heading">Expert Teachers</h1>

        <!-- Search Tutor Form -->
        <form method="post" class="search-tutor">
            <button type="submit" class="fas fa-search" name="search_tutor"></button>
        </form>

        <div class="box-container">
            <!-- Become a Tutor Offer -->
            <div class="box offer">
                <h3>Become a Tutor</h3>
                <p>Join our expert teaching team and inspire students worldwide.</p>
                <a href="register.aspx" class="inline-btn">Get Started</a>
            </div>

            <!-- Dynamic Tutor Profiles -->
            <asp:Literal ID="boxContainer" runat="server"></asp:Literal>
        </div>
    </section>

</asp:Content>
