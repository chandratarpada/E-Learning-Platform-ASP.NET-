<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="my_project.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home - Video Playlists</title>
    <style>
   /* General Container Styling */
.playlist-container {
    width: 90%;
    max-width: 1200px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 25px;
    margin: auto;
    padding: 20px;
}

/* Playlist Card */
.playlist-card {
    background-color: #fff;
    padding: 20px;
    border-radius: 12px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    width: 300px;
    text-align: center;
    transition: transform 0.3s ease-in-out, box-shadow 0.3s ease-in-out;
}

.playlist-card:hover {
    transform: scale(1.05);
    box-shadow: 0px 6px 15px rgba(0, 0, 0, 0.15);
}

/* Playlist Card - Image */
.playlist-card img {
    width: 100%;
    height: 180px;
    border-radius: 10px;
    object-fit: cover;
    margin-bottom: 15px;
}

/* Playlist Title */
.playlist-card h3 {
    color: #333;
    font-size: 1.3rem;
    font-weight: 600;
    margin: 10px 0;
    line-height: 1.4;
}

/* Playlist Description */
.playlist-card p {
    color: #666;
    font-size: 0.95rem;
    line-height: 1.6;
    margin-bottom: 20px;
    height: 60px;
    overflow: hidden;
}

/* Additional Information */
.lecturer-info {
    font-size: 0.9rem;
    color: #555;
    margin: 10px 0;
}

.lecture-count {
    background: #f0f0f0;
    padding: 5px 15px;
    border-radius: 20px;
    font-size: 0.85rem;
    color: #555;
    display: inline-block;
    margin: 10px 0;
}

/* Button Styling */
.inline-btn {
    display: inline-block;
    padding: 10px 25px;
    background: #800080;
    color: #fff;
    border-radius: 25px;
    text-decoration: none;
    font-weight: 500;
    transition: all 0.3s ease;
    border: 2px solid #800080;
}

.inline-btn:hover {
    background: #fff;
    color: #800080;
}

/* Heading */
.heading {
    text-align: center;
    font-size: 2.5rem;
    color: #333;
    margin-bottom: 30px;
    text-transform: uppercase;
}

/* No Data Section */
.no-data {
    text-align: center;
    padding: 40px;
    background: #fff;
    border-radius: 15px;
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
    width: 100%;
    max-width: 600px;
    margin: 0 auto;
}

.no-data h3 {
    color: #333;
    font-size: 1.5rem;
    margin-bottom: 15px;
}

.no-data p {
    color: #666;
    font-size: 1rem;
}

/* Responsive Design */
@media (max-width: 768px) {
    .playlist-container {
        flex-direction: column;
        align-items: center;
    }
    .playlist-card {
        width: 100%;
        max-width: 350px;
    }
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="courses">
        <h1 class="heading">Our Courses</h1>
        <div class="box-container">
            <div class="playlist-container">
                <asp:Panel ID="pnlNoData" runat="server" CssClass="no-data" Visible="false">
                    <h3>No playlists available at the moment.</h3>
                    <p>Please check back later for new content.</p>
                </asp:Panel>

                <asp:Repeater ID="rptPlaylists" runat="server">
                    <ItemTemplate>
                        <div class="playlist-card">
                            <img src='<%# ResolveUrl(Eval("Pimg").ToString()) %>' 
                                 alt='<%# Eval("Name") %>' 
                                 onerror="this.src='<%# ResolveUrl("~/images/default-playlist.png") %>'" />
                            <h3><%# Eval("Name") %></h3>
                            <p><%# Eval("Description") %></p>
                            <a href='<%# "playlist.aspx?Id=" + Eval("Playlist_id") %>' class="inline-btn">
                                View Playlist
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>