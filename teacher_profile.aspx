<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="teacher_profile.aspx.cs" Inherits="my_project.teacher_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tutor Profile</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="teacher-profile">
        <h1 class="heading">Profile Details</h1>

        <div class="details">
            <div class="tutor">
                <asp:Image ID="imgStaff" runat="server" CssClass="profile-image" />
                <h3><asp:Label ID="lblStaffName" runat="server" Text="John Doe"></asp:Label></h3>
                <span><asp:Label ID="lblQualification" runat="server" Text="Developer"></asp:Label></span>
            </div>
            <div class="flex">
                <p>Total Playlists: <span><asp:Label ID="lblTotalPlaylists" runat="server" Text="0"></asp:Label></span></p>
                <p>Total Videos: <span><asp:Label ID="lblTotalVideos" runat="server" Text="0"></asp:Label></span></p>
                <p>Total Likes: <span>1208</span></p>
                <p>Total Comments: <span>52</span></p>
            </div>
        </div>
    </section>

    <section class="courses">
        <h1 class="heading">Our Courses</h1>

        <div class="box-container">
            <asp:Repeater ID="RepeaterCourses" runat="server">
                <ItemTemplate>
                    <div class="box">
                        <div class="thumb">
                            <img src='<%# Eval("Thumbnail") %>' alt="Course Thumbnail">
                            <span><%# Eval("VideoCount") %> videos</span>
                        </div>
                        <h3 class="title"><%# Eval("Playlist_name") %></h3>
                        <a href="playlist.aspx" class="inline-btn">View Playlist</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>

</asp:Content>
