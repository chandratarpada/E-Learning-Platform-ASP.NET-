<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="playlist.aspx.cs" Inherits="my_project.playlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Playlist - Educa</title>
    <link rel="stylesheet" href="css/courses.css"/>
    <style>
    .video-container {
        width: 90%;
        max-width: 1200px;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        gap: 20px;
        margin: auto;
    }

    .video-card {
        background-color: #fff;
        padding: 15px;
        border-radius: 12px;
        box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
        width: 300px;
        text-align: center;
        transition: transform 0.3s ease-in-out, box-shadow 0.3s ease-in-out;
    }

    .video-card:hover {
        transform: scale(1.05);
        box-shadow: 0px 6px 15px rgba(0, 0, 0, 0.15);
    }

    .video-card h3 {
        margin: 10px 0;
        font-size: 18px;
        color: #800080;
        font-weight: 600;
    }

    .video-preview video {
        width: 100%;
        height: 180px;
        border-radius: 10px;
        object-fit: cover;
        cursor: pointer;
    }
    </style>

    <script>
        function playFullScreen(videoElement) {
            if (videoElement.requestFullscreen) {
                videoElement.requestFullscreen();
            } else if (videoElement.mozRequestFullScreen) { // Firefox
                videoElement.mozRequestFullScreen();
            } else if (videoElement.webkitRequestFullscreen) { // Chrome, Safari & Opera
                videoElement.webkitRequestFullscreen();
            } else if (videoElement.msRequestFullscreen) { // IE/Edge
                videoElement.msRequestFullscreen();
            }
            videoElement.play();
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="playlist">
        <h1 class="heading">Playlist Videos</h1>
        <div class="video-container">
            <asp:Repeater ID="rptVideos" runat="server">
                <ItemTemplate>
                    <div class="video-card">
                        <h3><%# Eval("LecturerName") %></h3>
                        <div class="video-preview">
                            <video width="100%" height="180" controls onclick="playFullScreen(this)">
                                <source src='<%# ResolveUrl(Eval("Video").ToString()) %>' type="video/mp4">
                                Your browser does not support the video tag.
                            </video>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
</asp:Content>
