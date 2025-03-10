<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="my_project.courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Our Courses - Educa</title>
    <link rel="stylesheet" href="css/courses.css"/>
    <style>
    .playlist-container {
        width: 90%;
        max-width: 1200px;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        gap: 20px;
        margin: auto;
    }

    .playlist-card {
        background-color: #fff;
        padding: 15px;
        border-radius: 12px;
        box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
        width: 270px;
        text-align: center;
        transition: transform 0.3s ease-in-out, box-shadow 0.3s ease-in-out;
    }

    .playlist-card:hover {
        transform: scale(1.05);
        box-shadow: 0px 6px 15px rgba(0, 0, 0, 0.15);
    }

    .playlist-card img {
        width: 100%;
        height: 160px;
        border-radius: 10px;
        object-fit: cover;
    }

    .playlist-card h3 {
        margin: 10px 0;
        font-size: 18px;
        color: #800080;
        font-weight: 600;
    }

    .playlist-card p {
        font-size: 14px;
        color: #555;
    }

    .inline-btn {
        display: inline-block;
        margin-top: 10px;
        padding: 8px 15px;
        background-color: #800080;
        color: white;
        text-decoration: none;
        border-radius: 6px;
        transition: 0.3s;
    }

    .inline-btn:hover {
        background-color: lightslategrey;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="courses">
        <h1 class="heading">Our Courses</h1>
        <div class="box-container">
            <div class="playlist-container">
                <asp:Repeater ID="rptPlaylists" runat="server">
                    <ItemTemplate>
                        <div class="playlist-card">
                            <img src='<%# Eval("Pimg") != DBNull.Value && !string.IsNullOrEmpty(Eval("Pimg").ToString()) ? ResolveUrl(Eval("Pimg").ToString()) : ResolveUrl("~/default.jpg") %>' 
                                 alt="Playlist Image" 
                                 onerror="this.onerror=null;this.src='<%# ResolveUrl("~/default.jpg") %>';" />
                            <h3><%# Eval("Name") %></h3>
                            <p><%# Eval("Description") %></p>
                            <a href="playlist.aspx?Id=<%# Eval("Playlist_id") %>" class="inline-btn">View Playlist</a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
