<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="watch_video.aspx.cs" Inherits="my_project.watch_video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Watch Video</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="watch-video">

        <div class="video-container">
            <div class="video">
                <video src="ProfileImages/vid-1.mp4" controls poster="ProfileImages/post-1-1.png" id="video"></video>
            </div>
            <h3 class="title">Complete HTML Tutorial (Part 01)</h3>
            <div class="info">
                <p class="date"><i class="fas fa-calendar"></i><span>22-10-2022</span></p>
                <p class="date"><i class="fas fa-heart"></i><span>44 likes</span></p>
            </div>
            <div class="tutor">
                <img src="ProfileImages/pic-2.jpg" alt="">
                <div>
                    <h3>John Deo</h3>
                    <span>Developer</span>
                </div>
            </div>
            <form action="" method="post" class="flex">
                <a href="playlist.aspx" class="inline-btn">View Playlist</a>
                <button><i class="far fa-heart"></i><span>Like</span></button>
            </form>
            <p class="description">
                Lorem ipsum dolor, sit amet consectetur adipisicing elit. Itaque labore ratione, hic exercitationem mollitia obcaecati culpa dolor placeat provident porro.
            </p>
        </div>

    </section>

    <section class="comments">

        <h1 class="heading">5 Comments</h1>

        <form action="" class="add-comment">
            <h3>Add Comments</h3>
            <textarea name="comment_box" placeholder="Enter your comment" required maxlength="1000" cols="30" rows="10"></textarea>
            <input type="submit" value="Add Comment" class="inline-btn" name="add_comment">
        </form>

        <h1 class="heading">User Comments</h1>

        <div class="box-container">
            <div class="box">
                <div class="user">
                    <img src="ProfileImages/pic-1.jpg" alt="">
                    <div>
                        <h3>Shaikh Anas</h3>
                        <span>22-10-2022</span>
                    </div>
                </div>
                <div class="comment-box">This is a comment from Shaikh Anas</div>
                <form action="" class="flex-btn">
                    <input type="submit" value="Edit Comment" name="edit_comment" class="inline-option-btn">
                    <input type="submit" value="Delete Comment" name="delete_comment" class="inline-delete-btn">
                </form>
            </div>

            <!-- Repeat the comment block for other users -->

        </div>

    </section>

</asp:Content>
